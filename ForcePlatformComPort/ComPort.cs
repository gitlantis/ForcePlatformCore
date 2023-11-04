using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForcePlatformComPort
{
    public class ComPort
    {
        public delegate void DataReceivedHandler(AdcData data);
        public event DataReceivedHandler DataReceived;

        private SerialPort sp;
        private bool exactDevice = false;
        private string inStr = "";
        private string[] ss = new string[20];

        AdcData adcData =new AdcData();

        public ComPort(bool autoDetect, string port, int filterLength)
        {
            Init(filterLength);

            if (autoDetect) AutoDetect("");
            else AutoDetect(port);
        }

        public void Init(int filterLength)
        {
            adcData.FilterLength = filterLength;
            adcData.CurrentAdc = new int[16];
            adcData.OlderAdc = new int[16];
            adcData.ZeroAdc = new int[16];
            adcData.ZeroedAdc = new int[16];
            adcData.FilterBuff = new int[16, filterLength];
            adcData.FilteredAdc = new int[16];
            adcData.MiddledAdc = new int[16];
            adcData.AbsAdc = new int[16];
            adcData.DiffZ = new int[4];
            adcData.DiffX = new int[4];
            adcData.DiffY = new int[4];
        }
        public void Zero()
        {
            for (int i = 0; i < adcData.CurrentAdc.Length; i++) { adcData.ZeroAdc[i] = adcData.MiddledAdc[i]; }

            sp.ReadExisting();
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
            sp.Dispose();
            Disconnect();
            Connect();
        }

        private void AutoDetect(string port)
        {
            string[] availablePorts = SerialPort.GetPortNames();
            if (port.Length != 0)
                availablePorts[0] = port;

            foreach (string portName in availablePorts)
            {
                try
                {
                    if (!exactDevice)
                    {
                        sp = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
                        Connect();
                        for (int i = 0; i < 6; i++)
                        {
                            Thread.Sleep(500);
                            if (inStr.Length == 0) break;
                        }

                        if (exactDevice) break;
                        Disconnect();
                    }
                }
                catch (Exception) { }
            }

            if (!exactDevice)
            {
                string message = "Device did not found, check connections and try to rerun application set to manual configuration";
                string caption = "Error detected during device search";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void Connect()
        {
            try
            {
                inStr = "";
                sp.DataReceived += new SerialDataReceivedEventHandler(onReceive);
                sp.Open();
            }
            catch (Exception) { }
        }

        public void Disconnect()
        {
            try
            {
                sp.DataReceived -= new SerialDataReceivedEventHandler(onReceive);
                sp.Close();
            }
            catch (Exception) { }
        }

        private void onReceive(object sender, SerialDataReceivedEventArgs e)
        {
            inStr += sp.ReadExisting(); while ((inStr.Length > 106) && (inStr[106] != 10) && (inStr[105] != 13)) inStr = inStr.Substring(1);

            if ((inStr.Length > 106) && (inStr[106] == 10) && (inStr[105] == 13) && (inStr[0] == 90))
            {
                exactDevice = true;
                string tempString = inStr.Substring(1, 104);
                inStr = inStr.Substring(106);

                for (int i = 0; i < 16; i++) ss[i] = tempString.Substring(i * 6, 6);

                // order correction
                string ts;
                for (int i = 0; i < 4; i++)
                {
                    ts = ss[i + 8]; ss[i + 8] = ss[i + 0]; ss[i + 0] = ts;
                    ts = ss[i + 12]; ss[i + 12] = ss[i + 4]; ss[i + 4] = ts;
                }

                ss[16] = tempString.Substring(96, 8);

                int[] _temp = new int[17];
                try { for (int i = 0; i < 17; i++) _temp[i] = Convert.ToInt32(ss[i], 16) >> 4; } catch { return; };

                for (int i = 0; i < 16; i++) adcData.CurrentAdc[i] = _temp[i];
                adcData.CurrentTimeMC = _temp[16]; FreshData();

                DataReceived?.Invoke(adcData);
            }
        }

        private void FilterData()
        {
            long[] sums = new long[16];
            int tmp;
            for (int j = 0; j < 16; j++)
            {
                for (int i = 1; i < adcData.FilterLength; i++)
                {
                    adcData.FilterBuff[j, i - 1] = adcData.FilterBuff[j, i];
                }
                adcData.FilterBuff[j, adcData.FilterLength - 1] = adcData.ZeroedAdc[j];
            }

            for (int j = 0; j < 16; j++)
            {
                sums[j] = 0; tmp = 0;
                for (int i = 0; i < adcData.FilterLength; i++)
                {
                    tmp++;
                    sums[j] += adcData.FilterBuff[j, i] * tmp;
                }
                adcData.FilteredAdc[j] = (int)(sums[j] / tmp);
                adcData.AbsAdc[j] = Math.Abs(adcData.FilteredAdc[j]);
            }

            for (int j = 0; j < 4; j++) { adcData.DiffZ[j] = 0; for (int i = 0; i < 4; i++) adcData.DiffZ[j] += adcData.AbsAdc[i + j * 4]; };

            for (int j = 0; j < 4; j++)
            {
                adcData.DiffX[j] = (adcData.AbsAdc[j * 4 + 0] + adcData.AbsAdc[j * 4 + 3]) - (adcData.AbsAdc[j * 4 + 1] + adcData.AbsAdc[j * 4 + 2]);
                adcData.DiffY[j] = (adcData.AbsAdc[j * 4 + 0] + adcData.AbsAdc[j * 4 + 1]) - (adcData.AbsAdc[j * 4 + 2] + adcData.AbsAdc[j * 4 + 3]);
            };
        }

        private void FreshData()
        {
            for (int i = 0; i < adcData.CurrentAdc.Length; i++) { adcData.ZeroedAdc[i] = adcData.CurrentAdc[i] - adcData.ZeroAdc[i]; adcData.MiddledAdc[i] = (int)((adcData.FilterLength * adcData.MiddledAdc[i] + adcData.CurrentAdc[i]) / (adcData.FilterLength + 1)); }
            FilterData();
        }
    }
}

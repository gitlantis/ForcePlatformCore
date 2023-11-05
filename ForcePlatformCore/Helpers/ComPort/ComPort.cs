using System.IO.Ports;

namespace ForcePlatformCore.Helpers.ComPort
{
    public class ComPort
    {
        private SerialPort sp;
        public bool connected = false;
        private string[] ss = new string[20];
        AdcSerialData adcData = new AdcSerialData();

        public ComPort(bool autoDetect, string port, int filterLength)
        {
            adcData.Init(filterLength);

            if (autoDetect) AutoDetect("");
            else AutoDetect(port);
        }

        public void Zero()
        {
            for (int i = 0; i < adcData.CurrentAdc.Length; i++) { adcData.ZeroAdc[i] = adcData.MiddledAdc[i]; }
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
                    if (!connected)
                    {
                        sp = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
                        Connect();
                        for (int i = 0; i < 6; i++)
                        {
                            Thread.Sleep(500);
                            onReceive();
                            if (adcData.CurrentTimeMC == 0) break;
                        }

                        if (connected) break;
                        Disconnect();
                    }
                }
                catch (Exception) { }
            }

            if (!connected)
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
                sp.Open();
            }
            catch (Exception) { }
        }

        public void Disconnect()
        {
            try
            {
                sp.Close();
            }
            catch (Exception) { }
        }

        public AdcSerialData onReceive()
        {
            string[] _temps = sp.ReadExisting().Split('\n');

            foreach (string s in _temps)
            {
                try
                {
                    if ((s[0] == 'Z') && (s.Length > 104))
                    {
                        connected = true;
                        string _s = s.Substring(1);
                        string[] ss = new string[17];
                        for (int i = 0; i < 16; i++) ss[i] = _s.Substring(i * 6, 6);

                        string ts;
                        for (int i = 0; i < 4; i++)
                        {
                            ts = ss[i + 8]; ss[i + 8] = ss[i + 0]; ss[i + 0] = ts;
                            ts = ss[i + 12]; ss[i + 12] = ss[i + 4]; ss[i + 4] = ts;
                        }

                        ss[16] = _s.Substring(96, 8);

                        int[] _tmp = new int[17];
                        try { for (int i = 0; i < 17; i++) _tmp[i] = Convert.ToInt32(ss[i], 16) >> 4; } catch { return null; };

                        for (int i = 0; i < 16; i++) adcData.CurrentAdc[i] = _tmp[i];
                        adcData.CurrentTimeMC = _tmp[16]; FreshData();
                    }
                }
                catch { }
            }
            return adcData;
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

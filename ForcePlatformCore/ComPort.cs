//using System;
//using System.Collections.Generic;
//using System.IO.Ports;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using ForcePlatformCore.Models;
//using System.Threading;

//namespace ForcePlatformCore
//{
//    public class ComPort
//    {
//        private SerialPort sp;
//        private bool exactDevice = false;
//        private string inStr = "";
//        private string[] ss = new string[20];

//        public ComPort(bool detect, string port)
//        {
//            if (detect) AutoDetect("");
//            else AutoDetect(port);
//        }

//        private void AutoDetect(string port)
//        {
//            string[] availablePorts = SerialPort.GetPortNames();
//            if (port.Length != 0)
//                availablePorts[0] = port;

//            foreach (string portName in availablePorts)
//            {
//                try
//                {
//                    if (!exactDevice)
//                    {
//                        sp = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
//                        Connect();
//                        for (int i = 0; i < 6; i++)
//                        {
//                            Thread.Sleep(500);
//                            if (inStr.Length==0) break;                            
//                        }
                        
//                        if (exactDevice) break;
//                        Disconnect();
//                    }
//                }
//                catch (Exception) { }
//            }

//            if (!exactDevice)
//            {
//                string message = "Device did not found, check connections and try to rerun application set to manual configuration";
//                string caption = "Error detected during device search";
//                MessageBoxButtons buttons = MessageBoxButtons.OK;
//                DialogResult result;

//                result = MessageBox.Show(message, caption, buttons);
//                if (result == DialogResult.OK)
//                {
//                    Environment.Exit(0);
//                }
//            }
//        }

//        public void Connect()
//        {
//            try
//            {
//                inStr = "";
//                sp.DataReceived += new SerialDataReceivedEventHandler(onReceive);
//                sp.Open();
//            }
//            catch (Exception) { }
//        }

//        public void Disconnect()
//        {
//            try
//            {
//                sp.DataReceived -= new SerialDataReceivedEventHandler(onReceive);
//                sp.Close();
//            }
//            catch (Exception) { }
//        }

//        private void onReceive(object sender, SerialDataReceivedEventArgs e)
//        {
//            inStr += sp.ReadExisting(); while ((inStr.Length > 106) && (inStr[106] != 10) && (inStr[105] != 13)) inStr = inStr.Substring(1);

//            if ((inStr.Length > 106) && (inStr[106] == 10) && (inStr[105] == 13) && (inStr[0] == 90))
//            {
//                exactDevice = true;
//                string tempString = inStr.Substring(1, 104);
//                inStr = inStr.Substring(106);

//                for (int i = 0; i < 16; i++) ss[i] = tempString.Substring(i * 6, 6);

//                // order correction
//                string ts;
//                for (int i = 0; i < 4; i++)
//                {
//                    ts = ss[i + 8]; ss[i + 8] = ss[i + 0]; ss[i + 0] = ts;
//                    ts = ss[i + 12]; ss[i + 12] = ss[i + 4]; ss[i + 4] = ts;
//                }

//                ss[16] = tempString.Substring(96, 8);

//                int[] _temp = new int[17];
//                try { for (int i = 0; i < 17; i++) _temp[i] = Convert.ToInt32(ss[i], 16) >> 4; } catch { return; };

//                for (int i = 0; i < 16; i++) AdcData.CurrentAdc[i] = _temp[i];
//                AdcData.CurrentTimeMC = _temp[16]; AdcData.FreshData();
//            }

//        }

//    }
//}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.Models;
using static System.Windows.Forms.Design.AxImporter;
using LiveCharts;
using LiveCharts.WinForms;
using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using Timer = System.Windows.Forms.Timer;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using ForcePlatformCore.Models;
using ForcePlatformCore.Helpers;

namespace ForcePlatformCore
{
    public partial class Form1 : Form
    {
        //readonly Timer AddPlotDataTimer = new() { Interval = 100, Enabled = true };
        readonly Timer UpdatePlotTimer = new() { Interval = 100, Enabled = true };
        readonly Timer UpdateStopperTimer = new() { Interval = 5000, Enabled = false };
        readonly int _plateNumber = 0;

        readonly ScottPlot.Plottable.DataLogger LoggerWeight;
        readonly ScottPlot.Plottable.DataLogger LoggerDiffX;
        readonly ScottPlot.Plottable.DataLogger LoggerDiffY;

        private bool isStopped = false;
        private int oldCurrentTimeMC;
        private List<CSVModel> csvData = new List<CSVModel>();

        public Form1(int plateNumber)
        {
            InitializeComponent();

            this.Text = $"Plate {plateNumber}";
            _plateNumber = plateNumber;

            comboBox1.SelectedIndex = 0;

            LoggerWeight = formsPlot1.Plot.AddDataLogger(label: "Weight", lineWidth: 3);
            LoggerDiffX = formsPlot1.Plot.AddDataLogger(label: "DiffX", lineWidth: 3);
            LoggerDiffY = formsPlot1.Plot.AddDataLogger(label: "DiffY", lineWidth: 3);

            formsPlot1.Plot.Legend(checkBox4.Checked);

            //AddRandomWalkData(100);

            //AddPlotDataTimer.Tick += AddRandomWalkData;
            UpdatePlotTimer.Tick += UpdatePlotTimer_Tick;
            UpdateStopperTimer.Tick += UpdateStopperTimer_Tick;
            //var a = new NewDataListener();
            //a.OnTimeChanged += (o, e) => AddRandomWalkData(AdcData.CurrentTimeMC);

            //Plot style
            var style = new ScottPlot.Styles.Black();
            var palette = new ScottPlot.Palettes.Category10();

            formsPlot1.Plot.Style(style);
            formsPlot1.Plot.Palette = palette;

            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel(comboBox1.Text);

            LoggerWeight.ViewSlide();
            LoggerDiffX.ViewSlide();
            LoggerDiffY.ViewSlide();
            formsPlot1.Refresh();
        }

        //private void AddRandomWalkData(object sender, EventArgs e)
        //{
        //    //if (AdcData.CurrentTimeMC != oldCurrentTimeMC)
        //    {
        //        var plate = _plateNumber - 1;
        //        LoggerWeight.Add(LoggerWeight.Count, AdcData.Weights[plate]);
        //        LoggerDiffX.Add(LoggerWeight.Count, AdcData.DiffX[plate]);
        //        LoggerDiffY.Add(LoggerWeight.Count, AdcData.DiffY[plate]);
        //        csvData.Add(new CSVModel
        //        {
        //            Weight = AdcData.Weights[plate],
        //            DiffX = AdcData.DiffX[plate],
        //            DiffY = AdcData.DiffY[plate]
        //        });
        //        //richTextBox1.Invoke((MethodInvoker)delegate {
        //        //    richTextBox1.AppendText("\r\n" + AdcData.CurrentTimeMC);
        //        //    richTextBox1.ScrollToCaret();
        //        //});

        //        oldCurrentTimeMC = AdcData.CurrentTimeMC;
        //    }
        //}

        private void UpdateStopperTimer_Tick(object sender, EventArgs e)
        {
            isStopped = false;
            LoggerWeight.ManageAxisLimits = !isStopped;
            LoggerDiffX.ManageAxisLimits = !isStopped;
            formsPlot1.Configuration.Pan = isStopped;
            formsPlot1.Configuration.Zoom = isStopped;
            UpdateStopperTimer.Stop();
        }

        private void UpdatePlotTimer_Tick(object sender, EventArgs e)
        {
            //AddRandomWalkData(1);

            //if (LoggerWeight.Count == LoggerWeight.CountOnLastRender)
            //    return;

            if (AdcData.CurrentTimeMC != oldCurrentTimeMC)
            {
                var plate = _plateNumber - 1;
                LoggerWeight.Add(AdcData.CurrentTimeMC, AdcData.Weights[plate]);
                LoggerDiffX.Add(AdcData.CurrentTimeMC, AdcData.DiffX[plate]);
                LoggerDiffY.Add(AdcData.CurrentTimeMC, AdcData.DiffY[plate]);
                //        //    richTextBox1.AppendText("\r\n" + AdcData.CurrentTimeMC);
                //        //    richTextBox1.ScrollToCaret();
                oldCurrentTimeMC = AdcData.CurrentTimeMC;
            }

            formsPlot1.Refresh();
        }

        private void formsPlot1_MouseDown(object sender, MouseEventArgs e)
        {
            isStopped = true;
            LoggerWeight.ManageAxisLimits = !isStopped;
            LoggerDiffX.ManageAxisLimits = !isStopped;
            LoggerDiffY.ManageAxisLimits = !isStopped;
            formsPlot1.Configuration.Pan = isStopped;
            formsPlot1.Configuration.Zoom = isStopped;
            UpdateStopperTimer.Stop();
            UpdateStopperTimer.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            LoggerWeight.IsVisible = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            LoggerDiffX.IsVisible = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            LoggerDiffX.IsVisible = checkBox3.Checked;
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Plot.Legend(checkBox4.Checked);
            formsPlot1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdcData.Zero();
            csvData = new List<CSVModel>();

            LoggerWeight.Clear();
            LoggerDiffX.Clear();
            LoggerDiffY.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button2.Text = AddNewDataTimer.Enabled ? "Continue" : "Stop";
            //AddNewDataTimer.Enabled = !AddNewDataTimer.Enabled;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel(comboBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CSVProcessor.Save(_plateNumber, csvData);

            AdcData.Zero();
            csvData = new List<CSVModel>();

            LoggerWeight.Clear();
            LoggerDiffX.Clear();
            LoggerDiffY.Clear();
        }
    }
}

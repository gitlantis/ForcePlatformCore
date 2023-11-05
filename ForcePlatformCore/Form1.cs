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
using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using Timer = System.Windows.Forms.Timer;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using ForcePlatformCore.Models;
using ForcePlatformCore.Helpers;
using System.Collections;

namespace ForcePlatformCore
{
    public partial class Form1 : Form
    {
        //readonly Timer AddPlotDataTimer = new() { Interval = 100, Enabled = true };
        //readonly Timer UpdatePlotTimer = new() { Interval = 10000, Enabled = true };
        //readonly Timer UpdateStopperTimer = new() { Interval = 5000, Enabled = false };
        readonly int _plateNumber = 0;
        
        readonly ScottPlot.Plottable.DataLogger LoggerWeight;
        readonly ScottPlot.Plottable.DataLogger LoggerDiffX;
        readonly ScottPlot.Plottable.DataLogger LoggerDiffY;

        private bool isStopped = false;
        private List<CSVModel> csvData = new List<CSVModel>();
        private int time = 0;
        public Form1(int plateNumber)
        {
            InitializeComponent();

            this.Text = $"Plate {plateNumber+1}";
            _plateNumber = plateNumber;

            comboBox1.SelectedIndex = 0;

            LoggerWeight = formsPlot1.Plot.AddDataLogger(label: "DiffZ", lineWidth: 3);
            LoggerDiffX = formsPlot1.Plot.AddDataLogger(label: "DiffX", lineWidth: 3);
            LoggerDiffY = formsPlot1.Plot.AddDataLogger(label: "DiffY", lineWidth: 3);

            formsPlot1.Plot.Legend(checkBox4.Checked);

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

        private void UpdateStopperTimer_Tick(object sender, EventArgs e)
        {
            isStopped = false;
            LoggerWeight.ManageAxisLimits = !isStopped;
            LoggerDiffX.ManageAxisLimits = !isStopped;
            formsPlot1.Configuration.Pan = isStopped;
            formsPlot1.Configuration.Zoom = isStopped;
            //UpdateStopperTimer.Stop();
        }

        private void formsPlot1_MouseDown(object sender, MouseEventArgs e)
        {
            isStopped = true;
            LoggerWeight.ManageAxisLimits = !isStopped;
            LoggerDiffX.ManageAxisLimits = !isStopped;
            LoggerDiffY.ManageAxisLimits = !isStopped;
            formsPlot1.Configuration.Pan = isStopped;
            formsPlot1.Configuration.Zoom = isStopped;
            //UpdateStopperTimer.Stop();
            //UpdateStopperTimer.Start();
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
            csvData = new List<CSVModel>();

            LoggerWeight.Clear();
            LoggerDiffX.Clear();
            LoggerDiffY.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
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
            CSVProcessor.Save(_plateNumber+1, csvData);

            csvData = new List<CSVModel>();

            LoggerWeight.Clear();
            LoggerDiffX.Clear();
            LoggerDiffY.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var points = AdcBuffer.BufferItems.Where(c => c.Plate == _plateNumber).ToList();
            foreach (var point in points)
            {
                LoggerDiffX.Add(point.CurrentTimeMC, point.DiffX);
                LoggerDiffY.Add(point.CurrentTimeMC, point.DiffY);
                LoggerWeight.Add(point.CurrentTimeMC, point.DiffZ);
            }

            AdcBuffer.BufferItems.RemoveAll(item => points.Contains(item));

            formsPlot1.Refresh();
        }

        public void Clear()
        {
            LoggerWeight.Clear();
            LoggerDiffX.Clear();
            LoggerDiffY.Clear();
            formsPlot1.Refresh();
        }
    }
}

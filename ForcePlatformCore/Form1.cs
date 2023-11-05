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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.IO;

namespace ForcePlatformCore
{
    public partial class Form1 : Form
    {
        readonly int _plateNumber = 0;

        readonly ScottPlot.Plottable.DataLogger LoggerDiffX;
        readonly ScottPlot.Plottable.DataLogger LoggerDiffY;
        readonly ScottPlot.Plottable.DataLogger LoggerDiffZ;

        private bool isStopped = false;
        private List<CSVModel> csvData = new List<CSVModel>();
        private int stopTime = 0;

        public Form1(int plateNumber)
        {
            InitializeComponent();

            this.Text = $"Plate {plateNumber + 1}";
            _plateNumber = plateNumber;

            comboBox1.SelectedIndex = 0;

            LoggerDiffX = formsPlot1.Plot.AddDataLogger(label: "DiffX", lineWidth: 3);
            LoggerDiffY = formsPlot1.Plot.AddDataLogger(label: "DiffY", lineWidth: 3);
            LoggerDiffZ = formsPlot1.Plot.AddDataLogger(label: "DiffZ", lineWidth: 3);

            formsPlot1.Plot.Legend(checkBox4.Checked);

            var style = new ScottPlot.Styles.Black();
            var palette = new ScottPlot.Palettes.Category10();

            formsPlot1.Plot.Style(style);
            formsPlot1.Plot.Palette = palette;

            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel(comboBox1.Text);

            LoggerDiffX.ViewSlide();
            LoggerDiffY.ViewSlide();
            LoggerDiffZ.ViewSlide();

            formsPlot1.Refresh();
        }

        private void formsPlot1_MouseDown(object sender, MouseEventArgs e)
        {
            isStopped = true;
            LoggerDiffX.ManageAxisLimits = !isStopped;
            LoggerDiffY.ManageAxisLimits = !isStopped;
            LoggerDiffZ.ManageAxisLimits = !isStopped;
            formsPlot1.Configuration.Pan = isStopped;
            formsPlot1.Configuration.Zoom = isStopped;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            LoggerDiffX.IsVisible = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            LoggerDiffY.IsVisible = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            LoggerDiffZ.IsVisible = checkBox3.Checked;
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Plot.Legend(checkBox4.Checked);
            formsPlot1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            csvData = new List<CSVModel>();

            LoggerDiffX.Clear();
            LoggerDiffY.Clear();
            LoggerDiffZ.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            button2.Text = !timer1.Enabled ? "Continue" : "Pause";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel(comboBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Save();
                
                string message = $"data saved in: {path} file";
                string caption = "Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

            }catch(Exception err)
            {
                string message = err.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stopTime >= 50)
            {
                isStopped = false;
                stopTime = 0;
                LoggerDiffX.ManageAxisLimits = !isStopped;
                LoggerDiffY.ManageAxisLimits = !isStopped;
                LoggerDiffZ.ManageAxisLimits = !isStopped;
                formsPlot1.Configuration.Pan = isStopped;
                formsPlot1.Configuration.Zoom = isStopped;
            }

            if (isStopped) stopTime++;

            var points = AdcBuffer.BufferItems.Where(c => c.Plate == _plateNumber).ToList();
            foreach (var point in points)
            {
                LoggerDiffX.Add(point.CurrentTimeMC, point.DiffX);
                LoggerDiffY.Add(point.CurrentTimeMC, point.DiffY);
                LoggerDiffZ.Add(point.CurrentTimeMC, point.DiffZ);
                
                csvData.Add(new CSVModel { 
                    Time = point.Time, 
                    DiffX = point.DiffX, 
                    DiffY = point.DiffY, 
                    DiffZ = point.DiffZ 
                });
            }

            AdcBuffer.BufferItems.RemoveAll(item => points.Contains(item));

            formsPlot1.Refresh();
        }

        public void Clear()
        {
            LoggerDiffX.Clear();
            LoggerDiffY.Clear();
            LoggerDiffZ.Clear();

            formsPlot1.Refresh();
        }

        public string Save()
        {
            var result = CSVProcessor.Save(_plateNumber + 1, csvData);

            csvData = new List<CSVModel>();

            LoggerDiffX.Clear();
            LoggerDiffY.Clear();
            LoggerDiffX.Clear();

            return result;
        }
    }
}

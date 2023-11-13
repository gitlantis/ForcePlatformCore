using ForcePlatformData;
using ForcePlatformData.Models;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForcePlatformCore
{
    public partial class RadarForm : Form
    {
        private bool pausePlot = false;
        private Plot plt;
        private double[] maxValues = new double[72];
        private double[,] plotValues;

        private int stopTime = 0;
        private bool isStopped = false;
        private double weight = 1;
        private int plateNumber = -1;
        public double[] convertToPolar(double X, double Y)
        {
            double[] res = new double[2] { 0, 0 };

            double vectorVal = Math.Sqrt(X * X + Y * Y);

            double angle = 0;
            //if (X < 0) angle += (double)180;
            //if (Y < 0) angle += (double)90;

            res[0] = vectorVal; // value of radius
            if (vectorVal != 0)
            {
                var _temp = Math.Abs(X) / vectorVal;

                angle = Math.Acos(_temp) / (Math.PI * 2) * 360;
                if (Y < 0) angle = 180 - angle;
                if (X < 0) angle = 360 - angle;
                res[1] = angle;
            }
            return res;
        }

        private void initalizePlot()
        {
            plt = new Plot(1000, 1000);
            for (int i = 0; i < 72; i++) maxValues[i++] = 100;//360/72 // 72ta seksizy
            plotValues = new double[1, 72];
            formsPlot1.Plot.Clear();
            timer1.Enabled = true;
        }

        public RadarForm(int plateNumber)
        {
            this.plateNumber = plateNumber;
            InitializeComponent();

            initalizePlot();
            drawRadarChart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stopTime >= 50)
            {
                isStopped = false;
                stopTime = 0;
            }

            if (isStopped) stopTime++;

            if (!pausePlot && !isStopped)
            {
                drawRadarChart();
            }
        }

        public void Pause(bool isPaused)
        {
            pausePlot = isPaused;
        }

        private void formsPlot1_MouseDown(object sender, MouseEventArgs e)
        {
            isStopped = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                Thread.Sleep(2000);
                weight = AdcBuffer.BufferItems.Where(c => c.Plate == plateNumber && c.DiffZ != 0).FirstOrDefault().DiffZ / AppConfig.Config.CalibrateZ;
                label1.Text = $"Weight: {weight.ToString("0.000")}kg";
                initalizePlot();
            }
            catch { }
        }

        private void drawRadarChart()
        {
            if (Program.ComPort.Connected)
            {
                //double angle = Math.Asin(X/R); vs sign Y   //cos ( // бир минут!
                var points = AdcBuffer.BufferItems.Where(c => c.Plate == plateNumber).ToList();

                double[] cc;

                var tmp = new double[72];

                for (int i = 0; i < 72; i++)
                {
                    foreach (var point in points)
                    {
                        cc = convertToPolar((2 * point.DiffX) / (weight * 100), (2 * point.DiffY) / (weight * 100)); // X Y  X = 2*DiffX /weight *100; Y = 2*DiffY /weight * 100;
                        double angle = cc[1];
                        int section = (int)(angle / 360 * 72) % 72; // подгон на количество секций, angle градусда
                        plotValues[0, section] = cc[0];
                    }
                }

                formsPlot1.Plot.Clear();
                var radar = formsPlot1.Plot.AddRadar(plotValues, independentAxes: false, maxValues: maxValues, false);

                radar.CategoryLabels = new string[maxValues.Length];
                for (int i = 0; i < 72; i++) { radar.CategoryLabels[i] = (i % 18 == 0) ? (i * 5).ToString() : ""; }

                formsPlot1.Refresh();
                AdcBuffer.BufferItems.Clear();
            }
        }
    }
}

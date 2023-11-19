using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using ForcePlatformCore.Helpers.ComPort;
using ForcePlatformCore.Models;
using ForcePlatformData;
using ForcePlatformData.Models;
using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using ScottPlot.Plottable;

namespace ForcePlatformCore
{
    public partial class DataLoggerForm : Form
    {
        public int PlateId;
        private bool pausePlot = false;
        private AppsettingsModel? config;
        private TextBox[] textBoxes = new TextBox[12];
        readonly int plateNumber = 0;

        readonly DataLogger[] LoggerDiffX = new DataLogger[4];
        readonly DataLogger[] LoggerDiffY = new DataLogger[4];
        readonly DataLogger[] LoggerDiffZ = new DataLogger[4];
        //    LoggerDiffP1X;
        //readonly DataLogger LoggerDiffP1Y;
        //readonly DataLogger LoggerDiffP1Z;

        //readonly DataLogger LoggerDiffP2X;
        //readonly DataLogger LoggerDiffP2Y;
        //readonly DataLogger LoggerDiffP2Z;

        //readonly DataLogger LoggerDiffP3X;
        //readonly DataLogger LoggerDiffP3Y;
        //readonly DataLogger LoggerDiffP3Z;

        //readonly DataLogger LoggerDiffP4X;
        //readonly DataLogger LoggerDiffP4Y;
        //readonly DataLogger LoggerDiffP4Z;

        private bool isStopped = false;
        private List<CsvModel> csvData = new List<CsvModel>();
        private int stopTime = 0;
        private double coeffcent = 0;
        private Dictionary<int, AxisItem> weight = new Dictionary<int, AxisItem> {
            { 0,new AxisItem() },
            { 1,new AxisItem() },
            { 2,new AxisItem() },
            { 3,new AxisItem() }
        };
        public List<int> Axis = new List<int> { 0, 1, 2 };

        public DataLoggerForm()
        {
            InitializeComponent();

            this.Text = $"Plate data";

            for (int i = 0; i < 4; i++)
            {
                LoggerDiffX[i] = formsPlot1.Plot.AddDataLogger(label: $"p{i}X", lineWidth: 3);
                LoggerDiffX[i].ViewSlide();
                LoggerDiffY[i] = formsPlot1.Plot.AddDataLogger(label: $"p{i}X", lineWidth: 3);
                LoggerDiffY[i].ViewSlide();
                LoggerDiffZ[i] = formsPlot1.Plot.AddDataLogger(label: $"p{i}X", lineWidth: 3);
                LoggerDiffZ[i].ViewSlide();
            }

            //LoggerDiffP1Y = formsPlot1.Plot.AddDataLogger(label: "p1Y", lineWidth: 3);
            //LoggerDiffP1Z = formsPlot1.Plot.AddDataLogger(label: "p1Z", lineWidth: 3);

            //LoggerDiffP2X = formsPlot1.Plot.AddDataLogger(label: "p2X", lineWidth: 3);
            //LoggerDiffP2Y = formsPlot1.Plot.AddDataLogger(label: "p2Y", lineWidth: 3);
            //LoggerDiffP2Z = formsPlot1.Plot.AddDataLogger(label: "p2Z", lineWidth: 3);

            //LoggerDiffP3X = formsPlot1.Plot.AddDataLogger(label: "p3X", lineWidth: 3);
            //LoggerDiffP3Y = formsPlot1.Plot.AddDataLogger(label: "p3Y", lineWidth: 3);
            //LoggerDiffP3Z = formsPlot1.Plot.AddDataLogger(label: "p3Z", lineWidth: 3);

            //LoggerDiffP4X = formsPlot1.Plot.AddDataLogger(label: "p4X", lineWidth: 3);
            //LoggerDiffP4Y = formsPlot1.Plot.AddDataLogger(label: "p4Y", lineWidth: 3);
            //LoggerDiffP4Z = formsPlot1.Plot.AddDataLogger(label: "p4Z", lineWidth: 3);

            formsPlot1.Plot.Legend(checkBox4.Checked);

            var style = new ScottPlot.Styles.Black();
            var palette = new ScottPlot.Palettes.Category10();

            formsPlot1.Plot.Style(style);
            formsPlot1.Plot.Palette = palette;

            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel(comboBox1.Text);

            formsPlot1.Plot.AxisAuto();
            formsPlot1.Plot.AxisScale();

            //LoggerDiffP1X.ViewSlide();
            //LoggerDiffP1Y.ViewSlide();
            //LoggerDiffP1Z.ViewSlide();

            //LoggerDiffP2X.ViewSlide();
            //LoggerDiffP2Y.ViewSlide();
            //LoggerDiffP2Z.ViewSlide();

            //LoggerDiffP3X.ViewSlide();
            //LoggerDiffP3Y.ViewSlide();
            //LoggerDiffP3Z.ViewSlide();

            //LoggerDiffP4X.ViewSlide();
            //LoggerDiffP4Y.ViewSlide();
            //LoggerDiffP4Z.ViewSlide();

            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            textBoxes[4] = textBox5;
            textBoxes[5] = textBox6;
            textBoxes[6] = textBox7;
            textBoxes[7] = textBox8;
            textBoxes[8] = textBox9;
            textBoxes[9] = textBox10;
            textBoxes[10] = textBox11;
            textBoxes[11] = textBox12;

            for (int box = 0; box < textBoxes.Length; box++)
            {
                textBoxes[box].ReadOnly = true;
            }

            formsPlot1.Refresh();

            this.config = AppConfig.Config;
            comboBox1.SelectedIndex = 1;
        }

        private void formsPlot1_MouseDown(object sender, MouseEventArgs e)
        {
            isStopped = true;
            //LoggerDiffP1X.ManageAxisLimits = !isStopped;
            //LoggerDiffP1Y.ManageAxisLimits = !isStopped;
            //LoggerDiffP1Z.ManageAxisLimits = !isStopped;

            //LoggerDiffP2X.ManageAxisLimits = !isStopped;
            //LoggerDiffP2Y.ManageAxisLimits = !isStopped;
            //LoggerDiffP2Z.ManageAxisLimits = !isStopped;

            //LoggerDiffP3X.ManageAxisLimits = !isStopped;
            //LoggerDiffP3Y.ManageAxisLimits = !isStopped;
            //LoggerDiffP3Z.ManageAxisLimits = !isStopped;

            //LoggerDiffP4X.ManageAxisLimits = !isStopped;
            //LoggerDiffP4Y.ManageAxisLimits = !isStopped;
            //LoggerDiffP4Z.ManageAxisLimits = !isStopped;

            stopPlot(isStopped);

            formsPlot1.Configuration.Pan = isStopped;
            formsPlot1.Configuration.Zoom = isStopped;
            Program.ComPort.Zero();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void stopPlot(bool stopped)
        {
            for (int i = 0; i < 4; i++)
            {
                LoggerDiffX[i].ManageAxisLimits = !stopped;
                LoggerDiffZ[i].ManageAxisLimits = !stopped;
                LoggerDiffZ[i].ManageAxisLimits = !stopped;
            }
        }
        public void RefreshPlot(ReadySerialData data)
        {
            if (stopTime >= 50)
            {
                isStopped = false;
                stopTime = 0;

                stopPlot(isStopped);

                formsPlot1.Configuration.Pan = isStopped;
                formsPlot1.Configuration.Zoom = isStopped;
            }

            if (isStopped) stopTime++;

            if (!pausePlot)
            {
                for (var plate = 0; plate < 4; plate++)
                {
                    var points = SmallAdcBuffer.BufferItems[plate];
                    //addData(points);
                    LoggerDiffX[plate].Clear();
                    var newCoordX = points.Select(c => new Coordinate(c.Time.TotalMilliseconds / 5, c.DiffX));
                    LoggerDiffX[plate].AddRange(newCoordX);

                    LoggerDiffY[plate].Clear();
                    var newCoordY = points.Select(c => new Coordinate(c.Time.TotalMilliseconds / 5, c.DiffY));
                    LoggerDiffY[plate].AddRange(newCoordY);

                    LoggerDiffZ[plate].Clear();
                    var newCoordZ = points.Select(c => new Coordinate(c.Time.TotalMilliseconds / 5, c.DiffZ));
                    LoggerDiffZ[plate].AddRange(newCoordZ);

                    var axisItem = new AxisItem
                    {
                        Plate = plate,
                        DiffX = points.Select(c => c.DiffX).LastOrDefault(),
                        DiffY = points.Select(c => c.DiffY).LastOrDefault(),
                        DiffZ = points.Select(c => c.DiffZ).LastOrDefault(),

                    };
                    weight[plate] = axisItem;
                }
                formsPlot1.Refresh();

            }
        }

        private void addData(List<AdcBufferItem> items)
        {
            for (int i = 0; i < 4; i++)
            {

            }
        }
        public void Pause(bool isPaused)
        {
            pausePlot = isPaused;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SmallAdcBuffer.BufferItems[PlateId].Clear();
        }

        public void ClearLoggers()
        {
            for (int plate = 0; plate < 4; plate++)
            {
                LoggerDiffX[plate].Clear();
                LoggerDiffY[plate].Clear();
                LoggerDiffZ[plate].Clear();
            }
            formsPlot1.Refresh();
        }

        private void addRemoveAxis(DataLogger dataLogger, CheckBox checkBox, int index)
        {
            for (var plate = 0; plate < 4; plate++)
            {
                dataLogger.IsVisible = checkBox.Checked;
                if (checkBox.Checked) Axis.Add(index);
                else Axis.RemoveAll(item => item == index);
            }
        }

        //private void checkBoxXCheckedChanged(object sender, EventArgs e)
        //{

        //    formsPlot1.Refresh();
        //}

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    AddRemoveAxis(LoggerDiffX, checkBox1, 0);
        //}

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    AddRemoveAxis(LoggerDiffY, checkBox2, 1);
        //}

        //private void checkBox3_CheckedChanged(object sender, EventArgs e)
        //{
        //    AddRemoveAxis(LoggerDiffZ, checkBox3, 2);
        //}

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Plot.Legend(checkBox4.Checked);
            formsPlot1.Refresh();
        }

        public static double[] values = new double[12];
        public static double weight_koef_kg = AppConfig.Config.CalibrateZ; // потом закроем :)) ------------------------------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (var plate = 0; plate < 4; plate++)
            {
                var point = weight[plate];

                //if (points.Count > 0)
                {
                    double? temp = point.DiffZ / weight_koef_kg;

                    double? percX = (point.DiffX / point.DiffZ) * 100;
                    double? percY = (point.DiffY / point.DiffZ) * 100;

                    if (temp < 5) { 
                        temp = null;
                        percX = null;
                        percY = null;
                    }

                    if (comboBox1.SelectedIndex == 1)
                    {
                        var force = temp * AppConfig.Config.FreeFallAcc;
                        textBoxes[2 + (plate * 3)].Text = force!=null?string.Format("{0:0.0}", force):"---.-";
                    }
                    else
                        textBoxes[2 + (plate * 3)].Text = temp!=null?string.Format("{0:0.0}", temp) : "---.-";

                    textBoxes[0 + (plate * 3)].Text = percX!=null?string.Format("{0:0.0}", percX) + " %" : "---.- %";
                    textBoxes[1 + (plate * 3)].Text = percY!=null?string.Format("{0:0.0}", percY) + " %":"---.- %";

                }
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel(comboBox1.Text);

            if (comboBox1.SelectedIndex == 0) coeffcent = 1.0 / config.CalibrateZ;
            else coeffcent = config.FreeFallAcc / config.CalibrateZ;
        }
    }
}

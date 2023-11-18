using System.Data;
using System.Diagnostics;
using ForcePlatformData;
using ForcePlatformData.Models;
using ScottPlot;
using ScottPlot.Plottable;

namespace ForcePlatformCore
{
    public partial class DataLoggerForm : Form
    {
        public int PlateId;
        private bool pausePlot = false;
        private AppsettingsModel? config;
        readonly int plateNumber = 0;

        readonly DataLogger LoggerDiffX;
        readonly DataLogger LoggerDiffY;
        readonly DataLogger LoggerDiffZ;

        private bool isStopped = false;
        private List<CsvModel> csvData = new List<CsvModel>();
        private int stopTime = 0;
        private double coeffcent = 0;

        public List<int> Axis = new List<int> { 0, 1, 2 };

        public DataLoggerForm(int plateId)
        {
            InitializeComponent();

            this.Text = $"Plate {plateId + 1}";
            plateNumber = plateId;
            PlateId = plateId;

            LoggerDiffX = formsPlot1.Plot.AddDataLogger(label: "X", lineWidth: 3);
            LoggerDiffY = formsPlot1.Plot.AddDataLogger(label: "Y", lineWidth: 3);
            LoggerDiffZ = formsPlot1.Plot.AddDataLogger(label: "Z", lineWidth: 3);

            formsPlot1.Plot.Legend(checkBox4.Checked);

            var style = new ScottPlot.Styles.Black();
            var palette = new ScottPlot.Palettes.Category10();

            formsPlot1.Plot.Style(style);
            formsPlot1.Plot.Palette = palette;

            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel(comboBox1.Text);

            formsPlot1.Plot.AxisAuto();
            formsPlot1.Plot.AxisScale();

            LoggerDiffX.ViewSlide();
            LoggerDiffY.ViewSlide();
            LoggerDiffZ.ViewSlide();

            formsPlot1.Refresh();

            this.config = AppConfig.Config;
            comboBox1.SelectedIndex = 1;
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
            AddRemoveAxis(LoggerDiffX, checkBox1, 0);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            AddRemoveAxis(LoggerDiffY, checkBox2, 1);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            AddRemoveAxis(LoggerDiffZ, checkBox3, 2);
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Plot.Legend(checkBox4.Checked);
            formsPlot1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel(comboBox1.Text);
            if (comboBox1.SelectedIndex == 0) coeffcent = 1.0 / config.CalibrateZ;
            else coeffcent = config.FreeFallAcc / config.CalibrateZ;
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

            if (!pausePlot)
            {
                var points = SmallAdcBuffer.BufferItems[plateNumber];
                LoggerDiffX.Clear();
                var newCoordX = points.Select(c => new Coordinate(c.Time.TotalMilliseconds / 5, c.DiffX));
                LoggerDiffX.AddRange(newCoordX);


                LoggerDiffY.();
                var newCoordY = points.Select(c => new Coordinate(c.Time.TotalMilliseconds / 5, c.DiffY));
                LoggerDiffY.AddRange(newCoordY);

                LoggerDiffZ.Clear();
                var newCoordZ = points.Select(c => new Coordinate(c.Time.TotalMilliseconds / 5, c.DiffZ));
                LoggerDiffZ.AddRange(newCoordZ);

                formsPlot1.Refresh();
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
            LoggerDiffX.Clear();
            LoggerDiffY.Clear();
            LoggerDiffZ.Clear();
            formsPlot1.Refresh();
        }

        private void AddRemoveAxis(DataLogger dataLogger, CheckBox checkBox, int index)
        {
            dataLogger.IsVisible = checkBox.Checked;
            if (checkBox.Checked) Axis.Add(index);
            else Axis.RemoveAll(item => item == index);
            formsPlot1.Refresh();
        }
    }
}

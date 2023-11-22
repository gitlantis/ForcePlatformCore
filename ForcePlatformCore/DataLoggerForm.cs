using System.Data;
using ForcePlatformCore.Helpers.ComPort;
using ForcePlatformData;
using ForcePlatformData.Models;
using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using ScottPlot.Plottable;

namespace ForcePlatformCore
{
    public partial class DataLoggerForm : Form
    {
        private MainMDI mainMdi;
        public int PlateId;
        private List<ReadySerialData> loggerData = new List<ReadySerialData>();
        private bool pausePlot = false;
        private AppsettingsModel? config;
        private TextBox[] textBoxes = new TextBox[12];

        readonly DataLogger[] LoggerDiffX = new DataLogger[4];
        readonly DataLogger[] LoggerDiffY = new DataLogger[4];
        readonly DataLogger[] LoggerDiffZ = new DataLogger[4];

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
        CheckBox[] checkBoxes = new CheckBox[12];

        public DataLoggerForm(MainMDI mdi)
        {
            InitializeComponent();

            this.Text = $"Plate data";

            mainMdi = mdi;

            checkBoxes[0] = checkBox1;
            checkBoxes[1] = checkBox2;
            checkBoxes[2] = checkBox3;
            checkBoxes[3] = checkBox4;
            checkBoxes[4] = checkBox5;
            checkBoxes[5] = checkBox6;
            checkBoxes[6] = checkBox7;
            checkBoxes[7] = checkBox8;
            checkBoxes[8] = checkBox9;
            checkBoxes[9] = checkBox10;
            checkBoxes[10] = checkBox11;
            checkBoxes[11] = checkBox12;

            for (int i = 0; i < 4; i++)
            {
                LoggerDiffX[i] = formsPlot1.Plot.AddDataLogger(label: $"p{i + 1}X", lineWidth: 3);
                LoggerDiffX[i].ViewSlide();
                checkBoxes[0 + (i * 3)].ForeColor = LoggerDiffX[i].LineColor;

                LoggerDiffY[i] = formsPlot1.Plot.AddDataLogger(label: $"p{i + 1}Y", lineWidth: 3);
                LoggerDiffY[i].ViewSlide();
                checkBoxes[1 + (i * 3)].ForeColor = LoggerDiffY[i].LineColor;

                LoggerDiffZ[i] = formsPlot1.Plot.AddDataLogger(label: $"p{i + 1}Z", lineWidth: 3);
                LoggerDiffZ[i].ViewSlide();
                checkBoxes[2 + (i * 3)].ForeColor = LoggerDiffZ[i].LineColor;
            }

            formsPlot1.Plot.Legend(checkBox13.Checked);

            var style = new ScottPlot.Styles.Black();
            var palette = new ScottPlot.Palettes.Category10();

            formsPlot1.Plot.Style(style);
            formsPlot1.Plot.Palette = palette;

            comboBox1.SelectedIndex = (int)Constants.Units.N;
            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel(comboBox1.Text);

            formsPlot1.Plot.AxisAuto();
            formsPlot1.Plot.AxisScale();

            formsPlot1.Refresh();

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
                textBoxes[box].ReadOnly = true;

            this.config = AppConfig.Config;
            comboBox1.SelectedIndex = 1;
        }

        private void formsPlot1_MouseDown(object sender, MouseEventArgs e)
        {
            isStopped = true;
            stopPlot(isStopped);

            formsPlot1.Configuration.Pan = isStopped;
            formsPlot1.Configuration.Zoom = isStopped;
            Program.ComPort.Zero();
        }

        private void stopPlot(bool stopped)
        {
            stopTime = 0;
            for (int i = 0; i < 4; i++)
            {
                LoggerDiffX[i].ManageAxisLimits = !stopped;
                LoggerDiffY[i].ManageAxisLimits = !stopped;
                LoggerDiffZ[i].ManageAxisLimits = !stopped;
            }
        }

        public void RefreshPlot()
        {
            if (stopTime >= 100)
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
                var points = Program.ComPort.SharedData;
                pushToBuffer(points);
                Program.ComPort.SharedData.Clear();

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

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Plot.Legend(checkBox13.Checked);
            formsPlot1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (var plate = 0; plate < 4; plate++)
            {
                var diffX = weight[plate].DiffX;
                var diffY = weight[plate].DiffY;
                var diffZ = weight[plate].DiffZ;

                double? temp = diffZ / AppConfig.Config.CalibrateZ;

                double? percX = (diffX / diffZ) * 100;
                double? percY = (diffY / diffZ) * 100;

                if (temp < 5)
                {
                    temp = null;
                    percX = null;
                    percY = null;
                }

                if (comboBox1.SelectedIndex == (int)Constants.Units.N)
                {
                    mainMdi.Unit = Constants.Units.N;
                    var force = temp * AppConfig.Config.FreeFallAcc;
                    textBoxes[2 + (plate * 3)].Text = force != null ? string.Format("{0:0.0}", force) : "---.-";
                }
                else
                {
                    mainMdi.Unit = Constants.Units.KgF;
                    textBoxes[2 + (plate * 3)].Text = temp != null ? string.Format("{0:0.0}", temp) : "---.-";
                }

                textBoxes[0 + (plate * 3)].Text = percX != null ? string.Format("{0:0.0}", percX) + " %" : "---.- %";
                textBoxes[1 + (plate * 3)].Text = percY != null ? string.Format("{0:0.0}", percY) + " %" : "---.- %";
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            formsPlot1.Plot.XLabel("Time");
            formsPlot1.Plot.YLabel(comboBox1.Text);

            if (comboBox1.SelectedIndex == 0) coeffcent = 1.0 / config.CalibrateZ;
            else coeffcent = config.FreeFallAcc / config.CalibrateZ;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var gCheckBoxes = new CheckBox[4];
            gCheckBoxes[0] = checkBox14;
            gCheckBoxes[1] = checkBox15;
            gCheckBoxes[2] = checkBox16;
            gCheckBoxes[3] = checkBox17;

            for (var i = 0; i < 4; i++)
            {
                LoggerDiffX[i].IsVisible = checkBoxes[0 + (i * 3)].Checked & gCheckBoxes[i].Checked;
                LoggerDiffY[i].IsVisible = checkBoxes[1 + (i * 3)].Checked & gCheckBoxes[i].Checked;
                LoggerDiffZ[i].IsVisible = checkBoxes[2 + (i * 3)].Checked & gCheckBoxes[i].Checked;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (var plate = 0; plate < 4; plate++)
            {
                LoggerDiffX[plate].Clear();
                var newCoordsX = loggerData.Select(c => new Coordinate(c.CurrentTimeMC / 5, c.DiffX[plate]));
                LoggerDiffX[plate].AddRange(newCoordsX);
                LoggerDiffY[plate].Clear();
                var newCoordsY = loggerData.Select(c => new Coordinate(c.CurrentTimeMC / 5, c.DiffY[plate]));
                LoggerDiffY[plate].AddRange(newCoordsY);
                LoggerDiffZ[plate].Clear();
                var newCoordsZ = loggerData.Select(c => new Coordinate(c.CurrentTimeMC / 5, c.DiffZ[plate]));
                LoggerDiffZ[plate].AddRange(newCoordsZ);

                var loggerLastElement = loggerData.LastOrDefault(new ReadySerialData { DiffX = new int[4], DiffY = new int[4], DiffZ = new int[4] });
                weight[plate].DiffX = loggerLastElement.DiffX[plate];
                weight[plate].DiffY = loggerLastElement.DiffY[plate];
                weight[plate].DiffZ = loggerLastElement.DiffZ[plate];
            }
            formsPlot1.Refresh();
        }
        private void pushToBuffer(List<ReadySerialData> serialData)
        {
            foreach (var data in serialData)
            {
                var newSerialData = new ReadySerialData();
                newSerialData.Set(data.FilterLength, data.CurrentTimeMC, data.DiffX,data.DiffY,data.DiffZ);
                loggerData.Add(newSerialData);
                if (loggerData.Count > 200) loggerData.RemoveAt(0);
            } 

        }
    }
}


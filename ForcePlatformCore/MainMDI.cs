using ForcePlatformCore.Helpers.ComPort;
using ForcePlatformCore.Models;
using ForcePlatformData;
using ForcePlatformData.Helpers;
using ForcePlatformData.Models;
using ForcePlatformData.Service;

namespace ForcePlatformCore
{
    public partial class MainMDI : Form
    {
        private bool pauseAll = false;
        private CsvModel csvData = new CsvModel();
        private bool startRecording = false;
        private DateTime startRecrdTime = DateTime.Now;

        private ReportService reportService = new ReportService();
        private Camera camera = new Camera();
        private DataLoggerForm dataLogger;
        private AppsettingsModel config;
        public Constants.Units Unit = Constants.Units.KgF;
        private string fileName = "";

        private void MDIParent1_Shown(object sender, EventArgs e)
        {
            var userSelectForm = new UserSelect();
            userSelectForm.ShowDialog();

            var settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog();

            AdcData.DiffZ = new int[4];
            AdcData.CurrentTimeMC = 0;
            csvData.CsvItems = new Queue<CsvItem>();

            timer1.Enabled = Program.ComPort.Connected;
            ComPort.BufferIsFull += ComPortBufferStore;
            config = AppConfig.Config;
            AdcData.Init(config.FilterLength);

            ComPortBufferStore(null, EventArgs.Empty);
            resetAll();
        }

        public void ComPortBufferStore(object sender, EventArgs e)
        {
            if (startRecording)
            {
                toolStripButton4.ForeColor = Color.Orange;
                toolStripButton4.Text = "Saving data";

                recordStartStop();
            }

            Program.ComPort.Zero();
            Program.ComPort.ResetSaverData();
        }

        public MainMDI()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void plateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDataLogger();
        }

        public void ShowPlateLogger()
        {
            config = AppConfig.Config;
            closeAllChilds();
            showDataLogger();
        }

        private void showDataLogger()
        {
            var loggerOpen = false;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm is DataLoggerForm)
                {
                    loggerOpen = true;
                    break;
                }
            }
            if (!loggerOpen)
            {
                dataLogger = new DataLoggerForm(this);
                dataLogger.MdiParent = this;
                dataLogger.Show();
            }
        }

        private void closeAllToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Form fm in this.MdiChildren) fm.Close();
        }

        private void tileHorizontalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            horizontal();
        }

        private void tileVerticalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            vertical();
        }

        private void cascadeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void cellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizontal()
        {
            int childCount = MdiChildren.Length;
            if (childCount > 0)
            {
                int y = 0;
                int height = ClientSize.Height / childCount;
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Location = new Point(0, y);
                    childForm.Size = new Size(ClientSize.Width, height);
                    y += height;
                }
            }
        }

        private void vertical()
        {
            int childCount = MdiChildren.Length;
            if (childCount > 0)
            {
                int x = 0;
                int width = ClientSize.Width / childCount;
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Location = new Point(x, 0);
                    childForm.Size = new Size(width, ClientSize.Height);
                    x += width;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.ComPort.Connected)
            {
                Program.ComPort.OnReceive();
                dataLogger.RefreshPlot();
            }
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.ComPort.Disconnect();

            AppConfig.DbContext?.Dispose();
            AppConfig.DbContext = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ComPortBufferStore(null, EventArgs.Empty);
            resetAll();
        }

        private void resetAll()
        {
            SmallAdcBuffer.BufferItems[0].Clear();
            SmallAdcBuffer.BufferItems[1].Clear();
            SmallAdcBuffer.BufferItems[2].Clear();
            SmallAdcBuffer.BufferItems[3].Clear();

            foreach (Form childForm in MdiChildren)
            {
                if (childForm is DataLoggerForm)
                {
                    var activeChild = (DataLoggerForm)childForm;
                    activeChild.ClearLoggers();
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var user = new UserSelect();
            user.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            pauseSignals();
        }

        private void pauseSignals()
        {
            pauseAll = !pauseAll;

            if (pauseAll)
            {
                toolStripButton3.Text = "Continue";
                toolStripButton3.Image = Image.FromFile("assets/play-circle-o.png");
            }
            else
            {
                toolStripButton3.Text = "Pause";
                toolStripButton3.Image = Image.FromFile("assets/pause-circle-o.png");
            }
            foreach (Form childForm in MdiChildren)
            {
                if (childForm is DataLoggerForm)
                {
                    var activeChild = (DataLoggerForm)childForm;
                    activeChild.Pause(pauseAll);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Program.User == null)
            {
                Program.Message("Warning", $"Please select a user");
                return;
            }

            csvData.FilterLength = SharedStaticModel.FilterLength;
            csvData.ExerciseType = SharedStaticModel.ExerciseType;

            if (csvData.ExerciseType.Length == 0)
            {
                Program.Message("Warning", "Plese choose exerceise type");
                return;
            }

            if (Program.User.Id < 1)
            {
                Program.Message("Warning", "Please select a user");
                return;
            }

            recordStartStop();
        }

        private void recordStartStop()
        {
            startRecording = !startRecording;
            Program.ComPort.StartRecording = startRecording;

            if (startRecording)
            {
                csvData.CsvItems.Clear();
                Program.ComPort.ResetSaverData();

                toolStripButton4.ForeColor = Color.Red;
                toolStripButton4.Text = "Stop recording";
                toolStripButton4.Image = Image.FromFile("assets/stop-circle-o-r.png");
                startRecrdTime = DateTime.Now;

                fileName = $"platform_data_{Program.User.Id}_{SharedStaticModel.ExerciseTypeIndex + 1}_{DateTimeOffset.Now.ToUnixTimeSeconds()}";
                if (camera.IsOpen) camera.StartRecording(fileName);
            }
            else
            {
                saveDataToCsv();

                toolStripButton4.ForeColor = Color.Black;
                toolStripButton4.Text = "Start recording";
                toolStripButton4.Image = Image.FromFile("assets/play-circle-o.png");
                fileName = "";
            }
        }

        private void saveDataToCsv()
        {
            try
            {
                var firstElement = true;
                var scanStartedTime = 0;
                var stopRecrdTime = DateTime.Now;
                int portDataCaunt = Program.ComPort.SaverData.Count;

                var elapsedTime = stopRecrdTime - startRecrdTime;
                var elapsedTimeArr = new int[portDataCaunt];
                var step = (int)(elapsedTime.TotalMilliseconds / portDataCaunt);

                if (camera.IsOpen) camera.StopRecording(portDataCaunt != 0);

                if (portDataCaunt == 0)
                {
                    Program.Message("Error", "Data is empty");
                    return;
                }

                for (int i = 0, j = 0; i < portDataCaunt; i++, j += step)
                {
                    elapsedTimeArr[i] = j;
                }

                int timeCount = 0;
                foreach (var queue in Program.ComPort.SaverData)
                {
                    if (firstElement)
                    {
                        scanStartedTime = queue.CurrentTimeMC;
                        firstElement = false;
                    }

                    var plateData = new List<AxisItem>();

                    var time = queue.CurrentTimeMC;
                    for (int plate = 0; plate < 4; plate++)
                    {
                        var diffZ = (double)queue.DiffZ[plate] / config.CalibrateZ;
                        if (Unit == Constants.Units.N) diffZ = diffZ * config.FreeFallAcc;

                        var percX = queue.DiffZ[plate] != 0 ? ((double)queue.DiffX[plate] / queue.DiffZ[plate]) * 100 : 0;
                        var percY = queue.DiffZ[plate] != 0 ? ((double)queue.DiffY[plate] / queue.DiffZ[plate]) * 100 : 0;

                        percX = double.IsInfinity(percX) || double.IsNaN(percX) ? 0 : percX;
                        percY = double.IsInfinity(percY) || double.IsNaN(percY) ? 0 : percY;

                        plateData.Add(new AxisItem
                        {
                            Plate = plate,
                            DiffX = percX,
                            DiffY = percY,
                            DiffZ = diffZ,
                        });
                    }

                    csvData.CsvItems.Enqueue(new CsvItem
                    {
                        Time = elapsedTimeArr[timeCount++],
                        UcTime = queue.CurrentTimeMC - scanStartedTime,
                        AxisItems = plateData,
                    });
                }

                var path = CsvProcessor.Save(csvData, fileName, Unit);

                var dialog = new CommentDialogForm($"Data saved to: {path} file \r\nPlease leave a comment for this data");
                dialog.ShowDialog();
                reportService.AddReport(Program.User.Id, path, SharedStaticModel.FilterLength, SharedStaticModel.ExerciseTypeIndex + 1, Unit, dialog.Comment);

                csvData.CsvItems.Clear();
                Program.ComPort.SaverData.Clear();

                resetAll();
            }
            catch (Exception err)
            {
                Program.Message("Error", err.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (camera.IsOpen)
            {
                camera = new Camera();
                camera.MdiParent = this;
                camera.Show();
            }
            else
            {
                camera.Show();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingForm = new SettingsForm(this);
            settingForm.ShowDialog();
        }

        private void radarChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeAllChilds();
        }

        private void closeAllChilds()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}

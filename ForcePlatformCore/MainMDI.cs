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
        private int oldCurrentTimeMC = 0;

        private ReportService reportService = new ReportService();
        private Camera camera;
        private DataLoggerForm dataLogger;
        public Constants.Units Unit = Constants.Units.KgF;
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

            AdcData.Init(AppConfig.Config.FilterLength);

            ComPortBufferStore(null, EventArgs.Empty);
            resetAll();
        }

        public void ComPortBufferStore(object sender, EventArgs e)
        {
            if(startRecording) recordStartStop();

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

                foreach (var queue in Program.ComPort.SharedData)
                {
                    if (oldCurrentTimeMC != queue.CurrentTimeMC)
                    {
                        foreach (var plate in new int[] { 0, 1, 2, 3 })
                        {
                            var item = new AdcBufferItem();
                            item.Time = queue.CurrentTimeMC;
                            item.DiffX = queue.DiffX[plate];
                            item.DiffY = queue.DiffY[plate];
                            item.DiffZ = queue.DiffZ[plate];
                            item.CurrentTimeMC = queue.CurrentTimeMC;

                            SmallAdcBuffer.PushNew(plate, item);
                        }
                        
                        dataLogger.RefreshPlot(queue);
                        oldCurrentTimeMC = queue.CurrentTimeMC;
                    }
                }
                Program.ComPort.SharedData.Clear();
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

            csvData.FilterMode = SharedStaticModel.FilterType;
            csvData.FilterLength = SharedStaticModel.FilterLength;
            csvData.ExerciseType = SharedStaticModel.ExerciseType;

            if (csvData.FilterMode.Length == 0 || csvData.ExerciseType.Length == 0)
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
            }
            else
            {
                toolStripButton4.ForeColor = Color.Black;
                toolStripButton4.Text = "Start recording";
                toolStripButton4.Image = Image.FromFile("assets/play-circle-o.png");
            }

            if (!startRecording)
            {
                saveDataToCsv();
            }
        }

        private void saveDataToCsv()
        {
            try
            {
                var oldCurrTimeMC = 0;
                var scanStartedTime = Program.ComPort.SaverData[0].CurrentTimeMC;
                foreach (var queue in Program.ComPort.SaverData)
                {
                    var plateData = new List<AxisItem>();
                    if (oldCurrTimeMC != queue.CurrentTimeMC)
                    {
                        var time = queue.CurrentTimeMC;
                        for (int plate = 0; plate < 4; plate++)
                        {
                            var percX = ((double)queue.DiffX[plate] / queue.DiffZ[plate]) * 100;
                            var percY = ((double)queue.DiffY[plate] / queue.DiffZ[plate]) * 100;

                            plateData.Add(new AxisItem
                            {
                                Plate = plate,
                                DiffX = percX,
                                DiffY = percY,
                                DiffZ = Converter.ToUnit(queue.DiffZ[plate], Unit),
                            });
                        }

                        csvData.CsvItems.Enqueue(new CsvItem
                        {
                            Time = queue.CurrentTimeMC - scanStartedTime,
                            AxisItems = plateData,
                        });
                        oldCurrTimeMC = queue.CurrentTimeMC;
                    }
                }

                var path = CsvProcessor.Save(Program.User.Id, SharedStaticModel.ExerciseTypeIndex + 1, csvData, Unit);
                reportService.AddReport(Program.User.Id, path, SharedStaticModel.ExerciseTypeIndex + 1, Unit);

                csvData.CsvItems.Clear();                
                resetAll();

                Program.Message("Success", $"data saved to: \r\n{path} file");
            }
            catch (Exception err)
            {
                Program.Message("Error", err.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (camera.Text == "")
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

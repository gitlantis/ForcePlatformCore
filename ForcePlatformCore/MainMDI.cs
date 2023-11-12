﻿using ForcePlatformCore.Helpers.ComPort;
using ForcePlatformCore.Models;
using ForcePlatformData;
using ForcePlatformData.Helpers;
using ForcePlatformData.Models;
using ForcePlatformData.Service;
using Microsoft.EntityFrameworkCore;

namespace ForcePlatformCore
{
    public partial class MainMDI : Form
    {
        private int childFormNumber = 0;
        private bool pauseAll = false;
        private CsvModel csvData = new CsvModel();
        private bool startRecording = false;
        private int glCnt = 0;
        private int oldCurrentTimeMC = 0;
        private ComPort comPort;
        private Form[] childForms = new Form[4];
        private HashSet<int> openPlates = new HashSet<int>();
        private HashSet<int> allPlates = new HashSet<int> { 0, 1, 2, 3 };
        private DateTime scanStarted = DateTime.Now;
        private ReportService reportService = new ReportService();
        private Camera camera;
        int zeroTime;

        enum filterTypes
        {
            swingWindow,
            meanWindow,
            hemming,
            batterfort
        }
        int currentFilterType = (int)filterTypes.swingWindow; // :-)))


        private void loadSettingsFromfile()
        {
            // setting larni zagruzka kere
            // filtr i glubina

        }

        public MainMDI()
        {
            InitializeComponent();
            // loadSettingsFromfile(); ------------------------------------------------------------------------------------
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
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

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            //// loadSettingsFromfile();    --------------------------------------------------------------------------------------
            AdcData.DiffZ = new int[4];
            AdcData.CurrentTimeMC = 0;
            csvData.CsvItems = new Queue<CsvItem>();

            //comPort = new ComPort(AppConfig.Config.AutoSelectCom, AppConfig.Config.ComPort, AppConfig.Config.FilterLength);
            //if (!AppConfig.Config.AutoSelectCom)
            //{
            //    var conf = AppConfig.Config;
            //    conf.ComPort = comPort.PortName;
            //    AppConfig.UpdateConfig = conf;
            //}

            //timer1.Enabled = comPort.Connected;
            AdcData.Init(AppConfig.Config.FilterLength);

            AppConfig.DbContext.Database.EnsureCreated();
            AppConfig.DbContext.Users.Load();

            resetAll();

            camera = new Camera();
            camera.MdiParent = this;
            camera.Show();
        }
        
        private void plateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var i = -1;
            if (sender == plate1ToolStripMenuItem) i = 0;
            if (sender == plate2ToolStripMenuItem) i = 1;
            if (sender == plate3ToolStripMenuItem) i = 2;
            if (sender == plate4ToolStripMenuItem) i = 3;

            showForm(i);
        }

        private void openAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                showForm(i);
        }

        private void showForm(int i)
        {
            if (i >= 0)
            {
                childForms[i] = new DataLoggerForm(i);
                childForms[i].MdiParent = this;
                childForms[i].Show();
                openPlates.Add(i);
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
                    childForm.Location = new System.Drawing.Point(0, y);
                    childForm.Size = new System.Drawing.Size(ClientSize.Width, height);
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
                    childForm.Location = new System.Drawing.Point(x, 0);
                    childForm.Size = new System.Drawing.Size(width, ClientSize.Height);
                    x += width;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comPort.Connected)
            {
                var data = comPort.onReceive();
                AdcData.Set(data);
                var plateData = new List<AxisItem>();

                if (oldCurrentTimeMC != AdcData.CurrentTimeMC)
                {
                    foreach (var plate in openPlates)
                    {
                        var item = new AdcBufferItem();
                        item.Plate = plate;
                        item.Time = DateTime.Now.Subtract(scanStarted);
                        item.DiffX = AdcData.DiffX[plate];
                        item.DiffY = AdcData.DiffY[plate];
                        item.DiffZ = AdcData.DiffZ[plate];
                        item.CurrentTimeMC = AdcData.CurrentTimeMC;

                        plateData.Add(new AxisItem
                        {
                            Plate = plate,
                            DiffX = AdcData.DiffX[plate],
                            DiffY = AdcData.DiffY[plate],
                            DiffZ = AdcData.DiffZ[plate],

                        });
                        AdcBuffer.BufferItems.Add(item);
                    }
                }

                if (startRecording)
                {
                    csvData.CsvItems.Enqueue(new CsvItem
                    {
                        Time = DateTime.Now.Subtract(scanStarted),
                        AxisItems = plateData,
                    });
                    var item = new AdcBufferItem();
                }
                oldCurrentTimeMC = AdcData.CurrentTimeMC;
            }
        }

        private void Zero()
        {
            for (int i = 0; i < AdcData.CurrentAdc.Length; i++) { AdcData.ZeroAdc[i] = AdcData.MiddledAdc[i]; }

        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            comPort.Disconnect();

            AppConfig.DbContext?.Dispose();
            AppConfig.DbContext = null;
        }

        private void button1_Click(object sender, EventArgs e)
        { }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var activePlates = new HashSet<int>();
            foreach (Form childForm in MdiChildren)
            {
                if (childForm is DataLoggerForm)
                {
                    DataLoggerForm activeChild = (DataLoggerForm)childForm;
                    activePlates.Add(activeChild.PlateId);
                }
            }

            var missingPlates = new HashSet<int>(allPlates.Except(activePlates));

            foreach (var plate in missingPlates)
            {
                AdcBuffer.BufferItems.RemoveAll(item => item.Plate == plate);
            }
            openPlates.Clear();
            openPlates.UnionWith(activePlates);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void resetAll()
        {
            scanStarted = DateTime.Now;
            csvData.CsvItems.Clear();
            AdcBuffer.BufferItems.Clear();
            Zero();

            foreach (Form childForm in MdiChildren)
            {
                if (childForm is DataLoggerForm)
                {
                    DataLoggerForm activeChild = (DataLoggerForm)childForm;
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
            pauseAll = !pauseAll;
            //timer1.Enabled = !pauseAll;
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
                    DataLoggerForm activeChild = (DataLoggerForm)childForm;
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

            csvData.FilterMode = CsvStaticModel.FilterType;
            csvData.FilterLength = CsvStaticModel.FilterLength;
            csvData.ExerciseType = CsvStaticModel.ExerciseType;

            if (csvData.FilterMode.Length == 0 && csvData.ExerciseType.Length == 0)
            {
                Program.Message("Warning", "Plese choose exerceise type");
                return;
            }

            if (openPlates.Count < 1)
            {
                Program.Message("Warning", "No plates opened to scan");
                return;
            }
            zeroTime = AdcData.CurrentTimeMC;
            startRecording = !startRecording;
            if (startRecording)
            {
                toolStripButton4.Text = "Stop recording";
                toolStripButton4.Image = Image.FromFile("assets/stop-circle-o.png");
            }
            else
            {
                toolStripButton4.Text = "Start recording";
                toolStripButton4.Image = Image.FromFile("assets/play-circle-o.png");
            }

            if (!startRecording)
            {
                try
                {
                    var path = CsvProcessor.Save(Program.User.Id, csvData, "", openPlates.ToList());
                    reportService.AddReport(Program.User.Id, path);

                    resetAll();              
                    Program.Message("Success", $"data saved to: \r\n{path} file");
                }
                catch (Exception err)
                {
                    Program.Message("Error", err.Message);
                }
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

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingForm = new SettingsForm();
            settingForm.ShowDialog();
            // loadSettingsFromfile();

        }
    }
}

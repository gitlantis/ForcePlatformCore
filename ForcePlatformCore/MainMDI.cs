﻿using ForcePlatformCore.Helpers.ComPort;
using ForcePlatformCore.Models;
using ForcePlatformData;
using ForcePlatformData.Helpers;
using ForcePlatformData.Models;
using ForcePlatformData.Service;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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

        //private HashSet<int> openPlates = new HashSet<int>();
        private DateTime scanStarted = DateTime.Now;
        private ReportService reportService = new ReportService();
        private Camera camera;
        private DataLoggerForm dataLogger = new DataLoggerForm();

        //private RadarForm radar;

        //private int radarPlate = 0;
        //int zeroTime;

        //enum filterTypes
        //{
        //    swingWindow,
        //    meanWindow,
        //    hemming,
        //    batterfort
        //}
        //int currentFilterType = (int)filterTypes.swingWindow; // :-)))


        //private void loadSettingsFromfile()
        //{
        //    // setting larni zagruzka kere
        //    // filtr i glubina

        //}

        private void MDIParent1_Shown(object sender, EventArgs e)
        {
            var userSelectForm = new UserSelect();
            userSelectForm.ShowDialog();

            var settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog();

            //// loadSettingsFromfile();    --------------------------------------------------------------------------------------
            AdcData.DiffZ = new int[4];
            AdcData.CurrentTimeMC = 0;
            csvData.CsvItems = new Queue<CsvItem>();

            timer1.Enabled = Program.ComPort.Connected;
            AdcData.Init(AppConfig.Config.FilterLength);

            resetAll();

            //this.OpenWithMode();
        }

        public MainMDI()
        {
            InitializeComponent();
            // loadSettingsFromfile(); ------------------------------------------------------------------------------------
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
            closeAllChilds();
        }

        private void plateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var i = -1;
            //if (sender == plate1ToolStripMenuItem) i = 0;
            //if (sender == plate2ToolStripMenuItem) i = 1;
            //if (sender == plate3ToolStripMenuItem) i = 2;
            //if (sender == plate4ToolStripMenuItem) i = 3;

            showDataLogger();
        }

        private void openAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDataLogger();
        }

        public void ShowAllForms()
        {
            //for (int i = 0; i < 4; i++)
            //    showForm(i);
            showDataLogger();
        }

        private void showDataLogger()
        {
            //var child = -1;

            //foreach (Form fm in this.MdiChildren)
            //{
            //    if (fm is DataLoggerForm childForm)
            //    {
            //        var form = (DataLoggerForm)childForm;
            //        if (form.PlateId == i)
            //        {
            //            child = i;
            //            break;
            //        }
            //    }
            //}
            //if (child != i)
            //{
            //    childForm = new DataLoggerForm();
            //    childForm.MdiParent = this;
            //    childForm.Show();
            //}
            dataLogger = new DataLoggerForm();
            dataLogger.MdiParent = this;
            dataLogger.Show();
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
            if (Program.ComPort.Connected)
            {
                Program.ComPort.OnReceive();

                foreach (var queue in Program.ComPort.SharedData)
                {
                    if (oldCurrentTimeMC != queue.CurrentTimeMC)
                    {
                        foreach (var plate in new int[] { 0, 1, 2, 3 })
                        {
                            //var plate = 0;//shuni kuraylik bitta
                            var item = new AdcBufferItem();
                            item.Time = DateTime.Now.Subtract(scanStarted);
                            item.DiffX = queue.DiffX[plate];
                            item.DiffY = queue.DiffY[plate];
                            item.DiffZ = queue.DiffZ[plate];
                            item.CurrentTimeMC = queue.CurrentTimeMC;

                            SmallAdcBuffer.PushNew(plate, item, startRecording);
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

        //private void button1_Click(object sender, EventArgs e)
        //{ }

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    var activePlates = new HashSet<int>();
        //    foreach (Form childForm in MdiChildren)
        //    {
        //        if (childForm is DataLoggerForm)
        //        {
        //            var activeChild = (DataLoggerForm)childForm;
        //            activePlates.Add(activeChild.PlateId);
        //        }

        //        if (childForm is RadarForm)
        //        {
        //            var activeChild = (RadarForm)childForm;
        //            activePlates.Add(radarPlate);
        //        }
        //    }

        //    var missingPlates = new HashSet<int>(allPlates.Except(activePlates));

        //    foreach (var plate in missingPlates)
        //    {
        //        AdcBuffer.BufferItems[plate].Clear();
        //    }
        //    openPlates.Clear();
        //    openPlates.UnionWith(activePlates);
        //}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void resetAll()
        {
            Program.ComPort.Zero();
            scanStarted = DateTime.Now;
            csvData.CsvItems.Clear();
            
            Program.ComPort.recordIncer = 0;

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
            pauseIncome();
        }

        private void pauseIncome()
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

            //if (openPlates.Count < 1)
            //{
            //    Program.Message("Warning", "No plates opened to scan");
            //    return;
            //}
            //zeroTime = AdcData.CurrentTimeMC;
            if (Program.User.Id < 1)
            {
                Program.Message("Warning", "Please select a user");
                return;
            }

            startRecording = !startRecording;

            if (startRecording)
            {
                Program.ComPort.StartRecording = startRecording;
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
                try
                {
                    var _oldCurrentTimeMC = 0;
                    foreach (var queue in Program.ComPort.SaverData)
                    {
                        var plateData = new List<AxisItem>();
                        if (_oldCurrentTimeMC != queue.CurrentTimeMC)
                        {
                            var time = queue.CurrentTimeMC;
                            for (int plate = 0; plate < 4; plate++)
                            {
                                plateData.Add(new AxisItem
                                {
                                    Plate = plate,
                                    DiffX = queue.DiffX[plate],
                                    DiffY = queue.DiffY[plate],
                                    DiffZ = queue.DiffZ[plate],
                                });
                            }
                            
                            csvData.CsvItems.Enqueue(new CsvItem
                            {
                                Time = time,
                                AxisItems = plateData,
                            });
                            _oldCurrentTimeMC = queue.CurrentTimeMC;
                        }

                    }//sababi listda faqat bir xil danny // list ishlatmang? massiv oling 1 minutga etadigan? dinamic memory? nuevogo

                    var path = CsvProcessor.Save(Program.User.Id, SharedStaticModel.ExerciseTypeIndex + 1, "", csvData);
                    reportService.AddReport(Program.User.Id, path, SharedStaticModel.ExerciseTypeIndex + 1);

                    resetAll();
                    Program.Message("Success", $"data saved to: \r\n{path} file");
                    Program.ComPort.recordIncer =0;
                    if (!startRecording) Program.ComPort.ResetSaverData();


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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingForm = new SettingsForm(this);
            settingForm.ShowDialog();
            // loadSettingsFromfile();
        }

        private void radarChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeAllChilds();
            //radar = new RadarForm(radarPlate);
            //radar.MdiParent = this;
            //radar.Show();
            //openPlates.Add(radarPlate);
        }

        //public void OpenWithMode()
        //{
        //    //closeAllChilds();
        //    //if (SharedStaticModel.ExerciseTypeIndex == 0)
        //    //{
        //    //    //radar = new RadarForm(radarPlate);
        //    //    //radar.MdiParent = this;
        //    //    //radar.Show();
        //    //    //openPlates.Add(radarPlate);
        //    //}

        //    //if (SharedStaticModel.ExerciseTypeIndex == 1)
        //    //{
        //    //    showForm(0);
        //    //    showForm(1);
        //    //}

        //    //if (SharedStaticModel.ExerciseTypeIndex == 2)
        //    //{
        //    showForm(0);
        //    showForm(1);
        //    showForm(2);
        //    showForm(3);
        //    //}
        //}

        private void closeAllChilds()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}

using ForcePlatformCore.Helpers;
using ForcePlatformCore.Helpers.ComPort;
using ForcePlatformCore.Models;
using Microsoft.Extensions.Configuration;
using ScottPlot.Drawing.Colormaps;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using WindowsFormsApp1.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ForcePlatformCore
{
    public partial class MDIParent1 : Form
    {
        private AppsettingsModel? config = new AppsettingsModel();
        private int childFormNumber = 0;
        private bool pauseAll = false;
        private Queue<CSVModel> csvData = new Queue<CSVModel>();
        public IConfiguration Configuration { get; set; }

        private bool startRecording = false;
        int glCnt = 0;
        int oldCurrentTimeMC = 0;
        ComPort comPort;
        Form[] childForms = new Form[4];

        HashSet<int> openPlates = new HashSet<int>();
        HashSet<int> allPlates = new HashSet<int> { 0, 1, 2, 3 };

        DateTime scanStarted = DateTime.Now;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
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
            AdcData.DiffZ = new int[4];
            AdcData.CurrentTimeMC = 0;

            config = Configuration.Get<AppsettingsModel>();
            comPort = new ComPort(config.AutoSelectCom, config.ComPort, config.FilterLength);
            timer1.Enabled = comPort.connected;
            AdcData.Init(config.FilterLength);
            resetAll();
        }
        private void plate1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(0);
        }

        private void plate2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(1);
        }

        private void plate3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(2);
        }

        private void plate4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(3);
        }

        private void openAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                showForm(i);
        }
        private void showForm(int i)
        {
            childForms[i] = new Form1(i, config);
            childForms[i].MdiParent = this;
            childForms[i].Show();
            openPlates.Add(i);
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
            if (comPort.connected)
            {
                var data = comPort.onReceive();
                AdcData.Set(data);

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

                        AdcBuffer.BufferItems.Add(item);
                    }
                }

                var plateData = new List<CSVItem>();
                int i = 0;
                foreach (var item in AdcData.DiffX)
                {
                    plateData.Add(new CSVItem
                    {
                        Plate = i,
                        DiffX = AdcData.DiffX[i],
                        DiffY = AdcData.DiffY[i],
                        DiffZ = AdcData.DiffZ[i],
                    });
                    i++;
                }

                var currentAdcHex = "";
                foreach (var ch in AdcData.CurrentAdc)
                {
                    currentAdcHex += ch.ToString("X");
                }

                currentAdcHex += AdcData.CurrentTimeMC.ToString("X");
                if (startRecording)
                {
                    csvData.Enqueue(new CSVModel
                    {
                        //Time = DateTime.Now.Subtract(scanStarted),
                        Time = AdcData.CurrentTimeMC.ToString(),
                        PlateData = plateData,
                        CurrentADC = currentAdcHex
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
        }

        private void button1_Click(object sender, EventArgs e)
        { }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var activePlates = new HashSet<int>();
            foreach (Form childForm in MdiChildren)
            {
                if (childForm is Form1)
                {
                    Form1 activeChild = (Form1)childForm;
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
            csvData.Clear();
            AdcBuffer.BufferItems.Clear();
            Zero();
            foreach (Form childForm in MdiChildren)
            {
                if (childForm is Form1)
                {
                    Form1 activeChild = (Form1)childForm;
                    activeChild.ClearLoggers();
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            pauseAll = !pauseAll;
            //timer1.Enabled = !pauseAll;
            toolStripButton3.Text = pauseAll ? "Continue" : "Pause";
            foreach (Form childForm in MdiChildren)
            {
                if (childForm is Form1)
                {
                    Form1 activeChild = (Form1)childForm;
                    activeChild.Pause(pauseAll);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            startRecording = !startRecording;
            toolStripButton4.Text = startRecording ? "Stop recording" : "Start recording";
            if (!startRecording)
            {
                try
                {
                    var path = CsvProcessor.Save(0, csvData, "", openPlates.ToList());
                    csvData.Clear();

                    string message = $"all data saved in: \r\n{path}file";
                    string caption = "Message";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons);
                }
                catch (Exception err)
                {
                    string message = err.Message;
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons);
                }

            }
        }
    }
}

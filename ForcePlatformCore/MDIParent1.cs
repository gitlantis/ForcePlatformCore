using ForcePlatformCore.Helpers.ComPort;
using ForcePlatformCore.Models;
using Microsoft.Extensions.Configuration;
using ScottPlot.Drawing.Colormaps;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using WindowsFormsApp1.Models;

namespace ForcePlatformCore
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        public IConfiguration Configuration { get; set; }

        int glCnt = 0;
        int oldCurrentTimeMC = 0;
        ComPort comPort;
        Form[] childForms = new Form[4];

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

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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

            var config = Configuration.Get<AppsettingsModel>();
            comPort = new ComPort(true, "COM9", 30);
            timer1.Enabled = comPort.connected;
            AdcData.Init(30);
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
            showForm(3);
        }

        private void plate4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(4);
        }

        private void openAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                showForm(i);
        }
        private void showForm(int i)
        {
            childForms[i] = new Form1(i);
            childForms[i].MdiParent = this;
            childForms[i].Show();
        }

        private void closeAllToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Form fm in this.MdiChildren)
                fm.Close();
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
                    for (int i = 0; i < 4; i++)
                    {
                        var item = new AdcBufferItem();
                        item.Plate = i;
                        item.DiffX = AdcData.DiffX[i];
                        item.DiffY = AdcData.DiffY[i];
                        item.DiffZ = AdcData.DiffZ[i];
                        item.CurrentTimeMC = AdcData.CurrentTimeMC;

                        AdcBuffer.BufferItems.Add(item);
                    }

                    richTextBox1.AppendText(AdcData.CurrentTimeMC + " " + AdcData.DiffZ[0] + "\r\n");
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
            richTextBox1.Clear();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AdcBuffer.BufferItems.Clear();
            Zero();
            foreach (Form childForm in MdiChildren)
            {
                if (childForm is Form1)
                {
                    Form1 activeChild = (Form1)childForm;
                    activeChild.Clear();
                }
            }

        }
    }
}

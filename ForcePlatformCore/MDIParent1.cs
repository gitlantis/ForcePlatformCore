using Microsoft.Extensions.Configuration;
using WindowsFormsApp1.Models;

namespace ForcePlatformCore
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        public IConfiguration Configuration { get; set; }
        ForcePlatformComPort.ComPort comPort;

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
            comPort = new ForcePlatformComPort.ComPort(autoDetect: true, port: "COM1", 30);
            comPort.DataReceived += (data) =>
            {
                AdcData.DiffY = data.DiffX;
                AdcData.DiffX = data.DiffY;
                AdcData.DiffZ = data.DiffZ;
                AdcData.CurrentTimeMC = data.CurrentTimeMC;
            };
            comPort.Zero();
            //var comPort = new ComPort(config.AutoSelectCom, config.ComPort);
        }
        private void plate1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form1 = new Form1(1);
            form1.MdiParent = this;
            form1.Show();
        }

        private void plate2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Form1(2);
            form2.MdiParent = this;
            form2.Show();
        }

        private void plate3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form3 = new Form1(3);
            form3.MdiParent = this;
            form3.Show();
        }

        private void plate4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form4 = new Form1(4);
            form4.MdiParent = this;
            form4.Show();
        }

        private void openAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form1 = new Form1(1);
            form1.MdiParent = this;
            form1.Show();
            var form2 = new Form1(2);
            form2.MdiParent = this;
            form2.Show();
            var form3 = new Form1(3);
            form3.MdiParent = this;
            form3.Show();
            var form4 = new Form1(4);
            form4.MdiParent = this;
            form4.Show();
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
            richTextBox1.AppendText("\r\n" + AdcData.CurrentTimeMC + " " + AdcData.DiffZ[0]);
            richTextBox1.ScrollToCaret();
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            comPort.Disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}

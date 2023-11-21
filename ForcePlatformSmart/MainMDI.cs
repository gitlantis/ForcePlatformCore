using ForcePlatformData.DbModels;
using ForcePlatformData.Service;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace ForcePlatformSmart
{
    public partial class MainMDI : Form
    {
        private int childFormNumber = 0;
        UserService userService = new UserService();

        public MainMDI()
        {
            InitializeComponent();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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

        private void MainMDI_Load(object sender, EventArgs e)
        {
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.DataSource = userService.GetAll();
            redrawDataGrid();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    var selectedRow = dataGridView1.Rows[e.RowIndex];

            //    var user = (User)selectedRow.DataBoundItem;

            //    var radarChart = new RadarForm(user);
            //    radarChart.Show();
            //}
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var actionColumn = dataGridView1.Columns.Cast<DataGridViewColumn>().FirstOrDefault(col => col.HeaderText == "Action");

                if (e.RowIndex >= 0 && actionColumn != null && e.ColumnIndex == actionColumn.Index)
                {
                    var selectedRow = dataGridView1.Rows[e.RowIndex];

                    var user = (User)selectedRow.DataBoundItem;

                    var userInfo = new UserInfo(user);
                    userInfo.Show();
                }
            }catch{ }
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            UpdateUsers(toolStripTextBox1.Text);
        }
        public void UpdateUsers(string keyword)
        {
            var users = new List<User>();
            try
            {
                if (keyword.Length < 1) users = userService.TakeSome(30);
                else users = userService.FindUser(keyword);
            }
            catch { }
            dataGridView1.DataSource = users;
        }
        private void redrawDataGrid()
        {
            var buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Action";
            buttonColumn.Text = "Info";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
        }
    }
}

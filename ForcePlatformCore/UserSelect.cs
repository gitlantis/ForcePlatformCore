using ForcePlatformCore;
using ForcePlatformCore.DbModels;
using ForcePlatformCore.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace ForcePlatformData
{
    public partial class UserSelect : Form
    {
        private List<User> users = new List<User>();
        private UserService userService = new UserService();
        private string comboboxText = "";
        public UserSelect()
        {
            InitializeComponent();
        }

        private void UserSelect_Load(object sender, EventArgs e)
        {
            try
            {
                users = userService.TakeSome(30);
                listBox1.DataSource = users;
                listBox1.DisplayMember = "FullName";
                listBox1.ValueMember = "Id";
            }
            catch { }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            var addUserForm = new UserAddUpdate("Add");
            addUserForm.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (selectUser())
            {
                var addUserForm = new UserAddUpdate("Edit");
                addUserForm.ShowDialog();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (selectUser()) this.Close();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (selectUser())
            {
                var userInfo = new UserInfo();
                userInfo.ShowDialog();
            }
        }

        private bool selectUser()
        {
            try
            {
                var selectedValue = listBox1.SelectedValue;
                int selectedId = (int)selectedValue;

                Program.User = users.Where(item => item.Id == selectedId).FirstOrDefault();
                Program.mdiParent.Text = $"Force Platform ({Program.User.FullName})";
                return true;
            }
            catch (Exception)
            {
                Program.Message("Error", "User not selected");
            }
            return false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                listBox1.BeginUpdate();
                users = userService.FindUser(textBox1.Text);
                listBox1.DataSource = users;
                listBox1.DisplayMember = "FullName";
                listBox1.ValueMember = "Id";
                listBox1.EndUpdate();
            }
            catch { }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (selectUser())
            {
                var userInfo = new UserInfo();
                userInfo.ShowDialog();
            }
        }
    }
}

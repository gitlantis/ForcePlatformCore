﻿using ForcePlatformData.DbModels;
using ForcePlatformData.Helpers;
using ForcePlatformData.Service;

namespace ForcePlatformCore
{
    public partial class UserSelect : Form
    {
        private List<User> users = new List<User>();
        private UserService userService = new UserService();
        private ReportService reportService = new ReportService();

        public UserSelect()
        {
            InitializeComponent();
        }

        private void UserSelect_Load(object sender, EventArgs e)
        {
            UpdateUsers("");
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            var addUserForm = new UserAddUpdate(this, "Add");
            addUserForm.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (selectUser())
            {
                var addUserForm = new UserAddUpdate(this, "Edit");
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
            UpdateUsers(textBox1.Text);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (selectUser()) this.Close();
        }

        public void UpdateUsers(string keyword)
        {
            try
            {
                listBox1.BeginUpdate();

                if (keyword.Length < 1) users = userService.TakeSome(30);
                else users = userService.FindUser(keyword);

                listBox1.DataSource = users;
                listBox1.DisplayMember = "FullName";
                listBox1.ValueMember = "Id";
                listBox1.EndUpdate();
            }
            catch { }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = listBox1.SelectedValue;
                int selectedId = (int)selectedValue;

                var selectedUser = users.Where(item => item.Id == selectedId).FirstOrDefault();

                if (selectedUser != null)
                {
                    DialogResult result = MessageBox.Show($"Do you want remove {selectedUser.FullName}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        result = MessageBox.Show($"All files also will be removed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            var reports = reportService.GetReportsByUserId(selectedUser.Id);
                            foreach (var report in reports)
                            {
                                CsvProcessor.Delete(report.Path);
                                PdfProcessor.Delete(report.Path);
                                VideoProcessor.Delete(report.Path);
                            }
                            userService.DeleteUser(selectedUser);
                            UpdateUsers(textBox1.Text);
                        }
                    }
                }
            }
            catch { }
        }
    }
}

﻿using ForcePlatformData;
using ForcePlatformData.DbModels;
using ForcePlatformData.Service;
using System.Diagnostics;

namespace ForcePlatformSmart
{
    public partial class UserInfo : Form
    {
        private string stdDetails = "{0, -150}{1, -20}";
        private UserService userService = new UserService();
        private ReportService reportService = new ReportService();
        private List<Report> reports = new List<Report>();
        private User user = new User();
        
        public UserInfo()
        {
            InitializeComponent();
        }
        public UserInfo(User selectedUser)
        {
            user = selectedUser;
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            textBox1.Text = user.Name;
            textBox2.Text = user.Surname;
            textBox3.Text = user.MiddleName;

            var param = userService.TakeUserParams(user.Id);
            textBox4.Text = param.BodyHeight.ToString();
            textBox5.Text = param.BodyWeight.ToString();

            textBox6.Text = param.LeftTigh.ToString() + " " + param.LengthUnit;
            textBox7.Text = param.LeftShin.ToString() + " " + param.LengthUnit;
            textBox8.Text = param.LeftSole.ToString() + " " + param.LengthUnit;

            textBox9.Text = param.RightTigh.ToString() + " " + param.LengthUnit;
            textBox10.Text = param.RightShin.ToString() + " " + param.LengthUnit;
            textBox11.Text = param.RightSole.ToString() + " " + param.LengthUnit;
            textBox12.Text = user.BirthDate.ToString("MM/dd/yyyy");
            textBox12.Text = param.Gender;

            reports = reportService.GetReports(user.Id);

            listBox1.Items.Clear();

            listBox1.BeginUpdate();
            listBox1.DataSource = reports;
            listBox1.DisplayMember = "FullDetail";
            listBox1.ValueMember = "Id";
            listBox1.EndUpdate();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = listBox1.SelectedValue;
                int selectedId = (int)selectedValue;
                var filePath = reports.Where(c => c.Id == selectedId).FirstOrDefault().Path;
                var fullPath = Path.Join(Environment.CurrentDirectory, AppConfig.Config.ReportsPath, filePath);

                if (File.Exists(fullPath))
                {
                    Process.Start("notepad.exe", fullPath);
                }
                else
                {
                    Program.Message("Error", "The file does not exist: " + fullPath);
                }
            }
            catch (Exception ex)
            {
                Program.Message("Error", ex.Message);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

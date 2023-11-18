﻿using ForcePlatformCore.Helpers;
using ForcePlatformData;
using ForcePlatformData.Models;

namespace ForcePlatformCore
{
    public partial class SettingsForm : Form
    {
        public int FilterLength = AppConfig.Config.FilterLength;
        private MainMDI mdi;
        private bool error = false;

        public SettingsForm(MainMDI mdi)
        {
            InitializeComponent();
            this.mdi = mdi;
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iconPictureBox1.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");
            iconPictureBox2.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");
            iconPictureBox3.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");
            iconPictureBox4.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");
            iconPictureBox5.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");
            iconPictureBox6.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");

            comboBox1.Items.AddRange(Constants.FilterTypes);
            comboBox1.Text = SharedStaticModel.FilterType;
            comboBox1.SelectedIndex = 0;

            textBox1.Text = AppConfig.Config.FilterLength.ToString();

            comboBox2.DataSource = AppConfig.DbContext.ExerciseType.ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox2.SelectedIndex = SharedStaticModel.ExerciseTypeIndex;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var conf = AppConfig.Config;
            conf.FilterLength = Convert.ToInt32(textBox1.Text);
            AppConfig.UpdateConfig = conf;

            SharedStaticModel.FilterLength = conf.FilterLength;

            SharedStaticModel.FilterType = comboBox1.Text;
            SharedStaticModel.FilterTypeIndex = comboBox1.SelectedIndex;

            SharedStaticModel.ExerciseType = comboBox2.Text;
            SharedStaticModel.ExerciseTypeIndex = comboBox2.SelectedIndex;

            //if (mdi != null) mdi.OpenWithMode();
            mdi.ShowAllForms();

            var sharedData = Program.ComPort.SharedData.LastOrDefault();

            //for (int i = 0; i < 4; i++)
            //{
            //    if (sharedData.DiffX[i] > 520000 || sharedData.DiffY[i] > 520000 || sharedData.DiffZ[i] > 520000)
            //    {
            //        Program.Message("Warning", "Don't stand on the platform");
            //        error = true;
            //        break;
            //    }
            //}

            if (comboBox2.SelectedIndex == 0 && !error)
                Program.Message("Attantion", "Experimenter should not move on this mode");

            Program.ComPort.Zero();

            if (!error) this.Close();
        }

        private void validateInt(object sender, KeyPressEventArgs e)
        {
            Validator.Int(sender, e);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidePictureBoxes();
            if (comboBox2.SelectedIndex == 0)
            {
                iconPictureBox1.Visible = true;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                iconPictureBox1.Visible = true;
                iconPictureBox2.Visible = true;

            }
            if (comboBox2.SelectedIndex == 2)
            {
                iconPictureBox3.Visible = true;
                iconPictureBox4.Visible = true;
                iconPictureBox5.Visible = true;
                iconPictureBox6.Visible = true;
            }
        }

        private void hidePictureBoxes()
        {
            iconPictureBox1.Visible = false;
            iconPictureBox2.Visible = false;
            iconPictureBox3.Visible = false;
            iconPictureBox4.Visible = false;
            iconPictureBox5.Visible = false;
            iconPictureBox6.Visible = false;
        }
    }
}

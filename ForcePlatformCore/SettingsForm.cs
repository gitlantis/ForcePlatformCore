﻿using ForcePlatformCore.Helpers;
using ForcePlatformData;
using ForcePlatformData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForcePlatformCore
{
    public partial class SettingsForm : Form
    {
        public int FilterLength = AppConfig.Config.FilterLength;
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

            comboBox1.Text = CsvStaticModel.FilterType;
            textBox1.Text = AppConfig.Config.FilterLength.ToString();
            comboBox2.Text = CsvStaticModel.ExerciseType;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var conf = AppConfig.Config;
            conf.FilterLength = Convert.ToInt32(textBox1.Text);
            AppConfig.UpdateConfig = conf;

            CsvStaticModel.FilterLength = conf.FilterLength;
            CsvStaticModel.FilterType = comboBox1.Text;
            CsvStaticModel.ExerciseType = comboBox2.Text;

            this.Close();
        }

        private void validateInt(object sender, KeyPressEventArgs e)
        {
            Validator.Int(sender, e);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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

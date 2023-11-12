using ForcePlatformCore.Helpers;
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

            //comboBox4.SelectedItem = 0;
            //comboBox1.SelectedItem = 0;

            //FilterType = comboBox1.Text;
            //ExcerciseType = comboBox2.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
    }
}

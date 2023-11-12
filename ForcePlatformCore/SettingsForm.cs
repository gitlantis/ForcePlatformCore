using ForcePlatformCore.Helpers;
using ForcePlatformData;
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
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var conf = AppConfig.Config;
            conf.FilterLength = Convert.ToInt32(textBox1.Text);
            AppConfig.UpdateConfig = conf;
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

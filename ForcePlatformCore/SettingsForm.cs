using FontAwesome.Sharp;
using ForcePlatformCore.Helpers;
using ForcePlatformData;
using ForcePlatformData.Models;

namespace ForcePlatformCore
{
    public partial class SettingsForm : Form
    {
        private AppsettingsModel appConfig = new AppsettingsModel();
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
            try
            {
                iconPictureBox1.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");
                iconPictureBox2.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");
                iconPictureBox3.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");
                iconPictureBox4.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");
                iconPictureBox5.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");
                iconPictureBox6.ImageLocation = Path.Join(Environment.CurrentDirectory, "assets", "plate_icon.png");

                appConfig = AppConfig.Config;
                textBox1.Text = appConfig.FilterLength.ToString();
                textBox3.Text = appConfig.CalibrateZ.ToString();

                comboBox2.DataSource = AppConfig.DbContext.ExerciseType.ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                comboBox2.SelectedIndex = SharedStaticModel.ExerciseTypeIndex;
            }
            catch (Exception ex)
            {
                Program.Message("Message", ex.Message);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveSettings()
        {
            try
            {
                var conf = appConfig;
                conf.FilterLength = Convert.ToInt32(textBox1.Text);
                conf.CalibrateZ = Convert.ToInt32(textBox3.Text);
                AppConfig.UpdateConfig = conf;

                SharedStaticModel.FilterLength = conf.FilterLength;

                SharedStaticModel.ExerciseType = comboBox2.Text;
                SharedStaticModel.ExerciseTypeIndex = comboBox2.SelectedIndex;

                mdi.ShowPlateLogger();

                if (comboBox2.SelectedIndex == 0 && !error)
                    Program.Message("Attantion", "Experimenter should not move on this mode");
            }
            catch (Exception ex)
            {
                Program.Message("Error", ex.Message);
            }
        }

        private void validateInt(object sender, KeyPressEventArgs e)
        {
            Validator.Int(sender, e);
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

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            SharedStaticModel.ExerciseTypeIndex = comboBox2.SelectedIndex;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }
    }
}

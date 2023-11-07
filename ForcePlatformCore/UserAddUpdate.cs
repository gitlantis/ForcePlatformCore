using ForcePlatformCore.DbModels;
using ForcePlatformCore.Service;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace ForcePlatformData
{
    public partial class UserAddUpdate : Form
    {
        private UserService userService = new UserService();
        private User user = new User();
        public UserAddUpdate(string text)
        {
            InitializeComponent();
            this.Text = text;
        }

        private void UserAddUpdate_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            if (this.Text.Equals("Edit"))
            {
                textBox1.Text = Program.User.Name;
                textBox2.Text = Program.User.Surname;
                textBox3.Text = Program.User.MiddleName;

                user.UserParams = userService.TakeUserParams(Program.User.Id);
                textBox4.Text = user.UserParams.BodyHeight.ToString();
                textBox5.Text = user.UserParams.BodyWeight.ToString();

                comboBox1.Text = user.UserParams.LengthUnit;

                textBox6.Text = user.UserParams.LeftTigh.ToString();
                textBox7.Text = user.UserParams.LeftShin.ToString();
                textBox8.Text = user.UserParams.LeftSole.ToString();

                textBox9.Text = user.UserParams.RightTigh.ToString();
                textBox10.Text = user.UserParams.RightShin.ToString();
                textBox11.Text = user.UserParams.RightSole.ToString();
            }
        }

        private void doubleValidation(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                user.Name = textBox1.Text;
                user.Surname = textBox2.Text;
                user.MiddleName = textBox3.Text;
                user.BirthDate = dateTimePicker1.Value;

                user.UserParams.BodyHeight = string.IsNullOrEmpty(textBox4.Text) ? null : Convert.ToDouble(textBox4.Text);
                user.UserParams.BodyWeight = string.IsNullOrEmpty(textBox5.Text) ? null : Convert.ToDouble(textBox5.Text);

                user.UserParams.LengthUnit = comboBox1.Text;

                user.UserParams.LeftTigh = string.IsNullOrEmpty(textBox6.Text) ? null : Convert.ToDouble(textBox6.Text);
                user.UserParams.LeftShin = string.IsNullOrEmpty(textBox7.Text) ? null : Convert.ToDouble(textBox7.Text);
                user.UserParams.LeftSole = string.IsNullOrEmpty(textBox8.Text) ? null : Convert.ToDouble(textBox8.Text);

                user.UserParams.RightTigh = string.IsNullOrEmpty(textBox9.Text) ? null : Convert.ToDouble(textBox9.Text);
                user.UserParams.RightShin = string.IsNullOrEmpty(textBox10.Text) ? null : Convert.ToDouble(textBox10.Text);
                user.UserParams.RightSole = string.IsNullOrEmpty(textBox11.Text) ? null : Convert.ToDouble(textBox11.Text);

                if (this.Text.Equals("Add"))
                {
                    var id = userService.AddUser(user);
                    Program.Message("Success", $"{user.FullName} added successfully");
                }
                else
                {
                    user.Id = Program.User.Id;
                    userService.EditUser(user);
                    Program.Message("Success", $"{user.FullName} updated successfully");
                }

            }
            catch (Exception ex)
            {
                Program.Message("Error", ex.Message);

            }
        }
    }
}

using ForcePlatformCore.DbModels;
using ForcePlatformCore.Service;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace ForcePlatformData
{
    public partial class UserAddUpdate : Form
    {
        private UserService userService = new UserService();
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

                var param = userService.TakeUserParams(Program.User.Id);
                textBox4.Text = param.BodyHeight.ToString();
                textBox5.Text = param.BodyWeight.ToString();

                comboBox1.Text = param.LengthUnit;

                textBox6.Text = param.LeftTigh.ToString();
                textBox7.Text = param.LeftShin.ToString();
                textBox8.Text = param.LeftSole.ToString();

                textBox9.Text = param.RightTigh.ToString();
                textBox10.Text = param.RightShin.ToString();
                textBox11.Text = param.RightSole.ToString();
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
                var user = new User();
                user.Name = textBox1.Text;
                user.Surname = textBox2.Text;
                user.MiddleName = textBox3.Text;
                user.BirthDate = dateTimePicker1.Value;

                var userParams = new UserParams();
                userParams.BodyHeight = Convert.ToDouble(textBox4.Text.DefaultIfEmpty());
                userParams.BodyWeight = Convert.ToDouble(textBox5.Text.DefaultIfEmpty());

                userParams.LengthUnit = comboBox1.Text;

                userParams.LeftTigh = Convert.ToDouble(textBox6.Text.DefaultIfEmpty());
                userParams.LeftShin = Convert.ToDouble(textBox7.Text.DefaultIfEmpty());
                userParams.LeftSole = Convert.ToDouble(textBox8.Text.DefaultIfEmpty());

                userParams.RightTigh = Convert.ToDouble(textBox9.Text.DefaultIfEmpty());
                userParams.RightShin = Convert.ToDouble(textBox10.Text.DefaultIfEmpty());
                userParams.RightSole = Convert.ToDouble(textBox11.Text.DefaultIfEmpty());

                user.UserParams = userParams;

                if (this.Text.Equals("Add"))
                {
                    var id = userService.AddUser(user);
                    Program.Message("Success", $"{user.FullName} added successfully");
                }
                else
                {
                    user.Id = Program.User.Id;
                    userService.EditUser(user);

                    var id = userService.AddUser(user);
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

using ForcePlatformData.DbModels;
using ForcePlatformData.Service;

namespace ForcePlatformCore
{
    public partial class UserAddUpdate : Form
    {
        private UserService userService = new UserService();
        private User user = new User();
        private UserSelect userSelectReference;

        public UserAddUpdate(UserSelect userSelect, string text)
        {
            InitializeComponent();
            this.Text = text;
            userSelectReference = userSelect;
            user.UserParams = new UserParams();
        }

        private void UserAddUpdate_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            if (this.Text.Equals("Edit"))
            {
                textBox1.Text = Program.User.Name;
                textBox2.Text = Program.User.Surname;
                textBox3.Text = Program.User.MiddleName;
                dateTimePicker1.Value = Program.User.BirthDate;

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
                textBox11.Text = user.UserParams.RightSole.ToString();
                comboBox2.Text = user.UserParams.Gender;
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
                double val = 0;
                Double.TryParse(textBox4.Text, out val);
                user.UserParams.BodyHeight = val;
                Double.TryParse(textBox4.Text, out val);
                user.UserParams.BodyWeight = val;

                user.UserParams.LengthUnit = comboBox1.Text;

                Double.TryParse(textBox4.Text, out val);
                user.UserParams.LeftTigh = val;
                Double.TryParse(textBox4.Text, out val);
                user.UserParams.LeftShin = val;
                Double.TryParse(textBox4.Text, out val);
                user.UserParams.LeftSole = val;

                Double.TryParse(textBox4.Text, out val);
                user.UserParams.RightTigh = val;
                Double.TryParse(textBox4.Text, out val);
                user.UserParams.RightShin = val;
                Double.TryParse(textBox4.Text, out val);
                user.UserParams.RightSole = val;
                user.UserParams.Gender = comboBox2.Text;
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
                userSelectReference.UpdateUsers("");
            }
            catch (Exception ex)
            {
                Program.Message("Error", ex.Message);

            }
        }
    }
}

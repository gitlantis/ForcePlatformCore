﻿using ForcePlatformCore.Helpers;
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

                user.UserParams = userService.GetUserParams(Program.User.Id);
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

                textBox12.Text = user.UserParams.LeftUpperLimb.ToString();
                textBox13.Text = user.UserParams.LeftForearm.ToString();
                textBox14.Text = user.UserParams.LeftHand.ToString();

                textBox15.Text = user.UserParams.RightUpperLimb.ToString();
                textBox16.Text = user.UserParams.RightForearm.ToString();
                textBox17.Text = user.UserParams.RightHand.ToString();

                comboBox2.Text = user.UserParams.Gender;
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
                Double.TryParse(textBox5.Text, out val);
                user.UserParams.BodyWeight = val;

                user.UserParams.LengthUnit = comboBox1.Text;

                Double.TryParse(textBox6.Text, out val);
                user.UserParams.LeftTigh = val;
                Double.TryParse(textBox7.Text, out val);
                user.UserParams.LeftShin = val;
                Double.TryParse(textBox8.Text, out val);
                user.UserParams.LeftSole = val;

                Double.TryParse(textBox9.Text, out val);
                user.UserParams.RightTigh = val;
                Double.TryParse(textBox10.Text, out val);
                user.UserParams.RightShin = val;
                Double.TryParse(textBox11.Text, out val);
                user.UserParams.RightSole = val;

                Double.TryParse(textBox12.Text, out val);
                user.UserParams.LeftUpperLimb = val;
                Double.TryParse(textBox13.Text, out val);
                user.UserParams.LeftForearm = val;
                Double.TryParse(textBox14.Text, out val);
                user.UserParams.LeftHand = val;

                Double.TryParse(textBox15.Text, out val);
                user.UserParams.RightUpperLimb = val;
                Double.TryParse(textBox16.Text, out val);
                user.UserParams.RightForearm = val;
                Double.TryParse(textBox17.Text, out val);
                user.UserParams.RightHand = val;

                user.UserParams.Gender = comboBox2.Text;

                DialogResult result = new DialogResult();
                if (this.Text.Equals("Add"))
                {
                    var id = userService.AddUser(user);
                    result = Program.Message("Success", $"{user.FullName} added successfully");
                }
                else
                {
                    user.Id = Program.User.Id;
                    userService.EditUser(user);
                    result = Program.Message("Success", $"{user.FullName} updated successfully");
                }

                if (result == DialogResult.OK)
                {
                    this.Close();
                }

                userSelectReference.UpdateUsers("");
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

        private void validateDouble(object sender, KeyPressEventArgs e)
        {
            Validator.Double(sender, e);
        }
    }
}

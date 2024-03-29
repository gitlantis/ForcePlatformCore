﻿using ForcePlatformCore.Helpers;

namespace ForcePlatformCore
{
    partial class UserAddUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            comboBox2 = new ComboBox();
            label16 = new Label();
            label8 = new Label();
            label7 = new Label();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            textBox8 = new TextBox();
            label12 = new Label();
            textBox7 = new TextBox();
            label11 = new Label();
            textBox6 = new TextBox();
            label10 = new Label();
            comboBox1 = new ComboBox();
            label9 = new Label();
            groupBox3 = new GroupBox();
            textBox9 = new TextBox();
            label13 = new Label();
            textBox10 = new TextBox();
            label14 = new Label();
            textBox11 = new TextBox();
            label15 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            groupBox4 = new GroupBox();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            textBox15 = new TextBox();
            textBox16 = new TextBox();
            textBox17 = new TextBox();
            textBox12 = new TextBox();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            groupBox5 = new GroupBox();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(618, 160);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "User";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "M", "F" });
            comboBox2.Location = new Point(446, 96);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(101, 29);
            comboBox2.TabIndex = 178;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(359, 99);
            label16.Name = "label16";
            label16.Size = new Size(65, 21);
            label16.TabIndex = 17;
            label16.Text = "Gender";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(553, 69);
            label8.Name = "label8";
            label8.Size = new Size(21, 15);
            label8.TabIndex = 16;
            label8.Text = "kg";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(553, 36);
            label7.Name = "label7";
            label7.Size = new Size(23, 15);
            label7.TabIndex = 15;
            label7.Text = "sm";
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(446, 60);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(101, 29);
            textBox5.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(446, 25);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(101, 29);
            textBox4.TabIndex = 5;
            textBox4.KeyPress += validateDouble;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(359, 64);
            label6.Name = "label6";
            label6.Size = new Size(66, 21);
            label6.TabIndex = 12;
            label6.Text = "Weight";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(359, 31);
            label5.Name = "label5";
            label5.Size = new Size(62, 21);
            label5.TabIndex = 11;
            label5.Text = "Height";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(134, 121);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(207, 23);
            dateTimePicker1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 122);
            label4.Name = "label4";
            label4.Size = new Size(85, 21);
            label4.TabIndex = 8;
            label4.Text = "Birth date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 90);
            label3.Name = "label3";
            label3.Size = new Size(111, 21);
            label3.TabIndex = 6;
            label3.Text = "Middle name";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(134, 86);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(205, 29);
            textBox3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 4;
            label2.Text = "Last name";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(134, 54);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(205, 29);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(15, 28);
            label1.Name = "label1";
            label1.Size = new Size(89, 21);
            label1.TabIndex = 2;
            label1.Text = "First name";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(134, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(205, 29);
            textBox1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox8);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(textBox7);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(label10);
            groupBox2.Location = new Point(12, 213);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(305, 137);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Left Foot";
            // 
            // textBox8
            // 
            textBox8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox8.Location = new Point(102, 92);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(150, 29);
            textBox8.TabIndex = 11;
            textBox8.KeyPress += validateDouble;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(15, 98);
            label12.Name = "label12";
            label12.Size = new Size(43, 21);
            label12.TabIndex = 18;
            label12.Text = "Sole";
            // 
            // textBox7
            // 
            textBox7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox7.Location = new Point(102, 57);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(150, 29);
            textBox7.TabIndex = 10;
            textBox7.KeyPress += validateDouble;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(15, 63);
            label11.Name = "label11";
            label11.Size = new Size(44, 21);
            label11.TabIndex = 16;
            label11.Text = "Shin";
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox6.Location = new Point(102, 22);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(150, 29);
            textBox6.TabIndex = 9;
            textBox6.KeyPress += validateDouble;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(15, 28);
            label10.Name = "label10";
            label10.Size = new Size(50, 21);
            label10.TabIndex = 14;
            label10.Text = "Tight";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.Items.AddRange(new object[] { "sm", "mm" });
            comboBox1.Location = new Point(274, 180);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 29);
            comboBox1.TabIndex = 1;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(225, 183);
            label9.Name = "label9";
            label9.Size = new Size(43, 21);
            label9.TabIndex = 16;
            label9.Text = "Unit";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox9);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(textBox10);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(textBox11);
            groupBox3.Controls.Add(label15);
            groupBox3.Location = new Point(325, 213);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(305, 137);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Right Foot";
            // 
            // textBox9
            // 
            textBox9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox9.Location = new Point(102, 22);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(150, 29);
            textBox9.TabIndex = 12;
            textBox9.KeyPress += validateDouble;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(15, 98);
            label13.Name = "label13";
            label13.Size = new Size(43, 21);
            label13.TabIndex = 18;
            label13.Text = "Sole";
            // 
            // textBox10
            // 
            textBox10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox10.Location = new Point(102, 57);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(150, 29);
            textBox10.TabIndex = 13;
            textBox10.KeyPress += validateDouble;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(15, 63);
            label14.Name = "label14";
            label14.Size = new Size(44, 21);
            label14.TabIndex = 16;
            label14.Text = "Shin";
            // 
            // textBox11
            // 
            textBox11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox11.Location = new Point(102, 92);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(150, 29);
            textBox11.TabIndex = 14;
            textBox11.KeyPress += validateDouble;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(15, 28);
            label15.Name = "label15";
            label15.Size = new Size(50, 21);
            label15.TabIndex = 14;
            label15.Text = "Tight";
            // 
            // iconButton2
            // 
            iconButton2.Anchor = AnchorStyles.Bottom;
            iconButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton2.ForeColor = Color.FromArgb(0, 0, 192);
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            iconButton2.IconColor = Color.FromArgb(0, 0, 192);
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 32;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(274, 498);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(89, 39);
            iconButton2.TabIndex = 21;
            iconButton2.Text = "Save";
            iconButton2.TextAlign = ContentAlignment.MiddleRight;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            iconButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton1.ForeColor = Color.FromArgb(0, 0, 192);
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            iconButton1.IconColor = Color.FromArgb(0, 0, 192);
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 32;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(541, 498);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(89, 39);
            iconButton1.TabIndex = 22;
            iconButton1.Text = "Close";
            iconButton1.TextAlign = ContentAlignment.MiddleRight;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label17);
            groupBox4.Controls.Add(label18);
            groupBox4.Controls.Add(label19);
            groupBox4.Controls.Add(textBox15);
            groupBox4.Controls.Add(textBox16);
            groupBox4.Controls.Add(textBox17);
            groupBox4.Location = new Point(323, 356);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(305, 137);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Right Arm";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(17, 23);
            label17.Name = "label17";
            label17.Size = new Size(96, 21);
            label17.TabIndex = 22;
            label17.Text = "Upper limb";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(17, 58);
            label18.Name = "label18";
            label18.Size = new Size(73, 21);
            label18.TabIndex = 21;
            label18.Text = "Forearm";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label19.Location = new Point(17, 95);
            label19.Name = "label19";
            label19.Size = new Size(51, 21);
            label19.TabIndex = 20;
            label19.Text = "Hand";
            // 
            // textBox15
            // 
            textBox15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox15.Location = new Point(113, 20);
            textBox15.Name = "textBox15";
            textBox15.Size = new Size(150, 29);
            textBox15.TabIndex = 18;
            textBox15.KeyPress += validateDouble;
            // 
            // textBox16
            // 
            textBox16.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox16.Location = new Point(113, 57);
            textBox16.Name = "textBox16";
            textBox16.Size = new Size(150, 29);
            textBox16.TabIndex = 19;
            textBox16.KeyPress += validateDouble;
            // 
            // textBox17
            // 
            textBox17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox17.Location = new Point(113, 94);
            textBox17.Name = "textBox17";
            textBox17.Size = new Size(150, 29);
            textBox17.TabIndex = 20;
            textBox17.KeyPress += validateDouble;
            // 
            // textBox12
            // 
            textBox12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox12.Location = new Point(117, 18);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(150, 29);
            textBox12.TabIndex = 15;
            textBox12.KeyPress += validateDouble;
            // 
            // textBox13
            // 
            textBox13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox13.Location = new Point(117, 55);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(150, 29);
            textBox13.TabIndex = 16;
            textBox13.KeyPress += validateDouble;
            // 
            // textBox14
            // 
            textBox14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox14.Location = new Point(117, 92);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(150, 29);
            textBox14.TabIndex = 17;
            textBox14.KeyPress += validateDouble;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label20);
            groupBox5.Controls.Add(textBox12);
            groupBox5.Controls.Add(label21);
            groupBox5.Controls.Add(label22);
            groupBox5.Controls.Add(textBox14);
            groupBox5.Controls.Add(textBox13);
            groupBox5.Location = new Point(12, 356);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(305, 137);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Left Arm";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label20.Location = new Point(15, 23);
            label20.Name = "label20";
            label20.Size = new Size(96, 21);
            label20.TabIndex = 18;
            label20.Text = "Upper limb";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label21.Location = new Point(15, 58);
            label21.Name = "label21";
            label21.Size = new Size(73, 21);
            label21.TabIndex = 16;
            label21.Text = "Forearm";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label22.Location = new Point(15, 95);
            label22.Name = "label22";
            label22.Size = new Size(51, 21);
            label22.TabIndex = 14;
            label22.Text = "Hand";
            // 
            // UserAddUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 543);
            Controls.Add(groupBox4);
            Controls.Add(groupBox5);
            Controls.Add(iconButton1);
            Controls.Add(iconButton2);
            Controls.Add(groupBox3);
            Controls.Add(label9);
            Controls.Add(comboBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MinimumSize = new Size(660, 440);
            Name = "UserAddUpdate";
            Text = "UserAddUpdate";
            Load += UserAddUpdate_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox3;
        private Label label2;
        private TextBox textBox2;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private ComboBox comboBox1;
        private Label label8;
        private Label label7;
        private TextBox textBox5;
        private TextBox textBox4;
        private Label label6;
        private Label label9;
        private TextBox textBox8;
        private Label label12;
        private TextBox textBox7;
        private Label label11;
        private TextBox textBox6;
        private Label label10;
        private GroupBox groupBox3;
        private TextBox textBox9;
        private Label label13;
        private TextBox textBox10;
        private Label label14;
        private TextBox textBox11;
        private Label label15;
        private FontAwesome.Sharp.IconButton iconButton2;
        private ComboBox comboBox2;
        private Label label16;
        private FontAwesome.Sharp.IconButton iconButton1;
        private GroupBox groupBox4;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private GroupBox groupBox5;
        private TextBox textBox15;
        private Label label20;
        private TextBox textBox16;
        private Label label21;
        private TextBox textBox17;
        private Label label22;
        private Label label17;
        private Label label18;
        private Label label19;
    }
}
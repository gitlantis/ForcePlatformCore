namespace ForcePlatformCore
{
    partial class SettingsForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            comboBox4 = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            comboBox1 = new ComboBox();
            label6 = new Label();
            comboBox2 = new ComboBox();
            imageList1 = new ImageList(components);
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(comboBox4, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(button1, 0, 2);
            tableLayoutPanel1.Controls.Add(button2, 1, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(72, 701);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30.638298F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 69.3617F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(150, 144);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Visible = false;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Скользящее окно", "Усреднение", "Хемминг", "Баттерфорт" });
            comboBox4.Location = new Point(78, 3);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(69, 23);
            comboBox4.TabIndex = 0;
            comboBox4.Text = "Выберите фильтр:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(57, 24);
            label2.TabIndex = 3;
            label2.Text = "глубина фильтра:";
            // 
            // button1
            // 
            button1.Location = new Point(3, 38);
            button1.Name = "button1";
            button1.Size = new Size(69, 23);
            button1.TabIndex = 5;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(78, 38);
            button2.Name = "button2";
            button2.Size = new Size(69, 23);
            button2.TabIndex = 6;
            button2.Text = "Выход";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 11);
            label1.TabIndex = 1;
            label1.Text = "тип фильтрации:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(11, 57);
            label4.Name = "label4";
            label4.Size = new Size(103, 21);
            label4.TabIndex = 15;
            label4.Text = "Filter length";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(11, 13);
            label3.Name = "label3";
            label3.Size = new Size(87, 21);
            label3.TabIndex = 13;
            label3.Text = "Filter type";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(163, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(602, 29);
            textBox1.TabIndex = 11;
            textBox1.KeyPress += validateInt;
            // 
            // iconButton2
            // 
            iconButton2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            iconButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton2.ForeColor = Color.FromArgb(0, 0, 192);
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Check;
            iconButton2.IconColor = Color.FromArgb(0, 0, 192);
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 32;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(695, 464);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(70, 39);
            iconButton2.TabIndex = 14;
            iconButton2.Text = "Ok";
            iconButton2.TextAlign = ContentAlignment.MiddleRight;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton1_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.Location = new Point(163, 10);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(602, 29);
            comboBox1.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(11, 100);
            label6.Name = "label6";
            label6.Size = new Size(118, 21);
            label6.TabIndex = 19;
            label6.Text = "Excercise type";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox2.Location = new Point(163, 97);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(602, 29);
            comboBox2.TabIndex = 18;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            comboBox2.SelectedValueChanged += comboBox2_SelectedValueChanged;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "photo_2023-11-12_20-18-50.jpg");
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.Anchor = AnchorStyles.None;
            iconPictureBox1.BackColor = SystemColors.Control;
            iconPictureBox1.ForeColor = SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconPictureBox1.IconColor = SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 218;
            iconPictureBox1.ImageLocation = "";
            iconPictureBox1.Location = new Point(181, 132);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Rotation = 270D;
            iconPictureBox1.Size = new Size(218, 308);
            iconPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox1.TabIndex = 24;
            iconPictureBox1.TabStop = false;
            iconPictureBox1.Visible = false;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.Anchor = AnchorStyles.None;
            iconPictureBox2.BackColor = SystemColors.Control;
            iconPictureBox2.ForeColor = SystemColors.ControlText;
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.None;
            iconPictureBox2.IconColor = SystemColors.ControlText;
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 218;
            iconPictureBox2.ImageLocation = "";
            iconPictureBox2.Location = new Point(372, 132);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Rotation = 270D;
            iconPictureBox2.Size = new Size(218, 308);
            iconPictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox2.TabIndex = 25;
            iconPictureBox2.TabStop = false;
            iconPictureBox2.Visible = false;
            // 
            // iconPictureBox5
            // 
            iconPictureBox5.Anchor = AnchorStyles.None;
            iconPictureBox5.BackColor = SystemColors.Control;
            iconPictureBox5.ForeColor = SystemColors.ControlText;
            iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.None;
            iconPictureBox5.IconColor = SystemColors.ControlText;
            iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox5.IconSize = 218;
            iconPictureBox5.ImageLocation = "";
            iconPictureBox5.Location = new Point(372, 202);
            iconPictureBox5.Name = "iconPictureBox5";
            iconPictureBox5.Rotation = 270D;
            iconPictureBox5.Size = new Size(218, 308);
            iconPictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox5.TabIndex = 33;
            iconPictureBox5.TabStop = false;
            iconPictureBox5.Visible = false;
            // 
            // iconPictureBox6
            // 
            iconPictureBox6.Anchor = AnchorStyles.None;
            iconPictureBox6.BackColor = SystemColors.Control;
            iconPictureBox6.ForeColor = SystemColors.ControlText;
            iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.None;
            iconPictureBox6.IconColor = SystemColors.ControlText;
            iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox6.IconSize = 218;
            iconPictureBox6.ImageLocation = "";
            iconPictureBox6.Location = new Point(558, 132);
            iconPictureBox6.Name = "iconPictureBox6";
            iconPictureBox6.Rotation = 270D;
            iconPictureBox6.Size = new Size(218, 308);
            iconPictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox6.TabIndex = 32;
            iconPictureBox6.TabStop = false;
            iconPictureBox6.Visible = false;
            // 
            // iconPictureBox3
            // 
            iconPictureBox3.Anchor = AnchorStyles.None;
            iconPictureBox3.BackColor = SystemColors.Control;
            iconPictureBox3.ForeColor = SystemColors.ControlText;
            iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.None;
            iconPictureBox3.IconColor = SystemColors.ControlText;
            iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox3.IconSize = 218;
            iconPictureBox3.ImageLocation = "";
            iconPictureBox3.Location = new Point(187, 132);
            iconPictureBox3.Name = "iconPictureBox3";
            iconPictureBox3.Rotation = 270D;
            iconPictureBox3.Size = new Size(218, 308);
            iconPictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox3.TabIndex = 31;
            iconPictureBox3.TabStop = false;
            iconPictureBox3.Visible = false;
            // 
            // iconPictureBox4
            // 
            iconPictureBox4.Anchor = AnchorStyles.None;
            iconPictureBox4.BackColor = SystemColors.Control;
            iconPictureBox4.ForeColor = SystemColors.ControlText;
            iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.None;
            iconPictureBox4.IconColor = SystemColors.ControlText;
            iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox4.IconSize = 218;
            iconPictureBox4.ImageLocation = "";
            iconPictureBox4.Location = new Point(2, 202);
            iconPictureBox4.Name = "iconPictureBox4";
            iconPictureBox4.Rotation = 270D;
            iconPictureBox4.Size = new Size(218, 308);
            iconPictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox4.TabIndex = 30;
            iconPictureBox4.TabStop = false;
            iconPictureBox4.Visible = false;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 515);
            Controls.Add(iconPictureBox5);
            Controls.Add(iconPictureBox6);
            Controls.Add(iconPictureBox3);
            Controls.Add(iconPictureBox4);
            Controls.Add(iconPictureBox2);
            Controls.Add(iconPictureBox1);
            Controls.Add(label6);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(iconButton2);
            Controls.Add(comboBox1);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(423, 218);
            Name = "SettingsForm";
            Text = "Settings";
            FormClosing += SettingsForm_FormClosing;
            Load += Form1_Load;
            KeyPress += validateInt;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox comboBox4;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Label label4;
        private Label label3;
        private TextBox textBox2;
        private FontAwesome.Sharp.IconButton iconButton2;
        private ComboBox comboBox1;
        private Label label6;
        private ComboBox comboBox2;
        private ImageList imageList1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
    }
}
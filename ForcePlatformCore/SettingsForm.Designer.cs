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
            tableLayoutPanel1 = new TableLayoutPanel();
            comboBox4 = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            comboBox1 = new ComboBox();
            label6 = new Label();
            comboBox2 = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
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
            tableLayoutPanel1.Location = new Point(489, 129);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30.638298F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 69.3617F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(391, 263);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Visible = false;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Скользящее окно", "Усреднение", "Хемминг", "Баттерфорт" });
            comboBox4.Location = new Point(198, 3);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(190, 23);
            comboBox4.TabIndex = 0;
            comboBox4.Text = "Выберите фильтр:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 47);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 3;
            label2.Text = "глубина фильтра:";
            // 
            // button1
            // 
            button1.Location = new Point(3, 157);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(198, 157);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Выход";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 1;
            label1.Text = "тип фильтрации:";
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
            iconButton1.Location = new Point(438, 137);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(89, 39);
            iconButton1.TabIndex = 16;
            iconButton1.Text = "Close";
            iconButton1.TextAlign = ContentAlignment.MiddleRight;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(11, 57);
            label4.Name = "label4";
            label4.Size = new Size(146, 21);
            label4.TabIndex = 15;
            label4.Text = "Глубина фильтра";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(11, 13);
            label3.Name = "label3";
            label3.Size = new Size(139, 21);
            label3.TabIndex = 13;
            label3.Text = "Тип фильтрации";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(163, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(361, 29);
            textBox1.TabIndex = 11;
            textBox1.KeyPress += validateInt;
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
            iconButton2.Location = new Point(224, 137);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(89, 39);
            iconButton2.TabIndex = 14;
            iconButton2.Text = "Save";
            iconButton2.TextAlign = ContentAlignment.MiddleRight;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton1_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.Items.AddRange(new object[] { "Скользящее экспоненциальное окно", "Усреднение" });
            comboBox1.Location = new Point(163, 10);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(361, 29);
            comboBox1.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(11, 100);
            label6.Name = "label6";
            label6.Size = new Size(142, 21);
            label6.TabIndex = 19;
            label6.Text = "Тип упражнения";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox2.Items.AddRange(new object[] { "Стоя", "Ход", "Прыжка" });
            comboBox2.Location = new Point(163, 97);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(361, 29);
            comboBox2.TabIndex = 18;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 184);
            Controls.Add(label6);
            Controls.Add(comboBox2);
            Controls.Add(iconButton1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(iconButton2);
            Controls.Add(comboBox1);
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(1000, 500);
            MinimumSize = new Size(423, 218);
            Name = "SettingsForm";
            Text = "Настройки";
            Load += Form1_Load;
            KeyPress += validateInt;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
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
        private FontAwesome.Sharp.IconButton iconButton1;
        private Label label4;
        private Label label3;
        private TextBox textBox2;
        private FontAwesome.Sharp.IconButton iconButton2;
        private ComboBox comboBox1;
        private Label label6;
        private ComboBox comboBox2;
    }
}
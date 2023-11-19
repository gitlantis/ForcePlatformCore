namespace ForcePlatformCore
{
    partial class DataLoggerForm
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
            formsPlot1 = new ScottPlot.FormsPlot();
            groupBox1 = new GroupBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox2 = new GroupBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            groupBox3 = new GroupBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox9 = new CheckBox();
            groupBox4 = new GroupBox();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            textBox12 = new TextBox();
            checkBox10 = new CheckBox();
            checkBox11 = new CheckBox();
            checkBox12 = new CheckBox();
            checkBox13 = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot1.BackColor = SystemColors.Control;
            formsPlot1.Location = new Point(0, 0);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(1326, 684);
            formsPlot1.TabIndex = 0;
            formsPlot1.MouseDown += formsPlot1_MouseDown;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(1355, 67);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(279, 129);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Plate 1";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(158, 89);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 29);
            textBox3.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(158, 58);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 29);
            textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(158, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 29);
            textBox1.TabIndex = 9;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox3.ForeColor = Color.Green;
            checkBox3.Location = new Point(36, 91);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(116, 25);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Z Axis Load";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox2.ForeColor = Color.Coral;
            checkBox2.Location = new Point(36, 60);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(116, 25);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Y Axis Load";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.ForeColor = Color.RoyalBlue;
            checkBox1.Location = new Point(36, 29);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(116, 25);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "X Axis Load";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "kgF", "N" });
            comboBox1.Location = new Point(1437, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(137, 23);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1384, 28);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 6;
            label1.Text = "Unit";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(checkBox4);
            groupBox2.Controls.Add(checkBox5);
            groupBox2.Controls.Add(checkBox6);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(1355, 202);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(279, 129);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Plate 2";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(158, 27);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 29);
            textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(158, 58);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 29);
            textBox5.TabIndex = 13;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(158, 89);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 29);
            textBox6.TabIndex = 12;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox4.ForeColor = Color.Green;
            checkBox4.Location = new Point(36, 91);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(116, 25);
            checkBox4.TabIndex = 2;
            checkBox4.Text = "Z Axis Load";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Checked = true;
            checkBox5.CheckState = CheckState.Checked;
            checkBox5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox5.ForeColor = Color.Coral;
            checkBox5.Location = new Point(36, 60);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(116, 25);
            checkBox5.TabIndex = 1;
            checkBox5.Text = "Y Axis Load";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Checked = true;
            checkBox6.CheckState = CheckState.Checked;
            checkBox6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox6.ForeColor = Color.RoyalBlue;
            checkBox6.Location = new Point(36, 29);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(116, 25);
            checkBox6.TabIndex = 0;
            checkBox6.Text = "X Axis Load";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(textBox7);
            groupBox3.Controls.Add(textBox8);
            groupBox3.Controls.Add(textBox9);
            groupBox3.Controls.Add(checkBox7);
            groupBox3.Controls.Add(checkBox8);
            groupBox3.Controls.Add(checkBox9);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(1355, 337);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(279, 129);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Plate 3";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(158, 27);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 29);
            textBox7.TabIndex = 14;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(158, 59);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 29);
            textBox8.TabIndex = 13;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(158, 90);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(100, 29);
            textBox9.TabIndex = 12;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Checked = true;
            checkBox7.CheckState = CheckState.Checked;
            checkBox7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox7.ForeColor = Color.Green;
            checkBox7.Location = new Point(36, 91);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(116, 25);
            checkBox7.TabIndex = 2;
            checkBox7.Text = "Z Axis Load";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Checked = true;
            checkBox8.CheckState = CheckState.Checked;
            checkBox8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox8.ForeColor = Color.Coral;
            checkBox8.Location = new Point(36, 60);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(116, 25);
            checkBox8.TabIndex = 1;
            checkBox8.Text = "Y Axis Load";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Checked = true;
            checkBox9.CheckState = CheckState.Checked;
            checkBox9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox9.ForeColor = Color.RoyalBlue;
            checkBox9.Location = new Point(36, 29);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(116, 25);
            checkBox9.TabIndex = 0;
            checkBox9.Text = "X Axis Load";
            checkBox9.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox4.Controls.Add(textBox10);
            groupBox4.Controls.Add(textBox11);
            groupBox4.Controls.Add(textBox12);
            groupBox4.Controls.Add(checkBox10);
            groupBox4.Controls.Add(checkBox11);
            groupBox4.Controls.Add(checkBox12);
            groupBox4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox4.Location = new Point(1355, 472);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(279, 129);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Plate 4";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(158, 24);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(100, 29);
            textBox10.TabIndex = 14;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(158, 56);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(100, 29);
            textBox11.TabIndex = 13;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(158, 88);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(100, 29);
            textBox12.TabIndex = 12;
            // 
            // checkBox10
            // 
            checkBox10.AutoSize = true;
            checkBox10.Checked = true;
            checkBox10.CheckState = CheckState.Checked;
            checkBox10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox10.ForeColor = Color.Green;
            checkBox10.Location = new Point(36, 91);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(116, 25);
            checkBox10.TabIndex = 2;
            checkBox10.Text = "Z Axis Load";
            checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            checkBox11.AutoSize = true;
            checkBox11.Checked = true;
            checkBox11.CheckState = CheckState.Checked;
            checkBox11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox11.ForeColor = Color.Coral;
            checkBox11.Location = new Point(36, 60);
            checkBox11.Name = "checkBox11";
            checkBox11.Size = new Size(116, 25);
            checkBox11.TabIndex = 1;
            checkBox11.Text = "Y Axis Load";
            checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            checkBox12.AutoSize = true;
            checkBox12.Checked = true;
            checkBox12.CheckState = CheckState.Checked;
            checkBox12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox12.ForeColor = Color.RoyalBlue;
            checkBox12.Location = new Point(36, 29);
            checkBox12.Name = "checkBox12";
            checkBox12.Size = new Size(116, 25);
            checkBox12.TabIndex = 0;
            checkBox12.Text = "X Axis Load";
            checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            checkBox13.AutoSize = true;
            checkBox13.Checked = true;
            checkBox13.CheckState = CheckState.Checked;
            checkBox13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox13.ForeColor = Color.Black;
            checkBox13.Location = new Point(1436, 607);
            checkBox13.Name = "checkBox13";
            checkBox13.Size = new Size(138, 25);
            checkBox13.TabIndex = 7;
            checkBox13.Text = "Show Legends";
            checkBox13.UseVisualStyleBackColor = true;
            checkBox13.CheckedChanged += checkBox13_CheckedChanged;
            // 
            // DataLoggerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1646, 684);
            Controls.Add(checkBox13);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(groupBox1);
            Controls.Add(formsPlot1);
            Name = "DataLoggerForm";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private GroupBox groupBox1;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private ComboBox comboBox1;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox2;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private GroupBox groupBox3;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private GroupBox groupBox4;
        private CheckBox checkBox10;
        private CheckBox checkBox11;
        private CheckBox checkBox12;
        private CheckBox checkBox13;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
    }
}
namespace ForcePlatformCore
{
    partial class Form1
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
            formsPlot1 = new ScottPlot.FormsPlot();
            groupBox1 = new GroupBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            label1 = new Label();
            checkBox4 = new CheckBox();
            button2 = new Button();
            button3 = new Button();
            richTextBox1 = new RichTextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot1.BackColor = SystemColors.Control;
            formsPlot1.Location = new Point(0, 0);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(1429, 684);
            formsPlot1.TabIndex = 0;
            formsPlot1.MouseDown += formsPlot1_MouseDown;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(1434, 77);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(190, 129);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Signals";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox3.Location = new Point(36, 91);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(108, 25);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Y Axis Load";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox2.Location = new Point(36, 60);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(108, 25);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "X Axis Load";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(36, 29);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(78, 25);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Weight";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Kg", "N" });
            comboBox1.Location = new Point(1487, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(137, 23);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(1470, 271);
            button1.Name = "button1";
            button1.Size = new Size(108, 45);
            button1.TabIndex = 5;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1434, 36);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 6;
            label1.Text = "Unit";
            // 
            // checkBox4
            // 
            checkBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox4.AutoSize = true;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox4.Location = new Point(1470, 221);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(119, 25);
            checkBox4.TabIndex = 7;
            checkBox4.Text = "Show legend";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(1470, 334);
            button2.Name = "button2";
            button2.Size = new Size(108, 45);
            button2.TabIndex = 8;
            button2.Text = "Pause";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(1434, 599);
            button3.Name = "button3";
            button3.Size = new Size(190, 45);
            button3.TabIndex = 9;
            button3.Text = "Save to CSV";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(1298, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(131, 119);
            richTextBox1.TabIndex = 10;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1646, 684);
            Controls.Add(richTextBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(checkBox4);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(groupBox1);
            Controls.Add(formsPlot1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private Button button1;
        private Label label1;
        private CheckBox checkBox4;
        private Button button2;
        private Button button3;
        private RichTextBox richTextBox1;
    }
}
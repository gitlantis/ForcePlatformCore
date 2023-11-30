namespace ForcePlatformCore
{
    partial class Camera
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
            pictureBox1 = new PictureBox();
            comboDevices = new ComboBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(0, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(519, 250);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // comboDevices
            // 
            comboDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDevices.FormattingEnabled = true;
            comboDevices.Location = new Point(3, 2);
            comboDevices.Name = "comboDevices";
            comboDevices.Size = new Size(144, 23);
            comboDevices.TabIndex = 1;
            comboDevices.SelectedIndexChanged += comboDevices_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(164, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(103, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Flip Horizontal";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(277, 4);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(86, 19);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "Flip vertical";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(369, 4);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(128, 19);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "Rotate to 90 degree";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // Camera
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 278);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(comboDevices);
            Controls.Add(pictureBox1);
            MinimumSize = new Size(500, 300);
            Name = "Camera";
            Text = "Camera";
            FormClosing += Camera_FormClosing;
            Load += Camera_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox comboDevices;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
    }
}
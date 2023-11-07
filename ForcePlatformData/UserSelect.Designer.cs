
namespace ForcePlatformData
{
    partial class UserSelect
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            comboBox1 = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // iconButton3
            // 
            iconButton3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            iconButton3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            iconButton3.IconColor = System.Drawing.Color.FromArgb(0, 0, 192);
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 32;
            iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            iconButton3.Location = new System.Drawing.Point(12, 47);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new System.Drawing.Size(126, 39);
            iconButton3.TabIndex = 5;
            iconButton3.Text = "New User";
            iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // iconButton2
            // 
            iconButton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            iconButton2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Check;
            iconButton2.IconColor = System.Drawing.Color.FromArgb(0, 0, 192);
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 32;
            iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            iconButton2.Location = new System.Drawing.Point(306, 47);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new System.Drawing.Size(89, 39);
            iconButton2.TabIndex = 7;
            iconButton2.Text = "Select";
            iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            iconButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            iconButton1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            iconButton1.IconColor = System.Drawing.Color.FromArgb(0, 0, 192);
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 32;
            iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            iconButton1.Location = new System.Drawing.Point(144, 47);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new System.Drawing.Size(79, 39);
            iconButton1.TabIndex = 4;
            iconButton1.Text = "Edit";
            iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(383, 29);
            comboBox1.TabIndex = 6;
            // 
            // UserSelect
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(413, 98);
            Controls.Add(iconButton3);
            Controls.Add(iconButton2);
            Controls.Add(iconButton1);
            Controls.Add(comboBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserSelect";
            Text = "User";
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}


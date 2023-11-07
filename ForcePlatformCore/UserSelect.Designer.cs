
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
            iconButton4 = new FontAwesome.Sharp.IconButton();
            textBox1 = new TextBox();
            label1 = new Label();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // iconButton3
            // 
            iconButton3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton3.ForeColor = Color.FromArgb(0, 0, 192);
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            iconButton3.IconColor = Color.FromArgb(0, 0, 192);
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 32;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(12, 483);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(126, 39);
            iconButton3.TabIndex = 2;
            iconButton3.Text = "New User";
            iconButton3.TextAlign = ContentAlignment.MiddleRight;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // iconButton2
            // 
            iconButton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton2.ForeColor = Color.FromArgb(0, 0, 192);
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Check;
            iconButton2.IconColor = Color.FromArgb(0, 0, 192);
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 32;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(333, 483);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(89, 39);
            iconButton2.TabIndex = 5;
            iconButton2.Text = "Select";
            iconButton2.TextAlign = ContentAlignment.MiddleRight;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // iconButton1
            // 
            iconButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton1.ForeColor = Color.FromArgb(0, 0, 192);
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            iconButton1.IconColor = Color.FromArgb(0, 0, 192);
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 32;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(144, 483);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(79, 39);
            iconButton1.TabIndex = 3;
            iconButton1.Text = "Edit";
            iconButton1.TextAlign = ContentAlignment.MiddleRight;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // iconButton4
            // 
            iconButton4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton4.ForeColor = Color.FromArgb(0, 0, 192);
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
            iconButton4.IconColor = Color.FromArgb(0, 0, 192);
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.IconSize = 32;
            iconButton4.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton4.Location = new Point(229, 483);
            iconButton4.Name = "iconButton4";
            iconButton4.Size = new Size(79, 39);
            iconButton4.TabIndex = 4;
            iconButton4.Text = "Info";
            iconButton4.TextAlign = ContentAlignment.MiddleRight;
            iconButton4.UseVisualStyleBackColor = true;
            iconButton4.Click += iconButton4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(96, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(322, 23);
            textBox1.TabIndex = 0;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(61, 21);
            label1.TabIndex = 12;
            label1.Text = "Search";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 41);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(410, 439);
            listBox1.TabIndex = 1;
            listBox1.DoubleClick += listBox1_DoubleClick;
            // 
            // UserSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 534);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(iconButton4);
            Controls.Add(iconButton3);
            Controls.Add(iconButton2);
            Controls.Add(iconButton1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserSelect";
            Text = "User";
            Load += UserSelect_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton4;
        private TextBox textBox1;
        private Label label1;
        private ListBox listBox1;
    }
}


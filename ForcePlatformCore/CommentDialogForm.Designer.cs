namespace ForcePlatformCore
{
    partial class CommentDialogForm
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
            richTextBox1 = new RichTextBox();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Location = new Point(0, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(451, 138);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Comment";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(5, 20);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(441, 111);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // iconButton1
            // 
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(159, 195);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(119, 23);
            iconButton1.TabIndex = 1;
            iconButton1.Text = "Add comment";
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(5, 9);
            label1.Name = "label1";
            label1.Size = new Size(0, 17);
            label1.TabIndex = 2;
            // 
            // CommentDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 224);
            Controls.Add(label1);
            Controls.Add(iconButton1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CommentDialogForm";
            Text = "Success";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RichTextBox richTextBox1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Label label1;
    }
}
﻿namespace ForcePlatformCore
{
    partial class MDIParent1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            menuStrip = new MenuStrip();
            platesToolStripMenuItem = new ToolStripMenuItem();
            plate1ToolStripMenuItem = new ToolStripMenuItem();
            plate2ToolStripMenuItem = new ToolStripMenuItem();
            plate3ToolStripMenuItem = new ToolStripMenuItem();
            plate4ToolStripMenuItem = new ToolStripMenuItem();
            openAllToolStripMenuItem = new ToolStripMenuItem();
            closeAllToolStripMenuItem = new ToolStripMenuItem();
            windowToolStripMenuItem = new ToolStripMenuItem();
            tileHorizontalToolStripMenuItem = new ToolStripMenuItem();
            tileVerticalToolStripMenuItem = new ToolStripMenuItem();
            cellToolStripMenuItem = new ToolStripMenuItem();
            cascadeToolStripMenuItem = new ToolStripMenuItem();
            richTextBox1 = new RichTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            timer2 = new System.Windows.Forms.Timer(components);
            richTextBox2 = new RichTextBox();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 949);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(1798, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(39, 17);
            toolStripStatusLabel.Text = "Status";
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { platesToolStripMenuItem, windowToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(1798, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "Force Plates";
            // 
            // platesToolStripMenuItem
            // 
            platesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { plate1ToolStripMenuItem, plate2ToolStripMenuItem, plate3ToolStripMenuItem, plate4ToolStripMenuItem, openAllToolStripMenuItem, closeAllToolStripMenuItem });
            platesToolStripMenuItem.Name = "platesToolStripMenuItem";
            platesToolStripMenuItem.Size = new Size(50, 20);
            platesToolStripMenuItem.Text = "Plates";
            // 
            // plate1ToolStripMenuItem
            // 
            plate1ToolStripMenuItem.Name = "plate1ToolStripMenuItem";
            plate1ToolStripMenuItem.Size = new Size(119, 22);
            plate1ToolStripMenuItem.Text = "Plate1";
            plate1ToolStripMenuItem.Click += plate1ToolStripMenuItem_Click;
            // 
            // plate2ToolStripMenuItem
            // 
            plate2ToolStripMenuItem.Name = "plate2ToolStripMenuItem";
            plate2ToolStripMenuItem.Size = new Size(119, 22);
            plate2ToolStripMenuItem.Text = "Plate2";
            plate2ToolStripMenuItem.Click += plate2ToolStripMenuItem_Click;
            // 
            // plate3ToolStripMenuItem
            // 
            plate3ToolStripMenuItem.Name = "plate3ToolStripMenuItem";
            plate3ToolStripMenuItem.Size = new Size(119, 22);
            plate3ToolStripMenuItem.Text = "Plate3";
            plate3ToolStripMenuItem.Click += plate3ToolStripMenuItem_Click;
            // 
            // plate4ToolStripMenuItem
            // 
            plate4ToolStripMenuItem.Name = "plate4ToolStripMenuItem";
            plate4ToolStripMenuItem.Size = new Size(119, 22);
            plate4ToolStripMenuItem.Text = "Plate4";
            plate4ToolStripMenuItem.Click += plate4ToolStripMenuItem_Click;
            // 
            // openAllToolStripMenuItem
            // 
            openAllToolStripMenuItem.Name = "openAllToolStripMenuItem";
            openAllToolStripMenuItem.Size = new Size(119, 22);
            openAllToolStripMenuItem.Text = "AllPlates";
            openAllToolStripMenuItem.Click += openAllToolStripMenuItem_Click;
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(119, 22);
            closeAllToolStripMenuItem.Text = "CloseAll";
            closeAllToolStripMenuItem.Click += closeAllToolStripMenuItem_Click_1;
            // 
            // windowToolStripMenuItem
            // 
            windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tileHorizontalToolStripMenuItem, tileVerticalToolStripMenuItem, cellToolStripMenuItem, cascadeToolStripMenuItem });
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new Size(63, 20);
            windowToolStripMenuItem.Text = "Window";
            // 
            // tileHorizontalToolStripMenuItem
            // 
            tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            tileHorizontalToolStripMenuItem.Size = new Size(150, 22);
            tileHorizontalToolStripMenuItem.Text = "Tile Horizontal";
            tileHorizontalToolStripMenuItem.Click += tileHorizontalToolStripMenuItem_Click_1;
            // 
            // tileVerticalToolStripMenuItem
            // 
            tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            tileVerticalToolStripMenuItem.Size = new Size(150, 22);
            tileVerticalToolStripMenuItem.Text = "TileVertical";
            tileVerticalToolStripMenuItem.Click += tileVerticalToolStripMenuItem_Click_1;
            // 
            // cellToolStripMenuItem
            // 
            cellToolStripMenuItem.Name = "cellToolStripMenuItem";
            cellToolStripMenuItem.Size = new Size(150, 22);
            cellToolStripMenuItem.Text = "Table";
            cellToolStripMenuItem.Click += cellToolStripMenuItem_Click;
            // 
            // cascadeToolStripMenuItem
            // 
            cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            cascadeToolStripMenuItem.Size = new Size(150, 22);
            cascadeToolStripMenuItem.Text = "Cascade";
            cascadeToolStripMenuItem.Click += cascadeToolStripMenuItem_Click_1;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(1417, 117);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(190, 562);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(338, 759);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timer2
            // 
            timer2.Enabled = true;
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(1214, 117);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(197, 562);
            richTextBox2.TabIndex = 8;
            richTextBox2.Text = "";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1798, 25);
            toolStrip1.TabIndex = 10;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // MDIParent1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1798, 971);
            Controls.Add(toolStrip1);
            Controls.Add(richTextBox2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MDIParent1";
            Text = "Force Platrom";
            FormClosing += MDIParent1_FormClosing;
            Load += MDIParent1_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolTip toolTip;
        private MenuStrip menuStrip;
        private ToolStripMenuItem platesToolStripMenuItem;
        private ToolStripMenuItem plate1ToolStripMenuItem;
        private ToolStripMenuItem plate2ToolStripMenuItem;
        private ToolStripMenuItem plate3ToolStripMenuItem;
        private ToolStripMenuItem plate4ToolStripMenuItem;
        private ToolStripMenuItem openAllToolStripMenuItem;
        private ToolStripMenuItem closeAllToolStripMenuItem;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private ToolStripMenuItem tileVerticalToolStripMenuItem;
        private ToolStripMenuItem cascadeToolStripMenuItem;
        private ToolStripMenuItem cellToolStripMenuItem;
        private RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private System.Windows.Forms.Timer timer2;
        private RichTextBox richTextBox2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
    }
}




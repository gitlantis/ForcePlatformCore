namespace ForcePlatformSmart
{
    partial class MainMDI
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
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            userBindingSource = new BindingSource(components);
            reportBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            toolStrip = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStripLabel2 = new ToolStripLabel();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reportBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 574);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(1209, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(39, 17);
            toolStripStatusLabel.Text = "Status";
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(ForcePlatformData.DbModels.User);
            // 
            // reportBindingSource
            // 
            reportBindingSource.DataSource = typeof(ForcePlatformData.DbModels.Report);
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1209, 543);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripTextBox1, toolStripLabel2 });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1209, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "ToolStrip";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(70, 22);
            toolStripLabel1.Text = "Search user:";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.BackColor = Color.Gainsboro;
            toolStripTextBox1.ForeColor = SystemColors.InfoText;
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(200, 25);
            toolStripTextBox1.KeyPress += toolStripTextBox1_KeyPress;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(43, 22);
            toolStripLabel2.Text = "v0.0.10";
            // 
            // MainMDI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 596);
            Controls.Add(dataGridView1);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            IsMdiContainer = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainMDI";
            Text = "MainMDI";
            Load += MainMDI_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)reportBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolTip toolTip;
        private BindingSource reportBindingSource;
        private BindingSource userBindingSource;
        private DataGridView dataGridView1;
        private ToolStrip toolStrip;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
    }
}




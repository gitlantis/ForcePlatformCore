namespace ForcePlatformSmart
{
    partial class AnalyticsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            checkBox1 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            formsPlot1 = new ScottPlot.FormsPlot();
            panel1 = new Panel();
            checkBox6 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox10 = new CheckBox();
            checkBox9 = new CheckBox();
            checkBox8 = new CheckBox();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel3 = new Panel();
            checkBox11 = new CheckBox();
            checkBox12 = new CheckBox();
            checkBox13 = new CheckBox();
            checkBox14 = new CheckBox();
            checkBox15 = new CheckBox();
            formsPlot2 = new ScottPlot.FormsPlot();
            panel4 = new Panel();
            checkBox16 = new CheckBox();
            checkBox17 = new CheckBox();
            checkBox18 = new CheckBox();
            checkBox19 = new CheckBox();
            checkBox20 = new CheckBox();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel5 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(panel4, 1, 1);
            tableLayoutPanel1.Controls.Add(panel5, 1, 2);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1231, 879);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(checkBox1);
            panel2.Controls.Add(checkBox5);
            panel2.Controls.Add(checkBox4);
            panel2.Controls.Add(checkBox3);
            panel2.Controls.Add(checkBox2);
            panel2.Controls.Add(formsPlot1);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(609, 406);
            panel2.TabIndex = 15;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top;
            checkBox1.AutoSize = true;
            checkBox1.BackColor = SystemColors.ButtonHighlight;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(140, 0);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(61, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Plate 1";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBoxFastLine_CheckedChanged;
            // 
            // checkBox5
            // 
            checkBox5.Anchor = AnchorStyles.Top;
            checkBox5.AutoSize = true;
            checkBox5.BackColor = SystemColors.ButtonHighlight;
            checkBox5.Checked = true;
            checkBox5.CheckState = CheckState.Checked;
            checkBox5.Location = new Point(408, 0);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(65, 19);
            checkBox5.TabIndex = 4;
            checkBox5.Text = "Legend";
            checkBox5.UseVisualStyleBackColor = false;
            checkBox5.CheckedChanged += checkBoxFastLine_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.Anchor = AnchorStyles.Top;
            checkBox4.AutoSize = true;
            checkBox4.BackColor = SystemColors.ButtonHighlight;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Location = new Point(341, 0);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(61, 19);
            checkBox4.TabIndex = 3;
            checkBox4.Text = "Plate 4";
            checkBox4.UseVisualStyleBackColor = false;
            checkBox4.CheckedChanged += checkBoxFastLine_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.Anchor = AnchorStyles.Top;
            checkBox3.AutoSize = true;
            checkBox3.BackColor = SystemColors.ButtonHighlight;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(274, 0);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(61, 19);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Plate 3";
            checkBox3.UseVisualStyleBackColor = false;
            checkBox3.CheckedChanged += checkBoxFastLine_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.Anchor = AnchorStyles.Top;
            checkBox2.AutoSize = true;
            checkBox2.BackColor = SystemColors.ButtonHighlight;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(207, 0);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(61, 19);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Plate 2";
            checkBox2.UseVisualStyleBackColor = false;
            checkBox2.CheckedChanged += checkBoxFastLine_CheckedChanged;
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot1.BackColor = Color.White;
            formsPlot1.Location = new Point(-3, -3);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(612, 409);
            formsPlot1.TabIndex = 34;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(checkBox6);
            panel1.Controls.Add(checkBox7);
            panel1.Controls.Add(checkBox10);
            panel1.Controls.Add(checkBox9);
            panel1.Controls.Add(checkBox8);
            panel1.Controls.Add(chart1);
            panel1.Location = new Point(618, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(610, 406);
            panel1.TabIndex = 31;
            // 
            // checkBox6
            // 
            checkBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox6.AutoSize = true;
            checkBox6.BackColor = SystemColors.ButtonHighlight;
            checkBox6.Checked = true;
            checkBox6.CheckState = CheckState.Checked;
            checkBox6.Location = new Point(535, 270);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(61, 19);
            checkBox6.TabIndex = 5;
            checkBox6.Text = "Plate 1";
            checkBox6.UseVisualStyleBackColor = false;
            checkBox6.CheckedChanged += checkBoxRadar_CheckedChanged;
            // 
            // checkBox7
            // 
            checkBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox7.AutoSize = true;
            checkBox7.BackColor = SystemColors.ButtonHighlight;
            checkBox7.Checked = true;
            checkBox7.CheckState = CheckState.Checked;
            checkBox7.Location = new Point(535, 295);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(61, 19);
            checkBox7.TabIndex = 6;
            checkBox7.Text = "Plate 2";
            checkBox7.UseVisualStyleBackColor = false;
            checkBox7.CheckedChanged += checkBoxRadar_CheckedChanged;
            // 
            // checkBox10
            // 
            checkBox10.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox10.AutoSize = true;
            checkBox10.BackColor = SystemColors.ButtonHighlight;
            checkBox10.Checked = true;
            checkBox10.CheckState = CheckState.Checked;
            checkBox10.Location = new Point(535, 371);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(65, 19);
            checkBox10.TabIndex = 9;
            checkBox10.Text = "Legend";
            checkBox10.UseVisualStyleBackColor = false;
            checkBox10.CheckedChanged += checkBoxRadar_CheckedChanged;
            // 
            // checkBox9
            // 
            checkBox9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox9.AutoSize = true;
            checkBox9.BackColor = SystemColors.ButtonHighlight;
            checkBox9.Checked = true;
            checkBox9.CheckState = CheckState.Checked;
            checkBox9.Location = new Point(535, 346);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(61, 19);
            checkBox9.TabIndex = 8;
            checkBox9.Text = "Plate 4";
            checkBox9.UseVisualStyleBackColor = false;
            checkBox9.CheckedChanged += checkBoxRadar_CheckedChanged;
            // 
            // checkBox8
            // 
            checkBox8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox8.AutoSize = true;
            checkBox8.BackColor = SystemColors.ButtonHighlight;
            checkBox8.Checked = true;
            checkBox8.CheckState = CheckState.Checked;
            checkBox8.Location = new Point(535, 321);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(61, 19);
            checkBox8.TabIndex = 7;
            checkBox8.Text = "Plate 3";
            checkBox8.UseVisualStyleBackColor = false;
            checkBox8.CheckedChanged += checkBoxRadar_CheckedChanged;
            // 
            // chart1
            // 
            chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea3.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart1.Legends.Add(legend3);
            chart1.Location = new Point(0, -3);
            chart1.Name = "chart1";
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series9.IsVisibleInLegend = false;
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series10.IsVisibleInLegend = false;
            series10.Legend = "Legend1";
            series10.Name = "Series2";
            series11.BorderWidth = 2;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series11.IsVisibleInLegend = false;
            series11.Legend = "Legend1";
            series11.Name = "Series3";
            series12.BorderWidth = 2;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series12.IsVisibleInLegend = false;
            series12.Legend = "Legend1";
            series12.Name = "Series4";
            chart1.Series.Add(series9);
            chart1.Series.Add(series10);
            chart1.Series.Add(series11);
            chart1.Series.Add(series12);
            chart1.Size = new Size(610, 409);
            chart1.TabIndex = 45;
            chart1.Text = "chart1";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(checkBox11);
            panel3.Controls.Add(checkBox12);
            panel3.Controls.Add(checkBox13);
            panel3.Controls.Add(checkBox14);
            panel3.Controls.Add(checkBox15);
            panel3.Controls.Add(formsPlot2);
            panel3.Location = new Point(3, 415);
            panel3.Name = "panel3";
            panel3.Size = new Size(609, 406);
            panel3.TabIndex = 32;
            // 
            // checkBox11
            // 
            checkBox11.Anchor = AnchorStyles.Top;
            checkBox11.AutoSize = true;
            checkBox11.BackColor = SystemColors.ButtonHighlight;
            checkBox11.Checked = true;
            checkBox11.CheckState = CheckState.Checked;
            checkBox11.Location = new Point(165, 3);
            checkBox11.Name = "checkBox11";
            checkBox11.Size = new Size(61, 19);
            checkBox11.TabIndex = 10;
            checkBox11.Text = "Plate 1";
            checkBox11.UseVisualStyleBackColor = false;
            checkBox11.CheckedChanged += checkBoxHeatmap_CheckedChanged;
            // 
            // checkBox12
            // 
            checkBox12.Anchor = AnchorStyles.Top;
            checkBox12.AutoSize = true;
            checkBox12.BackColor = SystemColors.ButtonHighlight;
            checkBox12.Checked = true;
            checkBox12.CheckState = CheckState.Checked;
            checkBox12.Location = new Point(232, 3);
            checkBox12.Name = "checkBox12";
            checkBox12.Size = new Size(61, 19);
            checkBox12.TabIndex = 11;
            checkBox12.Text = "Plate 2";
            checkBox12.UseVisualStyleBackColor = false;
            checkBox12.CheckedChanged += checkBoxHeatmap_CheckedChanged;
            // 
            // checkBox13
            // 
            checkBox13.Anchor = AnchorStyles.Top;
            checkBox13.AutoSize = true;
            checkBox13.BackColor = SystemColors.ButtonHighlight;
            checkBox13.Checked = true;
            checkBox13.CheckState = CheckState.Checked;
            checkBox13.Location = new Point(299, 3);
            checkBox13.Name = "checkBox13";
            checkBox13.Size = new Size(61, 19);
            checkBox13.TabIndex = 12;
            checkBox13.Text = "Plate 3";
            checkBox13.UseVisualStyleBackColor = false;
            checkBox13.CheckedChanged += checkBoxHeatmap_CheckedChanged;
            // 
            // checkBox14
            // 
            checkBox14.Anchor = AnchorStyles.Top;
            checkBox14.AutoSize = true;
            checkBox14.BackColor = SystemColors.ButtonHighlight;
            checkBox14.Checked = true;
            checkBox14.CheckState = CheckState.Checked;
            checkBox14.Location = new Point(366, 3);
            checkBox14.Name = "checkBox14";
            checkBox14.Size = new Size(61, 19);
            checkBox14.TabIndex = 13;
            checkBox14.Text = "Plate 4";
            checkBox14.UseVisualStyleBackColor = false;
            checkBox14.CheckedChanged += checkBoxHeatmap_CheckedChanged;
            // 
            // checkBox15
            // 
            checkBox15.Anchor = AnchorStyles.Top;
            checkBox15.AutoSize = true;
            checkBox15.BackColor = SystemColors.ButtonHighlight;
            checkBox15.Checked = true;
            checkBox15.CheckState = CheckState.Checked;
            checkBox15.Location = new Point(433, 3);
            checkBox15.Name = "checkBox15";
            checkBox15.Size = new Size(65, 19);
            checkBox15.TabIndex = 14;
            checkBox15.Text = "Legend";
            checkBox15.UseVisualStyleBackColor = false;
            checkBox15.Visible = false;
            // 
            // formsPlot2
            // 
            formsPlot2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot2.BackColor = Color.White;
            formsPlot2.Location = new Point(-3, 0);
            formsPlot2.Margin = new Padding(4, 3, 4, 3);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(612, 409);
            formsPlot2.TabIndex = 50;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(checkBox16);
            panel4.Controls.Add(checkBox17);
            panel4.Controls.Add(checkBox18);
            panel4.Controls.Add(checkBox19);
            panel4.Controls.Add(checkBox20);
            panel4.Controls.Add(chart2);
            panel4.Location = new Point(618, 415);
            panel4.Name = "panel4";
            panel4.Size = new Size(610, 406);
            panel4.TabIndex = 33;
            // 
            // checkBox16
            // 
            checkBox16.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox16.AutoSize = true;
            checkBox16.BackColor = SystemColors.ButtonHighlight;
            checkBox16.Checked = true;
            checkBox16.CheckState = CheckState.Checked;
            checkBox16.Location = new Point(535, 275);
            checkBox16.Name = "checkBox16";
            checkBox16.Size = new Size(61, 19);
            checkBox16.TabIndex = 15;
            checkBox16.Text = "Plate 1";
            checkBox16.UseVisualStyleBackColor = false;
            checkBox16.CheckedChanged += checkBoxTrack_CheckedChanged;
            // 
            // checkBox17
            // 
            checkBox17.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox17.AutoSize = true;
            checkBox17.BackColor = SystemColors.ButtonHighlight;
            checkBox17.Checked = true;
            checkBox17.CheckState = CheckState.Checked;
            checkBox17.Location = new Point(535, 300);
            checkBox17.Name = "checkBox17";
            checkBox17.Size = new Size(61, 19);
            checkBox17.TabIndex = 16;
            checkBox17.Text = "Plate 2";
            checkBox17.UseVisualStyleBackColor = false;
            checkBox17.CheckedChanged += checkBoxTrack_CheckedChanged;
            // 
            // checkBox18
            // 
            checkBox18.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox18.AutoSize = true;
            checkBox18.BackColor = SystemColors.ButtonHighlight;
            checkBox18.Checked = true;
            checkBox18.CheckState = CheckState.Checked;
            checkBox18.Location = new Point(535, 326);
            checkBox18.Name = "checkBox18";
            checkBox18.Size = new Size(61, 19);
            checkBox18.TabIndex = 17;
            checkBox18.Text = "Plate 3";
            checkBox18.UseVisualStyleBackColor = false;
            checkBox18.CheckedChanged += checkBoxTrack_CheckedChanged;
            // 
            // checkBox19
            // 
            checkBox19.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox19.AutoSize = true;
            checkBox19.BackColor = SystemColors.ButtonHighlight;
            checkBox19.Checked = true;
            checkBox19.CheckState = CheckState.Checked;
            checkBox19.Location = new Point(535, 351);
            checkBox19.Name = "checkBox19";
            checkBox19.Size = new Size(61, 19);
            checkBox19.TabIndex = 18;
            checkBox19.Text = "Plate 4";
            checkBox19.UseVisualStyleBackColor = false;
            checkBox19.CheckedChanged += checkBoxTrack_CheckedChanged;
            // 
            // checkBox20
            // 
            checkBox20.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox20.AutoSize = true;
            checkBox20.BackColor = SystemColors.ButtonHighlight;
            checkBox20.Checked = true;
            checkBox20.CheckState = CheckState.Checked;
            checkBox20.Location = new Point(535, 376);
            checkBox20.Name = "checkBox20";
            checkBox20.Size = new Size(65, 19);
            checkBox20.TabIndex = 19;
            checkBox20.Text = "Legend";
            checkBox20.UseVisualStyleBackColor = false;
            checkBox20.CheckedChanged += checkBoxTrack_CheckedChanged;
            // 
            // chart2
            // 
            chart2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea4.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chart2.Legends.Add(legend4);
            chart2.Location = new Point(0, 0);
            chart2.Name = "chart2";
            series13.BorderWidth = 2;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series13.IsVisibleInLegend = false;
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            series14.BorderWidth = 2;
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series14.IsVisibleInLegend = false;
            series14.Legend = "Legend1";
            series14.Name = "Series2";
            series15.BorderWidth = 2;
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series15.IsVisibleInLegend = false;
            series15.Legend = "Legend1";
            series15.Name = "Series3";
            series16.BorderWidth = 2;
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series16.IsVisibleInLegend = false;
            series16.Legend = "Legend1";
            series16.Name = "Series4";
            chart2.Series.Add(series13);
            chart2.Series.Add(series14);
            chart2.Series.Add(series15);
            chart2.Series.Add(series16);
            chart2.Size = new Size(610, 411);
            chart2.TabIndex = 50;
            chart2.Text = "chart2";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(iconButton1);
            panel5.Location = new Point(618, 827);
            panel5.Name = "panel5";
            panel5.Size = new Size(610, 49);
            panel5.TabIndex = 34;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Right;
            iconButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton1.ForeColor = Color.FromArgb(0, 0, 192);
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            iconButton1.IconColor = Color.FromArgb(0, 0, 192);
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 32;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(467, 4);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(141, 41);
            iconButton1.TabIndex = 20;
            iconButton1.Text = "Save report";
            iconButton1.TextAlign = ContentAlignment.MiddleRight;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // AnalyticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 878);
            Controls.Add(tableLayoutPanel1);
            Name = "AnalyticsForm";
            Text = "Statistics";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private Panel panel2;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private Panel panel1;
        private Panel panel3;
        private Panel panel4;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel5;
        private ScottPlot.FormsPlot formsPlot1;
        private CheckBox checkBox1;
        private CheckBox checkBox11;
        private CheckBox checkBox12;
        private CheckBox checkBox13;
        private CheckBox checkBox14;
        private CheckBox checkBox15;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox10;
        private CheckBox checkBox9;
        private CheckBox checkBox8;
        private CheckBox checkBox16;
        private CheckBox checkBox17;
        private CheckBox checkBox18;
        private CheckBox checkBox19;
        private CheckBox checkBox20;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private ScottPlot.FormsPlot formsPlot2;
    }
}
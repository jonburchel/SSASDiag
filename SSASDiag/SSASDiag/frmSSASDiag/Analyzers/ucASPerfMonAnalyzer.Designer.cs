﻿namespace SSASDiag
{
    partial class ucASPerfMonAnalyzer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitLogList = new System.Windows.Forms.SplitContainer();
            this.splitLogDetails = new System.Windows.Forms.SplitContainer();
            this.dgdLogList = new System.Windows.Forms.DataGridView();
            this.rtLogDetails = new System.Windows.Forms.RichTextBox();
            this.btnAnalyzeLogs = new System.Windows.Forms.Button();
            this.splitHideFilesButton = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHideFilesButton = new System.Windows.Forms.Label();
            this.splitAnalysis = new System.Windows.Forms.SplitContainer();
            this.splitPerfMonCountersAndChart = new System.Windows.Forms.SplitContainer();
            this.pnlCounters = new System.Windows.Forms.Panel();
            this.dgdGrouping = new System.Windows.Forms.DataGridView();
            this.Counter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSeriesDetails = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDur = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAvg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chartPerfMon = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnServers = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAutoScale = new System.Windows.Forms.CheckBox();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.lblCounterGrouping = new System.Windows.Forms.Label();
            this.dgdRules = new System.Windows.Forms.DataGridView();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewImageColumn();
            this.ResultDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnAnalyses = new System.Windows.Forms.Panel();
            this.pnlRuleButtons = new System.Windows.Forms.Panel();
            this.btnDeleteRule = new System.Windows.Forms.Button();
            this.btnEditRule = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRunAllRules = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.cmbRuleFilter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitLogList)).BeginInit();
            this.splitLogList.Panel1.SuspendLayout();
            this.splitLogList.Panel2.SuspendLayout();
            this.splitLogList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLogDetails)).BeginInit();
            this.splitLogDetails.Panel1.SuspendLayout();
            this.splitLogDetails.Panel2.SuspendLayout();
            this.splitLogDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdLogList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitHideFilesButton)).BeginInit();
            this.splitHideFilesButton.Panel1.SuspendLayout();
            this.splitHideFilesButton.Panel2.SuspendLayout();
            this.splitHideFilesButton.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitAnalysis)).BeginInit();
            this.splitAnalysis.Panel1.SuspendLayout();
            this.splitAnalysis.Panel2.SuspendLayout();
            this.splitAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPerfMonCountersAndChart)).BeginInit();
            this.splitPerfMonCountersAndChart.Panel1.SuspendLayout();
            this.splitPerfMonCountersAndChart.Panel2.SuspendLayout();
            this.splitPerfMonCountersAndChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdGrouping)).BeginInit();
            this.pnlSeriesDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerfMon)).BeginInit();
            this.pnServers.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdRules)).BeginInit();
            this.pnAnalyses.SuspendLayout();
            this.pnlRuleButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitLogList
            // 
            this.splitLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLogList.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitLogList.Location = new System.Drawing.Point(0, 0);
            this.splitLogList.Margin = new System.Windows.Forms.Padding(0);
            this.splitLogList.Name = "splitLogList";
            // 
            // splitLogList.Panel1
            // 
            this.splitLogList.Panel1.Controls.Add(this.splitLogDetails);
            this.splitLogList.Panel1.Controls.Add(this.btnAnalyzeLogs);
            // 
            // splitLogList.Panel2
            // 
            this.splitLogList.Panel2.Controls.Add(this.splitHideFilesButton);
            this.splitLogList.Size = new System.Drawing.Size(1000, 545);
            this.splitLogList.SplitterDistance = 189;
            this.splitLogList.TabIndex = 1;
            // 
            // splitLogDetails
            // 
            this.splitLogDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLogDetails.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitLogDetails.Location = new System.Drawing.Point(0, 21);
            this.splitLogDetails.Name = "splitLogDetails";
            this.splitLogDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLogDetails.Panel1
            // 
            this.splitLogDetails.Panel1.Controls.Add(this.dgdLogList);
            // 
            // splitLogDetails.Panel2
            // 
            this.splitLogDetails.Panel2.Controls.Add(this.rtLogDetails);
            this.splitLogDetails.Panel2MinSize = 100;
            this.splitLogDetails.Size = new System.Drawing.Size(189, 524);
            this.splitLogDetails.SplitterDistance = 366;
            this.splitLogDetails.TabIndex = 3;
            // 
            // dgdLogList
            // 
            this.dgdLogList.AllowUserToAddRows = false;
            this.dgdLogList.AllowUserToDeleteRows = false;
            this.dgdLogList.AllowUserToResizeRows = false;
            this.dgdLogList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgdLogList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgdLogList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgdLogList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgdLogList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdLogList.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdLogList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgdLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgdLogList.Location = new System.Drawing.Point(0, 0);
            this.dgdLogList.Margin = new System.Windows.Forms.Padding(0);
            this.dgdLogList.Name = "dgdLogList";
            this.dgdLogList.ReadOnly = true;
            this.dgdLogList.RowHeadersVisible = false;
            this.dgdLogList.Size = new System.Drawing.Size(189, 366);
            this.dgdLogList.TabIndex = 3;
            this.dgdLogList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgdLogList_DataBindingComplete);
            // 
            // rtLogDetails
            // 
            this.rtLogDetails.BackColor = System.Drawing.Color.Black;
            this.rtLogDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtLogDetails.DetectUrls = false;
            this.rtLogDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtLogDetails.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtLogDetails.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.rtLogDetails.Location = new System.Drawing.Point(0, 0);
            this.rtLogDetails.Name = "rtLogDetails";
            this.rtLogDetails.ReadOnly = true;
            this.rtLogDetails.Size = new System.Drawing.Size(189, 154);
            this.rtLogDetails.TabIndex = 40;
            this.rtLogDetails.Text = "";
            // 
            // btnAnalyzeLogs
            // 
            this.btnAnalyzeLogs.BackColor = System.Drawing.SystemColors.Control;
            this.btnAnalyzeLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnalyzeLogs.Enabled = false;
            this.btnAnalyzeLogs.FlatAppearance.BorderSize = 0;
            this.btnAnalyzeLogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAnalyzeLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAnalyzeLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyzeLogs.Location = new System.Drawing.Point(0, 0);
            this.btnAnalyzeLogs.Name = "btnAnalyzeLogs";
            this.btnAnalyzeLogs.Size = new System.Drawing.Size(189, 21);
            this.btnAnalyzeLogs.TabIndex = 1;
            this.btnAnalyzeLogs.UseVisualStyleBackColor = false;
            this.btnAnalyzeLogs.Click += new System.EventHandler(this.btnAnalyzeLogs_Click);
            // 
            // splitHideFilesButton
            // 
            this.splitHideFilesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitHideFilesButton.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitHideFilesButton.IsSplitterFixed = true;
            this.splitHideFilesButton.Location = new System.Drawing.Point(0, 0);
            this.splitHideFilesButton.Margin = new System.Windows.Forms.Padding(0);
            this.splitHideFilesButton.Name = "splitHideFilesButton";
            // 
            // splitHideFilesButton.Panel1
            // 
            this.splitHideFilesButton.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitHideFilesButton.Panel1MinSize = 14;
            // 
            // splitHideFilesButton.Panel2
            // 
            this.splitHideFilesButton.Panel2.Controls.Add(this.splitAnalysis);
            this.splitHideFilesButton.Size = new System.Drawing.Size(807, 545);
            this.splitHideFilesButton.SplitterDistance = 25;
            this.splitHideFilesButton.SplitterWidth = 1;
            this.splitHideFilesButton.TabIndex = 1;
            this.splitHideFilesButton.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblHideFilesButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(25, 545);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.tableLayoutPanel1_Click);
            this.tableLayoutPanel1.MouseLeave += new System.EventHandler(this.tableLayoutPanel1_MouseLeave);
            this.tableLayoutPanel1.MouseHover += new System.EventHandler(this.tableLayoutPanel1_MouseHover);
            this.tableLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // lblHideFilesButton
            // 
            this.lblHideFilesButton.AutoSize = true;
            this.lblHideFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHideFilesButton.Location = new System.Drawing.Point(0, 262);
            this.lblHideFilesButton.Margin = new System.Windows.Forms.Padding(0);
            this.lblHideFilesButton.Name = "lblHideFilesButton";
            this.lblHideFilesButton.Size = new System.Drawing.Size(18, 13);
            this.lblHideFilesButton.TabIndex = 0;
            this.lblHideFilesButton.Text = "≪";
            this.lblHideFilesButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHideFilesButton.Click += new System.EventHandler(this.tableLayoutPanel1_Click);
            this.lblHideFilesButton.MouseLeave += new System.EventHandler(this.tableLayoutPanel1_MouseLeave);
            this.lblHideFilesButton.MouseHover += new System.EventHandler(this.tableLayoutPanel1_MouseHover);
            // 
            // splitAnalysis
            // 
            this.splitAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitAnalysis.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitAnalysis.Location = new System.Drawing.Point(0, 0);
            this.splitAnalysis.Name = "splitAnalysis";
            this.splitAnalysis.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitAnalysis.Panel1
            // 
            this.splitAnalysis.Panel1.Controls.Add(this.splitPerfMonCountersAndChart);
            this.splitAnalysis.Panel1.Controls.Add(this.pnServers);
            // 
            // splitAnalysis.Panel2
            // 
            this.splitAnalysis.Panel2.Controls.Add(this.dgdRules);
            this.splitAnalysis.Panel2.Controls.Add(this.pnAnalyses);
            this.splitAnalysis.Panel2MinSize = 100;
            this.splitAnalysis.Size = new System.Drawing.Size(781, 545);
            this.splitAnalysis.SplitterDistance = 389;
            this.splitAnalysis.TabIndex = 1;
            this.splitAnalysis.Visible = false;
            // 
            // splitPerfMonCountersAndChart
            // 
            this.splitPerfMonCountersAndChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPerfMonCountersAndChart.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitPerfMonCountersAndChart.Location = new System.Drawing.Point(0, 21);
            this.splitPerfMonCountersAndChart.Name = "splitPerfMonCountersAndChart";
            // 
            // splitPerfMonCountersAndChart.Panel1
            // 
            this.splitPerfMonCountersAndChart.Panel1.Controls.Add(this.pnlCounters);
            this.splitPerfMonCountersAndChart.Panel1.Controls.Add(this.dgdGrouping);
            this.splitPerfMonCountersAndChart.Panel1MinSize = 150;
            // 
            // splitPerfMonCountersAndChart.Panel2
            // 
            this.splitPerfMonCountersAndChart.Panel2.Controls.Add(this.pnlSeriesDetails);
            this.splitPerfMonCountersAndChart.Panel2.Controls.Add(this.chartPerfMon);
            this.splitPerfMonCountersAndChart.Size = new System.Drawing.Size(781, 368);
            this.splitPerfMonCountersAndChart.SplitterDistance = 218;
            this.splitPerfMonCountersAndChart.TabIndex = 47;
            // 
            // pnlCounters
            // 
            this.pnlCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCounters.Location = new System.Drawing.Point(0, 21);
            this.pnlCounters.Name = "pnlCounters";
            this.pnlCounters.Size = new System.Drawing.Size(218, 347);
            this.pnlCounters.TabIndex = 2;
            // 
            // dgdGrouping
            // 
            this.dgdGrouping.AllowUserToOrderColumns = true;
            this.dgdGrouping.AllowUserToResizeColumns = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgdGrouping.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgdGrouping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdGrouping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Counter,
            this.Instance});
            this.dgdGrouping.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgdGrouping.Location = new System.Drawing.Point(0, 0);
            this.dgdGrouping.Name = "dgdGrouping";
            this.dgdGrouping.RowHeadersVisible = false;
            this.dgdGrouping.Size = new System.Drawing.Size(218, 21);
            this.dgdGrouping.TabIndex = 1;
            // 
            // Counter
            // 
            this.Counter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Counter.HeaderText = "Counter";
            this.Counter.Name = "Counter";
            this.Counter.ReadOnly = true;
            // 
            // Instance
            // 
            this.Instance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Instance.HeaderText = "Instance";
            this.Instance.Name = "Instance";
            this.Instance.ReadOnly = true;
            // 
            // pnlSeriesDetails
            // 
            this.pnlSeriesDetails.Controls.Add(this.label1);
            this.pnlSeriesDetails.Controls.Add(this.label6);
            this.pnlSeriesDetails.Controls.Add(this.txtDur);
            this.pnlSeriesDetails.Controls.Add(this.label3);
            this.pnlSeriesDetails.Controls.Add(this.txtAvg);
            this.pnlSeriesDetails.Controls.Add(this.label2);
            this.pnlSeriesDetails.Controls.Add(this.txtMin);
            this.pnlSeriesDetails.Controls.Add(this.txtMax);
            this.pnlSeriesDetails.Controls.Add(this.label4);
            this.pnlSeriesDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSeriesDetails.Location = new System.Drawing.Point(0, 312);
            this.pnlSeriesDetails.Name = "pnlSeriesDetails";
            this.pnlSeriesDetails.Size = new System.Drawing.Size(559, 56);
            this.pnlSeriesDetails.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(387, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Duration";
            // 
            // txtDur
            // 
            this.txtDur.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDur.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDur.Location = new System.Drawing.Point(51, 38);
            this.txtDur.Margin = new System.Windows.Forms.Padding(0);
            this.txtDur.Name = "txtDur";
            this.txtDur.ReadOnly = true;
            this.txtDur.Size = new System.Drawing.Size(80, 18);
            this.txtDur.TabIndex = 4;
            this.txtDur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDur.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SummaryTextBoxes_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(133, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Avg";
            // 
            // txtAvg
            // 
            this.txtAvg.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtAvg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAvg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvg.Location = new System.Drawing.Point(159, 38);
            this.txtAvg.Margin = new System.Windows.Forms.Padding(0);
            this.txtAvg.Name = "txtAvg";
            this.txtAvg.ReadOnly = true;
            this.txtAvg.Size = new System.Drawing.Size(100, 18);
            this.txtAvg.TabIndex = 4;
            this.txtAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAvg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SummaryTextBoxes_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Min";
            // 
            // txtMin
            // 
            this.txtMin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.Location = new System.Drawing.Point(285, 38);
            this.txtMin.Margin = new System.Windows.Forms.Padding(0);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(100, 18);
            this.txtMin.TabIndex = 2;
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SummaryTextBoxes_Enter);
            // 
            // txtMax
            // 
            this.txtMax.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.Location = new System.Drawing.Point(414, 38);
            this.txtMax.Margin = new System.Windows.Forms.Padding(0);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(100, 18);
            this.txtMax.TabIndex = 0;
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SummaryTextBoxes_Enter);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(563, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1, 20);
            this.label4.TabIndex = 0;
            // 
            // chartPerfMon
            // 
            this.chartPerfMon.BorderlineWidth = 0;
            this.chartPerfMon.BorderSkin.BorderWidth = 0;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            chartArea2.AxisX.LabelStyle.Format = "yyyy-MM-dd\nHH:mm:ss";
            chartArea2.AxisX.LabelStyle.Interval = 0D;
            chartArea2.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea2.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorGrid.LineWidth = 0;
            chartArea2.AxisX.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.InsideArea;
            chartArea2.AxisX.MaximumAutoSize = 100F;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisX.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.InsideArea;
            chartArea2.AxisX.Title = "Date/Time (UTC)";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            chartArea2.AxisX2.IsMarginVisible = false;
            chartArea2.AxisX2.LabelStyle.Enabled = false;
            chartArea2.AxisX2.MaximumAutoSize = 100F;
            chartArea2.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea2.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            chartArea2.AxisY.LabelStyle.Interval = 0D;
            chartArea2.AxisY.LabelStyle.IntervalOffset = 0D;
            chartArea2.AxisY.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.LineWidth = 0;
            chartArea2.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.InsideArea;
            chartArea2.AxisY.MaximumAutoSize = 100F;
            chartArea2.AxisY.MinorGrid.LineWidth = 0;
            chartArea2.AxisY.MinorTickMark.Enabled = true;
            chartArea2.AxisY.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.InsideArea;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY2.IsMarginVisible = false;
            chartArea2.AxisY2.LabelStyle.Enabled = false;
            chartArea2.AxisY2.MaximumAutoSize = 100F;
            chartArea2.BorderWidth = 0;
            chartArea2.IsSameFontSizeForAllAxes = true;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.chartPerfMon.ChartAreas.Add(chartArea2);
            this.chartPerfMon.Dock = System.Windows.Forms.DockStyle.Top;
            legend2.AutoFitMinFontSize = 6;
            legend2.BackColor = System.Drawing.SystemColors.ControlLight;
            legend2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            legend2.Enabled = false;
            legend2.Name = "Legend";
            legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            legend2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold);
            this.chartPerfMon.Legends.Add(legend2);
            this.chartPerfMon.Location = new System.Drawing.Point(0, 0);
            this.chartPerfMon.Margin = new System.Windows.Forms.Padding(0);
            this.chartPerfMon.Name = "chartPerfMon";
            this.chartPerfMon.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chartPerfMon.Size = new System.Drawing.Size(559, 309);
            this.chartPerfMon.SuppressExceptions = true;
            this.chartPerfMon.TabIndex = 0;
            this.chartPerfMon.Text = "Counter Data";
            this.chartPerfMon.SizeChanged += new System.EventHandler(this.ucASPerfMonAnalyzer_SizeChanged);
            this.chartPerfMon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartPerfMon_MouseClick);
            this.chartPerfMon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChartPerfMon_MouseMove);
            // 
            // pnServers
            // 
            this.pnServers.Controls.Add(this.panel1);
            this.pnServers.Controls.Add(this.lblCounterGrouping);
            this.pnServers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnServers.Location = new System.Drawing.Point(0, 0);
            this.pnServers.Margin = new System.Windows.Forms.Padding(0);
            this.pnServers.Name = "pnServers";
            this.pnServers.Size = new System.Drawing.Size(781, 21);
            this.pnServers.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAutoScale);
            this.panel1.Controls.Add(this.cmbServers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(470, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 21);
            this.panel1.TabIndex = 3;
            // 
            // chkAutoScale
            // 
            this.chkAutoScale.AutoSize = true;
            this.chkAutoScale.Checked = true;
            this.chkAutoScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoScale.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAutoScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoScale.Location = new System.Drawing.Point(0, 0);
            this.chkAutoScale.Name = "chkAutoScale";
            this.chkAutoScale.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.chkAutoScale.Size = new System.Drawing.Size(148, 21);
            this.chkAutoScale.TabIndex = 3;
            this.chkAutoScale.Text = "Auto-scale displayed counters";
            this.chkAutoScale.UseVisualStyleBackColor = true;
            this.chkAutoScale.CheckedChanged += new System.EventHandler(this.chkAutoScale_CheckedChanged);
            // 
            // cmbServers
            // 
            this.cmbServers.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServers.FormattingEnabled = true;
            this.cmbServers.ItemHeight = 12;
            this.cmbServers.Location = new System.Drawing.Point(162, 0);
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.Size = new System.Drawing.Size(149, 20);
            this.cmbServers.TabIndex = 2;
            // 
            // lblCounterGrouping
            // 
            this.lblCounterGrouping.AutoSize = true;
            this.lblCounterGrouping.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounterGrouping.Location = new System.Drawing.Point(4, 5);
            this.lblCounterGrouping.Name = "lblCounterGrouping";
            this.lblCounterGrouping.Size = new System.Drawing.Size(146, 12);
            this.lblCounterGrouping.TabIndex = 2;
            this.lblCounterGrouping.Text = "Drag headers to reorder groupings:";
            this.lblCounterGrouping.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgdRules
            // 
            this.dgdRules.AllowUserToAddRows = false;
            this.dgdRules.AllowUserToDeleteRows = false;
            this.dgdRules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgdRules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgdRules.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgdRules.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdRules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgdRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.RuleName,
            this.Description,
            this.Result,
            this.ResultDescription});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdRules.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgdRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgdRules.Location = new System.Drawing.Point(0, 20);
            this.dgdRules.Margin = new System.Windows.Forms.Padding(0);
            this.dgdRules.MultiSelect = false;
            this.dgdRules.Name = "dgdRules";
            this.dgdRules.ReadOnly = true;
            this.dgdRules.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgdRules.RowHeadersVisible = false;
            this.dgdRules.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgdRules.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgdRules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgdRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdRules.ShowCellErrors = false;
            this.dgdRules.ShowEditingIcon = false;
            this.dgdRules.ShowRowErrors = false;
            this.dgdRules.Size = new System.Drawing.Size(781, 132);
            this.dgdRules.TabIndex = 3;
            this.dgdRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdRules_CellClick);
            this.dgdRules.SelectionChanged += new System.EventHandler(this.dgdRules_SelectionChanged);
            this.dgdRules.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgdRules_MouseClick);
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.Frozen = true;
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // RuleName
            // 
            this.RuleName.DataPropertyName = "Name";
            this.RuleName.Frozen = true;
            this.RuleName.HeaderText = "Rule Name";
            this.RuleName.Name = "RuleName";
            this.RuleName.ReadOnly = true;
            this.RuleName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RuleName.Width = 150;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.FillWeight = 87.25314F;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Result
            // 
            this.Result.DataPropertyName = "RuleResultImg";
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Result.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Result.Width = 45;
            // 
            // ResultDescription
            // 
            this.ResultDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ResultDescription.DataPropertyName = "ResultDescription";
            this.ResultDescription.FillWeight = 112.7469F;
            this.ResultDescription.HeaderText = "";
            this.ResultDescription.Name = "ResultDescription";
            this.ResultDescription.ReadOnly = true;
            this.ResultDescription.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ResultDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnAnalyses
            // 
            this.pnAnalyses.Controls.Add(this.label5);
            this.pnAnalyses.Controls.Add(this.cmbRuleFilter);
            this.pnAnalyses.Controls.Add(this.pnlRuleButtons);
            this.pnAnalyses.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnAnalyses.Location = new System.Drawing.Point(0, 0);
            this.pnAnalyses.Name = "pnAnalyses";
            this.pnAnalyses.Size = new System.Drawing.Size(781, 20);
            this.pnAnalyses.TabIndex = 2;
            // 
            // pnlRuleButtons
            // 
            this.pnlRuleButtons.Controls.Add(this.btnExport);
            this.pnlRuleButtons.Controls.Add(this.btnDeleteRule);
            this.pnlRuleButtons.Controls.Add(this.btnEditRule);
            this.pnlRuleButtons.Controls.Add(this.btnRunAllRules);
            this.pnlRuleButtons.Controls.Add(this.button2);
            this.pnlRuleButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRuleButtons.Location = new System.Drawing.Point(371, 0);
            this.pnlRuleButtons.Name = "pnlRuleButtons";
            this.pnlRuleButtons.Size = new System.Drawing.Size(410, 20);
            this.pnlRuleButtons.TabIndex = 5;
            // 
            // btnDeleteRule
            // 
            this.btnDeleteRule.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDeleteRule.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDeleteRule.FlatAppearance.BorderSize = 0;
            this.btnDeleteRule.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnDeleteRule.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDeleteRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRule.Location = new System.Drawing.Point(344, 0);
            this.btnDeleteRule.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteRule.Name = "btnDeleteRule";
            this.btnDeleteRule.Size = new System.Drawing.Size(65, 19);
            this.btnDeleteRule.TabIndex = 5;
            this.btnDeleteRule.Text = "Delete Rule";
            this.btnDeleteRule.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteRule.UseVisualStyleBackColor = false;
            this.btnDeleteRule.Click += new System.EventHandler(this.btnDeleteRule_Click);
            // 
            // btnEditRule
            // 
            this.btnEditRule.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnEditRule.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnEditRule.FlatAppearance.BorderSize = 0;
            this.btnEditRule.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnEditRule.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEditRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRule.Location = new System.Drawing.Point(278, 0);
            this.btnEditRule.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditRule.Name = "btnEditRule";
            this.btnEditRule.Size = new System.Drawing.Size(65, 19);
            this.btnEditRule.TabIndex = 4;
            this.btnEditRule.Text = "Edit Rule";
            this.btnEditRule.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditRule.UseVisualStyleBackColor = false;
            this.btnEditRule.Click += new System.EventHandler(this.btnEditRule_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(212, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 19);
            this.button2.TabIndex = 1;
            this.button2.Text = "Create Rule";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // btnRunAllRules
            // 
            this.btnRunAllRules.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRunAllRules.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnRunAllRules.FlatAppearance.BorderSize = 0;
            this.btnRunAllRules.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnRunAllRules.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnRunAllRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunAllRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunAllRules.Location = new System.Drawing.Point(69, 0);
            this.btnRunAllRules.Margin = new System.Windows.Forms.Padding(0);
            this.btnRunAllRules.Name = "btnRunAllRules";
            this.btnRunAllRules.Size = new System.Drawing.Size(76, 19);
            this.btnRunAllRules.TabIndex = 3;
            this.btnRunAllRules.Text = "Run All";
            this.btnRunAllRules.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRunAllRules.UseVisualStyleBackColor = false;
            this.btnRunAllRules.Click += new System.EventHandler(this.btnRunRules_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(146, 0);
            this.btnExport.Margin = new System.Windows.Forms.Padding(0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(65, 19);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cmbRuleFilter
            // 
            this.cmbRuleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRuleFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.cmbRuleFilter.FormattingEnabled = true;
            this.cmbRuleFilter.Location = new System.Drawing.Point(35, 0);
            this.cmbRuleFilter.Name = "cmbRuleFilter";
            this.cmbRuleFilter.Size = new System.Drawing.Size(157, 20);
            this.cmbRuleFilter.TabIndex = 6;
            this.cmbRuleFilter.SelectedIndexChanged += new System.EventHandler(this.cmbRuleFilter_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.label5.Location = new System.Drawing.Point(5, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Filter";
            // 
            // ucASPerfMonAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitLogList);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucASPerfMonAnalyzer";
            this.Size = new System.Drawing.Size(1000, 545);
            this.SizeChanged += new System.EventHandler(this.ucASPerfMonAnalyzer_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucASPerfMonAnalyzer_Paint);
            this.splitLogList.Panel1.ResumeLayout(false);
            this.splitLogList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLogList)).EndInit();
            this.splitLogList.ResumeLayout(false);
            this.splitLogDetails.Panel1.ResumeLayout(false);
            this.splitLogDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLogDetails)).EndInit();
            this.splitLogDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgdLogList)).EndInit();
            this.splitHideFilesButton.Panel1.ResumeLayout(false);
            this.splitHideFilesButton.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitHideFilesButton)).EndInit();
            this.splitHideFilesButton.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitAnalysis.Panel1.ResumeLayout(false);
            this.splitAnalysis.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitAnalysis)).EndInit();
            this.splitAnalysis.ResumeLayout(false);
            this.splitPerfMonCountersAndChart.Panel1.ResumeLayout(false);
            this.splitPerfMonCountersAndChart.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPerfMonCountersAndChart)).EndInit();
            this.splitPerfMonCountersAndChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgdGrouping)).EndInit();
            this.pnlSeriesDetails.ResumeLayout(false);
            this.pnlSeriesDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPerfMon)).EndInit();
            this.pnServers.ResumeLayout(false);
            this.pnServers.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdRules)).EndInit();
            this.pnAnalyses.ResumeLayout(false);
            this.pnAnalyses.PerformLayout();
            this.pnlRuleButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitLogList;
        private System.Windows.Forms.SplitContainer splitLogDetails;
        private System.Windows.Forms.DataGridView dgdLogList;
        private System.Windows.Forms.RichTextBox rtLogDetails;
        public System.Windows.Forms.Button btnAnalyzeLogs;
        private System.Windows.Forms.SplitContainer splitHideFilesButton;
        private System.Windows.Forms.SplitContainer splitAnalysis;
        private System.Windows.Forms.SplitContainer splitPerfMonCountersAndChart;
        private System.Windows.Forms.DataGridView dgdGrouping;
        private System.Windows.Forms.DataGridViewTextBoxColumn Counter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instance;
        private System.Windows.Forms.Panel pnlSeriesDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAvg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPerfMon;
        private System.Windows.Forms.Panel pnServers;
        private System.Windows.Forms.Label lblCounterGrouping;
        private System.Windows.Forms.Panel pnAnalyses;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHideFilesButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAutoScale;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.DataGridView dgdRules;
        private System.Windows.Forms.Panel pnlRuleButtons;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlCounters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn RuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewImageColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultDescription;
        private System.Windows.Forms.Button btnDeleteRule;
        private System.Windows.Forms.Button btnEditRule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbRuleFilter;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRunAllRules;
    }
}

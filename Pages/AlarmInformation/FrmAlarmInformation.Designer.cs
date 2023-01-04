
namespace SampleProcessingSystem.Pages.Alarm_information
{
    partial class FrmAlarmInformation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlarmInformation));
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiSymbolButton13 = new Sunny.UI.UISymbolButton();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.uiSymbolButton4 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton3 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.startTimes = new Sunny.UI.UIDatetimePicker();
            this.endTimes = new Sunny.UI.UIDatetimePicker();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AbnormalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlarmInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlarmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AbnormalLeavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suggestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiTitlePanel1.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            this.uiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLine2
            // 
            this.uiLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTableLayoutPanel2.SetColumnSpan(this.uiLine2, 2);
            this.uiLine2.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLine2.Location = new System.Drawing.Point(3, 11);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uiLine2.Size = new System.Drawing.Size(187, 14);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 71;
            this.uiLine2.Text = "起始时间";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolButton13
            // 
            this.uiTableLayoutPanel2.SetColumnSpan(this.uiSymbolButton13, 2);
            this.uiSymbolButton13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSymbolButton13.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton13.Location = new System.Drawing.Point(3, 155);
            this.uiSymbolButton13.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uiSymbolButton13.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton13.Name = "uiSymbolButton13";
            this.uiSymbolButton13.Padding = new System.Windows.Forms.Padding(5, 5, 30, 2);
            this.uiSymbolButton13.Radius = 1;
            this.uiSymbolButton13.Size = new System.Drawing.Size(187, 41);
            this.uiSymbolButton13.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton13.Symbol = 61643;
            this.uiSymbolButton13.SymbolSize = 30;
            this.uiSymbolButton13.TabIndex = 60;
            this.uiSymbolButton13.Text = "查询";
            this.uiSymbolButton13.TipsFont = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton13.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton13.Click += new System.EventHandler(this.uiSymbolButton13_Click);
            // 
            // uiLine3
            // 
            this.uiLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTableLayoutPanel2.SetColumnSpan(this.uiLine3, 2);
            this.uiLine3.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiLine3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLine3.Location = new System.Drawing.Point(3, 86);
            this.uiLine3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uiLine3.Size = new System.Drawing.Size(187, 14);
            this.uiLine3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine3.TabIndex = 72;
            this.uiLine3.Text = "截止时间";
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.uiTableLayoutPanel2);
            this.uiTitlePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiTitlePanel1.Location = new System.Drawing.Point(610, 10);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.uiTitlePanel1.Radius = 0;
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(199, 448);
            this.uiTitlePanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTitlePanel1.TabIndex = 9;
            this.uiTitlePanel1.Text = "快捷操作";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.TitleHeight = 25;
            this.uiTitlePanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 2;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.Controls.Add(this.uiSymbolButton4, 0, 8);
            this.uiTableLayoutPanel2.Controls.Add(this.uiSymbolButton3, 0, 7);
            this.uiTableLayoutPanel2.Controls.Add(this.uiSymbolButton2, 0, 6);
            this.uiTableLayoutPanel2.Controls.Add(this.uiSymbolButton1, 0, 5);
            this.uiTableLayoutPanel2.Controls.Add(this.uiLine2, 0, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.uiSymbolButton13, 0, 4);
            this.uiTableLayoutPanel2.Controls.Add(this.uiLine3, 0, 2);
            this.uiTableLayoutPanel2.Controls.Add(this.startTimes, 0, 1);
            this.uiTableLayoutPanel2.Controls.Add(this.endTimes, 0, 3);
            this.uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel2.Location = new System.Drawing.Point(3, 35);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 9;
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.98848F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.64746F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.98848F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.64746F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.54562F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.54562F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.54562F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.54562F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.54562F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.uiTableLayoutPanel2.Size = new System.Drawing.Size(193, 410);
            this.uiTableLayoutPanel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiTableLayoutPanel2.TabIndex = 9;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // uiSymbolButton4
            // 
            this.uiTableLayoutPanel2.SetColumnSpan(this.uiSymbolButton4, 2);
            this.uiSymbolButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSymbolButton4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton4.Location = new System.Drawing.Point(3, 359);
            this.uiSymbolButton4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uiSymbolButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton4.Name = "uiSymbolButton4";
            this.uiSymbolButton4.Padding = new System.Windows.Forms.Padding(5, 5, 30, 2);
            this.uiSymbolButton4.Radius = 1;
            this.uiSymbolButton4.Size = new System.Drawing.Size(187, 46);
            this.uiSymbolButton4.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton4.Symbol = 61579;
            this.uiSymbolButton4.SymbolSize = 30;
            this.uiSymbolButton4.TabIndex = 79;
            this.uiSymbolButton4.Text = "退出";
            this.uiSymbolButton4.TipsFont = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton4.Click += new System.EventHandler(this.uiSymbolButton4_Click);
            // 
            // uiSymbolButton3
            // 
            this.uiTableLayoutPanel2.SetColumnSpan(this.uiSymbolButton3, 2);
            this.uiSymbolButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSymbolButton3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton3.Location = new System.Drawing.Point(3, 308);
            this.uiSymbolButton3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uiSymbolButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton3.Name = "uiSymbolButton3";
            this.uiSymbolButton3.Padding = new System.Windows.Forms.Padding(5, 5, 30, 2);
            this.uiSymbolButton3.Radius = 1;
            this.uiSymbolButton3.Size = new System.Drawing.Size(187, 41);
            this.uiSymbolButton3.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton3.Symbol = 61527;
            this.uiSymbolButton3.SymbolSize = 30;
            this.uiSymbolButton3.TabIndex = 78;
            this.uiSymbolButton3.Text = "删除全部";
            this.uiSymbolButton3.TipsFont = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton3.Click += new System.EventHandler(this.uiSymbolButton3_Click);
            // 
            // uiSymbolButton2
            // 
            this.uiTableLayoutPanel2.SetColumnSpan(this.uiSymbolButton2, 2);
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSymbolButton2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.Location = new System.Drawing.Point(3, 257);
            this.uiSymbolButton2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.Padding = new System.Windows.Forms.Padding(5, 5, 30, 2);
            this.uiSymbolButton2.Radius = 1;
            this.uiSymbolButton2.Size = new System.Drawing.Size(187, 41);
            this.uiSymbolButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton2.Symbol = 61526;
            this.uiSymbolButton2.SymbolSize = 30;
            this.uiSymbolButton2.TabIndex = 77;
            this.uiSymbolButton2.Text = "删除选中";
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton2.Click += new System.EventHandler(this.uiSymbolButton2_Click);
            // 
            // uiSymbolButton1
            // 
            this.uiTableLayoutPanel2.SetColumnSpan(this.uiSymbolButton1, 2);
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(3, 206);
            this.uiSymbolButton1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Padding = new System.Windows.Forms.Padding(5, 5, 30, 2);
            this.uiSymbolButton1.Radius = 1;
            this.uiSymbolButton1.Size = new System.Drawing.Size(187, 41);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton1.Symbol = 61553;
            this.uiSymbolButton1.SymbolSize = 30;
            this.uiSymbolButton1.TabIndex = 76;
            this.uiSymbolButton1.Text = "今日报警";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // startTimes
            // 
            this.uiTableLayoutPanel2.SetColumnSpan(this.startTimes, 2);
            this.startTimes.FillColor = System.Drawing.Color.White;
            this.startTimes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startTimes.Location = new System.Drawing.Point(4, 33);
            this.startTimes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startTimes.MaxLength = 19;
            this.startTimes.MinimumSize = new System.Drawing.Size(63, 0);
            this.startTimes.Name = "startTimes";
            this.startTimes.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.startTimes.Size = new System.Drawing.Size(185, 29);
            this.startTimes.Style = Sunny.UI.UIStyle.Custom;
            this.startTimes.SymbolDropDown = 61555;
            this.startTimes.SymbolNormal = 61555;
            this.startTimes.TabIndex = 80;
            this.startTimes.Text = "2022-08-03 09:30:13";
            this.startTimes.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.startTimes.Value = new System.DateTime(2022, 8, 3, 9, 30, 13, 655);
            this.startTimes.Watermark = "";
            this.startTimes.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // endTimes
            // 
            this.uiTableLayoutPanel2.SetColumnSpan(this.endTimes, 2);
            this.endTimes.FillColor = System.Drawing.Color.White;
            this.endTimes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.endTimes.Location = new System.Drawing.Point(4, 108);
            this.endTimes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.endTimes.MaxLength = 19;
            this.endTimes.MinimumSize = new System.Drawing.Size(63, 0);
            this.endTimes.Name = "endTimes";
            this.endTimes.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.endTimes.Size = new System.Drawing.Size(185, 29);
            this.endTimes.Style = Sunny.UI.UIStyle.Custom;
            this.endTimes.SymbolDropDown = 61555;
            this.endTimes.SymbolNormal = 61555;
            this.endTimes.TabIndex = 81;
            this.endTimes.Text = "2022-08-03 09:31:15";
            this.endTimes.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.endTimes.Value = new System.DateTime(2022, 8, 3, 9, 31, 15, 636);
            this.endTimes.Watermark = "";
            this.endTimes.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.38272F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.61728F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiDataGridView1, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiTitlePanel1, 1, 0);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(3, 30);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 1;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 531F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(814, 468);
            this.uiTableLayoutPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTableLayoutPanel1.TabIndex = 1;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiDataGridView1
            // 
            this.uiDataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView1.ColumnHeadersHeight = 25;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AbnormalCode,
            this.AlarmInfo,
            this.AlarmTime,
            this.AbnormalLeavel,
            this.Suggestion});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(5, 10);
            this.uiDataGridView1.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.uiDataGridView1.RowHeadersWidth = 50;
            this.uiDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.uiDataGridView1.RowTemplate.Height = 30;
            this.uiDataGridView1.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridView1.Size = new System.Drawing.Size(597, 448);
            this.uiDataGridView1.Style = Sunny.UI.UIStyle.Custom;
            this.uiDataGridView1.TabIndex = 7;
            this.uiDataGridView1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiDataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.uiDataGridView1_RowPostPaint);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // AbnormalCode
            // 
            this.AbnormalCode.DataPropertyName = "AbnormalCode";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AbnormalCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.AbnormalCode.FillWeight = 114.4385F;
            this.AbnormalCode.HeaderText = "异常码";
            this.AbnormalCode.MinimumWidth = 6;
            this.AbnormalCode.Name = "AbnormalCode";
            this.AbnormalCode.ReadOnly = true;
            this.AbnormalCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AbnormalCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AlarmInfo
            // 
            this.AlarmInfo.DataPropertyName = "AlarmInfo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AlarmInfo.DefaultCellStyle = dataGridViewCellStyle4;
            this.AlarmInfo.FillWeight = 85.5615F;
            this.AlarmInfo.HeaderText = "异常信息";
            this.AlarmInfo.MinimumWidth = 6;
            this.AlarmInfo.Name = "AlarmInfo";
            this.AlarmInfo.ReadOnly = true;
            this.AlarmInfo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AlarmInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AlarmTime
            // 
            this.AlarmTime.DataPropertyName = "AlarmTime";
            this.AlarmTime.HeaderText = "报警时间";
            this.AlarmTime.MinimumWidth = 6;
            this.AlarmTime.Name = "AlarmTime";
            // 
            // AbnormalLeavel
            // 
            this.AbnormalLeavel.DataPropertyName = "AbnormalLeavel";
            this.AbnormalLeavel.HeaderText = "AbnormalLeavel";
            this.AbnormalLeavel.MinimumWidth = 6;
            this.AbnormalLeavel.Name = "AbnormalLeavel";
            this.AbnormalLeavel.ReadOnly = true;
            this.AbnormalLeavel.Visible = false;
            // 
            // Suggestion
            // 
            this.Suggestion.DataPropertyName = "Suggestion";
            this.Suggestion.HeaderText = "Suggestion";
            this.Suggestion.MinimumWidth = 6;
            this.Suggestion.Name = "Suggestion";
            this.Suggestion.Visible = false;
            // 
            // FrmAlarmInformation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(820, 501);
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAlarmInformation";
            this.Padding = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.ShowIcon = false;
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = resources.GetString("$this.Text");
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10F);
            this.TitleHeight = 30;
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 1420, 806);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UISymbolButton uiSymbolButton13;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UISymbolButton uiSymbolButton3;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton uiSymbolButton4;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AbnormalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlarmInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlarmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AbnormalLeavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suggestion;
        private Sunny.UI.UIDatetimePicker startTimes;
        private Sunny.UI.UIDatetimePicker endTimes;
    }
}
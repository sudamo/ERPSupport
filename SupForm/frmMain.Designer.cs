namespace ERPSupport.SupForm
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.sc1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cbxCondition = new System.Windows.Forms.ComboBox();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.btnUnLock = new System.Windows.Forms.Button();
            this.cbxLogic = new System.Windows.Forms.ComboBox();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_New = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.tssFile1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFile_L = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_Config = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_Parameter = new System.Windows.Forms.ToolStripMenuItem();
            this.tssTool1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTool_Occupy = new System.Windows.Forms.ToolStripMenuItem();
            this.smiTool_Occupy_PickMtl = new System.Windows.Forms.ToolStripMenuItem();
            this.smiTool_Occupy_Trans = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_Occupy_LockStock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_Occupy_OrderRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tssTool_Occupy_1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTool_Occupy_LockPickMtl = new System.Windows.Forms.ToolStripMenuItem();
            this.tssTool2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTool_Timer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp_Regedit = new System.Windows.Forms.ToolStripMenuItem();
            this.tssHelp1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiHelp_View = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp_Version = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp_About = new System.Windows.Forms.ToolStripMenuItem();
            this.tSumSecond = new System.Windows.Forms.Timer(this.components);
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).BeginInit();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // sc1
            // 
            this.sc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc1.IsSplitterFixed = true;
            this.sc1.Location = new System.Drawing.Point(0, 24);
            this.sc1.Name = "sc1";
            // 
            // sc1.Panel1
            // 
            this.sc1.Panel1.AutoScroll = true;
            this.sc1.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.sc1.Panel1MinSize = 160;
            // 
            // sc1.Panel2
            // 
            this.sc1.Panel2.Controls.Add(this.panel1);
            this.sc1.Size = new System.Drawing.Size(1047, 711);
            this.sc1.SplitterDistance = 160;
            this.sc1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShowAll);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.cbxCondition);
            this.panel1.Controls.Add(this.txtCondition);
            this.panel1.Controls.Add(this.btnUnLock);
            this.panel1.Controls.Add(this.cbxLogic);
            this.panel1.Controls.Add(this.btnCommit);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dgv1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 711);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(594, 5);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(80, 20);
            this.btnShowAll.TabIndex = 19;
            this.btnShowAll.Text = "重置筛选";
            this.tt.SetToolTip(this.btnShowAll, "清除所有列筛选状态。");
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(248, 5);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(120, 21);
            this.dtpDate.TabIndex = 4;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(11, 5);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(37, 20);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "过滤";
            this.tt.SetToolTip(this.btnFilter, "根据需求构造更复杂的过滤条件");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Visible = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(380, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(60, 20);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "检查";
            this.tt.SetToolTip(this.btnCheck, "检查物料是否指定了调出仓库");
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(509, 5);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(80, 20);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "勾选";
            this.tt.SetToolTip(this.btnSelect, "勾取选定的数据行");
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cbxCondition
            // 
            this.cbxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCondition.FormattingEnabled = true;
            this.cbxCondition.Location = new System.Drawing.Point(52, 6);
            this.cbxCondition.Margin = new System.Windows.Forms.Padding(2);
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(110, 20);
            this.cbxCondition.TabIndex = 2;
            this.cbxCondition.SelectedIndexChanged += new System.EventHandler(this.cbxCondition_SelectedIndexChanged);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(248, 5);
            this.txtCondition.Margin = new System.Windows.Forms.Padding(2);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(120, 21);
            this.txtCondition.TabIndex = 1;
            // 
            // btnUnLock
            // 
            this.btnUnLock.Location = new System.Drawing.Point(763, 5);
            this.btnUnLock.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnLock.Name = "btnUnLock";
            this.btnUnLock.Size = new System.Drawing.Size(60, 20);
            this.btnUnLock.TabIndex = 10;
            this.btnUnLock.Text = "解锁";
            this.tt.SetToolTip(this.btnUnLock, "销售订单解除锁库");
            this.btnUnLock.UseVisualStyleBackColor = true;
            this.btnUnLock.Click += new System.EventHandler(this.btnUnLock_Click);
            // 
            // cbxLogic
            // 
            this.cbxLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLogic.FormattingEnabled = true;
            this.cbxLogic.Location = new System.Drawing.Point(168, 6);
            this.cbxLogic.Margin = new System.Windows.Forms.Padding(2);
            this.cbxLogic.Name = "cbxLogic";
            this.cbxLogic.Size = new System.Drawing.Size(76, 20);
            this.cbxLogic.TabIndex = 3;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(679, 5);
            this.btnCommit.Margin = new System.Windows.Forms.Padding(2);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(80, 20);
            this.btnCommit.TabIndex = 10;
            this.btnCommit.Text = "提交";
            this.tt.SetToolTip(this.btnCommit, "执行操作");
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(445, 5);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 20);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查找";
            this.tt.SetToolTip(this.btnSearch, "查询数据");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Turquoise;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(2, 30);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(879, 679);
            this.dgv1.TabIndex = 18;
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.SystemColors.Menu;
            this.msMain.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiTool,
            this.tsmiHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1047, 24);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "主菜单";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile_New,
            this.tsmiFile_Open,
            this.tssFile1,
            this.tsmiFile_L,
            this.tsmiFile_Exit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(68, 20);
            this.tsmiFile.Text = "文件(&F)";
            // 
            // tsmiFile_New
            // 
            this.tsmiFile_New.Enabled = false;
            this.tsmiFile_New.Name = "tsmiFile_New";
            this.tsmiFile_New.Size = new System.Drawing.Size(179, 22);
            this.tsmiFile_New.Text = "新建模板(&N)";
            // 
            // tsmiFile_Open
            // 
            this.tsmiFile_Open.Enabled = false;
            this.tsmiFile_Open.Name = "tsmiFile_Open";
            this.tsmiFile_Open.Size = new System.Drawing.Size(179, 22);
            this.tsmiFile_Open.Text = "打开模板(&O)";
            // 
            // tssFile1
            // 
            this.tssFile1.Name = "tssFile1";
            this.tssFile1.Size = new System.Drawing.Size(176, 6);
            // 
            // tsmiFile_L
            // 
            this.tsmiFile_L.Name = "tsmiFile_L";
            this.tsmiFile_L.Size = new System.Drawing.Size(179, 22);
            this.tsmiFile_L.Text = "注销(&L)";
            this.tsmiFile_L.Click += new System.EventHandler(this.tsmiFile_L_Click);
            // 
            // tsmiFile_Exit
            // 
            this.tsmiFile_Exit.Name = "tsmiFile_Exit";
            this.tsmiFile_Exit.Size = new System.Drawing.Size(179, 22);
            this.tsmiFile_Exit.Text = "退出(&E)  ALT+F4";
            this.tsmiFile_Exit.Click += new System.EventHandler(this.tsmiFile_Exit_Click);
            // 
            // tsmiTool
            // 
            this.tsmiTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTool_Config,
            this.tsmiTool_Parameter,
            this.tssTool1,
            this.tsmiTool_Occupy,
            this.tssTool2,
            this.tsmiTool_Timer});
            this.tsmiTool.Name = "tsmiTool";
            this.tsmiTool.Size = new System.Drawing.Size(68, 20);
            this.tsmiTool.Text = "工具(&T)";
            // 
            // tsmiTool_Config
            // 
            this.tsmiTool_Config.Name = "tsmiTool_Config";
            this.tsmiTool_Config.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Config.Text = "系统配置(&C)";
            this.tsmiTool_Config.Click += new System.EventHandler(this.tsmiTool_Config_Click);
            // 
            // tsmiTool_Parameter
            // 
            this.tsmiTool_Parameter.Name = "tsmiTool_Parameter";
            this.tsmiTool_Parameter.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Parameter.Text = "参数(&P)";
            this.tsmiTool_Parameter.Click += new System.EventHandler(this.tsmiTool_Parameter_Click);
            // 
            // tssTool1
            // 
            this.tssTool1.Name = "tssTool1";
            this.tssTool1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiTool_Occupy
            // 
            this.tsmiTool_Occupy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiTool_Occupy_PickMtl,
            this.smiTool_Occupy_Trans,
            this.tsmiTool_Occupy_LockStock,
            this.tsmiTool_Occupy_OrderRun,
            this.tssTool_Occupy_1,
            this.tsmiTool_Occupy_LockPickMtl});
            this.tsmiTool_Occupy.Name = "tsmiTool_Occupy";
            this.tsmiTool_Occupy.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Occupy.Text = "占用解除(&O)";
            // 
            // smiTool_Occupy_PickMtl
            // 
            this.smiTool_Occupy_PickMtl.Name = "smiTool_Occupy_PickMtl";
            this.smiTool_Occupy_PickMtl.Size = new System.Drawing.Size(152, 22);
            this.smiTool_Occupy_PickMtl.Text = "倒冲领料";
            this.smiTool_Occupy_PickMtl.Click += new System.EventHandler(this.smiTool_Occupy_PickMtl_Click);
            // 
            // smiTool_Occupy_Trans
            // 
            this.smiTool_Occupy_Trans.Name = "smiTool_Occupy_Trans";
            this.smiTool_Occupy_Trans.Size = new System.Drawing.Size(152, 22);
            this.smiTool_Occupy_Trans.Text = "调拨";
            this.smiTool_Occupy_Trans.Click += new System.EventHandler(this.smiTool_Occupy_Trans_Click);
            // 
            // tsmiTool_Occupy_LockStock
            // 
            this.tsmiTool_Occupy_LockStock.Name = "tsmiTool_Occupy_LockStock";
            this.tsmiTool_Occupy_LockStock.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Occupy_LockStock.Text = "锁库";
            this.tsmiTool_Occupy_LockStock.Click += new System.EventHandler(this.tsmiTool_Occupy_LockStock_Click);
            // 
            // tsmiTool_Occupy_OrderRun
            // 
            this.tsmiTool_Occupy_OrderRun.Name = "tsmiTool_Occupy_OrderRun";
            this.tsmiTool_Occupy_OrderRun.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Occupy_OrderRun.Text = "订单运算";
            this.tsmiTool_Occupy_OrderRun.Click += new System.EventHandler(this.tsmiTool_Occupy_OrderRun_Click);
            // 
            // tssTool_Occupy_1
            // 
            this.tssTool_Occupy_1.Name = "tssTool_Occupy_1";
            this.tssTool_Occupy_1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiTool_Occupy_LockPickMtl
            // 
            this.tsmiTool_Occupy_LockPickMtl.Name = "tsmiTool_Occupy_LockPickMtl";
            this.tsmiTool_Occupy_LockPickMtl.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Occupy_LockPickMtl.Text = "自动领料";
            this.tsmiTool_Occupy_LockPickMtl.Click += new System.EventHandler(this.tsmiTool_Occupy_LockPickMtl_Click);
            // 
            // tssTool2
            // 
            this.tssTool2.Name = "tssTool2";
            this.tssTool2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiTool_Timer
            // 
            this.tsmiTool_Timer.Name = "tsmiTool_Timer";
            this.tsmiTool_Timer.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Timer.Text = "定时器(&T)";
            this.tsmiTool_Timer.Click += new System.EventHandler(this.tsmiTool_Timer_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelp_Regedit,
            this.tssHelp1,
            this.tsmiHelp_View,
            this.tsmiHelp_Version,
            this.tsmiHelp_About});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(68, 20);
            this.tsmiHelp.Text = "帮助(&H)";
            // 
            // tsmiHelp_Regedit
            // 
            this.tsmiHelp_Regedit.Name = "tsmiHelp_Regedit";
            this.tsmiHelp_Regedit.Size = new System.Drawing.Size(179, 22);
            this.tsmiHelp_Regedit.Text = "注册(&R)";
            this.tsmiHelp_Regedit.Click += new System.EventHandler(this.tsmiHelp_Regedit_Click);
            // 
            // tssHelp1
            // 
            this.tssHelp1.Name = "tssHelp1";
            this.tssHelp1.Size = new System.Drawing.Size(176, 6);
            // 
            // tsmiHelp_View
            // 
            this.tsmiHelp_View.Name = "tsmiHelp_View";
            this.tsmiHelp_View.Size = new System.Drawing.Size(179, 22);
            this.tsmiHelp_View.Text = "查看帮助(&L)";
            this.tsmiHelp_View.Click += new System.EventHandler(this.tsmiHelp_View_Click);
            // 
            // tsmiHelp_Version
            // 
            this.tsmiHelp_Version.Name = "tsmiHelp_Version";
            this.tsmiHelp_Version.Size = new System.Drawing.Size(179, 22);
            this.tsmiHelp_Version.Text = "版本号(&V)";
            this.tsmiHelp_Version.Click += new System.EventHandler(this.tsmiHelp_Version_Click);
            // 
            // tsmiHelp_About
            // 
            this.tsmiHelp_About.Name = "tsmiHelp_About";
            this.tsmiHelp_About.Size = new System.Drawing.Size(179, 22);
            this.tsmiHelp_About.Text = "关于辅助系统(&A)";
            this.tsmiHelp_About.Click += new System.EventHandler(this.tsmiHelp_About_Click);
            // 
            // tSumSecond
            // 
            this.tSumSecond.Interval = 1000;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 735);
            this.Controls.Add(this.sc1);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.MinimumSize = new System.Drawing.Size(1023, 766);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP辅助系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.sc1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).EndInit();
            this.sc1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer sc1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cbxCondition;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.ComboBox cbxLogic;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUnLock;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Config;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp_View;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp_Version;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp_About;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_L;
        private System.Windows.Forms.ToolStripSeparator tssHelp1;
        private System.Windows.Forms.ToolStripSeparator tssFile1;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Timer;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_New;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_Open;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Occupy;
        private System.Windows.Forms.ToolStripSeparator tssTool1;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Parameter;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Occupy_LockStock;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Occupy_OrderRun;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Timer tSumSecond;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp_Regedit;
        private System.Windows.Forms.ToolStripSeparator tssTool2;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Occupy_LockPickMtl;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.ToolStripMenuItem smiTool_Occupy_PickMtl;
        private System.Windows.Forms.ToolStripMenuItem smiTool_Occupy_Trans;
        private System.Windows.Forms.ToolStripSeparator tssTool_Occupy_1;
    }
}
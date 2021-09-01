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
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnB_cbxPageSize = new System.Windows.Forms.ToolStripComboBox();
            this.bnB_lblPageSize = new System.Windows.Forms.ToolStripLabel();
            this.bnB_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnB_lblThe = new System.Windows.Forms.ToolStripLabel();
            this.bnB_txtCurrentPage = new System.Windows.Forms.ToolStripTextBox();
            this.bnB_lblSeparate = new System.Windows.Forms.ToolStripLabel();
            this.bnB_lblPageCount = new System.Windows.Forms.ToolStripLabel();
            this.bnB_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnB_lblRecordCount = new System.Windows.Forms.ToolStripLabel();
            this.bnB_tss3 = new System.Windows.Forms.ToolStripSeparator();
            this.bnB_tss4 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_lblDate = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_lblTo = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_New = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFile_L = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_Config = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_Parameter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTool_Occupy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_Occupy_PickMtl = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_Occupy_Trans = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_Occupy_LockStock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_Occupy_OrderRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tssTool_Occupy_1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTool_Occupy_LockPickMtl = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTool_Timer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_Business = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_tss0 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPro_INOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPro_Dir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPro_K3Data = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_WMSData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp_Regedit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiHelp_View = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp_Version = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp_About = new System.Windows.Forms.ToolStripMenuItem();
            this.tSumSecond = new System.Windows.Forms.Timer(this.components);
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.bnB_btnFirst = new System.Windows.Forms.ToolStripButton();
            this.bnB_btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.bnB_btnGoto = new System.Windows.Forms.ToolStripButton();
            this.bnB_btnNext = new System.Windows.Forms.ToolStripButton();
            this.bnB_btnLast = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnFilter = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnCheck = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnSearch = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnShowAll = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnCommit = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnUnLock = new System.Windows.Forms.ToolStripButton();
            this.bs1 = new System.Windows.Forms.BindingSource(this.components);
            this.tsmiPro_Business_DLOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_Business_SynOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_Business_DLROrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_Business_SynROrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_Business_ImportDelivery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_Business_CancleAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_Business_CancleDealt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_Business_LockSynOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPro_Business_Report = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).BeginInit();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs1)).BeginInit();
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
            this.panel1.Controls.Add(this.bnBottom);
            this.panel1.Controls.Add(this.bnTop);
            this.panel1.Controls.Add(this.dgv1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 711);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // bnBottom
            // 
            this.bnBottom.AddNewItem = null;
            this.bnBottom.CountItem = null;
            this.bnBottom.CountItemFormat = " @总页数";
            this.bnBottom.DeleteItem = null;
            this.bnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnB_cbxPageSize,
            this.bnB_lblPageSize,
            this.bnB_btnFirst,
            this.bnB_btnPrevious,
            this.bnB_tss1,
            this.bnB_btnGoto,
            this.bnB_lblThe,
            this.bnB_txtCurrentPage,
            this.bnB_lblSeparate,
            this.bnB_lblPageCount,
            this.bnB_tss2,
            this.bnB_lblRecordCount,
            this.bnB_tss3,
            this.bnB_btnNext,
            this.bnB_btnLast,
            this.bnB_tss4});
            this.bnBottom.Location = new System.Drawing.Point(0, 684);
            this.bnBottom.MoveFirstItem = null;
            this.bnBottom.MoveLastItem = null;
            this.bnBottom.MoveNextItem = null;
            this.bnBottom.MovePreviousItem = null;
            this.bnBottom.Name = "bnBottom";
            this.bnBottom.PositionItem = null;
            this.bnBottom.Size = new System.Drawing.Size(883, 27);
            this.bnBottom.TabIndex = 21;
            this.bnBottom.Text = "bnBottom";
            this.bnBottom.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bnBottom_ItemClicked);
            // 
            // bnB_cbxPageSize
            // 
            this.bnB_cbxPageSize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnB_cbxPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnB_cbxPageSize.Name = "bnB_cbxPageSize";
            this.bnB_cbxPageSize.Size = new System.Drawing.Size(80, 27);
            this.bnB_cbxPageSize.SelectedIndexChanged += new System.EventHandler(this.bnB_cbxPageSize_SelectedIndexChanged);
            // 
            // bnB_lblPageSize
            // 
            this.bnB_lblPageSize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnB_lblPageSize.Name = "bnB_lblPageSize";
            this.bnB_lblPageSize.Size = new System.Drawing.Size(56, 24);
            this.bnB_lblPageSize.Text = "每页显示";
            this.bnB_lblPageSize.ToolTipText = "每页显示行数";
            // 
            // bnB_tss1
            // 
            this.bnB_tss1.Name = "bnB_tss1";
            this.bnB_tss1.Size = new System.Drawing.Size(6, 27);
            // 
            // bnB_lblThe
            // 
            this.bnB_lblThe.Name = "bnB_lblThe";
            this.bnB_lblThe.Size = new System.Drawing.Size(20, 24);
            this.bnB_lblThe.Text = "第";
            // 
            // bnB_txtCurrentPage
            // 
            this.bnB_txtCurrentPage.Name = "bnB_txtCurrentPage";
            this.bnB_txtCurrentPage.Size = new System.Drawing.Size(40, 27);
            // 
            // bnB_lblSeparate
            // 
            this.bnB_lblSeparate.Name = "bnB_lblSeparate";
            this.bnB_lblSeparate.Size = new System.Drawing.Size(45, 24);
            this.bnB_lblSeparate.Text = "页 / 共";
            // 
            // bnB_lblPageCount
            // 
            this.bnB_lblPageCount.Name = "bnB_lblPageCount";
            this.bnB_lblPageCount.Size = new System.Drawing.Size(20, 24);
            this.bnB_lblPageCount.Text = "页";
            // 
            // bnB_tss2
            // 
            this.bnB_tss2.Name = "bnB_tss2";
            this.bnB_tss2.Size = new System.Drawing.Size(6, 27);
            // 
            // bnB_lblRecordCount
            // 
            this.bnB_lblRecordCount.Name = "bnB_lblRecordCount";
            this.bnB_lblRecordCount.Size = new System.Drawing.Size(20, 24);
            this.bnB_lblRecordCount.Text = "行";
            // 
            // bnB_tss3
            // 
            this.bnB_tss3.Name = "bnB_tss3";
            this.bnB_tss3.Size = new System.Drawing.Size(6, 27);
            // 
            // bnB_tss4
            // 
            this.bnB_tss4.Name = "bnB_tss4";
            this.bnB_tss4.Size = new System.Drawing.Size(6, 27);
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_lblDate,
            this.bnTop_lblTo,
            this.bnTop_btnFilter,
            this.bnTop_tss1,
            this.bnTop_btnCheck,
            this.bnTop_btnSearch,
            this.bnTop_btnShowAll,
            this.bnTop_btnCommit,
            this.bnTop_btnUnLock});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(883, 27);
            this.bnTop.TabIndex = 0;
            this.bnTop.Text = "bnTop";
            this.bnTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bnTop_ItemClicked);
            // 
            // bnTop_lblDate
            // 
            this.bnTop_lblDate.Name = "bnTop_lblDate";
            this.bnTop_lblDate.Size = new System.Drawing.Size(92, 24);
            this.bnTop_lblDate.Text = "计划开工日期：";
            // 
            // bnTop_lblTo
            // 
            this.bnTop_lblTo.Name = "bnTop_lblTo";
            this.bnTop_lblTo.Size = new System.Drawing.Size(13, 24);
            this.bnTop_lblTo.Text = "-";
            // 
            // bnTop_tss1
            // 
            this.bnTop_tss1.Name = "bnTop_tss1";
            this.bnTop_tss1.Size = new System.Drawing.Size(6, 27);
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
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv1.Location = new System.Drawing.Point(2, 29);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(880, 656);
            this.dgv1.TabIndex = 1;
            this.dgv1.RowHeadersWidthChanged += new System.EventHandler(this.dgv1_RowHeadersWidthChanged);
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.SystemColors.Menu;
            this.msMain.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiTool,
            this.tsmiPro,
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
            this.tsmiFile_tss1,
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
            // tsmiFile_tss1
            // 
            this.tsmiFile_tss1.Name = "tsmiFile_tss1";
            this.tsmiFile_tss1.Size = new System.Drawing.Size(176, 6);
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
            this.tsmiTool_tss1,
            this.tsmiTool_Occupy,
            this.tsmiTool_tss2,
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
            // tsmiTool_tss1
            // 
            this.tsmiTool_tss1.Name = "tsmiTool_tss1";
            this.tsmiTool_tss1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiTool_Occupy
            // 
            this.tsmiTool_Occupy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTool_Occupy_PickMtl,
            this.tsmiTool_Occupy_Trans,
            this.tsmiTool_Occupy_LockStock,
            this.tsmiTool_Occupy_OrderRun,
            this.tssTool_Occupy_1,
            this.tsmiTool_Occupy_LockPickMtl});
            this.tsmiTool_Occupy.Name = "tsmiTool_Occupy";
            this.tsmiTool_Occupy.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Occupy.Text = "占用解除(&O)";
            // 
            // tsmiTool_Occupy_PickMtl
            // 
            this.tsmiTool_Occupy_PickMtl.Name = "tsmiTool_Occupy_PickMtl";
            this.tsmiTool_Occupy_PickMtl.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Occupy_PickMtl.Text = "倒冲领料";
            this.tsmiTool_Occupy_PickMtl.Click += new System.EventHandler(this.smiTool_Occupy_PickMtl_Click);
            // 
            // tsmiTool_Occupy_Trans
            // 
            this.tsmiTool_Occupy_Trans.Name = "tsmiTool_Occupy_Trans";
            this.tsmiTool_Occupy_Trans.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Occupy_Trans.Text = "调拨";
            this.tsmiTool_Occupy_Trans.Click += new System.EventHandler(this.smiTool_Occupy_Trans_Click);
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
            // tsmiTool_tss2
            // 
            this.tsmiTool_tss2.Name = "tsmiTool_tss2";
            this.tsmiTool_tss2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmiTool_Timer
            // 
            this.tsmiTool_Timer.Name = "tsmiTool_Timer";
            this.tsmiTool_Timer.Size = new System.Drawing.Size(152, 22);
            this.tsmiTool_Timer.Text = "定时器(&T)";
            this.tsmiTool_Timer.Click += new System.EventHandler(this.tsmiTool_Timer_Click);
            // 
            // tsmiPro
            // 
            this.tsmiPro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPro_Business,
            this.tsmiPro_tss0,
            this.tsmiPro_INOrder,
            this.tsmiPro_tss1,
            this.tsmiPro_Dir,
            this.tsmiPro_tss2,
            this.tsmiPro_K3Data,
            this.tsmiPro_WMSData});
            this.tsmiPro.Name = "tsmiPro";
            this.tsmiPro.Size = new System.Drawing.Size(68, 20);
            this.tsmiPro.Text = "项目(&P)";
            // 
            // tsmiPro_Business
            // 
            this.tsmiPro_Business.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPro_Business_Report,
            this.tsmiPro_Business_DLOrder,
            this.tsmiPro_Business_SynOrder,
            this.tsmiPro_Business_DLROrder,
            this.tsmiPro_Business_SynROrder,
            this.tsmiPro_Business_ImportDelivery,
            this.tsmiPro_Business_CancleAudit,
            this.tsmiPro_Business_CancleDealt,
            this.tsmiPro_Business_LockSynOrder});
            this.tsmiPro_Business.Name = "tsmiPro_Business";
            this.tsmiPro_Business.Size = new System.Drawing.Size(179, 22);
            this.tsmiPro_Business.Text = "电商(&B)";
            // 
            // tsmiPro_tss0
            // 
            this.tsmiPro_tss0.Name = "tsmiPro_tss0";
            this.tsmiPro_tss0.Size = new System.Drawing.Size(176, 6);
            // 
            // tsmiPro_INOrder
            // 
            this.tsmiPro_INOrder.Name = "tsmiPro_INOrder";
            this.tsmiPro_INOrder.Size = new System.Drawing.Size(179, 22);
            this.tsmiPro_INOrder.Text = "网上订单系统(&N)";
            this.tsmiPro_INOrder.Click += new System.EventHandler(this.tsmiPro_INOrder_Click);
            // 
            // tsmiPro_tss1
            // 
            this.tsmiPro_tss1.Name = "tsmiPro_tss1";
            this.tsmiPro_tss1.Size = new System.Drawing.Size(176, 6);
            // 
            // tsmiPro_Dir
            // 
            this.tsmiPro_Dir.Name = "tsmiPro_Dir";
            this.tsmiPro_Dir.Size = new System.Drawing.Size(179, 22);
            this.tsmiPro_Dir.Text = "调拨单设置(&D)";
            this.tsmiPro_Dir.Click += new System.EventHandler(this.tsmiPro_Dir_Click);
            // 
            // tsmiPro_tss2
            // 
            this.tsmiPro_tss2.Name = "tsmiPro_tss2";
            this.tsmiPro_tss2.Size = new System.Drawing.Size(176, 6);
            // 
            // tsmiPro_K3Data
            // 
            this.tsmiPro_K3Data.Name = "tsmiPro_K3Data";
            this.tsmiPro_K3Data.Size = new System.Drawing.Size(179, 22);
            this.tsmiPro_K3Data.Text = "K3数据同步(&K)";
            this.tsmiPro_K3Data.Click += new System.EventHandler(this.tsmiPro_K3Data_Click);
            // 
            // tsmiPro_WMSData
            // 
            this.tsmiPro_WMSData.Name = "tsmiPro_WMSData";
            this.tsmiPro_WMSData.Size = new System.Drawing.Size(179, 22);
            this.tsmiPro_WMSData.Text = "WMS数据同步(&W)";
            this.tsmiPro_WMSData.ToolTipText = "同步K3数据到WMS系统";
            this.tsmiPro_WMSData.Click += new System.EventHandler(this.tsmiPro_WMSData_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelp_Regedit,
            this.tsmiHelp_tss1,
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
            // tsmiHelp_tss1
            // 
            this.tsmiHelp_tss1.Name = "tsmiHelp_tss1";
            this.tsmiHelp_tss1.Size = new System.Drawing.Size(176, 6);
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
            // bnB_btnFirst
            // 
            this.bnB_btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnB_btnFirst.Image = global::ERPSupport.SupForm.Properties.Resources.resultset_first;
            this.bnB_btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnB_btnFirst.Name = "bnB_btnFirst";
            this.bnB_btnFirst.Size = new System.Drawing.Size(24, 24);
            this.bnB_btnFirst.Tag = "1";
            // 
            // bnB_btnPrevious
            // 
            this.bnB_btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnB_btnPrevious.Image = global::ERPSupport.SupForm.Properties.Resources.resultset_previous;
            this.bnB_btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnB_btnPrevious.Name = "bnB_btnPrevious";
            this.bnB_btnPrevious.Size = new System.Drawing.Size(24, 24);
            this.bnB_btnPrevious.Tag = "2";
            // 
            // bnB_btnGoto
            // 
            this.bnB_btnGoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnB_btnGoto.Image = global::ERPSupport.SupForm.Properties.Resources.control_repeat_blue;
            this.bnB_btnGoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnB_btnGoto.Name = "bnB_btnGoto";
            this.bnB_btnGoto.Size = new System.Drawing.Size(24, 24);
            this.bnB_btnGoto.Tag = "3";
            this.bnB_btnGoto.Text = "跳到";
            this.bnB_btnGoto.ToolTipText = "跳到指定页";
            // 
            // bnB_btnNext
            // 
            this.bnB_btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnB_btnNext.Image = global::ERPSupport.SupForm.Properties.Resources.resultset_next;
            this.bnB_btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnB_btnNext.Name = "bnB_btnNext";
            this.bnB_btnNext.Size = new System.Drawing.Size(24, 24);
            this.bnB_btnNext.Tag = "4";
            // 
            // bnB_btnLast
            // 
            this.bnB_btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnB_btnLast.Image = global::ERPSupport.SupForm.Properties.Resources.resultset_last;
            this.bnB_btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnB_btnLast.Name = "bnB_btnLast";
            this.bnB_btnLast.Size = new System.Drawing.Size(24, 24);
            this.bnB_btnLast.Tag = "5";
            // 
            // bnTop_btnFilter
            // 
            this.bnTop_btnFilter.Image = global::ERPSupport.SupForm.Properties.Resources.add;
            this.bnTop_btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnFilter.Name = "bnTop_btnFilter";
            this.bnTop_btnFilter.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnFilter.Tag = "1";
            this.bnTop_btnFilter.Text = "筛选";
            this.bnTop_btnFilter.ToolTipText = "设置过滤条件";
            // 
            // bnTop_btnCheck
            // 
            this.bnTop_btnCheck.Image = global::ERPSupport.SupForm.Properties.Resources.zootool;
            this.bnTop_btnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnCheck.Name = "bnTop_btnCheck";
            this.bnTop_btnCheck.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnCheck.Tag = "2";
            this.bnTop_btnCheck.Text = "检查";
            this.bnTop_btnCheck.ToolTipText = "检查物料是否已经设置默认调出仓库";
            // 
            // bnTop_btnSearch
            // 
            this.bnTop_btnSearch.Image = global::ERPSupport.SupForm.Properties.Resources.zoom;
            this.bnTop_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnSearch.Name = "bnTop_btnSearch";
            this.bnTop_btnSearch.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnSearch.Tag = "3";
            this.bnTop_btnSearch.Text = "查询";
            this.bnTop_btnSearch.ToolTipText = "查询数据";
            // 
            // bnTop_btnShowAll
            // 
            this.bnTop_btnShowAll.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_refresh;
            this.bnTop_btnShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnShowAll.Name = "bnTop_btnShowAll";
            this.bnTop_btnShowAll.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnShowAll.Tag = "4";
            this.bnTop_btnShowAll.Text = "重置";
            this.bnTop_btnShowAll.ToolTipText = "清空列筛选";
            // 
            // bnTop_btnCommit
            // 
            this.bnTop_btnCommit.Image = global::ERPSupport.SupForm.Properties.Resources.accept;
            this.bnTop_btnCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnCommit.Name = "bnTop_btnCommit";
            this.bnTop_btnCommit.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnCommit.Tag = "5";
            this.bnTop_btnCommit.Text = "提交";
            // 
            // bnTop_btnUnLock
            // 
            this.bnTop_btnUnLock.Image = global::ERPSupport.SupForm.Properties.Resources.key;
            this.bnTop_btnUnLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnUnLock.Name = "bnTop_btnUnLock";
            this.bnTop_btnUnLock.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnUnLock.Tag = "6";
            this.bnTop_btnUnLock.Text = "解锁";
            this.bnTop_btnUnLock.ToolTipText = "库存解锁";
            // 
            // tsmiPro_Business_DLOrder
            // 
            this.tsmiPro_Business_DLOrder.Name = "tsmiPro_Business_DLOrder";
            this.tsmiPro_Business_DLOrder.Size = new System.Drawing.Size(186, 22);
            this.tsmiPro_Business_DLOrder.Text = "下载又一城订单";
            // 
            // tsmiPro_Business_SynOrder
            // 
            this.tsmiPro_Business_SynOrder.Name = "tsmiPro_Business_SynOrder";
            this.tsmiPro_Business_SynOrder.Size = new System.Drawing.Size(186, 22);
            this.tsmiPro_Business_SynOrder.Text = "同步订单信息";
            // 
            // tsmiPro_Business_DLROrder
            // 
            this.tsmiPro_Business_DLROrder.Name = "tsmiPro_Business_DLROrder";
            this.tsmiPro_Business_DLROrder.Size = new System.Drawing.Size(186, 22);
            this.tsmiPro_Business_DLROrder.Text = "下载又一城退货单";
            // 
            // tsmiPro_Business_SynROrder
            // 
            this.tsmiPro_Business_SynROrder.Name = "tsmiPro_Business_SynROrder";
            this.tsmiPro_Business_SynROrder.Size = new System.Drawing.Size(186, 22);
            this.tsmiPro_Business_SynROrder.Text = "同步退货单信息";
            // 
            // tsmiPro_Business_ImportDelivery
            // 
            this.tsmiPro_Business_ImportDelivery.Name = "tsmiPro_Business_ImportDelivery";
            this.tsmiPro_Business_ImportDelivery.Size = new System.Drawing.Size(186, 22);
            this.tsmiPro_Business_ImportDelivery.Text = "导入发货信息";
            // 
            // tsmiPro_Business_CancleAudit
            // 
            this.tsmiPro_Business_CancleAudit.Name = "tsmiPro_Business_CancleAudit";
            this.tsmiPro_Business_CancleAudit.Size = new System.Drawing.Size(186, 22);
            this.tsmiPro_Business_CancleAudit.Text = "待审的取消申请";
            // 
            // tsmiPro_Business_CancleDealt
            // 
            this.tsmiPro_Business_CancleDealt.Name = "tsmiPro_Business_CancleDealt";
            this.tsmiPro_Business_CancleDealt.Size = new System.Drawing.Size(186, 22);
            this.tsmiPro_Business_CancleDealt.Text = "已处理的取消申请";
            // 
            // tsmiPro_Business_LockSynOrder
            // 
            this.tsmiPro_Business_LockSynOrder.Name = "tsmiPro_Business_LockSynOrder";
            this.tsmiPro_Business_LockSynOrder.Size = new System.Drawing.Size(186, 22);
            this.tsmiPro_Business_LockSynOrder.Text = "锁住同步订单信息";
            // 
            // tsmiPro_Business_Report
            // 
            this.tsmiPro_Business_Report.Name = "tsmiPro_Business_Report";
            this.tsmiPro_Business_Report.Size = new System.Drawing.Size(186, 22);
            this.tsmiPro_Business_Report.Text = "报表管理";
            this.tsmiPro_Business_Report.Click += new System.EventHandler(this.tsmiPro_Business_Report_Click);
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
            this.MinimumSize = new System.Drawing.Size(1022, 762);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP辅助系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.sc1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc1)).EndInit();
            this.sc1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).EndInit();
            this.bnTop.ResumeLayout(false);
            this.bnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer sc1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv1;
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
        private System.Windows.Forms.ToolStripSeparator tsmiHelp_tss1;
        private System.Windows.Forms.ToolStripSeparator tsmiFile_tss1;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Timer;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_New;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_Open;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Occupy;
        private System.Windows.Forms.ToolStripSeparator tsmiTool_tss1;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Parameter;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Occupy_LockStock;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Occupy_OrderRun;
        private System.Windows.Forms.Timer tSumSecond;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp_Regedit;
        private System.Windows.Forms.ToolStripSeparator tsmiTool_tss2;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Occupy_LockPickMtl;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Occupy_PickMtl;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool_Occupy_Trans;
        private System.Windows.Forms.ToolStripSeparator tssTool_Occupy_1;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Dir;
        private System.Windows.Forms.BindingNavigator bnTop;
        private System.Windows.Forms.ToolStripButton bnTop_btnFilter;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss1;
        private System.Windows.Forms.ToolStripButton bnTop_btnCheck;
        private System.Windows.Forms.ToolStripButton bnTop_btnSearch;
        private System.Windows.Forms.ToolStripButton bnTop_btnShowAll;
        private System.Windows.Forms.ToolStripButton bnTop_btnCommit;
        private System.Windows.Forms.ToolStripButton bnTop_btnUnLock;
        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripSeparator bnB_tss1;
        private System.Windows.Forms.ToolStripSeparator bnB_tss2;
        private System.Windows.Forms.ToolStripSeparator bnB_tss4;
        private System.Windows.Forms.ToolStripComboBox bnB_cbxPageSize;
        private System.Windows.Forms.ToolStripLabel bnB_lblPageSize;
        private System.Windows.Forms.ToolStripLabel bnB_lblRecordCount;
        private System.Windows.Forms.ToolStripSeparator bnB_tss3;
        private System.Windows.Forms.ToolStripButton bnB_btnGoto;
        private System.Windows.Forms.BindingSource bs1;
        private System.Windows.Forms.ToolStripLabel bnB_lblSeparate;
        private System.Windows.Forms.ToolStripLabel bnB_lblThe;
        private System.Windows.Forms.ToolStripTextBox bnB_txtCurrentPage;
        private System.Windows.Forms.ToolStripLabel bnB_lblPageCount;
        private System.Windows.Forms.ToolStripButton bnB_btnFirst;
        private System.Windows.Forms.ToolStripButton bnB_btnPrevious;
        private System.Windows.Forms.ToolStripButton bnB_btnNext;
        private System.Windows.Forms.ToolStripButton bnB_btnLast;
        private System.Windows.Forms.ToolStripLabel bnTop_lblDate;
        private System.Windows.Forms.ToolStripLabel bnTop_lblTo;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_WMSData;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_K3Data;
        private System.Windows.Forms.ToolStripSeparator tsmiPro_tss1;
        private System.Windows.Forms.ToolStripSeparator tsmiPro_tss2;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_INOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Business;
        private System.Windows.Forms.ToolStripSeparator tsmiPro_tss0;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Business_DLOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Business_SynOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Business_DLROrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Business_SynROrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Business_ImportDelivery;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Business_CancleAudit;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Business_CancleDealt;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Business_LockSynOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiPro_Business_Report;
    }
}
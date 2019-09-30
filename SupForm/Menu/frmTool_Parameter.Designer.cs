namespace ERPSupport.SupForm.Menu
{
    partial class frmTool_Parameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTool_Parameter));
            this.gbxOrderRun = new System.Windows.Forms.GroupBox();
            this.plOther = new System.Windows.Forms.Panel();
            this.chbJoin = new System.Windows.Forms.CheckBox();
            this.btnInport = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStar = new System.Windows.Forms.DateTimePicker();
            this.lblSumDays = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStarTime = new System.Windows.Forms.Label();
            this.lblOther = new System.Windows.Forms.Label();
            this.txtSumDays = new System.Windows.Forms.TextBox();
            this.plMaterial = new System.Windows.Forms.Panel();
            this.lblMinBats = new System.Windows.Forms.Label();
            this.lblLowBook = new System.Windows.Forms.Label();
            this.txtMinBats = new System.Windows.Forms.TextBox();
            this.lblAddGoodsDays = new System.Windows.Forms.Label();
            this.txtLowBook = new System.Windows.Forms.TextBox();
            this.lblLogisticsDays = new System.Windows.Forms.Label();
            this.txtAddGoodsDays = new System.Windows.Forms.TextBox();
            this.lblSafeStockDays = new System.Windows.Forms.Label();
            this.txtLogisticsDays = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.txtSafeStockDays = new System.Windows.Forms.TextBox();
            this.gbxLockStock = new System.Windows.Forms.GroupBox();
            this.plMiddle = new System.Windows.Forms.Panel();
            this.chbIsUse = new System.Windows.Forms.CheckBox();
            this.plNumber = new System.Windows.Forms.Panel();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.plPercent = new System.Windows.Forms.Panel();
            this.lblPC = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.plOption = new System.Windows.Forms.Panel();
            this.rbtPercent = new System.Windows.Forms.RadioButton();
            this.rbtNumber = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.gbxOrderRun.SuspendLayout();
            this.plOther.SuspendLayout();
            this.plMaterial.SuspendLayout();
            this.gbxLockStock.SuspendLayout();
            this.plMiddle.SuspendLayout();
            this.plNumber.SuspendLayout();
            this.plPercent.SuspendLayout();
            this.plOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxOrderRun
            // 
            this.gbxOrderRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOrderRun.Controls.Add(this.plOther);
            this.gbxOrderRun.Controls.Add(this.plMaterial);
            this.gbxOrderRun.Location = new System.Drawing.Point(12, 220);
            this.gbxOrderRun.Margin = new System.Windows.Forms.Padding(4);
            this.gbxOrderRun.Name = "gbxOrderRun";
            this.gbxOrderRun.Padding = new System.Windows.Forms.Padding(4);
            this.gbxOrderRun.Size = new System.Drawing.Size(633, 242);
            this.gbxOrderRun.TabIndex = 1;
            this.gbxOrderRun.TabStop = false;
            this.gbxOrderRun.Text = "订单运算参数";
            // 
            // plOther
            // 
            this.plOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plOther.Controls.Add(this.chbJoin);
            this.plOther.Controls.Add(this.btnInport);
            this.plOther.Controls.Add(this.dtpEnd);
            this.plOther.Controls.Add(this.dtpStar);
            this.plOther.Controls.Add(this.lblSumDays);
            this.plOther.Controls.Add(this.lblEndTime);
            this.plOther.Controls.Add(this.lblStarTime);
            this.plOther.Controls.Add(this.lblOther);
            this.plOther.Controls.Add(this.txtSumDays);
            this.plOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plOther.Location = new System.Drawing.Point(323, 22);
            this.plOther.Margin = new System.Windows.Forms.Padding(4);
            this.plOther.Name = "plOther";
            this.plOther.Size = new System.Drawing.Size(306, 216);
            this.plOther.TabIndex = 1;
            // 
            // chbJoin
            // 
            this.chbJoin.AutoSize = true;
            this.chbJoin.Location = new System.Drawing.Point(56, 145);
            this.chbJoin.Margin = new System.Windows.Forms.Padding(4);
            this.chbJoin.Name = "chbJoin";
            this.chbJoin.Size = new System.Drawing.Size(187, 19);
            this.chbJoin.TabIndex = 3;
            this.chbJoin.Text = "采购/生产数量参与运算";
            this.tt.SetToolTip(this.chbJoin, "勾选表示采购生产数量参与销售订单运算，否则不参与。");
            this.chbJoin.UseVisualStyleBackColor = true;
            // 
            // btnInport
            // 
            this.btnInport.Location = new System.Drawing.Point(56, 176);
            this.btnInport.Margin = new System.Windows.Forms.Padding(4);
            this.btnInport.Name = "btnInport";
            this.btnInport.Size = new System.Drawing.Size(209, 29);
            this.btnInport.TabIndex = 4;
            this.btnInport.Text = "导入物料选项参数";
            this.tt.SetToolTip(this.btnInport, "批量导入物料选项参数。");
            this.btnInport.UseVisualStyleBackColor = true;
            this.btnInport.Click += new System.EventHandler(this.btnInport_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(132, 74);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(132, 25);
            this.dtpEnd.TabIndex = 1;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStar
            // 
            this.dtpStar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStar.Location = new System.Drawing.Point(132, 40);
            this.dtpStar.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStar.Name = "dtpStar";
            this.dtpStar.Size = new System.Drawing.Size(132, 25);
            this.dtpStar.TabIndex = 0;
            this.dtpStar.ValueChanged += new System.EventHandler(this.dtpStar_ValueChanged);
            // 
            // lblSumDays
            // 
            this.lblSumDays.AutoSize = true;
            this.lblSumDays.Location = new System.Drawing.Point(53, 115);
            this.lblSumDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSumDays.Name = "lblSumDays";
            this.lblSumDays.Size = new System.Drawing.Size(67, 15);
            this.lblSumDays.TabIndex = 1;
            this.lblSumDays.Text = "累计天数";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(53, 81);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(67, 15);
            this.lblEndTime.TabIndex = 1;
            this.lblEndTime.Text = "结束时间";
            // 
            // lblStarTime
            // 
            this.lblStarTime.AutoSize = true;
            this.lblStarTime.Location = new System.Drawing.Point(53, 48);
            this.lblStarTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStarTime.Name = "lblStarTime";
            this.lblStarTime.Size = new System.Drawing.Size(67, 15);
            this.lblStarTime.TabIndex = 1;
            this.lblStarTime.Text = "开始时间";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Location = new System.Drawing.Point(127, 11);
            this.lblOther.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(67, 15);
            this.lblOther.TabIndex = 1;
            this.lblOther.Text = "其他选项";
            // 
            // txtSumDays
            // 
            this.txtSumDays.Enabled = false;
            this.txtSumDays.Location = new System.Drawing.Point(132, 111);
            this.txtSumDays.Margin = new System.Windows.Forms.Padding(4);
            this.txtSumDays.Name = "txtSumDays";
            this.txtSumDays.Size = new System.Drawing.Size(79, 25);
            this.txtSumDays.TabIndex = 2;
            this.txtSumDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Int);
            // 
            // plMaterial
            // 
            this.plMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plMaterial.Controls.Add(this.lblMinBats);
            this.plMaterial.Controls.Add(this.lblLowBook);
            this.plMaterial.Controls.Add(this.txtMinBats);
            this.plMaterial.Controls.Add(this.lblAddGoodsDays);
            this.plMaterial.Controls.Add(this.txtLowBook);
            this.plMaterial.Controls.Add(this.lblLogisticsDays);
            this.plMaterial.Controls.Add(this.txtAddGoodsDays);
            this.plMaterial.Controls.Add(this.lblSafeStockDays);
            this.plMaterial.Controls.Add(this.txtLogisticsDays);
            this.plMaterial.Controls.Add(this.lblMaterial);
            this.plMaterial.Controls.Add(this.txtSafeStockDays);
            this.plMaterial.Dock = System.Windows.Forms.DockStyle.Left;
            this.plMaterial.Enabled = false;
            this.plMaterial.Location = new System.Drawing.Point(4, 22);
            this.plMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.plMaterial.Name = "plMaterial";
            this.plMaterial.Size = new System.Drawing.Size(319, 216);
            this.plMaterial.TabIndex = 0;
            // 
            // lblMinBats
            // 
            this.lblMinBats.AutoSize = true;
            this.lblMinBats.Location = new System.Drawing.Point(64, 182);
            this.lblMinBats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinBats.Name = "lblMinBats";
            this.lblMinBats.Size = new System.Drawing.Size(67, 15);
            this.lblMinBats.TabIndex = 1;
            this.lblMinBats.Text = "最小批量";
            // 
            // lblLowBook
            // 
            this.lblLowBook.AutoSize = true;
            this.lblLowBook.Location = new System.Drawing.Point(48, 149);
            this.lblLowBook.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowBook.Name = "lblLowBook";
            this.lblLowBook.Size = new System.Drawing.Size(82, 15);
            this.lblLowBook.TabIndex = 1;
            this.lblLowBook.Text = "最低订货量";
            // 
            // txtMinBats
            // 
            this.txtMinBats.Location = new System.Drawing.Point(143, 179);
            this.txtMinBats.Margin = new System.Windows.Forms.Padding(4);
            this.txtMinBats.Name = "txtMinBats";
            this.txtMinBats.Size = new System.Drawing.Size(79, 25);
            this.txtMinBats.TabIndex = 4;
            this.txtMinBats.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Float);
            // 
            // lblAddGoodsDays
            // 
            this.lblAddGoodsDays.AutoSize = true;
            this.lblAddGoodsDays.Location = new System.Drawing.Point(80, 115);
            this.lblAddGoodsDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddGoodsDays.Name = "lblAddGoodsDays";
            this.lblAddGoodsDays.Size = new System.Drawing.Size(52, 15);
            this.lblAddGoodsDays.TabIndex = 1;
            this.lblAddGoodsDays.Text = "补货量";
            // 
            // txtLowBook
            // 
            this.txtLowBook.Location = new System.Drawing.Point(143, 145);
            this.txtLowBook.Margin = new System.Windows.Forms.Padding(4);
            this.txtLowBook.Name = "txtLowBook";
            this.txtLowBook.Size = new System.Drawing.Size(79, 25);
            this.txtLowBook.TabIndex = 3;
            this.txtLowBook.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Float);
            // 
            // lblLogisticsDays
            // 
            this.lblLogisticsDays.AutoSize = true;
            this.lblLogisticsDays.Location = new System.Drawing.Point(64, 81);
            this.lblLogisticsDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogisticsDays.Name = "lblLogisticsDays";
            this.lblLogisticsDays.Size = new System.Drawing.Size(67, 15);
            this.lblLogisticsDays.TabIndex = 1;
            this.lblLogisticsDays.Text = "物流时间";
            // 
            // txtAddGoodsDays
            // 
            this.txtAddGoodsDays.Location = new System.Drawing.Point(143, 111);
            this.txtAddGoodsDays.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddGoodsDays.Name = "txtAddGoodsDays";
            this.txtAddGoodsDays.Size = new System.Drawing.Size(79, 25);
            this.txtAddGoodsDays.TabIndex = 2;
            this.txtAddGoodsDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Int);
            // 
            // lblSafeStockDays
            // 
            this.lblSafeStockDays.AutoSize = true;
            this.lblSafeStockDays.Location = new System.Drawing.Point(32, 48);
            this.lblSafeStockDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSafeStockDays.Name = "lblSafeStockDays";
            this.lblSafeStockDays.Size = new System.Drawing.Size(97, 15);
            this.lblSafeStockDays.TabIndex = 1;
            this.lblSafeStockDays.Text = "安全库存天数";
            // 
            // txtLogisticsDays
            // 
            this.txtLogisticsDays.Location = new System.Drawing.Point(143, 78);
            this.txtLogisticsDays.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogisticsDays.Name = "txtLogisticsDays";
            this.txtLogisticsDays.Size = new System.Drawing.Size(79, 25);
            this.txtLogisticsDays.TabIndex = 1;
            this.txtLogisticsDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Int);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(120, 11);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(67, 15);
            this.lblMaterial.TabIndex = 1;
            this.lblMaterial.Text = "物料选项";
            this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSafeStockDays
            // 
            this.txtSafeStockDays.Location = new System.Drawing.Point(143, 44);
            this.txtSafeStockDays.Margin = new System.Windows.Forms.Padding(4);
            this.txtSafeStockDays.Name = "txtSafeStockDays";
            this.txtSafeStockDays.Size = new System.Drawing.Size(79, 25);
            this.txtSafeStockDays.TabIndex = 0;
            this.txtSafeStockDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Int);
            // 
            // gbxLockStock
            // 
            this.gbxLockStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxLockStock.Controls.Add(this.plMiddle);
            this.gbxLockStock.Controls.Add(this.plOption);
            this.gbxLockStock.Location = new System.Drawing.Point(16, 15);
            this.gbxLockStock.Margin = new System.Windows.Forms.Padding(4);
            this.gbxLockStock.Name = "gbxLockStock";
            this.gbxLockStock.Padding = new System.Windows.Forms.Padding(4);
            this.gbxLockStock.Size = new System.Drawing.Size(633, 198);
            this.gbxLockStock.TabIndex = 0;
            this.gbxLockStock.TabStop = false;
            this.gbxLockStock.Text = "锁库规则(未使用)";
            // 
            // plMiddle
            // 
            this.plMiddle.Controls.Add(this.chbIsUse);
            this.plMiddle.Controls.Add(this.plNumber);
            this.plMiddle.Controls.Add(this.plPercent);
            this.plMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMiddle.Location = new System.Drawing.Point(4, 71);
            this.plMiddle.Margin = new System.Windows.Forms.Padding(4);
            this.plMiddle.Name = "plMiddle";
            this.plMiddle.Size = new System.Drawing.Size(625, 123);
            this.plMiddle.TabIndex = 1;
            // 
            // chbIsUse
            // 
            this.chbIsUse.AutoSize = true;
            this.chbIsUse.Enabled = false;
            this.chbIsUse.Location = new System.Drawing.Point(487, 12);
            this.chbIsUse.Margin = new System.Windows.Forms.Padding(4);
            this.chbIsUse.Name = "chbIsUse";
            this.chbIsUse.Size = new System.Drawing.Size(89, 19);
            this.chbIsUse.TabIndex = 0;
            this.chbIsUse.Text = "启用规则";
            this.chbIsUse.UseVisualStyleBackColor = true;
            // 
            // plNumber
            // 
            this.plNumber.Controls.Add(this.lblNumber);
            this.plNumber.Controls.Add(this.txtNumber);
            this.plNumber.Location = new System.Drawing.Point(161, 8);
            this.plNumber.Margin = new System.Windows.Forms.Padding(4);
            this.plNumber.Name = "plNumber";
            this.plNumber.Size = new System.Drawing.Size(140, 102);
            this.plNumber.TabIndex = 0;
            // 
            // lblNumber
            // 
            this.lblNumber.Location = new System.Drawing.Point(7, 6);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(127, 56);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "订单每条分录最大锁库数量";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(11, 69);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(99, 25);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Float);
            // 
            // plPercent
            // 
            this.plPercent.Controls.Add(this.lblPC);
            this.plPercent.Controls.Add(this.lblPercent);
            this.plPercent.Controls.Add(this.txtPercent);
            this.plPercent.Location = new System.Drawing.Point(329, 8);
            this.plPercent.Margin = new System.Windows.Forms.Padding(4);
            this.plPercent.Name = "plPercent";
            this.plPercent.Size = new System.Drawing.Size(140, 102);
            this.plPercent.TabIndex = 0;
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Location = new System.Drawing.Point(119, 72);
            this.lblPC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(15, 15);
            this.lblPC.TabIndex = 0;
            this.lblPC.Text = "%";
            // 
            // lblPercent
            // 
            this.lblPercent.Location = new System.Drawing.Point(7, 6);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(127, 56);
            this.lblPercent.TabIndex = 0;
            this.lblPercent.Text = "订单每条分录最大锁库数量按库存量百分比分配";
            // 
            // txtPercent
            // 
            this.txtPercent.Location = new System.Drawing.Point(19, 69);
            this.txtPercent.Margin = new System.Windows.Forms.Padding(4);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(99, 25);
            this.txtPercent.TabIndex = 0;
            this.txtPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Percent);
            // 
            // plOption
            // 
            this.plOption.Controls.Add(this.rbtPercent);
            this.plOption.Controls.Add(this.rbtNumber);
            this.plOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.plOption.Location = new System.Drawing.Point(4, 22);
            this.plOption.Margin = new System.Windows.Forms.Padding(4);
            this.plOption.Name = "plOption";
            this.plOption.Size = new System.Drawing.Size(625, 49);
            this.plOption.TabIndex = 0;
            // 
            // rbtPercent
            // 
            this.rbtPercent.AutoSize = true;
            this.rbtPercent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtPercent.Location = new System.Drawing.Point(329, 15);
            this.rbtPercent.Margin = new System.Windows.Forms.Padding(4);
            this.rbtPercent.Name = "rbtPercent";
            this.rbtPercent.Size = new System.Drawing.Size(93, 24);
            this.rbtPercent.TabIndex = 1;
            this.rbtPercent.TabStop = true;
            this.rbtPercent.Text = "百分比";
            this.rbtPercent.UseVisualStyleBackColor = true;
            // 
            // rbtNumber
            // 
            this.rbtNumber.AutoSize = true;
            this.rbtNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtNumber.Location = new System.Drawing.Point(201, 20);
            this.rbtNumber.Margin = new System.Windows.Forms.Padding(4);
            this.rbtNumber.Name = "rbtNumber";
            this.rbtNumber.Size = new System.Drawing.Size(72, 24);
            this.rbtNumber.TabIndex = 0;
            this.rbtNumber.TabStop = true;
            this.rbtNumber.Text = "数量";
            this.rbtNumber.UseVisualStyleBackColor = true;
            this.rbtNumber.CheckedChanged += new System.EventHandler(this.rbtNumber_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(221, 470);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(349, 470);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(100, 29);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "取消(&C)";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // frmTool_Parameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 503);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbxLockStock);
            this.Controls.Add(this.gbxOrderRun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(680, 550);
            this.MinimumSize = new System.Drawing.Size(680, 550);
            this.Name = "frmTool_Parameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.frmTool_Parameter_Load);
            this.gbxOrderRun.ResumeLayout(false);
            this.plOther.ResumeLayout(false);
            this.plOther.PerformLayout();
            this.plMaterial.ResumeLayout(false);
            this.plMaterial.PerformLayout();
            this.gbxLockStock.ResumeLayout(false);
            this.plMiddle.ResumeLayout(false);
            this.plMiddle.PerformLayout();
            this.plNumber.ResumeLayout(false);
            this.plNumber.PerformLayout();
            this.plPercent.ResumeLayout(false);
            this.plPercent.PerformLayout();
            this.plOption.ResumeLayout(false);
            this.plOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxOrderRun;
        private System.Windows.Forms.GroupBox gbxLockStock;
        private System.Windows.Forms.Panel plOther;
        private System.Windows.Forms.Label lblSumDays;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStarTime;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.TextBox txtSumDays;
        private System.Windows.Forms.Panel plMaterial;
        private System.Windows.Forms.Label lblMinBats;
        private System.Windows.Forms.Label lblLowBook;
        private System.Windows.Forms.TextBox txtMinBats;
        private System.Windows.Forms.Label lblAddGoodsDays;
        private System.Windows.Forms.TextBox txtLowBook;
        private System.Windows.Forms.Label lblLogisticsDays;
        private System.Windows.Forms.TextBox txtAddGoodsDays;
        private System.Windows.Forms.Label lblSafeStockDays;
        private System.Windows.Forms.TextBox txtLogisticsDays;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.TextBox txtSafeStockDays;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStar;
        private System.Windows.Forms.Panel plMiddle;
        private System.Windows.Forms.Panel plNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Panel plPercent;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.Panel plOption;
        private System.Windows.Forms.RadioButton rbtPercent;
        private System.Windows.Forms.RadioButton rbtNumber;
        private System.Windows.Forms.CheckBox chbIsUse;
        private System.Windows.Forms.Button btnInport;
        private System.Windows.Forms.CheckBox chbJoin;
        private System.Windows.Forms.ToolTip tt;
    }
}
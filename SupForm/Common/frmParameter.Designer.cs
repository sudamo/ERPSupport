namespace ERPSupport.SupForm.Common
{
    partial class frmParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParameter));
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
            this.gbxOrderRun.Location = new System.Drawing.Point(9, 176);
            this.gbxOrderRun.Name = "gbxOrderRun";
            this.gbxOrderRun.Size = new System.Drawing.Size(480, 194);
            this.gbxOrderRun.TabIndex = 10;
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
            this.plOther.Location = new System.Drawing.Point(243, 17);
            this.plOther.Name = "plOther";
            this.plOther.Size = new System.Drawing.Size(234, 174);
            this.plOther.TabIndex = 17;
            // 
            // chbJoin
            // 
            this.chbJoin.AutoSize = true;
            this.chbJoin.Location = new System.Drawing.Point(42, 116);
            this.chbJoin.Name = "chbJoin";
            this.chbJoin.Size = new System.Drawing.Size(150, 16);
            this.chbJoin.TabIndex = 22;
            this.chbJoin.Text = "采购/生产数量参与运算";
            this.tt.SetToolTip(this.chbJoin, "勾选表示采购生产数量参与销售订单运算，否则不参与。");
            this.chbJoin.UseVisualStyleBackColor = true;
            // 
            // btnInport
            // 
            this.btnInport.Location = new System.Drawing.Point(42, 141);
            this.btnInport.Name = "btnInport";
            this.btnInport.Size = new System.Drawing.Size(157, 23);
            this.btnInport.TabIndex = 21;
            this.btnInport.Text = "导入物料选项参数";
            this.tt.SetToolTip(this.btnInport, "批量导入物料选项参数。");
            this.btnInport.UseVisualStyleBackColor = true;
            this.btnInport.Click += new System.EventHandler(this.btnInport_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(99, 59);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(100, 21);
            this.dtpEnd.TabIndex = 19;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStar
            // 
            this.dtpStar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStar.Location = new System.Drawing.Point(99, 32);
            this.dtpStar.Name = "dtpStar";
            this.dtpStar.Size = new System.Drawing.Size(100, 21);
            this.dtpStar.TabIndex = 18;
            this.dtpStar.ValueChanged += new System.EventHandler(this.dtpStar_ValueChanged);
            // 
            // lblSumDays
            // 
            this.lblSumDays.AutoSize = true;
            this.lblSumDays.Location = new System.Drawing.Point(40, 92);
            this.lblSumDays.Name = "lblSumDays";
            this.lblSumDays.Size = new System.Drawing.Size(53, 12);
            this.lblSumDays.TabIndex = 1;
            this.lblSumDays.Text = "累计天数";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(40, 65);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(53, 12);
            this.lblEndTime.TabIndex = 1;
            this.lblEndTime.Text = "结束时间";
            // 
            // lblStarTime
            // 
            this.lblStarTime.AutoSize = true;
            this.lblStarTime.Location = new System.Drawing.Point(40, 38);
            this.lblStarTime.Name = "lblStarTime";
            this.lblStarTime.Size = new System.Drawing.Size(53, 12);
            this.lblStarTime.TabIndex = 1;
            this.lblStarTime.Text = "开始时间";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Location = new System.Drawing.Point(95, 9);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(53, 12);
            this.lblOther.TabIndex = 1;
            this.lblOther.Text = "其他选项";
            // 
            // txtSumDays
            // 
            this.txtSumDays.Enabled = false;
            this.txtSumDays.Location = new System.Drawing.Point(99, 89);
            this.txtSumDays.Name = "txtSumDays";
            this.txtSumDays.Size = new System.Drawing.Size(60, 21);
            this.txtSumDays.TabIndex = 20;
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
            this.plMaterial.Location = new System.Drawing.Point(3, 17);
            this.plMaterial.Name = "plMaterial";
            this.plMaterial.Size = new System.Drawing.Size(240, 174);
            this.plMaterial.TabIndex = 11;
            // 
            // lblMinBats
            // 
            this.lblMinBats.AutoSize = true;
            this.lblMinBats.Location = new System.Drawing.Point(48, 146);
            this.lblMinBats.Name = "lblMinBats";
            this.lblMinBats.Size = new System.Drawing.Size(53, 12);
            this.lblMinBats.TabIndex = 1;
            this.lblMinBats.Text = "最小批量";
            // 
            // lblLowBook
            // 
            this.lblLowBook.AutoSize = true;
            this.lblLowBook.Location = new System.Drawing.Point(36, 119);
            this.lblLowBook.Name = "lblLowBook";
            this.lblLowBook.Size = new System.Drawing.Size(65, 12);
            this.lblLowBook.TabIndex = 1;
            this.lblLowBook.Text = "最低订货量";
            // 
            // txtMinBats
            // 
            this.txtMinBats.Location = new System.Drawing.Point(107, 143);
            this.txtMinBats.Name = "txtMinBats";
            this.txtMinBats.Size = new System.Drawing.Size(60, 21);
            this.txtMinBats.TabIndex = 16;
            this.txtMinBats.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Float);
            // 
            // lblAddGoodsDays
            // 
            this.lblAddGoodsDays.AutoSize = true;
            this.lblAddGoodsDays.Location = new System.Drawing.Point(60, 92);
            this.lblAddGoodsDays.Name = "lblAddGoodsDays";
            this.lblAddGoodsDays.Size = new System.Drawing.Size(41, 12);
            this.lblAddGoodsDays.TabIndex = 1;
            this.lblAddGoodsDays.Text = "补货量";
            // 
            // txtLowBook
            // 
            this.txtLowBook.Location = new System.Drawing.Point(107, 116);
            this.txtLowBook.Name = "txtLowBook";
            this.txtLowBook.Size = new System.Drawing.Size(60, 21);
            this.txtLowBook.TabIndex = 15;
            this.txtLowBook.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Float);
            // 
            // lblLogisticsDays
            // 
            this.lblLogisticsDays.AutoSize = true;
            this.lblLogisticsDays.Location = new System.Drawing.Point(48, 65);
            this.lblLogisticsDays.Name = "lblLogisticsDays";
            this.lblLogisticsDays.Size = new System.Drawing.Size(53, 12);
            this.lblLogisticsDays.TabIndex = 1;
            this.lblLogisticsDays.Text = "物流时间";
            // 
            // txtAddGoodsDays
            // 
            this.txtAddGoodsDays.Location = new System.Drawing.Point(107, 89);
            this.txtAddGoodsDays.Name = "txtAddGoodsDays";
            this.txtAddGoodsDays.Size = new System.Drawing.Size(60, 21);
            this.txtAddGoodsDays.TabIndex = 14;
            this.txtAddGoodsDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Int);
            // 
            // lblSafeStockDays
            // 
            this.lblSafeStockDays.AutoSize = true;
            this.lblSafeStockDays.Location = new System.Drawing.Point(24, 38);
            this.lblSafeStockDays.Name = "lblSafeStockDays";
            this.lblSafeStockDays.Size = new System.Drawing.Size(77, 12);
            this.lblSafeStockDays.TabIndex = 1;
            this.lblSafeStockDays.Text = "安全库存天数";
            // 
            // txtLogisticsDays
            // 
            this.txtLogisticsDays.Location = new System.Drawing.Point(107, 62);
            this.txtLogisticsDays.Name = "txtLogisticsDays";
            this.txtLogisticsDays.Size = new System.Drawing.Size(60, 21);
            this.txtLogisticsDays.TabIndex = 13;
            this.txtLogisticsDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Int);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(90, 9);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(53, 12);
            this.lblMaterial.TabIndex = 1;
            this.lblMaterial.Text = "物料选项";
            this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSafeStockDays
            // 
            this.txtSafeStockDays.Location = new System.Drawing.Point(107, 35);
            this.txtSafeStockDays.Name = "txtSafeStockDays";
            this.txtSafeStockDays.Size = new System.Drawing.Size(60, 21);
            this.txtSafeStockDays.TabIndex = 12;
            this.txtSafeStockDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Int);
            // 
            // gbxLockStock
            // 
            this.gbxLockStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxLockStock.Controls.Add(this.plMiddle);
            this.gbxLockStock.Controls.Add(this.plOption);
            this.gbxLockStock.Location = new System.Drawing.Point(12, 12);
            this.gbxLockStock.Name = "gbxLockStock";
            this.gbxLockStock.Size = new System.Drawing.Size(480, 158);
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
            this.plMiddle.Location = new System.Drawing.Point(3, 56);
            this.plMiddle.Name = "plMiddle";
            this.plMiddle.Size = new System.Drawing.Size(474, 99);
            this.plMiddle.TabIndex = 0;
            // 
            // chbIsUse
            // 
            this.chbIsUse.AutoSize = true;
            this.chbIsUse.Enabled = false;
            this.chbIsUse.Location = new System.Drawing.Point(365, 10);
            this.chbIsUse.Name = "chbIsUse";
            this.chbIsUse.Size = new System.Drawing.Size(72, 16);
            this.chbIsUse.TabIndex = 5;
            this.chbIsUse.Text = "启用规则";
            this.chbIsUse.UseVisualStyleBackColor = true;
            // 
            // plNumber
            // 
            this.plNumber.Controls.Add(this.lblNumber);
            this.plNumber.Controls.Add(this.txtNumber);
            this.plNumber.Location = new System.Drawing.Point(121, 6);
            this.plNumber.Name = "plNumber";
            this.plNumber.Size = new System.Drawing.Size(105, 82);
            this.plNumber.TabIndex = 0;
            // 
            // lblNumber
            // 
            this.lblNumber.Location = new System.Drawing.Point(5, 5);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(95, 45);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "订单每条分录最大锁库数量";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(8, 55);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(75, 21);
            this.txtNumber.TabIndex = 3;
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Float);
            // 
            // plPercent
            // 
            this.plPercent.Controls.Add(this.lblPC);
            this.plPercent.Controls.Add(this.lblPercent);
            this.plPercent.Controls.Add(this.txtPercent);
            this.plPercent.Location = new System.Drawing.Point(247, 6);
            this.plPercent.Name = "plPercent";
            this.plPercent.Size = new System.Drawing.Size(105, 82);
            this.plPercent.TabIndex = 0;
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Location = new System.Drawing.Point(89, 58);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(11, 12);
            this.lblPC.TabIndex = 0;
            this.lblPC.Text = "%";
            // 
            // lblPercent
            // 
            this.lblPercent.Location = new System.Drawing.Point(5, 5);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(95, 45);
            this.lblPercent.TabIndex = 0;
            this.lblPercent.Text = "订单每条分录最大锁库数量按库存量百分比分配";
            // 
            // txtPercent
            // 
            this.txtPercent.Location = new System.Drawing.Point(14, 55);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(75, 21);
            this.txtPercent.TabIndex = 4;
            this.txtPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress_Percent);
            // 
            // plOption
            // 
            this.plOption.Controls.Add(this.rbtPercent);
            this.plOption.Controls.Add(this.rbtNumber);
            this.plOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.plOption.Location = new System.Drawing.Point(3, 17);
            this.plOption.Name = "plOption";
            this.plOption.Size = new System.Drawing.Size(474, 39);
            this.plOption.TabIndex = 0;
            // 
            // rbtPercent
            // 
            this.rbtPercent.AutoSize = true;
            this.rbtPercent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtPercent.Location = new System.Drawing.Point(247, 12);
            this.rbtPercent.Name = "rbtPercent";
            this.rbtPercent.Size = new System.Drawing.Size(77, 20);
            this.rbtPercent.TabIndex = 2;
            this.rbtPercent.TabStop = true;
            this.rbtPercent.Text = "百分比";
            this.rbtPercent.UseVisualStyleBackColor = true;
            // 
            // rbtNumber
            // 
            this.rbtNumber.AutoSize = true;
            this.rbtNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtNumber.Location = new System.Drawing.Point(151, 16);
            this.rbtNumber.Name = "rbtNumber";
            this.rbtNumber.Size = new System.Drawing.Size(60, 20);
            this.rbtNumber.TabIndex = 1;
            this.rbtNumber.TabStop = true;
            this.rbtNumber.Text = "数量";
            this.rbtNumber.UseVisualStyleBackColor = true;
            this.rbtNumber.CheckedChanged += new System.EventHandler(this.rbtNumber_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(166, 376);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(262, 376);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 22;
            this.btnCancle.Text = "取消(&C)";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // frmParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 412);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbxLockStock);
            this.Controls.Add(this.gbxOrderRun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(520, 450);
            this.MinimumSize = new System.Drawing.Size(520, 450);
            this.Name = "frmParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.frmParameter_Load);
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
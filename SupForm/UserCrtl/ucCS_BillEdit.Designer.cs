namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucCS_BillEdit
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.pl1 = new System.Windows.Forms.Panel();
            this.btnSyn = new System.Windows.Forms.Button();
            this.btnBatchModify = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.lblFbillNo = new System.Windows.Forms.Label();
            this.lblSP = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.lblMTL = new System.Windows.Forms.Label();
            this.pl2 = new System.Windows.Forms.Panel();
            this.btnModify = new System.Windows.Forms.Button();
            this.chkSingle = new System.Windows.Forms.CheckBox();
            this.txtCanOutQty = new System.Windows.Forms.TextBox();
            this.txtMTL = new System.Windows.Forms.TextBox();
            this.lblCanOutQty = new System.Windows.Forms.Label();
            this.pl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.pl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(50, 3);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(100, 20);
            this.cbxType.TabIndex = 0;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // pl1
            // 
            this.pl1.Controls.Add(this.btnSyn);
            this.pl1.Controls.Add(this.btnBatchModify);
            this.pl1.Controls.Add(this.btnSearch);
            this.pl1.Controls.Add(this.dtpTo);
            this.pl1.Controls.Add(this.dtpFrom);
            this.pl1.Controls.Add(this.txtBillNo);
            this.pl1.Controls.Add(this.lblFbillNo);
            this.pl1.Controls.Add(this.lblSP);
            this.pl1.Controls.Add(this.lblDate);
            this.pl1.Controls.Add(this.lblType);
            this.pl1.Controls.Add(this.cbxType);
            this.pl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl1.Location = new System.Drawing.Point(0, 0);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(1024, 25);
            this.pl1.TabIndex = 1;
            // 
            // btnSyn
            // 
            this.btnSyn.Location = new System.Drawing.Point(791, 1);
            this.btnSyn.Name = "btnSyn";
            this.btnSyn.Size = new System.Drawing.Size(100, 23);
            this.btnSyn.TabIndex = 6;
            this.btnSyn.Text = "同步需求日期";
            this.btnSyn.UseVisualStyleBackColor = true;
            this.btnSyn.Click += new System.EventHandler(this.btnSyn_Click);
            // 
            // btnBatchModify
            // 
            this.btnBatchModify.Location = new System.Drawing.Point(710, 1);
            this.btnBatchModify.Name = "btnBatchModify";
            this.btnBatchModify.Size = new System.Drawing.Size(75, 23);
            this.btnBatchModify.TabIndex = 5;
            this.btnBatchModify.Text = "批量修改";
            this.btnBatchModify.UseVisualStyleBackColor = true;
            this.btnBatchModify.Click += new System.EventHandler(this.btnBatchModify_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(629, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(523, 3);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(100, 21);
            this.dtpTo.TabIndex = 4;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(400, 3);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 21);
            this.dtpFrom.TabIndex = 4;
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(227, 3);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(120, 21);
            this.txtBillNo.TabIndex = 3;
            // 
            // lblFbillNo
            // 
            this.lblFbillNo.AutoSize = true;
            this.lblFbillNo.Location = new System.Drawing.Point(156, 6);
            this.lblFbillNo.Name = "lblFbillNo";
            this.lblFbillNo.Size = new System.Drawing.Size(65, 12);
            this.lblFbillNo.TabIndex = 2;
            this.lblFbillNo.Text = "单据编号：";
            // 
            // lblSP
            // 
            this.lblSP.AutoSize = true;
            this.lblSP.Location = new System.Drawing.Point(506, 6);
            this.lblSP.Name = "lblSP";
            this.lblSP.Size = new System.Drawing.Size(11, 12);
            this.lblSP.TabIndex = 1;
            this.lblSP.Text = "-";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(353, 6);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 12);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "日期：";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(3, 6);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 12);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "类型：";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(5, 75);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(1016, 690);
            this.dgv1.TabIndex = 2;
            this.dgv1.Visible = false;
            // 
            // lblMTL
            // 
            this.lblMTL.AutoSize = true;
            this.lblMTL.Location = new System.Drawing.Point(3, 11);
            this.lblMTL.Name = "lblMTL";
            this.lblMTL.Size = new System.Drawing.Size(65, 12);
            this.lblMTL.TabIndex = 3;
            this.lblMTL.Text = "物料编码：";
            // 
            // pl2
            // 
            this.pl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pl2.Controls.Add(this.btnModify);
            this.pl2.Controls.Add(this.chkSingle);
            this.pl2.Controls.Add(this.txtCanOutQty);
            this.pl2.Controls.Add(this.txtMTL);
            this.pl2.Controls.Add(this.lblCanOutQty);
            this.pl2.Controls.Add(this.lblMTL);
            this.pl2.Location = new System.Drawing.Point(5, 30);
            this.pl2.Name = "pl2";
            this.pl2.Size = new System.Drawing.Size(1016, 39);
            this.pl2.TabIndex = 4;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(624, 6);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 6;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // chkSingle
            // 
            this.chkSingle.AutoSize = true;
            this.chkSingle.Location = new System.Drawing.Point(518, 12);
            this.chkSingle.Name = "chkSingle";
            this.chkSingle.Size = new System.Drawing.Size(72, 16);
            this.chkSingle.TabIndex = 5;
            this.chkSingle.Text = "整单发货";
            this.chkSingle.UseVisualStyleBackColor = true;
            // 
            // txtCanOutQty
            // 
            this.txtCanOutQty.Location = new System.Drawing.Point(353, 8);
            this.txtCanOutQty.Name = "txtCanOutQty";
            this.txtCanOutQty.Size = new System.Drawing.Size(142, 21);
            this.txtCanOutQty.TabIndex = 4;
            // 
            // txtMTL
            // 
            this.txtMTL.Location = new System.Drawing.Point(74, 8);
            this.txtMTL.Name = "txtMTL";
            this.txtMTL.Size = new System.Drawing.Size(142, 21);
            this.txtMTL.TabIndex = 4;
            // 
            // lblCanOutQty
            // 
            this.lblCanOutQty.AutoSize = true;
            this.lblCanOutQty.Location = new System.Drawing.Point(277, 11);
            this.lblCanOutQty.Name = "lblCanOutQty";
            this.lblCanOutQty.Size = new System.Drawing.Size(65, 12);
            this.lblCanOutQty.TabIndex = 3;
            this.lblCanOutQty.Text = "可出数量：";
            // 
            // ucCS_BillEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pl2);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.pl1);
            this.Name = "ucCS_BillEdit";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucCS_BillEdit_Load);
            this.pl1.ResumeLayout(false);
            this.pl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.pl2.ResumeLayout(false);
            this.pl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Panel pl1;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label lblFbillNo;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnBatchModify;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblSP;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnSyn;
        private System.Windows.Forms.Label lblMTL;
        private System.Windows.Forms.Panel pl2;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.CheckBox chkSingle;
        private System.Windows.Forms.TextBox txtCanOutQty;
        private System.Windows.Forms.TextBox txtMTL;
        private System.Windows.Forms.Label lblCanOutQty;
    }
}

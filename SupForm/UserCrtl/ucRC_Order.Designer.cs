namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucRC_Order
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
            this.lblBillNo = new System.Windows.Forms.Label();
            this.txtFBillNO = new System.Windows.Forms.TextBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pl1 = new System.Windows.Forms.Panel();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.dtpTO = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblYSD = new System.Windows.Forms.Label();
            this.lblMaterialNo = new System.Windows.Forms.Label();
            this.txtMaterialNo = new System.Windows.Forms.TextBox();
            this.txtYSD = new System.Windows.Forms.TextBox();
            this.lblDash = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.pl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Location = new System.Drawing.Point(109, 6);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(59, 12);
            this.lblBillNo.TabIndex = 0;
            this.lblBillNo.Text = "销售订单:";
            // 
            // txtFBillNO
            // 
            this.txtFBillNO.Location = new System.Drawing.Point(174, 1);
            this.txtFBillNO.Name = "txtFBillNO";
            this.txtFBillNO.Size = new System.Drawing.Size(80, 21);
            this.txtFBillNO.TabIndex = 3;
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(3, 3);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(100, 20);
            this.cbxType.TabIndex = 2;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(856, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pl1
            // 
            this.pl1.Controls.Add(this.cbxStatus);
            this.pl1.Controls.Add(this.dtpTO);
            this.pl1.Controls.Add(this.dtpFrom);
            this.pl1.Controls.Add(this.cbxType);
            this.pl1.Controls.Add(this.btnExport);
            this.pl1.Controls.Add(this.btnSearch);
            this.pl1.Controls.Add(this.lblYSD);
            this.pl1.Controls.Add(this.lblMaterialNo);
            this.pl1.Controls.Add(this.lblBillNo);
            this.pl1.Controls.Add(this.txtMaterialNo);
            this.pl1.Controls.Add(this.txtYSD);
            this.pl1.Controls.Add(this.txtFBillNO);
            this.pl1.Controls.Add(this.lblDash);
            this.pl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl1.Location = new System.Drawing.Point(0, 0);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(1024, 25);
            this.pl1.TabIndex = 1;
            // 
            // cbxStatus
            // 
            this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(770, 3);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(80, 20);
            this.cbxStatus.TabIndex = 8;
            // 
            // dtpTO
            // 
            this.dtpTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTO.Location = new System.Drawing.Point(519, 3);
            this.dtpTO.Name = "dtpTO";
            this.dtpTO.Size = new System.Drawing.Size(85, 21);
            this.dtpTO.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(411, 3);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(85, 21);
            this.dtpFrom.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(947, 1);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(70, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "导出报表";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblYSD
            // 
            this.lblYSD.AutoSize = true;
            this.lblYSD.Location = new System.Drawing.Point(611, 6);
            this.lblYSD.Name = "lblYSD";
            this.lblYSD.Size = new System.Drawing.Size(47, 12);
            this.lblYSD.TabIndex = 0;
            this.lblYSD.Text = "运单号:";
            this.lblYSD.Visible = false;
            // 
            // lblMaterialNo
            // 
            this.lblMaterialNo.AutoSize = true;
            this.lblMaterialNo.Location = new System.Drawing.Point(260, 6);
            this.lblMaterialNo.Name = "lblMaterialNo";
            this.lblMaterialNo.Size = new System.Drawing.Size(59, 12);
            this.lblMaterialNo.TabIndex = 0;
            this.lblMaterialNo.Text = "物料编码:";
            // 
            // txtMaterialNo
            // 
            this.txtMaterialNo.Location = new System.Drawing.Point(325, 3);
            this.txtMaterialNo.Name = "txtMaterialNo";
            this.txtMaterialNo.Size = new System.Drawing.Size(80, 21);
            this.txtMaterialNo.TabIndex = 3;
            // 
            // txtYSD
            // 
            this.txtYSD.Location = new System.Drawing.Point(664, 3);
            this.txtYSD.Name = "txtYSD";
            this.txtYSD.Size = new System.Drawing.Size(100, 21);
            this.txtYSD.TabIndex = 3;
            this.txtYSD.Visible = false;
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Location = new System.Drawing.Point(502, 6);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(11, 12);
            this.lblDash.TabIndex = 0;
            this.lblDash.Text = "-";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(3, 30);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1018, 735);
            this.dgv1.TabIndex = 6;
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
            // 
            // ucRC_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.pl1);
            this.Name = "ucRC_Order";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucRC_Order_Load);
            this.pl1.ResumeLayout(false);
            this.pl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBillNo;
        private System.Windows.Forms.TextBox txtFBillNO;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pl1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label lblYSD;
        private System.Windows.Forms.TextBox txtYSD;
        private System.Windows.Forms.DateTimePicker dtpTO;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label lblMaterialNo;
        private System.Windows.Forms.TextBox txtMaterialNo;
    }
}

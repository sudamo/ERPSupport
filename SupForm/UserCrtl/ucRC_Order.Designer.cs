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
            this.components = new System.ComponentModel.Container();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_cbxType = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_lblBillNo = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtBillNo = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_lblMaterialNo = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtMaterialNo = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_lblYSD = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtYSD = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_lblDash = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_cbxStatus = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_tss3 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnSearch = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnExport = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            this.SuspendLayout();
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
            this.dgv1.Location = new System.Drawing.Point(3, 28);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1018, 737);
            this.dgv1.TabIndex = 6;
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_cbxType,
            this.bnTop_lblBillNo,
            this.bnTop_txtBillNo,
            this.bnTop_lblMaterialNo,
            this.bnTop_txtMaterialNo,
            this.bnTop_lblYSD,
            this.bnTop_txtYSD,
            this.bnTop_tss,
            this.bnTop_lblDash,
            this.bnTop_tss2,
            this.bnTop_cbxStatus,
            this.bnTop_tss3,
            this.bnTop_btnSearch,
            this.bnTop_btnExport});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(1024, 25);
            this.bnTop.TabIndex = 27;
            this.bnTop.Text = "bindingNavigator1";
            this.bnTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bnTop_ItemClicked);
            // 
            // bnTop_cbxType
            // 
            this.bnTop_cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxType.Name = "bnTop_cbxType";
            this.bnTop_cbxType.Size = new System.Drawing.Size(95, 25);
            this.bnTop_cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // bnTop_lblBillNo
            // 
            this.bnTop_lblBillNo.Name = "bnTop_lblBillNo";
            this.bnTop_lblBillNo.Size = new System.Drawing.Size(68, 22);
            this.bnTop_lblBillNo.Text = "销售订单：";
            // 
            // bnTop_txtBillNo
            // 
            this.bnTop_txtBillNo.Name = "bnTop_txtBillNo";
            this.bnTop_txtBillNo.Size = new System.Drawing.Size(80, 25);
            // 
            // bnTop_lblMaterialNo
            // 
            this.bnTop_lblMaterialNo.Name = "bnTop_lblMaterialNo";
            this.bnTop_lblMaterialNo.Size = new System.Drawing.Size(68, 22);
            this.bnTop_lblMaterialNo.Text = "物料编码：";
            // 
            // bnTop_txtMaterialNo
            // 
            this.bnTop_txtMaterialNo.Name = "bnTop_txtMaterialNo";
            this.bnTop_txtMaterialNo.Size = new System.Drawing.Size(100, 25);
            // 
            // bnTop_lblYSD
            // 
            this.bnTop_lblYSD.Name = "bnTop_lblYSD";
            this.bnTop_lblYSD.Size = new System.Drawing.Size(56, 22);
            this.bnTop_lblYSD.Text = "运单号：";
            // 
            // bnTop_txtYSD
            // 
            this.bnTop_txtYSD.Name = "bnTop_txtYSD";
            this.bnTop_txtYSD.Size = new System.Drawing.Size(100, 25);
            // 
            // bnTop_tss
            // 
            this.bnTop_tss.Name = "bnTop_tss";
            this.bnTop_tss.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_lblDash
            // 
            this.bnTop_lblDash.Name = "bnTop_lblDash";
            this.bnTop_lblDash.Size = new System.Drawing.Size(13, 22);
            this.bnTop_lblDash.Text = "-";
            // 
            // bnTop_tss2
            // 
            this.bnTop_tss2.Name = "bnTop_tss2";
            this.bnTop_tss2.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_cbxStatus
            // 
            this.bnTop_cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxStatus.Name = "bnTop_cbxStatus";
            this.bnTop_cbxStatus.Size = new System.Drawing.Size(75, 25);
            // 
            // bnTop_tss3
            // 
            this.bnTop_tss3.Name = "bnTop_tss3";
            this.bnTop_tss3.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_btnSearch
            // 
            this.bnTop_btnSearch.Image = global::ERPSupport.SupForm.Properties.Resources.zoom;
            this.bnTop_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnSearch.Name = "bnTop_btnSearch";
            this.bnTop_btnSearch.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnSearch.Tag = "1";
            this.bnTop_btnSearch.Text = "查找";
            this.bnTop_btnSearch.ToolTipText = "查询";
            // 
            // bnTop_btnExport
            // 
            this.bnTop_btnExport.Image = global::ERPSupport.SupForm.Properties.Resources.page_excel;
            this.bnTop_btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnExport.Name = "bnTop_btnExport";
            this.bnTop_btnExport.Size = new System.Drawing.Size(76, 22);
            this.bnTop_btnExport.Tag = "2";
            this.bnTop_btnExport.Text = "导出报表";
            this.bnTop_btnExport.ToolTipText = "把日志数据导出Excel报表";
            // 
            // ucRC_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnTop);
            this.Controls.Add(this.dgv1);
            this.Name = "ucRC_Order";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucRC_Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).EndInit();
            this.bnTop.ResumeLayout(false);
            this.bnTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.BindingNavigator bnTop;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxType;
        private System.Windows.Forms.ToolStripLabel bnTop_lblBillNo;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtBillNo;
        private System.Windows.Forms.ToolStripLabel bnTop_lblMaterialNo;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtMaterialNo;
        private System.Windows.Forms.ToolStripLabel bnTop_lblYSD;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtYSD;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss2;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxStatus;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss3;
        private System.Windows.Forms.ToolStripButton bnTop_btnSearch;
        private System.Windows.Forms.ToolStripButton bnTop_btnExport;
        private System.Windows.Forms.ToolStripLabel bnTop_lblDash;
    }
}

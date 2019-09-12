namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucCS_ExpCompany
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
            this.bnTop_lblMatchBillno = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtMatchBillno = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_lblCompany = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnAdd = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnEdit = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnDelete = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.bnTop_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_lblMi = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtNumber = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_txtECPY = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            this.SuspendLayout();
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
            this.dgv1.Location = new System.Drawing.Point(5, 28);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(1016, 737);
            this.dgv1.TabIndex = 4;
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_lblMatchBillno,
            this.bnTop_txtMatchBillno,
            this.bnTop_lblMi,
            this.bnTop_txtNumber,
            this.bnTop_lblCompany,
            this.bnTop_txtECPY,
            this.bnTop_tss,
            this.bnTop_btnAdd,
            this.bnTop_btnEdit,
            this.bnTop_btnDelete,
            this.bnTop_btnRefresh,
            this.bnTop_tss2});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(1024, 25);
            this.bnTop.TabIndex = 26;
            this.bnTop.Text = "bindingNavigator1";
            this.bnTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bnTop_ItemClicked);
            // 
            // bnTop_lblMatchBillno
            // 
            this.bnTop_lblMatchBillno.Name = "bnTop_lblMatchBillno";
            this.bnTop_lblMatchBillno.Size = new System.Drawing.Size(80, 22);
            this.bnTop_lblMatchBillno.Text = "匹配运单号：";
            // 
            // bnTop_txtMatchBillno
            // 
            this.bnTop_txtMatchBillno.Name = "bnTop_txtMatchBillno";
            this.bnTop_txtMatchBillno.Size = new System.Drawing.Size(100, 25);
            this.bnTop_txtMatchBillno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatchBillno_KeyPress);
            // 
            // bnTop_lblCompany
            // 
            this.bnTop_lblCompany.Name = "bnTop_lblCompany";
            this.bnTop_lblCompany.Size = new System.Drawing.Size(68, 22);
            this.bnTop_lblCompany.Text = "快递公司：";
            // 
            // bnTop_tss
            // 
            this.bnTop_tss.Name = "bnTop_tss";
            this.bnTop_tss.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_btnAdd
            // 
            this.bnTop_btnAdd.Image = global::ERPSupport.SupForm.Properties.Resources.add;
            this.bnTop_btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnAdd.Name = "bnTop_btnAdd";
            this.bnTop_btnAdd.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnAdd.Tag = "1";
            this.bnTop_btnAdd.Text = "新增";
            // 
            // bnTop_btnEdit
            // 
            this.bnTop_btnEdit.Image = global::ERPSupport.SupForm.Properties.Resources.livejournal;
            this.bnTop_btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnEdit.Name = "bnTop_btnEdit";
            this.bnTop_btnEdit.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnEdit.Tag = "2";
            this.bnTop_btnEdit.Text = "修改";
            this.bnTop_btnEdit.ToolTipText = "修改当前信息";
            // 
            // bnTop_btnDelete
            // 
            this.bnTop_btnDelete.Image = global::ERPSupport.SupForm.Properties.Resources.delete;
            this.bnTop_btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnDelete.Name = "bnTop_btnDelete";
            this.bnTop_btnDelete.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnDelete.Tag = "3";
            this.bnTop_btnDelete.Text = "删除";
            // 
            // bnTop_btnRefresh
            // 
            this.bnTop_btnRefresh.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_refresh;
            this.bnTop_btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnRefresh.Name = "bnTop_btnRefresh";
            this.bnTop_btnRefresh.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnRefresh.Tag = "4";
            this.bnTop_btnRefresh.Text = "刷新";
            this.bnTop_btnRefresh.ToolTipText = "刷新仓库信息";
            // 
            // bnTop_tss2
            // 
            this.bnTop_tss2.Name = "bnTop_tss2";
            this.bnTop_tss2.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_lblMi
            // 
            this.bnTop_lblMi.Name = "bnTop_lblMi";
            this.bnTop_lblMi.Size = new System.Drawing.Size(57, 22);
            this.bnTop_lblMi.Text = "*  位数：";
            // 
            // bnTop_txtNumber
            // 
            this.bnTop_txtNumber.Name = "bnTop_txtNumber";
            this.bnTop_txtNumber.Size = new System.Drawing.Size(50, 25);
            this.bnTop_txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // bnTop_txtECPY
            // 
            this.bnTop_txtECPY.Name = "bnTop_txtECPY";
            this.bnTop_txtECPY.Size = new System.Drawing.Size(150, 25);
            // 
            // ucCS_ExpCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnTop);
            this.Controls.Add(this.dgv1);
            this.Name = "ucCS_ExpCompany";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucCS_ExpCompany_Load);
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
        private System.Windows.Forms.ToolStripLabel bnTop_lblMatchBillno;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtMatchBillno;
        private System.Windows.Forms.ToolStripLabel bnTop_lblMi;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtNumber;
        private System.Windows.Forms.ToolStripLabel bnTop_lblCompany;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtECPY;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss;
        private System.Windows.Forms.ToolStripButton bnTop_btnAdd;
        private System.Windows.Forms.ToolStripButton bnTop_btnEdit;
        private System.Windows.Forms.ToolStripButton bnTop_btnDelete;
        private System.Windows.Forms.ToolStripButton bnTop_btnRefresh;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss2;
    }
}

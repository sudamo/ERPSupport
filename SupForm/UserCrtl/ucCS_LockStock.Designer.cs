namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucCS_LockStock
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
            this.bnTop_lblSeq = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtSeq = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_cbxOrg = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_cbxStock = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_lblOrg = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_lblStock = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnUp = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnDown = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnDel = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnSave = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnAdd = new System.Windows.Forms.ToolStripButton();
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
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(5, 27);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(1017, 739);
            this.dgv1.TabIndex = 6;
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_lblSeq,
            this.bnTop_txtSeq,
            this.bnTop_lblOrg,
            this.bnTop_cbxOrg,
            this.bnTop_lblStock,
            this.bnTop_cbxStock,
            this.bnTop_tss,
            this.bnTop_btnAdd,
            this.bnTop_btnUp,
            this.bnTop_btnDown,
            this.bnTop_btnSave,
            this.bnTop_btnDel,
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
            this.bnTop.TabIndex = 25;
            this.bnTop.Text = "bindingNavigator1";
            this.bnTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bnTop_ItemClicked);
            // 
            // bnTop_lblSeq
            // 
            this.bnTop_lblSeq.Name = "bnTop_lblSeq";
            this.bnTop_lblSeq.Size = new System.Drawing.Size(44, 22);
            this.bnTop_lblSeq.Text = "序号：";
            // 
            // bnTop_txtSeq
            // 
            this.bnTop_txtSeq.Name = "bnTop_txtSeq";
            this.bnTop_txtSeq.Size = new System.Drawing.Size(60, 25);
            this.bnTop_txtSeq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSEQ_KeyPress);
            // 
            // bnTop_tss
            // 
            this.bnTop_tss.Name = "bnTop_tss";
            this.bnTop_tss.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_tss2
            // 
            this.bnTop_tss2.Name = "bnTop_tss2";
            this.bnTop_tss2.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_cbxOrg
            // 
            this.bnTop_cbxOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxOrg.Name = "bnTop_cbxOrg";
            this.bnTop_cbxOrg.Size = new System.Drawing.Size(120, 25);
            this.bnTop_cbxOrg.SelectedIndexChanged += new System.EventHandler(this.cbxOrg_SelectedIndexChanged);
            // 
            // bnTop_cbxStock
            // 
            this.bnTop_cbxStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxStock.Name = "bnTop_cbxStock";
            this.bnTop_cbxStock.Size = new System.Drawing.Size(160, 25);
            // 
            // bnTop_lblOrg
            // 
            this.bnTop_lblOrg.Name = "bnTop_lblOrg";
            this.bnTop_lblOrg.Size = new System.Drawing.Size(68, 22);
            this.bnTop_lblOrg.Text = "使用组织：";
            // 
            // bnTop_lblStock
            // 
            this.bnTop_lblStock.Name = "bnTop_lblStock";
            this.bnTop_lblStock.Size = new System.Drawing.Size(44, 22);
            this.bnTop_lblStock.Text = "仓库：";
            // 
            // bnTop_btnRefresh
            // 
            this.bnTop_btnRefresh.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_refresh;
            this.bnTop_btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnRefresh.Name = "bnTop_btnRefresh";
            this.bnTop_btnRefresh.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnRefresh.Tag = "6";
            this.bnTop_btnRefresh.Text = "刷新";
            this.bnTop_btnRefresh.ToolTipText = "刷新仓库信息";
            // 
            // bnTop_btnUp
            // 
            this.bnTop_btnUp.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_up;
            this.bnTop_btnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnUp.Name = "bnTop_btnUp";
            this.bnTop_btnUp.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnUp.Tag = "2";
            this.bnTop_btnUp.Text = "上移";
            // 
            // bnTop_btnDown
            // 
            this.bnTop_btnDown.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_down;
            this.bnTop_btnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnDown.Name = "bnTop_btnDown";
            this.bnTop_btnDown.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnDown.Tag = "3";
            this.bnTop_btnDown.Text = "下移";
            // 
            // bnTop_btnDel
            // 
            this.bnTop_btnDel.Image = global::ERPSupport.SupForm.Properties.Resources.delete;
            this.bnTop_btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnDel.Name = "bnTop_btnDel";
            this.bnTop_btnDel.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnDel.Tag = "5";
            this.bnTop_btnDel.Text = "删除";
            // 
            // bnTop_btnSave
            // 
            this.bnTop_btnSave.Image = global::ERPSupport.SupForm.Properties.Resources.save;
            this.bnTop_btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnSave.Name = "bnTop_btnSave";
            this.bnTop_btnSave.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnSave.Tag = "4";
            this.bnTop_btnSave.Text = "保存";
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
            // ucCS_LockStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnTop);
            this.Controls.Add(this.dgv1);
            this.Name = "ucCS_LockStock";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucCS_LockStock_Load);
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
        private System.Windows.Forms.ToolStripLabel bnTop_lblSeq;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtSeq;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss;
        private System.Windows.Forms.ToolStripButton bnTop_btnRefresh;
        private System.Windows.Forms.ToolStripButton bnTop_btnUp;
        private System.Windows.Forms.ToolStripButton bnTop_btnDown;
        private System.Windows.Forms.ToolStripButton bnTop_btnDel;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss2;
        private System.Windows.Forms.ToolStripLabel bnTop_lblOrg;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxOrg;
        private System.Windows.Forms.ToolStripLabel bnTop_lblStock;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxStock;
        private System.Windows.Forms.ToolStripButton bnTop_btnSave;
        private System.Windows.Forms.ToolStripButton bnTop_btnAdd;
    }
}

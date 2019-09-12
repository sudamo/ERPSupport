namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucCS_PickDepartment
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
            this.bnTop_lblOrg = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_cbxOrg = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_lblDepartment = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_cbxDepartment = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnAdd = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnDelete = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.bnTop_tss2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(1017, 739);
            this.dgv1.TabIndex = 7;
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_lblOrg,
            this.bnTop_cbxOrg,
            this.bnTop_lblDepartment,
            this.bnTop_cbxDepartment,
            this.bnTop_tss,
            this.bnTop_btnAdd,
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
            this.bnTop.TabIndex = 27;
            this.bnTop.Text = "bindingNavigator1";
            this.bnTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bnTop_ItemClicked);
            // 
            // bnTop_lblOrg
            // 
            this.bnTop_lblOrg.Name = "bnTop_lblOrg";
            this.bnTop_lblOrg.Size = new System.Drawing.Size(68, 22);
            this.bnTop_lblOrg.Text = "使用组织：";
            // 
            // bnTop_cbxOrg
            // 
            this.bnTop_cbxOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxOrg.Name = "bnTop_cbxOrg";
            this.bnTop_cbxOrg.Size = new System.Drawing.Size(120, 25);
            this.bnTop_cbxOrg.SelectedIndexChanged += new System.EventHandler(this.cbxOrg_SelectedIndexChanged);
            // 
            // bnTop_lblDepartment
            // 
            this.bnTop_lblDepartment.Name = "bnTop_lblDepartment";
            this.bnTop_lblDepartment.Size = new System.Drawing.Size(44, 22);
            this.bnTop_lblDepartment.Text = "部门：";
            // 
            // bnTop_cbxDepartment
            // 
            this.bnTop_cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxDepartment.Name = "bnTop_cbxDepartment";
            this.bnTop_cbxDepartment.Size = new System.Drawing.Size(160, 25);
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
            // bnTop_btnDelete
            // 
            this.bnTop_btnDelete.Image = global::ERPSupport.SupForm.Properties.Resources.delete;
            this.bnTop_btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnDelete.Name = "bnTop_btnDelete";
            this.bnTop_btnDelete.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnDelete.Tag = "2";
            this.bnTop_btnDelete.Text = "删除";
            // 
            // bnTop_btnRefresh
            // 
            this.bnTop_btnRefresh.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_refresh;
            this.bnTop_btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnRefresh.Name = "bnTop_btnRefresh";
            this.bnTop_btnRefresh.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnRefresh.Tag = "3";
            this.bnTop_btnRefresh.Text = "刷新";
            this.bnTop_btnRefresh.ToolTipText = "刷新仓库信息";
            // 
            // bnTop_tss2
            // 
            this.bnTop_tss2.Name = "bnTop_tss2";
            this.bnTop_tss2.Size = new System.Drawing.Size(6, 25);
            // 
            // ucCS_PickDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnTop);
            this.Controls.Add(this.dgv1);
            this.Name = "ucCS_PickDepartment";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucCS_PickDepartment_Load);
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
        private System.Windows.Forms.ToolStripLabel bnTop_lblOrg;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxOrg;
        private System.Windows.Forms.ToolStripLabel bnTop_lblDepartment;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxDepartment;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss;
        private System.Windows.Forms.ToolStripButton bnTop_btnAdd;
        private System.Windows.Forms.ToolStripButton bnTop_btnDelete;
        private System.Windows.Forms.ToolStripButton bnTop_btnRefresh;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss2;
    }
}

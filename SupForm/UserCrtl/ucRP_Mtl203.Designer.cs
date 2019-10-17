namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucRP_Mtl203
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_cbxCondition = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_cbxLogic = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_txtValue = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_cbxValue = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnSearch = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnReport = new System.Windows.Forms.ToolStripButton();
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Turquoise;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(2, 29);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(1020, 737);
            this.dgv1.TabIndex = 19;
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_cbxCondition,
            this.bnTop_cbxLogic,
            this.bnTop_txtValue,
            this.bnTop_cbxValue,
            this.bnTop_tss,
            this.bnTop_btnSearch,
            this.bnTop_btnReport});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(1024, 27);
            this.bnTop.TabIndex = 28;
            this.bnTop.Text = "bindingNavigator1";
            // 
            // bnTop_cbxCondition
            // 
            this.bnTop_cbxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxCondition.Name = "bnTop_cbxCondition";
            this.bnTop_cbxCondition.Size = new System.Drawing.Size(100, 27);
            this.bnTop_cbxCondition.SelectedIndexChanged += new System.EventHandler(this.bnTop_cbxCondition_SelectedIndexChanged);
            // 
            // bnTop_cbxLogic
            // 
            this.bnTop_cbxLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxLogic.Name = "bnTop_cbxLogic";
            this.bnTop_cbxLogic.Size = new System.Drawing.Size(75, 27);
            // 
            // bnTop_txtValue
            // 
            this.bnTop_txtValue.Name = "bnTop_txtValue";
            this.bnTop_txtValue.Size = new System.Drawing.Size(120, 27);
            // 
            // bnTop_cbxValue
            // 
            this.bnTop_cbxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxValue.Name = "bnTop_cbxValue";
            this.bnTop_cbxValue.Size = new System.Drawing.Size(120, 27);
            // 
            // bnTop_tss
            // 
            this.bnTop_tss.Name = "bnTop_tss";
            this.bnTop_tss.Size = new System.Drawing.Size(6, 27);
            // 
            // bnTop_btnSearch
            // 
            this.bnTop_btnSearch.Image = global::ERPSupport.SupForm.Properties.Resources.zoom;
            this.bnTop_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnSearch.Name = "bnTop_btnSearch";
            this.bnTop_btnSearch.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnSearch.Text = "查找";
            this.bnTop_btnSearch.ToolTipText = "根据过滤条件查找数据";
            this.bnTop_btnSearch.Click += new System.EventHandler(this.bnTop_btnSearch_Click);
            // 
            // bnTop_btnReport
            // 
            this.bnTop_btnReport.Image = global::ERPSupport.SupForm.Properties.Resources.page_excel;
            this.bnTop_btnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnReport.Name = "bnTop_btnReport";
            this.bnTop_btnReport.Size = new System.Drawing.Size(80, 24);
            this.bnTop_btnReport.Text = "导出报表";
            this.bnTop_btnReport.ToolTipText = "把查询数据导出Excel报表";
            this.bnTop_btnReport.Click += new System.EventHandler(this.bnTop_btnReport_Click);
            // 
            // ucRP_Mtl203
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnTop);
            this.Controls.Add(this.dgv1);
            this.Name = "ucRP_Mtl203";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucRP_Mtl203_Load);
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
        private System.Windows.Forms.ToolStripSeparator bnTop_tss;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxCondition;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxLogic;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtValue;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxValue;
        private System.Windows.Forms.ToolStripButton bnTop_btnSearch;
        private System.Windows.Forms.ToolStripButton bnTop_btnReport;
    }
}

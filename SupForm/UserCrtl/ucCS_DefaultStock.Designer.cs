namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucCS_DefaultStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_lblNumber = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtNumber = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnSearch = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnBatchFill = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnSave = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnDel = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnClear = new System.Windows.Forms.ToolStripButton();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(5, 27);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.Size = new System.Drawing.Size(793, 571);
            this.dgv1.TabIndex = 11;
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_lblNumber,
            this.bnTop_txtNumber,
            this.bnTop_tss,
            this.bnTop_btnSearch,
            this.bnTop_btnBatchFill,
            this.bnTop_btnSave,
            this.bnTop_btnDel,
            this.bnTop_btnClear,
            this.bnTop_tss2});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(800, 25);
            this.bnTop.TabIndex = 13;
            this.bnTop.Text = "bindingNavigator1";
            this.bnTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bnTop_ItemClicked);
            // 
            // bnTop_lblNumber
            // 
            this.bnTop_lblNumber.Name = "bnTop_lblNumber";
            this.bnTop_lblNumber.Size = new System.Drawing.Size(68, 22);
            this.bnTop_lblNumber.Text = "物料编码：";
            // 
            // bnTop_txtNumber
            // 
            this.bnTop_txtNumber.Name = "bnTop_txtNumber";
            this.bnTop_txtNumber.Size = new System.Drawing.Size(130, 25);
            // 
            // bnTop_tss
            // 
            this.bnTop_tss.Name = "bnTop_tss";
            this.bnTop_tss.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_btnSearch
            // 
            this.bnTop_btnSearch.Image = global::ERPSupport.SupForm.Properties.Resources.zoom;
            this.bnTop_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnSearch.Name = "bnTop_btnSearch";
            this.bnTop_btnSearch.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnSearch.Tag = "1";
            this.bnTop_btnSearch.Text = "查询";
            // 
            // bnTop_btnBatchFill
            // 
            this.bnTop_btnBatchFill.Image = global::ERPSupport.SupForm.Properties.Resources.accept;
            this.bnTop_btnBatchFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnBatchFill.Name = "bnTop_btnBatchFill";
            this.bnTop_btnBatchFill.Size = new System.Drawing.Size(76, 22);
            this.bnTop_btnBatchFill.Tag = "2";
            this.bnTop_btnBatchFill.Text = "批量填充";
            // 
            // bnTop_btnSave
            // 
            this.bnTop_btnSave.Image = global::ERPSupport.SupForm.Properties.Resources.save;
            this.bnTop_btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnSave.Name = "bnTop_btnSave";
            this.bnTop_btnSave.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnSave.Tag = "3";
            this.bnTop_btnSave.Text = "保存";
            // 
            // bnTop_btnDel
            // 
            this.bnTop_btnDel.Image = global::ERPSupport.SupForm.Properties.Resources.delete;
            this.bnTop_btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnDel.Name = "bnTop_btnDel";
            this.bnTop_btnDel.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnDel.Tag = "4";
            this.bnTop_btnDel.Text = "删除";
            // 
            // bnTop_btnClear
            // 
            this.bnTop_btnClear.Image = global::ERPSupport.SupForm.Properties.Resources.comment_delete;
            this.bnTop_btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnClear.Name = "bnTop_btnClear";
            this.bnTop_btnClear.Size = new System.Drawing.Size(100, 22);
            this.bnTop_btnClear.Tag = "5";
            this.bnTop_btnClear.Text = "清除空值仓库";
            // 
            // bnTop_tss2
            // 
            this.bnTop_tss2.Name = "bnTop_tss2";
            this.bnTop_tss2.Size = new System.Drawing.Size(6, 25);
            // 
            // ucCS_DefaultStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnTop);
            this.Controls.Add(this.dgv1);
            this.Name = "ucCS_DefaultStock";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.ucCS_DefaultStock_Load);
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
        private System.Windows.Forms.ToolStripLabel bnTop_lblNumber;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtNumber;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss;
        private System.Windows.Forms.ToolStripButton bnTop_btnSearch;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss2;
        private System.Windows.Forms.ToolStripButton bnTop_btnSave;
        private System.Windows.Forms.ToolStripButton bnTop_btnClear;
        private System.Windows.Forms.ToolStripButton bnTop_btnBatchFill;
        private System.Windows.Forms.ToolStripButton bnTop_btnDel;
    }
}

namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucRC_System
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
            this.bnTop_lblDate = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtUser = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_lblUser = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnSearch = new System.Windows.Forms.ToolStripButton();
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
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(5, 27);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(1017, 739);
            this.dgv1.TabIndex = 21;
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_lblDate,
            this.bnTop_tss,
            this.bnTop_lblUser,
            this.bnTop_txtUser,
            this.bnTop_tss2,
            this.bnTop_btnSearch});
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
            // bnTop_lblDate
            // 
            this.bnTop_lblDate.Name = "bnTop_lblDate";
            this.bnTop_lblDate.Size = new System.Drawing.Size(44, 22);
            this.bnTop_lblDate.Text = "日期：";
            // 
            // bnTop_txtUser
            // 
            this.bnTop_txtUser.Name = "bnTop_txtUser";
            this.bnTop_txtUser.Size = new System.Drawing.Size(100, 25);
            this.bnTop_txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // bnTop_lblUser
            // 
            this.bnTop_lblUser.Name = "bnTop_lblUser";
            this.bnTop_lblUser.Size = new System.Drawing.Size(44, 22);
            this.bnTop_lblUser.Text = "用户：";
            // 
            // bnTop_tss
            // 
            this.bnTop_tss.Name = "bnTop_tss";
            this.bnTop_tss.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_btnSearch
            // 
            this.bnTop_btnSearch.Image = global::ERPSupport.SupForm.Properties.Resources.magnifier;
            this.bnTop_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnSearch.Name = "bnTop_btnSearch";
            this.bnTop_btnSearch.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnSearch.Tag = "1";
            this.bnTop_btnSearch.Text = "查找";
            this.bnTop_btnSearch.ToolTipText = "刷新仓库信息";
            // 
            // bnTop_tss2
            // 
            this.bnTop_tss2.Name = "bnTop_tss2";
            this.bnTop_tss2.Size = new System.Drawing.Size(6, 25);
            // 
            // ucRC_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bnTop);
            this.Controls.Add(this.dgv1);
            this.Name = "ucRC_System";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucRC_System_Load);
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
        private System.Windows.Forms.ToolStripLabel bnTop_lblDate;
        private System.Windows.Forms.ToolStripLabel bnTop_lblUser;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtUser;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss;
        private System.Windows.Forms.ToolStripButton bnTop_btnSearch;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss2;
    }
}

namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucLockStock
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.lblUseOrg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSEQ = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbxStock = new System.Windows.Forms.ComboBox();
            this.cbxUseOrg = new System.Windows.Forms.ComboBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblSEQ = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.dgv1.Location = new System.Drawing.Point(5, 30);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(1017, 736);
            this.dgv1.TabIndex = 6;
            // 
            // lblUseOrg
            // 
            this.lblUseOrg.AutoSize = true;
            this.lblUseOrg.Location = new System.Drawing.Point(115, 6);
            this.lblUseOrg.Name = "lblUseOrg";
            this.lblUseOrg.Size = new System.Drawing.Size(65, 12);
            this.lblUseOrg.TabIndex = 24;
            this.lblUseOrg.Text = "使用组织：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSEQ);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cbxStock);
            this.panel1.Controls.Add(this.cbxUseOrg);
            this.panel1.Controls.Add(this.lblStock);
            this.panel1.Controls.Add(this.lblSEQ);
            this.panel1.Controls.Add(this.lblUseOrg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 25);
            this.panel1.TabIndex = 25;
            // 
            // txtSEQ
            // 
            this.txtSEQ.Location = new System.Drawing.Point(50, 3);
            this.txtSEQ.Name = "txtSEQ";
            this.txtSEQ.Size = new System.Drawing.Size(59, 21);
            this.txtSEQ.TabIndex = 1;
            this.txtSEQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSEQ_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(568, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(487, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbxStock
            // 
            this.cbxStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStock.FormattingEnabled = true;
            this.cbxStock.Location = new System.Drawing.Point(360, 3);
            this.cbxStock.Name = "cbxStock";
            this.cbxStock.Size = new System.Drawing.Size(121, 20);
            this.cbxStock.TabIndex = 3;
            // 
            // cbxUseOrg
            // 
            this.cbxUseOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUseOrg.FormattingEnabled = true;
            this.cbxUseOrg.Location = new System.Drawing.Point(186, 3);
            this.cbxUseOrg.Name = "cbxUseOrg";
            this.cbxUseOrg.Size = new System.Drawing.Size(121, 20);
            this.cbxUseOrg.TabIndex = 2;
            this.cbxUseOrg.SelectedIndexChanged += new System.EventHandler(this.cbxUseOrg_SelectedIndexChanged);
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(313, 6);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(41, 12);
            this.lblStock.TabIndex = 24;
            this.lblStock.Text = "仓库：";
            // 
            // lblSEQ
            // 
            this.lblSEQ.AutoSize = true;
            this.lblSEQ.Location = new System.Drawing.Point(3, 6);
            this.lblSEQ.Name = "lblSEQ";
            this.lblSEQ.Size = new System.Drawing.Size(41, 12);
            this.lblSEQ.TabIndex = 24;
            this.lblSEQ.Text = "序号：";
            // 
            // ucLockStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv1);
            this.Name = "ucLockStock";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucLockStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label lblUseOrg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbxStock;
        private System.Windows.Forms.ComboBox cbxUseOrg;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtSEQ;
        private System.Windows.Forms.Label lblSEQ;
    }
}

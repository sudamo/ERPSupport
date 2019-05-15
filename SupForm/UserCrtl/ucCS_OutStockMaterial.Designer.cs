namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucCS_OutStockMaterial
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
            this.pl1 = new System.Windows.Forms.Panel();
            this.rbtNotMatch = new System.Windows.Forms.RadioButton();
            this.rbtMatch = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtMatchBillno = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.pl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(5, 30);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1016, 735);
            this.dgv1.TabIndex = 7;
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // pl1
            // 
            this.pl1.Controls.Add(this.rbtNotMatch);
            this.pl1.Controls.Add(this.rbtMatch);
            this.pl1.Controls.Add(this.btnDelete);
            this.pl1.Controls.Add(this.btnEdit);
            this.pl1.Controls.Add(this.btnAdd);
            this.pl1.Controls.Add(this.lblNumber);
            this.pl1.Controls.Add(this.txtMatchBillno);
            this.pl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl1.Location = new System.Drawing.Point(0, 0);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(1024, 25);
            this.pl1.TabIndex = 6;
            // 
            // rbtNotMatch
            // 
            this.rbtNotMatch.AutoSize = true;
            this.rbtNotMatch.Location = new System.Drawing.Point(256, 4);
            this.rbtNotMatch.Name = "rbtNotMatch";
            this.rbtNotMatch.Size = new System.Drawing.Size(47, 16);
            this.rbtNotMatch.TabIndex = 4;
            this.rbtNotMatch.TabStop = true;
            this.rbtNotMatch.Text = "排除";
            this.rbtNotMatch.UseVisualStyleBackColor = true;
            // 
            // rbtMatch
            // 
            this.rbtMatch.AutoSize = true;
            this.rbtMatch.Location = new System.Drawing.Point(203, 4);
            this.rbtMatch.Name = "rbtMatch";
            this.rbtMatch.Size = new System.Drawing.Size(47, 16);
            this.rbtMatch.TabIndex = 4;
            this.rbtMatch.TabStop = true;
            this.rbtMatch.Text = "携带";
            this.rbtMatch.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(471, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(390, 1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(309, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(3, 6);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(89, 12);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "物料编码前缀：";
            // 
            // txtMatchBillno
            // 
            this.txtMatchBillno.Location = new System.Drawing.Point(98, 3);
            this.txtMatchBillno.Name = "txtMatchBillno";
            this.txtMatchBillno.Size = new System.Drawing.Size(99, 21);
            this.txtMatchBillno.TabIndex = 1;
            this.txtMatchBillno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatchBillno_KeyPress);
            // 
            // ucCS_OutStockMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.pl1);
            this.Name = "ucCS_OutStockMaterial";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucCS_OutStockMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.pl1.ResumeLayout(false);
            this.pl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Panel pl1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtMatchBillno;
        private System.Windows.Forms.RadioButton rbtNotMatch;
        private System.Windows.Forms.RadioButton rbtMatch;
    }
}

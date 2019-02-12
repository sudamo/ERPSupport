namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucExpressCompany
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
            this.lblTittle = new System.Windows.Forms.Label();
            this.pl1 = new System.Windows.Forms.Panel();
            this.lblPP = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblMatchBillno = new System.Windows.Forms.Label();
            this.lblWildcard = new System.Windows.Forms.Label();
            this.txtECPY = new System.Windows.Forms.TextBox();
            this.txtMatchBillno = new System.Windows.Forms.TextBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.pl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTittle
            // 
            this.lblTittle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTittle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTittle.Location = new System.Drawing.Point(0, 0);
            this.lblTittle.Name = "lblTittle";
            this.lblTittle.Size = new System.Drawing.Size(1024, 23);
            this.lblTittle.TabIndex = 0;
            this.lblTittle.Text = "运单号与快递公司设置";
            this.lblTittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pl1
            // 
            this.pl1.Controls.Add(this.lblPP);
            this.pl1.Controls.Add(this.txtNumber);
            this.pl1.Controls.Add(this.lblTittle);
            this.pl1.Controls.Add(this.btnDelete);
            this.pl1.Controls.Add(this.btnEdit);
            this.pl1.Controls.Add(this.btnAdd);
            this.pl1.Controls.Add(this.lblCompany);
            this.pl1.Controls.Add(this.lblMatchBillno);
            this.pl1.Controls.Add(this.lblWildcard);
            this.pl1.Controls.Add(this.txtECPY);
            this.pl1.Controls.Add(this.txtMatchBillno);
            this.pl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl1.Location = new System.Drawing.Point(0, 0);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(1024, 50);
            this.pl1.TabIndex = 3;
            // 
            // lblPP
            // 
            this.lblPP.AutoSize = true;
            this.lblPP.Location = new System.Drawing.Point(191, 29);
            this.lblPP.Name = "lblPP";
            this.lblPP.Size = new System.Drawing.Size(11, 12);
            this.lblPP.TabIndex = 7;
            this.lblPP.Text = "*";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(255, 26);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(57, 21);
            this.txtNumber.TabIndex = 6;
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(710, 24);
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
            this.btnEdit.Location = new System.Drawing.Point(629, 24);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(548, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(318, 29);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(65, 12);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "快递公司：";
            // 
            // lblMatchBillno
            // 
            this.lblMatchBillno.AutoSize = true;
            this.lblMatchBillno.Location = new System.Drawing.Point(3, 29);
            this.lblMatchBillno.Name = "lblMatchBillno";
            this.lblMatchBillno.Size = new System.Drawing.Size(77, 12);
            this.lblMatchBillno.TabIndex = 0;
            this.lblMatchBillno.Text = "匹配运单号：";
            // 
            // lblWildcard
            // 
            this.lblWildcard.AutoSize = true;
            this.lblWildcard.Location = new System.Drawing.Point(208, 27);
            this.lblWildcard.Name = "lblWildcard";
            this.lblWildcard.Size = new System.Drawing.Size(41, 12);
            this.lblWildcard.TabIndex = 0;
            this.lblWildcard.Text = "位数：";
            // 
            // txtECPY
            // 
            this.txtECPY.Location = new System.Drawing.Point(389, 26);
            this.txtECPY.Name = "txtECPY";
            this.txtECPY.Size = new System.Drawing.Size(153, 21);
            this.txtECPY.TabIndex = 2;
            // 
            // txtMatchBillno
            // 
            this.txtMatchBillno.Location = new System.Drawing.Point(86, 26);
            this.txtMatchBillno.Name = "txtMatchBillno";
            this.txtMatchBillno.Size = new System.Drawing.Size(99, 21);
            this.txtMatchBillno.TabIndex = 1;
            this.txtMatchBillno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatchBillno_KeyPress);
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
            this.dgv1.Location = new System.Drawing.Point(5, 53);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(1016, 712);
            this.dgv1.TabIndex = 4;
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // ucExpressCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.pl1);
            this.Name = "ucExpressCompany";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucExpressCompany_Load);
            this.pl1.ResumeLayout(false);
            this.pl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTittle;
        private System.Windows.Forms.Panel pl1;
        private System.Windows.Forms.Label lblMatchBillno;
        private System.Windows.Forms.Label lblWildcard;
        private System.Windows.Forms.TextBox txtMatchBillno;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.TextBox txtECPY;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblPP;
    }
}

namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucUser
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
            this.btnSave = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.libOwn = new System.Windows.Forms.ListBox();
            this.libRole = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbRole = new System.Windows.Forms.GroupBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblOwn = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.grbRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 10F);
            this.btnSave.Location = new System.Drawing.Point(9, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(3, 65);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(291, 395);
            this.dgv1.TabIndex = 2;
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(720, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "用户管理";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // libOwn
            // 
            this.libOwn.Font = new System.Drawing.Font("宋体", 12F);
            this.libOwn.FormattingEnabled = true;
            this.libOwn.ItemHeight = 16;
            this.libOwn.Location = new System.Drawing.Point(6, 44);
            this.libOwn.Name = "libOwn";
            this.libOwn.Size = new System.Drawing.Size(120, 340);
            this.libOwn.TabIndex = 4;
            // 
            // libRole
            // 
            this.libRole.Font = new System.Drawing.Font("宋体", 12F);
            this.libRole.FormattingEnabled = true;
            this.libRole.ItemHeight = 16;
            this.libRole.Location = new System.Drawing.Point(173, 44);
            this.libRole.Name = "libRole";
            this.libRole.Size = new System.Drawing.Size(120, 340);
            this.libRole.TabIndex = 7;
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("宋体", 9F);
            this.btnRemove.Location = new System.Drawing.Point(132, 199);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(35, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "->";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("宋体", 9F);
            this.btnAdd.Location = new System.Drawing.Point(132, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "<-";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grbRole
            // 
            this.grbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbRole.Controls.Add(this.lblRole);
            this.grbRole.Controls.Add(this.lblOwn);
            this.grbRole.Controls.Add(this.libOwn);
            this.grbRole.Controls.Add(this.btnAdd);
            this.grbRole.Controls.Add(this.btnSave);
            this.grbRole.Controls.Add(this.libRole);
            this.grbRole.Controls.Add(this.btnRemove);
            this.grbRole.Font = new System.Drawing.Font("宋体", 14F);
            this.grbRole.Location = new System.Drawing.Point(300, 40);
            this.grbRole.Name = "grbRole";
            this.grbRole.Size = new System.Drawing.Size(320, 420);
            this.grbRole.TabIndex = 3;
            this.grbRole.TabStop = false;
            this.grbRole.Text = "用户";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("宋体", 12F);
            this.lblRole.Location = new System.Drawing.Point(170, 25);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(40, 16);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "角色";
            // 
            // lblOwn
            // 
            this.lblOwn.AutoSize = true;
            this.lblOwn.Font = new System.Drawing.Font("宋体", 12F);
            this.lblOwn.Location = new System.Drawing.Point(6, 25);
            this.lblOwn.Name = "lblOwn";
            this.lblOwn.Size = new System.Drawing.Size(88, 16);
            this.lblOwn.TabIndex = 6;
            this.lblOwn.Text = "已分配角色";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(99, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(88, 21);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 12);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "根据姓名定位：";
            // 
            // ucUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.grbRole);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgv1);
            this.Name = "ucUser";
            this.Size = new System.Drawing.Size(720, 480);
            this.Load += new System.EventHandler(this.ucUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.grbRole.ResumeLayout(false);
            this.grbRole.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox libOwn;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox libRole;
        private System.Windows.Forms.GroupBox grbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblOwn;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
    }
}

namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucSM_UserAcc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSM_UserAcc));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pl1 = new System.Windows.Forms.Panel();
            this.pl3 = new System.Windows.Forms.Panel();
            this.chbOccupy = new System.Windows.Forms.CheckBox();
            this.chbExport = new System.Windows.Forms.CheckBox();
            this.chbImport = new System.Windows.Forms.CheckBox();
            this.chbTimerPick = new System.Windows.Forms.CheckBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.trv1 = new System.Windows.Forms.TreeView();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblUserList = new System.Windows.Forms.Label();
            this.pl1.SuspendLayout();
            this.pl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(880, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "权限管理";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pl1
            // 
            this.pl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pl1.Controls.Add(this.pl3);
            this.pl1.Controls.Add(this.lblPrompt);
            this.pl1.Controls.Add(this.txtRoleName);
            this.pl1.Controls.Add(this.trv1);
            this.pl1.Controls.Add(this.dgv1);
            this.pl1.Controls.Add(this.btnAdd);
            this.pl1.Controls.Add(this.btnSave);
            this.pl1.Controls.Add(this.btnDelete);
            this.pl1.Location = new System.Drawing.Point(4, 48);
            this.pl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(659, 624);
            this.pl1.TabIndex = 1;
            // 
            // pl3
            // 
            this.pl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pl3.Controls.Add(this.chbOccupy);
            this.pl3.Controls.Add(this.chbExport);
            this.pl3.Controls.Add(this.chbImport);
            this.pl3.Controls.Add(this.chbTimerPick);
            this.pl3.Location = new System.Drawing.Point(512, 35);
            this.pl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pl3.Name = "pl3";
            this.pl3.Size = new System.Drawing.Size(143, 575);
            this.pl3.TabIndex = 5;
            // 
            // chbOccupy
            // 
            this.chbOccupy.AutoSize = true;
            this.chbOccupy.Location = new System.Drawing.Point(4, 4);
            this.chbOccupy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbOccupy.Name = "chbOccupy";
            this.chbOccupy.Size = new System.Drawing.Size(89, 19);
            this.chbOccupy.TabIndex = 0;
            this.chbOccupy.Text = "占用解除";
            this.chbOccupy.UseVisualStyleBackColor = true;
            // 
            // chbExport
            // 
            this.chbExport.AutoSize = true;
            this.chbExport.Enabled = false;
            this.chbExport.Location = new System.Drawing.Point(4, 174);
            this.chbExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbExport.Name = "chbExport";
            this.chbExport.Size = new System.Drawing.Size(89, 19);
            this.chbExport.TabIndex = 3;
            this.chbExport.Text = "导出报表";
            this.chbExport.UseVisualStyleBackColor = true;
            // 
            // chbImport
            // 
            this.chbImport.AutoSize = true;
            this.chbImport.Enabled = false;
            this.chbImport.Location = new System.Drawing.Point(4, 146);
            this.chbImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbImport.Name = "chbImport";
            this.chbImport.Size = new System.Drawing.Size(89, 19);
            this.chbImport.TabIndex = 2;
            this.chbImport.Text = "导入报表";
            this.chbImport.UseVisualStyleBackColor = true;
            // 
            // chbTimerPick
            // 
            this.chbTimerPick.AutoSize = true;
            this.chbTimerPick.Location = new System.Drawing.Point(4, 31);
            this.chbTimerPick.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chbTimerPick.Name = "chbTimerPick";
            this.chbTimerPick.Size = new System.Drawing.Size(89, 19);
            this.chbTimerPick.TabIndex = 1;
            this.chbTimerPick.Text = "定时领料";
            this.chbTimerPick.UseVisualStyleBackColor = true;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.ForeColor = System.Drawing.Color.Red;
            this.lblPrompt.Location = new System.Drawing.Point(267, 10);
            this.lblPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(0, 15);
            this.lblPrompt.TabIndex = 3;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(4, 6);
            this.txtRoleName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(145, 25);
            this.txtRoleName.TabIndex = 0;
            // 
            // trv1
            // 
            this.trv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trv1.Location = new System.Drawing.Point(157, 35);
            this.trv1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trv1.Name = "trv1";
            this.trv1.Size = new System.Drawing.Size(345, 574);
            this.trv1.TabIndex = 5;
            this.trv1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trv1_AfterCheck);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(4, 35);
            this.dgv1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(147, 575);
            this.dgv1.TabIndex = 2;
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(157, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "创建角色";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(447, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存方案";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(555, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 29);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除方案";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "widescreen.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "folder_star.png");
            this.imageList1.Images.SetKeyName(3, "folder_wrench.png");
            this.imageList1.Images.SetKeyName(4, "folder_key.png");
            this.imageList1.Images.SetKeyName(5, "folder_table.png");
            this.imageList1.Images.SetKeyName(6, "widgets.png");
            this.imageList1.Images.SetKeyName(7, "box.png");
            this.imageList1.Images.SetKeyName(8, "bug.png");
            this.imageList1.Images.SetKeyName(9, "burro.png");
            this.imageList1.Images.SetKeyName(10, "butterfly.png");
            this.imageList1.Images.SetKeyName(11, "aol_mail.png");
            this.imageList1.Images.SetKeyName(12, "chefs_hat.png");
            this.imageList1.Images.SetKeyName(13, "flower.png");
            this.imageList1.Images.SetKeyName(14, "align_center.png");
            this.imageList1.Images.SetKeyName(15, "align_left.png");
            this.imageList1.Images.SetKeyName(16, "align_right.png");
            this.imageList1.Images.SetKeyName(17, "column_four.png");
            this.imageList1.Images.SetKeyName(18, "column_left.png");
            this.imageList1.Images.SetKeyName(19, "column_one.png");
            this.imageList1.Images.SetKeyName(20, "column_right.png");
            this.imageList1.Images.SetKeyName(21, "notebook.png");
            this.imageList1.Images.SetKeyName(22, "account_balances.png");
            this.imageList1.Images.SetKeyName(23, "administrator.png");
            this.imageList1.Images.SetKeyName(24, "angel.png");
            // 
            // lblUserList
            // 
            this.lblUserList.AutoSize = true;
            this.lblUserList.Font = new System.Drawing.Font("宋体", 10F);
            this.lblUserList.Location = new System.Drawing.Point(667, 82);
            this.lblUserList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserList.Name = "lblUserList";
            this.lblUserList.Size = new System.Drawing.Size(93, 17);
            this.lblUserList.TabIndex = 2;
            this.lblUserList.Text = "分配用户：";
            // 
            // ucSM_UserAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUserList);
            this.Controls.Add(this.pl1);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucSM_UserAcc";
            this.Size = new System.Drawing.Size(880, 675);
            this.Load += new System.EventHandler(this.ucMS_UserAcc_Load);
            this.pl1.ResumeLayout(false);
            this.pl1.PerformLayout();
            this.pl3.ResumeLayout(false);
            this.pl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pl1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TreeView trv1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUserList;
        private System.Windows.Forms.CheckBox chbTimerPick;
        private System.Windows.Forms.CheckBox chbOccupy;
        private System.Windows.Forms.Panel pl3;
        private System.Windows.Forms.CheckBox chbExport;
        private System.Windows.Forms.CheckBox chbImport;
    }
}

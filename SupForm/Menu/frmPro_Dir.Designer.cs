namespace ERPSupport.SupForm.Menu
{
    partial class frmPro_Dir
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPro_Dir));
            this.gbxDirType = new System.Windows.Forms.GroupBox();
            this.rbtWMS = new System.Windows.Forms.RadioButton();
            this.rbtERP = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbxDB_WMS = new System.Windows.Forms.GroupBox();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtCatalog = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblPWD = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblCatalog = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.gbxDirType.SuspendLayout();
            this.gbxDB_WMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDirType
            // 
            this.gbxDirType.Controls.Add(this.rbtWMS);
            this.gbxDirType.Controls.Add(this.rbtERP);
            this.gbxDirType.Location = new System.Drawing.Point(312, 13);
            this.gbxDirType.Name = "gbxDirType";
            this.gbxDirType.Size = new System.Drawing.Size(260, 50);
            this.gbxDirType.TabIndex = 0;
            this.gbxDirType.TabStop = false;
            this.gbxDirType.Text = "调拨方向";
            // 
            // rbtWMS
            // 
            this.rbtWMS.AutoSize = true;
            this.rbtWMS.Location = new System.Drawing.Point(120, 20);
            this.rbtWMS.Name = "rbtWMS";
            this.rbtWMS.Size = new System.Drawing.Size(41, 16);
            this.rbtWMS.TabIndex = 0;
            this.rbtWMS.TabStop = true;
            this.rbtWMS.Text = "WMS";
            this.rbtWMS.UseVisualStyleBackColor = true;
            // 
            // rbtERP
            // 
            this.rbtERP.AutoSize = true;
            this.rbtERP.Location = new System.Drawing.Point(40, 20);
            this.rbtERP.Name = "rbtERP";
            this.rbtERP.Size = new System.Drawing.Size(41, 16);
            this.rbtERP.TabIndex = 0;
            this.rbtERP.TabStop = true;
            this.rbtERP.Text = "ERP";
            this.rbtERP.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(200, 418);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "确定(&OK)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(300, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbxDB_WMS
            // 
            this.gbxDB_WMS.Controls.Add(this.txtPWD);
            this.gbxDB_WMS.Controls.Add(this.txtUser);
            this.gbxDB_WMS.Controls.Add(this.txtCatalog);
            this.gbxDB_WMS.Controls.Add(this.txtIP);
            this.gbxDB_WMS.Controls.Add(this.lblPWD);
            this.gbxDB_WMS.Controls.Add(this.lblUser);
            this.gbxDB_WMS.Controls.Add(this.lblCatalog);
            this.gbxDB_WMS.Controls.Add(this.lblIP);
            this.gbxDB_WMS.Location = new System.Drawing.Point(12, 13);
            this.gbxDB_WMS.Name = "gbxDB_WMS";
            this.gbxDB_WMS.Size = new System.Drawing.Size(260, 131);
            this.gbxDB_WMS.TabIndex = 2;
            this.gbxDB_WMS.TabStop = false;
            this.gbxDB_WMS.Text = "WMS数据库配置";
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(53, 100);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(177, 21);
            this.txtPWD.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(53, 73);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(177, 21);
            this.txtUser.TabIndex = 1;
            // 
            // txtCatalog
            // 
            this.txtCatalog.Location = new System.Drawing.Point(53, 46);
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(177, 21);
            this.txtCatalog.TabIndex = 1;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(53, 19);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(177, 21);
            this.txtIP.TabIndex = 1;
            // 
            // lblPWD
            // 
            this.lblPWD.AutoSize = true;
            this.lblPWD.Location = new System.Drawing.Point(18, 103);
            this.lblPWD.Name = "lblPWD";
            this.lblPWD.Size = new System.Drawing.Size(29, 12);
            this.lblPWD.TabIndex = 0;
            this.lblPWD.Text = "密码";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(18, 76);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 12);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "用户";
            // 
            // lblCatalog
            // 
            this.lblCatalog.AutoSize = true;
            this.lblCatalog.Location = new System.Drawing.Point(6, 49);
            this.lblCatalog.Name = "lblCatalog";
            this.lblCatalog.Size = new System.Drawing.Size(41, 12);
            this.lblCatalog.TabIndex = 0;
            this.lblCatalog.Text = "数据库";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(18, 22);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(29, 12);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "地址";
            // 
            // frmPro_Dir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 442);
            this.Controls.Add(this.gbxDB_WMS);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbxDirType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 480);
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "frmPro_Dir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "调拨单选项";
            this.Load += new System.EventHandler(this.frmPro_Dir_Load);
            this.gbxDirType.ResumeLayout(false);
            this.gbxDirType.PerformLayout();
            this.gbxDB_WMS.ResumeLayout(false);
            this.gbxDB_WMS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxDirType;
        private System.Windows.Forms.RadioButton rbtWMS;
        private System.Windows.Forms.RadioButton rbtERP;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbxDB_WMS;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtPWD;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtCatalog;
        private System.Windows.Forms.Label lblPWD;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblCatalog;
    }
}
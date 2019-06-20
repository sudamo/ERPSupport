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
            this.gbxPenZi = new System.Windows.Forms.GroupBox();
            this.lblUnit2 = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.chbIsUsePZ = new System.Windows.Forms.CheckBox();
            this.txtPianYiPZ = new System.Windows.Forms.TextBox();
            this.txtMaxQtyPZ = new System.Windows.Forms.TextBox();
            this.lblPianYiPZ = new System.Windows.Forms.Label();
            this.lblMaxQtyPZ = new System.Windows.Forms.Label();
            this.gbxCaiLiao = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUnit3 = new System.Windows.Forms.Label();
            this.chbIsUseCL = new System.Windows.Forms.CheckBox();
            this.txtPianYiCL = new System.Windows.Forms.TextBox();
            this.txtMaxQtyCL = new System.Windows.Forms.TextBox();
            this.lblPianYiCL = new System.Windows.Forms.Label();
            this.lblMaxQtyCL = new System.Windows.Forms.Label();
            this.gbxDirType.SuspendLayout();
            this.gbxDB_WMS.SuspendLayout();
            this.gbxPenZi.SuspendLayout();
            this.gbxCaiLiao.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDirType
            // 
            this.gbxDirType.Controls.Add(this.rbtWMS);
            this.gbxDirType.Controls.Add(this.rbtERP);
            this.gbxDirType.Location = new System.Drawing.Point(371, 16);
            this.gbxDirType.Margin = new System.Windows.Forms.Padding(4);
            this.gbxDirType.Name = "gbxDirType";
            this.gbxDirType.Padding = new System.Windows.Forms.Padding(4);
            this.gbxDirType.Size = new System.Drawing.Size(348, 62);
            this.gbxDirType.TabIndex = 0;
            this.gbxDirType.TabStop = false;
            this.gbxDirType.Text = "调拨方向";
            // 
            // rbtWMS
            // 
            this.rbtWMS.AutoSize = true;
            this.rbtWMS.Location = new System.Drawing.Point(160, 25);
            this.rbtWMS.Margin = new System.Windows.Forms.Padding(4);
            this.rbtWMS.Name = "rbtWMS";
            this.rbtWMS.Size = new System.Drawing.Size(52, 19);
            this.rbtWMS.TabIndex = 0;
            this.rbtWMS.TabStop = true;
            this.rbtWMS.Text = "WMS";
            this.rbtWMS.UseVisualStyleBackColor = true;
            // 
            // rbtERP
            // 
            this.rbtERP.AutoSize = true;
            this.rbtERP.Location = new System.Drawing.Point(53, 25);
            this.rbtERP.Margin = new System.Windows.Forms.Padding(4);
            this.rbtERP.Name = "rbtERP";
            this.rbtERP.Size = new System.Drawing.Size(52, 19);
            this.rbtERP.TabIndex = 0;
            this.rbtERP.TabStop = true;
            this.rbtERP.Text = "ERP";
            this.rbtERP.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(263, 411);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "确定(&OK)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 411);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
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
            this.gbxDB_WMS.Location = new System.Drawing.Point(16, 16);
            this.gbxDB_WMS.Margin = new System.Windows.Forms.Padding(4);
            this.gbxDB_WMS.Name = "gbxDB_WMS";
            this.gbxDB_WMS.Padding = new System.Windows.Forms.Padding(4);
            this.gbxDB_WMS.Size = new System.Drawing.Size(347, 164);
            this.gbxDB_WMS.TabIndex = 2;
            this.gbxDB_WMS.TabStop = false;
            this.gbxDB_WMS.Text = "WMS数据库配置";
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(71, 125);
            this.txtPWD.Margin = new System.Windows.Forms.Padding(4);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(235, 25);
            this.txtPWD.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(71, 91);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(235, 25);
            this.txtUser.TabIndex = 1;
            // 
            // txtCatalog
            // 
            this.txtCatalog.Location = new System.Drawing.Point(71, 58);
            this.txtCatalog.Margin = new System.Windows.Forms.Padding(4);
            this.txtCatalog.Name = "txtCatalog";
            this.txtCatalog.Size = new System.Drawing.Size(235, 25);
            this.txtCatalog.TabIndex = 1;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(71, 24);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(235, 25);
            this.txtIP.TabIndex = 1;
            // 
            // lblPWD
            // 
            this.lblPWD.AutoSize = true;
            this.lblPWD.Location = new System.Drawing.Point(24, 129);
            this.lblPWD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPWD.Name = "lblPWD";
            this.lblPWD.Size = new System.Drawing.Size(37, 15);
            this.lblPWD.TabIndex = 0;
            this.lblPWD.Text = "密码";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(24, 95);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(37, 15);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "用户";
            // 
            // lblCatalog
            // 
            this.lblCatalog.AutoSize = true;
            this.lblCatalog.Location = new System.Drawing.Point(8, 61);
            this.lblCatalog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCatalog.Name = "lblCatalog";
            this.lblCatalog.Size = new System.Drawing.Size(52, 15);
            this.lblCatalog.TabIndex = 0;
            this.lblCatalog.Text = "数据库";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(24, 28);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(37, 15);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "地址";
            // 
            // gbxPenZi
            // 
            this.gbxPenZi.Controls.Add(this.lblUnit2);
            this.gbxPenZi.Controls.Add(this.lblUnit);
            this.gbxPenZi.Controls.Add(this.chbIsUsePZ);
            this.gbxPenZi.Controls.Add(this.txtPianYiPZ);
            this.gbxPenZi.Controls.Add(this.txtMaxQtyPZ);
            this.gbxPenZi.Controls.Add(this.lblPianYiPZ);
            this.gbxPenZi.Controls.Add(this.lblMaxQtyPZ);
            this.gbxPenZi.Location = new System.Drawing.Point(371, 85);
            this.gbxPenZi.Name = "gbxPenZi";
            this.gbxPenZi.Size = new System.Drawing.Size(348, 95);
            this.gbxPenZi.TabIndex = 3;
            this.gbxPenZi.TabStop = false;
            this.gbxPenZi.Text = "盆子调拨设置";
            // 
            // lblUnit2
            // 
            this.lblUnit2.AutoSize = true;
            this.lblUnit2.Location = new System.Drawing.Point(227, 66);
            this.lblUnit2.Name = "lblUnit2";
            this.lblUnit2.Size = new System.Drawing.Size(38, 15);
            this.lblUnit2.TabIndex = 3;
            this.lblUnit2.Text = "(套)";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(227, 35);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(38, 15);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "(套)";
            // 
            // chbIsUsePZ
            // 
            this.chbIsUsePZ.AutoSize = true;
            this.chbIsUsePZ.Location = new System.Drawing.Point(271, 34);
            this.chbIsUsePZ.Name = "chbIsUsePZ";
            this.chbIsUsePZ.Size = new System.Drawing.Size(59, 19);
            this.chbIsUsePZ.TabIndex = 2;
            this.chbIsUsePZ.Text = "启用";
            this.chbIsUsePZ.UseVisualStyleBackColor = true;
            this.chbIsUsePZ.CheckedChanged += new System.EventHandler(this.chbIsUse_CheckedChanged);
            // 
            // txtPianYiPZ
            // 
            this.txtPianYiPZ.Location = new System.Drawing.Point(141, 63);
            this.txtPianYiPZ.Name = "txtPianYiPZ";
            this.txtPianYiPZ.Size = new System.Drawing.Size(80, 25);
            this.txtPianYiPZ.TabIndex = 1;
            this.txtPianYiPZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtMaxQtyPZ
            // 
            this.txtMaxQtyPZ.Location = new System.Drawing.Point(141, 32);
            this.txtMaxQtyPZ.Name = "txtMaxQtyPZ";
            this.txtMaxQtyPZ.Size = new System.Drawing.Size(80, 25);
            this.txtMaxQtyPZ.TabIndex = 1;
            this.txtMaxQtyPZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lblPianYiPZ
            // 
            this.lblPianYiPZ.AutoSize = true;
            this.lblPianYiPZ.Location = new System.Drawing.Point(53, 66);
            this.lblPianYiPZ.Name = "lblPianYiPZ";
            this.lblPianYiPZ.Size = new System.Drawing.Size(82, 15);
            this.lblPianYiPZ.TabIndex = 0;
            this.lblPianYiPZ.Text = "偏移数量：";
            // 
            // lblMaxQtyPZ
            // 
            this.lblMaxQtyPZ.AutoSize = true;
            this.lblMaxQtyPZ.Location = new System.Drawing.Point(8, 35);
            this.lblMaxQtyPZ.Name = "lblMaxQtyPZ";
            this.lblMaxQtyPZ.Size = new System.Drawing.Size(127, 15);
            this.lblMaxQtyPZ.TabIndex = 0;
            this.lblMaxQtyPZ.Text = "每张单最大数量：";
            // 
            // gbxCaiLiao
            // 
            this.gbxCaiLiao.Controls.Add(this.label3);
            this.gbxCaiLiao.Controls.Add(this.lblUnit3);
            this.gbxCaiLiao.Controls.Add(this.chbIsUseCL);
            this.gbxCaiLiao.Controls.Add(this.txtPianYiCL);
            this.gbxCaiLiao.Controls.Add(this.txtMaxQtyCL);
            this.gbxCaiLiao.Controls.Add(this.lblPianYiCL);
            this.gbxCaiLiao.Controls.Add(this.lblMaxQtyCL);
            this.gbxCaiLiao.Location = new System.Drawing.Point(371, 186);
            this.gbxCaiLiao.Name = "gbxCaiLiao";
            this.gbxCaiLiao.Size = new System.Drawing.Size(348, 109);
            this.gbxCaiLiao.TabIndex = 6;
            this.gbxCaiLiao.TabStop = false;
            this.gbxCaiLiao.Text = "材料调拨设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "(行)";
            // 
            // lblUnit3
            // 
            this.lblUnit3.AutoSize = true;
            this.lblUnit3.Location = new System.Drawing.Point(227, 45);
            this.lblUnit3.Name = "lblUnit3";
            this.lblUnit3.Size = new System.Drawing.Size(38, 15);
            this.lblUnit3.TabIndex = 3;
            this.lblUnit3.Text = "(行)";
            // 
            // chbIsUseCL
            // 
            this.chbIsUseCL.AutoSize = true;
            this.chbIsUseCL.Location = new System.Drawing.Point(271, 44);
            this.chbIsUseCL.Name = "chbIsUseCL";
            this.chbIsUseCL.Size = new System.Drawing.Size(59, 19);
            this.chbIsUseCL.TabIndex = 7;
            this.chbIsUseCL.Text = "启用";
            this.chbIsUseCL.UseVisualStyleBackColor = true;
            this.chbIsUseCL.CheckedChanged += new System.EventHandler(this.chbIsUseCL_CheckedChanged);
            // 
            // txtPianYiCL
            // 
            this.txtPianYiCL.Location = new System.Drawing.Point(139, 73);
            this.txtPianYiCL.Name = "txtPianYiCL";
            this.txtPianYiCL.Size = new System.Drawing.Size(82, 25);
            this.txtPianYiCL.TabIndex = 5;
            this.txtPianYiCL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtMaxQtyCL
            // 
            this.txtMaxQtyCL.Location = new System.Drawing.Point(139, 42);
            this.txtMaxQtyCL.Name = "txtMaxQtyCL";
            this.txtMaxQtyCL.Size = new System.Drawing.Size(82, 25);
            this.txtMaxQtyCL.TabIndex = 6;
            this.txtMaxQtyCL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lblPianYiCL
            // 
            this.lblPianYiCL.AutoSize = true;
            this.lblPianYiCL.Location = new System.Drawing.Point(51, 76);
            this.lblPianYiCL.Name = "lblPianYiCL";
            this.lblPianYiCL.Size = new System.Drawing.Size(82, 15);
            this.lblPianYiCL.TabIndex = 3;
            this.lblPianYiCL.Text = "偏移数量：";
            // 
            // lblMaxQtyCL
            // 
            this.lblMaxQtyCL.AutoSize = true;
            this.lblMaxQtyCL.Location = new System.Drawing.Point(6, 45);
            this.lblMaxQtyCL.Name = "lblMaxQtyCL";
            this.lblMaxQtyCL.Size = new System.Drawing.Size(127, 15);
            this.lblMaxQtyCL.TabIndex = 4;
            this.lblMaxQtyCL.Text = "每张单最大数量：";
            // 
            // frmPro_Dir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 453);
            this.Controls.Add(this.gbxCaiLiao);
            this.Controls.Add(this.gbxPenZi);
            this.Controls.Add(this.gbxDB_WMS);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbxDirType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(750, 500);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmPro_Dir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "调拨单选项";
            this.Load += new System.EventHandler(this.frmPro_Dir_Load);
            this.gbxDirType.ResumeLayout(false);
            this.gbxDirType.PerformLayout();
            this.gbxDB_WMS.ResumeLayout(false);
            this.gbxDB_WMS.PerformLayout();
            this.gbxPenZi.ResumeLayout(false);
            this.gbxPenZi.PerformLayout();
            this.gbxCaiLiao.ResumeLayout(false);
            this.gbxCaiLiao.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbxPenZi;
        private System.Windows.Forms.CheckBox chbIsUsePZ;
        private System.Windows.Forms.TextBox txtPianYiPZ;
        private System.Windows.Forms.TextBox txtMaxQtyPZ;
        private System.Windows.Forms.Label lblPianYiPZ;
        private System.Windows.Forms.Label lblMaxQtyPZ;
        private System.Windows.Forms.GroupBox gbxCaiLiao;
        private System.Windows.Forms.CheckBox chbIsUseCL;
        private System.Windows.Forms.TextBox txtPianYiCL;
        private System.Windows.Forms.TextBox txtMaxQtyCL;
        private System.Windows.Forms.Label lblPianYiCL;
        private System.Windows.Forms.Label lblMaxQtyCL;
        private System.Windows.Forms.Label lblUnit2;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUnit3;
    }
}
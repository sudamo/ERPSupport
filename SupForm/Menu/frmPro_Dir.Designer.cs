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
            this.lblUnit4 = new System.Windows.Forms.Label();
            this.lblUnit3 = new System.Windows.Forms.Label();
            this.txtMinQtyPZ = new System.Windows.Forms.TextBox();
            this.txtDPQtyPZ = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblDPQtyPZ = new System.Windows.Forms.Label();
            this.lblUnit2 = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.chbIsUsePZ = new System.Windows.Forms.CheckBox();
            this.txtPianYiPZ = new System.Windows.Forms.TextBox();
            this.txtMaxQtyPZ = new System.Windows.Forms.TextBox();
            this.lblPianYiPZ = new System.Windows.Forms.Label();
            this.lblMaxQtyPZ = new System.Windows.Forms.Label();
            this.gbxCaiLiao = new System.Windows.Forms.GroupBox();
            this.lblUnit6 = new System.Windows.Forms.Label();
            this.lblUnit5 = new System.Windows.Forms.Label();
            this.chbIsUseCL = new System.Windows.Forms.CheckBox();
            this.txtPianYiCL = new System.Windows.Forms.TextBox();
            this.txtMaxQtyCL = new System.Windows.Forms.TextBox();
            this.lblPianYiCL = new System.Windows.Forms.Label();
            this.lblMaxQtyCL = new System.Windows.Forms.Label();
            this.gbxCPDB_Default = new System.Windows.Forms.GroupBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.cbxStock = new System.Windows.Forms.ComboBox();
            this.gbxDirType.SuspendLayout();
            this.gbxDB_WMS.SuspendLayout();
            this.gbxPenZi.SuspendLayout();
            this.gbxCaiLiao.SuspendLayout();
            this.gbxCPDB_Default.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDirType
            // 
            this.gbxDirType.Controls.Add(this.rbtWMS);
            this.gbxDirType.Controls.Add(this.rbtERP);
            this.gbxDirType.Enabled = false;
            this.gbxDirType.Location = new System.Drawing.Point(278, 12);
            this.gbxDirType.Name = "gbxDirType";
            this.gbxDirType.Size = new System.Drawing.Size(225, 50);
            this.gbxDirType.TabIndex = 0;
            this.gbxDirType.TabStop = false;
            this.gbxDirType.Text = "调拨方向";
            // 
            // rbtWMS
            // 
            this.rbtWMS.AutoSize = true;
            this.rbtWMS.Checked = true;
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
            this.rbtERP.Text = "ERP";
            this.rbtERP.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(182, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "确定(&OK)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(278, 346);
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
            this.gbxDB_WMS.Location = new System.Drawing.Point(12, 12);
            this.gbxDB_WMS.Name = "gbxDB_WMS";
            this.gbxDB_WMS.Size = new System.Drawing.Size(245, 130);
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
            // gbxPenZi
            // 
            this.gbxPenZi.Controls.Add(this.lblUnit4);
            this.gbxPenZi.Controls.Add(this.lblUnit3);
            this.gbxPenZi.Controls.Add(this.txtMinQtyPZ);
            this.gbxPenZi.Controls.Add(this.txtDPQtyPZ);
            this.gbxPenZi.Controls.Add(this.lblMin);
            this.gbxPenZi.Controls.Add(this.lblDPQtyPZ);
            this.gbxPenZi.Controls.Add(this.lblUnit2);
            this.gbxPenZi.Controls.Add(this.lblUnit);
            this.gbxPenZi.Controls.Add(this.chbIsUsePZ);
            this.gbxPenZi.Controls.Add(this.txtPianYiPZ);
            this.gbxPenZi.Controls.Add(this.txtMaxQtyPZ);
            this.gbxPenZi.Controls.Add(this.lblPianYiPZ);
            this.gbxPenZi.Controls.Add(this.lblMaxQtyPZ);
            this.gbxPenZi.Location = new System.Drawing.Point(278, 67);
            this.gbxPenZi.Margin = new System.Windows.Forms.Padding(2);
            this.gbxPenZi.Name = "gbxPenZi";
            this.gbxPenZi.Padding = new System.Windows.Forms.Padding(2);
            this.gbxPenZi.Size = new System.Drawing.Size(225, 135);
            this.gbxPenZi.TabIndex = 3;
            this.gbxPenZi.TabStop = false;
            this.gbxPenZi.Text = "盆子调拨设置";
            // 
            // lblUnit4
            // 
            this.lblUnit4.AutoSize = true;
            this.lblUnit4.Location = new System.Drawing.Point(174, 109);
            this.lblUnit4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnit4.Name = "lblUnit4";
            this.lblUnit4.Size = new System.Drawing.Size(29, 12);
            this.lblUnit4.TabIndex = 13;
            this.lblUnit4.Text = "(套)";
            // 
            // lblUnit3
            // 
            this.lblUnit3.AutoSize = true;
            this.lblUnit3.Location = new System.Drawing.Point(174, 84);
            this.lblUnit3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnit3.Name = "lblUnit3";
            this.lblUnit3.Size = new System.Drawing.Size(29, 12);
            this.lblUnit3.TabIndex = 14;
            this.lblUnit3.Text = "(片)";
            // 
            // txtMinQtyPZ
            // 
            this.txtMinQtyPZ.Location = new System.Drawing.Point(109, 106);
            this.txtMinQtyPZ.Margin = new System.Windows.Forms.Padding(2);
            this.txtMinQtyPZ.Name = "txtMinQtyPZ";
            this.txtMinQtyPZ.Size = new System.Drawing.Size(61, 21);
            this.txtMinQtyPZ.TabIndex = 11;
            // 
            // txtDPQtyPZ
            // 
            this.txtDPQtyPZ.Location = new System.Drawing.Point(109, 81);
            this.txtDPQtyPZ.Margin = new System.Windows.Forms.Padding(2);
            this.txtDPQtyPZ.Name = "txtDPQtyPZ";
            this.txtDPQtyPZ.Size = new System.Drawing.Size(61, 21);
            this.txtDPQtyPZ.TabIndex = 12;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(16, 109);
            this.lblMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(89, 12);
            this.lblMin.TabIndex = 9;
            this.lblMin.Text = "大单统计数量：";
            // 
            // lblDPQtyPZ
            // 
            this.lblDPQtyPZ.AutoSize = true;
            this.lblDPQtyPZ.Location = new System.Drawing.Point(16, 84);
            this.lblDPQtyPZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDPQtyPZ.Name = "lblDPQtyPZ";
            this.lblDPQtyPZ.Size = new System.Drawing.Size(89, 12);
            this.lblDPQtyPZ.TabIndex = 10;
            this.lblDPQtyPZ.Text = "单片合计数量：";
            // 
            // lblUnit2
            // 
            this.lblUnit2.AutoSize = true;
            this.lblUnit2.Location = new System.Drawing.Point(174, 59);
            this.lblUnit2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnit2.Name = "lblUnit2";
            this.lblUnit2.Size = new System.Drawing.Size(29, 12);
            this.lblUnit2.TabIndex = 3;
            this.lblUnit2.Text = "(套)";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(174, 35);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 12);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "(套)";
            // 
            // chbIsUsePZ
            // 
            this.chbIsUsePZ.AutoSize = true;
            this.chbIsUsePZ.Location = new System.Drawing.Point(176, 17);
            this.chbIsUsePZ.Margin = new System.Windows.Forms.Padding(2);
            this.chbIsUsePZ.Name = "chbIsUsePZ";
            this.chbIsUsePZ.Size = new System.Drawing.Size(48, 16);
            this.chbIsUsePZ.TabIndex = 2;
            this.chbIsUsePZ.Text = "启用";
            this.chbIsUsePZ.UseVisualStyleBackColor = true;
            this.chbIsUsePZ.CheckedChanged += new System.EventHandler(this.chbIsUse_CheckedChanged);
            // 
            // txtPianYiPZ
            // 
            this.txtPianYiPZ.Location = new System.Drawing.Point(109, 56);
            this.txtPianYiPZ.Margin = new System.Windows.Forms.Padding(2);
            this.txtPianYiPZ.Name = "txtPianYiPZ";
            this.txtPianYiPZ.Size = new System.Drawing.Size(61, 21);
            this.txtPianYiPZ.TabIndex = 1;
            this.txtPianYiPZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtMaxQtyPZ
            // 
            this.txtMaxQtyPZ.Location = new System.Drawing.Point(109, 32);
            this.txtMaxQtyPZ.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaxQtyPZ.Name = "txtMaxQtyPZ";
            this.txtMaxQtyPZ.Size = new System.Drawing.Size(61, 21);
            this.txtMaxQtyPZ.TabIndex = 1;
            this.txtMaxQtyPZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lblPianYiPZ
            // 
            this.lblPianYiPZ.AutoSize = true;
            this.lblPianYiPZ.Location = new System.Drawing.Point(40, 59);
            this.lblPianYiPZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPianYiPZ.Name = "lblPianYiPZ";
            this.lblPianYiPZ.Size = new System.Drawing.Size(65, 12);
            this.lblPianYiPZ.TabIndex = 0;
            this.lblPianYiPZ.Text = "偏移数量：";
            // 
            // lblMaxQtyPZ
            // 
            this.lblMaxQtyPZ.AutoSize = true;
            this.lblMaxQtyPZ.Location = new System.Drawing.Point(4, 35);
            this.lblMaxQtyPZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxQtyPZ.Name = "lblMaxQtyPZ";
            this.lblMaxQtyPZ.Size = new System.Drawing.Size(101, 12);
            this.lblMaxQtyPZ.TabIndex = 0;
            this.lblMaxQtyPZ.Text = "每张单最大数量：";
            // 
            // gbxCaiLiao
            // 
            this.gbxCaiLiao.Controls.Add(this.lblUnit6);
            this.gbxCaiLiao.Controls.Add(this.lblUnit5);
            this.gbxCaiLiao.Controls.Add(this.chbIsUseCL);
            this.gbxCaiLiao.Controls.Add(this.txtPianYiCL);
            this.gbxCaiLiao.Controls.Add(this.txtMaxQtyCL);
            this.gbxCaiLiao.Controls.Add(this.lblPianYiCL);
            this.gbxCaiLiao.Controls.Add(this.lblMaxQtyCL);
            this.gbxCaiLiao.Enabled = false;
            this.gbxCaiLiao.Location = new System.Drawing.Point(278, 206);
            this.gbxCaiLiao.Margin = new System.Windows.Forms.Padding(2);
            this.gbxCaiLiao.Name = "gbxCaiLiao";
            this.gbxCaiLiao.Padding = new System.Windows.Forms.Padding(2);
            this.gbxCaiLiao.Size = new System.Drawing.Size(225, 90);
            this.gbxCaiLiao.TabIndex = 6;
            this.gbxCaiLiao.TabStop = false;
            this.gbxCaiLiao.Text = "材料调拨设置";
            // 
            // lblUnit6
            // 
            this.lblUnit6.AutoSize = true;
            this.lblUnit6.Location = new System.Drawing.Point(170, 61);
            this.lblUnit6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnit6.Name = "lblUnit6";
            this.lblUnit6.Size = new System.Drawing.Size(29, 12);
            this.lblUnit6.TabIndex = 3;
            this.lblUnit6.Text = "(行)";
            // 
            // lblUnit5
            // 
            this.lblUnit5.AutoSize = true;
            this.lblUnit5.Location = new System.Drawing.Point(170, 36);
            this.lblUnit5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnit5.Name = "lblUnit5";
            this.lblUnit5.Size = new System.Drawing.Size(29, 12);
            this.lblUnit5.TabIndex = 3;
            this.lblUnit5.Text = "(行)";
            // 
            // chbIsUseCL
            // 
            this.chbIsUseCL.AutoSize = true;
            this.chbIsUseCL.Location = new System.Drawing.Point(172, 18);
            this.chbIsUseCL.Margin = new System.Windows.Forms.Padding(2);
            this.chbIsUseCL.Name = "chbIsUseCL";
            this.chbIsUseCL.Size = new System.Drawing.Size(48, 16);
            this.chbIsUseCL.TabIndex = 7;
            this.chbIsUseCL.Text = "启用";
            this.chbIsUseCL.UseVisualStyleBackColor = true;
            this.chbIsUseCL.CheckedChanged += new System.EventHandler(this.chbIsUseCL_CheckedChanged);
            // 
            // txtPianYiCL
            // 
            this.txtPianYiCL.Location = new System.Drawing.Point(104, 58);
            this.txtPianYiCL.Margin = new System.Windows.Forms.Padding(2);
            this.txtPianYiCL.Name = "txtPianYiCL";
            this.txtPianYiCL.Size = new System.Drawing.Size(62, 21);
            this.txtPianYiCL.TabIndex = 5;
            this.txtPianYiCL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtMaxQtyCL
            // 
            this.txtMaxQtyCL.Location = new System.Drawing.Point(104, 34);
            this.txtMaxQtyCL.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaxQtyCL.Name = "txtMaxQtyCL";
            this.txtMaxQtyCL.Size = new System.Drawing.Size(62, 21);
            this.txtMaxQtyCL.TabIndex = 6;
            this.txtMaxQtyCL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lblPianYiCL
            // 
            this.lblPianYiCL.AutoSize = true;
            this.lblPianYiCL.Location = new System.Drawing.Point(38, 61);
            this.lblPianYiCL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPianYiCL.Name = "lblPianYiCL";
            this.lblPianYiCL.Size = new System.Drawing.Size(65, 12);
            this.lblPianYiCL.TabIndex = 3;
            this.lblPianYiCL.Text = "偏移数量：";
            // 
            // lblMaxQtyCL
            // 
            this.lblMaxQtyCL.AutoSize = true;
            this.lblMaxQtyCL.Location = new System.Drawing.Point(4, 36);
            this.lblMaxQtyCL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxQtyCL.Name = "lblMaxQtyCL";
            this.lblMaxQtyCL.Size = new System.Drawing.Size(101, 12);
            this.lblMaxQtyCL.TabIndex = 4;
            this.lblMaxQtyCL.Text = "每张单最大数量：";
            // 
            // gbxCPDB_Default
            // 
            this.gbxCPDB_Default.Controls.Add(this.cbxStock);
            this.gbxCPDB_Default.Controls.Add(this.cbxDepartment);
            this.gbxCPDB_Default.Controls.Add(this.lblStock);
            this.gbxCPDB_Default.Controls.Add(this.lblDepartment);
            this.gbxCPDB_Default.Location = new System.Drawing.Point(12, 148);
            this.gbxCPDB_Default.Name = "gbxCPDB_Default";
            this.gbxCPDB_Default.Size = new System.Drawing.Size(245, 148);
            this.gbxCPDB_Default.TabIndex = 0;
            this.gbxCPDB_Default.TabStop = false;
            this.gbxCPDB_Default.Text = "成品调拨默认参数";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(6, 23);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 12);
            this.lblDepartment.TabIndex = 0;
            this.lblDepartment.Text = "调入部门：";
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(77, 20);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(153, 20);
            this.cbxDepartment.TabIndex = 1;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(6, 49);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(65, 12);
            this.lblStock.TabIndex = 0;
            this.lblStock.Text = "调入仓库：";
            // 
            // cbxStock
            // 
            this.cbxStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStock.FormattingEnabled = true;
            this.cbxStock.Location = new System.Drawing.Point(77, 46);
            this.cbxStock.Name = "cbxStock";
            this.cbxStock.Size = new System.Drawing.Size(153, 20);
            this.cbxStock.TabIndex = 1;
            // 
            // frmPro_Dir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 381);
            this.ControlBox = false;
            this.Controls.Add(this.gbxCaiLiao);
            this.Controls.Add(this.gbxPenZi);
            this.Controls.Add(this.gbxDB_WMS);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbxCPDB_Default);
            this.Controls.Add(this.gbxDirType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.gbxCPDB_Default.ResumeLayout(false);
            this.gbxCPDB_Default.PerformLayout();
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
        private System.Windows.Forms.Label lblUnit6;
        private System.Windows.Forms.Label lblUnit5;
        private System.Windows.Forms.Label lblUnit4;
        private System.Windows.Forms.Label lblUnit3;
        private System.Windows.Forms.TextBox txtMinQtyPZ;
        private System.Windows.Forms.TextBox txtDPQtyPZ;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblDPQtyPZ;
        private System.Windows.Forms.GroupBox gbxCPDB_Default;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cbxStock;
        private System.Windows.Forms.Label lblStock;
    }
}
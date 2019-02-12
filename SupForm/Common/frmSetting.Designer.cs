namespace ERPSupport.SupForm.Common
{
    partial class frmSetting
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.lblERPADDRESS = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblZTID = new System.Windows.Forms.Label();
            this.lblPWD = new System.Windows.Forms.Label();
            this.txtERPADDRESS = new System.Windows.Forms.TextBox();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.txtZTID = new System.Windows.Forms.TextBox();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.lblORCLADDRESS = new System.Windows.Forms.Label();
            this.txtORCLADDRESS = new System.Windows.Forms.TextBox();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblERPADDRESS
            // 
            this.lblERPADDRESS.Location = new System.Drawing.Point(3, 10);
            this.lblERPADDRESS.Name = "lblERPADDRESS";
            this.lblERPADDRESS.Size = new System.Drawing.Size(65, 15);
            this.lblERPADDRESS.TabIndex = 0;
            this.lblERPADDRESS.Text = "服务器地址";
            this.lblERPADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOwner
            // 
            this.lblOwner.Location = new System.Drawing.Point(3, 70);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(65, 15);
            this.lblOwner.TabIndex = 0;
            this.lblOwner.Text = "库用户";
            this.lblOwner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblZTID
            // 
            this.lblZTID.Location = new System.Drawing.Point(3, 40);
            this.lblZTID.Name = "lblZTID";
            this.lblZTID.Size = new System.Drawing.Size(65, 15);
            this.lblZTID.TabIndex = 0;
            this.lblZTID.Text = "账套ID";
            this.lblZTID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPWD
            // 
            this.lblPWD.Location = new System.Drawing.Point(3, 100);
            this.lblPWD.Name = "lblPWD";
            this.lblPWD.Size = new System.Drawing.Size(65, 15);
            this.lblPWD.TabIndex = 0;
            this.lblPWD.Text = "数据库密码";
            this.lblPWD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtERPADDRESS
            // 
            this.txtERPADDRESS.Location = new System.Drawing.Point(71, 8);
            this.txtERPADDRESS.Name = "txtERPADDRESS";
            this.txtERPADDRESS.Size = new System.Drawing.Size(210, 21);
            this.txtERPADDRESS.TabIndex = 1;
            this.tt.SetToolTip(this.txtERPADDRESS, "在此输入K3Cloud地址。");
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(71, 68);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(210, 21);
            this.txtOwner.TabIndex = 3;
            this.tt.SetToolTip(this.txtOwner, "ORACLE库名。");
            // 
            // txtZTID
            // 
            this.txtZTID.Location = new System.Drawing.Point(71, 38);
            this.txtZTID.Name = "txtZTID";
            this.txtZTID.Size = new System.Drawing.Size(210, 21);
            this.txtZTID.TabIndex = 2;
            this.tt.SetToolTip(this.txtZTID, "在此输入所使用的ERP帐套ID。");
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(71, 98);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(210, 21);
            this.txtPWD.TabIndex = 4;
            this.tt.SetToolTip(this.txtPWD, "ORACLE登陆密码。");
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(50, 161);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 20);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.tt.SetToolTip(this.btnOK, "保存当前设置并关闭窗口。");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(175, 161);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 20);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "取消";
            this.tt.SetToolTip(this.btnCancle, "不保存当前设置并关闭窗口。");
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // lblORCLADDRESS
            // 
            this.lblORCLADDRESS.Location = new System.Drawing.Point(3, 130);
            this.lblORCLADDRESS.Name = "lblORCLADDRESS";
            this.lblORCLADDRESS.Size = new System.Drawing.Size(65, 15);
            this.lblORCLADDRESS.TabIndex = 0;
            this.lblORCLADDRESS.Text = "数据库地址";
            this.lblORCLADDRESS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtORCLADDRESS
            // 
            this.txtORCLADDRESS.Location = new System.Drawing.Point(71, 128);
            this.txtORCLADDRESS.Name = "txtORCLADDRESS";
            this.txtORCLADDRESS.Size = new System.Drawing.Size(210, 21);
            this.txtORCLADDRESS.TabIndex = 5;
            this.tt.SetToolTip(this.txtORCLADDRESS, "数据库链接地址。");
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 192);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtORCLADDRESS);
            this.Controls.Add(this.txtPWD);
            this.Controls.Add(this.txtZTID);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.txtERPADDRESS);
            this.Controls.Add(this.lblORCLADDRESS);
            this.Controls.Add(this.lblPWD);
            this.Controls.Add(this.lblZTID);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.lblERPADDRESS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务器设置";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblERPADDRESS;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblZTID;
        private System.Windows.Forms.Label lblPWD;
        private System.Windows.Forms.TextBox txtERPADDRESS;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.TextBox txtZTID;
        private System.Windows.Forms.TextBox txtPWD;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label lblORCLADDRESS;
        private System.Windows.Forms.TextBox txtORCLADDRESS;
        private System.Windows.Forms.ToolTip tt;
    }
}
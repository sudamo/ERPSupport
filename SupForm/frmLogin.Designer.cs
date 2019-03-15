namespace ERPSupport.SupForm
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblTitle = new System.Windows.Forms.Label();
            this.llbSetting = new System.Windows.Forms.LinkLabel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pl1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("华文楷体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(1, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 42);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "ERP辅助系统";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // llbSetting
            // 
            this.llbSetting.AutoSize = true;
            this.llbSetting.Location = new System.Drawing.Point(5, 180);
            this.llbSetting.Name = "llbSetting";
            this.llbSetting.Size = new System.Drawing.Size(65, 12);
            this.llbSetting.TabIndex = 12;
            this.llbSetting.TabStop = true;
            this.llbSetting.Text = "服务器设置";
            this.llbSetting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSetting_LinkClicked);
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("宋体", 10F);
            this.lblVersion.Location = new System.Drawing.Point(195, 13);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(41, 23);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "V3.1";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pl1
            // 
            this.pl1.Location = new System.Drawing.Point(6, 57);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(240, 120);
            this.pl1.TabIndex = 11;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 202);
            this.ControlBox = false;
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.llbSetting);
            this.Controls.Add(this.pl1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登陆";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel llbSetting;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel pl1;
    }
}
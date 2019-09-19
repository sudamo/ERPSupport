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
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(267, 52);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "ERP辅助系统";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // llbSetting
            // 
            this.llbSetting.AutoSize = true;
            this.llbSetting.Location = new System.Drawing.Point(7, 225);
            this.llbSetting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llbSetting.Name = "llbSetting";
            this.llbSetting.Size = new System.Drawing.Size(82, 15);
            this.llbSetting.TabIndex = 12;
            this.llbSetting.TabStop = true;
            this.llbSetting.Text = "服务器设置";
            this.llbSetting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSetting_LinkClicked);
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("宋体", 10F);
            this.lblVersion.Location = new System.Drawing.Point(260, 16);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(55, 29);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "V6.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pl1
            // 
            this.pl1.Location = new System.Drawing.Point(8, 71);
            this.pl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(320, 150);
            this.pl1.TabIndex = 11;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 253);
            this.ControlBox = false;
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.llbSetting);
            this.Controls.Add(this.pl1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimumSize = new System.Drawing.Size(400, 300);
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
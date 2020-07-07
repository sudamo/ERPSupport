namespace ERPSupport.SupForm.Bussiness
{
    partial class frmINOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINOrder));
            this.gbxReport = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFileDir = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.gbxReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxReport
            // 
            this.gbxReport.Controls.Add(this.btnImport);
            this.gbxReport.Controls.Add(this.btnOpen);
            this.gbxReport.Controls.Add(this.txtFileDir);
            this.gbxReport.Controls.Add(this.lblFile);
            this.gbxReport.Location = new System.Drawing.Point(12, 12);
            this.gbxReport.Name = "gbxReport";
            this.gbxReport.Size = new System.Drawing.Size(440, 100);
            this.gbxReport.TabIndex = 0;
            this.gbxReport.TabStop = false;
            this.gbxReport.Text = "报表";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(359, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "打开(&O)";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFileDir
            // 
            this.txtFileDir.Location = new System.Drawing.Point(89, 20);
            this.txtFileDir.Name = "txtFileDir";
            this.txtFileDir.ReadOnly = true;
            this.txtFileDir.Size = new System.Drawing.Size(264, 21);
            this.txtFileDir.TabIndex = 1;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(6, 23);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(77, 12);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "导入新价格：";
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(89, 71);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "导入(&I)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // frmINOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 282);
            this.Controls.Add(this.gbxReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(480, 320);
            this.MinimumSize = new System.Drawing.Size(480, 320);
            this.Name = "frmINOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网上订单系统";
            this.Load += new System.EventHandler(this.frmINOrder_Load);
            this.gbxReport.ResumeLayout(false);
            this.gbxReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxReport;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFileDir;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnImport;
    }
}
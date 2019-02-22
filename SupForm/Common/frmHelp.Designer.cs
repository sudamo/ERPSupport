namespace ERPSupport.SupForm.Common
{
    partial class frmHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelp));
            this.rtbContext = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSay = new System.Windows.Forms.Button();
            this.txtSay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rtbContext
            // 
            this.rtbContext.BackColor = System.Drawing.Color.Ivory;
            this.rtbContext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContext.Location = new System.Drawing.Point(60, 20);
            this.rtbContext.Name = "rtbContext";
            this.rtbContext.ReadOnly = true;
            this.rtbContext.Size = new System.Drawing.Size(360, 271);
            this.rtbContext.TabIndex = 2;
            this.rtbContext.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Ivory;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnOK.Location = new System.Drawing.Point(0, 337);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(480, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSay
            // 
            this.btnSay.Enabled = false;
            this.btnSay.Location = new System.Drawing.Point(426, 295);
            this.btnSay.Name = "btnSay";
            this.btnSay.Size = new System.Drawing.Size(42, 23);
            this.btnSay.TabIndex = 3;
            this.btnSay.Text = "留言";
            this.btnSay.UseVisualStyleBackColor = false;
            this.btnSay.Visible = false;
            // 
            // txtSay
            // 
            this.txtSay.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtSay.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSay.Location = new System.Drawing.Point(60, 297);
            this.txtSay.Name = "txtSay";
            this.txtSay.Size = new System.Drawing.Size(360, 21);
            this.txtSay.TabIndex = 2;
            this.txtSay.Visible = false;
            // 
            // frmHelp
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(480, 360);
            this.ControlBox = false;
            this.Controls.Add(this.txtSay);
            this.Controls.Add(this.btnSay);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtbContext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 360);
            this.MinimumSize = new System.Drawing.Size(480, 360);
            this.Name = "frmHelp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查看";
            this.Load += new System.EventHandler(this.frmHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbContext;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSay;
        private System.Windows.Forms.TextBox txtSay;
    }
}
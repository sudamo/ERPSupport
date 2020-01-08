namespace ERPSupport.SupForm.Menu
{
    partial class frmPro_WMSData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPro_WMSData));
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnBottom_btnCancel = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_tss = new System.Windows.Forms.ToolStripSeparator();
            this.txtMTL = new System.Windows.Forms.TextBox();
            this.btnSyn = new System.Windows.Forms.Button();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.lblMTL = new System.Windows.Forms.Label();
            this.lblTips = new System.Windows.Forms.Label();
            this.gbxMTL = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
            this.gbxMTL.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnBottom
            // 
            this.bnBottom.AddNewItem = null;
            this.bnBottom.CountItem = null;
            this.bnBottom.DeleteItem = null;
            this.bnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnBottom_btnCancel,
            this.bnBottom_tss});
            this.bnBottom.Location = new System.Drawing.Point(0, 327);
            this.bnBottom.MoveFirstItem = null;
            this.bnBottom.MoveLastItem = null;
            this.bnBottom.MoveNextItem = null;
            this.bnBottom.MovePreviousItem = null;
            this.bnBottom.Name = "bnBottom";
            this.bnBottom.PositionItem = null;
            this.bnBottom.Size = new System.Drawing.Size(438, 27);
            this.bnBottom.TabIndex = 6;
            this.bnBottom.Text = "Bottom";
            // 
            // bnBottom_btnCancel
            // 
            this.bnBottom_btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnBottom_btnCancel.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_redo;
            this.bnBottom_btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnCancel.Name = "bnBottom_btnCancel";
            this.bnBottom_btnCancel.Size = new System.Drawing.Size(56, 24);
            this.bnBottom_btnCancel.Text = "退出";
            this.bnBottom_btnCancel.ToolTipText = "退出关闭窗口";
            this.bnBottom_btnCancel.Click += new System.EventHandler(this.bnBottom_btnCancel_Click);
            // 
            // bnBottom_tss
            // 
            this.bnBottom_tss.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnBottom_tss.Name = "bnBottom_tss";
            this.bnBottom_tss.Size = new System.Drawing.Size(6, 27);
            // 
            // txtMTL
            // 
            this.txtMTL.Font = new System.Drawing.Font("宋体", 10F);
            this.txtMTL.Location = new System.Drawing.Point(72, 19);
            this.txtMTL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMTL.Name = "txtMTL";
            this.txtMTL.Size = new System.Drawing.Size(136, 23);
            this.txtMTL.TabIndex = 7;
            this.txtMTL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMTL_KeyPress);
            // 
            // btnSyn
            // 
            this.btnSyn.Location = new System.Drawing.Point(358, 19);
            this.btnSyn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSyn.Name = "btnSyn";
            this.btnSyn.Size = new System.Drawing.Size(56, 20);
            this.btnSyn.TabIndex = 8;
            this.btnSyn.Text = "同步";
            this.btnSyn.UseVisualStyleBackColor = true;
            this.btnSyn.Click += new System.EventHandler(this.btnSyn_Click);
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.Location = new System.Drawing.Point(286, 22);
            this.chbAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(72, 16);
            this.chbAll.TabIndex = 9;
            this.chbAll.Text = "所有物料";
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chbAll_CheckedChanged);
            // 
            // lblMTL
            // 
            this.lblMTL.AutoSize = true;
            this.lblMTL.Location = new System.Drawing.Point(4, 23);
            this.lblMTL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMTL.Name = "lblMTL";
            this.lblMTL.Size = new System.Drawing.Size(65, 12);
            this.lblMTL.TabIndex = 10;
            this.lblMTL.Text = "物料编码：";
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.ForeColor = System.Drawing.Color.Red;
            this.lblTips.Location = new System.Drawing.Point(4, 52);
            this.lblTips.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(29, 12);
            this.lblTips.TabIndex = 10;
            this.lblTips.Text = "提示";
            // 
            // gbxMTL
            // 
            this.gbxMTL.Controls.Add(this.lblMTL);
            this.gbxMTL.Controls.Add(this.lblTips);
            this.gbxMTL.Controls.Add(this.txtMTL);
            this.gbxMTL.Controls.Add(this.btnSyn);
            this.gbxMTL.Controls.Add(this.chbAll);
            this.gbxMTL.Location = new System.Drawing.Point(9, 10);
            this.gbxMTL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxMTL.Name = "gbxMTL";
            this.gbxMTL.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxMTL.Size = new System.Drawing.Size(418, 72);
            this.gbxMTL.TabIndex = 11;
            this.gbxMTL.TabStop = false;
            this.gbxMTL.Text = "物料";
            // 
            // frmPro_WMSData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 354);
            this.ControlBox = false;
            this.Controls.Add(this.gbxMTL);
            this.Controls.Add(this.bnBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(454, 392);
            this.MinimumSize = new System.Drawing.Size(454, 392);
            this.Name = "frmPro_WMSData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "同步数据-WMS";
            this.Load += new System.EventHandler(this.frmPro_WMSData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            this.gbxMTL.ResumeLayout(false);
            this.gbxMTL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripButton bnBottom_btnCancel;
        private System.Windows.Forms.ToolStripSeparator bnBottom_tss;
        private System.Windows.Forms.TextBox txtMTL;
        private System.Windows.Forms.Button btnSyn;
        private System.Windows.Forms.CheckBox chbAll;
        private System.Windows.Forms.Label lblMTL;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.GroupBox gbxMTL;
    }
}
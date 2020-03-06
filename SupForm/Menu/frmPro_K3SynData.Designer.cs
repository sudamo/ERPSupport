namespace ERPSupport.SupForm.Menu
{
    partial class frmPro_K3SynData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPro_K3SynData));
            this.gbxOutStock = new System.Windows.Forms.GroupBox();
            this.lblTips = new System.Windows.Forms.Label();
            this.btnSyn = new System.Windows.Forms.Button();
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnBottom_btnCancel = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_tss = new System.Windows.Forms.ToolStripSeparator();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblOrg = new System.Windows.Forms.Label();
            this.cbxMonth = new System.Windows.Forms.ComboBox();
            this.cbxOrg = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.gbxOutStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxOutStock
            // 
            this.gbxOutStock.Controls.Add(this.txtYear);
            this.gbxOutStock.Controls.Add(this.cbxOrg);
            this.gbxOutStock.Controls.Add(this.cbxMonth);
            this.gbxOutStock.Controls.Add(this.lblOrg);
            this.gbxOutStock.Controls.Add(this.lblMonth);
            this.gbxOutStock.Controls.Add(this.lblYear);
            this.gbxOutStock.Controls.Add(this.lblDateTime);
            this.gbxOutStock.Controls.Add(this.lblTips);
            this.gbxOutStock.Controls.Add(this.btnSyn);
            this.gbxOutStock.Location = new System.Drawing.Point(9, 5);
            this.gbxOutStock.Margin = new System.Windows.Forms.Padding(2);
            this.gbxOutStock.Name = "gbxOutStock";
            this.gbxOutStock.Padding = new System.Windows.Forms.Padding(2);
            this.gbxOutStock.Size = new System.Drawing.Size(418, 72);
            this.gbxOutStock.TabIndex = 13;
            this.gbxOutStock.TabStop = false;
            this.gbxOutStock.Text = "出库单单价";
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.ForeColor = System.Drawing.Color.Red;
            this.lblTips.Location = new System.Drawing.Point(225, 49);
            this.lblTips.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(29, 12);
            this.lblTips.TabIndex = 10;
            this.lblTips.Text = "提示";
            // 
            // btnSyn
            // 
            this.btnSyn.Location = new System.Drawing.Point(358, 19);
            this.btnSyn.Margin = new System.Windows.Forms.Padding(2);
            this.btnSyn.Name = "btnSyn";
            this.btnSyn.Size = new System.Drawing.Size(56, 20);
            this.btnSyn.TabIndex = 8;
            this.btnSyn.Text = "同步";
            this.btnSyn.UseVisualStyleBackColor = true;
            this.btnSyn.Click += new System.EventHandler(this.btnSyn_Click);
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
            this.bnBottom.TabIndex = 12;
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
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(4, 49);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(41, 12);
            this.lblDateTime.TabIndex = 10;
            this.lblDateTime.Text = "时间：";
            // 
            // lblOrg
            // 
            this.lblOrg.AutoSize = true;
            this.lblOrg.Location = new System.Drawing.Point(4, 23);
            this.lblOrg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrg.Name = "lblOrg";
            this.lblOrg.Size = new System.Drawing.Size(41, 12);
            this.lblOrg.TabIndex = 10;
            this.lblOrg.Text = "组织：";
            // 
            // cbxMonth
            // 
            this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonth.FormattingEnabled = true;
            this.cbxMonth.Location = new System.Drawing.Point(137, 46);
            this.cbxMonth.Name = "cbxMonth";
            this.cbxMonth.Size = new System.Drawing.Size(50, 20);
            this.cbxMonth.TabIndex = 11;
            // 
            // cbxOrg
            // 
            this.cbxOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrg.FormattingEnabled = true;
            this.cbxOrg.Location = new System.Drawing.Point(50, 20);
            this.cbxOrg.Name = "cbxOrg";
            this.cbxOrg.Size = new System.Drawing.Size(137, 20);
            this.cbxOrg.TabIndex = 11;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(115, 49);
            this.lblYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(17, 12);
            this.lblYear.TabIndex = 10;
            this.lblYear.Text = "年";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(192, 49);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(17, 12);
            this.lblMonth.TabIndex = 10;
            this.lblMonth.Text = "月";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(50, 46);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(60, 21);
            this.txtYear.TabIndex = 12;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // frmPro_K3SynData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 354);
            this.Controls.Add(this.gbxOutStock);
            this.Controls.Add(this.bnBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(454, 392);
            this.MinimumSize = new System.Drawing.Size(454, 392);
            this.Name = "frmPro_K3SynData";
            this.Text = "K3关联单据数据同步";
            this.Load += new System.EventHandler(this.frmPro_K3SynData_Load);
            this.gbxOutStock.ResumeLayout(false);
            this.gbxOutStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxOutStock;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Button btnSyn;
        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripButton bnBottom_btnCancel;
        private System.Windows.Forms.ToolStripSeparator bnBottom_tss;
        private System.Windows.Forms.ComboBox cbxOrg;
        private System.Windows.Forms.ComboBox cbxMonth;
        private System.Windows.Forms.Label lblOrg;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
    }
}
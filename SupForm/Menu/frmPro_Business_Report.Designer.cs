namespace ERPSupport.SupForm.Menu
{
    partial class frmPro_Business_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPro_Business_Report));
            this.gbx1 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnDLTemplate = new System.Windows.Forms.Button();
            this.gbx2 = new System.Windows.Forms.GroupBox();
            this.gbx3 = new System.Windows.Forms.GroupBox();
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnBottom_btnCancel = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_tss = new System.Windows.Forms.ToolStripSeparator();
            this.t1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnUPTemplate = new System.Windows.Forms.Button();
            this.gbx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx1
            // 
            this.gbx1.Controls.Add(this.btnImport);
            this.gbx1.Controls.Add(this.txtPath);
            this.gbx1.Controls.Add(this.lblPath);
            this.gbx1.Controls.Add(this.btnUPTemplate);
            this.gbx1.Controls.Add(this.btnDLTemplate);
            this.gbx1.Location = new System.Drawing.Point(12, 12);
            this.gbx1.Name = "gbx1";
            this.gbx1.Size = new System.Drawing.Size(460, 99);
            this.gbx1.TabIndex = 0;
            this.gbx1.TabStop = false;
            this.gbx1.Text = "ERP销售订单报表";
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(364, 49);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(90, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "订单导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(53, 51);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(305, 21);
            this.txtPath.TabIndex = 2;
            this.t1.SetToolTip(this.txtPath, "点击此处选择报表文件，文件后缀为xls或xlsx");
            this.txtPath.Click += new System.EventHandler(this.txtPath_Click);
            this.txtPath.MouseEnter += new System.EventHandler(this.txtPath_MouseEnter);
            this.txtPath.MouseLeave += new System.EventHandler(this.txtPath_MouseLeave);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(6, 54);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(41, 12);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "路径：";
            // 
            // btnDLTemplate
            // 
            this.btnDLTemplate.Enabled = false;
            this.btnDLTemplate.Location = new System.Drawing.Point(364, 20);
            this.btnDLTemplate.Name = "btnDLTemplate";
            this.btnDLTemplate.Size = new System.Drawing.Size(90, 23);
            this.btnDLTemplate.TabIndex = 0;
            this.btnDLTemplate.Text = "下载导入模板";
            this.btnDLTemplate.UseVisualStyleBackColor = true;
            this.btnDLTemplate.Click += new System.EventHandler(this.btnDLTemplate_Click);
            // 
            // gbx2
            // 
            this.gbx2.Location = new System.Drawing.Point(12, 117);
            this.gbx2.Name = "gbx2";
            this.gbx2.Size = new System.Drawing.Size(460, 99);
            this.gbx2.TabIndex = 0;
            this.gbx2.TabStop = false;
            this.gbx2.Text = "UCity报表";
            // 
            // gbx3
            // 
            this.gbx3.Location = new System.Drawing.Point(12, 222);
            this.gbx3.Name = "gbx3";
            this.gbx3.Size = new System.Drawing.Size(460, 99);
            this.gbx3.TabIndex = 0;
            this.gbx3.TabStop = false;
            this.gbx3.Text = "聚水潭报表";
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
            this.bnBottom.Location = new System.Drawing.Point(0, 335);
            this.bnBottom.MoveFirstItem = null;
            this.bnBottom.MoveLastItem = null;
            this.bnBottom.MoveNextItem = null;
            this.bnBottom.MovePreviousItem = null;
            this.bnBottom.Name = "bnBottom";
            this.bnBottom.PositionItem = null;
            this.bnBottom.Size = new System.Drawing.Size(484, 27);
            this.bnBottom.TabIndex = 13;
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
            // t1
            // 
            this.t1.AutoPopDelay = 8000;
            this.t1.InitialDelay = 100;
            this.t1.IsBalloon = true;
            this.t1.ReshowDelay = 100;
            this.t1.UseFading = false;
            // 
            // btnUPTemplate
            // 
            this.btnUPTemplate.Enabled = false;
            this.btnUPTemplate.Location = new System.Drawing.Point(268, 20);
            this.btnUPTemplate.Name = "btnUPTemplate";
            this.btnUPTemplate.Size = new System.Drawing.Size(90, 23);
            this.btnUPTemplate.TabIndex = 0;
            this.btnUPTemplate.Text = "上传新模板";
            this.btnUPTemplate.UseVisualStyleBackColor = true;
            this.btnUPTemplate.Click += new System.EventHandler(this.btnDLTemplate_Click);
            // 
            // frmPro_Business_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.ControlBox = false;
            this.Controls.Add(this.bnBottom);
            this.Controls.Add(this.gbx3);
            this.Controls.Add(this.gbx2);
            this.Controls.Add(this.gbx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "frmPro_Business_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电商报表管理";
            this.Load += new System.EventHandler(this.frmPro_Business_Report_Load);
            this.gbx1.ResumeLayout(false);
            this.gbx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx1;
        private System.Windows.Forms.GroupBox gbx2;
        private System.Windows.Forms.GroupBox gbx3;
        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripButton bnBottom_btnCancel;
        private System.Windows.Forms.ToolStripSeparator bnBottom_tss;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnDLTemplate;
        private System.Windows.Forms.ToolTip t1;
        private System.Windows.Forms.Button btnUPTemplate;
    }
}
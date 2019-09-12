namespace ERPSupport.SupForm.Bussiness
{
    partial class frmPPBom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPPBom));
            this.pl1 = new System.Windows.Forms.Panel();
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_lblBillNo = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtBillNo = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnSearch = new System.Windows.Forms.ToolStripButton();
            this.tpl1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.bnC = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnC_lblMTLNumber = new System.Windows.Forms.ToolStripLabel();
            this.bnC_txtMTLNumber = new System.Windows.Forms.ToolStripTextBox();
            this.bnC_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnC_btnSearch = new System.Windows.Forms.ToolStripButton();
            this.bnC_btnChange = new System.Windows.Forms.ToolStripButton();
            this.lblCName = new System.Windows.Forms.Label();
            this.plRight = new System.Windows.Forms.Panel();
            this.txtLoss = new System.Windows.Forms.TextBox();
            this.lblLoss = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtBom = new System.Windows.Forms.TextBox();
            this.lblBom = new System.Windows.Forms.Label();
            this.txtDep = new System.Windows.Forms.TextBox();
            this.lblDep = new System.Windows.Forms.Label();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.lblOrg = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtMoBillNo = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblMoBillNo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtMoSeq = new System.Windows.Forms.TextBox();
            this.lblMoSeq = new System.Windows.Forms.Label();
            this.pl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            this.tpl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnC)).BeginInit();
            this.bnC.SuspendLayout();
            this.plRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl1
            // 
            this.pl1.Controls.Add(this.lblQty);
            this.pl1.Controls.Add(this.lblMoSeq);
            this.pl1.Controls.Add(this.lblStatus);
            this.pl1.Controls.Add(this.lblOrg);
            this.pl1.Controls.Add(this.lblMoBillNo);
            this.pl1.Controls.Add(this.lblUnit);
            this.pl1.Controls.Add(this.txtMoSeq);
            this.pl1.Controls.Add(this.lblDep);
            this.pl1.Controls.Add(this.txtStatus);
            this.pl1.Controls.Add(this.bnTop);
            this.pl1.Controls.Add(this.txtQty);
            this.pl1.Controls.Add(this.txtUnit);
            this.pl1.Controls.Add(this.txtMoBillNo);
            this.pl1.Controls.Add(this.txtOrg);
            this.pl1.Controls.Add(this.txtDep);
            this.pl1.Controls.Add(this.lblNumber);
            this.pl1.Controls.Add(this.lblBom);
            this.pl1.Controls.Add(this.txtNumber);
            this.pl1.Controls.Add(this.txtBom);
            this.pl1.Controls.Add(this.txtName);
            this.pl1.Controls.Add(this.lblName);
            this.pl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl1.Location = new System.Drawing.Point(0, 0);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(1008, 142);
            this.pl1.TabIndex = 0;
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_lblBillNo,
            this.bnTop_txtBillNo,
            this.bnTop_tss,
            this.bnTop_btnSearch});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(1008, 25);
            this.bnTop.TabIndex = 1;
            this.bnTop.Text = "bindingNavigator1";
            // 
            // bnTop_lblBillNo
            // 
            this.bnTop_lblBillNo.Name = "bnTop_lblBillNo";
            this.bnTop_lblBillNo.Size = new System.Drawing.Size(104, 22);
            this.bnTop_lblBillNo.Text = "生产用料清单号：";
            // 
            // bnTop_txtBillNo
            // 
            this.bnTop_txtBillNo.Name = "bnTop_txtBillNo";
            this.bnTop_txtBillNo.Size = new System.Drawing.Size(150, 25);
            this.bnTop_txtBillNo.ToolTipText = "输入生产用料清单号";
            // 
            // bnTop_tss
            // 
            this.bnTop_tss.Name = "bnTop_tss";
            this.bnTop_tss.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_btnSearch
            // 
            this.bnTop_btnSearch.Image = global::ERPSupport.SupForm.Properties.Resources.zoom;
            this.bnTop_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnSearch.Name = "bnTop_btnSearch";
            this.bnTop_btnSearch.Size = new System.Drawing.Size(52, 22);
            this.bnTop_btnSearch.Tag = "1";
            this.bnTop_btnSearch.Text = "查询";
            this.bnTop_btnSearch.ToolTipText = "查询生产用料清单信息";
            this.bnTop_btnSearch.Click += new System.EventHandler(this.bnTop_btnSearch_Click);
            // 
            // tpl1
            // 
            this.tpl1.ColumnCount = 2;
            this.tpl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tpl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tpl1.Controls.Add(this.dgv1, 0, 0);
            this.tpl1.Controls.Add(this.plRight, 1, 0);
            this.tpl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpl1.Location = new System.Drawing.Point(0, 142);
            this.tpl1.Name = "tpl1";
            this.tpl1.RowCount = 1;
            this.tpl1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpl1.Size = new System.Drawing.Size(1008, 588);
            this.tpl1.TabIndex = 1;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(3, 3);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(598, 582);
            this.dgv1.TabIndex = 2;
            // 
            // bnC
            // 
            this.bnC.AddNewItem = null;
            this.bnC.CountItem = null;
            this.bnC.DeleteItem = null;
            this.bnC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnC_lblMTLNumber,
            this.bnC_txtMTLNumber,
            this.bnC_tss,
            this.bnC_btnSearch,
            this.bnC_btnChange});
            this.bnC.Location = new System.Drawing.Point(0, 0);
            this.bnC.MoveFirstItem = null;
            this.bnC.MoveLastItem = null;
            this.bnC.MoveNextItem = null;
            this.bnC.MovePreviousItem = null;
            this.bnC.Name = "bnC";
            this.bnC.PositionItem = null;
            this.bnC.Size = new System.Drawing.Size(398, 25);
            this.bnC.TabIndex = 29;
            this.bnC.Text = "bindingNavigator1";
            // 
            // bnC_lblMTLNumber
            // 
            this.bnC_lblMTLNumber.Name = "bnC_lblMTLNumber";
            this.bnC_lblMTLNumber.Size = new System.Drawing.Size(92, 22);
            this.bnC_lblMTLNumber.Text = "子项物料编码：";
            // 
            // bnC_txtMTLNumber
            // 
            this.bnC_txtMTLNumber.Name = "bnC_txtMTLNumber";
            this.bnC_txtMTLNumber.Size = new System.Drawing.Size(150, 25);
            this.bnC_txtMTLNumber.ToolTipText = "输入子项物料编码";
            // 
            // bnC_tss
            // 
            this.bnC_tss.Name = "bnC_tss";
            this.bnC_tss.Size = new System.Drawing.Size(6, 25);
            // 
            // bnC_btnSearch
            // 
            this.bnC_btnSearch.Image = global::ERPSupport.SupForm.Properties.Resources.zoom;
            this.bnC_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnC_btnSearch.Name = "bnC_btnSearch";
            this.bnC_btnSearch.Size = new System.Drawing.Size(52, 22);
            this.bnC_btnSearch.Tag = "1";
            this.bnC_btnSearch.Text = "查询";
            this.bnC_btnSearch.ToolTipText = "根据子项物料编码查询子项物料";
            this.bnC_btnSearch.Click += new System.EventHandler(this.bnC_btnSearch_Click);
            // 
            // bnC_btnChange
            // 
            this.bnC_btnChange.Image = global::ERPSupport.SupForm.Properties.Resources.update;
            this.bnC_btnChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnC_btnChange.Name = "bnC_btnChange";
            this.bnC_btnChange.Size = new System.Drawing.Size(52, 22);
            this.bnC_btnChange.Tag = "2";
            this.bnC_btnChange.Text = "替换";
            this.bnC_btnChange.Click += new System.EventHandler(this.bnC_bntChange_Click);
            // 
            // lblCName
            // 
            this.lblCName.AutoSize = true;
            this.lblCName.Location = new System.Drawing.Point(15, 60);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(89, 12);
            this.lblCName.TabIndex = 36;
            this.lblCName.Text = "子项物料名称：";
            // 
            // plRight
            // 
            this.plRight.Controls.Add(this.lblLoss);
            this.plRight.Controls.Add(this.txtLoss);
            this.plRight.Controls.Add(this.lblCName);
            this.plRight.Controls.Add(this.bnC);
            this.plRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plRight.Location = new System.Drawing.Point(607, 3);
            this.plRight.Name = "plRight";
            this.plRight.Size = new System.Drawing.Size(398, 582);
            this.plRight.TabIndex = 3;
            // 
            // txtLoss
            // 
            this.txtLoss.Location = new System.Drawing.Point(110, 102);
            this.txtLoss.Name = "txtLoss";
            this.txtLoss.Size = new System.Drawing.Size(80, 21);
            this.txtLoss.TabIndex = 60;
            this.txtLoss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoss_KeyPress);
            // 
            // lblLoss
            // 
            this.lblLoss.AutoSize = true;
            this.lblLoss.Location = new System.Drawing.Point(63, 105);
            this.lblLoss.Name = "lblLoss";
            this.lblLoss.Size = new System.Drawing.Size(41, 12);
            this.lblLoss.TabIndex = 36;
            this.lblLoss.Text = "用量：";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(81, 37);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(120, 21);
            this.txtNumber.TabIndex = 50;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(10, 40);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(65, 12);
            this.lblNumber.TabIndex = 36;
            this.lblNumber.Text = "产品编码：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(81, 97);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(490, 21);
            this.txtName.TabIndex = 57;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 100);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 12);
            this.lblName.TabIndex = 36;
            this.lblName.Text = "产品名称：";
            // 
            // txtBom
            // 
            this.txtBom.Location = new System.Drawing.Point(81, 67);
            this.txtBom.Name = "txtBom";
            this.txtBom.ReadOnly = true;
            this.txtBom.Size = new System.Drawing.Size(120, 21);
            this.txtBom.TabIndex = 54;
            // 
            // lblBom
            // 
            this.lblBom.AutoSize = true;
            this.lblBom.Location = new System.Drawing.Point(16, 70);
            this.lblBom.Name = "lblBom";
            this.lblBom.Size = new System.Drawing.Size(59, 12);
            this.lblBom.TabIndex = 36;
            this.lblBom.Text = "BOM版本：";
            // 
            // txtDep
            // 
            this.txtDep.Location = new System.Drawing.Point(278, 67);
            this.txtDep.Name = "txtDep";
            this.txtDep.ReadOnly = true;
            this.txtDep.Size = new System.Drawing.Size(120, 21);
            this.txtDep.TabIndex = 55;
            // 
            // lblDep
            // 
            this.lblDep.AutoSize = true;
            this.lblDep.Location = new System.Drawing.Point(207, 70);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(65, 12);
            this.lblDep.TabIndex = 36;
            this.lblDep.Text = "生产车间：";
            // 
            // txtOrg
            // 
            this.txtOrg.Location = new System.Drawing.Point(278, 37);
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.ReadOnly = true;
            this.txtOrg.Size = new System.Drawing.Size(120, 21);
            this.txtOrg.TabIndex = 51;
            // 
            // lblOrg
            // 
            this.lblOrg.AutoSize = true;
            this.lblOrg.Location = new System.Drawing.Point(207, 40);
            this.lblOrg.Name = "lblOrg";
            this.lblOrg.Size = new System.Drawing.Size(65, 12);
            this.lblOrg.TabIndex = 36;
            this.lblOrg.Text = "生产组织：";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(451, 37);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(120, 21);
            this.txtUnit.TabIndex = 52;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(404, 40);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(41, 12);
            this.lblUnit.TabIndex = 36;
            this.lblUnit.Text = "单位：";
            // 
            // txtMoBillNo
            // 
            this.txtMoBillNo.Location = new System.Drawing.Point(672, 37);
            this.txtMoBillNo.Name = "txtMoBillNo";
            this.txtMoBillNo.ReadOnly = true;
            this.txtMoBillNo.Size = new System.Drawing.Size(120, 21);
            this.txtMoBillNo.TabIndex = 53;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(451, 67);
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(120, 21);
            this.txtQty.TabIndex = 55;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(672, 67);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(120, 21);
            this.txtStatus.TabIndex = 56;
            // 
            // lblMoBillNo
            // 
            this.lblMoBillNo.AutoSize = true;
            this.lblMoBillNo.Location = new System.Drawing.Point(577, 40);
            this.lblMoBillNo.Name = "lblMoBillNo";
            this.lblMoBillNo.Size = new System.Drawing.Size(89, 12);
            this.lblMoBillNo.TabIndex = 36;
            this.lblMoBillNo.Text = "生产订单编号：";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(577, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(89, 12);
            this.lblStatus.TabIndex = 36;
            this.lblStatus.Text = "生产订单状态：";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(404, 70);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(41, 12);
            this.lblQty.TabIndex = 36;
            this.lblQty.Text = "数量：";
            // 
            // txtMoSeq
            // 
            this.txtMoSeq.Location = new System.Drawing.Point(672, 97);
            this.txtMoSeq.Name = "txtMoSeq";
            this.txtMoSeq.ReadOnly = true;
            this.txtMoSeq.Size = new System.Drawing.Size(120, 21);
            this.txtMoSeq.TabIndex = 58;
            // 
            // lblMoSeq
            // 
            this.lblMoSeq.AutoSize = true;
            this.lblMoSeq.Location = new System.Drawing.Point(577, 100);
            this.lblMoSeq.Name = "lblMoSeq";
            this.lblMoSeq.Size = new System.Drawing.Size(89, 12);
            this.lblMoSeq.TabIndex = 36;
            this.lblMoSeq.Text = "生产订单行号：";
            // 
            // frmPPBom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.tpl1);
            this.Controls.Add(this.pl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmPPBom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改生产用料清单信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPPBom_Load);
            this.pl1.ResumeLayout(false);
            this.pl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).EndInit();
            this.bnTop.ResumeLayout(false);
            this.bnTop.PerformLayout();
            this.tpl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnC)).EndInit();
            this.bnC.ResumeLayout(false);
            this.bnC.PerformLayout();
            this.plRight.ResumeLayout(false);
            this.plRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl1;
        private System.Windows.Forms.TableLayoutPanel tpl1;
        private System.Windows.Forms.BindingNavigator bnTop;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss;
        private System.Windows.Forms.ToolStripButton bnTop_btnSearch;
        private System.Windows.Forms.ToolStripLabel bnTop_lblBillNo;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtBillNo;
        private System.Windows.Forms.BindingNavigator bnC;
        private System.Windows.Forms.ToolStripLabel bnC_lblMTLNumber;
        private System.Windows.Forms.ToolStripTextBox bnC_txtMTLNumber;
        private System.Windows.Forms.ToolStripSeparator bnC_tss;
        private System.Windows.Forms.ToolStripButton bnC_btnSearch;
        private System.Windows.Forms.ToolStripButton bnC_btnChange;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Panel plRight;
        private System.Windows.Forms.Label lblCName;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblMoSeq;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblOrg;
        private System.Windows.Forms.Label lblMoBillNo;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtMoSeq;
        private System.Windows.Forms.Label lblDep;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtMoBillNo;
        private System.Windows.Forms.TextBox txtOrg;
        private System.Windows.Forms.TextBox txtDep;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblBom;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtBom;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLoss;
        private System.Windows.Forms.TextBox txtLoss;
    }
}
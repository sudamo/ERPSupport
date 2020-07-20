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
            this.btnImport = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFileDir = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.gbxCustomer = new System.Windows.Forms.GroupBox();
            this.cbxCreateOrg = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.cbxSeller = new System.Windows.Forms.ComboBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.lblCreateOrg = new System.Windows.Forms.Label();
            this.lblSaler = new System.Windows.Forms.Label();
            this.gbxReport.SuspendLayout();
            this.gbxCustomer.SuspendLayout();
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
            this.gbxReport.Size = new System.Drawing.Size(440, 76);
            this.gbxReport.TabIndex = 0;
            this.gbxReport.TabStop = false;
            this.gbxReport.Text = "报表";
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(359, 47);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "导入(&I)";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
            // gbxCustomer
            // 
            this.gbxCustomer.Controls.Add(this.lblSaler);
            this.gbxCustomer.Controls.Add(this.lblCreateOrg);
            this.gbxCustomer.Controls.Add(this.lblCustomerName);
            this.gbxCustomer.Controls.Add(this.txtCustomerName);
            this.gbxCustomer.Controls.Add(this.btnAddCustomer);
            this.gbxCustomer.Controls.Add(this.btnSearch);
            this.gbxCustomer.Controls.Add(this.cbxSeller);
            this.gbxCustomer.Controls.Add(this.cbxCreateOrg);
            this.gbxCustomer.Location = new System.Drawing.Point(12, 94);
            this.gbxCustomer.Name = "gbxCustomer";
            this.gbxCustomer.Size = new System.Drawing.Size(440, 76);
            this.gbxCustomer.TabIndex = 1;
            this.gbxCustomer.TabStop = false;
            this.gbxCustomer.Text = "客户";
            // 
            // cbxCreateOrg
            // 
            this.cbxCreateOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCreateOrg.Enabled = false;
            this.cbxCreateOrg.FormattingEnabled = true;
            this.cbxCreateOrg.Location = new System.Drawing.Point(89, 47);
            this.cbxCreateOrg.Name = "cbxCreateOrg";
            this.cbxCreateOrg.Size = new System.Drawing.Size(139, 20);
            this.cbxCreateOrg.TabIndex = 0;
            this.cbxCreateOrg.SelectedIndexChanged += new System.EventHandler(this.cbxCreateOrg_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(359, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(89, 20);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(264, 21);
            this.txtCustomerName.TabIndex = 2;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(6, 23);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(65, 12);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "客户全名：";
            // 
            // cbxSeller
            // 
            this.cbxSeller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSeller.Enabled = false;
            this.cbxSeller.FormattingEnabled = true;
            this.cbxSeller.Location = new System.Drawing.Point(293, 47);
            this.cbxSeller.Name = "cbxSeller";
            this.cbxSeller.Size = new System.Drawing.Size(60, 20);
            this.cbxSeller.TabIndex = 0;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Enabled = false;
            this.btnAddCustomer.Location = new System.Drawing.Point(359, 45);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnAddCustomer.TabIndex = 1;
            this.btnAddCustomer.Text = "新增";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // lblCreateOrg
            // 
            this.lblCreateOrg.AutoSize = true;
            this.lblCreateOrg.Location = new System.Drawing.Point(6, 50);
            this.lblCreateOrg.Name = "lblCreateOrg";
            this.lblCreateOrg.Size = new System.Drawing.Size(65, 12);
            this.lblCreateOrg.TabIndex = 3;
            this.lblCreateOrg.Text = "创建组织：";
            // 
            // lblSaler
            // 
            this.lblSaler.AutoSize = true;
            this.lblSaler.Location = new System.Drawing.Point(234, 50);
            this.lblSaler.Name = "lblSaler";
            this.lblSaler.Size = new System.Drawing.Size(53, 12);
            this.lblSaler.TabIndex = 3;
            this.lblSaler.Text = "销售员：";
            // 
            // frmINOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 282);
            this.Controls.Add(this.gbxCustomer);
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
            this.gbxCustomer.ResumeLayout(false);
            this.gbxCustomer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxReport;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFileDir;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox gbxCustomer;
        private System.Windows.Forms.Label lblSaler;
        private System.Windows.Forms.Label lblCreateOrg;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxSeller;
        private System.Windows.Forms.ComboBox cbxCreateOrg;
    }
}
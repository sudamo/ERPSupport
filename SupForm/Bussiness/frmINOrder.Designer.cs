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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmINOrder));
            this.gbxReport = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFileDir = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.gbxCustomer = new System.Windows.Forms.GroupBox();
            this.lblSaler = new System.Windows.Forms.Label();
            this.lblCreateOrg = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxSeller = new System.Windows.Forms.ComboBox();
            this.cbxCreateOrg = new System.Windows.Forms.ComboBox();
            this.gbxArea = new System.Windows.Forms.GroupBox();
            this.btnAddADD = new System.Windows.Forms.Button();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblProvince = new System.Windows.Forms.Label();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.cbxProvince = new System.Windows.Forms.ComboBox();
            this.cbxCity = new System.Windows.Forms.ComboBox();
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_Price = new System.Windows.Forms.ToolStripButton();
            this.gbxReport.SuspendLayout();
            this.gbxCustomer.SuspendLayout();
            this.gbxArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
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
            this.txtFileDir.Location = new System.Drawing.Point(77, 20);
            this.txtFileDir.Name = "txtFileDir";
            this.txtFileDir.ReadOnly = true;
            this.txtFileDir.Size = new System.Drawing.Size(276, 21);
            this.txtFileDir.TabIndex = 1;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(6, 23);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(65, 12);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "导入价格：";
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
            // lblSaler
            // 
            this.lblSaler.AutoSize = true;
            this.lblSaler.Location = new System.Drawing.Point(222, 50);
            this.lblSaler.Name = "lblSaler";
            this.lblSaler.Size = new System.Drawing.Size(53, 12);
            this.lblSaler.TabIndex = 3;
            this.lblSaler.Text = "销售员：";
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
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(6, 23);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(65, 12);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "客户全名：";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(77, 20);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(276, 21);
            this.txtCustomerName.TabIndex = 2;
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
            // cbxSeller
            // 
            this.cbxSeller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSeller.Enabled = false;
            this.cbxSeller.FormattingEnabled = true;
            this.cbxSeller.Location = new System.Drawing.Point(281, 47);
            this.cbxSeller.Name = "cbxSeller";
            this.cbxSeller.Size = new System.Drawing.Size(72, 20);
            this.cbxSeller.TabIndex = 0;
            // 
            // cbxCreateOrg
            // 
            this.cbxCreateOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCreateOrg.Enabled = false;
            this.cbxCreateOrg.FormattingEnabled = true;
            this.cbxCreateOrg.Location = new System.Drawing.Point(77, 47);
            this.cbxCreateOrg.Name = "cbxCreateOrg";
            this.cbxCreateOrg.Size = new System.Drawing.Size(139, 20);
            this.cbxCreateOrg.TabIndex = 0;
            this.cbxCreateOrg.SelectedIndexChanged += new System.EventHandler(this.cbxCreateOrg_SelectedIndexChanged);
            // 
            // gbxArea
            // 
            this.gbxArea.Controls.Add(this.btnAddADD);
            this.gbxArea.Controls.Add(this.lblDistrict);
            this.gbxArea.Controls.Add(this.lblCity);
            this.gbxArea.Controls.Add(this.lblProvince);
            this.gbxArea.Controls.Add(this.txtDistrict);
            this.gbxArea.Controls.Add(this.cbxProvince);
            this.gbxArea.Controls.Add(this.cbxCity);
            this.gbxArea.Location = new System.Drawing.Point(12, 176);
            this.gbxArea.Name = "gbxArea";
            this.gbxArea.Size = new System.Drawing.Size(440, 76);
            this.gbxArea.TabIndex = 0;
            this.gbxArea.TabStop = false;
            this.gbxArea.Text = "地区";
            // 
            // btnAddADD
            // 
            this.btnAddADD.Location = new System.Drawing.Point(359, 47);
            this.btnAddADD.Name = "btnAddADD";
            this.btnAddADD.Size = new System.Drawing.Size(75, 23);
            this.btnAddADD.TabIndex = 2;
            this.btnAddADD.Text = "添加";
            this.btnAddADD.UseVisualStyleBackColor = true;
            this.btnAddADD.Click += new System.EventHandler(this.btnAddADD_Click);
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(24, 52);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(47, 12);
            this.lblDistrict.TabIndex = 0;
            this.lblDistrict.Text = "区/县：";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(222, 23);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(29, 12);
            this.lblCity.TabIndex = 0;
            this.lblCity.Text = "市：";
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(42, 23);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(29, 12);
            this.lblProvince.TabIndex = 0;
            this.lblProvince.Text = "省：";
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(77, 46);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(139, 21);
            this.txtDistrict.TabIndex = 1;
            // 
            // cbxProvince
            // 
            this.cbxProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProvince.FormattingEnabled = true;
            this.cbxProvince.Location = new System.Drawing.Point(77, 20);
            this.cbxProvince.Name = "cbxProvince";
            this.cbxProvince.Size = new System.Drawing.Size(139, 20);
            this.cbxProvince.TabIndex = 0;
            this.cbxProvince.SelectedIndexChanged += new System.EventHandler(this.cbxProvince_SelectedIndexChanged);
            // 
            // cbxCity
            // 
            this.cbxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCity.FormattingEnabled = true;
            this.cbxCity.Location = new System.Drawing.Point(257, 20);
            this.cbxCity.Name = "cbxCity";
            this.cbxCity.Size = new System.Drawing.Size(96, 20);
            this.cbxCity.TabIndex = 0;
            // 
            // bnBottom
            // 
            this.bnBottom.AddNewItem = null;
            this.bnBottom.CountItem = null;
            this.bnBottom.DeleteItem = null;
            this.bnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_Price});
            this.bnBottom.Location = new System.Drawing.Point(0, 257);
            this.bnBottom.MoveFirstItem = null;
            this.bnBottom.MoveLastItem = null;
            this.bnBottom.MoveNextItem = null;
            this.bnBottom.MovePreviousItem = null;
            this.bnBottom.Name = "bnBottom";
            this.bnBottom.PositionItem = null;
            this.bnBottom.Size = new System.Drawing.Size(464, 25);
            this.bnBottom.TabIndex = 2;
            this.bnBottom.Text = "bindingNavigator1";
            // 
            // bnTop_Price
            // 
            this.bnTop_Price.Image = global::ERPSupport.SupForm.Properties.Resources.update;
            this.bnTop_Price.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_Price.Name = "bnTop_Price";
            this.bnTop_Price.Size = new System.Drawing.Size(76, 22);
            this.bnTop_Price.Tag = "1";
            this.bnTop_Price.Text = "更新价格";
            this.bnTop_Price.Click += new System.EventHandler(this.bnTop_Price_Click);
            // 
            // frmINOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 282);
            this.Controls.Add(this.bnBottom);
            this.Controls.Add(this.gbxCustomer);
            this.Controls.Add(this.gbxArea);
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
            this.gbxArea.ResumeLayout(false);
            this.gbxArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox gbxArea;
        private System.Windows.Forms.Button btnAddADD;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.ComboBox cbxProvince;
        private System.Windows.Forms.ComboBox cbxCity;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripButton bnTop_Price;
    }
}
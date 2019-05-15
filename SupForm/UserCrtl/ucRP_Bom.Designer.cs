namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucRP_Bom
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTies = new System.Windows.Forms.Label();
            this.rbtBOMChild = new System.Windows.Forms.RadioButton();
            this.rbtReplaceGroup = new System.Windows.Forms.RadioButton();
            this.rbtBom = new System.Windows.Forms.RadioButton();
            this.cbxTimes = new System.Windows.Forms.ComboBox();
            this.cbxLogic = new System.Windows.Forms.ComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxUseOrg = new System.Windows.Forms.ComboBox();
            this.lblUseOrg = new System.Windows.Forms.Label();
            this.lblTimes = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTies);
            this.panel1.Controls.Add(this.rbtBOMChild);
            this.panel1.Controls.Add(this.rbtReplaceGroup);
            this.panel1.Controls.Add(this.rbtBom);
            this.panel1.Controls.Add(this.cbxTimes);
            this.panel1.Controls.Add(this.cbxLogic);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cbxUseOrg);
            this.panel1.Controls.Add(this.lblUseOrg);
            this.panel1.Controls.Add(this.lblTimes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 25);
            this.panel1.TabIndex = 0;
            // 
            // lblTies
            // 
            this.lblTies.AutoSize = true;
            this.lblTies.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTies.ForeColor = System.Drawing.Color.Red;
            this.lblTies.Location = new System.Drawing.Point(658, 7);
            this.lblTies.Name = "lblTies";
            this.lblTies.Size = new System.Drawing.Size(192, 11);
            this.lblTies.TabIndex = 7;
            this.lblTies.Text = "分组查询大概需要几分钟，请耐心等待";
            // 
            // rbtBOMChild
            // 
            this.rbtBOMChild.AutoSize = true;
            this.rbtBOMChild.Location = new System.Drawing.Point(275, 4);
            this.rbtBOMChild.Name = "rbtBOMChild";
            this.rbtBOMChild.Size = new System.Drawing.Size(113, 16);
            this.rbtBOMChild.TabIndex = 6;
            this.rbtBOMChild.TabStop = true;
            this.rbtBOMChild.Text = "BOM项次重复查询";
            this.rbtBOMChild.UseVisualStyleBackColor = true;
            this.rbtBOMChild.CheckedChanged += new System.EventHandler(this.rbtBOMChild_CheckedChanged);
            // 
            // rbtReplaceGroup
            // 
            this.rbtReplaceGroup.AutoSize = true;
            this.rbtReplaceGroup.Location = new System.Drawing.Point(394, 4);
            this.rbtReplaceGroup.Name = "rbtReplaceGroup";
            this.rbtReplaceGroup.Size = new System.Drawing.Size(89, 16);
            this.rbtReplaceGroup.TabIndex = 5;
            this.rbtReplaceGroup.TabStop = true;
            this.rbtReplaceGroup.Text = "BOM项次查询";
            this.rbtReplaceGroup.UseVisualStyleBackColor = true;
            this.rbtReplaceGroup.CheckedChanged += new System.EventHandler(this.rbtBom_CheckedChanged);
            // 
            // rbtBom
            // 
            this.rbtBom.AutoSize = true;
            this.rbtBom.Location = new System.Drawing.Point(180, 4);
            this.rbtBom.Name = "rbtBom";
            this.rbtBom.Size = new System.Drawing.Size(89, 16);
            this.rbtBom.TabIndex = 5;
            this.rbtBom.TabStop = true;
            this.rbtBom.Text = "BOM重复查询";
            this.rbtBom.UseVisualStyleBackColor = true;
            this.rbtBom.CheckedChanged += new System.EventHandler(this.rbtBom_CheckedChanged);
            // 
            // cbxTimes
            // 
            this.cbxTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTimes.DropDownWidth = 50;
            this.cbxTimes.FormattingEnabled = true;
            this.cbxTimes.Location = new System.Drawing.Point(602, 3);
            this.cbxTimes.Name = "cbxTimes";
            this.cbxTimes.Size = new System.Drawing.Size(50, 20);
            this.cbxTimes.TabIndex = 4;
            // 
            // cbxLogic
            // 
            this.cbxLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLogic.FormattingEnabled = true;
            this.cbxLogic.Location = new System.Drawing.Point(536, 3);
            this.cbxLogic.Name = "cbxLogic";
            this.cbxLogic.Size = new System.Drawing.Size(60, 20);
            this.cbxLogic.TabIndex = 4;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(937, 1);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "导出报表";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(856, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxUseOrg
            // 
            this.cbxUseOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUseOrg.FormattingEnabled = true;
            this.cbxUseOrg.Location = new System.Drawing.Point(74, 3);
            this.cbxUseOrg.Name = "cbxUseOrg";
            this.cbxUseOrg.Size = new System.Drawing.Size(100, 20);
            this.cbxUseOrg.TabIndex = 2;
            // 
            // lblUseOrg
            // 
            this.lblUseOrg.AutoSize = true;
            this.lblUseOrg.Location = new System.Drawing.Point(3, 6);
            this.lblUseOrg.Name = "lblUseOrg";
            this.lblUseOrg.Size = new System.Drawing.Size(65, 12);
            this.lblUseOrg.TabIndex = 0;
            this.lblUseOrg.Text = "使用组织：";
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.Location = new System.Drawing.Point(489, 6);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(41, 12);
            this.lblTimes.TabIndex = 0;
            this.lblTimes.Text = "项次：";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(5, 28);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(1017, 738);
            this.dgv1.TabIndex = 22;
            // 
            // ucRP_Bom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.panel1);
            this.Name = "ucRP_Bom";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucRP_Bom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxUseOrg;
        private System.Windows.Forms.Label lblUseOrg;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.ComboBox cbxTimes;
        private System.Windows.Forms.ComboBox cbxLogic;
        private System.Windows.Forms.RadioButton rbtReplaceGroup;
        private System.Windows.Forms.RadioButton rbtBom;
        private System.Windows.Forms.Label lblTies;
        private System.Windows.Forms.RadioButton rbtBOMChild;
    }
}

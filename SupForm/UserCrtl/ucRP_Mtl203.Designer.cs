namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucRP_Mtl203
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pl1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbxCondition = new System.Windows.Forms.ComboBox();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.cbxLogic = new System.Windows.Forms.ComboBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.pl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // pl1
            // 
            this.pl1.Controls.Add(this.btnExport);
            this.pl1.Controls.Add(this.btnSearch);
            this.pl1.Controls.Add(this.dtpDate);
            this.pl1.Controls.Add(this.cbxCondition);
            this.pl1.Controls.Add(this.txtCondition);
            this.pl1.Controls.Add(this.cbxLogic);
            this.pl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl1.Location = new System.Drawing.Point(0, 0);
            this.pl1.Margin = new System.Windows.Forms.Padding(2);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(1024, 25);
            this.pl1.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(415, 1);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 20);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "导出报表";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(351, 1);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 20);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(196, 2);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(151, 21);
            this.dtpDate.TabIndex = 4;
            // 
            // cbxCondition
            // 
            this.cbxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCondition.FormattingEnabled = true;
            this.cbxCondition.Location = new System.Drawing.Point(2, 2);
            this.cbxCondition.Margin = new System.Windows.Forms.Padding(2);
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(110, 20);
            this.cbxCondition.TabIndex = 2;
            this.cbxCondition.SelectedIndexChanged += new System.EventHandler(this.cbxCondition_SelectedIndexChanged);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(196, 2);
            this.txtCondition.Margin = new System.Windows.Forms.Padding(2);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(151, 21);
            this.txtCondition.TabIndex = 1;
            // 
            // cbxLogic
            // 
            this.cbxLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLogic.FormattingEnabled = true;
            this.cbxLogic.Location = new System.Drawing.Point(116, 2);
            this.cbxLogic.Margin = new System.Windows.Forms.Padding(2);
            this.cbxLogic.Name = "cbxLogic";
            this.cbxLogic.Size = new System.Drawing.Size(76, 20);
            this.cbxLogic.TabIndex = 3;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Turquoise;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(2, 27);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(1020, 739);
            this.dgv1.TabIndex = 19;
            // 
            // ucRP_Mtl203
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.pl1);
            this.Name = "ucRP_Mtl203";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucRP_Mtl203_Load);
            this.pl1.ResumeLayout(false);
            this.pl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cbxCondition;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.ComboBox cbxLogic;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgv1;
    }
}

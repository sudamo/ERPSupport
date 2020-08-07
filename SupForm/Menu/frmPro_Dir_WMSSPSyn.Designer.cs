namespace ERPSupport.SupForm.Menu
{
    partial class frmPro_Dir_WMSSPSyn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPro_Dir_WMSSPSyn));
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_lblNumber = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtNumber = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnCommit = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnCommitAll = new System.Windows.Forms.ToolStripButton();
            this.bn1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bn_lblPageSize = new System.Windows.Forms.ToolStripLabel();
            this.bn_cbxPageSize = new System.Windows.Forms.ToolStripComboBox();
            this.bn_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.bn_btnStart = new System.Windows.Forms.ToolStripButton();
            this.bn_btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.bn_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.bn_btnGoto = new System.Windows.Forms.ToolStripButton();
            this.bn_lblThe = new System.Windows.Forms.ToolStripLabel();
            this.bn_txtCurrentPage = new System.Windows.Forms.ToolStripTextBox();
            this.bn_lblSeparate = new System.Windows.Forms.ToolStripLabel();
            this.bn_lblPageCount = new System.Windows.Forms.ToolStripLabel();
            this.bn_tss3 = new System.Windows.Forms.ToolStripSeparator();
            this.bn_lblRecordCount = new System.Windows.Forms.ToolStripLabel();
            this.bn_tss4 = new System.Windows.Forms.ToolStripSeparator();
            this.bn_btnNext = new System.Windows.Forms.ToolStripButton();
            this.bn_btnLast = new System.Windows.Forms.ToolStripButton();
            this.bn_tss5 = new System.Windows.Forms.ToolStripSeparator();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.bs1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bnTop_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnImport = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bn1)).BeginInit();
            this.bn1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs1)).BeginInit();
            this.SuspendLayout();
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.CountItemFormat = "部门：";
            this.bnTop.DeleteItem = null;
            this.bnTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_lblNumber,
            this.bnTop_txtNumber,
            this.bnTop_tss1,
            this.bnTop_btnCommit,
            this.bnTop_btnCommitAll,
            this.bnTop_tss2,
            this.bnTop_btnImport});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(534, 27);
            this.bnTop.TabIndex = 3;
            this.bnTop.Text = "bindingNavigator1";
            // 
            // bnTop_lblNumber
            // 
            this.bnTop_lblNumber.Name = "bnTop_lblNumber";
            this.bnTop_lblNumber.Size = new System.Drawing.Size(68, 24);
            this.bnTop_lblNumber.Text = "物料编码：";
            // 
            // bnTop_txtNumber
            // 
            this.bnTop_txtNumber.Name = "bnTop_txtNumber";
            this.bnTop_txtNumber.Size = new System.Drawing.Size(130, 27);
            this.bnTop_txtNumber.ToolTipText = "输入物料编码并按回车进行模糊查询";
            this.bnTop_txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bnTop_txtNumber_KeyPress);
            // 
            // bnTop_tss1
            // 
            this.bnTop_tss1.Name = "bnTop_tss1";
            this.bnTop_tss1.Size = new System.Drawing.Size(6, 27);
            // 
            // bnTop_btnCommit
            // 
            this.bnTop_btnCommit.Image = global::ERPSupport.SupForm.Properties.Resources.accept;
            this.bnTop_btnCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnCommit.Name = "bnTop_btnCommit";
            this.bnTop_btnCommit.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnCommit.Tag = "2";
            this.bnTop_btnCommit.Text = "同步";
            this.bnTop_btnCommit.ToolTipText = "同步选中物料的仓位到ERP";
            this.bnTop_btnCommit.Click += new System.EventHandler(this.bnTop_btnCommit_Click);
            // 
            // bnTop_btnCommitAll
            // 
            this.bnTop_btnCommitAll.Image = global::ERPSupport.SupForm.Properties.Resources.three_tags;
            this.bnTop_btnCommitAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnCommitAll.Name = "bnTop_btnCommitAll";
            this.bnTop_btnCommitAll.Size = new System.Drawing.Size(80, 24);
            this.bnTop_btnCommitAll.Tag = "3";
            this.bnTop_btnCommitAll.Text = "同步全部";
            this.bnTop_btnCommitAll.ToolTipText = "同步所有WMS仓位到ERP";
            this.bnTop_btnCommitAll.Click += new System.EventHandler(this.bnTop_btnCommitAll_Click);
            // 
            // bn1
            // 
            this.bn1.AddNewItem = null;
            this.bn1.CountItem = null;
            this.bn1.DeleteItem = null;
            this.bn1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bn1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bn1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bn_lblPageSize,
            this.bn_cbxPageSize,
            this.bn_tss1,
            this.bn_btnStart,
            this.bn_btnPrevious,
            this.bn_tss2,
            this.bn_btnGoto,
            this.bn_lblThe,
            this.bn_txtCurrentPage,
            this.bn_lblSeparate,
            this.bn_lblPageCount,
            this.bn_tss3,
            this.bn_lblRecordCount,
            this.bn_tss4,
            this.bn_btnNext,
            this.bn_btnLast,
            this.bn_tss5});
            this.bn1.Location = new System.Drawing.Point(0, 655);
            this.bn1.MoveFirstItem = null;
            this.bn1.MoveLastItem = null;
            this.bn1.MoveNextItem = null;
            this.bn1.MovePreviousItem = null;
            this.bn1.Name = "bn1";
            this.bn1.PositionItem = null;
            this.bn1.Size = new System.Drawing.Size(534, 27);
            this.bn1.TabIndex = 5;
            this.bn1.Text = "bindingNavigator1";
            this.bn1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bn1_ItemClicked);
            // 
            // bn_lblPageSize
            // 
            this.bn_lblPageSize.Name = "bn_lblPageSize";
            this.bn_lblPageSize.Size = new System.Drawing.Size(56, 24);
            this.bn_lblPageSize.Text = "每页显示";
            // 
            // bn_cbxPageSize
            // 
            this.bn_cbxPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bn_cbxPageSize.Name = "bn_cbxPageSize";
            this.bn_cbxPageSize.Size = new System.Drawing.Size(75, 27);
            this.bn_cbxPageSize.ToolTipText = "每页显示行数";
            this.bn_cbxPageSize.SelectedIndexChanged += new System.EventHandler(this.bn_cbxPageSize_SelectedIndexChanged);
            // 
            // bn_tss1
            // 
            this.bn_tss1.Name = "bn_tss1";
            this.bn_tss1.Size = new System.Drawing.Size(6, 27);
            // 
            // bn_btnStart
            // 
            this.bn_btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bn_btnStart.Image = global::ERPSupport.SupForm.Properties.Resources.control_start_blue;
            this.bn_btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bn_btnStart.Name = "bn_btnStart";
            this.bn_btnStart.Size = new System.Drawing.Size(24, 24);
            this.bn_btnStart.Tag = "1";
            // 
            // bn_btnPrevious
            // 
            this.bn_btnPrevious.AutoToolTip = false;
            this.bn_btnPrevious.BackColor = System.Drawing.SystemColors.Control;
            this.bn_btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bn_btnPrevious.Image = global::ERPSupport.SupForm.Properties.Resources.control_play2_blue;
            this.bn_btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bn_btnPrevious.Name = "bn_btnPrevious";
            this.bn_btnPrevious.Size = new System.Drawing.Size(24, 24);
            this.bn_btnPrevious.Tag = "2";
            // 
            // bn_tss2
            // 
            this.bn_tss2.Name = "bn_tss2";
            this.bn_tss2.Size = new System.Drawing.Size(6, 27);
            // 
            // bn_btnGoto
            // 
            this.bn_btnGoto.AutoToolTip = false;
            this.bn_btnGoto.BackColor = System.Drawing.SystemColors.Control;
            this.bn_btnGoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bn_btnGoto.Image = global::ERPSupport.SupForm.Properties.Resources.control_repeat_blue;
            this.bn_btnGoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bn_btnGoto.Name = "bn_btnGoto";
            this.bn_btnGoto.Size = new System.Drawing.Size(24, 24);
            this.bn_btnGoto.Tag = "3";
            // 
            // bn_lblThe
            // 
            this.bn_lblThe.Name = "bn_lblThe";
            this.bn_lblThe.Size = new System.Drawing.Size(20, 24);
            this.bn_lblThe.Text = "第";
            // 
            // bn_txtCurrentPage
            // 
            this.bn_txtCurrentPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bn_txtCurrentPage.Name = "bn_txtCurrentPage";
            this.bn_txtCurrentPage.Size = new System.Drawing.Size(40, 27);
            // 
            // bn_lblSeparate
            // 
            this.bn_lblSeparate.Name = "bn_lblSeparate";
            this.bn_lblSeparate.Size = new System.Drawing.Size(45, 24);
            this.bn_lblSeparate.Text = "页 / 共";
            // 
            // bn_lblPageCount
            // 
            this.bn_lblPageCount.Name = "bn_lblPageCount";
            this.bn_lblPageCount.Size = new System.Drawing.Size(20, 24);
            this.bn_lblPageCount.Text = "页";
            // 
            // bn_tss3
            // 
            this.bn_tss3.Name = "bn_tss3";
            this.bn_tss3.Size = new System.Drawing.Size(6, 27);
            // 
            // bn_lblRecordCount
            // 
            this.bn_lblRecordCount.Name = "bn_lblRecordCount";
            this.bn_lblRecordCount.Size = new System.Drawing.Size(20, 24);
            this.bn_lblRecordCount.Text = "行";
            // 
            // bn_tss4
            // 
            this.bn_tss4.Name = "bn_tss4";
            this.bn_tss4.Size = new System.Drawing.Size(6, 27);
            // 
            // bn_btnNext
            // 
            this.bn_btnNext.AutoToolTip = false;
            this.bn_btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.bn_btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bn_btnNext.Image = global::ERPSupport.SupForm.Properties.Resources.control_play_blue;
            this.bn_btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bn_btnNext.Name = "bn_btnNext";
            this.bn_btnNext.Size = new System.Drawing.Size(24, 24);
            this.bn_btnNext.Tag = "4";
            // 
            // bn_btnLast
            // 
            this.bn_btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bn_btnLast.Image = global::ERPSupport.SupForm.Properties.Resources.control_end_blue;
            this.bn_btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bn_btnLast.Name = "bn_btnLast";
            this.bn_btnLast.Size = new System.Drawing.Size(24, 24);
            this.bn_btnLast.Tag = "5";
            // 
            // bn_tss5
            // 
            this.bn_tss5.Name = "bn_tss5";
            this.bn_tss5.Size = new System.Drawing.Size(6, 27);
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
            this.dgv1.Location = new System.Drawing.Point(0, 30);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(522, 622);
            this.dgv1.TabIndex = 4;
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.Frozen = true;
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ToolTipText = "勾选";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // bnTop_tss2
            // 
            this.bnTop_tss2.Name = "bnTop_tss2";
            this.bnTop_tss2.Size = new System.Drawing.Size(6, 27);
            // 
            // bnTop_btnImport
            // 
            this.bnTop_btnImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnTop_btnImport.Image = global::ERPSupport.SupForm.Properties.Resources.page_excel;
            this.bnTop_btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnImport.Name = "bnTop_btnImport";
            this.bnTop_btnImport.Size = new System.Drawing.Size(80, 24);
            this.bnTop_btnImport.Text = "仓位导入";
            this.bnTop_btnImport.ToolTipText = "选择Excel报表导入仓位到WMS系统";
            this.bnTop_btnImport.Click += new System.EventHandler(this.bnTop_btnImport_Click);
            // 
            // frmPro_Dir_WMSSPSyn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 682);
            this.Controls.Add(this.bnTop);
            this.Controls.Add(this.bn1);
            this.Controls.Add(this.dgv1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPro_Dir_WMSSPSyn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMS仓位同步";
            this.Load += new System.EventHandler(this.frmPro_Dir_WMSSPSyn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).EndInit();
            this.bnTop.ResumeLayout(false);
            this.bnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bn1)).EndInit();
            this.bn1.ResumeLayout(false);
            this.bn1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnTop;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss1;
        private System.Windows.Forms.ToolStripLabel bnTop_lblNumber;
        private System.Windows.Forms.ToolStripButton bnTop_btnCommit;
        private System.Windows.Forms.ToolStripButton bnTop_btnCommitAll;
        private System.Windows.Forms.BindingNavigator bn1;
        private System.Windows.Forms.ToolStripLabel bn_lblPageSize;
        private System.Windows.Forms.ToolStripComboBox bn_cbxPageSize;
        private System.Windows.Forms.ToolStripSeparator bn_tss1;
        private System.Windows.Forms.ToolStripButton bn_btnStart;
        private System.Windows.Forms.ToolStripButton bn_btnPrevious;
        private System.Windows.Forms.ToolStripSeparator bn_tss2;
        private System.Windows.Forms.ToolStripButton bn_btnGoto;
        private System.Windows.Forms.ToolStripLabel bn_lblThe;
        private System.Windows.Forms.ToolStripTextBox bn_txtCurrentPage;
        private System.Windows.Forms.ToolStripLabel bn_lblSeparate;
        private System.Windows.Forms.ToolStripLabel bn_lblPageCount;
        private System.Windows.Forms.ToolStripSeparator bn_tss3;
        private System.Windows.Forms.ToolStripLabel bn_lblRecordCount;
        private System.Windows.Forms.ToolStripSeparator bn_tss4;
        private System.Windows.Forms.ToolStripButton bn_btnNext;
        private System.Windows.Forms.ToolStripButton bn_btnLast;
        private System.Windows.Forms.ToolStripSeparator bn_tss5;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.BindingSource bs1;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss2;
        private System.Windows.Forms.ToolStripButton bnTop_btnImport;
    }
}
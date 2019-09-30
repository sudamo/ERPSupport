namespace ERPSupport.SupForm.Bussiness
{
    partial class frmCPDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCPDB));
            this.dgv1 = new System.Windows.Forms.DataGridView();
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
            this.bn_lblLockQty = new System.Windows.Forms.ToolStripLabel();
            this.bn_tss4 = new System.Windows.Forms.ToolStripSeparator();
            this.bn_btnNext = new System.Windows.Forms.ToolStripButton();
            this.bn_btnLast = new System.Windows.Forms.ToolStripButton();
            this.bn_tss5 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_btnFilter = new System.Windows.Forms.ToolStripButton();
            this.bnTop_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_lblDep = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_cbxDep = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_lblInStock = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_cbxInStock = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_tss3 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnCommit = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnPush = new System.Windows.Forms.ToolStripButton();
            this.bs1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn1)).BeginInit();
            this.bn1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs1)).BeginInit();
            this.SuspendLayout();
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
            this.dgv1.Location = new System.Drawing.Point(0, 35);
            this.dgv1.Margin = new System.Windows.Forms.Padding(4);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(1173, 632);
            this.dgv1.TabIndex = 1;
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
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
            this.bn_lblLockQty,
            this.bn_tss4,
            this.bn_btnNext,
            this.bn_btnLast,
            this.bn_tss5});
            this.bn1.Location = new System.Drawing.Point(0, 674);
            this.bn1.MoveFirstItem = null;
            this.bn1.MoveLastItem = null;
            this.bn1.MoveNextItem = null;
            this.bn1.MovePreviousItem = null;
            this.bn1.Name = "bn1";
            this.bn1.PositionItem = null;
            this.bn1.Size = new System.Drawing.Size(1179, 28);
            this.bn1.TabIndex = 2;
            this.bn1.Text = "bindingNavigator1";
            this.bn1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bn1_ItemClicked);
            // 
            // bn_lblPageSize
            // 
            this.bn_lblPageSize.Name = "bn_lblPageSize";
            this.bn_lblPageSize.Size = new System.Drawing.Size(69, 25);
            this.bn_lblPageSize.Text = "每页显示";
            // 
            // bn_cbxPageSize
            // 
            this.bn_cbxPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bn_cbxPageSize.Name = "bn_cbxPageSize";
            this.bn_cbxPageSize.Size = new System.Drawing.Size(99, 28);
            this.bn_cbxPageSize.ToolTipText = "每页显示行数";
            this.bn_cbxPageSize.SelectedIndexChanged += new System.EventHandler(this.bn_cbxPageSize_SelectedIndexChanged);
            // 
            // bn_tss1
            // 
            this.bn_tss1.Name = "bn_tss1";
            this.bn_tss1.Size = new System.Drawing.Size(6, 28);
            // 
            // bn_btnStart
            // 
            this.bn_btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bn_btnStart.Image = global::ERPSupport.SupForm.Properties.Resources.control_start_blue;
            this.bn_btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bn_btnStart.Name = "bn_btnStart";
            this.bn_btnStart.Size = new System.Drawing.Size(24, 25);
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
            this.bn_btnPrevious.Size = new System.Drawing.Size(24, 25);
            this.bn_btnPrevious.Tag = "2";
            // 
            // bn_tss2
            // 
            this.bn_tss2.Name = "bn_tss2";
            this.bn_tss2.Size = new System.Drawing.Size(6, 28);
            // 
            // bn_btnGoto
            // 
            this.bn_btnGoto.AutoToolTip = false;
            this.bn_btnGoto.BackColor = System.Drawing.SystemColors.Control;
            this.bn_btnGoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bn_btnGoto.Image = global::ERPSupport.SupForm.Properties.Resources.control_repeat_blue;
            this.bn_btnGoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bn_btnGoto.Name = "bn_btnGoto";
            this.bn_btnGoto.Size = new System.Drawing.Size(24, 25);
            this.bn_btnGoto.Tag = "3";
            // 
            // bn_lblThe
            // 
            this.bn_lblThe.Name = "bn_lblThe";
            this.bn_lblThe.Size = new System.Drawing.Size(24, 25);
            this.bn_lblThe.Text = "第";
            // 
            // bn_txtCurrentPage
            // 
            this.bn_txtCurrentPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bn_txtCurrentPage.Name = "bn_txtCurrentPage";
            this.bn_txtCurrentPage.Size = new System.Drawing.Size(52, 28);
            // 
            // bn_lblSeparate
            // 
            this.bn_lblSeparate.Name = "bn_lblSeparate";
            this.bn_lblSeparate.Size = new System.Drawing.Size(53, 25);
            this.bn_lblSeparate.Text = "页 / 共";
            // 
            // bn_lblPageCount
            // 
            this.bn_lblPageCount.Name = "bn_lblPageCount";
            this.bn_lblPageCount.Size = new System.Drawing.Size(24, 25);
            this.bn_lblPageCount.Text = "页";
            // 
            // bn_tss3
            // 
            this.bn_tss3.Name = "bn_tss3";
            this.bn_tss3.Size = new System.Drawing.Size(6, 28);
            // 
            // bn_lblRecordCount
            // 
            this.bn_lblRecordCount.Name = "bn_lblRecordCount";
            this.bn_lblRecordCount.Size = new System.Drawing.Size(24, 25);
            this.bn_lblRecordCount.Text = "行";
            // 
            // bn_lblLockQty
            // 
            this.bn_lblLockQty.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bn_lblLockQty.Name = "bn_lblLockQty";
            this.bn_lblLockQty.Size = new System.Drawing.Size(84, 25);
            this.bn_lblLockQty.Text = "@锁库数：";
            // 
            // bn_tss4
            // 
            this.bn_tss4.Name = "bn_tss4";
            this.bn_tss4.Size = new System.Drawing.Size(6, 28);
            // 
            // bn_btnNext
            // 
            this.bn_btnNext.AutoToolTip = false;
            this.bn_btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.bn_btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bn_btnNext.Image = global::ERPSupport.SupForm.Properties.Resources.control_play_blue;
            this.bn_btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bn_btnNext.Name = "bn_btnNext";
            this.bn_btnNext.Size = new System.Drawing.Size(24, 25);
            this.bn_btnNext.Tag = "4";
            // 
            // bn_btnLast
            // 
            this.bn_btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bn_btnLast.Image = global::ERPSupport.SupForm.Properties.Resources.control_end_blue;
            this.bn_btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bn_btnLast.Name = "bn_btnLast";
            this.bn_btnLast.Size = new System.Drawing.Size(24, 25);
            this.bn_btnLast.Tag = "5";
            // 
            // bn_tss5
            // 
            this.bn_tss5.Name = "bn_tss5";
            this.bn_tss5.Size = new System.Drawing.Size(6, 28);
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.CountItemFormat = "部门：";
            this.bnTop.DeleteItem = null;
            this.bnTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_btnFilter,
            this.bnTop_tss1,
            this.bnTop_lblDep,
            this.bnTop_cbxDep,
            this.bnTop_tss2,
            this.bnTop_lblInStock,
            this.bnTop_cbxInStock,
            this.bnTop_tss3,
            this.bnTop_btnCommit,
            this.bnTop_btnPush});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(1179, 28);
            this.bnTop.TabIndex = 0;
            this.bnTop.Text = "bindingNavigator1";
            this.bnTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bnTop_ItemClicked);
            // 
            // bnTop_btnFilter
            // 
            this.bnTop_btnFilter.Image = global::ERPSupport.SupForm.Properties.Resources.add;
            this.bnTop_btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnFilter.Name = "bnTop_btnFilter";
            this.bnTop_btnFilter.Size = new System.Drawing.Size(63, 25);
            this.bnTop_btnFilter.Tag = "1";
            this.bnTop_btnFilter.Text = "过滤";
            // 
            // bnTop_tss1
            // 
            this.bnTop_tss1.Name = "bnTop_tss1";
            this.bnTop_tss1.Size = new System.Drawing.Size(6, 28);
            // 
            // bnTop_lblDep
            // 
            this.bnTop_lblDep.Name = "bnTop_lblDep";
            this.bnTop_lblDep.Size = new System.Drawing.Size(54, 25);
            this.bnTop_lblDep.Text = "部门：";
            // 
            // bnTop_cbxDep
            // 
            this.bnTop_cbxDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxDep.Name = "bnTop_cbxDep";
            this.bnTop_cbxDep.Size = new System.Drawing.Size(160, 28);
            // 
            // bnTop_tss2
            // 
            this.bnTop_tss2.Name = "bnTop_tss2";
            this.bnTop_tss2.Size = new System.Drawing.Size(6, 28);
            // 
            // bnTop_lblInStock
            // 
            this.bnTop_lblInStock.Name = "bnTop_lblInStock";
            this.bnTop_lblInStock.Size = new System.Drawing.Size(84, 25);
            this.bnTop_lblInStock.Text = "调入仓库：";
            // 
            // bnTop_cbxInStock
            // 
            this.bnTop_cbxInStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxInStock.Name = "bnTop_cbxInStock";
            this.bnTop_cbxInStock.Size = new System.Drawing.Size(160, 28);
            // 
            // bnTop_tss3
            // 
            this.bnTop_tss3.Name = "bnTop_tss3";
            this.bnTop_tss3.Size = new System.Drawing.Size(6, 28);
            // 
            // bnTop_btnCommit
            // 
            this.bnTop_btnCommit.Image = global::ERPSupport.SupForm.Properties.Resources.accept;
            this.bnTop_btnCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnCommit.Name = "bnTop_btnCommit";
            this.bnTop_btnCommit.Size = new System.Drawing.Size(63, 25);
            this.bnTop_btnCommit.Tag = "2";
            this.bnTop_btnCommit.Text = "调拨";
            // 
            // bnTop_btnPush
            // 
            this.bnTop_btnPush.Image = global::ERPSupport.SupForm.Properties.Resources.three_tags;
            this.bnTop_btnPush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnPush.Name = "bnTop_btnPush";
            this.bnTop_btnPush.Size = new System.Drawing.Size(138, 25);
            this.bnTop_btnPush.Tag = "3";
            this.bnTop_btnPush.Text = "发货通知单调拨";
            this.bnTop_btnPush.ToolTipText = "根据发货通知单下推成品调拨单";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "chb";
            this.dataGridViewCheckBoxColumn1.FalseValue = "false";
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.TrueValue = "true";
            this.dataGridViewCheckBoxColumn1.Width = 20;
            // 
            // frmCPDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 702);
            this.Controls.Add(this.bnTop);
            this.Controls.Add(this.bn1);
            this.Controls.Add(this.dgv1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1194, 738);
            this.Name = "frmCPDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成品调拨";
            this.Load += new System.EventHandler(this.frmCPDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn1)).EndInit();
            this.bn1.ResumeLayout(false);
            this.bn1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).EndInit();
            this.bnTop.ResumeLayout(false);
            this.bnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.BindingNavigator bn1;
        private System.Windows.Forms.ToolStripSeparator bn_tss1;
        private System.Windows.Forms.ToolStripButton bn_btnPrevious;
        private System.Windows.Forms.ToolStripSeparator bn_tss2;
        private System.Windows.Forms.ToolStripButton bn_btnNext;
        private System.Windows.Forms.ToolStripSeparator bn_tss3;
        private System.Windows.Forms.ToolStripSeparator bn_tss4;
        private System.Windows.Forms.ToolStripButton bn_btnGoto;
        private System.Windows.Forms.ToolStripSeparator bn_tss5;
        private System.Windows.Forms.ToolStripTextBox bn_txtCurrentPage;
        private System.Windows.Forms.ToolStripLabel bn_lblSeparate;
        private System.Windows.Forms.ToolStripLabel bn_lblPageCount;
        private System.Windows.Forms.ToolStripComboBox bn_cbxPageSize;
        private System.Windows.Forms.ToolStripLabel bn_lblPageSize;
        private System.Windows.Forms.ToolStripLabel bn_lblRecordCount;
        private System.Windows.Forms.ToolStripLabel bn_lblLockQty;
        private System.Windows.Forms.BindingSource bs1;
        private System.Windows.Forms.ToolStripLabel bn_lblThe;
        private System.Windows.Forms.ToolStripButton bn_btnStart;
        private System.Windows.Forms.ToolStripButton bn_btnLast;
        private System.Windows.Forms.BindingNavigator bnTop;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss1;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss2;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss3;
        private System.Windows.Forms.ToolStripButton bnTop_btnFilter;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxDep;
        private System.Windows.Forms.ToolStripLabel bnTop_lblInStock;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxInStock;
        private System.Windows.Forms.ToolStripButton bnTop_btnCommit;
        private System.Windows.Forms.ToolStripButton bnTop_btnPush;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.ToolStripLabel bnTop_lblDep;
    }
}
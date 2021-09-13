namespace ERPSupport.SupForm.Menu
{
    partial class frmPro_K3Data_Bas_Mtl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPro_K3Data_Bas_Mtl));
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_cbxType = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_cbxYear = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_lblYear = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_cbxMonth = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_lblMonth = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_btnDel = new System.Windows.Forms.ToolStripButton();
            this.bnTop_btnSyn = new System.Windows.Forms.ToolStripButton();
            this.bnTop_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnCheck = new System.Windows.Forms.ToolStripButton();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.cmsPaste = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsPaste_Area = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t1 = new System.Windows.Forms.ToolTip(this.components);
            this.FNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.cmsPaste.SuspendLayout();
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
            this.bnTop_cbxType,
            this.bnTop_cbxYear,
            this.bnTop_lblYear,
            this.bnTop_cbxMonth,
            this.bnTop_lblMonth,
            this.bnTop_btnDel,
            this.bnTop_btnSyn,
            this.bnTop_tss1,
            this.bnTop_btnCheck});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(484, 27);
            this.bnTop.TabIndex = 1;
            this.bnTop.Text = "bindingNavigator1";
            // 
            // bnTop_cbxType
            // 
            this.bnTop_cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxType.Name = "bnTop_cbxType";
            this.bnTop_cbxType.Size = new System.Drawing.Size(100, 27);
            this.bnTop_cbxType.SelectedIndexChanged += new System.EventHandler(this.bnTop_cbxType_SelectedIndexChanged);
            // 
            // bnTop_cbxYear
            // 
            this.bnTop_cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxYear.Name = "bnTop_cbxYear";
            this.bnTop_cbxYear.Size = new System.Drawing.Size(75, 27);
            this.bnTop_cbxYear.Visible = false;
            // 
            // bnTop_lblYear
            // 
            this.bnTop_lblYear.Name = "bnTop_lblYear";
            this.bnTop_lblYear.Size = new System.Drawing.Size(20, 24);
            this.bnTop_lblYear.Text = "年";
            this.bnTop_lblYear.Visible = false;
            // 
            // bnTop_cbxMonth
            // 
            this.bnTop_cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxMonth.Name = "bnTop_cbxMonth";
            this.bnTop_cbxMonth.Size = new System.Drawing.Size(75, 27);
            this.bnTop_cbxMonth.Visible = false;
            // 
            // bnTop_lblMonth
            // 
            this.bnTop_lblMonth.Name = "bnTop_lblMonth";
            this.bnTop_lblMonth.Size = new System.Drawing.Size(20, 24);
            this.bnTop_lblMonth.Text = "月";
            this.bnTop_lblMonth.Visible = false;
            // 
            // bnTop_btnDel
            // 
            this.bnTop_btnDel.Image = global::ERPSupport.SupForm.Properties.Resources.delete;
            this.bnTop_btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnDel.Name = "bnTop_btnDel";
            this.bnTop_btnDel.Size = new System.Drawing.Size(68, 24);
            this.bnTop_btnDel.Text = "行删除";
            this.bnTop_btnDel.ToolTipText = "选择数据行(可多行)删除";
            this.bnTop_btnDel.Click += new System.EventHandler(this.bnTop_btnDel_Click);
            // 
            // bnTop_btnSyn
            // 
            this.bnTop_btnSyn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnTop_btnSyn.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_refresh;
            this.bnTop_btnSyn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnSyn.Name = "bnTop_btnSyn";
            this.bnTop_btnSyn.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnSyn.Tag = "2";
            this.bnTop_btnSyn.Text = "同步";
            this.bnTop_btnSyn.ToolTipText = "同步物料名称";
            this.bnTop_btnSyn.Click += new System.EventHandler(this.bnTop_btnSyn_Click);
            // 
            // bnTop_tss1
            // 
            this.bnTop_tss1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnTop_tss1.Name = "bnTop_tss1";
            this.bnTop_tss1.Size = new System.Drawing.Size(6, 27);
            // 
            // bnTop_btnCheck
            // 
            this.bnTop_btnCheck.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnTop_btnCheck.Image = global::ERPSupport.SupForm.Properties.Resources.report_magnify;
            this.bnTop_btnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnCheck.Name = "bnTop_btnCheck";
            this.bnTop_btnCheck.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnCheck.Text = "检查";
            this.bnTop_btnCheck.Click += new System.EventHandler(this.bnTop_btnCheck_Click);
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FNumber,
            this.FCheck,
            this.FResult});
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(0, 27);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(484, 535);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv1_CellMouseClick);
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
            this.dgv1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv1_UserDeletedRow);
            // 
            // cmsPaste
            // 
            this.cmsPaste.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsPaste_Area});
            this.cmsPaste.Name = "contextMenuStrip1";
            this.cmsPaste.Size = new System.Drawing.Size(113, 26);
            // 
            // cmsPaste_Area
            // 
            this.cmsPaste_Area.Name = "cmsPaste_Area";
            this.cmsPaste_Area.Size = new System.Drawing.Size(112, 22);
            this.cmsPaste_Area.Text = "块粘贴";
            this.cmsPaste_Area.Click += new System.EventHandler(this.cmsPaste_Area_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 50F;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "物料编码";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.ToolTipText = "输入需要同步的物料编码";
            this.dataGridViewTextBoxColumn1.Width = 160;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "检查结果";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ToolTipText = "检查结果";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.FillWeight = 50F;
            this.dataGridViewTextBoxColumn3.HeaderText = "同步结果";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ToolTipText = "同步执行结果";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // FNumber
            // 
            this.FNumber.Frozen = true;
            this.FNumber.HeaderText = "物料编码";
            this.FNumber.Name = "FNumber";
            this.FNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FNumber.ToolTipText = "输入需要同步的物料编码";
            this.FNumber.Width = 130;
            // 
            // FCheck
            // 
            this.FCheck.HeaderText = "检查结果";
            this.FCheck.Name = "FCheck";
            this.FCheck.ToolTipText = "检查结果";
            // 
            // FResult
            // 
            this.FResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FResult.FillWeight = 50F;
            this.FResult.HeaderText = "同步结果";
            this.FResult.Name = "FResult";
            this.FResult.ToolTipText = "同步执行结果";
            this.FResult.Width = 185;
            // 
            // frmPro_K3Data_Bas_Mtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 562);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.bnTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "frmPro_K3Data_Bas_Mtl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "同步物料名称";
            this.Load += new System.EventHandler(this.frmPro_K3Data_Bas_Mtl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).EndInit();
            this.bnTop.ResumeLayout(false);
            this.bnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.cmsPaste.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnTop;
        private System.Windows.Forms.ToolStripButton bnTop_btnSyn;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.ToolStripButton bnTop_btnCheck;
        private System.Windows.Forms.ContextMenuStrip cmsPaste;
        private System.Windows.Forms.ToolStripMenuItem cmsPaste_Area;
        private System.Windows.Forms.ToolStripButton bnTop_btnDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxType;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxYear;
        private System.Windows.Forms.ToolStripLabel bnTop_lblYear;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxMonth;
        private System.Windows.Forms.ToolStripLabel bnTop_lblMonth;
        private System.Windows.Forms.ToolTip t1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn FResult;
    }
}
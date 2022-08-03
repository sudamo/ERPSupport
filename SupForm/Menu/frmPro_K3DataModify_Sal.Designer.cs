namespace ERPSupport.SupForm.Menu
{
    partial class frmPro_K3DataModify_Sal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPro_K3DataModify_Sal));
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_btnModify = new System.Windows.Forms.ToolStripButton();
            this.bnTop_tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_btnCheck = new System.Windows.Forms.ToolStripButton();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.FBillNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCARRIAGENO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_PAEZ_LOGISTCSCOMPANY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDELIVERYDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiPaste_Area = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.cms.SuspendLayout();
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
            this.bnTop_btnModify,
            this.bnTop_tss1,
            this.bnTop_btnCheck});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(684, 27);
            this.bnTop.TabIndex = 2;
            this.bnTop.Text = "bindingNavigator1";
            // 
            // bnTop_btnModify
            // 
            this.bnTop_btnModify.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnTop_btnModify.Image = global::ERPSupport.SupForm.Properties.Resources.livejournal;
            this.bnTop_btnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_btnModify.Name = "bnTop_btnModify";
            this.bnTop_btnModify.Size = new System.Drawing.Size(56, 24);
            this.bnTop_btnModify.Tag = "2";
            this.bnTop_btnModify.Text = "修改";
            this.bnTop_btnModify.ToolTipText = "修改数据";
            this.bnTop_btnModify.Click += new System.EventHandler(this.bnTop_btnModify_Click);
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
            this.FBillNO,
            this.FCARRIAGENO,
            this.F_PAEZ_LOGISTCSCOMPANY,
            this.FDELIVERYDATE,
            this.Result});
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(0, 27);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(684, 434);
            this.dgv1.TabIndex = 3;
            this.dgv1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv1_CellMouseClick);
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
            // 
            // FBillNO
            // 
            this.FBillNO.Frozen = true;
            this.FBillNO.HeaderText = "单据编号";
            this.FBillNO.Name = "FBillNO";
            this.FBillNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FBillNO.ToolTipText = "销售订单/出库单";
            this.FBillNO.Width = 130;
            // 
            // FCARRIAGENO
            // 
            this.FCARRIAGENO.HeaderText = "快递单号";
            this.FCARRIAGENO.Name = "FCARRIAGENO";
            this.FCARRIAGENO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FCARRIAGENO.ToolTipText = "运输单号";
            // 
            // F_PAEZ_LOGISTCSCOMPANY
            // 
            this.F_PAEZ_LOGISTCSCOMPANY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.F_PAEZ_LOGISTCSCOMPANY.FillWeight = 50F;
            this.F_PAEZ_LOGISTCSCOMPANY.HeaderText = "快递公司";
            this.F_PAEZ_LOGISTCSCOMPANY.Name = "F_PAEZ_LOGISTCSCOMPANY";
            this.F_PAEZ_LOGISTCSCOMPANY.ToolTipText = "物流公司";
            this.F_PAEZ_LOGISTCSCOMPANY.Width = 185;
            // 
            // FDELIVERYDATE
            // 
            this.FDELIVERYDATE.HeaderText = "发货日期";
            this.FDELIVERYDATE.Name = "FDELIVERYDATE";
            // 
            // Result
            // 
            this.Result.HeaderText = "结果";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPaste_Area,
            this.tsmiDel});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(113, 48);
            // 
            // tsmiPaste_Area
            // 
            this.tsmiPaste_Area.Name = "tsmiPaste_Area";
            this.tsmiPaste_Area.Size = new System.Drawing.Size(112, 22);
            this.tsmiPaste_Area.Text = "块粘贴";
            this.tsmiPaste_Area.Click += new System.EventHandler(this.tsmiPaste_Area_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Name = "tsmiDel";
            this.tsmiDel.Size = new System.Drawing.Size(112, 22);
            this.tsmiDel.Text = "删除行";
            this.tsmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "单价编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.ToolTipText = "销售订单/出库单";
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "快递单号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.ToolTipText = "运输单号";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.FillWeight = 50F;
            this.dataGridViewTextBoxColumn3.HeaderText = "快递公司";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ToolTipText = "物流公司";
            this.dataGridViewTextBoxColumn3.Width = 185;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "发货日期";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "结果";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // frmPro_K3DataModify_Sal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.bnTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPro_K3DataModify_Sal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "K3数据调整";
            this.Load += new System.EventHandler(this.frmPro_K3DataModify_Sal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).EndInit();
            this.bnTop.ResumeLayout(false);
            this.bnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnTop;
        private System.Windows.Forms.ToolStripButton bnTop_btnModify;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss1;
        private System.Windows.Forms.ToolStripButton bnTop_btnCheck;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste_Area;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn FBillNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCARRIAGENO;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_PAEZ_LOGISTCSCOMPANY;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDELIVERYDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
    }
}
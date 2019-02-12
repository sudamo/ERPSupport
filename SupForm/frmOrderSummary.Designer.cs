namespace ERPSupport.SupForm
{
    partial class frmOrderSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderSummary));
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpPlanEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpPlanStar = new System.Windows.Forms.DateTimePicker();
            this.cbxWorkShop = new System.Windows.Forms.ComboBox();
            this.lblPlanEnd = new System.Windows.Forms.Label();
            this.lblPlanStar = new System.Windows.Forms.Label();
            this.lblWorkShop = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.chbLackMatrial = new System.Windows.Forms.CheckBox();
            this.btnMo = new System.Windows.Forms.Button();
            this.btnPo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgv1.Location = new System.Drawing.Point(0, 37);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1008, 691);
            this.dgv1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "选择";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpPlanEnd);
            this.panel1.Controls.Add(this.dtpPlanStar);
            this.panel1.Controls.Add(this.cbxWorkShop);
            this.panel1.Controls.Add(this.lblPlanEnd);
            this.panel1.Controls.Add(this.lblPlanStar);
            this.panel1.Controls.Add(this.lblWorkShop);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.chbLackMatrial);
            this.panel1.Controls.Add(this.btnMo);
            this.panel1.Controls.Add(this.btnPo);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 31);
            this.panel1.TabIndex = 1;
            // 
            // dtpPlanEnd
            // 
            this.dtpPlanEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanEnd.Location = new System.Drawing.Point(801, 4);
            this.dtpPlanEnd.Name = "dtpPlanEnd";
            this.dtpPlanEnd.Size = new System.Drawing.Size(85, 21);
            this.dtpPlanEnd.TabIndex = 5;
            // 
            // dtpPlanStar
            // 
            this.dtpPlanStar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanStar.Location = new System.Drawing.Point(627, 4);
            this.dtpPlanStar.Name = "dtpPlanStar";
            this.dtpPlanStar.Size = new System.Drawing.Size(85, 21);
            this.dtpPlanStar.TabIndex = 5;
            // 
            // cbxWorkShop
            // 
            this.cbxWorkShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWorkShop.FormattingEnabled = true;
            this.cbxWorkShop.Location = new System.Drawing.Point(425, 4);
            this.cbxWorkShop.Name = "cbxWorkShop";
            this.cbxWorkShop.Size = new System.Drawing.Size(113, 20);
            this.cbxWorkShop.TabIndex = 4;
            // 
            // lblPlanEnd
            // 
            this.lblPlanEnd.AutoSize = true;
            this.lblPlanEnd.Location = new System.Drawing.Point(718, 7);
            this.lblPlanEnd.Name = "lblPlanEnd";
            this.lblPlanEnd.Size = new System.Drawing.Size(77, 12);
            this.lblPlanEnd.TabIndex = 3;
            this.lblPlanEnd.Text = "计划完工时间";
            // 
            // lblPlanStar
            // 
            this.lblPlanStar.AutoSize = true;
            this.lblPlanStar.Location = new System.Drawing.Point(544, 7);
            this.lblPlanStar.Name = "lblPlanStar";
            this.lblPlanStar.Size = new System.Drawing.Size(77, 12);
            this.lblPlanStar.TabIndex = 3;
            this.lblPlanStar.Text = "计划开工时间";
            // 
            // lblWorkShop
            // 
            this.lblWorkShop.AutoSize = true;
            this.lblWorkShop.Location = new System.Drawing.Point(366, 7);
            this.lblWorkShop.Name = "lblWorkShop";
            this.lblWorkShop.Size = new System.Drawing.Size(53, 12);
            this.lblWorkShop.TabIndex = 3;
            this.lblWorkShop.Text = "生产车间";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(3, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 20);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "全部选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // chbLackMatrial
            // 
            this.chbLackMatrial.AutoSize = true;
            this.chbLackMatrial.Enabled = false;
            this.chbLackMatrial.Location = new System.Drawing.Point(84, 6);
            this.chbLackMatrial.Name = "chbLackMatrial";
            this.chbLackMatrial.Size = new System.Drawing.Size(84, 16);
            this.chbLackMatrial.TabIndex = 1;
            this.chbLackMatrial.Text = "仅显示缺料";
            this.chbLackMatrial.UseVisualStyleBackColor = true;
            // 
            // btnMo
            // 
            this.btnMo.Location = new System.Drawing.Point(916, 3);
            this.btnMo.Name = "btnMo";
            this.btnMo.Size = new System.Drawing.Size(80, 20);
            this.btnMo.TabIndex = 0;
            this.btnMo.Text = "生产订单";
            this.btnMo.UseVisualStyleBackColor = true;
            this.btnMo.Click += new System.EventHandler(this.btnMo_Click);
            // 
            // btnPo
            // 
            this.btnPo.Location = new System.Drawing.Point(280, 3);
            this.btnPo.Name = "btnPo";
            this.btnPo.Size = new System.Drawing.Size(80, 20);
            this.btnPo.TabIndex = 0;
            this.btnPo.Text = "采购申请单";
            this.btnPo.UseVisualStyleBackColor = true;
            this.btnPo.Click += new System.EventHandler(this.btnPo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(174, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 20);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存汇总结果";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmOrderSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrderSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单运算汇总";
            this.Load += new System.EventHandler(this.frmOrderSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMo;
        private System.Windows.Forms.Button btnPo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chbLackMatrial;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cbxWorkShop;
        private System.Windows.Forms.Label lblWorkShop;
        private System.Windows.Forms.DateTimePicker dtpPlanEnd;
        private System.Windows.Forms.DateTimePicker dtpPlanStar;
        private System.Windows.Forms.Label lblPlanEnd;
        private System.Windows.Forms.Label lblPlanStar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}
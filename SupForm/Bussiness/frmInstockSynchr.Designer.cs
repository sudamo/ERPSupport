namespace ERPSupport.SupForm.Bussiness
{
    partial class frmInstockSynchr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstockSynchr));
            this.lblBillno = new System.Windows.Forms.Label();
            this.txtBillno = new System.Windows.Forms.TextBox();
            this.btnSynchr = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBillno
            // 
            this.lblBillno.AutoSize = true;
            this.lblBillno.Location = new System.Drawing.Point(9, 9);
            this.lblBillno.Name = "lblBillno";
            this.lblBillno.Size = new System.Drawing.Size(77, 12);
            this.lblBillno.TabIndex = 0;
            this.lblBillno.Text = "入库单编号：";
            // 
            // txtBillno
            // 
            this.txtBillno.Location = new System.Drawing.Point(92, 6);
            this.txtBillno.Name = "txtBillno";
            this.txtBillno.Size = new System.Drawing.Size(100, 21);
            this.txtBillno.TabIndex = 1;
            this.txtBillno.TextChanged += new System.EventHandler(this.txtBillno_TextChanged);
            // 
            // btnSynchr
            // 
            this.btnSynchr.Enabled = false;
            this.btnSynchr.Location = new System.Drawing.Point(320, 4);
            this.btnSynchr.Name = "btnSynchr";
            this.btnSynchr.Size = new System.Drawing.Size(75, 23);
            this.btnSynchr.TabIndex = 2;
            this.btnSynchr.Text = "同步";
            this.btnSynchr.UseVisualStyleBackColor = true;
            this.btnSynchr.Click += new System.EventHandler(this.btnSynchr_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(3, 33);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(393, 292);
            this.dgv1.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(239, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmInstockSynchr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 327);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSynchr);
            this.Controls.Add(this.txtBillno);
            this.Controls.Add(this.lblBillno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(415, 365);
            this.MinimumSize = new System.Drawing.Size(415, 365);
            this.Name = "frmInstockSynchr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "根据入库单同步条码";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBillno;
        private System.Windows.Forms.TextBox txtBillno;
        private System.Windows.Forms.Button btnSynchr;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnSearch;
    }
}
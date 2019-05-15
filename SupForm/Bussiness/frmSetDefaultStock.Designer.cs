namespace ERPSupport.SupForm.Bussiness
{
    partial class frmSetDefaultStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetDefaultStock));
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.btnBatFill = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Location = new System.Drawing.Point(12, 12);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(53, 12);
            this.lblMaterialName.TabIndex = 0;
            this.lblMaterialName.Text = "物料名称";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(510, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Location = new System.Drawing.Point(70, 8);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.ReadOnly = true;
            this.txtMaterialName.Size = new System.Drawing.Size(354, 21);
            this.txtMaterialName.TabIndex = 3;
            // 
            // btnBatFill
            // 
            this.btnBatFill.Location = new System.Drawing.Point(430, 8);
            this.btnBatFill.Name = "btnBatFill";
            this.btnBatFill.Size = new System.Drawing.Size(75, 23);
            this.btnBatFill.TabIndex = 2;
            this.btnBatFill.Text = "批量填充";
            this.btnBatFill.UseVisualStyleBackColor = true;
            this.btnBatFill.Click += new System.EventHandler(this.btnBatFill_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(2, 37);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(597, 395);
            this.dgv1.TabIndex = 4;
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // frmSetDefaultStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 437);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.txtMaterialName);
            this.Controls.Add(this.btnBatFill);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMaterialName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetDefaultStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "物料默认仓库设置";
            this.Load += new System.EventHandler(this.frmSetDefaultStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Button btnBatFill;
        private System.Windows.Forms.DataGridView dgv1;
    }
}
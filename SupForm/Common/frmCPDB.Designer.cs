namespace ERPSupport.SupForm.Common
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCPDB));
            this.pl1 = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnComit = new System.Windows.Forms.Button();
            this.cbxStock = new System.Windows.Forms.ComboBox();
            this.cbxDep = new System.Windows.Forms.ComboBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblDep = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.pl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // pl1
            // 
            this.pl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pl1.Controls.Add(this.btnFilter);
            this.pl1.Controls.Add(this.btnSearch);
            this.pl1.Controls.Add(this.btnComit);
            this.pl1.Controls.Add(this.cbxStock);
            this.pl1.Controls.Add(this.cbxDep);
            this.pl1.Controls.Add(this.lblStock);
            this.pl1.Controls.Add(this.lblDep);
            this.pl1.Location = new System.Drawing.Point(0, 0);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(880, 26);
            this.pl1.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(11, 2);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(37, 20);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "过滤";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(399, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 21);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnComit
            // 
            this.btnComit.Location = new System.Drawing.Point(465, 2);
            this.btnComit.Name = "btnComit";
            this.btnComit.Size = new System.Drawing.Size(60, 21);
            this.btnComit.TabIndex = 4;
            this.btnComit.Text = "调拨";
            this.btnComit.UseVisualStyleBackColor = true;
            this.btnComit.Click += new System.EventHandler(this.btnComit_Click);
            // 
            // cbxStock
            // 
            this.cbxStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStock.FormattingEnabled = true;
            this.cbxStock.Location = new System.Drawing.Point(273, 3);
            this.cbxStock.Name = "cbxStock";
            this.cbxStock.Size = new System.Drawing.Size(120, 20);
            this.cbxStock.TabIndex = 3;
            // 
            // cbxDep
            // 
            this.cbxDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDep.FormattingEnabled = true;
            this.cbxDep.Location = new System.Drawing.Point(88, 3);
            this.cbxDep.Name = "cbxDep";
            this.cbxDep.Size = new System.Drawing.Size(120, 20);
            this.cbxDep.TabIndex = 3;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(214, 6);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(53, 12);
            this.lblStock.TabIndex = 0;
            this.lblStock.Text = "调入仓库";
            // 
            // lblDep
            // 
            this.lblDep.AutoSize = true;
            this.lblDep.Location = new System.Drawing.Point(53, 6);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(29, 12);
            this.lblDep.TabIndex = 0;
            this.lblDep.Text = "部门";
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
            this.dgv1.Location = new System.Drawing.Point(0, 32);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(880, 525);
            this.dgv1.TabIndex = 1;
            // 
            // frmCPDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.pl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmCPDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成品调拨";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCPDB_Load);
            this.pl1.ResumeLayout(false);
            this.pl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnComit;
        private System.Windows.Forms.ComboBox cbxStock;
        private System.Windows.Forms.ComboBox cbxDep;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblDep;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnFilter;
    }
}
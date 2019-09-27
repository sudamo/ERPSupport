namespace ERPSupport.SupForm.Bussiness
{
    partial class frmCPDB_Push
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCPDB_Push));
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnBottom_btnSearch = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_btnClose = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_btnPush = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_lblBillNo = new System.Windows.Forms.ToolStripLabel();
            this.bnBottom_txtBillNo = new System.Windows.Forms.ToolStripTextBox();
            this.bnBottom_lblDate = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv1.Location = new System.Drawing.Point(13, 13);
            this.dgv1.Margin = new System.Windows.Forms.Padding(4);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(756, 509);
            this.dgv1.TabIndex = 61;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            // 
            // bnBottom
            // 
            this.bnBottom.AddNewItem = null;
            this.bnBottom.CountItem = null;
            this.bnBottom.CountItemFormat = "(无)";
            this.bnBottom.DeleteItem = null;
            this.bnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnBottom_lblDate,
            this.bnBottom_lblBillNo,
            this.bnBottom_txtBillNo,
            this.bnBottom_btnSearch,
            this.bnBottom_btnClose,
            this.bnBottom_btnPush});
            this.bnBottom.Location = new System.Drawing.Point(0, 526);
            this.bnBottom.MoveFirstItem = null;
            this.bnBottom.MoveLastItem = null;
            this.bnBottom.MoveNextItem = null;
            this.bnBottom.MovePreviousItem = null;
            this.bnBottom.Name = "bnBottom";
            this.bnBottom.PositionItem = null;
            this.bnBottom.Size = new System.Drawing.Size(782, 27);
            this.bnBottom.TabIndex = 62;
            this.bnBottom.Text = "bnTop";
            // 
            // bnBottom_btnSearch
            // 
            this.bnBottom_btnSearch.Image = global::ERPSupport.SupForm.Properties.Resources.zoom;
            this.bnBottom_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnSearch.Name = "bnBottom_btnSearch";
            this.bnBottom_btnSearch.Size = new System.Drawing.Size(63, 24);
            this.bnBottom_btnSearch.Tag = "1";
            this.bnBottom_btnSearch.Text = "查找";
            this.bnBottom_btnSearch.Click += new System.EventHandler(this.bnTop_btnSearch_Click);
            // 
            // bnBottom_btnClose
            // 
            this.bnBottom_btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnBottom_btnClose.Image = global::ERPSupport.SupForm.Properties.Resources.cross;
            this.bnBottom_btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnClose.Name = "bnBottom_btnClose";
            this.bnBottom_btnClose.Size = new System.Drawing.Size(63, 24);
            this.bnBottom_btnClose.Text = "关闭";
            this.bnBottom_btnClose.ToolTipText = "关闭窗口";
            this.bnBottom_btnClose.Click += new System.EventHandler(this.bnBottom_btnClose_Click);
            // 
            // bnBottom_btnPush
            // 
            this.bnBottom_btnPush.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnBottom_btnPush.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_right;
            this.bnBottom_btnPush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnPush.Name = "bnBottom_btnPush";
            this.bnBottom_btnPush.Size = new System.Drawing.Size(63, 24);
            this.bnBottom_btnPush.Text = "下推";
            this.bnBottom_btnPush.ToolTipText = "根据所选发货通知单下推调拨单";
            this.bnBottom_btnPush.Click += new System.EventHandler(this.bnBottom_btnPush_Click);
            // 
            // bnBottom_lblBillNo
            // 
            this.bnBottom_lblBillNo.Name = "bnBottom_lblBillNo";
            this.bnBottom_lblBillNo.Size = new System.Drawing.Size(114, 24);
            this.bnBottom_lblBillNo.Text = "发后通知单号：";
            // 
            // bnBottom_txtBillNo
            // 
            this.bnBottom_txtBillNo.Name = "bnBottom_txtBillNo";
            this.bnBottom_txtBillNo.Size = new System.Drawing.Size(120, 27);
            // 
            // bnBottom_lblDate
            // 
            this.bnBottom_lblDate.Name = "bnBottom_lblDate";
            this.bnBottom_lblDate.Size = new System.Drawing.Size(54, 24);
            this.bnBottom_lblDate.Text = "日期：";
            // 
            // frmCPDB_Push
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.ControlBox = false;
            this.Controls.Add(this.bnBottom);
            this.Controls.Add(this.dgv1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmCPDB_Push";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "调拨";
            this.Load += new System.EventHandler(this.frmCPDB_Push_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripButton bnBottom_btnSearch;
        private System.Windows.Forms.ToolStripButton bnBottom_btnPush;
        private System.Windows.Forms.ToolStripButton bnBottom_btnClose;
        private System.Windows.Forms.ToolStripLabel bnBottom_lblBillNo;
        private System.Windows.Forms.ToolStripTextBox bnBottom_txtBillNo;
        private System.Windows.Forms.ToolStripLabel bnBottom_lblDate;
    }
}
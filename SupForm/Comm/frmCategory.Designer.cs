namespace ERPSupport.SupForm.Comm
{
    partial class frmCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategory));
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnBottom_btnClose = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_btnPush = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
            this.SuspendLayout();
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
            this.bnBottom_btnClose,
            this.bnBottom_btnPush});
            this.bnBottom.Location = new System.Drawing.Point(0, 45);
            this.bnBottom.MoveFirstItem = null;
            this.bnBottom.MoveLastItem = null;
            this.bnBottom.MoveNextItem = null;
            this.bnBottom.MovePreviousItem = null;
            this.bnBottom.Name = "bnBottom";
            this.bnBottom.PositionItem = null;
            this.bnBottom.Size = new System.Drawing.Size(284, 27);
            this.bnBottom.TabIndex = 2;
            this.bnBottom.Text = "bnTop";
            // 
            // bnBottom_btnClose
            // 
            this.bnBottom_btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnBottom_btnClose.Image = global::ERPSupport.SupForm.Properties.Resources.cross;
            this.bnBottom_btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnClose.Name = "bnBottom_btnClose";
            this.bnBottom_btnClose.Size = new System.Drawing.Size(56, 24);
            this.bnBottom_btnClose.Text = "关闭";
            this.bnBottom_btnClose.ToolTipText = "关闭窗口";
            this.bnBottom_btnClose.Click += new System.EventHandler(this.bnBottom_btnClose_Click);
            // 
            // bnBottom_btnPush
            // 
            this.bnBottom_btnPush.Image = global::ERPSupport.SupForm.Properties.Resources.accept;
            this.bnBottom_btnPush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnPush.Name = "bnBottom_btnPush";
            this.bnBottom_btnPush.Size = new System.Drawing.Size(56, 24);
            this.bnBottom_btnPush.Text = "确定";
            this.bnBottom_btnPush.ToolTipText = "根据所选发货通知单下推调拨单";
            this.bnBottom_btnPush.Click += new System.EventHandler(this.bnBottom_btnPush_Click);
            // 
            // frmCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 72);
            this.ControlBox = false;
            this.Controls.Add(this.bnBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "类型选择";
            this.Load += new System.EventHandler(this.frmCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripButton bnBottom_btnClose;
        private System.Windows.Forms.ToolStripButton bnBottom_btnPush;
    }
}
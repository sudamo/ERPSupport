namespace ERPSupport.SupForm.Bussiness
{
    partial class frmPPBomDir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPPBomDir));
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnBottom_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnBottom_btnEidt = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_btnCancle = new System.Windows.Forms.ToolStripButton();
            this.txtBillNos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnBottom
            // 
            this.bnBottom.AddNewItem = null;
            this.bnBottom.CountItem = null;
            this.bnBottom.DeleteItem = null;
            this.bnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnBottom_tss,
            this.bnBottom_btnEidt,
            this.bnBottom_btnCancle});
            this.bnBottom.Location = new System.Drawing.Point(0, 126);
            this.bnBottom.MoveFirstItem = null;
            this.bnBottom.MoveLastItem = null;
            this.bnBottom.MoveNextItem = null;
            this.bnBottom.MovePreviousItem = null;
            this.bnBottom.Name = "bnBottom";
            this.bnBottom.PositionItem = null;
            this.bnBottom.Size = new System.Drawing.Size(582, 27);
            this.bnBottom.TabIndex = 28;
            this.bnBottom.Text = "bindingNavigator1";
            // 
            // bnBottom_tss
            // 
            this.bnBottom_tss.Name = "bnBottom_tss";
            this.bnBottom_tss.Size = new System.Drawing.Size(6, 27);
            // 
            // bnBottom_btnEidt
            // 
            this.bnBottom_btnEidt.Image = global::ERPSupport.SupForm.Properties.Resources.livejournal;
            this.bnBottom_btnEidt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnEidt.Name = "bnBottom_btnEidt";
            this.bnBottom_btnEidt.Size = new System.Drawing.Size(63, 24);
            this.bnBottom_btnEidt.Tag = "1";
            this.bnBottom_btnEidt.Text = "修改";
            this.bnBottom_btnEidt.ToolTipText = "修改";
            this.bnBottom_btnEidt.Click += new System.EventHandler(this.bnBottom_btnEidt_Click);
            // 
            // bnBottom_btnCancle
            // 
            this.bnBottom_btnCancle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnBottom_btnCancle.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_redo;
            this.bnBottom_btnCancle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnCancle.Name = "bnBottom_btnCancle";
            this.bnBottom_btnCancle.Size = new System.Drawing.Size(63, 24);
            this.bnBottom_btnCancle.Text = "取消";
            this.bnBottom_btnCancle.ToolTipText = "取消并推出";
            this.bnBottom_btnCancle.Click += new System.EventHandler(this.bnBottom_btnCancle_Click);
            // 
            // txtBillNos
            // 
            this.txtBillNos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBillNos.Location = new System.Drawing.Point(0, 0);
            this.txtBillNos.Multiline = true;
            this.txtBillNos.Name = "txtBillNos";
            this.txtBillNos.Size = new System.Drawing.Size(582, 126);
            this.txtBillNos.TabIndex = 29;
            // 
            // frmPPBomDir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 153);
            this.ControlBox = false;
            this.Controls.Add(this.txtBillNos);
            this.Controls.Add(this.bnBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 200);
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "frmPPBomDir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "在文本框输入生产订单编号(多个单号请用逗号分隔)";
            this.Load += new System.EventHandler(this.frmPPBomDir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripSeparator bnBottom_tss;
        private System.Windows.Forms.ToolStripButton bnBottom_btnEidt;
        private System.Windows.Forms.ToolStripButton bnBottom_btnCancle;
        private System.Windows.Forms.TextBox txtBillNos;
    }
}
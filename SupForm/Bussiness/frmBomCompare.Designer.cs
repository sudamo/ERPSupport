namespace ERPSupport.SupForm.Bussiness
{
    partial class frmBomCompare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBomCompare));
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnBottom_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnBottom_lblNeedDate = new System.Windows.Forms.ToolStripLabel();
            this.bnBottom_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnBottom_btnOK = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_tss3 = new System.Windows.Forms.ToolStripSeparator();
            this.bnBottom_btnCancel = new System.Windows.Forms.ToolStripButton();
            this.tpl1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbx1 = new System.Windows.Forms.GroupBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.gbx2 = new System.Windows.Forms.GroupBox();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
            this.tpl1.SuspendLayout();
            this.gbx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.gbx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
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
            this.bnBottom_lblNeedDate,
            this.bnBottom_tss2,
            this.bnBottom_btnOK,
            this.bnBottom_tss3,
            this.bnBottom_btnCancel});
            this.bnBottom.Location = new System.Drawing.Point(0, 764);
            this.bnBottom.MoveFirstItem = null;
            this.bnBottom.MoveLastItem = null;
            this.bnBottom.MoveNextItem = null;
            this.bnBottom.MovePreviousItem = null;
            this.bnBottom.Name = "bnBottom";
            this.bnBottom.PositionItem = null;
            this.bnBottom.Size = new System.Drawing.Size(1176, 27);
            this.bnBottom.TabIndex = 1;
            this.bnBottom.Text = "bindingNavigator1";
            // 
            // bnBottom_tss
            // 
            this.bnBottom_tss.Name = "bnBottom_tss";
            this.bnBottom_tss.Size = new System.Drawing.Size(6, 27);
            // 
            // bnBottom_lblNeedDate
            // 
            this.bnBottom_lblNeedDate.Name = "bnBottom_lblNeedDate";
            this.bnBottom_lblNeedDate.Size = new System.Drawing.Size(84, 24);
            this.bnBottom_lblNeedDate.Text = "需求日期：";
            // 
            // bnBottom_tss2
            // 
            this.bnBottom_tss2.Name = "bnBottom_tss2";
            this.bnBottom_tss2.Size = new System.Drawing.Size(6, 27);
            // 
            // bnBottom_btnOK
            // 
            this.bnBottom_btnOK.Image = global::ERPSupport.SupForm.Properties.Resources.tick;
            this.bnBottom_btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnOK.Name = "bnBottom_btnOK";
            this.bnBottom_btnOK.Size = new System.Drawing.Size(63, 24);
            this.bnBottom_btnOK.Tag = "1";
            this.bnBottom_btnOK.Text = "确定";
            this.bnBottom_btnOK.ToolTipText = "确定修改";
            this.bnBottom_btnOK.Click += new System.EventHandler(this.bnBottom_btnOK_Click);
            // 
            // bnBottom_tss3
            // 
            this.bnBottom_tss3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnBottom_tss3.Name = "bnBottom_tss3";
            this.bnBottom_tss3.Size = new System.Drawing.Size(6, 27);
            // 
            // bnBottom_btnCancel
            // 
            this.bnBottom_btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnBottom_btnCancel.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_redo;
            this.bnBottom_btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnCancel.Name = "bnBottom_btnCancel";
            this.bnBottom_btnCancel.Size = new System.Drawing.Size(63, 24);
            this.bnBottom_btnCancel.Text = "取消";
            this.bnBottom_btnCancel.ToolTipText = "取消并退出";
            this.bnBottom_btnCancel.Click += new System.EventHandler(this.bnBottom_btnCancel_Click);
            // 
            // tpl1
            // 
            this.tpl1.ColumnCount = 2;
            this.tpl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpl1.Controls.Add(this.gbx1, 0, 0);
            this.tpl1.Controls.Add(this.gbx2, 1, 0);
            this.tpl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpl1.Location = new System.Drawing.Point(0, 0);
            this.tpl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpl1.Name = "tpl1";
            this.tpl1.RowCount = 1;
            this.tpl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpl1.Size = new System.Drawing.Size(1176, 764);
            this.tpl1.TabIndex = 0;
            // 
            // gbx1
            // 
            this.gbx1.Controls.Add(this.dgv1);
            this.gbx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx1.Location = new System.Drawing.Point(4, 4);
            this.gbx1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbx1.Name = "gbx1";
            this.gbx1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbx1.Size = new System.Drawing.Size(580, 756);
            this.gbx1.TabIndex = 35;
            this.gbx1.TabStop = false;
            this.gbx1.Text = "修改前";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(4, 22);
            this.dgv1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv1.Size = new System.Drawing.Size(572, 730);
            this.dgv1.TabIndex = 0;
            // 
            // gbx2
            // 
            this.gbx2.Controls.Add(this.dgv2);
            this.gbx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx2.Location = new System.Drawing.Point(592, 4);
            this.gbx2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbx2.Name = "gbx2";
            this.gbx2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbx2.Size = new System.Drawing.Size(580, 756);
            this.gbx2.TabIndex = 35;
            this.gbx2.TabStop = false;
            this.gbx2.Text = "修改后";
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.AllowUserToResizeRows = false;
            this.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2.Location = new System.Drawing.Point(4, 22);
            this.dgv2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv2.MultiSelect = false;
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv2.RowTemplate.Height = 23;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv2.Size = new System.Drawing.Size(572, 730);
            this.dgv2.TabIndex = 0;
            // 
            // frmBomCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 791);
            this.ControlBox = false;
            this.Controls.Add(this.tpl1);
            this.Controls.Add(this.bnBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1194, 838);
            this.MinimumSize = new System.Drawing.Size(1194, 838);
            this.Name = "frmBomCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "物料清单修改对照";
            this.Load += new System.EventHandler(this.frmBomCompare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            this.tpl1.ResumeLayout(false);
            this.gbx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.gbx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripSeparator bnBottom_tss;
        private System.Windows.Forms.ToolStripSeparator bnBottom_tss2;
        private System.Windows.Forms.ToolStripButton bnBottom_btnOK;
        private System.Windows.Forms.ToolStripSeparator bnBottom_tss3;
        private System.Windows.Forms.ToolStripButton bnBottom_btnCancel;
        private System.Windows.Forms.TableLayoutPanel tpl1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.ToolStripLabel bnBottom_lblNeedDate;
        private System.Windows.Forms.GroupBox gbx1;
        private System.Windows.Forms.GroupBox gbx2;
    }
}
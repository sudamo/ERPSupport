namespace ERPSupport.SupForm.Menu
{
    partial class frmPro_Dir_Stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPro_Dir_Stock));
            this.libStock = new System.Windows.Forms.ListBox();
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnBottom_btnAdd = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_btnEdit = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_btnDelete = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_btnCancel = new System.Windows.Forms.ToolStripButton();
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_cbxOutStock = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_lblTo = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_cbxInStock = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // libStock
            // 
            this.libStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.libStock.BackColor = System.Drawing.Color.AliceBlue;
            this.libStock.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.libStock.FormattingEnabled = true;
            this.libStock.ItemHeight = 14;
            this.libStock.Location = new System.Drawing.Point(0, 32);
            this.libStock.Name = "libStock";
            this.libStock.Size = new System.Drawing.Size(344, 298);
            this.libStock.TabIndex = 2;
            this.libStock.SelectedIndexChanged += new System.EventHandler(this.libStock_SelectedIndexChanged);
            // 
            // bnBottom
            // 
            this.bnBottom.AddNewItem = null;
            this.bnBottom.CountItem = null;
            this.bnBottom.DeleteItem = null;
            this.bnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnBottom_btnAdd,
            this.bnBottom_btnEdit,
            this.bnBottom_btnDelete,
            this.bnBottom_btnCancel});
            this.bnBottom.Location = new System.Drawing.Point(0, 335);
            this.bnBottom.MoveFirstItem = null;
            this.bnBottom.MoveLastItem = null;
            this.bnBottom.MoveNextItem = null;
            this.bnBottom.MovePreviousItem = null;
            this.bnBottom.Name = "bnBottom";
            this.bnBottom.PositionItem = null;
            this.bnBottom.Size = new System.Drawing.Size(344, 27);
            this.bnBottom.TabIndex = 3;
            this.bnBottom.Text = "bindingNavigator1";
            // 
            // bnBottom_btnAdd
            // 
            this.bnBottom_btnAdd.Image = global::ERPSupport.SupForm.Properties.Resources.add;
            this.bnBottom_btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnAdd.Name = "bnBottom_btnAdd";
            this.bnBottom_btnAdd.Size = new System.Drawing.Size(56, 24);
            this.bnBottom_btnAdd.Text = "新增";
            this.bnBottom_btnAdd.ToolTipText = "新增仓库对应";
            this.bnBottom_btnAdd.Click += new System.EventHandler(this.bnBottom_btnAdd_Click);
            // 
            // bnBottom_btnEdit
            // 
            this.bnBottom_btnEdit.Image = global::ERPSupport.SupForm.Properties.Resources.livejournal;
            this.bnBottom_btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnEdit.Name = "bnBottom_btnEdit";
            this.bnBottom_btnEdit.Size = new System.Drawing.Size(56, 24);
            this.bnBottom_btnEdit.Text = "修改";
            this.bnBottom_btnEdit.Click += new System.EventHandler(this.bnBottom_btnEdit_Click);
            // 
            // bnBottom_btnDelete
            // 
            this.bnBottom_btnDelete.Image = global::ERPSupport.SupForm.Properties.Resources.delete;
            this.bnBottom_btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnDelete.Name = "bnBottom_btnDelete";
            this.bnBottom_btnDelete.Size = new System.Drawing.Size(56, 24);
            this.bnBottom_btnDelete.Text = "删除";
            this.bnBottom_btnDelete.Click += new System.EventHandler(this.bnBottom_btnDelete_Click);
            // 
            // bnBottom_btnCancel
            // 
            this.bnBottom_btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bnBottom_btnCancel.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_redo;
            this.bnBottom_btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnCancel.Name = "bnBottom_btnCancel";
            this.bnBottom_btnCancel.Size = new System.Drawing.Size(56, 24);
            this.bnBottom_btnCancel.Text = "取消";
            this.bnBottom_btnCancel.ToolTipText = "取消并退出";
            this.bnBottom_btnCancel.Click += new System.EventHandler(this.bnBottom_btnCancel_Click);
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_cbxOutStock,
            this.bnTop_lblTo,
            this.bnTop_cbxInStock});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(344, 25);
            this.bnTop.TabIndex = 4;
            this.bnTop.Text = "bindingNavigator1";
            // 
            // bnTop_cbxOutStock
            // 
            this.bnTop_cbxOutStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxOutStock.Name = "bnTop_cbxOutStock";
            this.bnTop_cbxOutStock.Size = new System.Drawing.Size(125, 25);
            // 
            // bnTop_lblTo
            // 
            this.bnTop_lblTo.Name = "bnTop_lblTo";
            this.bnTop_lblTo.Size = new System.Drawing.Size(27, 22);
            this.bnTop_lblTo.Text = "-->";
            this.bnTop_lblTo.ToolTipText = "由调出仓库到调入仓库";
            // 
            // bnTop_cbxInStock
            // 
            this.bnTop_cbxInStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxInStock.Name = "bnTop_cbxInStock";
            this.bnTop_cbxInStock.Size = new System.Drawing.Size(125, 25);
            // 
            // frmPro_Dir_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 362);
            this.ControlBox = false;
            this.Controls.Add(this.bnTop);
            this.Controls.Add(this.bnBottom);
            this.Controls.Add(this.libStock);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(360, 400);
            this.MinimumSize = new System.Drawing.Size(320, 400);
            this.Name = "frmPro_Dir_Stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "仓库间调拨";
            this.Load += new System.EventHandler(this.frmPro_Dir_Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).EndInit();
            this.bnTop.ResumeLayout(false);
            this.bnTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox libStock;
        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripButton bnBottom_btnAdd;
        private System.Windows.Forms.ToolStripButton bnBottom_btnEdit;
        private System.Windows.Forms.ToolStripButton bnBottom_btnDelete;
        private System.Windows.Forms.ToolStripButton bnBottom_btnCancel;
        private System.Windows.Forms.BindingNavigator bnTop;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxOutStock;
        private System.Windows.Forms.ToolStripLabel bnTop_lblTo;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxInStock;
    }
}
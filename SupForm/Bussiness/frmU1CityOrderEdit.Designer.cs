﻿namespace ERPSupport.SupForm.Bussiness
{
    partial class frmU1CityOrderEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmU1CityOrderEdit));
            this.lblOrder = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbxFields = new System.Windows.Forms.GroupBox();
            this.cbxSaler = new System.Windows.Forms.ComboBox();
            this.cbxDep = new System.Windows.Forms.ComboBox();
            this.cbxSaleOrg = new System.Windows.Forms.ComboBox();
            this.lblSaler = new System.Windows.Forms.Label();
            this.lblDep = new System.Windows.Forms.Label();
            this.lblSaleOrg = new System.Windows.Forms.Label();
            this.bnBottom = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnBottom_btnClose = new System.Windows.Forms.ToolStripButton();
            this.bnBottom_btnOK = new System.Windows.Forms.ToolStripButton();
            this.lblFacOrg = new System.Windows.Forms.Label();
            this.cbxFacOrg = new System.Windows.Forms.ComboBox();
            this.gbxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).BeginInit();
            this.bnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(12, 13);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(41, 12);
            this.lblOrder.TabIndex = 0;
            this.lblOrder.Text = "订单：";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(59, 10);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(132, 21);
            this.txtPath.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(197, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "浏览(&S)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbxFields
            // 
            this.gbxFields.Controls.Add(this.cbxSaler);
            this.gbxFields.Controls.Add(this.cbxDep);
            this.gbxFields.Controls.Add(this.cbxFacOrg);
            this.gbxFields.Controls.Add(this.cbxSaleOrg);
            this.gbxFields.Controls.Add(this.lblSaler);
            this.gbxFields.Controls.Add(this.lblFacOrg);
            this.gbxFields.Controls.Add(this.lblDep);
            this.gbxFields.Controls.Add(this.lblSaleOrg);
            this.gbxFields.Location = new System.Drawing.Point(14, 49);
            this.gbxFields.Name = "gbxFields";
            this.gbxFields.Size = new System.Drawing.Size(258, 141);
            this.gbxFields.TabIndex = 3;
            this.gbxFields.TabStop = false;
            this.gbxFields.Text = "调整为";
            // 
            // cbxSaler
            // 
            this.cbxSaler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSaler.FormattingEnabled = true;
            this.cbxSaler.Location = new System.Drawing.Point(79, 98);
            this.cbxSaler.Name = "cbxSaler";
            this.cbxSaler.Size = new System.Drawing.Size(160, 20);
            this.cbxSaler.TabIndex = 1;
            // 
            // cbxDep
            // 
            this.cbxDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDep.FormattingEnabled = true;
            this.cbxDep.Location = new System.Drawing.Point(79, 72);
            this.cbxDep.Name = "cbxDep";
            this.cbxDep.Size = new System.Drawing.Size(160, 20);
            this.cbxDep.TabIndex = 1;
            // 
            // cbxSaleOrg
            // 
            this.cbxSaleOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSaleOrg.FormattingEnabled = true;
            this.cbxSaleOrg.Location = new System.Drawing.Point(79, 46);
            this.cbxSaleOrg.Name = "cbxSaleOrg";
            this.cbxSaleOrg.Size = new System.Drawing.Size(160, 20);
            this.cbxSaleOrg.TabIndex = 1;
            this.cbxSaleOrg.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChange);
            // 
            // lblSaler
            // 
            this.lblSaler.AutoSize = true;
            this.lblSaler.Location = new System.Drawing.Point(20, 101);
            this.lblSaler.Name = "lblSaler";
            this.lblSaler.Size = new System.Drawing.Size(53, 12);
            this.lblSaler.TabIndex = 0;
            this.lblSaler.Text = "销售员：";
            // 
            // lblDep
            // 
            this.lblDep.AutoSize = true;
            this.lblDep.Location = new System.Drawing.Point(32, 75);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(41, 12);
            this.lblDep.TabIndex = 0;
            this.lblDep.Text = "部门：";
            // 
            // lblSaleOrg
            // 
            this.lblSaleOrg.AutoSize = true;
            this.lblSaleOrg.Location = new System.Drawing.Point(8, 49);
            this.lblSaleOrg.Name = "lblSaleOrg";
            this.lblSaleOrg.Size = new System.Drawing.Size(65, 12);
            this.lblSaleOrg.TabIndex = 0;
            this.lblSaleOrg.Text = "销售组织：";
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
            this.bnBottom_btnOK});
            this.bnBottom.Location = new System.Drawing.Point(0, 195);
            this.bnBottom.MoveFirstItem = null;
            this.bnBottom.MoveLastItem = null;
            this.bnBottom.MoveNextItem = null;
            this.bnBottom.MovePreviousItem = null;
            this.bnBottom.Name = "bnBottom";
            this.bnBottom.PositionItem = null;
            this.bnBottom.Size = new System.Drawing.Size(284, 27);
            this.bnBottom.TabIndex = 4;
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
            // bnBottom_btnOK
            // 
            this.bnBottom_btnOK.Image = global::ERPSupport.SupForm.Properties.Resources.accept;
            this.bnBottom_btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnBottom_btnOK.Name = "bnBottom_btnOK";
            this.bnBottom_btnOK.Size = new System.Drawing.Size(56, 24);
            this.bnBottom_btnOK.Text = "修改";
            this.bnBottom_btnOK.ToolTipText = "确定修改订单信息";
            this.bnBottom_btnOK.Click += new System.EventHandler(this.bnBottom_btnOK_Click);
            // 
            // lblFacOrg
            // 
            this.lblFacOrg.AutoSize = true;
            this.lblFacOrg.Location = new System.Drawing.Point(8, 23);
            this.lblFacOrg.Name = "lblFacOrg";
            this.lblFacOrg.Size = new System.Drawing.Size(65, 12);
            this.lblFacOrg.TabIndex = 0;
            this.lblFacOrg.Text = "生产组织：";
            // 
            // cbxFacOrg
            // 
            this.cbxFacOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFacOrg.FormattingEnabled = true;
            this.cbxFacOrg.Location = new System.Drawing.Point(79, 20);
            this.cbxFacOrg.Name = "cbxFacOrg";
            this.cbxFacOrg.Size = new System.Drawing.Size(160, 20);
            this.cbxFacOrg.TabIndex = 1;
            this.cbxFacOrg.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChange);
            // 
            // frmU1CityOrderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 222);
            this.ControlBox = false;
            this.Controls.Add(this.bnBottom);
            this.Controls.Add(this.gbxFields);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblOrder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 260);
            this.MinimumSize = new System.Drawing.Size(300, 240);
            this.Name = "frmU1CityOrderEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "UiCity对接单据调整";
            this.Load += new System.EventHandler(this.frmU1CityOrderEdit_Load);
            this.gbxFields.ResumeLayout(false);
            this.gbxFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnBottom)).EndInit();
            this.bnBottom.ResumeLayout(false);
            this.bnBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbxFields;
        private System.Windows.Forms.Label lblSaler;
        private System.Windows.Forms.Label lblDep;
        private System.Windows.Forms.Label lblSaleOrg;
        private System.Windows.Forms.ComboBox cbxSaler;
        private System.Windows.Forms.ComboBox cbxDep;
        private System.Windows.Forms.ComboBox cbxSaleOrg;
        private System.Windows.Forms.BindingNavigator bnBottom;
        private System.Windows.Forms.ToolStripButton bnBottom_btnClose;
        private System.Windows.Forms.ToolStripButton bnBottom_btnOK;
        private System.Windows.Forms.ComboBox cbxFacOrg;
        private System.Windows.Forms.Label lblFacOrg;
    }
}
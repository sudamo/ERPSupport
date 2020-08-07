namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucCS_BillEdit
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bnR1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnR1_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnR1_btnEidt = new System.Windows.Forms.ToolStripButton();
            this.bnTop = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnTop_lblType = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_cbxType = new System.Windows.Forms.ToolStripComboBox();
            this.bnTop_lblBillNo = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_txtBillNo = new System.Windows.Forms.ToolStripTextBox();
            this.bnTop_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_lblDash = new System.Windows.Forms.ToolStripLabel();
            this.bnTop_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnTop_Search = new System.Windows.Forms.ToolStripButton();
            this.bnTop_Syn = new System.Windows.Forms.ToolStripButton();
            this.bnTop_ChangeDB = new System.Windows.Forms.ToolStripButton();
            this.bnTop_PPBom = new System.Windows.Forms.ToolStripButton();
            this.bnTop_Bom = new System.Windows.Forms.ToolStripButton();
            this.bnTop_Org = new System.Windows.Forms.ToolStripButton();
            this.bnR2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnR2_lblMTLNumber = new System.Windows.Forms.ToolStripLabel();
            this.bnR2_txtMTLNumber = new System.Windows.Forms.ToolStripTextBox();
            this.bnR2_lblCanOutQty = new System.Windows.Forms.ToolStripLabel();
            this.bnR2_txtCanOutQty = new System.Windows.Forms.ToolStripTextBox();
            this.bnR2_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnR2_btnEdit = new System.Windows.Forms.ToolStripButton();
            this.bnR3 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bnR3_lblCustomer = new System.Windows.Forms.ToolStripLabel();
            this.bnR2_txtCustomer = new System.Windows.Forms.ToolStripTextBox();
            this.bnR3_tss = new System.Windows.Forms.ToolStripSeparator();
            this.bnR3_tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.bnR3_btnEdit = new System.Windows.Forms.ToolStripButton();
            this.tpl1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bnR1)).BeginInit();
            this.bnR1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).BeginInit();
            this.bnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnR2)).BeginInit();
            this.bnR2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnR3)).BeginInit();
            this.bnR3.SuspendLayout();
            this.tpl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // bnR1
            // 
            this.bnR1.AddNewItem = null;
            this.bnR1.CountItem = null;
            this.bnR1.DeleteItem = null;
            this.bnR1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bnR1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnR1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnR1_tss,
            this.bnR1_btnEidt});
            this.bnR1.Location = new System.Drawing.Point(0, 0);
            this.bnR1.MoveFirstItem = null;
            this.bnR1.MoveLastItem = null;
            this.bnR1.MoveNextItem = null;
            this.bnR1.MovePreviousItem = null;
            this.bnR1.Name = "bnR1";
            this.bnR1.PositionItem = null;
            this.bnR1.Size = new System.Drawing.Size(1018, 30);
            this.bnR1.TabIndex = 27;
            this.bnR1.Text = "bindingNavigator1";
            // 
            // bnR1_tss
            // 
            this.bnR1_tss.Name = "bnR1_tss";
            this.bnR1_tss.Size = new System.Drawing.Size(6, 30);
            // 
            // bnR1_btnEidt
            // 
            this.bnR1_btnEidt.Image = global::ERPSupport.SupForm.Properties.Resources.livejournal;
            this.bnR1_btnEidt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnR1_btnEidt.Name = "bnR1_btnEidt";
            this.bnR1_btnEidt.Size = new System.Drawing.Size(56, 27);
            this.bnR1_btnEidt.Tag = "1";
            this.bnR1_btnEidt.Text = "修改";
            this.bnR1_btnEidt.ToolTipText = "修改整单发货标识";
            this.bnR1_btnEidt.Click += new System.EventHandler(this.bnR1_btnEidt_Click);
            // 
            // bnTop
            // 
            this.bnTop.AddNewItem = null;
            this.bnTop.CountItem = null;
            this.bnTop.DeleteItem = null;
            this.bnTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnTop_lblType,
            this.bnTop_cbxType,
            this.bnTop_lblBillNo,
            this.bnTop_txtBillNo,
            this.bnTop_tss,
            this.bnTop_lblDash,
            this.bnTop_tss2,
            this.bnTop_Search,
            this.bnTop_Syn,
            this.bnTop_ChangeDB,
            this.bnTop_PPBom,
            this.bnTop_Bom,
            this.bnTop_Org});
            this.bnTop.Location = new System.Drawing.Point(0, 0);
            this.bnTop.MoveFirstItem = null;
            this.bnTop.MoveLastItem = null;
            this.bnTop.MoveNextItem = null;
            this.bnTop.MovePreviousItem = null;
            this.bnTop.Name = "bnTop";
            this.bnTop.PositionItem = null;
            this.bnTop.Size = new System.Drawing.Size(1024, 27);
            this.bnTop.TabIndex = 28;
            this.bnTop.Text = "bindingNavigator1";
            this.bnTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.bnTop_ItemClicked);
            // 
            // bnTop_lblType
            // 
            this.bnTop_lblType.Name = "bnTop_lblType";
            this.bnTop_lblType.Size = new System.Drawing.Size(68, 22);
            this.bnTop_lblType.Text = "单据类型：";
            // 
            // bnTop_cbxType
            // 
            this.bnTop_cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bnTop_cbxType.Name = "bnTop_cbxType";
            this.bnTop_cbxType.Size = new System.Drawing.Size(90, 25);
            this.bnTop_cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // bnTop_lblBillNo
            // 
            this.bnTop_lblBillNo.Name = "bnTop_lblBillNo";
            this.bnTop_lblBillNo.Size = new System.Drawing.Size(68, 24);
            this.bnTop_lblBillNo.Text = "单据编号：";
            this.bnTop_lblBillNo.Visible = false;
            // 
            // bnTop_txtBillNo
            // 
            this.bnTop_txtBillNo.Name = "bnTop_txtBillNo";
            this.bnTop_txtBillNo.Size = new System.Drawing.Size(120, 27);
            this.bnTop_txtBillNo.Visible = false;
            // 
            // bnTop_tss
            // 
            this.bnTop_tss.Name = "bnTop_tss";
            this.bnTop_tss.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_lblDash
            // 
            this.bnTop_lblDash.Name = "bnTop_lblDash";
            this.bnTop_lblDash.Size = new System.Drawing.Size(13, 24);
            this.bnTop_lblDash.Text = "-";
            this.bnTop_lblDash.Visible = false;
            // 
            // bnTop_tss2
            // 
            this.bnTop_tss2.Name = "bnTop_tss2";
            this.bnTop_tss2.Size = new System.Drawing.Size(6, 25);
            // 
            // bnTop_Search
            // 
            this.bnTop_Search.Image = global::ERPSupport.SupForm.Properties.Resources.zoom;
            this.bnTop_Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_Search.Name = "bnTop_Search";
            this.bnTop_Search.Size = new System.Drawing.Size(56, 24);
            this.bnTop_Search.Tag = "1";
            this.bnTop_Search.Text = "查找";
            this.bnTop_Search.ToolTipText = "查询";
            this.bnTop_Search.Visible = false;
            // 
            // bnTop_Syn
            // 
            this.bnTop_Syn.Image = global::ERPSupport.SupForm.Properties.Resources.arrow_refresh;
            this.bnTop_Syn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_Syn.Name = "bnTop_Syn";
            this.bnTop_Syn.Size = new System.Drawing.Size(104, 24);
            this.bnTop_Syn.Tag = "2";
            this.bnTop_Syn.Text = "同步需求日期";
            this.bnTop_Syn.ToolTipText = "同步用料清单的需求日期为生产订单的计划开工时间";
            this.bnTop_Syn.Visible = false;
            // 
            // bnTop_ChangeDB
            // 
            this.bnTop_ChangeDB.Image = global::ERPSupport.SupForm.Properties.Resources.direction;
            this.bnTop_ChangeDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_ChangeDB.Name = "bnTop_ChangeDB";
            this.bnTop_ChangeDB.Size = new System.Drawing.Size(104, 24);
            this.bnTop_ChangeDB.Tag = "3";
            this.bnTop_ChangeDB.Text = "修改调拨状态";
            this.bnTop_ChangeDB.ToolTipText = "根据生产订单修改生成调拨单状态";
            this.bnTop_ChangeDB.Visible = false;
            // 
            // bnTop_PPBom
            // 
            this.bnTop_PPBom.Image = global::ERPSupport.SupForm.Properties.Resources.text;
            this.bnTop_PPBom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_PPBom.Name = "bnTop_PPBom";
            this.bnTop_PPBom.Size = new System.Drawing.Size(92, 24);
            this.bnTop_PPBom.Tag = "4";
            this.bnTop_PPBom.Text = "修改投料单";
            this.bnTop_PPBom.ToolTipText = "修改生产用料清单的信息";
            this.bnTop_PPBom.Visible = false;
            // 
            // bnTop_Bom
            // 
            this.bnTop_Bom.Image = global::ERPSupport.SupForm.Properties.Resources.note;
            this.bnTop_Bom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_Bom.Name = "bnTop_Bom";
            this.bnTop_Bom.Size = new System.Drawing.Size(86, 24);
            this.bnTop_Bom.Tag = "5";
            this.bnTop_Bom.Text = "批改BOM";
            this.bnTop_Bom.ToolTipText = "批量修改物料清单";
            this.bnTop_Bom.Visible = false;
            // 
            // bnTop_Org
            // 
            this.bnTop_Org.Image = global::ERPSupport.SupForm.Properties.Resources.link_edit;
            this.bnTop_Org.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnTop_Org.Name = "bnTop_Org";
            this.bnTop_Org.Size = new System.Drawing.Size(80, 24);
            this.bnTop_Org.Tag = "6";
            this.bnTop_Org.Text = "调整组织";
            this.bnTop_Org.ToolTipText = "调整U1City下的订单信息";
            this.bnTop_Org.Visible = false;
            // 
            // bnR2
            // 
            this.bnR2.AddNewItem = null;
            this.bnR2.CountItem = null;
            this.bnR2.DeleteItem = null;
            this.bnR2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bnR2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnR2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnR2_lblMTLNumber,
            this.bnR2_txtMTLNumber,
            this.bnR2_lblCanOutQty,
            this.bnR2_txtCanOutQty,
            this.bnR2_tss,
            this.bnR2_btnEdit});
            this.bnR2.Location = new System.Drawing.Point(0, 30);
            this.bnR2.MoveFirstItem = null;
            this.bnR2.MoveLastItem = null;
            this.bnR2.MoveNextItem = null;
            this.bnR2.MovePreviousItem = null;
            this.bnR2.Name = "bnR2";
            this.bnR2.PositionItem = null;
            this.bnR2.Size = new System.Drawing.Size(1018, 30);
            this.bnR2.TabIndex = 31;
            this.bnR2.Text = "bindingNavigator1";
            // 
            // bnR2_lblMTLNumber
            // 
            this.bnR2_lblMTLNumber.Name = "bnR2_lblMTLNumber";
            this.bnR2_lblMTLNumber.Size = new System.Drawing.Size(68, 27);
            this.bnR2_lblMTLNumber.Text = "物料编码：";
            // 
            // bnR2_txtMTLNumber
            // 
            this.bnR2_txtMTLNumber.Name = "bnR2_txtMTLNumber";
            this.bnR2_txtMTLNumber.ReadOnly = true;
            this.bnR2_txtMTLNumber.Size = new System.Drawing.Size(170, 30);
            // 
            // bnR2_lblCanOutQty
            // 
            this.bnR2_lblCanOutQty.Name = "bnR2_lblCanOutQty";
            this.bnR2_lblCanOutQty.Size = new System.Drawing.Size(68, 27);
            this.bnR2_lblCanOutQty.Text = "可出数量：";
            // 
            // bnR2_txtCanOutQty
            // 
            this.bnR2_txtCanOutQty.Name = "bnR2_txtCanOutQty";
            this.bnR2_txtCanOutQty.Size = new System.Drawing.Size(50, 30);
            this.bnR2_txtCanOutQty.ToolTipText = "把可出数量修改为当前输入值";
            this.bnR2_txtCanOutQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bnR2_txtCanOutQty_KeyPress);
            // 
            // bnR2_tss
            // 
            this.bnR2_tss.Name = "bnR2_tss";
            this.bnR2_tss.Size = new System.Drawing.Size(6, 30);
            // 
            // bnR2_btnEdit
            // 
            this.bnR2_btnEdit.Image = global::ERPSupport.SupForm.Properties.Resources.livejournal;
            this.bnR2_btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnR2_btnEdit.Name = "bnR2_btnEdit";
            this.bnR2_btnEdit.Size = new System.Drawing.Size(56, 27);
            this.bnR2_btnEdit.Tag = "1";
            this.bnR2_btnEdit.Text = "修改";
            this.bnR2_btnEdit.ToolTipText = "修改销售订单可出数量";
            this.bnR2_btnEdit.Click += new System.EventHandler(this.bnR2_btnEdit_Click);
            // 
            // bnR3
            // 
            this.bnR3.AddNewItem = null;
            this.bnR3.CountItem = null;
            this.bnR3.DeleteItem = null;
            this.bnR3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bnR3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnR3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnR3_lblCustomer,
            this.bnR2_txtCustomer,
            this.bnR3_tss,
            this.bnR3_tss2,
            this.bnR3_btnEdit});
            this.bnR3.Location = new System.Drawing.Point(0, 60);
            this.bnR3.MoveFirstItem = null;
            this.bnR3.MoveLastItem = null;
            this.bnR3.MoveNextItem = null;
            this.bnR3.MovePreviousItem = null;
            this.bnR3.Name = "bnR3";
            this.bnR3.PositionItem = null;
            this.bnR3.Size = new System.Drawing.Size(1018, 30);
            this.bnR3.TabIndex = 32;
            this.bnR3.Text = "bindingNavigator1";
            // 
            // bnR3_lblCustomer
            // 
            this.bnR3_lblCustomer.Name = "bnR3_lblCustomer";
            this.bnR3_lblCustomer.Size = new System.Drawing.Size(44, 27);
            this.bnR3_lblCustomer.Text = "客户：";
            // 
            // bnR2_txtCustomer
            // 
            this.bnR2_txtCustomer.Name = "bnR2_txtCustomer";
            this.bnR2_txtCustomer.Size = new System.Drawing.Size(192, 30);
            this.bnR2_txtCustomer.ToolTipText = "把客户修改为当前输入值";
            // 
            // bnR3_tss
            // 
            this.bnR3_tss.Name = "bnR3_tss";
            this.bnR3_tss.Size = new System.Drawing.Size(6, 30);
            // 
            // bnR3_tss2
            // 
            this.bnR3_tss2.Name = "bnR3_tss2";
            this.bnR3_tss2.Size = new System.Drawing.Size(6, 30);
            // 
            // bnR3_btnEdit
            // 
            this.bnR3_btnEdit.Image = global::ERPSupport.SupForm.Properties.Resources.livejournal;
            this.bnR3_btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bnR3_btnEdit.Name = "bnR3_btnEdit";
            this.bnR3_btnEdit.Size = new System.Drawing.Size(56, 27);
            this.bnR3_btnEdit.Tag = "1";
            this.bnR3_btnEdit.Text = "修改";
            this.bnR3_btnEdit.ToolTipText = "修改客户";
            this.bnR3_btnEdit.Click += new System.EventHandler(this.bnR3_btnEdit_Click);
            // 
            // tpl1
            // 
            this.tpl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tpl1.ColumnCount = 1;
            this.tpl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpl1.Controls.Add(this.bnR1, 0, 0);
            this.tpl1.Controls.Add(this.bnR2, 0, 1);
            this.tpl1.Controls.Add(this.bnR3, 0, 2);
            this.tpl1.Controls.Add(this.dgv1, 0, 3);
            this.tpl1.Location = new System.Drawing.Point(3, 28);
            this.tpl1.Name = "tpl1";
            this.tpl1.RowCount = 4;
            this.tpl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tpl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tpl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tpl1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpl1.Size = new System.Drawing.Size(1018, 737);
            this.tpl1.TabIndex = 33;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(3, 93);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1012, 644);
            this.dgv1.TabIndex = 33;
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // ucCS_BillEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tpl1);
            this.Controls.Add(this.bnTop);
            this.Name = "ucCS_BillEdit";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucCS_BillEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnR1)).EndInit();
            this.bnR1.ResumeLayout(false);
            this.bnR1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnTop)).EndInit();
            this.bnTop.ResumeLayout(false);
            this.bnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnR2)).EndInit();
            this.bnR2.ResumeLayout(false);
            this.bnR2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnR3)).EndInit();
            this.bnR3.ResumeLayout(false);
            this.bnR3.PerformLayout();
            this.tpl1.ResumeLayout(false);
            this.tpl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingNavigator bnR1;
        private System.Windows.Forms.ToolStripSeparator bnR1_tss;
        private System.Windows.Forms.ToolStripButton bnR1_btnEidt;
        private System.Windows.Forms.BindingNavigator bnTop;
        private System.Windows.Forms.ToolStripComboBox bnTop_cbxType;
        private System.Windows.Forms.ToolStripLabel bnTop_lblBillNo;
        private System.Windows.Forms.ToolStripTextBox bnTop_txtBillNo;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss;
        private System.Windows.Forms.ToolStripLabel bnTop_lblDash;
        private System.Windows.Forms.ToolStripSeparator bnTop_tss2;
        private System.Windows.Forms.ToolStripButton bnTop_Search;
        private System.Windows.Forms.ToolStripButton bnTop_Syn;
        private System.Windows.Forms.ToolStripLabel bnTop_lblType;
        private System.Windows.Forms.BindingNavigator bnR2;
        private System.Windows.Forms.ToolStripSeparator bnR2_tss;
        private System.Windows.Forms.ToolStripButton bnR2_btnEdit;
        private System.Windows.Forms.ToolStripLabel bnR2_lblMTLNumber;
        private System.Windows.Forms.ToolStripTextBox bnR2_txtMTLNumber;
        private System.Windows.Forms.ToolStripLabel bnR2_lblCanOutQty;
        private System.Windows.Forms.ToolStripTextBox bnR2_txtCanOutQty;
        private System.Windows.Forms.BindingNavigator bnR3;
        private System.Windows.Forms.ToolStripSeparator bnR3_tss;
        private System.Windows.Forms.ToolStripLabel bnR3_lblCustomer;
        private System.Windows.Forms.ToolStripTextBox bnR2_txtCustomer;
        private System.Windows.Forms.ToolStripButton bnR3_btnEdit;
        private System.Windows.Forms.TableLayoutPanel tpl1;
        private System.Windows.Forms.ToolStripSeparator bnR3_tss2;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.ToolStripButton bnTop_PPBom;
        private System.Windows.Forms.ToolStripButton bnTop_Bom;
        private System.Windows.Forms.ToolStripButton bnTop_ChangeDB;
        private System.Windows.Forms.ToolStripButton bnTop_Org;
    }
}

namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucPDARecord
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxOperator = new System.Windows.Forms.ComboBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.chbFailed = new System.Windows.Forms.CheckBox();
            this.chbSucc = new System.Windows.Forms.CheckBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.pl1 = new System.Windows.Forms.Panel();
            this.btnSynchr = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.btnToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.pl1.SuspendLayout();
            this.SuspendLayout();
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
            this.dgv1.Location = new System.Drawing.Point(5, 57);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(1016, 708);
            this.dgv1.TabIndex = 13;
            this.dgv1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv1_RowStateChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(186, 3);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(110, 21);
            this.dtpTo.TabIndex = 2;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(50, 3);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(110, 21);
            this.dtpFrom.TabIndex = 1;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTo.Location = new System.Drawing.Point(166, 8);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(14, 14);
            this.labelTo.TabIndex = 0;
            this.labelTo.Text = "-";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate.Location = new System.Drawing.Point(3, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 12);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "日期：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(418, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "查找";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxOperator
            // 
            this.cbxOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOperator.FormattingEnabled = true;
            this.cbxOperator.Location = new System.Drawing.Point(337, 6);
            this.cbxOperator.Name = "cbxOperator";
            this.cbxOperator.Size = new System.Drawing.Size(75, 20);
            this.cbxOperator.TabIndex = 8;
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.ItemHeight = 12;
            this.cbxType.Location = new System.Drawing.Point(337, 30);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(74, 20);
            this.cbxType.TabIndex = 7;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // chbFailed
            // 
            this.chbFailed.AutoSize = true;
            this.chbFailed.Location = new System.Drawing.Point(635, 32);
            this.chbFailed.Name = "chbFailed";
            this.chbFailed.Size = new System.Drawing.Size(48, 16);
            this.chbFailed.TabIndex = 5;
            this.chbFailed.Text = "失败";
            this.chbFailed.UseVisualStyleBackColor = true;
            // 
            // chbSucc
            // 
            this.chbSucc.AutoSize = true;
            this.chbSucc.Location = new System.Drawing.Point(581, 32);
            this.chbSucc.Name = "chbSucc";
            this.chbSucc.Size = new System.Drawing.Size(48, 16);
            this.chbSucc.TabIndex = 4;
            this.chbSucc.Text = "成功";
            this.chbSucc.UseVisualStyleBackColor = true;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(202, 30);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(94, 21);
            this.txtBarcode.TabIndex = 7;
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(50, 30);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(110, 21);
            this.txtNo.TabIndex = 6;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(167, 33);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(29, 12);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "条码";
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(3, 33);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(41, 12);
            this.lblNo.TabIndex = 0;
            this.lblNo.Text = "单号：";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(302, 9);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(29, 12);
            this.lblOperator.TabIndex = 0;
            this.lblOperator.Text = "员工";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(302, 33);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 12);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "类型";
            // 
            // pl1
            // 
            this.pl1.Controls.Add(this.btnSynchr);
            this.pl1.Controls.Add(this.btn2);
            this.pl1.Controls.Add(this.btn1);
            this.pl1.Controls.Add(this.txtCompany);
            this.pl1.Controls.Add(this.lblCompany);
            this.pl1.Controls.Add(this.dtpTo);
            this.pl1.Controls.Add(this.dtpFrom);
            this.pl1.Controls.Add(this.labelTo);
            this.pl1.Controls.Add(this.lblDate);
            this.pl1.Controls.Add(this.btnToExcel);
            this.pl1.Controls.Add(this.btnSearch);
            this.pl1.Controls.Add(this.cbxOperator);
            this.pl1.Controls.Add(this.cbxType);
            this.pl1.Controls.Add(this.chbFailed);
            this.pl1.Controls.Add(this.chbSucc);
            this.pl1.Controls.Add(this.txtBarcode);
            this.pl1.Controls.Add(this.txtNo);
            this.pl1.Controls.Add(this.lblBarcode);
            this.pl1.Controls.Add(this.lblNo);
            this.pl1.Controls.Add(this.lblOperator);
            this.pl1.Controls.Add(this.lblType);
            this.pl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl1.Location = new System.Drawing.Point(0, 0);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(1024, 55);
            this.pl1.TabIndex = 1;
            this.pl1.MouseLeave += new System.EventHandler(this.pl1_MouseLeave);
            // 
            // btnSynchr
            // 
            this.btnSynchr.Location = new System.Drawing.Point(580, 4);
            this.btnSynchr.Name = "btnSynchr";
            this.btnSynchr.Size = new System.Drawing.Size(122, 23);
            this.btnSynchr.TabIndex = 11;
            this.btnSynchr.Text = "同步条码";
            this.btnSynchr.UseVisualStyleBackColor = true;
            this.btnSynchr.Click += new System.EventHandler(this.btnSynchr_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(641, 4);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(61, 23);
            this.btn2.TabIndex = 15;
            this.btn2.Text = "没入库单";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(580, 4);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(61, 23);
            this.btn1.TabIndex = 14;
            this.btn1.Text = "选择同步";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // txtCompany
            // 
            this.txtCompany.Enabled = false;
            this.txtCompany.Location = new System.Drawing.Point(476, 30);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(99, 21);
            this.txtCompany.TabIndex = 13;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(417, 33);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(53, 12);
            this.lblCompany.TabIndex = 12;
            this.lblCompany.Text = "快递公司";
            // 
            // btnToExcel
            // 
            this.btnToExcel.Location = new System.Drawing.Point(499, 4);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(75, 23);
            this.btnToExcel.TabIndex = 10;
            this.btnToExcel.Text = "导出";
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // ucPDARecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.pl1);
            this.Name = "ucPDARecord";
            this.Size = new System.Drawing.Size(1024, 768);
            this.Load += new System.EventHandler(this.ucPDARecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.pl1.ResumeLayout(false);
            this.pl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxOperator;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.CheckBox chbFailed;
        private System.Windows.Forms.CheckBox chbSucc;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Panel pl1;
        private System.Windows.Forms.Button btnSynchr;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
    }
}

namespace ERPSupport.SupForm.Common
{
    partial class frmBillModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBillModify));
            this.lblFBillNo = new System.Windows.Forms.Label();
            this.lblField = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxField = new System.Windows.Forms.ComboBox();
            this.cbxValue = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.dtpValue = new System.Windows.Forms.DateTimePicker();
            this.chbValue = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblFBillNo
            // 
            this.lblFBillNo.AutoSize = true;
            this.lblFBillNo.Location = new System.Drawing.Point(12, 10);
            this.lblFBillNo.Name = "lblFBillNo";
            this.lblFBillNo.Size = new System.Drawing.Size(65, 12);
            this.lblFBillNo.TabIndex = 0;
            this.lblFBillNo.Text = "单据编码：";
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(36, 45);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(41, 12);
            this.lblField.TabIndex = 0;
            this.lblField.Text = "字段：";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(48, 80);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(29, 12);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "值：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(30, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbxField
            // 
            this.cbxField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxField.FormattingEnabled = true;
            this.cbxField.Location = new System.Drawing.Point(83, 42);
            this.cbxField.Name = "cbxField";
            this.cbxField.Size = new System.Drawing.Size(129, 20);
            this.cbxField.TabIndex = 2;
            // 
            // cbxValue
            // 
            this.cbxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxValue.FormattingEnabled = true;
            this.cbxValue.Location = new System.Drawing.Point(83, 77);
            this.cbxValue.Name = "cbxValue";
            this.cbxValue.Size = new System.Drawing.Size(129, 20);
            this.cbxValue.TabIndex = 5;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(84, 77);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(111, 21);
            this.txtValue.TabIndex = 6;
            // 
            // dtpValue
            // 
            this.dtpValue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpValue.Location = new System.Drawing.Point(83, 77);
            this.dtpValue.Name = "dtpValue";
            this.dtpValue.Size = new System.Drawing.Size(98, 21);
            this.dtpValue.TabIndex = 7;
            // 
            // chbValue
            // 
            this.chbValue.AutoSize = true;
            this.chbValue.Location = new System.Drawing.Point(137, 81);
            this.chbValue.Name = "chbValue";
            this.chbValue.Size = new System.Drawing.Size(15, 14);
            this.chbValue.TabIndex = 8;
            this.chbValue.UseVisualStyleBackColor = true;
            // 
            // frmBillModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 162);
            this.Controls.Add(this.chbValue);
            this.Controls.Add(this.dtpValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cbxValue);
            this.Controls.Add(this.cbxField);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.lblFBillNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBillModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "单据修改";
            this.Load += new System.EventHandler(this.frmBiliModify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFBillNo;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxField;
        private System.Windows.Forms.ComboBox cbxValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.DateTimePicker dtpValue;
        private System.Windows.Forms.CheckBox chbValue;
    }
}
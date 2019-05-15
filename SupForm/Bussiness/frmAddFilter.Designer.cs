namespace ERPSupport.SupForm.Bussiness
{
    partial class frmAddFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddFilter));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.chbShare = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTips = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(174, 33);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加";
            this.tt.SetToolTip(this.btnAdd, "创建新的方案。");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(255, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.tt.SetToolTip(this.btnCancel, "取消并返回。");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "方案名称";
            // 
            // chbShare
            // 
            this.chbShare.AutoSize = true;
            this.chbShare.Location = new System.Drawing.Point(258, 9);
            this.chbShare.Name = "chbShare";
            this.chbShare.Size = new System.Drawing.Size(72, 16);
            this.chbShare.TabIndex = 2;
            this.chbShare.Text = "是否共享";
            this.tt.SetToolTip(this.chbShare, "勾选后，其他人可以查看到此方案。");
            this.chbShare.UseVisualStyleBackColor = true;
            this.chbShare.CheckedChanged += new System.EventHandler(this.chbShare_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(71, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(181, 21);
            this.txtName.TabIndex = 1;
            this.tt.SetToolTip(this.txtName, "在文本框中输入新建用户名。");
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.ForeColor = System.Drawing.Color.Red;
            this.lblTips.Location = new System.Drawing.Point(12, 38);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(0, 12);
            this.lblTips.TabIndex = 5;
            // 
            // frmAddFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 62);
            this.ControlBox = false;
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chbShare);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(350, 100);
            this.MinimumSize = new System.Drawing.Size(350, 100);
            this.Name = "frmAddFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加查询方案";
            this.Load += new System.EventHandler(this.frmAddFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox chbShare;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.ToolTip tt;
    }
}
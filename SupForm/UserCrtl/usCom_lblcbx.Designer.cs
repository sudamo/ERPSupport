namespace ERPSupport.SupForm.UserCrtl
{
    partial class usCom_lblcbx
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
            this.lbl = new System.Windows.Forms.Label();
            this.cbx = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(3, 3);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(53, 12);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "类型分组";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbx
            // 
            this.cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx.FormattingEnabled = true;
            this.cbx.Location = new System.Drawing.Point(80, 0);
            this.cbx.Name = "cbx";
            this.cbx.Size = new System.Drawing.Size(120, 20);
            this.cbx.TabIndex = 1;
            // 
            // usCom_lblcbx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbx);
            this.Controls.Add(this.lbl);
            this.Name = "usCom_lblcbx";
            this.Size = new System.Drawing.Size(200, 20);
            this.Load += new System.EventHandler(this.usCom_lblcbx_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox cbx;
    }
}

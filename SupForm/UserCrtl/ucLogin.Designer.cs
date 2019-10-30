namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucLogin
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPWD = new System.Windows.Forms.Label();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(161, 84);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 27);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(56, 84);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(65, 27);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "登陆(&L)";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("宋体", 12F);
            this.txtUser.Location = new System.Drawing.Point(126, 6);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 26);
            this.txtUser.TabIndex = 5;
            this.tt.SetToolTip(this.txtUser, "请输入K3Cloud用户名。");
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // lblPWD
            // 
            this.lblPWD.Font = new System.Drawing.Font("宋体", 12F);
            this.lblPWD.Location = new System.Drawing.Point(21, 42);
            this.lblPWD.Name = "lblPWD";
            this.lblPWD.Size = new System.Drawing.Size(100, 26);
            this.lblPWD.TabIndex = 4;
            this.lblPWD.Text = "密码：";
            this.lblPWD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPWD
            // 
            this.txtPWD.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPWD.Location = new System.Drawing.Point(126, 44);
            this.txtPWD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(100, 26);
            this.txtPWD.TabIndex = 6;
            this.txtPWD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPWD_KeyPress);
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("宋体", 12F);
            this.lblUser.Location = new System.Drawing.Point(21, 4);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(100, 26);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "用户名：";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPWD);
            this.Controls.Add(this.lblPWD);
            this.Name = "ucLogin";
            this.Size = new System.Drawing.Size(240, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPWD;
        private System.Windows.Forms.TextBox txtPWD;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolTip tt;
    }
}

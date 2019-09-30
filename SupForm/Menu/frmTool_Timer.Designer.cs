namespace ERPSupport.SupForm.Menu
{
    partial class frmTool_Timer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTool_Timer));
            this.btnStar = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.txtPickMinute = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.tSumSecond = new System.Windows.Forms.Timer(this.components);
            this.btnRestar = new System.Windows.Forms.Button();
            this.lblT = new System.Windows.Forms.Label();
            this.lblTick = new System.Windows.Forms.Label();
            this.lblMinute = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblTimes = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.cbxFnuction = new System.Windows.Forms.ComboBox();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.chbExit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnStar
            // 
            this.btnStar.Location = new System.Drawing.Point(15, 242);
            this.btnStar.Margin = new System.Windows.Forms.Padding(4);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(100, 29);
            this.btnStar.TabIndex = 2;
            this.btnStar.Text = "启动";
            this.tt.SetToolTip(this.btnStar, "启动自动执行。");
            this.btnStar.UseVisualStyleBackColor = true;
            this.btnStar.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(123, 242);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 29);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "暂停";
            this.tt.SetToolTip(this.btnPause, "暂停自动执行。");
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // txtPickMinute
            // 
            this.txtPickMinute.Location = new System.Drawing.Point(123, 178);
            this.txtPickMinute.Margin = new System.Windows.Forms.Padding(4);
            this.txtPickMinute.Name = "txtPickMinute";
            this.txtPickMinute.Size = new System.Drawing.Size(99, 25);
            this.txtPickMinute.TabIndex = 0;
            this.txtPickMinute.Text = "20";
            this.tt.SetToolTip(this.txtPickMinute, "每次自动执行功能的时间间隔。");
            this.txtPickMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPickMinute_KeyPress);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("新宋体", 16F, System.Drawing.FontStyle.Bold);
            this.lblTime.Location = new System.Drawing.Point(100, 99);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(132, 27);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "00:00:00";
            this.tt.SetToolTip(this.lblTime, "自动功能已经启动的时间。");
            // 
            // tSumSecond
            // 
            this.tSumSecond.Interval = 1000;
            this.tSumSecond.Tick += new System.EventHandler(this.tSumSecond_Tick);
            // 
            // btnRestar
            // 
            this.btnRestar.Location = new System.Drawing.Point(231, 242);
            this.btnRestar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(100, 29);
            this.btnRestar.TabIndex = 4;
            this.btnRestar.Text = "重置";
            this.tt.SetToolTip(this.btnRestar, "清除所有持续状态，并重新开始。");
            this.btnRestar.UseVisualStyleBackColor = true;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Font = new System.Drawing.Font("宋体", 12F);
            this.lblT.Location = new System.Drawing.Point(88, 142);
            this.lblT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(99, 20);
            this.lblT.TabIndex = 2;
            this.lblT.Text = "执行次数:";
            this.tt.SetToolTip(this.lblT, "功能已经自动执行的次数。");
            // 
            // lblTick
            // 
            this.lblTick.AutoSize = true;
            this.lblTick.Location = new System.Drawing.Point(35, 181);
            this.lblTick.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTick.Name = "lblTick";
            this.lblTick.Size = new System.Drawing.Size(75, 15);
            this.lblTick.TabIndex = 2;
            this.lblTick.Text = "时间间隔:";
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.Location = new System.Drawing.Point(231, 181);
            this.lblMinute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(37, 15);
            this.lblMinute.TabIndex = 2;
            this.lblMinute.Text = "分钟";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("新宋体", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(85, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 34);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "运行时间";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("新宋体", 16F, System.Drawing.FontStyle.Bold);
            this.lblDay.Location = new System.Drawing.Point(151, 61);
            this.lblDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(41, 27);
            this.lblDay.TabIndex = 2;
            this.lblDay.Text = "天";
            this.tt.SetToolTip(this.lblDay, "自动功能已经启动的天数。");
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(123, 278);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.tt.SetToolTip(this.btnOK, "确定并返回设置参数。");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(231, 278);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(100, 29);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "取消";
            this.tt.SetToolTip(this.btnCancle, "取消当前设置的参数并返回。");
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("宋体", 16F);
            this.lblDays.Location = new System.Drawing.Point(100, 61);
            this.lblDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(26, 27);
            this.lblDays.TabIndex = 4;
            this.lblDays.Text = " ";
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTimes.Location = new System.Drawing.Point(203, 142);
            this.lblTimes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(19, 20);
            this.lblTimes.TabIndex = 4;
            this.lblTimes.Text = " ";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Location = new System.Drawing.Point(35, 215);
            this.lblFunction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(75, 15);
            this.lblFunction.TabIndex = 2;
            this.lblFunction.Text = "执行功能:";
            // 
            // cbxFnuction
            // 
            this.cbxFnuction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFnuction.FormattingEnabled = true;
            this.cbxFnuction.Location = new System.Drawing.Point(123, 211);
            this.cbxFnuction.Margin = new System.Windows.Forms.Padding(4);
            this.cbxFnuction.Name = "cbxFnuction";
            this.cbxFnuction.Size = new System.Drawing.Size(144, 23);
            this.cbxFnuction.TabIndex = 1;
            this.tt.SetToolTip(this.cbxFnuction, "选择自动执行功能。");
            // 
            // chbExit
            // 
            this.chbExit.AutoSize = true;
            this.chbExit.Location = new System.Drawing.Point(15, 283);
            this.chbExit.Margin = new System.Windows.Forms.Padding(4);
            this.chbExit.Name = "chbExit";
            this.chbExit.Size = new System.Drawing.Size(89, 19);
            this.chbExit.TabIndex = 5;
            this.chbExit.Text = "定时关闭";
            this.tt.SetToolTip(this.chbExit, "无操作定时关闭程序");
            this.chbExit.UseVisualStyleBackColor = true;
            // 
            // frmTool_Timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 313);
            this.ControlBox = false;
            this.Controls.Add(this.chbExit);
            this.Controls.Add(this.cbxFnuction);
            this.Controls.Add(this.lblTimes);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblMinute);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.lblTick);
            this.Controls.Add(this.lblT);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtPickMinute);
            this.Controls.Add(this.btnRestar);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(360, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 360);
            this.Name = "frmTool_Timer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计时器设置";
            this.Load += new System.EventHandler(this.frmTool_Timer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStar;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TextBox txtPickMinute;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tSumSecond;
        private System.Windows.Forms.Button btnRestar;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label lblTick;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.ComboBox cbxFnuction;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.CheckBox chbExit;
    }
}
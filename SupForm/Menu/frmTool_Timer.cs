﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ERPSupport.SupForm.Menu
{
    using Model.Basic;
    using Model.Globa;

    /// <summary>
    /// 定时器设置
    /// </summary>
    public partial class frmTool_Timer : Form
    {
        /// <summary>
        /// 进行时间累计(秒)
        /// </summary>
        int _Second;
        /// <summary>
        /// 正则表达式
        /// </summary>
        private Regex _reg;

        private TimerParameter _TimerPara;
        /// <summary>
        /// 计时器参数
        /// </summary>
        public TimerParameter TimerPara
        {
            get
            {
                return _TimerPara;
            }

            set
            {
                _TimerPara = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pTimerPara"></param>
        public frmTool_Timer(TimerParameter pTimerPara)
        {
            InitializeComponent();

            _TimerPara = new TimerParameter(pTimerPara.ExeTimes, pTimerPara.PickMinute, pTimerPara.RunSeconds, pTimerPara.PauseStatus, pTimerPara.IsRunning, pTimerPara.FuncID);
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTool_Timer_Load(object sender, EventArgs e)
        {
            tSumSecond.Interval = 1000;
            tSumSecond.Enabled = false;
            _reg = new Regex(@"^[1-9]\d*|0$");
            _Second = 0;

            FillComboBox();

            if (_TimerPara.PauseStatus)
            {
                btnStar.Enabled = true;
                btnPause.Enabled = false;
            }
            else
            {
                btnStar.Enabled = false;
                btnPause.Enabled = true;
                tSumSecond.Start();
            }

            txtPickMinute.Text = _TimerPara.PickMinute.ToString();
            lblTimes.Text = _TimerPara.ExeTimes.ToString();
            cbxFnuction.SelectedIndex = _TimerPara.FuncID == "ALL" ? 0 : 1;

            chbExit.Checked = System.Configuration.ConfigurationManager.AppSettings["LS_AutoExit"] == "1";

            ShowTime();
        }

        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            DataTable dt = null;
            DataRow dr = null;

            //cbxLogic
            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            dr = dt.NewRow();
            dr["FName"] = "全部";
            dr["FValue"] = "ALL";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "倒冲领料";
            dr["FValue"] = "PickMtrl";
            dt.Rows.Add(dr);

            cbxFnuction.DataSource = dt;
            cbxFnuction.DisplayMember = "FName";
            cbxFnuction.ValueMember = "FValue";
            cbxFnuction.SelectedIndex = 1;
        }

        /// <summary>
        /// 显示计时时间
        /// </summary>
        private void ShowTime()
        {
            lblDays.Text = string.Format("{0:d}", (_TimerPara.RunSeconds + _Second) / 86400);//24*60*60
            lblTime.Text = string.Format("{0:d2}:{1:d2}:{2:d2}", (_TimerPara.RunSeconds + _Second) / 3600 % 24, (_TimerPara.RunSeconds + _Second) / 60 % 60, (_TimerPara.RunSeconds + _Second) % 60);
        }

        /// <summary>
        /// 每当经过指定的时间间隔时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSumSecond_Tick(object sender, EventArgs e)
        {
            _Second++;
            ShowTime();
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStar_Click(object sender, EventArgs e)
        {
            tSumSecond.Start();

            _TimerPara.PauseStatus = false;

            btnStar.Enabled = false;
            btnPause.Enabled = true;
        }

        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            tSumSecond.Stop();

            _TimerPara.PauseStatus = true;

            btnStar.Enabled = true;
            btnPause.Enabled = false;
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestar_Click(object sender, EventArgs e)
        {
            tSumSecond.Stop();

            _TimerPara = new TimerParameter(0, 20, 0, true, false, "NULL");
            _Second = 0;
            txtPickMinute.Text = _TimerPara.PickMinute.ToString();
            btnStar.Enabled = true;
            btnPause.Enabled = false;
            ShowTime();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //目前只能设置自动领料功能

            //最多只能一个客户端设置自动领料
            DataTable dt = DALFactory.K3Cloud.DALCreator.CommFunction.GetLockObjectInfo("LOCKPICKMTL");
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("自动领料数据查询失败，未能启动自动领料");
                return;
            }

            if (GlobalParameter.K3Inf.UserName != dt.Rows[0]["FUSER"].ToString())//本客户端还未占用自动领料的情况下，判断自动领料功能是否被他人占用。
            {
                if (dt.Rows[0]["FSTATUS"].ToString() != "0" && !_TimerPara.PauseStatus)
                {
                    MessageBox.Show("[" + dt.Rows[0]["FUSER"].ToString() + "]正在执行自动领料，请勿重复设置。");
                    return;
                }
            }

            if (txtPickMinute.Text.Trim() == string.Empty || int.Parse(txtPickMinute.Text) == 0)
            {
                MessageBox.Show("请输入定时时间");
                txtPickMinute.Focus();
                return;
            }

            if (int.Parse(txtPickMinute.Text) < 15)
            {
                MessageBox.Show("时间间隔不能小于15分钟");
                txtPickMinute.Focus();
                txtPickMinute.Select();
                return;
            }

            _TimerPara.ExeTimes = int.Parse(lblTimes.Text.Trim() == "" ? "0" : lblTimes.Text.Trim());
            _TimerPara.PickMinute = int.Parse(txtPickMinute.Text);
            _TimerPara.FuncID = cbxFnuction.SelectedIndex == 0 ? "ALL" : "PickMtrl";
            _TimerPara.RunSeconds += _Second;

            if (_TimerPara.PauseStatus)//更新占用自动领料功能状态。
            {
                DALFactory.K3Cloud.DALCreator.CommFunction.UpdateLockStatus(0, "LOCKPICKMTL");
            }
            else
            {
                DALFactory.K3Cloud.DALCreator.CommFunction.UpdateLockStatus(1, "LOCKPICKMTL");
            }

            string AutoExit = chbExit.Checked ? "1" : "0";
            UserClass.AppConfig.WriteValue("LS_AutoExit", AutoExit);

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// txtPickMinute_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPickMinute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                if (!_reg.IsMatch(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            }
        }
    }
}

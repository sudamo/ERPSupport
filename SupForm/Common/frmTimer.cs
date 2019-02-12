using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ERPSupport.SQL.K3Cloud;
using ERPSupport.Model.Basic;
using ERPSupport.Model.Globa;

namespace ERPSupport.SupForm.Common
{
    /// <summary>
    /// 定时器设置
    /// </summary>
    public partial class frmTimer : Form
    {
        /// <summary>
        /// 进行时间累计(秒)
        /// </summary>
        int iSecond;
        /// <summary>
        /// 正则表达式
        /// </summary>
        private Regex reg;
        /// <summary>
        /// 定时器实例
        /// </summary>
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
        public frmTimer(TimerParameter pTimerPara)
        {
            InitializeComponent();

            _TimerPara = new TimerParameter(pTimerPara.ExeTimes, pTimerPara.PickMinute, pTimerPara.RunSeconds, pTimerPara.PauseStatus, pTimerPara.IsRunning, pTimerPara.FuncID);
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTimer_Load(object sender, EventArgs e)
        {
            tSumSecond.Interval = 1000;
            tSumSecond.Enabled = false;
            reg = new Regex(@"^[1-9]\d*|0$");
            iSecond = 0;

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
            lblDays.Text = string.Format("{0:d}", (_TimerPara.RunSeconds + iSecond) / 86400);//24*60*60
            lblTime.Text = string.Format("{0:d2}:{1:d2}:{2:d2}", (_TimerPara.RunSeconds + iSecond) / 3600 % 24, (_TimerPara.RunSeconds + iSecond) / 60 % 60, (_TimerPara.RunSeconds + iSecond) % 60);
        }

        /// <summary>
        /// 每当经过指定的时间间隔时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSumSecond_Tick(object sender, EventArgs e)
        {
            iSecond++;
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
            iSecond = 0;
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
            DataTable dt = CommonFunction.GetLockObjectInfo("LOCKPICKMTL");
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("自动领料数据查询失败，未能启动自动领料");
                return;
            }

            if (GlobalParameter.K3Inf.UserName != dt.Rows[0]["FUSER"].ToString())//本客户端还未占用自动领料的情况下，判断自动领料功能是否被他人占用。
            {
                if (dt.Rows[0]["FSTATUS"].ToString() != "0")
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
            _TimerPara.RunSeconds += iSecond;

            if (_TimerPara.PauseStatus)//更新占用自动领料功能状态。
            {
                CommonFunction.UpdateLockStatus(0, "LOCKPICKMTL");
            }
            else
            {
                CommonFunction.UpdateLockStatus(1, "LOCKPICKMTL");
            }

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
                if (!reg.IsMatch(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            }
        }
    }
}

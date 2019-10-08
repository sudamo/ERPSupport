using System;
using System.Data;
using System.Timers;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Kingdee.BOS.WebApi.Client;
using Excel = Microsoft.Office.Interop.Excel;

namespace ERPSupport.SupForm.Bussiness
{
    using SQL.K3Cloud;
    using Model.Globa;

    /// <summary>
    /// 订单运算
    /// </summary>
    public partial class frmOrderOperation : Form
    {
        #region Fields Properties Variable & Constructor

        /// <summary>
        /// 订单信息
        /// </summary>
        private DataTable _dtRun;
        /// <summary>
        /// 订单信息运算结果
        /// </summary>
        private DataTable _dtRunResult;
        /// <summary>
        /// 子项明细信息
        /// </summary>
        private DataTable _dtDtl;
        /// <summary>
        /// 子项明细运算结果
        /// </summary>
        private DataTable _dtDtlResult;
        /// <summary>
        /// 需要运算的订单分录ID集合
        /// </summary>
        private List<int> _ListRunEntryId;
        /// <summary>
        /// 不需要运算的订单分录ID集合
        /// </summary>
        private List<int> _ListNotRunEntryId;
        /// <summary>
        /// 方法标识
        /// </summary>
        private string _FuncID;
        /// <summary>
        /// 指定的时间段内总天数
        /// </summary>
        private int _SumDays;
        /// <summary>
        /// 指定的时间段内，除去周日的天数。
        /// </summary>
        private int _Days;
        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime _StarTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        private DateTime _EndTime;
        /// <summary>
        /// 运算是否添加采购生产数量
        /// </summary>
        private bool _AddJoinQty;
        /// <summary>
        /// 计时器
        /// </summary>
        private System.Timers.Timer _timer;
        /// <summary>
        /// 单独进程执行操作的组件
        /// </summary>
        private BackgroundWorker _bgWorker;
        /// <summary>
        /// 进度条窗体
        /// </summary>
        private frmProgress _frmNotify;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pDT">销售订单分录信息</param>
        public frmOrderOperation(DataTable pDT)
        {
            InitializeComponent();
            _dtRun = pDT;
        }
        #endregion

        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOrderOperation_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;//解决多线程调用控件问题

            _frmNotify = new frmProgress();
            _bgWorker = new BackgroundWorker();
            _bgWorker.WorkerReportsProgress = true;
            _bgWorker.WorkerSupportsCancellation = true;
            _bgWorker.DoWork += new DoWorkEventHandler(DoWork);
            _bgWorker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);

            SetDefault();
        }
        #endregion

        #region 设置初始状态
        /// <summary>
        /// 设置初始状态
        /// </summary>
        private void SetDefault()
        {
            //计时
            _timer = new System.Timers.Timer();
            _timer.Enabled = true;
            _timer.Interval = 1000 * 60 * 5;//每5分钟执行一次
            _timer.Start();
            _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            //获取数据源
            dgv1.DataSource = _dtRun;
            dgv1.Columns[18].Visible = false;
            dgv1.Columns[19].Visible = false;

            //不允许重新排列
            DGVSort(dgv1, false);

            //配置信息
            _StarTime = DateTime.Parse(UserClass.AppConfig.ReadValue("ORP_StarTime", "AppSettings"));
            _EndTime = DateTime.Parse(UserClass.AppConfig.ReadValue("ORP_EndTime", "AppSettings"));
            _SumDays = int.Parse(UserClass.AppConfig.ReadValue("ORP_SumMoonths", "AppSettings"));
            _AddJoinQty = UserClass.AppConfig.ReadValue("ORP_AddJoinQty", "AppSettings") == "0" ? false : true;

            int itemp = _SumDays;
            _Days = 0;
            while (itemp > 0)
            {
                if (_EndTime.AddDays(-itemp + 1).DayOfWeek != DayOfWeek.Sunday)
                    _Days++;
                itemp--;
            }
        }
        #endregion

        #region 是否允许DataGridView column 排序
        /// <summary>
        /// 是否允许DataGridView column 排序
        /// </summary>
        /// <param name="pDGV"></param>
        /// <param name="pSort"></param>
        private void DGVSort(DataGridView pDGV, bool pSort)
        {
            DataGridViewColumnSortMode tempMode = pSort ? DataGridViewColumnSortMode.Automatic : DataGridViewColumnSortMode.NotSortable;
            for (int i = 0; i < pDGV.Columns.Count; i++)
                pDGV.Columns[i].SortMode = tempMode;
        }
        #endregion

        #region 进度控制
        /// <summary>
        /// 执行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            if (_FuncID == "ExpandMTL")
                e.Result = ExpandMTL(e);
            else
                e.Result = SaveOrderRun(e);
        }

        /// <summary>
        /// 进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            _frmNotify.SetNotifyInfo(e.ProgressPercentage, "运算进度:" + e.ProgressPercentage + " %");
        }

        /// <summary>
        /// 事件处理完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            _frmNotify.Close();
        }
        #endregion

        #region 定时器
        /// <summary>
        /// 定时执行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //每5分钟更新一次正在使用时间
            CommFunction.UpdateLockStatus(1, "ORDERRUN");
        }
        #endregion

        #region 运算
        /// <summary>
        /// 订单运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            _dtRunResult = SalOrder.OrderRun(_dtRun, _AddJoinQty);

            if (_dtRunResult == null || _dtRunResult.Rows.Count == 0)
            {
                MessageBox.Show("未查询到成品物料信息");
                return;
            }

            dgv1.DataSource = null;
            dgv1.DataSource = _dtRunResult;
            dgv1.Columns[0].Visible = false;
            dgv1.Columns[1].Visible = false;
            _ListRunEntryId = new List<int>();
            _ListNotRunEntryId = new List<int>();

            //不允许重新排列
            DGVSort(dgv1, false);

            for (int i = 0; i < _dtRunResult.Rows.Count; i++)
            {
                if (_dtRunResult.Rows[i]["欠料等级"].ToString() != "无需生产" && _dtRunResult.Rows[i]["锁库"].ToString() == "否" && _dtRunResult.Rows[i]["完全锁库"].ToString() == "否")
                {
                    dgv1.Rows[i].DefaultCellStyle.BackColor = Color.Orange;//改变需要运算行的颜色
                    _ListRunEntryId.Add(int.Parse(_dtRun.Rows[i]["订单内码"].ToString()));//添加分录ID到集合
                }
                else
                {
                    _ListNotRunEntryId.Add(int.Parse(_dtRun.Rows[i]["订单内码"].ToString()));
                }
            }

            if (_ListRunEntryId.Count > 0)
            {
                dgv2.DataSource = null;

                //子项运算进度
                _FuncID = "ExpandMTL";
                _bgWorker.RunWorkerAsync();
                _frmNotify.ShowDialog();

                //更新订单分录欠料等级
                string strTempLL;
                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    if (dgv1.Rows[i].DefaultCellStyle.BackColor == Color.Orange)
                    {
                        if (dgv1.Rows[i].Cells[19].Value.ToString().Trim().Length > 0)
                        {
                            strTempLL = LackLevel(int.Parse(_dtRun.Rows[i]["订单内码"].ToString()));
                            dgv1.Rows[i].Cells[22].Value = strTempLL;
                            _dtRunResult.Rows[i]["欠料等级"] = strTempLL;
                        }
                        else
                            dgv1.Rows[i].Cells[22].Value = " ";
                    }
                }

                chbAll.Enabled = true;
                txtFBillNo.Enabled = true;
                btnSummary.Enabled = true;

                MessageBox.Show("运算完毕");
            }
            else
            {
                MessageBox.Show("没有需要运算的订单");
                //return;
            }

            btnSave.Enabled = true;
        }

        /// <summary>
        /// 子项物料运算
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int ExpandMTL(DoWorkEventArgs e)
        {
            _dtDtl = new DataTable();
            _dtDtl = SalOrder.OrderRun(_ListRunEntryId, _StarTime, _EndTime, _AddJoinQty);

            if (_dtDtl == null || _dtDtl.Rows.Count == 0)
            {
                MessageBox.Show("未查询到子项物料信息");
                return -1;
            }

            #region Define Variables

            //子项运算

            DataTable dtCalulate = new DataTable();//多次运算物料Table
            dtCalulate.Columns.Add("物料编码");
            dtCalulate.Columns.Add("库存可用数量");
            dtCalulate.Columns.Add("库存需求");
            dtCalulate.Columns.Add("净需求");
            dtCalulate.Columns.Add("本次占用数量");

            dtCalulate.Columns.Add("累计占用数量");
            //dtCalulate.Columns.Add("欠料数量");

            _dtDtlResult = new DataTable();
            DataRow dr;
            int iCount = 0;//子项明细行数            
            bool bMatched = false;//物料是否已作运算

            _dtDtlResult.Columns.Add("订单编号");
            _dtDtlResult.Columns.Add("父项物料");
            _dtDtlResult.Columns.Add("父项名称");
            _dtDtlResult.Columns.Add("物料编码");
            _dtDtlResult.Columns.Add("物料名称");

            _dtDtlResult.Columns.Add("单位");
            _dtDtlResult.Columns.Add("BOM");
            _dtDtlResult.Columns.Add("订单数量");
            _dtDtlResult.Columns.Add("锁库数量");
            _dtDtlResult.Columns.Add("子项需求");
            //1
            _dtDtlResult.Columns.Add("库存数量");
            _dtDtlResult.Columns.Add("库存可用数量");
            _dtDtlResult.Columns.Add("最小库存");
            _dtDtlResult.Columns.Add("最大库存");
            _dtDtlResult.Columns.Add("库存需求");

            _dtDtlResult.Columns.Add("净需求");
            _dtDtlResult.Columns.Add("领料数量");
            _dtDtlResult.Columns.Add("安全库存");
            _dtDtlResult.Columns.Add("库存可用天数");
            _dtDtlResult.Columns.Add("下单点");
            //2
            _dtDtlResult.Columns.Add("本次占用数量");
            _dtDtlResult.Columns.Add("累计占用数量");
            _dtDtlResult.Columns.Add("欠料数量");
            _dtDtlResult.Columns.Add("欠料等级");
            _dtDtlResult.Columns.Add("物料属性");

            _dtDtlResult.Columns.Add("客户");
            _dtDtlResult.Columns.Add("提交人");
            _dtDtlResult.Columns.Add("采购在途");
            _dtDtlResult.Columns.Add("生产自制");
            _dtDtlResult.Columns.Add("安全库存天数");
            //3
            _dtDtlResult.Columns.Add("物流天数");
            _dtDtlResult.Columns.Add("最低订货量");
            _dtDtlResult.Columns.Add("最小批量");
            _dtDtlResult.Columns.Add("补货量");
            _dtDtlResult.Columns.Add("可用库存");

            _dtDtlResult.Columns.Add("FID");
            _dtDtlResult.Columns.Add("FENTRYID");
            _dtDtlResult.Columns.Add("SALORG");
            _dtDtlResult.Columns.Add("FMATERIALID");
            #endregion

            for (int i = 0; i < _ListRunEntryId.Count; i++)
            {
                for (int j = 0; j < _dtDtl.Rows.Count; j++)
                {
                    if (int.Parse(_dtDtl.Rows[j]["FENTRYID"].ToString()) == _ListRunEntryId[i])
                    {
                        if (i == 0)//第一个成品的子项添加到dtDetailResult和dtCalulate中
                        {
                            #region if i = 0
                            dr = _dtDtlResult.NewRow();

                            dr["订单编号"] = _dtDtl.Rows[j]["FBILLNO"];
                            dr["父项物料"] = _dtDtl.Rows[j]["PFNUMBER"];
                            dr["父项名称"] = _dtDtl.Rows[j]["PFNAME"];
                            dr["物料编码"] = _dtDtl.Rows[j]["FNUMBER"];
                            dr["物料名称"] = _dtDtl.Rows[j]["FNAME"];

                            dr["单位"] = _dtDtl.Rows[j]["UNIT"];
                            dr["BOM"] = _dtDtl.Rows[j]["BOM"];
                            dr["订单数量"] = _dtDtl.Rows[j]["FQTY"];
                            dr["锁库数量"] = _dtDtl.Rows[j]["FLOCKQTY"];
                            dr["子项需求"] = _dtDtl.Rows[j]["FSUBQTY"];
                            //1
                            dr["库存数量"] = _dtDtl.Rows[j]["STOCKQTY"];
                            dr["可用库存"] = _dtDtl.Rows[j]["STOCKAVBQTY"];
                            dr["库存可用数量"] = decimal.Parse(dr["可用库存"].ToString()) > decimal.Parse(dr["子项需求"].ToString()) ? decimal.Parse(dr["可用库存"].ToString()) - decimal.Parse(dr["子项需求"].ToString()) : 0;
                            dr["最小库存"] = _dtDtl.Rows[j]["FMINSTOCK"];
                            dr["最大库存"] = _dtDtl.Rows[j]["FMAXSTOCK"];

                            dr["库存需求"] = decimal.Parse(dr["可用库存"].ToString()) > 0 ? (decimal.Parse(dr["可用库存"].ToString()) >= decimal.Parse(dr["最小库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString()) ? 0 : decimal.Parse(dr["最大库存"].ToString()) - decimal.Parse(dr["可用库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString())) : dr["最大库存"];
                            dr["净需求"] = decimal.Parse(dr["可用库存"].ToString()) > 0 ? (decimal.Parse(dr["可用库存"].ToString()) >= decimal.Parse(dr["最小库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString()) ? 0 : decimal.Parse(dr["最大库存"].ToString()) - decimal.Parse(dr["可用库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString())) : decimal.Parse(dr["最大库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString());
                            dr["领料数量"] = _dtDtl.Rows[j]["FACTUALQTY"];
                            dr["安全库存天数"] = _dtDtl.Rows[j]["F_PAEZ_SAFEDAYS"];
                            dr["物流天数"] = _dtDtl.Rows[j]["F_PAEZ_LOGISTICSDAYS"];
                            //2
                            dr["安全库存"] = decimal.Parse(dr["领料数量"].ToString()) / _SumDays * int.Parse(dr["安全库存天数"].ToString());
                            dr["库存可用天数"] = decimal.Parse(dr["领料数量"].ToString()) == 0 ? 0 : decimal.Parse(dr["可用库存"].ToString()) / decimal.Parse(dr["领料数量"].ToString()) / _Days;
                            dr["下单点"] = decimal.Parse(dr["领料数量"].ToString()) / _Days * (int.Parse(dr["安全库存天数"].ToString()) + int.Parse(dr["物流天数"].ToString()));
                            dr["本次占用数量"] = decimal.Parse(dr["可用库存"].ToString()) >= decimal.Parse(dr["子项需求"].ToString()) ? dr["子项需求"] : dr["可用库存"];
                            dr["累计占用数量"] = dr["子项需求"];

                            dr["欠料数量"] = decimal.Parse(dr["可用库存"].ToString()) >= decimal.Parse(dr["子项需求"].ToString()) ? 0 : decimal.Parse(dr["子项需求"].ToString()) - decimal.Parse(dr["可用库存"].ToString());
                            dr["欠料等级"] = decimal.Parse(dr["欠料数量"].ToString()) > 0 ? _dtDtl.Rows[j]["FGROUPLEVEL"].ToString().Trim() : string.Empty;
                            dr["物料属性"] = int.Parse(_dtDtl.Rows[j]["FERPCLSID"].ToString()) == 1 ? "外购" : "自制";
                            dr["采购在途"] = _dtDtl.Rows[j]["FPOQTY"];
                            dr["生产自制"] = _dtDtl.Rows[j]["FMOQTY"];
                            //3
                            dr["最低订货量"] = _dtDtl.Rows[j]["F_PAEZ_LOWQTY"];
                            dr["最小批量"] = _dtDtl.Rows[j]["F_PAEZ_MINQTY"];
                            dr["补货量"] = _dtDtl.Rows[j]["F_PAEZ_REPLENISHMENT"];
                            dr["FID"] = _dtDtl.Rows[j]["FID"];
                            dr["FENTRYID"] = _dtDtl.Rows[j]["FENTRYID"];

                            dr["SALORG"] = _dtDtl.Rows[j]["SALORG"];
                            dr["FMATERIALID"] = _dtDtl.Rows[j]["FMATERIALID"];
                            dr["客户"] = _dtDtl.Rows[j]["FCUSTID"];
                            dr["提交人"] = _dtDtl.Rows[j]["F_PAEZ_SUBMITUSERID"];

                            _dtDtlResult.Rows.Add(dr);

                            //添加数据到dtCalulate
                            dr = dtCalulate.NewRow();
                            dr["物料编码"] = _dtDtlResult.Rows[iCount]["物料编码"];
                            dr["库存可用数量"] = _dtDtlResult.Rows[iCount]["库存可用数量"];
                            dr["库存需求"] = _dtDtlResult.Rows[iCount]["库存需求"];
                            dr["净需求"] = _dtDtlResult.Rows[iCount]["净需求"];
                            dr["本次占用数量"] = _dtDtlResult.Rows[iCount]["本次占用数量"];

                            dr["累计占用数量"] = _dtDtlResult.Rows[iCount]["累计占用数量"];

                            dtCalulate.Rows.Add(dr);
                            //累计子项数量
                            iCount++;
                            #endregion
                        }
                        else//
                        {
                            for (int k = 0; k < dtCalulate.Rows.Count; k++)
                            {
                                bMatched = false;
                                if (_dtDtl.Rows[j]["FNUMBER"].ToString() == dtCalulate.Rows[k]["物料编码"].ToString())//物料是否已作运算，是则做累计运算再添加到dtDtlResult中
                                {
                                    #region if Match Material Number
                                    dr = _dtDtlResult.NewRow();

                                    dr["订单编号"] = _dtDtl.Rows[j]["FBILLNO"];
                                    dr["父项物料"] = _dtDtl.Rows[j]["PFNUMBER"];
                                    dr["父项名称"] = _dtDtl.Rows[j]["PFNAME"];
                                    dr["物料编码"] = _dtDtl.Rows[j]["FNUMBER"];
                                    dr["物料名称"] = _dtDtl.Rows[j]["FNAME"];

                                    dr["单位"] = _dtDtl.Rows[j]["UNIT"];
                                    dr["BOM"] = _dtDtl.Rows[j]["BOM"];
                                    dr["订单数量"] = _dtDtl.Rows[j]["FQTY"];
                                    dr["锁库数量"] = _dtDtl.Rows[j]["FLOCKQTY"];
                                    dr["子项需求"] = _dtDtl.Rows[j]["FSUBQTY"];
                                    //1
                                    dr["库存数量"] = _dtDtl.Rows[j]["STOCKQTY"];
                                    dr["可用库存"] = _dtDtl.Rows[j]["STOCKAVBQTY"];
                                    dr["库存可用数量"] = decimal.Parse(dr["可用库存"].ToString()) > decimal.Parse(dr["子项需求"].ToString()) + decimal.Parse(dtCalulate.Rows[k]["累计占用数量"].ToString()) ? decimal.Parse(dr["可用库存"].ToString()) - decimal.Parse(dr["子项需求"].ToString()) - decimal.Parse(dtCalulate.Rows[k]["累计占用数量"].ToString()) : 0;
                                    dr["最小库存"] = _dtDtl.Rows[j]["FMINSTOCK"];
                                    dr["最大库存"] = _dtDtl.Rows[j]["FMAXSTOCK"];

                                    dr["库存需求"] = decimal.Parse(dtCalulate.Rows[k]["库存可用数量"].ToString()) > 0 ? (decimal.Parse(dtCalulate.Rows[k]["库存可用数量"].ToString()) >= decimal.Parse(dr["最小库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString()) ? 0 : decimal.Parse(dr["最大库存"].ToString()) - decimal.Parse(dtCalulate.Rows[k]["库存可用数量"].ToString()) + decimal.Parse(dr["子项需求"].ToString())) : dr["最大库存"];
                                    dr["净需求"] = decimal.Parse(dtCalulate.Rows[k]["库存可用数量"].ToString()) > 0 ? (decimal.Parse(dtCalulate.Rows[k]["库存可用数量"].ToString()) >= decimal.Parse(dr["最小库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString()) ? 0 : decimal.Parse(dr["最大库存"].ToString()) - decimal.Parse(dtCalulate.Rows[k]["库存可用数量"].ToString()) + decimal.Parse(dr["子项需求"].ToString())) : decimal.Parse(dr["最大库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString());
                                    dr["领料数量"] = _dtDtl.Rows[j]["FACTUALQTY"];
                                    dr["安全库存天数"] = _dtDtl.Rows[j]["F_PAEZ_SAFEDAYS"];
                                    dr["物流天数"] = _dtDtl.Rows[j]["F_PAEZ_LOGISTICSDAYS"];
                                    //2
                                    dr["安全库存"] = decimal.Parse(dr["领料数量"].ToString()) / _SumDays * int.Parse(dr["安全库存天数"].ToString());
                                    dr["库存可用天数"] = decimal.Parse(dr["领料数量"].ToString()) == 0 ? 0 : decimal.Parse(dr["可用库存"].ToString()) / decimal.Parse(dr["领料数量"].ToString()) / _Days;
                                    dr["下单点"] = decimal.Parse(dr["领料数量"].ToString()) / _Days * (int.Parse(dr["安全库存天数"].ToString()) + int.Parse(dr["物流天数"].ToString()));
                                    dr["本次占用数量"] = decimal.Parse(dtCalulate.Rows[k]["库存可用数量"].ToString()) > 0 ? (decimal.Parse(dtCalulate.Rows[k]["库存可用数量"].ToString()) >= decimal.Parse(dr["子项需求"].ToString()) ? dr["子项需求"] : decimal.Parse(dtCalulate.Rows[k]["库存可用数量"].ToString())) : 0;
                                    dr["累计占用数量"] = decimal.Parse(dtCalulate.Rows[k]["累计占用数量"].ToString()) + decimal.Parse(dr["子项需求"].ToString());

                                    dr["欠料数量"] = decimal.Parse(dr["可用库存"].ToString()) >= decimal.Parse(dr["累计占用数量"].ToString()) ? 0 : decimal.Parse(dr["累计占用数量"].ToString()) - decimal.Parse(dr["可用库存"].ToString());
                                    dr["欠料等级"] = decimal.Parse(dr["欠料数量"].ToString()) > 0 ? _dtDtl.Rows[j]["FGROUPLEVEL"].ToString().Trim() : string.Empty;
                                    dr["物料属性"] = int.Parse(_dtDtl.Rows[j]["FERPCLSID"].ToString()) == 1 ? "外购" : "自制";
                                    dr["采购在途"] = _dtDtl.Rows[j]["FPOQTY"];
                                    dr["生产自制"] = _dtDtl.Rows[j]["FMOQTY"];
                                    //3
                                    dr["最低订货量"] = _dtDtl.Rows[j]["F_PAEZ_LOWQTY"];
                                    dr["最小批量"] = _dtDtl.Rows[j]["F_PAEZ_MINQTY"];
                                    dr["补货量"] = _dtDtl.Rows[j]["F_PAEZ_REPLENISHMENT"];
                                    dr["FID"] = _dtDtl.Rows[j]["FID"];
                                    dr["FENTRYID"] = _dtDtl.Rows[j]["FENTRYID"];

                                    dr["SALORG"] = _dtDtl.Rows[j]["SALORG"];
                                    dr["FMATERIALID"] = _dtDtl.Rows[j]["FMATERIALID"];
                                    dr["客户"] = _dtDtl.Rows[j]["FCUSTID"];
                                    dr["提交人"] = _dtDtl.Rows[j]["F_PAEZ_SUBMITUSERID"];

                                    _dtDtlResult.Rows.Add(dr);

                                    //调整dtCalulate数据
                                    dtCalulate.Rows[k]["库存可用数量"] = dr["库存可用数量"];
                                    dtCalulate.Rows[k]["库存需求"] = dr["库存需求"];
                                    dtCalulate.Rows[k]["净需求"] = dr["净需求"];
                                    dtCalulate.Rows[k]["本次占用数量"] = dr["本次占用数量"];

                                    dtCalulate.Rows[k]["累计占用数量"] = dr["累计占用数量"];

                                    iCount++;

                                    bMatched = true;
                                    break;
                                    #endregion
                                }
                            }

                            if (!bMatched)//未做过运算的物料，直接添加到dtDtlResult中
                            {
                                #region if bMatched is false
                                dr = _dtDtlResult.NewRow();

                                dr["订单编号"] = _dtDtl.Rows[j]["FBILLNO"];
                                dr["父项物料"] = _dtDtl.Rows[j]["PFNUMBER"];
                                dr["父项名称"] = _dtDtl.Rows[j]["PFNAME"];
                                dr["物料编码"] = _dtDtl.Rows[j]["FNUMBER"];
                                dr["物料名称"] = _dtDtl.Rows[j]["FNAME"];

                                dr["单位"] = _dtDtl.Rows[j]["UNIT"];
                                dr["BOM"] = _dtDtl.Rows[j]["BOM"];
                                dr["订单数量"] = _dtDtl.Rows[j]["FQTY"];
                                dr["锁库数量"] = _dtDtl.Rows[j]["FLOCKQTY"];
                                dr["子项需求"] = _dtDtl.Rows[j]["FSUBQTY"];
                                //1
                                dr["库存数量"] = _dtDtl.Rows[j]["STOCKQTY"];
                                dr["可用库存"] = _dtDtl.Rows[j]["STOCKAVBQTY"];
                                dr["库存可用数量"] = decimal.Parse(dr["可用库存"].ToString()) > decimal.Parse(dr["子项需求"].ToString()) ? decimal.Parse(dr["可用库存"].ToString()) - decimal.Parse(dr["子项需求"].ToString()) : 0;
                                dr["最小库存"] = _dtDtl.Rows[j]["FMINSTOCK"];
                                dr["最大库存"] = _dtDtl.Rows[j]["FMAXSTOCK"];

                                dr["库存需求"] = decimal.Parse(dr["可用库存"].ToString()) > 0 ? (decimal.Parse(dr["可用库存"].ToString()) >= decimal.Parse(dr["最小库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString()) ? 0 : decimal.Parse(dr["最大库存"].ToString()) - decimal.Parse(dr["可用库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString())) : dr["最大库存"];
                                dr["净需求"] = decimal.Parse(dr["可用库存"].ToString()) > 0 ? (decimal.Parse(dr["可用库存"].ToString()) >= decimal.Parse(dr["最小库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString()) ? 0 : decimal.Parse(dr["最大库存"].ToString()) - decimal.Parse(dr["可用库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString())) : decimal.Parse(dr["最大库存"].ToString()) + decimal.Parse(dr["子项需求"].ToString());
                                dr["领料数量"] = _dtDtl.Rows[j]["FACTUALQTY"];
                                dr["安全库存天数"] = _dtDtl.Rows[j]["F_PAEZ_SAFEDAYS"];
                                dr["物流天数"] = _dtDtl.Rows[j]["F_PAEZ_LOGISTICSDAYS"];
                                //2
                                dr["安全库存"] = decimal.Parse(dr["领料数量"].ToString()) / _SumDays * int.Parse(dr["安全库存天数"].ToString());
                                dr["库存可用天数"] = decimal.Parse(dr["领料数量"].ToString()) == 0 ? 0 : decimal.Parse(dr["可用库存"].ToString()) / decimal.Parse(dr["领料数量"].ToString()) / _Days;
                                dr["下单点"] = decimal.Parse(dr["领料数量"].ToString()) / _Days * (int.Parse(dr["安全库存天数"].ToString()) + int.Parse(dr["物流天数"].ToString()));
                                dr["本次占用数量"] = decimal.Parse(dr["可用库存"].ToString()) >= decimal.Parse(dr["子项需求"].ToString()) ? dr["子项需求"] : dr["可用库存"];
                                dr["累计占用数量"] = dr["子项需求"];

                                dr["欠料数量"] = decimal.Parse(dr["可用库存"].ToString()) >= decimal.Parse(dr["子项需求"].ToString()) ? 0 : decimal.Parse(dr["子项需求"].ToString()) - decimal.Parse(dr["可用库存"].ToString());
                                dr["欠料等级"] = decimal.Parse(dr["欠料数量"].ToString()) > 0 ? _dtDtl.Rows[j]["FGROUPLEVEL"].ToString().Trim() : string.Empty;
                                dr["物料属性"] = int.Parse(_dtDtl.Rows[j]["FERPCLSID"].ToString()) == 1 ? "外购" : "自制";
                                dr["采购在途"] = _dtDtl.Rows[j]["FPOQTY"];
                                dr["生产自制"] = _dtDtl.Rows[j]["FMOQTY"];
                                //3
                                dr["最低订货量"] = _dtDtl.Rows[j]["F_PAEZ_LOWQTY"];
                                dr["最小批量"] = _dtDtl.Rows[j]["F_PAEZ_MINQTY"];
                                dr["补货量"] = _dtDtl.Rows[j]["F_PAEZ_REPLENISHMENT"];
                                dr["FID"] = _dtDtl.Rows[j]["FID"];
                                dr["FENTRYID"] = _dtDtl.Rows[j]["FENTRYID"];

                                dr["SALORG"] = _dtDtl.Rows[j]["SALORG"];
                                dr["FMATERIALID"] = _dtDtl.Rows[j]["FMATERIALID"];
                                dr["客户"] = _dtDtl.Rows[j]["FCUSTID"];
                                dr["提交人"] = _dtDtl.Rows[j]["F_PAEZ_SUBMITUSERID"];

                                _dtDtlResult.Rows.Add(dr);

                                //添加数据到dtCalulate
                                dr = dtCalulate.NewRow();
                                dr["物料编码"] = _dtDtlResult.Rows[iCount]["物料编码"];
                                dr["库存可用数量"] = _dtDtlResult.Rows[iCount]["库存可用数量"];
                                dr["库存需求"] = _dtDtlResult.Rows[iCount]["库存需求"];
                                dr["净需求"] = _dtDtlResult.Rows[iCount]["净需求"];
                                dr["本次占用数量"] = _dtDtlResult.Rows[iCount]["本次占用数量"];

                                dr["累计占用数量"] = _dtDtlResult.Rows[iCount]["累计占用数量"];

                                dtCalulate.Rows.Add(dr);
                                //累计子项数量
                                iCount++;
                                #endregion
                            }
                        }
                    }
                }
                //进度条
                if (_bgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return -1;
                }
                else
                {
                    _bgWorker.ReportProgress((i + 1) * 100 / (_ListRunEntryId.Count));
                    Thread.Sleep(1);
                }
            }

            return 0;
        }

        #region 根据FEntryId获取欠料等级
        /// <summary>
        /// 根据销售订单分录ID获取欠料等级
        /// </summary>
        /// <param name="pFEntryId">订单分录ID</param>
        /// <returns></returns>
        private string LackLevel(int pFEntryId)
        {
            string strGroupLeve = string.Empty;

            if (_dtDtlResult == null || _dtDtlResult.Rows.Count == 0)
                return string.Empty;

            for (int i = 0; i < _dtDtlResult.Rows.Count; i++)
            {
                if (int.Parse(_dtDtlResult.Rows[i]["FENTRYID"].ToString()) == pFEntryId && _dtDtlResult.Rows[i]["欠料等级"] != null)
                {
                    if (strGroupLeve.Length > 0 && _dtDtlResult.Rows[i]["欠料等级"].ToString().Trim().Length > 0)
                        strGroupLeve += ",";

                    strGroupLeve += _dtDtlResult.Rows[i]["欠料等级"].ToString();
                }
            }

            return strGroupLeve.Length > 0 ? "欠料:" + strGroupLeve.Trim() : "不欠料";
        }
        #endregion

        #endregion

        #region 事件

        /// <summary>
        /// 定位销售订单分录位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtFBillNo.Text.Trim() != string.Empty && dgv1 != null && dgv1.Rows.Count > 0)
                {
                    for (int i = 0; i < dgv1.Rows.Count; i++)
                    {
                        if (dgv1.Rows[i].Cells[2].Value.ToString().Contains(txtFBillNo.Text.Trim().ToUpper()))
                        {
                            dgv1.ClearSelection();
                            dgv1.Rows[i].Selected = true;
                            dgv1.CurrentCell = dgv1.Rows[i].Cells[2];

                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 双击展开物料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            if (dgv1.DataSource == null || dgv1.Rows.Count == 0 || chbAll.Checked)
                return;

            if (dgv1.CurrentRow.DefaultCellStyle.BackColor != Color.Orange)//排除其他分录
            {
                dgv2.DataSource = null;
                return;
            }
            else//只添加运算缺料分录
            {
                dgv2.DataSource = null;
                dgv2.DataSource = GetTableByFEntryId(int.Parse(_dtRunResult.Rows[dgv1.CurrentCell.RowIndex]["FENTRYID"].ToString()));

                if (dgv2.Rows.Count > 0)
                {
                    dgv2.Columns[34].Visible = false;//可用库存
                    dgv2.Columns[35].Visible = false;//FID
                    dgv2.Columns[36].Visible = false;//FENTRYID
                    dgv2.Columns[37].Visible = false;//SALORG
                    dgv2.Columns[38].Visible = false;//FMATERIALID
                }
            }
        }

        #region 根据FEntryId获取明细信息
        /// <summary>
        /// 根据分录ID获取该分录ID展开的明细Dable
        /// </summary>
        /// <param name="pFEntryId">订单分录ID</param>
        /// <returns></returns>
        private DataTable GetTableByFEntryId(int pFEntryId)
        {
            if (_dtDtlResult == null || _dtDtlResult.Rows.Count == 0)
                return new DataTable();

            DataTable dtReturn = _dtDtlResult.Clone();

            for (int i = 0; i < _dtDtlResult.Rows.Count; i++)
            {
                if (int.Parse(_dtDtlResult.Rows[i]["FENTRYID"].ToString()) == pFEntryId)
                    dtReturn.ImportRow(_dtDtlResult.Rows[i]);
            }

            return dtReturn;
        }
        #endregion

        /// <summary>
        /// 全部展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv1.DataSource == null || dgv1.Rows.Count == 0)
                return;

            dgv2.DataSource = null;

            if (chbAll.Checked && _dtDtlResult.Rows.Count > 0)
            {
                dgv2.DataSource = _dtDtlResult;

                dgv2.Columns[34].Visible = false;//可用库存
                dgv2.Columns[35].Visible = false;//FID
                dgv2.Columns[36].Visible = false;//FENTRYID
                dgv2.Columns[37].Visible = false;//SALORG
                dgv2.Columns[38].Visible = false;//FMATERIALID

                btnExport.Enabled = true;
            }
            else
            {
                btnExport.Enabled = false;
            }
        }

        /// <summary>
        /// 汇总运算结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSummary_Click(object sender, EventArgs e)
        {
            if (dgv2 == null || dgv2.Rows.Count == 0)
                return;

            frmOrderSummary os = new frmOrderSummary(_dtDtlResult, _ListRunEntryId);
            os.ShowDialog();
        }

        /// <summary>
        /// 显示dgv1行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /// <summary>
        /// 显示dgv2行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /// <summary>
        /// 报表 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            _FuncID = "SaveOrderRun";
            _bgWorker.RunWorkerAsync();
            _frmNotify.ShowDialog();
        }
        #endregion

        #region 保存运算结果
        /// <summary>
        /// 保存运算结果
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private int SaveOrderRun(DoWorkEventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            int iSEQ = 0;
            string strSQL = string.Empty, YSBILLNO = "YS" + dtNow.ToString("yyyyMMddHHmmssfff");

            for (int i = 0; i < _dtRunResult.Rows.Count; i++)
            {
                if (_ListRunEntryId.Contains(int.Parse(_dtRunResult.Rows[i]["FENTRYID"].ToString())))
                {
                    iSEQ++;
                    strSQL = "INSERT INTO DM_LOG_ORDERRUN(YSBILLNO,FID,FENTRYID,FBILLNO,FBILLTYPE,FMTLNUMBER,FMTLNAME,FCUSTNAME,F_PAEZ_SUBMITUSERID,FUNIT,FQTY,FLOCKQTY,FDEMANDQTY,BOM,FLACKLEVEL,ISLACK,FSEQ) VALUES('" + YSBILLNO + "'," + _dtRunResult.Rows[i]["FID"].ToString() + "," + _dtRunResult.Rows[i]["FENTRYID"].ToString() + ",'" + _dtRunResult.Rows[i]["单据编号"].ToString() + "','" + _dtRunResult.Rows[i]["单据类型"].ToString() + "','" + _dtRunResult.Rows[i]["物料编码"].ToString() + "','" + _dtRunResult.Rows[i]["物料名称"].ToString() + "','" + _dtRunResult.Rows[i]["客户名称"].ToString() + "','" + _dtRunResult.Rows[i]["提交人"].ToString() + "','" + _dtRunResult.Rows[i]["单位"].ToString() + "'," + _dtRunResult.Rows[i]["订单数量"].ToString() + "," + _dtRunResult.Rows[i]["锁库数量"].ToString() + "," + _dtRunResult.Rows[i]["订单需求"].ToString() + ",'" + _dtRunResult.Rows[i]["BOM版本"].ToString() + "','" + _dtRunResult.Rows[i]["欠料等级"].ToString() + "'," + (_dtRunResult.Rows[i]["是否欠料"].ToString() == "是" ? "1" : "0") + "," + iSEQ + ")";

                    SQL.ORAHelper.ExecuteNonQuery(strSQL);

                    //保存子项物料运算结果
                    SaveDetail(_dtRunResult.Rows[i]["FENTRYID"].ToString());

                    //反写运算次数、整单是否欠料和欠料等级
                    SalOrder.UpdateOrderFields(int.Parse(_dtRunResult.Rows[i]["FENTRYID"].ToString()), _dtRunResult.Rows[i]["欠料等级"].ToString());
                }

                //进度条
                if (_bgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return -1;
                }
                else
                {
                    _bgWorker.ReportProgress((i + 1) * 100 / (_dtRunResult.Rows.Count));
                    Thread.Sleep(1);
                }
            }

            //反写无需生产的销售订单
            for (int i = 0; i < _ListNotRunEntryId.Count; i++)
            {
                SalOrder.UpdateOrderFields(_ListNotRunEntryId[i], "无需生产");
            }

            MessageBox.Show("已经保存");
            return 0;
        }
        #endregion

        #region 保存子项物料运算结果
        /// <summary>
        /// 保存子项物料运算结果
        /// </summary>
        /// <param name="pFentryid"></param>
        /// <param name="pPID"></param>
        private void SaveDetail(string pFentryid)
        {
            int iPID = SalOrder.GetMaxID("LOG_ORDERRUN", 1);
            int iSEQ = 0;
            string strSQL = "INSERT ALL ";

            for (int i = 0; i < _dtDtlResult.Rows.Count; i++)
            {
                if (_dtDtlResult.Rows[i]["FENTRYID"].ToString() == pFentryid)
                {
                    iSEQ++;
                    strSQL += " INTO DM_LOG_ORDERRUNSUB(PID,FID,FENTRYID,FPMTLNUMBER,FPMTLNAME,FMTLNUMBER,FMTLNAME,FNUIT,BOM,FQTY,FLOCKQTY,FSUBQTY,FSTOCKQTY,FSTOCKAVBQTY,FSTOCKDEMANDQTY,FNETDEMANDQTY,FPICQTY,FMINSTOCK,FMAXSTOCK,FSAFESTOCK,FSTOCKDAYS,FORDERQTY,FOCCUPYQTY,FOCCUPYSUMQTY,FLACKQTY,FLACKLEVEL,FSEQ) VALUES(" + iPID + "," + _dtDtlResult.Rows[i]["FID"].ToString() + "," + _dtDtlResult.Rows[i]["FENTRYID"].ToString() + ",'" + _dtDtlResult.Rows[i]["父项物料"].ToString() + "','" + _dtDtlResult.Rows[i]["父项名称"].ToString() + "','" + _dtDtlResult.Rows[i]["物料编码"].ToString() + "','" + _dtDtlResult.Rows[i]["物料名称"].ToString() + "','" + _dtDtlResult.Rows[i]["单位"].ToString() + "','" + _dtDtlResult.Rows[i]["BOM"].ToString() + "'," + _dtDtlResult.Rows[i]["订单数量"].ToString() + "," + _dtDtlResult.Rows[i]["锁库数量"].ToString() + "," + _dtDtlResult.Rows[i]["子项需求"].ToString() + "," + _dtDtlResult.Rows[i]["库存数量"].ToString() + "," + _dtDtlResult.Rows[i]["库存可用数量"].ToString() + "," + _dtDtlResult.Rows[i]["库存需求"].ToString() + "," + _dtDtlResult.Rows[i]["净需求"].ToString() + "," + _dtDtlResult.Rows[i]["领料数量"].ToString() + "," + _dtDtlResult.Rows[i]["最小库存"].ToString() + "," + _dtDtlResult.Rows[i]["最大库存"].ToString() + "," + _dtDtlResult.Rows[i]["安全库存"].ToString() + "," + _dtDtlResult.Rows[i]["库存可用天数"].ToString() + "," + _dtDtlResult.Rows[i]["下单点"].ToString() + "," + _dtDtlResult.Rows[i]["本次占用数量"].ToString() + "," + _dtDtlResult.Rows[i]["累计占用数量"].ToString() + "," + _dtDtlResult.Rows[i]["欠料数量"].ToString() + ",'" + _dtDtlResult.Rows[i]["欠料等级"].ToString() + "'," + iSEQ + ")";
                }
            }
            SQL.ORAHelper.ExecuteNonQuery(strSQL + " SELECT * FROM DUAL;");

            ////添加预留关系 --不修改库存可用量
            //if (decimal.Parse(FOCCUPYQTY) > 0)
            //{
            //    AddReserveLink(dtDtlResult.Rows[i], decimal.Parse(FOCCUPYQTY));
            //}
        }
        #endregion

        #region 添加预留关系-暂未使用
        /// <summary>
        /// 添加预留关系
        /// </summary>
        /// <param name="pDR"></param>
        /// <param name="pQTY"></param>
        /// <returns></returns>
        private string AddReserveLink(DataRow pDR, decimal pQTY)
        {
            DataTable dt;
            decimal FQTY, Fremain = 1;//扣除数量、剩余未扣除数量
            string strRetrunValue = string.Empty;
            K3CloudApiClient client = new K3CloudApiClient(GlobalParameter.K3Inf.C_ERPADDRESS);
            var bLogin = client.Login(GlobalParameter.K3Inf.C_ZTID, "damo", "111111", 2052);

            if (bLogin)
            {
                JObject jsonRoot = new JObject();
                jsonRoot.Add("Creator", "");
                jsonRoot.Add("NeedUpDateFields", new JArray(""));
                jsonRoot.Add("NeedReturnFields", new JArray(""));
                jsonRoot.Add("IsDeleteEntry", "True");
                jsonRoot.Add("IsVerifyBaseDataField", "false");
                jsonRoot.Add("SubSystemId", "");

                JObject model = new JObject();
                jsonRoot.Add("Model", model);
                model.Add("FID", 0);

                model.Add("FPARENTBILLNO", pDR["订单编号"].ToString());
                model.Add("FSRCBILLNO", pDR["订单编号"].ToString());
                model.Add("FDEMANDBILLNO", pDR["订单编号"].ToString());
                model.Add("FBASEDEMANDQTY", pDR["订单数量"].ToString());
                model.Add("FDosageType", "2");
                model.Add("FRESERVETYPE", "3");
                model.Add("FSRCENTRYID", pDR["FENTRYID"].ToString());
                model.Add("FSRCINTERID", pDR["FID"].ToString());
                model.Add("FDemandENTRYID", pDR["FENTRYID"].ToString());
                model.Add("FDEMANDINTERID", pDR["FID"].ToString());

                model.Add("FSupRate", 100.0);
                model.Add("FScrapRate", 0.0);
                model.Add("FBaseFixScrapQty", 0.0);
                model.Add("FBASENUMERATOR", 1);
                model.Add("FBASEDENOMINATOR", 1);

                model.Add("FRemarks", "");

                JObject basedata = new JObject();
                basedata.Add("FNumber", pDR["单位"].ToString());
                model.Add("FBASEDEMANDUNITID", basedata);

                basedata = new JObject();
                basedata.Add("FID", "SAL_SaleOrder");
                model.Add("FSRCFORMID", basedata);

                basedata = new JObject();
                basedata.Add("FID", "SAL_SaleOrder");
                model.Add("FDEMANDFORMID", basedata);

                basedata = new JObject();
                basedata.Add("FNumber", pDR["物料编码"].ToString());
                model.Add("FMATERIALID", basedata);

                model.Add("FDate", DateTime.Today);

                //--Detail
                dt = SalOrder.GetInventoryInfByMaterialId(pDR["FMATERIALID"].ToString());
                if (dt == null || dt.Rows.Count == 0)
                    return "查询即时库存失败";

                JArray entryRows = new JArray();
                string entityKey = "FEntity";
                model.Add(entityKey, entryRows);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Fremain <= 0)
                        break;//已经全部扣除占用数量
                    if (decimal.Parse(dt.Rows[i]["FAVBQTY"].ToString()) <= 0)
                        continue;//没有库存可扣除

                    FQTY = decimal.Parse(dt.Rows[i]["FAVBQTY"].ToString()) > pQTY ? pQTY : decimal.Parse(dt.Rows[i]["FAVBQTY"].ToString());
                    Fremain = pQTY - decimal.Parse(dt.Rows[i]["FAVBQTY"].ToString());

                    JObject entryRow = new JObject();
                    entryRows.Add(entryRow);

                    entryRow.Add("FEntryID", 0);

                    basedata = new JObject();
                    basedata.Add("FID", "STK_Inventory");
                    entryRow.Add("FSUPPLYFORMID", basedata);

                    entryRow.Add("FSUPPLYINTERID", dt.Rows[i]["FINID"].ToString());
                    entryRow.Add("FBASESUPPLYQTY", FQTY);
                    entryRow.Add("FLINKTYPE", "4");
                    entryRow.Add("FSupplyRemarks", "");

                    basedata = new JObject();
                    basedata.Add("FNumber", pDR["物料编码"].ToString());
                    entryRow.Add("FSUPPLYMATERIALID", basedata);

                    basedata = new JObject();
                    basedata.Add("FNumber", pDR["SALORG"].ToString());
                    entryRow.Add("FSUPPLYORGID", basedata);

                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["STOCK"].ToString());
                    entryRow.Add("FSUPPLYSTOCKID", basedata);

                    basedata = new JObject();
                    basedata.Add("FNumber", pDR["单位"].ToString());
                    entryRow.Add("FBASESUPPLYUNITID", basedata);
                }

                // 调用Web API接口服务，保存采购订单
                strRetrunValue = client.Execute<string>("Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save", new object[] { "PLN_RESERVELINK", jsonRoot.ToString() });
                JObject jo = JObject.Parse(strRetrunValue);

                if (!jo["Result"]["ResponseStatus"]["IsSuccess"].Value<bool>())
                {
                    strRetrunValue = string.Empty;
                    for (int i = 0; i < ((IList)jo["Result"]["ResponseStatus"]["Errors"]).Count; i++)
                        strRetrunValue += jo["Result"]["ResponseStatus"]["Errors"][i]["FieldName"].Value<string>() + "\r\n";//保存不成功返错误信息
                }
                else
                {
                    strRetrunValue = "FID:" + jo["Result"]["Id"].Value<string>();//保存成功返回单据编号FBILLNO
                }
            }

            return strRetrunValue;
        }
        #endregion

        #region 导出报表
        /// <summary>
        /// 导出报表
        /// </summary>
        private void Export()
        {
            if (_dtDtlResult == null || _dtDtlResult.Rows.Count == 0)
            {
                MessageBox.Show("没有数据信息");
                return;
            }
            //实例化OfficeExcel对象
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)//服务器上缺少Excel组件，需要安装Office软件
            {
                MessageBox.Show("请先安装Microsoft Office软件");
                return;
            }
            //定义Excel对象
            Excel.Workbook xlBook = xlApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = xlBook.Worksheets[1] as Excel.Worksheet;
            Excel.Range range, rTitle, rcTitle;

            //设置对象不可见
            xlApp.Visible = false;
            xlApp.DisplayAlerts = false;
            //变量
            int iRows = _dtDtlResult.Rows.Count;//行数
            int iColumns = 27;//列数
            int colIndex = 0;//序号
            //设置表头样式
            worksheet.Cells[1, 1] = "半成品运算结果";
            rTitle = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, iColumns]];
            rTitle.Merge();
            rTitle.Interior.Color = Color.FromArgb(26, 180, 240);
            rTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rTitle.RowHeight = "32";
            rTitle.Font.Bold = true;
            rTitle.Font.Size = 24;
            rTitle.Font.Name = "宋体";
            //设置列名样式
            rcTitle = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, iColumns]];
            rcTitle.Interior.Color = Color.FromArgb(135, 165, 175);
            rcTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rcTitle.RowHeight = "24";

            //文本格式
            (worksheet.Columns["B:B", Type.Missing] as Excel.Range).NumberFormatLocal = "@";
            (worksheet.Columns["D:D", Type.Missing] as Excel.Range).NumberFormatLocal = "@";
            //填充列名
            foreach (DataColumn col in _dtDtlResult.Columns)
            {
                colIndex++;
                if (colIndex <= iColumns)
                    worksheet.Cells[2, colIndex] = col.ColumnName;
            }
            //object
            object[,] objData = new object[iRows, iColumns];
            //循环添加objData
            for (int r = 0; r < iRows; r++)
            {
                for (int c = 0; c < iColumns; c++)
                {
                    objData[r, c] = _dtDtlResult.Rows[r][c];
                }
            }
            //填充数据
            range = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[iRows + 2, iColumns]];
            range.Value2 = objData;
            worksheet.Name = "MRP";

            //保存execel
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "选择保存路径";
            //设置保存文件的类型
            sfd.Filter = "Excel文件|*.xlsx|Excel2003文件|*.xls|所有文件|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                worksheet.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            xlApp.Visible = true;
        }
        #endregion
    }
}
using System;
using System.Data;
using System.Timers;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using ERPSupport.SQL.K3Cloud;
using ERPSupport.Model.Enum;
using ERPSupport.Model.Basic;
using ERPSupport.Model.Globa;
using ERPSupport.Model.K3Cloud;
using ERPSupport.SupForm.Common;
using ERPSupport.SupForm.UserCrtl;
using ERPSupport.SupForm.UserClass;

namespace ERPSupport.SupForm
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class frmMain : Form
    {
        #region Fields,Properties & Constructor

        /// <summary>
        /// 选择状态
        /// </summary>
        private bool bSelect;
        /// <summary>
        /// 导航当前点击行数
        /// </summary>
        private int iCurrentRow;
        /// <summary>
        /// 当前一级控件其包含二级控件数
        /// </summary>
        private int iChildCount;
        /// <summary>
        /// 方案名
        /// </summary>
        private string strFilterName;
        /// <summary>
        /// 业务标识
        /// </summary>
        private FormID eFormId;
        /// <summary>
        /// 单独进程执行操作的组件
        /// </summary>
        private BackgroundWorker bgWorker;
        /// <summary>
        /// 进度条窗体
        /// </summary>
        private frmProgress frmNotify;
        /// <summary>
        /// 定时参数
        /// </summary>
        private TimerParameter TimerPara;
        /// <summary>
        /// 订单实体List
        /// </summary>
        private IList lstOrder;
        /// <summary>
        /// 所有UC对象
        /// </summary>
        private List<string> listUC;
        /// <summary>
        /// 已经打开的UC对象
        /// </summary>
        private List<string> listOpenUC;
        /// <summary>
        /// 筛选条件
        /// </summary>
        private List<Filter> lstFilter;
        /// <summary>
        /// 勾选状态
        /// </summary>
        private List<CheckStatus> lstCheckStatus;
        /// <summary>
        /// 导航一级控件
        /// </summary>
        private List<ucNaviga> lstP;
        /// <summary>
        /// 导航二级控件
        /// </summary>
        private List<ucNaviga> lstC;
        /// <summary>
        /// 查询结果
        /// </summary>
        private DataTable dtSearch;
        /// <summary>
        /// 计时器
        /// </summary>
        private System.Timers.Timer tExecute;
        /// <summary>
        /// 程序自动关闭计时器
        /// </summary>
        private System.Timers.Timer tClose;
        /// <summary>
        /// 窗口信息
        /// </summary>
        private WinMessager msg;

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            SetDefaultStatus();
            FillLogic();
            FillCondition();
            FillControlList();
            MenuSet();
        }
        #endregion

        #region 设置初始状态
        /// <summary>
        /// 设置初始状态
        /// </summary>
        private void SetDefaultStatus()
        {
            bSelect = false;
            iCurrentRow = 0;
            iChildCount = 0;
            strFilterName = string.Empty;
            eFormId = FormID.PRD_INSTOCK;
            dtSearch = new DataTable();
            TimerPara = new TimerParameter(0, 20, 0, true, false, "NULL");
            CheckForIllegalCrossThreadCalls = false;//解决多线程调用控件问题
            //-----
            bgWorker = new BackgroundWorker();
            frmNotify = new frmProgress();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += new DoWorkEventHandler(DoWork);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);
            //-----
            DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
            newColumn.HeaderText = "选择";
            newColumn.Width = 35;
            dgv1.Columns.Add(newColumn);
            //-----
            listUC = new List<string>();
            listOpenUC = new List<string>();
            //-----
            msg = new WinMessager();
            Application.AddMessageFilter(msg);
            tClose = new System.Timers.Timer();
            tClose.Interval = 1000 * 60 * 30;//每30分钟执行一次,也就是30*2分钟没操作就自动关闭程序
            tClose.Elapsed += new ElapsedEventHandler(tClose_Elapsed);
            tClose.Start();

            //配置
            listUC.Add("ucStockEdit");
            listUC.Add("ucPickMTLDepartment");
            listUC.Add("ucExpressCompany");
            listUC.Add("ucBillModify");
            listUC.Add("ucLockStock");
            listUC.Add("ucUTMTLNumber");
            //报表
            listUC.Add("ucReportBom");
            listUC.Add("ucReportMtl203");
            //日志
            listUC.Add("ucERPRecord");
            listUC.Add("ucPDARecord");
            listUC.Add("ucOrderRecord");
            //系统管理
            listUC.Add("ucUserAcc");
            listUC.Add("ucUser");
            //-----
            Text = "ERP辅助系统" + " - " + GlobalParameter.K3Inf.UserName;
        }
        #endregion

        #region 填充逻辑关系下拉框
        /// <summary>
        /// 填充逻辑关系下拉框
        /// </summary>
        private void FillLogic()
        {
            DataTable dt = null;
            DataRow dr = null;

            //cbxLogic
            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            dr = dt.NewRow();
            dr["FName"] = "";
            dr["FValue"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "等于";
            dr["FValue"] = "=";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "不等于";
            dr["FValue"] = "<>";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "大于";
            dr["FValue"] = ">";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "大于等于";
            dr["FValue"] = ">=";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "小于";
            dr["FValue"] = "<";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "小于等于";
            dr["FValue"] = "<=";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "包含";
            dr["FValue"] = "LIKE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "左包含";
            dr["FValue"] = "LIKE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "右包含";
            dr["FValue"] = "LIKE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["FName"] = "不包含";
            dr["FValue"] = "NOT LIKE";
            dt.Rows.Add(dr);

            cbxLogic.DataSource = dt;
            cbxLogic.DisplayMember = "FName";
            cbxLogic.ValueMember = "FValue";
            cbxLogic.SelectedIndex = 4;
        }
        #endregion

        #region 填充筛选条件下拉框
        /// <summary>
        /// 填充筛选条件下拉框
        /// </summary>
        private void FillCondition()
        {
            DataTable dt = null;
            DataRow dr = null;

            dt = new DataTable();
            dt.Columns.Add("FName");
            dt.Columns.Add("FValue");

            if (eFormId == FormID.PRD_INSTOCK)
            {
                dr = dt.NewRow();
                dr["FName"] = "";
                dr["FValue"] = "";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["FName"] = "日期";
                dr["FValue"] = "A.FDATE";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["FName"] = "单据编号";
                dr["FValue"] = "A.FBILLNO";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["FName"] = "物料编码";
                dr["FValue"] = "MTL.FNUMBER";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["FName"] = "物料名称";
                dr["FValue"] = "MTLL.FNAME";
                dt.Rows.Add(dr);
            }
            else if (eFormId == FormID.PRD_PPBOM)
            {
                dr = dt.NewRow();
                dr["FName"] = "";
                dr["FValue"] = "";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["FName"] = "计划开工日期";
                dr["FValue"] = "BE.FPLANSTARTDATE";
                dt.Rows.Add(dr);
            }
            else if (eFormId == FormID.SAL_SALEORDER || eFormId == FormID.SAL_SALEORDERRUN)
            {
                dr = dt.NewRow();
                dr["FName"] = "";
                dr["FValue"] = "";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["FName"] = "审核日期";
                dr["FValue"] = "A.FAPPROVEDATE";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["FName"] = "日期";
                dr["FValue"] = "A.FDATE";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["FName"] = "单据编号";
                dr["FValue"] = "A.FBILLNO";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["FName"] = "客户";
                dr["FValue"] = "CURL.FName";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["FName"] = "物料编码";
                dr["FValue"] = "MTL.FNumber";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["FName"] = "物料名称";
                dr["FValue"] = "MTLL.FName";
                dt.Rows.Add(dr);
            }

            cbxCondition.DataSource = dt;
            cbxCondition.DisplayMember = "FName";
            cbxCondition.ValueMember = "FValue";
            cbxCondition.SelectedIndex = 1;
        }
        #endregion

        #region 获取一、二级控件List并填充一级控件到窗体左边导航栏
        /// <summary>
        /// 获取一、二级控件List并填充一级控件到窗体左边导航栏
        /// </summary>
        private void FillControlList()
        {
            string sRIDs, sMIDs, sFunctionIds;
            DataTable dtControls = CommonFunction.GetNavigation(out sRIDs, out sMIDs, out sFunctionIds);
            if (dtControls == null)
                return;

            new GlobalRights(sRIDs.Trim(), sMIDs.Trim(), sFunctionIds.Trim());

            ucNaviga uc;
            lstP = new List<ucNaviga>();
            lstC = new List<ucNaviga>();

            for (int i = 0; i < dtControls.Rows.Count; i++)
            {
                if (int.Parse(dtControls.Rows[i]["LV"].ToString()) == 1)
                {
                    uc = new ucNaviga();
                    uc.Name = "UCP" + dtControls.Rows[i]["NODEID"].ToString();
                    uc.pBtnClick += new EventHandler(FillNavi);

                    ((Button)uc.Controls.Find("button1", true)[0]).Text = dtControls.Rows[i]["NODENAME"].ToString();
                    ((Button)uc.Controls.Find("button1", true)[0]).Font = new Font(((Button)uc.Controls.Find("button1", true)[0]).Font.FontFamily, 12, ((Button)uc.Controls.Find("button1", true)[0]).Font.Style);

                    lstP.Add(uc);
                }
                else if (int.Parse(dtControls.Rows[i]["LV"].ToString()) == 2)
                {
                    uc = new ucNaviga();
                    uc.Name = "UCC" + dtControls.Rows[i]["NODEID"].ToString();
                    uc.pBtnClick += new EventHandler(FillNavi);

                    ((Button)uc.Controls.Find("button1", true)[0]).Text = "·" + dtControls.Rows[i]["NODENAME"].ToString() + "·";

                    lstC.Add(uc);
                }
            }

            //填装一级控件到导航栏
            int itmp = 0;
            foreach (ucNaviga ucp in lstP)
            {
                ucp.Location = new Point(0, 30 * itmp);
                sc1.Panel1.Controls.Add(ucp);
                itmp++;
            }
        }
        #endregion

        #region 菜单权限
        /// <summary>
        /// 菜单权限
        /// </summary>
        private void MenuSet()
        {
            //工具
            if (GlobalParameter.K3Inf.UserName != "Administrator")
            {
                foreach (ToolStripItem ct in ((ToolStripMenuItem)((MenuStrip)Controls[1]).Items[1]).DropDownItems)
                {
                    if (ct.Name == "tsmiTool_Occupy" && !GlobalRights.FunctionIds.Contains("tsmiTool_Occupy"))
                        ct.Enabled = false;
                    if (ct.Name == "tsmiTool_Timer" && !GlobalRights.FunctionIds.Contains("tsmiTool_Timer"))
                        ct.Enabled = false;
                }
            }
        }
        #endregion

        #region 委托导航栏点击事件
        /// <summary>
        /// 委托导航栏点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillNavi(object sender, EventArgs e)
        {
            ucNaviga uc = (ucNaviga)(((Button)sender).Parent.Parent);

            if (uc.Conr == "P")//当点击的是一级控件时，给当前点击的一级控件填装二级控件
            {
                foreach (ucNaviga ucp in lstP)//移除所有子控件
                {
                    List<Control> ct = new List<Control>();

                    foreach (Control ctp in ucp.Controls)
                        ct.Add(ctp);

                    for (int i = 0; i < ct.Count; i++)
                    {
                        if (ct[i].GetType().Name == "UserControl1")
                            ucp.Controls.Remove(ct[i]);
                    }
                }

                int iRow = int.Parse(uc.Name.Substring(3, 1));//所在的行数
                iCurrentRow = iRow;

                //下级分类的个数
                iChildCount = CommonFunction.ChildNumber(uc.Name.Substring(3, 1));

                //改变控件大小和位置
                ResetUCSize(lstP, iRow, iChildCount);

                //填装二级控件
                AddChild(uc, lstC, iRow, iChildCount);

                Text = "ERP辅助系统" + "\\" + ((Button)uc.Controls.Find("button1", true)[0]).Text + " - " + GlobalParameter.K3Inf.UserName;
            }
            else if (uc.Conr == "C")//当点击的是二级控件时
            {
                switch (uc.ParentId)
                {
                    case 1:
                        {
                            ((Panel)(sc1.Panel2.Controls.Find("panel1", false)[0])).Visible = true;//显示主窗体Panel
                            HideUC(listOpenUC, "", true);//隐藏所有用户控件

                            //if (uc.NodeId == 101)
                            //    eFormId = FormID.PRD_INSTOCK;
                            //else if (uc.NodeId == 102)
                            //    eFormId = FormID.PRD_PPBOM;
                            //else if (uc.NodeId == 103)
                            //    eFormId = FormID.SAL_SALEORDER;
                            //else if (uc.NodeId == 104)
                            //    eFormId = FormID.SAL_SALEORDERRUN;

                            eFormId = (FormID)(uc.NodeId % 100);

                            FormIDChange();
                        }
                        break;
                    case 2:
                        {
                            ((Panel)(sc1.Panel2.Controls.Find("panel1", false)[0])).Visible = false;

                            if (uc.NodeId == 201)
                            {
                                if (!HideUC(listOpenUC, "StockSet", false))
                                {
                                    ucStockEdit UserCtrl = new ucStockEdit();
                                    UserCtrl.Name = "StockSet";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 202)
                            {
                                if (!HideUC(listOpenUC, "PickMTLDepartment", false))
                                {
                                    ucPickMTLDepartment UserCtrl = new ucPickMTLDepartment();
                                    UserCtrl.Name = "PickMTLDepartment";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 203)
                            {
                                if (!HideUC(listOpenUC, "ExpressCompany", false))
                                {
                                    ucExpressCompany UserCtrl = new ucExpressCompany();
                                    UserCtrl.Name = "ExpressCompany";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 204)
                            {
                                if (!HideUC(listOpenUC, "BillModify", false))
                                {
                                    ucBillModify UserCtrl = new ucBillModify();
                                    UserCtrl.Name = "BillModify";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 205)
                            {
                                if (!HideUC(listOpenUC, "LockStock1", false))
                                {
                                    ucLockStock UserCtrl = new ucLockStock("LOCKSTOCK");
                                    UserCtrl.Name = "LockStock1";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }

                            else if (uc.NodeId == 206)
                            {
                                if (!HideUC(listOpenUC, "LockStock2", false))
                                {
                                    ucLockStock UserCtrl = new ucLockStock("RUNSTOCK");
                                    UserCtrl.Name = "LockStock2";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 207)
                            {
                                if (!HideUC(listOpenUC, "UTMTLNumber", false))
                                {
                                    ucUTMTLNumber UserCtrl = new ucUTMTLNumber();
                                    UserCtrl.Name = "UTMTLNumber";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                        }
                        break;
                    case 3:
                        {
                            ((Panel)(sc1.Panel2.Controls.Find("panel1", false)[0])).Visible = false;

                            if (uc.NodeId == 301)
                            {
                                if (!HideUC(listOpenUC, "ReportMtl203", false))
                                {
                                    ucReportMtl203 UserCtrl = new ucReportMtl203();
                                    UserCtrl.Name = "ReportMtl203";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 302)
                            {
                                if (!HideUC(listOpenUC, "ReportBom", false))
                                {
                                    ucReportBom UserCtrl = new ucReportBom();
                                    UserCtrl.Name = "ReportBom";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            ((Panel)(sc1.Panel2.Controls.Find("panel1", false)[0])).Visible = false;

                            if (uc.NodeId == 401)
                            {
                                if (!HideUC(listOpenUC, "ERPRecord1", false))
                                {
                                    ucERPRecord UserCtrl = new ucERPRecord("ASSISTANT");
                                    UserCtrl.Name = "ERPRecord1";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 402)
                            {
                                if (!HideUC(listOpenUC, "ERPRecord2", false))
                                {
                                    ucERPRecord UserCtrl = new ucERPRecord("K3CLOUD");
                                    UserCtrl.Name = "ERPRecord2";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 403)
                            {
                                if (!HideUC(listOpenUC, "PDARecord", false))
                                {
                                    ucPDARecord UserCtrl = new ucPDARecord();
                                    UserCtrl.Name = "PDARecord";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 404)
                            {
                                if (!HideUC(listOpenUC, "OrderRecord", false))
                                {
                                    ucOrderRecord UserCtrl = new ucOrderRecord();
                                    UserCtrl.Name = "OrderRecord";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                        }
                        break;
                    case 5:
                        {
                            ((Panel)(sc1.Panel2.Controls.Find("panel1", false)[0])).Visible = false;

                            if (uc.NodeId == 501)
                            {
                                if (!HideUC(listOpenUC, "User", false))
                                {
                                    ucUser UserCtrl = new ucUser();
                                    UserCtrl.Name = "User";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 502)
                            {
                                if (!HideUC(listOpenUC, "UserAcc", false))
                                {
                                    ucUserAcc UserCtrl = new ucUserAcc();
                                    UserCtrl.Name = "UserAcc";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    listOpenUC.Add(UserCtrl.Name);
                                }
                            }
                        }
                        break;
                    default:
                        {
                            RemoveChildControls(sc1.Panel2.Controls, listUC);
                        }
                        break;
                }

                ChangeCurrentControlStyle(uc, lstC);
                Text = "ERP辅助系统" + "\\" + ((Button)uc.Parent.Controls.Find("button1", true)[0]).Text + "\\" + ((Button)uc.Controls.Find("button1", true)[0]).Text.Replace("·", "") + " - " + GlobalParameter.K3Inf.UserName;
            }
        }
        #endregion

        #region 改变FormId
        /// <summary>
        /// 改变FormId
        /// </summary>
        private void FormIDChange()
        {
            FillCondition();

            if (eFormId == FormID.PRD_INSTOCK)
            {
                btnCommit.Text = "生成领料单";
                btnCommit.Enabled = true;

                btnCheck.Visible = false;
                btnSearch.Text = "查找";
                btnSearch.Enabled = true;
                btnSelect.Enabled = true;
                btnFilter.Visible = false;
                cbxLogic.Enabled = true;
                cbxCondition.Enabled = true;
                btnUnLock.Visible = false;

                cbxCondition.SelectedIndex = 1;
                cbxLogic.SelectedIndex = 4;
                dtpDate.Value = DateTime.Now;
            }
            else if (eFormId == FormID.PRD_PPBOM)
            {
                btnCommit.Text = "生成调拨单";
                btnCommit.Enabled = true;

                btnCheck.Visible = true;
                btnSearch.Text = "汇总";
                btnSearch.Enabled = false;
                btnSelect.Enabled = false;
                btnFilter.Visible = false;
                cbxLogic.Enabled = false;
                cbxCondition.Enabled = false;
                btnUnLock.Visible = false;

                cbxCondition.SelectedIndex = 1;
                cbxLogic.SelectedIndex = 1;
                dtpDate.Value = DateTime.Now;
            }
            else if (eFormId == FormID.SAL_SALEORDER)
            {
                btnCommit.Text = "锁库";
                btnCommit.Enabled = true;

                btnCheck.Visible = false;
                btnSearch.Text = "查找";
                btnSearch.Enabled = true;
                btnSelect.Enabled = true;
                btnFilter.Visible = true;
                cbxLogic.Enabled = true;
                cbxCondition.Enabled = true;
                btnUnLock.Visible = true;

                cbxCondition.SelectedIndex = 1;
                cbxLogic.SelectedIndex = 4;
                dtpDate.Value = DateTime.Now.AddDays(-1);
            }
            else if (eFormId == FormID.SAL_SALEORDERRUN)
            {
                btnCommit.Text = "订单运算";
                btnCommit.Enabled = true;

                btnCheck.Visible = false;
                btnSearch.Text = "查找";
                btnSearch.Enabled = true;
                btnSelect.Enabled = true;
                btnFilter.Visible = true;
                cbxLogic.Enabled = true;
                cbxCondition.Enabled = true;
                btnUnLock.Visible = false;

                cbxCondition.SelectedIndex = 1;
                cbxLogic.SelectedIndex = 4;
                dtpDate.Value = DateTime.Now.AddDays(-1);
            }

            txtCondition.Text = "";
            lstFilter = new List<Filter>();
            dgv1.DataSource = null;
        }
        #endregion

        #region 查找按钮
        /// <summary>
        /// 查找按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSourceBinding();

            //隐藏订单内码
            if (dgv1.Rows.Count > 0)
            {
                if (eFormId == FormID.SAL_SALEORDER)
                    dgv1.Columns[18].Visible = false;
                else if (eFormId == FormID.SAL_SALEORDERRUN)
                    dgv1.Columns[19].Visible = false;

                //不允许重新排列
                for (int i = 0; i < dgv1.Columns.Count; i++)
                {
                    dgv1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            bSelect = false;
            btnSelect.Text = "勾选";
        }
        #endregion

        #region 绑定数据源
        /// <summary>
        /// 绑定数据源
        /// </summary>
        private void DataSourceBinding()
        {
            dgv1.DataSource = null;
            dtSearch = SearchData();

            BindingSource bs = new BindingSource();
            bs.DataSource = dtSearch;

            //设置列头过滤功能
            if (dtSearch != null && dtSearch.Rows.Count > 0)
            {
                foreach (DataColumn col in dtSearch.Columns)
                {
                    DataGridViewAutoFilterTextBoxColumn filterColumn = new DataGridViewAutoFilterTextBoxColumn();
                    filterColumn.DataPropertyName = col.ColumnName;
                    filterColumn.HeaderText = col.ColumnName;
                    filterColumn.Resizable = DataGridViewTriState.True;
                    dgv1.Columns.Add(filterColumn);
                }

                dgv1.DataSource = bs;
            }
        }
        #endregion

        #region 查询数据
        /// <summary>
        /// 获取单据列表
        /// </summary>
        /// <returns></returns>
        private DataTable SearchData()
        {
            string strFilter = SetFilter();

            if (!strFilter.Equals(string.Empty)) strFilter += " AND ";

            //根据lstFilter添加过滤条件
            if (lstFilter != null && lstFilter.Count > 0)
            {
                strFilter += "(" + GetFilter() + ") AND ";
            }

            return SalOrder.GetDataSource(eFormId, strFilter);
        }
        #endregion

        #region 过滤条件
        /// <summary>
        /// 添加过滤条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            frmFilter frm = new frmFilter(lstFilter, strFilterName);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                lstFilter = frm.lstFilter;
                strFilterName = frm.strFilterName;
            }
        }

        /// <summary>
        /// 获取过滤条件
        /// </summary>
        /// <returns></returns>
        private string GetFilter()
        {
            string retrunValue = string.Empty;
            string sLeft, sField, sCompare, sValue, sRight, sLogic;
            DataTable dtOrg = CommonFunction.GetOrganization(2);
            DataTable dtBillType = CommonFunction.GetBillType("SAL_SALEORDER");

            for (int i = 0; i < lstFilter.Count; i++)
            {
                sLeft = sField = sCompare = sValue = sRight = sLogic = string.Empty;

                if (lstFilter[i].Validation)
                {
                    //左括号
                    switch (lstFilter[i].ParenthesesLeft)
                    {
                        case 1:
                            sLeft = "(";
                            break;
                        case 2:
                            sLeft = "((";
                            break;
                        case 3:
                            sLeft = "(((";
                            break;
                    }
                    //字段、比较、值
                    switch (lstFilter[i].Field)
                    {
                        case 1:
                            sField = "TO_CHAR(A.FDATE,'yyyy-mm-dd')";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 2:
                            sField = "TO_CHAR(A.FAPPROVEDATE,'yyyy-mm-dd')";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 3:
                            sField = "TO_CHAR(AE.FPLANSTARTDATE,'yyyy-mm-dd')";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 4:
                            sField = "A.FBILLNO";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 5:
                            sField = "MTL.FNumber";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;

                        case 6:
                            sField = "MTLL.FNAME";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 7:
                            sField = "AR.FPURJOINQTY";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 8:
                            sField = "A.FSALEORGID";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 9:
                            sField = "A.F_PAEZ_FACTORGID";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 10:
                            sField = "AE.FSTOCKORGID";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        //
                        case 11:
                            sField = "A.FFULLLOCK";
                            sCompare = " = ";
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 12:
                            sField = "AE.FMRPTERMINATESTATUS";
                            sCompare = " = ";
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 13:
                            sField = "AE.FBATCHFLAG";
                            sCompare = " = ";
                            sValue = GetValue(lstFilter[i], dtOrg);
                            break;
                        case 14:
                            sField = "A.FBILLTYPEID";
                            sCompare = GetCompare(lstFilter[i]);
                            sValue = GetValue(lstFilter[i], dtBillType);
                            break;
                    }
                    //右括号
                    switch (lstFilter[i].ParenthesesRight)
                    {
                        case 1:
                            sRight = ")";
                            break;
                        case 2:
                            sRight = "))";
                            break;
                        case 3:
                            sRight = ")))";
                            break;
                    }
                    //逻辑
                    switch (lstFilter[i].Logic)
                    {
                        case 1:
                            sLogic = "AND";
                            break;
                        case 2:
                            sLogic = "OR";
                            break;
                        default:
                            sLogic = "AND";
                            break;
                    }
                }
                if (i == lstFilter.Count - 1)
                    retrunValue += " " + sLeft + " " + sField + " " + sCompare + " " + sValue + " " + sRight + " ";
                else
                    retrunValue += " " + sLeft + " " + sField + " " + sCompare + " " + sValue + " " + sRight + " " + sLogic + " ";
            }

            if (retrunValue.Trim().Equals(string.Empty))
                retrunValue = "1 = 1";

            return retrunValue;
        }

        /// <summary>
        /// 获取比较
        /// </summary>
        /// <param name="pFilter"></param>
        /// <returns></returns>
        private string GetCompare(Filter pFilter)
        {
            string retrunValue = string.Empty;

            switch (pFilter.Compare)
            {
                case 1:
                    retrunValue = " = ";
                    break;
                case 2:
                    retrunValue = " <> ";
                    break;
                case 3:
                    retrunValue = " > ";
                    break;
                case 4:
                    retrunValue = " >= ";
                    break;
                case 5:
                    retrunValue = " < ";
                    break;

                case 6:
                    retrunValue = " <= ";
                    break;
                case 7:
                case 8:
                case 9:
                    retrunValue = " LIKE ";
                    break;
                case 10:
                    retrunValue = " NOT LIKE ";
                    break;
                default:
                    retrunValue = " = ";
                    break;
            }

            return retrunValue;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="pFilter"></param>
        /// <param name="pDT"></param>
        /// <returns></returns>
        private string GetValue(Filter pFilter, DataTable pDT)
        {
            string retrunValue = string.Empty;

            switch (pFilter.Field)
            {
                case 1:
                case 2:
                case 3:
                    retrunValue = "'" + pFilter.FilterValue.FilterDateTime.ToString("yyyy-MM-dd") + "'";
                    break;
                case 4:
                case 5:
                case 6:
                    switch (pFilter.Compare)
                    {
                        case 7:
                        case 10:
                            retrunValue = "'%" + pFilter.FilterValue.FilterText + "%'";
                            break;
                        case 8:
                            retrunValue = "'" + pFilter.FilterValue.FilterText + "%'";
                            break;
                        case 9:
                            retrunValue = "'%" + pFilter.FilterValue.FilterText + "'";
                            break;
                        default:
                            retrunValue = "'" + pFilter.FilterValue.FilterText + "'";
                            break;
                    }
                    break;
                case 7:
                    retrunValue = pFilter.FilterValue.FilterText;
                    break;
                case 8:
                case 9:
                case 10:
                    retrunValue = pDT.Rows[pFilter.FilterValue.FilterIndex]["FValue"].ToString();
                    break;
                case 11:
                case 13:
                    retrunValue = pFilter.FilterValue.FilterCheck ? "'1'" : "'0'";
                    break;
                case 12:
                    retrunValue = pFilter.FilterValue.FilterCheck ? "'A'" : "'B'";
                    break;
                case 14://单据类型
                    retrunValue = "'" + pDT.Rows[pFilter.FilterValue.FilterIndex]["FValue"].ToString() + "'";
                    break;
            }

            return retrunValue;
        }

        /// <summary>
        /// 构造过滤条件
        /// </summary>
        /// <returns></returns>
        private string SetFilter()
        {
            string strFilter = string.Empty;

            if (cbxCondition.SelectedIndex == 0 || cbxLogic.SelectedIndex == 0)//不选择筛选条件
                return string.Empty;

            if (eFormId == FormID.PRD_INSTOCK || eFormId == FormID.PRD_PPBOM)//倒冲领料、调拨
            {
                if (cbxCondition.SelectedIndex == 1)//日期类型
                {
                    switch (cbxLogic.SelectedIndex)
                    {
                        case 1:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " = '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        case 2:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " <> '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        case 3:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " > '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        case 4:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " >= '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        case 5:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " < '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        case 6:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " <= '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        default:
                            strFilter = string.Empty;
                            break;
                    }
                }
                else//非日期类型
                {
                    if (txtCondition.Text.Trim().Length == 0)//没输入筛选条件
                        return string.Empty;

                    switch (cbxLogic.SelectedIndex)
                    {
                        case 1:
                            strFilter = cbxCondition.SelectedValue.ToString() + " = '" + txtCondition.Text.Trim() + "'";
                            break;
                        case 2:
                            strFilter = cbxCondition.SelectedValue.ToString() + " <> '" + txtCondition.Text.Trim() + "'";
                            break;
                        case 7:
                            strFilter = cbxCondition.SelectedValue.ToString() + " LIKE '%" + txtCondition.Text.Trim() + "%'";
                            break;
                        case 8:
                            strFilter = cbxCondition.SelectedValue.ToString() + " NOT LIKE '%" + txtCondition.Text.Trim() + "%'";
                            break;
                        case 9:
                            strFilter = cbxCondition.SelectedValue.ToString() + " LIKE '" + txtCondition.Text.Trim() + "%'";
                            break;
                        case 10:
                            strFilter = cbxCondition.SelectedValue.ToString() + " LIKE '%" + txtCondition.Text.Trim() + "'";
                            break;
                        default:
                            strFilter = string.Empty;
                            break;
                    }
                }
            }
            else if (eFormId == FormID.SAL_SALEORDER || eFormId == FormID.SAL_SALEORDERRUN)//销售订单锁库、运算
            {
                if (cbxCondition.SelectedIndex == 1 || cbxCondition.SelectedIndex == 2)//日期类型
                {
                    switch (cbxLogic.SelectedIndex)
                    {
                        case 1:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " = '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        case 2:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " <> '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        case 3:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " > '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        case 4:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " >= '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        case 5:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " < '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        case 6:
                            strFilter = "TO_CHAR(" + cbxCondition.SelectedValue.ToString() + ", 'yyyy-MM-dd')" + " <= '" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                            break;
                        default:
                            strFilter = string.Empty;
                            break;
                    }
                }
                else//非日期类型
                {
                    if (txtCondition.Text.Trim().Length == 0)//没输入筛选条件
                        return string.Empty;

                    switch (cbxLogic.SelectedIndex)
                    {
                        case 1:
                            strFilter = cbxCondition.SelectedValue.ToString() + " = '" + txtCondition.Text.Trim() + "'";
                            break;
                        case 2:
                            strFilter = cbxCondition.SelectedValue.ToString() + " <> '" + txtCondition.Text.Trim() + "'";
                            break;
                        case 7:
                            strFilter = cbxCondition.SelectedValue.ToString() + " LIKE '%" + txtCondition.Text.Trim() + "%'";
                            break;
                        case 8:
                            strFilter = cbxCondition.SelectedValue.ToString() + " LIKE '" + txtCondition.Text.Trim() + "%'";
                            break;
                        case 9:
                            strFilter = cbxCondition.SelectedValue.ToString() + " LIKE '%" + txtCondition.Text.Trim() + "'";
                            break;
                        case 10:
                            strFilter = cbxCondition.SelectedValue.ToString() + " NOT LIKE '%" + txtCondition.Text.Trim() + "%'";
                            break;
                        default:
                            strFilter = string.Empty;
                            break;
                    }
                }
            }
            return strFilter;
        }
        #endregion

        #region 选择/取消选择
        /// <summary>
        /// 选择/取消选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgv1.DataSource == null || dgv1.Rows.Count < 1)
                return;

            if (!bSelect)
            {
                foreach (DataGridViewRow dr in dgv1.SelectedRows)
                {
                    dr.Cells[0].Value = true;
                }

                bSelect = true;
                btnSelect.Text = "取消勾选";
            }
            else
            {
                foreach (DataGridViewRow dr in dgv1.SelectedRows)
                {
                    dr.Cells[0].Value = false;
                }

                bSelect = false;
                btnSelect.Text = "勾选";
            }
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
            //事件处理，指定处理函数
            if (eFormId == FormID.PRD_PPBOM)
                e.Result = Trans(sender, e);
            else if (eFormId == FormID.SAL_SALEORDER)
                e.Result = LockStock(sender, e);
        }

        /// <summary>
        /// 进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            frmNotify.SetNotifyInfo(e.ProgressPercentage, "执行进度:" + Convert.ToString(e.ProgressPercentage) + "%");
        }

        /// <summary>
        /// 事件处理完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            frmNotify.Close();
        }
        #endregion

        #region 提交操作
        /// <summary>
        /// 生成单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (!TimerPara.PauseStatus && eFormId != FormID.PRD_PPBOM)//排除调拨
            {
                MessageBox.Show("请先暂停定时器：工具->定时器");
                return;
            }

            if (dgv1.DataSource == null || dgv1.Rows.Count < 1)
            {
                MessageBox.Show("没有数据！");
                return;
            }

            DataTable dtResult;
            DataRow dr;

            dtResult = new DataTable();
            dtResult.Columns.Add("单号");

            if (eFormId == FormID.PRD_INSTOCK)//根据勾选生成倒冲领料单
            {
                //限制单一用户执行倒冲领料
                DataTable dtLock = CommonFunction.GetLockObjectInfo("PICKMTL");

                if (dtLock == null || dtLock.Rows.Count == 0)//新增记录
                {
                    CommonFunction.DM_LockObject_Add("PICKMTL", "FUNCTION", "限制只有一个用户操作倒冲领料", "PICKMTL");
                }
                else if (dtLock.Rows[0]["FSTATUS"].ToString() == "0")//没有占用锁库操作时，占用锁库操作
                {
                    CommonFunction.UpdateLockStatus(1, "PICKMTL");
                }
                else//存在操作记录
                {
                    MessageBox.Show("[" + dtLock.Rows[0]["FUSER"].ToString() + "]正在执行倒冲领料，请稍后再使用。");
                    return;
                }

                List<string> sList = new List<string>();//单据编号List

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    if (dgv1.Rows[i].Cells[0].Value != null && Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value))
                    {
                        if (sList.Contains(dgv1.Rows[i].Cells[3].Value.ToString()))//去除重复的入库单编号
                            continue;

                        sList.Add(dgv1.Rows[i].Cells[3].Value.ToString());

                        dr = dtResult.NewRow();
                        dr["单号"] = PrdPick.PickMtl(dgv1.Rows[i].Cells[3].Value.ToString());
                        dtResult.Rows.Add(dr);
                    }
                }

                if (dtResult.Rows.Count > 0)
                {
                    frmResult tmp = new frmResult(dtResult);
                    tmp.ShowDialog();
                    DataSourceBinding();
                }
                else
                {
                    MessageBox.Show("没有选择数据！");
                    return;
                }

                //解除倒冲领料占用
                CommonFunction.UpdateLockStatus(0, "PICKMTL");
            }
            else if (eFormId == FormID.PRD_PPBOM)//生成直接调拨单
            {
                //限制单一用户执行调拨
                DataTable dtLock = CommonFunction.GetLockObjectInfo("TRANS");

                if (dtLock == null || dtLock.Rows.Count == 0)//新增记录
                {
                    CommonFunction.DM_LockObject_Add("TRANS", "FUNCTION", "限制只有一个用户操作调拨", "TRANS");
                }
                else if (dtLock.Rows[0]["FSTATUS"].ToString() == "0")//没有占用锁库操作时，占用锁库操作
                {
                    CommonFunction.UpdateLockStatus(1, "TRANS");
                }
                else//存在操作记录
                {
                    MessageBox.Show("[" + dtLock.Rows[0]["FUSER"].ToString() + "]正在执行调拨，请稍后再使用。");
                    return;
                }

                try
                {
                    bgWorker.RunWorkerAsync();
                    frmNotify.ShowDialog();
                    DataSourceBinding();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误提示：\n\r" + ex.Message);
                    return;
                }

                //解除调拨占用
                CommonFunction.UpdateLockStatus(0, "TRANS");
            }
            else if (eFormId == FormID.SAL_SALEORDER)//锁库
            {
                //记录勾选状态
                lstCheckStatus = new List<CheckStatus>();

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    lstCheckStatus.Add(new CheckStatus(i, Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value)));
                }

                lstOrder = new ArrayList();
                OrderInfo entry;

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    if (dgv1.Rows[i].Cells[0].Value == null) continue;//未被勾选

                    entry = new OrderInfo();
                    entry.FBillNo = dgv1.Rows[i].Cells[1].Value.ToString();//销售订单编号
                    entry.FBILLTYPEID = dgv1.Rows[i].Cells[2].Value.ToString();//单据类型
                    entry.FMaterialNo = dgv1.Rows[i].Cells[6].Value.ToString();//物料编码
                    entry.FEntryId = int.Parse(dgv1.Rows[i].Cells[18].Value.ToString());//销售订单分录内码
                    lstOrder.Add(entry);//封装参与锁库的订单实体                        

                }
                if (lstOrder.Count == 0)
                {
                    MessageBox.Show("没有选择锁库订单！");
                    return;
                }

                bgWorker.RunWorkerAsync();
                frmNotify.ShowDialog();

                //修改批量锁库状态
                SalOrder.UpdateBatchFlag(lstOrder);

                DataSourceBinding();

                //还原勾选状态
                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    dgv1.Rows[i].Cells[0].Value = lstCheckStatus[i].ChStatus;
                }
            }
            else if (eFormId == FormID.SAL_SALEORDERRUN)//订单运算
            {
                DataTable dtTran = dtSearch.Clone();

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    if (dgv1.Rows[i].Cells[0].Value != null && Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value))
                    {
                        //排除完全锁库订单或已锁库分录(在运算时排除)

                        //dtTran.ImportRow(dtSearch.Rows[i]);
                        dtTran.ImportRow((dtSearch.Select("订单内码=" + dgv1.Rows[i].Cells[19].Value.ToString()))[0]);
                    }
                }

                if (dtTran.Rows.Count == 0)
                {
                    MessageBox.Show("没有选择订单！");
                    return;
                }

                dtResult = new DataTable();
                dtResult.Columns.Add("状态");
                dtResult.Columns.Add("单号");
                dtResult.Columns.Add("原因");

                //判断是否有未批量锁库的订单
                for (int i = 0; i < dtTran.Rows.Count; i++)
                {
                    if (dtTran.Rows[i]["批量锁库"].ToString() == "否" && dtTran.Rows[i]["单据类型"].ToString() != "备货销售订单")
                    {
                        dr = dtResult.NewRow();
                        dr["状态"] = "失败";
                        dr["单号"] = dtTran.Rows[i]["单据编号"].ToString();
                        dr["原因"] = "销售订单未批量锁库";
                        dtResult.Rows.Add(dr);
                    }
                }

                //提示
                if (dtResult.Rows.Count > 0)
                {
                    frmResult tmp = new frmResult(dtResult);
                    tmp.ShowDialog();
                    return;
                }

                //查询运算功能是否被其他用户占用,功能退出时间大于5分钟时表示系统解除了占用。
                DataTable dtLock = CommonFunction.DM_LockObjectInfo("ORDERRUN");
                if (dtLock == null || dtLock.Rows.Count == 0)//新增记录
                {
                    CommonFunction.DM_LockObject_Add("T_SAL_ORDER", "TABLE", "限制只有一个用户操作订单运算", "ORDERRUN");
                }
                else if (dtLock.Rows[0]["FSTATUS"].ToString() == "0")//没有占用订单运算操作时，占用订单运算操作
                {
                    CommonFunction.UpdateLockStatus(1, "ORDERRUN");
                }
                else
                {
                    MessageBox.Show("[" + dtLock.Rows[0]["FUSER"].ToString() + "]正在使用订单运算功能，请稍后再使用。");
                    return;
                }

                //运算
                try
                {
                    frmOrderOperation oor = new frmOrderOperation(dtTran);
                    oor.ShowDialog();
                    oor.Dispose();
                }
                catch { }
                finally
                {
                    CommonFunction.UpdateLockStatus(0, "ORDERRUN");
                }
            }
        }
        #endregion

        #region 直接调拨单
        /// <summary>
        /// 直接调拨单
        /// </summary>
        private int Trans(object sender, DoWorkEventArgs e)
        {
            string strBillNos, tmp;

            List<string> list;
            List<string> lstOutStock;

            DataTable dt;
            DataTable dtDept  = CommonFunction.GetPickMtlDepartment();

            if (dtDept == null || dtDept.Rows.Count == 0)
                return -1;

            //根据具体部门汇总分组情况指定锯齿数组值
            string[][] DepNo = new string[dtDept.Rows.Count][];
            strBillNos = string.Empty;
            tmp = string.Empty;
            list = new List<string>();

            for (int i = 0; i < dtDept.Rows.Count; i++)
            {
                DepNo[i] = new string[] { dtDept.Rows[i]["FNUMBER"].ToString() };
            }

            for (int i = 0; i < DepNo.Length; i++)
            {
                tmp = string.Empty;

                for (int j = 0; j < DepNo[i].Length; j++)
                {
                    if (j > 0) tmp += ",";
                    tmp += "'" + DepNo[i][j] + "'";
                }

                list.Add(tmp);
            }

            for (int i = 0; i < list.Count; i++)
            {
                dt = new DataTable();
                lstOutStock = new List<string>();

                //获取调拨单数据
                dt = PrdAllocation.GetTransferDirectDt(dtpDate.Value.ToString("yyyy-MM-dd"), list[i]);

                if (dt.Rows.Count == 0)
                    continue;

                //统计调出仓库
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (j == 0)
                        lstOutStock.Add(dt.Rows[0]["调出仓库"].ToString());
                    else if (!lstOutStock.Contains(dt.Rows[j]["调出仓库"].ToString()))
                        lstOutStock.Add(dt.Rows[j]["调出仓库"].ToString());
                }

                //根据不同调出仓分批生产单据
                DataTable dt2;

                for (int j = 0; j < lstOutStock.Count; j++)
                {
                    dt2 = new DataTable();
                    dt2 = dt.Clone();

                    for (int m = 0; m < dt.Rows.Count; m++)
                    {
                        if (lstOutStock[j] == dt.Rows[m]["调出仓库"].ToString())
                            dt2.ImportRow(dt.Rows[m]);
                    }

                    if (dt2.Rows.Count > 0)
                    {
                        //生成单据
                        tmp = PrdAllocation.TransferDirect(dt2, dtpDate.Value);

                        if (tmp != "")
                            strBillNos += "[" + tmp + "] ";
                    }
                }

                //更新【已经生成调拨单】状态
                PrdAllocation.UpdateDirectFields(dtpDate.Value.ToString("yyyy-MM-dd"), list[i]);

                //控制进度条
                if (bgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return -1;
                }
                else
                {
                    // 状态报告  
                    bgWorker.ReportProgress(i * 100 / (list.Count - 1));

                    // 等待，用于UI刷新界面，很重要  
                    Thread.Sleep(1);
                }
            }

            if (strBillNos != "")
                MessageBox.Show("生成直接调拨单：" + strBillNos);
            else
                MessageBox.Show("没有数据可以生成直接调拨单！\n\r 或者源单据未审核！");

            return -1;
        }
        #endregion

        #region 锁库
        /// <summary>
        /// 锁库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private int LockStock(object sender, DoWorkEventArgs e)
        {
            DataTable dt, ReturnDT;
            DataRow dr;

            ReturnDT = new DataTable();
            ReturnDT.Columns.Add("操作");
            ReturnDT.Columns.Add("销售订单");
            ReturnDT.Columns.Add("物料编码");
            ReturnDT.Columns.Add("仓库");
            ReturnDT.Columns.Add("信息");

            if (lstOrder.Count == 0) goto ShowResult;

            //占用锁库操作
            DataTable dtLock = CommonFunction.GetLockObjectInfo("LOCKSTOCK");

            if (dtLock == null || dtLock.Rows.Count == 0)//新增记录
            {
                CommonFunction.DM_LockObject_Add("T_SAL_ORDER", "TABLE", "限制只有一个用户操作订单锁库", "LOCKSTOCK");
            }
            else if (dtLock.Rows[0]["FSTATUS"].ToString() == "0")//没有占用锁库操作时，占用锁库操作
            {
                CommonFunction.UpdateLockStatus(1, "LOCKSTOCK");
            }
            else//存在锁表操作记录
            {
                MessageBox.Show("[" + dtLock.Rows[0]["FUSER"].ToString() + "]正在执行操作锁库，请稍后再使用。");
                return -1;
            }

            for (int i = 0; i < lstOrder.Count; i++)
            {
                dt = new DataTable();
                dt = SalOrder.GetOrderLockByFEntryId(((OrderInfo)lstOrder[i]).FEntryId);

                if (dt == null || dt.Rows.Count == 0)//锁库失败信息
                {
                    dr = ReturnDT.NewRow();
                    dr["操作"] = "失败";
                    dr["销售订单"] = ((OrderInfo)lstOrder[i]).FBillNo;
                    dr["物料编码"] = ((OrderInfo)lstOrder[i]).FMaterialNo;
                    dr["仓库"] = "";
                    dr["信息"] = "没有库存信息";
                    ReturnDT.Rows.Add(dr);

                    //锁库失败记录日志
                    SalOrder.Log_OrderLock((OrderInfo)lstOrder[i], 1, "没有库存信息");
                }
                else
                {
                    if (((OrderInfo)lstOrder[i]).FBILLTYPEID == "备货销售订单")//备货销售订单不需要锁库
                    {
                        dr = ReturnDT.NewRow();
                        dr["操作"] = "失败";
                        dr["销售订单"] = ((OrderInfo)lstOrder[i]).FBillNo;
                        dr["物料编码"] = ((OrderInfo)lstOrder[i]).FMaterialNo;
                        dr["仓库"] = "";
                        dr["信息"] = "备货销售订单。";
                        ReturnDT.Rows.Add(dr);

                        //锁库失败记录日志
                        SalOrder.Log_OrderLock((OrderInfo)lstOrder[i], 1, "备货销售订单");
                        continue;
                    }

                    double dCanLockQty = double.Parse(dt.Rows[0]["最大可锁数量"].ToString());//可锁库数量

                    if (dCanLockQty <= 0)//可锁库数量小于等于零时不需要锁库
                    {
                        dr = ReturnDT.NewRow();
                        dr["操作"] = "失败";
                        dr["销售订单"] = ((OrderInfo)lstOrder[i]).FBillNo;
                        dr["物料编码"] = ((OrderInfo)lstOrder[i]).FMaterialNo;
                        dr["仓库"] = "";
                        dr["信息"] = "可锁数量小于等于零";
                        ReturnDT.Rows.Add(dr);

                        //锁库失败记录日志
                        SalOrder.Log_OrderLock((OrderInfo)lstOrder[i], 1, "可锁数量小于等于零");
                        continue;
                    }

                    double dAvbqty = 0;//可用量

                    for (int j = 0; j < dt.Rows.Count; j++)//累加可用量
                    {
                        dAvbqty += double.Parse(dt.Rows[j]["可用量"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[j]["可用量"].ToString());
                    }

                    if (dAvbqty == 0)
                    {
                        dr = ReturnDT.NewRow();
                        dr["操作"] = "失败";
                        dr["销售订单"] = ((OrderInfo)lstOrder[i]).FBillNo;
                        dr["物料编码"] = ((OrderInfo)lstOrder[i]).FMaterialNo;
                        dr["仓库"] = "";
                        dr["信息"] = "库存可用量为零";
                        ReturnDT.Rows.Add(dr);

                        //锁库失败记录日志
                        SalOrder.Log_OrderLock((OrderInfo)lstOrder[i], 1, "库存可用量为零");
                        continue;
                    }

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        double dQTY = double.Parse(dt.Rows[j]["可用量"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[j]["可用量"].ToString());//第i行 库存可用数量

                        if (dQTY >= dCanLockQty)//当库存可用量大于或等于可锁库数量时可参与锁库
                        {
                            //添加预留关系
                            if (SalOrder.AddReserveLink(dt.Rows[j], dCanLockQty).IndexOf("FID") < 0)
                                continue;

                            SalOrder.UpdateOrderLock(dCanLockQty.ToString(), int.Parse(dt.Rows[0]["FID"].ToString()), int.Parse(dt.Rows[0]["FENTRYID"].ToString()));

                            //库存锁库列表（销售订单->锁库查询）

                            //新增锁库日志
                            dt.Rows[j]["锁库数量"] = dCanLockQty.ToString();
                            SalOrder.Log_OrderLock(dt.Rows[j], 1);

                            dr = ReturnDT.NewRow();
                            dr["操作"] = "成功";
                            dr["销售订单"] = dt.Rows[0]["单据编号"].ToString();
                            dr["物料编码"] = dt.Rows[0]["物料编码"].ToString();
                            dr["仓库"] = dt.Rows[j]["仓库"].ToString();
                            dr["信息"] = "成功锁库数量:" + dCanLockQty.ToString();
                            ReturnDT.Rows.Add(dr);

                            dCanLockQty = 0;
                            break;
                        }
                        else if (dQTY > 0)//当储存可用量小于可锁库数量时
                        {
                            //添加预留关系
                            if (SalOrder.AddReserveLink(dt.Rows[j], dQTY).IndexOf("FID") < 0)
                                continue;

                            //修改销售订单锁库/预留数量(库存单位)、待锁库/待预留数量(库存单位)FLEFTQTY、批量锁库标识
                            SalOrder.UpdateOrderLock(dQTY.ToString(), int.Parse(dt.Rows[0]["FENTRYID"].ToString()));

                            //库存锁库列表（销售订单->锁库查询）

                            //新增锁库日志
                            dt.Rows[j]["锁库数量"] = dQTY.ToString();
                            SalOrder.Log_OrderLock(dt.Rows[j], 1);

                            dr = ReturnDT.NewRow();
                            dr["操作"] = "成功";
                            dr["销售订单"] = dt.Rows[0]["单据编号"].ToString();
                            dr["物料编码"] = dt.Rows[0]["物料编码"].ToString();
                            dr["仓库"] = dt.Rows[j]["仓库"].ToString();
                            dr["信息"] = "成功锁库数量:" + dQTY.ToString();
                            ReturnDT.Rows.Add(dr);

                            //修改销售订单可锁库数量dLockQty
                            dCanLockQty -= dQTY;
                        }
                    }
                }

                //进度条
                if (bgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    goto ShowResult;
                }
                else
                {
                    bgWorker.ReportProgress((i + 1) * 100 / lstOrder.Count);
                    Thread.Sleep(1);
                }
            }

            //Remark
            ShowResult:
            frmLockStockResult lsr = new frmLockStockResult(ReturnDT);
            lsr.ShowDialog();

            //解除锁表标志
            CommonFunction.UpdateLockStatus(0, "LOCKSTOCK");

            return -1;
        }
        #endregion

        #region 解锁
        /// <summary>
        /// btnUnLock_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnLock_Click(object sender, EventArgs e)
        {
            if (dgv1.DataSource == null || dgv1.Rows.Count < 1)
            {
                MessageBox.Show("没有数据！");
                return;
            }

            //记录勾选状态
            lstCheckStatus = new List<CheckStatus>();

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                lstCheckStatus.Add(new CheckStatus(i, Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value)));
            }

            IList olist = new ArrayList();//销售订单实体
            OrderInfo entry;

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1.Rows[i].Cells[0].Value != null && Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value))
                {
                    entry = new OrderInfo();
                    entry.FBillNo = dgv1.Rows[i].Cells[1].Value.ToString();
                    entry.FMaterialNo = dgv1.Rows[i].Cells[6].Value.ToString();
                    entry.FLockQTY = double.Parse(dgv1.Rows[i].Cells[10].Value.ToString());
                    entry.FEntryId = int.Parse(dgv1.Rows[i].Cells[18].Value.ToString());
                    entry.FStockOrgNumber = dgv1.Rows[i].Cells[5].Value.ToString();
                    entry.FUnitNumber = dgv1.Rows[i].Cells[8].Value.ToString();
                    olist.Add(entry);//封装实体
                }
            }

            if (olist.Count == 0)
            {
                MessageBox.Show("没有选择订单");
                return;
            }

            frmLockStockResult lsr = new frmLockStockResult(UnLockStock(olist));
            lsr.ShowDialog();

            DataSourceBinding();

            //还原勾选状态
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                dgv1.Rows[i].Cells[0].Value = lstCheckStatus[i].ChStatus;
            }
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="pList"></param>
        /// <returns></returns>
        private DataTable UnLockStock(IList pList)
        {
            DataTable ReturnDT = null;
            DataRow dr = null;
            double dLockQTY;

            ReturnDT = new DataTable();
            ReturnDT.Columns.Add("操作");
            ReturnDT.Columns.Add("销售订单");
            ReturnDT.Columns.Add("物料编码");
            ReturnDT.Columns.Add("信息");

            for (int i = 0; i < pList.Count; i++)
            {
                dLockQTY = ((OrderInfo)pList[i]).FLockQTY;
                dr = ReturnDT.NewRow();

                if (dLockQTY <= 0)
                {
                    dr["操作"] = "解锁失败";
                    dr["销售订单"] = ((OrderInfo)pList[i]).FBillNo;
                    dr["物料编码"] = ((OrderInfo)pList[i]).FMaterialNo;
                    dr["信息"] = "解锁数量:0";
                    ReturnDT.Rows.Add(dr);
                    //continue;
                }
                else
                {
                    SalOrder.UnLockSalOrder(dLockQTY.ToString(), ((OrderInfo)pList[i]).FEntryId);

                    dr["操作"] = "解锁成功";
                    dr["销售订单"] = ((OrderInfo)pList[i]).FBillNo;
                    dr["物料编码"] = ((OrderInfo)pList[i]).FMaterialNo;
                    dr["信息"] = "解锁数量:" + dLockQTY.ToString();
                    ReturnDT.Rows.Add(dr);
                }

                //解锁日志
                SalOrder.Log_OrderLock(dr, 0);
            }
            return ReturnDT;
        }
        #endregion

        #region 检查物料是否指定了调出仓库
        /// <summary>
        /// btnCheck_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (cbxCondition.SelectedIndex != 1 || cbxLogic.SelectedIndex != 1)
            {
                MessageBox.Show("请指定计划开工日期");
                return;
            }

            dgv1.DataSource = null;

            if (PrdAllocation.SetDefaultStock(dtpDate.Value))
            {
                btnSearch.Enabled = true;
                MessageBox.Show("所有物料已经设置默认仓库，可以做调拨单！");
                return;
            }
            else
            {
                btnSearch.Enabled = false;
                frmSetDefaultStock frmSS = new frmSetDefaultStock(dtpDate.Value.ToString("yyyy-MM-dd"));
                frmSS.ShowDialog();
            }
        }
        #endregion

        #region 显示当前UC，其余隐藏
        /// <summary>
        /// 显示当前UC，其余隐藏
        /// </summary>
        /// <param name="pList">已经打开的UC</param>
        /// <param name="pUCName">当前点击的UC</param>
        /// <param name="pAll">是否隐藏所有UC</param>
        /// <returns>pUCName是否在pList中</returns>
        private bool HideUC(List<string> pList, string pUCName, bool pAll)
        {
            bool bReturnValue = false;

            if (pList.Count == 0)
                return false;

            if (pAll)
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    ((UserControl)(sc1.Panel2.Controls.Find(pList[i], false)[0])).Visible = false;
                }
            }
            else
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    if (pList[i] == pUCName)
                    {
                        ((UserControl)(sc1.Panel2.Controls.Find(pList[i], false)[0])).Visible = true;
                        bReturnValue = true;
                    }
                    else
                        ((UserControl)(sc1.Panel2.Controls.Find(pList[i], false)[0])).Visible = false;
                }
            }

            return bReturnValue;
        }
        #endregion

        #region 通过指定的子控件TypeName从父控件中移除
        /// <summary>
        /// 通过指定的子控件TypeName从父控件中移除
        /// </summary>
        /// <param name="pCC">父控件</param>
        /// <param name="pControlTypeNameList">指定移除的子控件List</param>
        private void RemoveChildControls(Control.ControlCollection pCC, List<string> pControlTypeNameList)
        {
            List<Control> list = new List<Control>();

            foreach (Control ct in pCC)
            {
                list.Add(ct);
            }

            for (int i = 0; i < pCC.Count; i++)
            {
                if (pControlTypeNameList.Contains(pCC[i].GetType().Name))
                    pCC.Remove(list[i]);
            }
        }
        #endregion

        #region 重置一级控件大小
        /// <summary>
        /// 重置一级控件大小
        /// </summary>
        /// <param name="pListP">一级控件List</param>
        /// <param name="pRow">当前点击的行数</param>
        /// <param name="pChildCount">当前一级控件的包含子二级控件数</param>
        private void ResetUCSize(List<ucNaviga> pListP, int pRow, int pChildCount)
        {
            int iRow = 1;

            foreach (ucNaviga uc in pListP)
            {
                if (int.Parse(uc.Name.Substring(3, 1)) < pRow)//调整小于当前行的控件大小
                {
                    uc.Location = new Point(0, (iRow - 1) * 30);
                    uc.Size = new Size(160, 30);
                }
                else if (int.Parse(uc.Name.Substring(3, 1)) == pRow)//调整当前行的控件大小
                {
                    uc.Location = new Point(0, (iRow - 1) * 30);
                    uc.Size = new Size(160, (1 + pChildCount) * 30);
                }
                else//调整大于当前行的控件大小
                {
                    uc.Location = new Point(0, sc1.Panel1.Size.Height - (pListP.Count - iRow + 1) * 30);
                    uc.Size = new Size(160, 30);
                }

                iRow++;
            }
        }
        #endregion

        #region 在当前点击的一级控件中填充其二级控件
        /// <summary>
        /// 在当前点击的一级控件中填充其二级控件
        /// </summary>
        /// <param name="pUCP">一级控件</param>
        /// <param name="pListC">二级控件List</param>
        /// <param name="pRow">当前一级控件所在行数</param>
        /// <param name="pChildCount">当前一级控件的包含子二级控件数</param>
        private void AddChild(ucNaviga pUCP, List<ucNaviga> pListC, int pRow, int pChildCount)
        {
            int iCount = 0;

            foreach (ucNaviga uc in pListC)
            {
                if (uc.Name.Substring(3, 1) == pUCP.Name.Substring(3, 1))//?V5.0优化：可以更严密地判断二级控件是否属于一级控件
                {
                    //改变二级控件背景色
                    ((Button)uc.Controls.Find("button1", true)[0]).BackColor = Color.Beige;

                    //去掉二级控件边框
                    ((Button)uc.Controls.Find("button1", true)[0]).FlatStyle = FlatStyle.Flat;
                    ((Button)uc.Controls.Find("button1", true)[0]).FlatAppearance.BorderSize = 0;

                    //指定二级控件的位置
                    uc.Location = new Point(0, (iCount + 1) * 30);
                    pUCP.Controls.Add(uc);

                    iCount++;
                }
            }
        }
        #endregion

        #region 控制当前点击的二级控件样式
        /// <summary>
        /// 控制当前点击的二级控件样式
        /// </summary>
        /// <param name="pUCNavi">当前二级控件</param>
        /// <param name="pListC">二级控件列表</param>
        private void ChangeCurrentControlStyle(ucNaviga pUCNavi, List<ucNaviga> pListC)
        {
            foreach (ucNaviga uc in pListC)
            {
                if (pUCNavi.Name == uc.Name)
                    ((Button)uc.Controls.Find("button1", true)[0]).FlatStyle = FlatStyle.Standard;
                else
                    ((Button)uc.Controls.Find("button1", true)[0]).FlatStyle = FlatStyle.Flat;
            }
        }
        #endregion

        #region 主窗口大小改变时发生
        /// <summary>
        /// 主窗口大小改变时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (iCurrentRow != 0)
                ResetUCSize(lstP, iCurrentRow, iChildCount);
        }
        #endregion

        #region 菜单

        /// <summary>
        /// 注销Logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFile_L_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要注销用户[" + GlobalParameter.K3Inf.UserName + "]吗？", "用户注销", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dispose();
                DialogResult = DialogResult.None;
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFile_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出系统吗？", "系统退出", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTool_Config_Click(object sender, EventArgs e)
        {
            frmSetting st = new frmSetting(2);
            st.ShowDialog();

            if (st.BLogout)
            {
                Dispose();
                DialogResult = DialogResult.None;
            }
        }

        /// <summary>
        /// 参数设定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTool_Parameter_Click(object sender, EventArgs e)
        {
            frmParameter frm = new frmParameter();
            frm.ShowDialog();
        }

        /// <summary>
        /// 解除倒冲领料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiTool_Occupy_PickMtl_Click(object sender, EventArgs e)
        {
            object oUser = CommonFunction.GetLockObjectInfo("PICKMTL", 1);

            if (oUser == null)
            {
                MessageBox.Show("倒冲领料未被占用。");
            }
            else
            {
                if (MessageBox.Show("倒冲领料操作被[" + oUser.ToString() + "]占用\n确定要强行解除吗？", "占用解除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CommonFunction.UpdateLockStatus(0, "PICKMTL");
                }
            }
        }

        /// <summary>
        /// 解除调拨
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiTool_Occupy_Trans_Click(object sender, EventArgs e)
        {
            object oUser = CommonFunction.GetLockObjectInfo("TRANS", 1);

            if (oUser == null)
            {
                MessageBox.Show("调拨未被占用。");
            }
            else
            {
                if (MessageBox.Show("调拨操作被[" + oUser.ToString() + "]占用\n确定要强行解除吗？", "占用解除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CommonFunction.UpdateLockStatus(0, "TRANS");
                }
            }
        }

        /// <summary>
        /// 解除锁库占用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTool_Occupy_LockStock_Click(object sender, EventArgs e)
        {
            object oUser = CommonFunction.GetLockObjectInfo("LOCKSTOCK", 1);

            if (oUser == null)
            {
                MessageBox.Show("锁库操作未被占用。");
            }
            else
            {
                if (MessageBox.Show("锁库操作被[" + oUser.ToString() + "]占用\n确定要强行解除吗？", "占用解除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CommonFunction.UpdateLockStatus(0, "LOCKSTOCK");
                }
            }
        }

        /// <summary>
        /// 解除订单运算占用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTool_Occupy_OrderRun_Click(object sender, EventArgs e)
        {
            object oUser = CommonFunction.GetLockObjectInfo("ORDERRUN", 1);

            if (oUser == null)
            {
                MessageBox.Show("订单运算操作未被占用。");
            }
            else
            {
                if (MessageBox.Show("订单运算操作被[" + oUser.ToString() + "]占用\n确定要强行解除吗？", "占用解除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CommonFunction.UpdateLockStatus(0, "ORDERRUN");
                }
            }
        }

        /// <summary>
        /// 解除自动领料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTool_Occupy_LockPickMtl_Click(object sender, EventArgs e)
        {
            object oUser = CommonFunction.GetLockObjectInfo("LOCKPICKMTL", 1);

            if (oUser == null)
            {
                MessageBox.Show("自动领料未被占用。");
            }
            else
            {
                if (MessageBox.Show("自动领料操作被[" + oUser.ToString() + "]占用\n确定要强行解除吗？", "占用解除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CommonFunction.UpdateLockStatus(0, "LOCKPICKMTL");
                }
            }
        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTool_Timer_Click(object sender, EventArgs e)
        {
            frmTimer frmTime = new frmTimer(TimerPara);

            if (frmTime.ShowDialog() == DialogResult.OK)
            {
                //TimerPara = frmTime.TimerPara;
                TimerPara = new TimerParameter(frmTime.TimerPara.ExeTimes, frmTime.TimerPara.PickMinute, frmTime.TimerPara.RunSeconds, frmTime.TimerPara.PauseStatus, frmTime.TimerPara.IsRunning, frmTime.TimerPara.FuncID);

                if (TimerPara.PauseStatus)
                {
                    if (tSumSecond != null) tSumSecond.Stop();//停止进行时间累计
                    if (tExecute != null) tExecute.Stop();//停止方法自动执行
                }
                else
                {
                    //进行时间累计
                    tSumSecond = new System.Windows.Forms.Timer();
                    tSumSecond.Enabled = true;
                    tSumSecond.Interval = 1000;
                    tSumSecond.Tick += tSumSecond_Tick;
                    tSumSecond.Start();

                    //方法自动执行
                    tExecute = new System.Timers.Timer();
                    tExecute.Enabled = true;
                    tExecute.Interval = 1000 * 60 * TimerPara.PickMinute;//每pMinute分钟执行一次
                    tExecute.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                    tExecute.Start();
                }
            }
            //frmTime.Dispose();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiHelp_Regedit_Click(object sender, EventArgs e)
        {
            frmHelp frmH = new frmHelp(1);
            frmH.ShowDialog();
        }

        /// <summary>
        /// 查看帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiHelp_View_Click(object sender, EventArgs e)
        {
            frmHelp frmH = new frmHelp(2);
            frmH.ShowDialog();
        }

        /// <summary>
        /// 系统版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiHelp_Version_Click(object sender, EventArgs e)
        {
            frmHelp frmH = new frmHelp(3);
            frmH.ShowDialog();
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiHelp_About_Click(object sender, EventArgs e)
        {
            frmHelp frmH = new frmHelp(4);
            frmH.ShowDialog();
        }
        #endregion

        #region 事件

        #region 下拉框变化响应
        /// <summary>
        /// 下拉框变化响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eFormId == FormID.PRD_INSTOCK || eFormId == FormID.PRD_PPBOM)
            {
                if (cbxCondition.SelectedIndex == 1)
                {
                    cbxLogic.SelectedIndex = 4;
                    txtCondition.Visible = false;
                    dtpDate.Visible = true;
                }
                else
                {
                    cbxLogic.SelectedIndex = 7;
                    txtCondition.Visible = true;
                    dtpDate.Visible = false;
                }
            }
            else if (eFormId == FormID.SAL_SALEORDER || eFormId == FormID.SAL_SALEORDERRUN)
            {
                if (cbxCondition.SelectedIndex == 1 || cbxCondition.SelectedIndex == 2)
                {
                    cbxLogic.SelectedIndex = 4;
                    txtCondition.Visible = false;
                    dtpDate.Visible = true;
                }
                else
                {
                    cbxLogic.SelectedIndex = 7;
                    txtCondition.Visible = true;
                    dtpDate.Visible = false;
                }
            }

            if (cbxCondition.SelectedIndex == 0 && cbxLogic.SelectedIndex != -1) cbxLogic.SelectedIndex = -1;
        }
        #endregion

        #region 日期值变化
        /// <summary>
        /// 日期值变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (eFormId == FormID.PRD_PPBOM)
            {
                btnSearch.Enabled = false;
            }
        }
        #endregion

        #region 添加行号
        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        #endregion

        #region 清除列头筛选状态
        /// <summary>
        /// 清除列头筛选状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            DataGridViewAutoFilterColumnHeaderCell.RemoveFilter(dgv1);
        }
        #endregion

        #region 定时器事件
        /// <summary>
        /// 计算RunSeconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSumSecond_Tick(object sender, EventArgs e)
        {
            TimerPara.RunSeconds++;
        }

        /// <summary>
        /// 定时任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DataTable dt = new DataTable();

            TimerPara.IsRunning = true;

            try
            {
                dt = PrdPick.GetInstockBillNo(DateTime.Now.AddDays(-2));

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PrdPick.PickMtl(dt.Rows[i]["FBILLNO"].ToString());
                    }
                    TimerPara.ExeTimes++;
                }
            }
            catch { }

            TimerPara.IsRunning = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tClose_Elapsed(object sender, ElapsedEventArgs e)
        {
            WinMessager.iOperCount++;
            if (WinMessager.iOperCount > 1)
            {
                //Application.Exit();
            }
        }
        #endregion

        #endregion
    }
}

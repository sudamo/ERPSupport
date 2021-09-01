using System;
using System.Data;
using System.Timers;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ERPSupport.SupForm
{
    using Model.Enum;
    using Model.Basic;
    using Model.Globa;
    using Model.K3Cloud;
    using Menu;
    using UserCrtl;
    using UserClass;
    using Bussiness;
    using DALFactory.K3Cloud;

    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class frmMain : Form
    {
        #region Fields,Properties & Constructor
        /// <summary>
        /// 仓库ID
        /// </summary>
        private int _StockID;
        /// <summary>
        /// 部门ID
        /// </summary>
        private int _DeptID;
        /// <summary>
        /// 从数据源的第iStart行开始取数据
        /// </summary>
        private int _Start;
        /// <summary>
        /// 取数据截至行
        /// </summary>
        private int _End;
        /// <summary>
        /// 当前页号（页码）
        /// </summary>
        private int _CurrentPage;
        /// <summary>
        /// 每页显示行数（页长）
        /// </summary>
        private int _PageSize;
        /// <summary>
        /// 页数＝总记录数/每页显示行数（向上取整）
        /// </summary>
        private int _PageCount;
        /// <summary>
        /// 总记录数
        /// </summary>
        private int _RecordCount;
        /// <summary>
        /// 数据源
        /// </summary>
        private DataTable _DataSource;
        /// <summary>
        /// 用于显示的数据
        /// </summary>
        private DataTable _DataTemp;
        /// <summary>
        /// 导航当前点击行数
        /// </summary>
        private int _CurrentRow;
        /// <summary>
        /// 当前一级控件其包含二级控件数
        /// </summary>
        private int _ChildCount;
        /// <summary>
        /// 方案名
        /// </summary>
        private string _FilterName;
        /// <summary>
        /// 旧业务标识
        /// </summary>
        private FormID _FormId_Pre;
        /// <summary>
        /// 当前业务标识
        /// </summary>
        private FormID _FormId;
        /// <summary>
        /// 单独进程执行操作的组件
        /// </summary>
        private BackgroundWorker _Worker;
        /// <summary>
        /// 进度条窗体
        /// </summary>
        private frmProgress _Progress;
        /// <summary>
        /// 定时参数
        /// </summary>
        private TimerParameter _TimerPara;
        /// <summary>
        /// 订单实体List
        /// </summary>
        private IList _ListOrder;
        /// <summary>
        /// 所有UC对象
        /// </summary>
        private List<string> _ListUC;
        /// <summary>
        /// 已经打开的UC对象
        /// </summary>
        private List<string> _ListOpenUC;
        /// <summary>
        /// 筛选条件
        /// </summary>
        private List<Filter> _ListFilter;
        /// <summary>
        /// 勾选状态
        /// </summary>
        private List<CheckStatus> _ListCheckStatus;
        /// <summary>
        /// 导航一级控件
        /// </summary>
        private List<ucNaviga> _ListP;
        /// <summary>
        /// 导航二级控件
        /// </summary>
        private List<ucNaviga> _ListC;
        /// <summary>
        /// 计时器
        /// </summary>
        private System.Timers.Timer _Execute;
        /// <summary>
        /// 程序自动关闭计时器
        /// </summary>
        private System.Timers.Timer _Close;
        /// <summary>
        /// 窗口信息
        /// </summary>
        private WinMessager _msg;
        /// <summary>
        /// 正则表达式判断
        /// </summary>
        private Regex _reg;
        /// <summary>
        /// 表头复选框
        /// </summary>
        private CheckBox _chb;
        /// <summary>
        /// 表体复选框
        /// </summary>
        private DataGridViewCheckBoxColumn _col;
        /// <summary>
        /// ToolStrip日期从
        /// </summary>
        private ToolStripDateTimePicker _dateFrom;
        /// <summary>
        /// ToolStrip日期到
        /// </summary>
        private ToolStripDateTimePicker _dateTo;
        /// <summary>
        /// 销售订单实体
        /// </summary>
        private OrderInfo _OrderInf;

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
            FromSetting();
            FillComboBox();
            FillControlList();
        }
        #endregion

        #region 设置初始状态
        /// <summary>
        /// 设置初始状态
        /// </summary>
        private void FromSetting()
        {
            _DeptID = 0;
            _StockID = 0;
            //
            _CurrentRow = 0;
            _ChildCount = 0;
            _FilterName = string.Empty;
            _FormId = _FormId_Pre = FormID.PRD_INSTOCK;
            _DataSource = new DataTable();
            _ListUC = DALCreator.CommFunction.GetNavigation();
            _ListOpenUC = new List<string>();
            _TimerPara = new TimerParameter(0, 20, 0, true, false, "NULL");

            _OrderInf = new OrderInfo()
            {
                FDocumentStatus = "C",
                FCloseStatus = "A",
                FCancleStatus = "A",
                F_PAEZ_FACTORGID = 100508,
                FMRPCloseStatus = "A",
                FMRPTerminateStatus = "A"
            };
            //-----
            CheckForIllegalCrossThreadCalls = false;//解决多线程调用控件问题
            //-----
            _Worker = new BackgroundWorker();
            _Progress = new frmProgress();
            _Worker.WorkerReportsProgress = true;
            _Worker.WorkerSupportsCancellation = true;
            _Worker.DoWork += new DoWorkEventHandler(DoWork);
            _Worker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
            _Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);
            //-----
            if (System.Configuration.ConfigurationManager.AppSettings["LS_AutoExit"] == "1" && GlobalParameter.K3Inf.UserName != "damo")
            {
                _msg = new WinMessager();
                Application.AddMessageFilter(_msg);
                _Close = new System.Timers.Timer();
                _Close.Interval = 1000 * 60 * 60;//每60分钟执行一次,也就是60*2分钟没操作就自动关闭程序
                _Close.Elapsed += new ElapsedEventHandler(tClose_Elapsed);
                _Close.Start();
            }
            //-----
            _col = new DataGridViewCheckBoxColumn();
            _col.Width = 30;
            dgv1.Columns.Add(_col);

            _chb = new CheckBox();
            _chb.Size = new Size(16, 16);
            _chb.CheckedChanged += new EventHandler(ckBox_CheckedChanged);
            dgv1.Controls.Add(_chb);

            //-----
            _dateFrom = new ToolStripDateTimePicker();
            _dateFrom.Size = new Size(120, 21);
            //_dateFrom.ValueChangedChanged += new EventHandler(dtpDate_ValueChanged);
            _dateTo = new ToolStripDateTimePicker();
            _dateTo.Size = new Size(120, 21);

            //重新排列Items
            List<ToolStripItem> list = new List<ToolStripItem>();
            list.Add(bnTop.Items[0]);
            list.Add(_dateFrom);
            list.Add(bnTop.Items[1]);
            list.Add(_dateTo);
            list.Add(bnTop.Items[2]);
            list.Add(bnTop.Items[3]);
            list.Add(bnTop.Items[4]);
            list.Add(bnTop.Items[5]);
            list.Add(bnTop.Items[6]);
            list.Add(bnTop.Items[7]);
            list.Add(bnTop.Items[8]);

            bnTop.Items.Clear();
            foreach (ToolStripItem item in list)
                bnTop.Items.Add(item);

            //-----
            //配置本地信息
            GlobalParameter.LocalInf = new LocalInfo(DALCreator.CommFunction.GetLocalIP(), DALCreator.CommFunction.GetMac(), string.Empty, DateTime.Now, DateTime.Now);
            //登录日志
            DALCreator.CommFunction.DM_Log_Local("登录系统", "主窗口", "登录系统");
            //这是标题
            Text = "ERP辅助系统" + " - " + GlobalParameter.K3Inf.UserName;
        }
        #endregion

        #region 填充下拉框
        /// <summary>
        /// 填充下拉框
        /// </summary>
        private void FillComboBox()
        {
            DataTable dtComboBox;
            DataRow dr;

            dtComboBox = new DataTable();
            dtComboBox.Columns.Add("FName");
            dtComboBox.Columns.Add("FValue");

            dr = dtComboBox.NewRow();
            dr["FName"] = "50";
            dr["FValue"] = "50";
            dtComboBox.Rows.Add(dr);

            dr = dtComboBox.NewRow();
            dr["FName"] = "100";
            dr["FValue"] = "100";
            dtComboBox.Rows.Add(dr);

            dr = dtComboBox.NewRow();
            dr["FName"] = "500";
            dr["FValue"] = "500";
            dtComboBox.Rows.Add(dr);

            dr = dtComboBox.NewRow();
            dr["FName"] = "1000";
            dr["FValue"] = "1000";
            dtComboBox.Rows.Add(dr);

            dr = dtComboBox.NewRow();
            dr["FName"] = "10000";
            dr["FValue"] = "10000";
            dtComboBox.Rows.Add(dr);

            dr = dtComboBox.NewRow();
            dr["FName"] = "20000";
            dr["FValue"] = "20000";
            dtComboBox.Rows.Add(dr);

            bnB_cbxPageSize.ComboBox.DataSource = dtComboBox;
            bnB_cbxPageSize.ComboBox.DisplayMember = "FName";
            bnB_cbxPageSize.ComboBox.ValueMember = "FValue";
            bnB_cbxPageSize.ComboBox.SelectedIndex = 4;

            _PageSize = int.Parse(bnB_cbxPageSize.ComboBox.SelectedValue.ToString());
        }
        #endregion

        #region 功能控制
        /// <summary>
        /// 获取一、二级控件List并填充一级控件到窗体左边导航栏
        /// </summary>
        private void FillControlList()
        {
            string sRIDs, sMIDs, sFunctionIds;
            DataTable dtControls = DALCreator.CommFunction.GetNavigation(out sRIDs, out sMIDs, out sFunctionIds);
            if (dtControls == null)
                return;

            new GlobalRights(sRIDs.Trim(), sMIDs.Trim(), sFunctionIds.Trim());

            ucNaviga uc;
            _ListP = new List<ucNaviga>();
            _ListC = new List<ucNaviga>();

            for (int i = 0; i < dtControls.Rows.Count; i++)
            {
                if (int.Parse(dtControls.Rows[i]["LV"].ToString()) == 1)
                {
                    uc = new ucNaviga();
                    uc.Name = "UCP" + dtControls.Rows[i]["NODEID"].ToString();
                    uc._BtnClick += new EventHandler(FillNavi);

                    ((Button)uc.Controls.Find("button1", true)[0]).Text = dtControls.Rows[i]["NODENAME"].ToString();
                    ((Button)uc.Controls.Find("button1", true)[0]).Font = new Font(((Button)uc.Controls.Find("button1", true)[0]).Font.FontFamily, 12, ((Button)uc.Controls.Find("button1", true)[0]).Font.Style);

                    _ListP.Add(uc);
                }
                else if (int.Parse(dtControls.Rows[i]["LV"].ToString()) == 2)
                {
                    uc = new ucNaviga();
                    uc.Name = "UCC" + dtControls.Rows[i]["NODEID"].ToString();
                    uc._BtnClick += new EventHandler(FillNavi);

                    ((Button)uc.Controls.Find("button1", true)[0]).Text = "·" + dtControls.Rows[i]["NODENAME"].ToString() + "·";

                    _ListC.Add(uc);
                }
            }

            //填装一级控件到导航栏
            int itmp = 0;
            foreach (ucNaviga ucp in _ListP)
            {
                ucp.Location = new Point(0, 30 * itmp);
                sc1.Panel1.Controls.Add(ucp);
                itmp++;
            }

            //菜单权限
            if (GlobalParameter.K3Inf.UserName != "Administrator" && GlobalParameter.K3Inf.UserName != "damo")
            {
                //--Tool
                foreach (ToolStripItem ct in ((ToolStripMenuItem)((MenuStrip)Controls[1]).Items[1]).DropDownItems)
                {
                    //if (ct.Name == "tsmiTool_Occupy" && !GlobalRights.FunctionIds.Contains("tsmiTool_Occupy"))
                    //    ct.Enabled = false;
                    //if (ct.Name == "tsmiTool_Timer" && !GlobalRights.FunctionIds.Contains("tsmiTool_Timer"))
                    //    ct.Enabled = false;
                    switch (ct.Name)
                    {
                        case "tsmiTool_Occupy":
                            if (GlobalRights.FunctionIds.Contains(ct.Name)) ct.Enabled = true;
                            else ct.Enabled = false;
                            break;
                        case "tsmiTool_Timer":
                            if (GlobalRights.FunctionIds.Contains(ct.Name)) ct.Enabled = true;
                            else ct.Enabled = false;
                            break;
                    }
                }
                //--Pro
                foreach (ToolStripItem ct in ((ToolStripMenuItem)((MenuStrip)Controls[1]).Items[2]).DropDownItems)
                {
                    //if (ct.Name == "tsmiPro_Business" && !GlobalRights.FunctionIds.Contains("tsmiPro_Business"))
                    //    ct.Enabled = false;
                    //if (ct.Name == "tsmiPro_INOrder" && !GlobalRights.FunctionIds.Contains("tsmiPro_INOrder"))
                    //    ct.Enabled = false;
                    //if (ct.Name == "tsmiPro_Dir" && !GlobalRights.FunctionIds.Contains("tsmiPro_Dir"))
                    //    ct.Enabled = false;
                    //if (ct.Name == "tsmiPro_K3Data" && !GlobalRights.FunctionIds.Contains("tsmiPro_K3Data"))
                    //    ct.Enabled = false;
                    //if (ct.Name == "tsmiPro_WMSData" && !GlobalRights.FunctionIds.Contains("tsmiPro_WMSData"))
                    //    ct.Enabled = false;

                    switch (ct.Name)
                    {
                        case "tsmiPro_Business":
                            if (GlobalRights.FunctionIds.Contains(ct.Name)) ct.Enabled = true;
                            else ct.Enabled = false;
                            break;
                        case "tsmiPro_INOrder":
                            if (GlobalRights.FunctionIds.Contains(ct.Name)) ct.Enabled = true;
                            else ct.Enabled = false;
                            break;
                        case "tsmiPro_Dir":
                            if (GlobalRights.FunctionIds.Contains(ct.Name)) ct.Enabled = true;
                            else ct.Enabled = false;
                            break;
                        case "tsmiPro_K3Data":
                            if (GlobalRights.FunctionIds.Contains(ct.Name)) ct.Enabled = true;
                            else ct.Enabled = false;
                            break;
                        case "tsmiPro_WMSData":
                            if (GlobalRights.FunctionIds.Contains(ct.Name)) ct.Enabled = true;
                            else ct.Enabled = false;
                            break;
                    }
                }
            }
        }
        #endregion

        #region 导航栏点击事件
        /// <summary>
        /// 导航栏点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillNavi(object sender, EventArgs e)
        {
            ucNaviga uc = (ucNaviga)(((Button)sender).Parent.Parent);

            if (uc.Conr == "P")//当点击的是一级控件时，给当前点击的一级控件填装二级控件
            {
                foreach (ucNaviga ucp in _ListP)//移除所有子控件
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
                _CurrentRow = iRow;

                //下级分类的个数
                _ChildCount = DALCreator.CommFunction.ChildNumber(uc.Name.Substring(3, 1));

                //改变控件大小和位置
                ResetUCSize(_ListP, iRow, _ChildCount);

                //填装二级控件
                AddChild(uc, _ListC, iRow, _ChildCount);

                Text = "ERP辅助系统" + "\\" + ((Button)uc.Controls.Find("button1", true)[0]).Text + " - " + GlobalParameter.K3Inf.UserName;
            }
            else if (uc.Conr == "C")//当点击的是二级控件时
            {
                switch (uc.ParentId)
                {
                    case 1:
                        {
                            ((Panel)(sc1.Panel2.Controls.Find("panel1", false)[0])).Visible = true;//显示主窗体Panel
                            HideUC(_ListOpenUC, "", true);//隐藏所有用户控件
                            _FormId = (FormID)(uc.NodeId % 100);//设置_FormId

                            FormIDChange();
                        }
                        break;
                    case 2:
                        {
                            ((Panel)(sc1.Panel2.Controls.Find("panel1", false)[0])).Visible = false;

                            if (uc.NodeId == 201)
                            {
                                if (!HideUC(_ListOpenUC, "DefaultStock", false))
                                {
                                    ucCS_DefaultStock UserCtrl = new ucCS_DefaultStock();
                                    UserCtrl.Name = "DefaultStock";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 202)
                            {
                                if (!HideUC(_ListOpenUC, "PickDepartment", false))
                                {
                                    ucCS_PickDepartment UserCtrl = new ucCS_PickDepartment();
                                    UserCtrl.Name = "PickDepartment";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 203)
                            {
                                if (!HideUC(_ListOpenUC, "ExpCompany", false))
                                {
                                    ucCS_ExpCompany UserCtrl = new ucCS_ExpCompany();
                                    UserCtrl.Name = "ExpCompany";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 204)
                            {
                                if (!HideUC(_ListOpenUC, "BillEdit", false))
                                {
                                    ucCS_BillEdit UserCtrl = new ucCS_BillEdit();
                                    UserCtrl.Name = "BillEdit";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 205)
                            {
                                if (!HideUC(_ListOpenUC, "LockStock1", false))
                                {
                                    ucCS_LockStock UserCtrl = new ucCS_LockStock("LOCKSTOCK");
                                    UserCtrl.Name = "LockStock1";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }

                            else if (uc.NodeId == 206)
                            {
                                if (!HideUC(_ListOpenUC, "LockStock2", false))
                                {
                                    ucCS_LockStock UserCtrl = new ucCS_LockStock("RUNSTOCK");
                                    UserCtrl.Name = "LockStock2";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 207)
                            {
                                if (!HideUC(_ListOpenUC, "OutStockMaterial", false))
                                {
                                    ucCS_OutStockMaterial UserCtrl = new ucCS_OutStockMaterial();
                                    UserCtrl.Name = "OutStockMaterial";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                        }
                        break;
                    case 3:
                        {
                            ((Panel)(sc1.Panel2.Controls.Find("panel1", false)[0])).Visible = false;

                            if (uc.NodeId == 301)
                            {
                                if (!HideUC(_ListOpenUC, "Mtl203", false))
                                {
                                    ucRP_Mtl203 UserCtrl = new ucRP_Mtl203();
                                    UserCtrl.Name = "Mtl203";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 302)
                            {
                                if (!HideUC(_ListOpenUC, "Bom", false))
                                {
                                    ucRP_Bom UserCtrl = new ucRP_Bom();
                                    UserCtrl.Name = "Bom";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            ((Panel)(sc1.Panel2.Controls.Find("panel1", false)[0])).Visible = false;

                            if (uc.NodeId == 401)
                            {
                                if (!HideUC(_ListOpenUC, "System1", false))
                                {
                                    ucRC_System UserCtrl = new ucRC_System("ASSISTANT");
                                    UserCtrl.Name = "System1";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 402)
                            {
                                if (!HideUC(_ListOpenUC, "System2", false))
                                {
                                    ucRC_System UserCtrl = new ucRC_System("K3CLOUD");
                                    UserCtrl.Name = "System2";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 403)
                            {
                                if (!HideUC(_ListOpenUC, "PDA", false))
                                {
                                    ucRC_PDA UserCtrl = new ucRC_PDA();
                                    UserCtrl.Name = "PDA";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 404)
                            {
                                if (!HideUC(_ListOpenUC, "Order", false))
                                {
                                    ucRC_Order UserCtrl = new ucRC_Order();
                                    UserCtrl.Name = "Order";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                        }
                        break;
                    case 5:
                        {
                            ((Panel)(sc1.Panel2.Controls.Find("panel1", false)[0])).Visible = false;

                            if (uc.NodeId == 501)
                            {
                                if (!HideUC(_ListOpenUC, "User", false))
                                {
                                    ucSM_User UserCtrl = new ucSM_User();
                                    UserCtrl.Name = "User";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                            else if (uc.NodeId == 502)
                            {
                                if (!HideUC(_ListOpenUC, "UserAcc", false))
                                {
                                    ucSM_UserAcc UserCtrl = new ucSM_UserAcc();
                                    UserCtrl.Name = "UserAcc";
                                    sc1.Panel2.Controls.Add(UserCtrl);
                                    UserCtrl.Dock = DockStyle.Fill;

                                    _ListOpenUC.Add(UserCtrl.Name);
                                }
                            }
                        }
                        break;
                    default:
                        {
                            RemoveChildControls(sc1.Panel2.Controls, _ListUC);
                        }
                        break;
                }

                ChangeCurrentControlStyle(uc, _ListC);
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
            if (_FormId != _FormId_Pre)
            {
                _col.Visible = false;
                _chb.Visible = false;
                _chb.Checked = false;

                _ListFilter = new List<Filter>();
                dgv1.DataSource = null;

                if (_FormId == FormID.PRD_INSTOCK)
                {
                    bnTop_btnCommit.Text = "领料";
                    bnTop_btnCommit.Enabled = true;
                    bnTop_btnCommit.Image = Properties.Resources.accept;

                    bnTop_btnCheck.Visible = false;
                    bnTop_btnSearch.Text = "查找";
                    bnTop_btnSearch.Enabled = true;
                    bnTop_btnFilter.Visible = false;
                    bnTop_btnUnLock.Visible = false;

                    bnTop_lblDate.Text = "日期:";
                    bnTop_lblDate.Visible = true;
                    bnTop_lblTo.Visible = true;
                    _dateFrom.Visible = true;
                    _dateFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    _dateTo.Visible = true;
                    _dateTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else if (_FormId == FormID.PRD_PPBOM || _FormId == FormID.PRD_PPBOM_DX)
                {
                    bnTop_btnCommit.Text = "材料调拨";
                    bnTop_btnCommit.Enabled = true;
                    bnTop_btnCommit.Image = Properties.Resources.accept;

                    bnTop_btnCheck.Visible = true;
                    bnTop_btnSearch.Text = "汇总";
                    bnTop_btnSearch.Enabled = false;
                    bnTop_btnFilter.Visible = false;

                    bnTop_lblDate.Text = "计划开工日期:";
                    bnTop_lblDate.Visible = true;
                    bnTop_lblTo.Visible = false;
                    _dateFrom.Visible = true;
                    _dateFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    _dateTo.Visible = false;

                    bnTop.Location = new Point(210, 0);

                    if (GlobalParameter.Tmp_Params != null && GlobalParameter.Tmp_Params.ToString() == "1")
                    {
                        bnTop_btnUnLock.Visible = false;
                    }
                    else
                    {
                        bnTop_btnUnLock.Visible = true;
                        bnTop_btnUnLock.Text = "成品调拨";
                        bnTop_btnUnLock.ToolTipText = "产成品调拨";
                        bnTop_btnUnLock.Image = Properties.Resources.direction;

                        if (_FormId == FormID.PRD_PPBOM_DX)
                            bnTop_btnUnLock.Visible = false;
                    }
                }
                else if (_FormId == FormID.SAL_SaleOrder)
                {
                    bnTop_btnCommit.Text = "锁库";
                    bnTop_btnCommit.Enabled = true;
                    bnTop_btnCommit.Image = Properties.Resources._lock;

                    bnTop_btnCheck.Visible = false;
                    bnTop_btnSearch.Text = "查找";
                    bnTop_btnSearch.Enabled = true;
                    bnTop_btnFilter.Visible = true;
                    bnTop_btnUnLock.Visible = true;
                    bnTop_btnUnLock.Text = "解锁";
                    bnTop_btnUnLock.ToolTipText = "库存解锁";
                    bnTop_btnUnLock.Image = Properties.Resources.key;

                    bnTop_lblDate.Visible = false;
                    bnTop_lblTo.Visible = false;
                    _dateFrom.Visible = false;
                    _dateTo.Visible = false;

                    bnTop.Location = new Point(2, 0);
                }
                else if (_FormId == FormID.SAL_SaleOrderRun)
                {
                    bnTop_btnCommit.Text = "订单运算";
                    bnTop_btnCommit.Enabled = true;
                    bnTop_btnCommit.Image = Properties.Resources.accept;

                    bnTop_btnCheck.Visible = false;
                    bnTop_btnSearch.Text = "查找";
                    bnTop_btnSearch.Enabled = true;
                    bnTop_btnFilter.Visible = true;
                    bnTop_btnUnLock.Visible = false;

                    bnTop_lblDate.Visible = false;
                    bnTop_lblTo.Visible = false;
                    _dateFrom.Visible = false;
                    _dateTo.Visible = false;
                }
                _FormId_Pre = _FormId;
            }
            else//?
            {
                if (_FormId == FormID.PRD_INSTOCK)
                {
                    bnTop_btnCommit.Text = "领料";
                    bnTop_btnCommit.Enabled = true;
                    bnTop_btnCommit.Image = Properties.Resources.accept;

                    bnTop_btnCheck.Visible = false;
                    bnTop_btnSearch.Text = "查找";
                    bnTop_btnSearch.Enabled = true;
                    bnTop_btnFilter.Visible = false;
                    bnTop_btnUnLock.Visible = false;

                    bnTop_lblDate.Text = "日期:";
                    bnTop_lblDate.Visible = true;
                    bnTop_lblTo.Visible = true;
                    _dateFrom.Visible = true;
                    _dateFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    _dateTo.Visible = true;
                    _dateTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
            }
        }
        #endregion

        #region 绑定数据源
        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <param name="pType">家在方式：1、重新加载数据源；2、改变_PageSize，重新计算 _CurrentPage；</param>
        private void DataSourceBinding(int pType)
        {
            if (pType == 1)//重新加载数据源
            {
                string strFilter = string.Empty;

                if (_FormId == FormID.PRD_INSTOCK)//领料
                    strFilter += "TO_CHAR(A.FDATE,'yyyy-mm-dd') BETWEEN '" + _dateFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + _dateTo.Value.ToString("yyyy-MM-dd") + "' AND";
                else if (_FormId == FormID.PRD_PPBOM || _FormId == FormID.PRD_PPBOM_DX)//调拨
                {
                    strFilter += "TO_CHAR(BE.FPLANSTARTDATE,'yyyy-mm-dd') = '" + _dateFrom.Value.ToString("yyyy-MM-dd") + "' AND";
                    if (_StockID != 0)
                        strFilter += " MSG.FSTOCKID = " + _StockID + " AND";
                    if (_DeptID != 0)
                        strFilter += " DEP.FDEPTID = " + _DeptID + " AND ";
                }
                else if (_ListFilter != null && _ListFilter.Count > 0)//锁库&运算
                    strFilter += "(" + GetFilter() + ") AND ";
                else
                {
                    MessageBox.Show("请设置筛选条件");
                    return;
                }
                _DataSource = DALCreator.SalOrder.GetDataSource(_FormId, strFilter, _OrderInf);

                if (_DataSource == null || _DataSource.Rows.Count == 0)
                {
                    dgv1.DataSource = null;
                    MessageBox.Show("没有查询到数据");
                    return;
                }

                _CurrentPage = 1;//当前页数从1开始
            }
            else if (pType == 2)//改变_PageSize，重新计算 _CurrentPage
            {
                _PageSize = int.Parse(bnB_cbxPageSize.ComboBox.SelectedValue.ToString());
                _CurrentPage = _Start / _PageSize + 1;
            }

            dgv1.DataSource = null;

            _RecordCount = _DataSource.Rows.Count;
            _PageCount = (_RecordCount / _PageSize);
            if ((_RecordCount % _PageSize) > 0)
                _PageCount++;

            _Start = _PageSize * (_CurrentPage - 1);
            if (_CurrentPage == _PageCount)
                _End = _RecordCount;
            else
                _End = _PageSize * _CurrentPage;

            _DataTemp = _DataSource.Clone();
            for (int i = _Start; i < _End; i++)
                _DataTemp.ImportRow(_DataSource.Rows[i]);

            bnB_txtCurrentPage.Text = _CurrentPage.ToString();
            bnB_lblPageCount.Text = string.Format("{0}页", _PageCount.ToString());
            bnB_lblRecordCount.Text = string.Format("{0}行", _RecordCount.ToString());

            bs1.DataSource = _DataTemp;

            //设置列头过滤功能
            if (_DataSource != null && _DataSource.Rows.Count > 0)
            {
                foreach (DataColumn col in _DataSource.Columns)
                {
                    DataGridViewAutoFilterTextBoxColumn filterColumn = new DataGridViewAutoFilterTextBoxColumn();
                    filterColumn.DataPropertyName = col.ColumnName;
                    filterColumn.HeaderText = col.ColumnName;
                    filterColumn.Resizable = DataGridViewTriState.True;
                    dgv1.Columns.Add(filterColumn);
                }

                bnBottom.BindingSource = bs1;
                dgv1.DataSource = bs1;

                _col.Visible = true;
                _chb.Visible = true;
                _chb.Checked = false;
                _chb.Location = new Point(dgv1.Rows[0].HeaderCell.Size.Width + 8, 2);
            }
            else
            {
                _col.Visible = false;
                _chb.Visible = false;

                dgv1.DataSource = null;
            }
        }
        #endregion

        #region ItemFunc
        /// <summary>
        /// 添加过滤条件
        /// </summary>
        private void Filter()
        {
            frmFilter frm = new frmFilter(_ListFilter, _FilterName, _FormId, _OrderInf);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                _ListFilter = frm.ListFilter;
                _FilterName = frm.FilterName;

                _OrderInf = frm.OrderInf;
            }
        }
        /// <summary>
        /// 检查默认仓库
        /// </summary>
        private void Check()
        {
            dgv1.DataSource = null;

            if (DALCreator.PrdAllocation.SetDefaultStock(_dateFrom.Value, _FormId))
            {
                //更新中间仓
                DALCreator.PrdAllocation.UpdateMST_Tran();
                bnTop_btnSearch.Enabled = true;
                MessageBox.Show("所有物料已经设置默认仓库，可以做调拨单！");
                return;
            }
            else
            {
                bnTop_btnSearch.Enabled = false;
                frmSetDefaultStock frmSS = new frmSetDefaultStock(_dateFrom.Value.ToString("yyyy-MM-dd"), _FormId);
                frmSS.ShowDialog();
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        private void Search()
        {
            DataSourceBinding(1);

            //隐藏订单内码
            if (dgv1.Rows.Count > 0)
            {
                if (_FormId == FormID.SAL_SaleOrder)
                    dgv1.Columns[20].Visible = false;
                else if (_FormId == FormID.SAL_SaleOrderRun)
                {

                    dgv1.Columns[20].Visible = false;
                    dgv1.Columns[21].Visible = false;
                }

                //不允许重新排列
                for (int i = 0; i < dgv1.Columns.Count; i++)
                {
                    dgv1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }
        /// <summary>
        /// 清除列头筛选
        /// </summary>
        private void ShowAll()
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            DataGridViewAutoFilterColumnHeaderCell.RemoveFilter(dgv1);
        }
        /// <summary>
        /// 提交
        /// </summary>
        private void Commit()
        {
            if (!_TimerPara.PauseStatus && _FormId != FormID.PRD_PPBOM)//排除调拨
            {
                MessageBox.Show("请先暂停定时器：工具->定时器");
                return;
            }

            if (dgv1.DataSource == null || dgv1.Rows.Count < 1)
            {
                MessageBox.Show("没有数据！");
                return;
            }

            if (dgv1.IsCurrentCellDirty)
                dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit);//-----------------提交编辑状态的行，否则获取编辑之前的值。

            DataTable dtResult;
            DataRow dr;

            dtResult = new DataTable();
            dtResult.Columns.Add("单号");

            #region 倒冲领料
            if (_FormId == FormID.PRD_INSTOCK)//根据勾选生成倒冲领料单
            {
                //限制单一用户执行倒冲领料
                DataTable dtLock = DALCreator.CommFunction.GetLockObjectInfo("PICKMTL");

                if (dtLock == null || dtLock.Rows.Count == 0)//新增记录
                {
                    DALCreator.CommFunction.DM_LockObject_Add("PICKMTL", "FUNCTION", "限制只有一个用户操作倒冲领料", "PICKMTL");
                }
                else if (dtLock.Rows[0]["FSTATUS"].ToString() == "0")//没有占用锁库操作时，占用锁库操作
                {
                    DALCreator.CommFunction.UpdateLockStatus(1, "PICKMTL");
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
                        dr["单号"] = DALCreator.PrdPick.PickMtl(dgv1.Rows[i].Cells[3].Value.ToString());
                        dtResult.Rows.Add(dr);
                    }
                }

                if (dtResult.Rows.Count > 0)
                {
                    frmResult tmp = new frmResult(dtResult);
                    tmp.ShowDialog();
                    DataSourceBinding(1);
                }
                else
                {
                    MessageBox.Show("没有选择数据！");
                }

                //解除倒冲领料占用
                DALCreator.CommFunction.UpdateLockStatus(0, "PICKMTL");

                //操作日志
                string strBillNos = string.Empty;
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    strBillNos += "[" + dtResult.Rows[i]["单号"].ToString() + "]";
                }

                DALCreator.CommFunction.DM_Log_Local("倒冲领料", "辅助功能\\倒冲领料", strBillNos);
            }
            #endregion

            #region 直接调拨
            else if (_FormId == FormID.PRD_PPBOM || _FormId == FormID.PRD_PPBOM_DX)//生成直接调拨单
            {
                //限制单一用户执行调拨
                DataTable dtLock = DALCreator.CommFunction.GetLockObjectInfo("TRANS");

                if (dtLock == null || dtLock.Rows.Count == 0)//新增记录
                {
                    DALCreator.CommFunction.DM_LockObject_Add("TRANS", "FUNCTION", "限制只有一个用户操作调拨", "TRANS");
                }
                else if (dtLock.Rows[0]["FSTATUS"].ToString() == "0")//没有占用锁库操作时，占用锁库操作
                {
                    DALCreator.CommFunction.UpdateLockStatus(1, "TRANS");
                }
                else//存在操作记录
                {
                    MessageBox.Show("[" + dtLock.Rows[0]["FUSER"].ToString() + "]正在执行调拨，请稍后再使用。");
                    return;
                }

                try
                {
                    _Worker.RunWorkerAsync();
                    _Progress.ShowDialog();
                    DataSourceBinding(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误提示：\n\r" + ex.Message);
                    return;
                }

                //解除调拨占用
                DALCreator.CommFunction.UpdateLockStatus(0, "TRANS");
            }
            #endregion

            #region 锁库
            else if (_FormId == FormID.SAL_SaleOrder)//锁库
            {
                //记录勾选状态
                _ListCheckStatus = new List<CheckStatus>();

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    _ListCheckStatus.Add(new CheckStatus(i, Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value)));
                }

                _ListOrder = new ArrayList();
                OrderInfo entry;

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    if (dgv1.Rows[i].Cells[0].Value == null) continue;//未被勾选

                    entry = new OrderInfo();
                    entry.FBillNo = dgv1.Rows[i].Cells[1].Value.ToString();//销售订单编号
                    entry.FBillTypeId = dgv1.Rows[i].Cells[2].Value.ToString();//单据类型
                    entry.FMaterialCode = dgv1.Rows[i].Cells[6].Value.ToString();//物料编码
                    entry.FDocumentStatus = dgv1.Rows[i].Cells[18].Value.ToString();//
                    entry.FCloseStatus = dgv1.Rows[i].Cells[19].Value.ToString();//
                    entry.FEntryId = int.Parse(dgv1.Rows[i].Cells[20].Value.ToString());//销售订单分录内码
                    _ListOrder.Add(entry);//封装参与锁库的订单实体                        

                }
                if (_ListOrder.Count == 0)
                {
                    MessageBox.Show("没有选择锁库订单！");
                    return;
                }

                _Worker.RunWorkerAsync();
                _Progress.ShowDialog();

                //修改批量锁库状态
                DALCreator.SalOrder.UpdateBatchFlag(_ListOrder);

                DataSourceBinding(1);

                //还原勾选状态
                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    dgv1.Rows[i].Cells[0].Value = _ListCheckStatus[i].ChStatus;
                }

                //操作日志
                DALCreator.CommFunction.DM_Log_Local("锁库", "辅助功能\\锁库", "请查看锁库日志");
            }
            #endregion

            #region 运算
            else if (_FormId == FormID.SAL_SaleOrderRun)//订单运算
            {
                DataTable dtTran = _DataSource.Clone();

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    if (dgv1.Rows[i].Cells[0].Value != null && Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value))
                    {
                        //排除完全锁库订单或已锁库分录(在运算时排除)

                        //dtTran.ImportRow(dtSearch.Rows[i]);
                        dtTran.ImportRow((_DataSource.Select("订单内码=" + dgv1.Rows[i].Cells[21].Value.ToString()))[0]);
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
                    if (dtTran.Rows[i]["批量锁库"].ToString() == "否" && dtTran.Rows[i]["单据类型"].ToString() != "备货销售订单" && dtTran.Rows[i]["特殊"].ToString() != "1")//备货类型和非普通类型不用批量锁库也可以参与运算
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
                DataTable dtLock = DALCreator.CommFunction.DM_LockObjectInfo("ORDERRUN");
                if (dtLock == null || dtLock.Rows.Count == 0)//新增记录
                {
                    DALCreator.CommFunction.DM_LockObject_Add("T_SAL_ORDER", "TABLE", "限制只有一个用户操作订单运算", "ORDERRUN");
                }
                else if (dtLock.Rows[0]["FSTATUS"].ToString() == "0")//没有占用订单运算操作时，占用订单运算操作
                {
                    DALCreator.CommFunction.UpdateLockStatus(1, "ORDERRUN");
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
                    DALCreator.CommFunction.UpdateLockStatus(0, "ORDERRUN");
                }

                //操作日志
                DALCreator.CommFunction.DM_Log_Local("运算", "辅助功能\\运算", "请查看运算日志");
            }
            #endregion
        }
        /// <summary>
        /// 解锁、成品调拨
        /// </summary>
        private void UnLock()
        {
            if (_FormId == FormID.PRD_PPBOM)//成品调拨
            {
                frmCPDB frm = new frmCPDB();
                frm.Show(this);
            }
            else if (_FormId == FormID.SAL_SaleOrder)//销售订单解锁
            {
                if (dgv1.DataSource == null || dgv1.Rows.Count < 1)
                {
                    MessageBox.Show("没有数据！");
                    return;
                }

                //记录勾选状态
                _ListCheckStatus = new List<CheckStatus>();

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    _ListCheckStatus.Add(new CheckStatus(i, Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value)));
                }

                IList olist = new ArrayList();//销售订单实体
                OrderInfo entry;

                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    if (dgv1.Rows[i].Cells[0].Value != null && Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value))
                    {
                        entry = new OrderInfo();
                        entry.FBillNo = dgv1.Rows[i].Cells[1].Value.ToString();
                        entry.FMaterialCode = dgv1.Rows[i].Cells[6].Value.ToString();
                        entry.FLockQTY = double.Parse(dgv1.Rows[i].Cells[10].Value.ToString());
                        entry.FEntryId = int.Parse(dgv1.Rows[i].Cells[18].Value.ToString());
                        entry.FSTOCKORGCode = dgv1.Rows[i].Cells[5].Value.ToString();
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

                DataSourceBinding(1);

                //还原勾选状态
                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    dgv1.Rows[i].Cells[0].Value = _ListCheckStatus[i].ChStatus;
                }
            }
        }
        #endregion

        #region 过滤条件

        /// <summary>
        /// 获取过滤条件
        /// </summary>
        /// <returns></returns>
        private string GetFilter()
        {
            string retrunValue = string.Empty;
            string sLeft, sField, sCompare, sValue, sRight, sLogic;
            DataTable dtOrg = DALCreator.CommFunction.GetOrganization();
            DataTable dtBillType = DALCreator.CommFunction.GetBillType("SAL_SALEORDER");

            for (int i = 0; i < _ListFilter.Count; i++)
            {
                sLeft = sField = sCompare = sValue = sRight = sLogic = string.Empty;

                if (_ListFilter[i].Validation)
                {
                    //左括号
                    switch (_ListFilter[i].ParenthesesLeft)
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
                    switch (_ListFilter[i].Field)
                    {
                        case 1:
                            sField = "TO_CHAR(A.FDATE,'yyyy-mm-dd')";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 2:
                            sField = "TO_CHAR(A.FAPPROVEDATE,'yyyy-mm-dd')";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 3:
                            sField = "TO_CHAR(AE.FPLANSTARTDATE,'yyyy-mm-dd')";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 4:
                            sField = "A.FBILLNO";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 5:
                            sField = "MTL.FNumber";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;

                        case 6:
                            sField = "MTLL.FNAME";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 7:
                            sField = "AR.FPURJOINQTY";
                            sCompare = GetCompare(_ListFilter[i], false);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 8:
                            sField = "A.FSALEORGID";
                            sCompare = GetCompare(_ListFilter[i], true);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 9:
                            sField = "A.F_PAEZ_FACTORGID";
                            sCompare = GetCompare(_ListFilter[i], true);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 10:
                            sField = "AE.FSTOCKORGID";
                            sCompare = GetCompare(_ListFilter[i], true);
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        //
                        case 11:
                            sField = "A.FFULLLOCK";
                            sCompare = " = ";
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 12:
                            sField = "AE.FMRPTERMINATESTATUS";
                            sCompare = " = ";
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 13:
                            sField = "AE.FBATCHFLAG";
                            sCompare = " = ";
                            sValue = GetValue(_ListFilter[i], dtOrg);
                            break;
                        case 14:
                            sField = "A.FBILLTYPEID";
                            sCompare = GetCompare(_ListFilter[i], true);
                            sValue = GetValue(_ListFilter[i], dtBillType);
                            break;
                    }
                    //右括号
                    switch (_ListFilter[i].ParenthesesRight)
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
                    switch (_ListFilter[i].Logic)
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
                if (i == _ListFilter.Count - 1)
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
        /// <param name="pIsComboBox"></param>
        /// <returns></returns>
        private string GetCompare(Filter pFilter, bool pIsComboBox)
        {
            string retrunValue = string.Empty;

            if (pIsComboBox)
            {
                if (pFilter.Compare == 2)
                    retrunValue = " <> ";
                else
                    retrunValue = " = ";
            }
            else
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
                    case 11:
                        retrunValue = " IN ";
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
                        case 11:
                            string str = pFilter.FilterValue.FilterText.Replace("，", ",").Replace(",", "','");
                            retrunValue = "('" + str + "')";
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
            switch (_FormId)
            {
                case FormID.PRD_PPBOM:
                case FormID.PRD_PPBOM_DX:
                        Trans(sender, e);
                        break;
                case FormID.SAL_SaleOrder:
                    e.Result = LockStock(sender, e);
                    break;
            }
        }

        /// <summary>
        /// 进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            _Progress.SetNotifyInfo(e.ProgressPercentage, "执行进度:" + Convert.ToString(e.ProgressPercentage) + "%");
        }

        /// <summary>
        /// 进度条
        /// </summary>
        /// <param name="e"></param>
        /// <param name="pCount"></param>
        /// <param name="pCurrent"></param>
        private void ReportProgreess(DoWorkEventArgs e, int pCount, int pCurrent)
        {
            //控制进度条
            if (_Worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                _Worker.ReportProgress(pCurrent * 100 / pCount);//状态报告                      
                Thread.Sleep(1);//等待，用于UI刷新界面，很重要  
            }
        }

        /// <summary>
        /// 事件处理完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            _Progress.Close();
        }
        #endregion

        #region 直接调拨单

        /// <summary>
        /// 直接调拨单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Trans(object sender, DoWorkEventArgs e)
        {
            switch (_FormId)
            {
                case FormID.PRD_PPBOM:
                    {
                        #region 河南工厂调拨
                        string strBillNos, tmp;
                        strBillNos = string.Empty;

                        List<string> lstDep;//领料部门List
                        List<string> lstOutStock;//调出仓编码List
                        List<string> lstType;//调拨类型

                        List<string> lstDepSet = DALCreator.CommFunction.GetPickMtlDepartment();//获取已经设置的默认仓库

                        string strCondition = string.Empty, strConditionEx = string.Empty;//过滤条件，用于筛选或排除指定调出调入仓            
                        DataTable dtDir_Stock = DALCreator.CommFunction.GetDM_Dir_Stock();//获取指定仓调拨
                        if (dtDir_Stock != null && dtDir_Stock.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtDir_Stock.Rows.Count; i++)
                            {
                                if (i > 0)
                                {
                                    strCondition += "OR";
                                    strConditionEx += "AND";
                                }
                                strCondition += "(MST.FSTOCKID = " + dtDir_Stock.Rows[i]["OUTSTOCKID"].ToString() + " AND DEP.FINSTOCKID = " + dtDir_Stock.Rows[i]["INSTOCKID"].ToString() + ")";
                                strConditionEx += "(MST.FSTOCKID != " + dtDir_Stock.Rows[i]["OUTSTOCKID"].ToString() + " OR DEP.FINSTOCKID != " + dtDir_Stock.Rows[i]["INSTOCKID"].ToString() + ")";
                            }
                            strCondition = "(" + strCondition + ")";
                            strConditionEx = "(" + strConditionEx + ")";
                        }

                        DataTable dtPZ = DALCreator.PrdAllocation.GetTransPZ(_dateFrom.Value.ToString("yyyy-MM-dd"), _StockID, _DeptID);
                        DataTable dtZD = DALCreator.PrdAllocation.GetTransCL(_dateFrom.Value.ToString("yyyy-MM-dd"), _StockID, _DeptID, strCondition);
                        DataTable dtCL = DALCreator.PrdAllocation.GetTransCL(_dateFrom.Value.ToString("yyyy-MM-dd"), _StockID, _DeptID, strConditionEx, false);
                        DataTable dtCL_Tran = DALCreator.PrdAllocation.GetTransCL(_dateFrom.Value.ToString("yyyy-MM-dd"), _StockID, _DeptID, strConditionEx, true);
                        int iPZ = dtPZ == null ? 0 : dtPZ.Rows.Count;
                        int iZD = dtZD == null ? 0 : dtZD.Rows.Count;
                        int iCL = dtCL == null ? 0 : dtCL.Rows.Count;
                        int iCL_Tran = dtCL_Tran == null ? 0 : dtCL_Tran.Rows.Count;
                        int iCurrent = 0, iCount = iPZ + iZD + iCL + iCL_Tran;//当前执行数和总记录数

                        #region 盆子调拨

                        if (dtPZ == null || dtPZ.Rows.Count == 0)
                            goto CailiaoDiaobo;

                        lstOutStock = new List<string>();
                        lstType = new List<string>();
                        lstDep = new List<string>();
                        for (int i = 0; i < dtPZ.Rows.Count; i++)
                        {
                            if (!lstOutStock.Contains(dtPZ.Rows[i]["调出仓库编码"].ToString()))
                                lstOutStock.Add(dtPZ.Rows[i]["调出仓库编码"].ToString());
                            if (!lstType.Contains(dtPZ.Rows[i]["调拨类型"].ToString()))
                                lstType.Add(dtPZ.Rows[i]["调拨类型"].ToString());
                            if (!lstDep.Contains(dtPZ.Rows[i]["领料部门编码"].ToString()) && lstDepSet.Contains(dtPZ.Rows[i]["领料部门编码"].ToString()))
                                lstDep.Add(dtPZ.Rows[i]["领料部门编码"].ToString());
                        }

                        int iMaxQtyPZ = int.Parse(AppConfig.ReadValue("DIR_MaxQtyPZ", "AppSettings")), iPianYiPZ = int.Parse(AppConfig.ReadValue("DIR_PianYiPZ", "AppSettings"));
                        if (iMaxQtyPZ <= 0)
                        {
                            MessageBox.Show("每张单最大数量不能小于等于零。");
                            return;
                        }
                        bool bIsUsePZ = AppConfig.ReadValue("DIR_IsUsePZ", "AppSettings").ToString() == "1" ? true : false;

                        #region 启用盆子数量控制

                        if (bIsUsePZ)
                        {
                            for (int i = 0; i < lstOutStock.Count; i++)//根据不同的调出仓库
                            {
                                DataTable dt_2 = dtPZ.Clone();
                                for (int j = 0; j < dtPZ.Rows.Count; j++)
                                {
                                    if (lstOutStock[i] == dtPZ.Rows[j]["调出仓库编码"].ToString())
                                        dt_2.ImportRow(dtPZ.Rows[j]);
                                }
                                if (dt_2.Rows.Count > 0)
                                {
                                    for (int m = 0; m < lstDep.Count; m++)//根据不同的领料部门
                                    {
                                        DataTable dt_3 = dtPZ.Clone();
                                        for (int n = 0; n < dt_2.Rows.Count; n++)
                                        {
                                            if (lstDep[m] == dt_2.Rows[n]["领料部门编码"].ToString())
                                                dt_3.ImportRow(dt_2.Rows[n]);
                                        }
                                        if (dt_3.Rows.Count > 0)
                                        {
                                            for (int p = 0; p < lstType.Count; p++)//根据不同的调拨类型
                                            {
                                                DataTable dt_4 = dtPZ.Clone();
                                                for (int q = 0; q < dt_3.Rows.Count; q++)
                                                {
                                                    if (lstType[p] == dt_3.Rows[q]["调拨类型"].ToString())
                                                        dt_4.ImportRow(dt_3.Rows[q]);
                                                }

                                                if (dt_4.Rows.Count > 0)
                                                {
                                                    int iSumDD = 0;
                                                    DataTable dtPZ_DD, dtPZ_XD;
                                                    dtPZ_DD = dtPZ.Clone();
                                                    dtPZ_XD = dtPZ.Clone();

                                                    for (int j = 0; j < dt_4.Rows.Count; j++)
                                                    {
                                                        if (dt_4.Rows[j]["大单"].ToString() == "1")
                                                        {
                                                            dtPZ_DD.ImportRow(dt_4.Rows[j]);
                                                            iSumDD += int.Parse(dt_4.Rows[j]["调拨数量"].ToString());
                                                        }
                                                        else
                                                            dtPZ_XD.ImportRow(dt_4.Rows[j]);
                                                    }

                                                    #region 需要区分大单生成调拨单
                                                    if (iSumDD > 0 && iSumDD >= GlobalParameter.Dir_MinQtyPZ)
                                                    {
                                                        //其他盆子正常生成调拨单
                                                        if (dtPZ_XD.Rows.Count > 0)
                                                        {
                                                            int iSumQtyPZ = int.Parse(dtPZ_XD.Rows[0]["合并数量"].ToString());
                                                            string strSEQ = dtPZ_XD.Rows[0]["生产顺序号"].ToString();
                                                            DataTable dtPZ_2 = dt_4.Clone();
                                                            dtPZ_2.ImportRow(dtPZ_XD.Rows[0]);

                                                            if (dtPZ_XD.Rows.Count == 1)
                                                            {
                                                                tmp = DALCreator.PrdAllocation.TransferDir(dtPZ_XD, _dateFrom.Value.ToString("yyyy-MM-dd"));

                                                                iCurrent++;
                                                                ReportProgreess(e, iCount, iCurrent);

                                                                if (tmp != "")
                                                                    strBillNos += "[" + tmp + "]";
                                                            }
                                                            else
                                                            {
                                                                for (int j = 1; j < dtPZ_XD.Rows.Count; j++)
                                                                {
                                                                    if (j == dtPZ_XD.Rows.Count - 1)//最后一行数据,(盘子必然在最后一套之内)
                                                                    {
                                                                        dtPZ_2.ImportRow(dtPZ_XD.Rows[j]);
                                                                        tmp = DALCreator.PrdAllocation.TransferDir(dtPZ_2, _dateFrom.Value.ToString("yyyy-MM-dd"));

                                                                        iCurrent++;
                                                                        ReportProgreess(e, iCount, iCurrent);

                                                                        if (tmp != "")
                                                                            strBillNos += "[" + tmp + "]";
                                                                    }
                                                                    else if (strSEQ == dtPZ_XD.Rows[j]["生产顺序号"].ToString())
                                                                    {
                                                                        dtPZ_2.ImportRow(dtPZ_XD.Rows[j]);
                                                                    }
                                                                    else
                                                                    {
                                                                        //判断累计另一套盘子的数量后是否超出设置数量及允许偏移值
                                                                        if (iSumQtyPZ + int.Parse(dtPZ_XD.Rows[j]["合并数量"].ToString()) <= iMaxQtyPZ || iSumQtyPZ + int.Parse(dtPZ_XD.Rows[j]["合并数量"].ToString()) - iMaxQtyPZ <= iPianYiPZ)//指定最大数量范围及偏移值之内
                                                                        {
                                                                            dtPZ_2.ImportRow(dtPZ_XD.Rows[j]);
                                                                            iSumQtyPZ += int.Parse(dtPZ_XD.Rows[j]["合并数量"].ToString());//累计盘子套数
                                                                            strSEQ = dtPZ_XD.Rows[j]["生产顺序号"].ToString();//设置新的生产顺序号变量
                                                                        }
                                                                        else
                                                                        {
                                                                            tmp = DALCreator.PrdAllocation.TransferDir(dtPZ_2, _dateFrom.Value.ToString("yyyy-MM-dd"));

                                                                            iCurrent++;
                                                                            ReportProgreess(e, iCount, iCurrent);

                                                                            if (tmp != "")
                                                                                strBillNos += "[" + tmp + "]";

                                                                            dtPZ_2 = dtPZ_XD.Clone();
                                                                            dtPZ_2.ImportRow(dtPZ_XD.Rows[j]);

                                                                            iSumQtyPZ = int.Parse(dtPZ_XD.Rows[j]["合并数量"].ToString());//重新计算新单据的调拨累计数量
                                                                            strSEQ = dtPZ_XD.Rows[j]["生产顺序号"].ToString();//重新赋值新单据的生产顺序号变量
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }

                                                        //大单单独生成调拨单
                                                        tmp = DALCreator.PrdAllocation.TransferDir(dtPZ_DD, _dateFrom.Value.ToString("yyyy-MM-dd"));

                                                        iCurrent++;
                                                        ReportProgreess(e, iCount, iCurrent);

                                                        if (tmp != "")
                                                            strBillNos += "[" + tmp + "]";
                                                    }
                                                    #endregion

                                                    #region 不需要区分大单
                                                    else
                                                    {
                                                        int iSumQtyPZ = int.Parse(dt_4.Rows[0]["合并数量"].ToString());
                                                        string strSEQ = dt_4.Rows[0]["生产顺序号"].ToString();
                                                        DataTable dtPZ_2 = dtPZ.Clone();
                                                        dtPZ_2.ImportRow(dt_4.Rows[0]);

                                                        if (dt_4.Rows.Count == 1)
                                                        {
                                                            tmp = DALCreator.PrdAllocation.TransferDir(dt_4, _dateFrom.Value.ToString("yyyy-MM-dd"));

                                                            iCurrent++;
                                                            ReportProgreess(e, iCount, iCurrent);

                                                            if (tmp != "")
                                                                strBillNos += "[" + tmp + "]";
                                                        }
                                                        else
                                                        {
                                                            for (int j = 1; j < dt_4.Rows.Count; j++)
                                                            {
                                                                if (j == dt_4.Rows.Count - 1)//最后一行数据,(盘子必然在最后一套之内)
                                                                {
                                                                    dtPZ_2.ImportRow(dt_4.Rows[j]);
                                                                    tmp = DALCreator.PrdAllocation.TransferDir(dtPZ_2, _dateFrom.Value.ToString("yyyy-MM-dd"));

                                                                    iCurrent++;
                                                                    ReportProgreess(e, iCount, iCurrent);

                                                                    if (tmp != "")
                                                                        strBillNos += "[" + tmp + "]";
                                                                }
                                                                else if (strSEQ == dt_4.Rows[j]["生产顺序号"].ToString())
                                                                {
                                                                    dtPZ_2.ImportRow(dt_4.Rows[j]);
                                                                }
                                                                else
                                                                {
                                                                    //判断累计另一套盘子的数量后是否超出设置数量及允许偏移值
                                                                    if (iSumQtyPZ + int.Parse(dt_4.Rows[j]["合并数量"].ToString()) <= iMaxQtyPZ || iSumQtyPZ + int.Parse(dt_4.Rows[j]["合并数量"].ToString()) - iMaxQtyPZ <= iPianYiPZ)//指定最大数量范围及偏移值之内
                                                                    {
                                                                        dtPZ_2.ImportRow(dt_4.Rows[j]);
                                                                        iSumQtyPZ += int.Parse(dt_4.Rows[j]["合并数量"].ToString());//累计盘子套数
                                                                        strSEQ = dt_4.Rows[j]["生产顺序号"].ToString();//设置新的生产顺序号变量
                                                                    }
                                                                    else
                                                                    {
                                                                        tmp = DALCreator.PrdAllocation.TransferDir(dtPZ_2, _dateFrom.Value.ToString("yyyy-MM-dd"));

                                                                        iCurrent++;
                                                                        ReportProgreess(e, iCount, iCurrent);

                                                                        if (tmp != "")
                                                                            strBillNos += "[" + tmp + "]";

                                                                        dtPZ_2 = dtPZ.Clone();
                                                                        dtPZ_2.ImportRow(dt_4.Rows[j]);

                                                                        iSumQtyPZ = int.Parse(dt_4.Rows[j]["合并数量"].ToString());//重新计算新单据的调拨累计数量
                                                                        strSEQ = dt_4.Rows[j]["生产顺序号"].ToString();//重新赋值新单据的生产顺序号变量
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    #endregion
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        #region 未启用盆子数量控制
                        else
                        {
                            for (int i = 0; i < lstOutStock.Count; i++)//根据不同的调出仓库
                            {
                                DataTable dt_2 = dtPZ.Clone();
                                for (int j = 0; j < dtPZ.Rows.Count; j++)
                                {
                                    if (lstOutStock[i] == dtPZ.Rows[j]["调出仓库编码"].ToString())
                                        dt_2.ImportRow(dtPZ.Rows[j]);
                                }
                                if (dt_2.Rows.Count > 0)
                                {
                                    for (int m = 0; m < lstDep.Count; m++)//根据不同的领料部门
                                    {
                                        DataTable dt_3 = dtPZ.Clone();
                                        for (int n = 0; n < dt_2.Rows.Count; n++)
                                        {
                                            if (lstDep[m] == dt_2.Rows[n]["领料部门编码"].ToString())
                                                dt_3.ImportRow(dt_2.Rows[n]);
                                        }
                                        if (dt_3.Rows.Count > 0)
                                        {
                                            for (int p = 0; p < lstType.Count; p++)//根据不同的调拨类型
                                            {
                                                DataTable dt_4 = dtPZ.Clone();
                                                for (int q = 0; q < dt_3.Rows.Count; q++)
                                                {
                                                    if (lstType[p] == dt_3.Rows[q]["调拨类型"].ToString())
                                                        dt_4.ImportRow(dt_3.Rows[q]);
                                                }

                                                if (dt_4.Rows.Count > 0)
                                                {
                                                    tmp = DALCreator.PrdAllocation.TransferDir(dt_4, _dateFrom.Value.ToString("yyyy-MM-dd"));

                                                    iCurrent++;
                                                    ReportProgreess(e, iCount, iCurrent);

                                                    if (tmp != "")
                                                        strBillNos += "[" + tmp + "]";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        #endregion

                        CailiaoDiaobo:

                        #region 材料调拨

                        #region 处理指定仓调拨
                        if (dtZD != null && dtZD.Rows.Count > 0)
                        {
                            tmp = DALCreator.PrdAllocation.TransferDirERP(dtZD, _dateFrom.Value);
                            iCurrent++;
                            ReportProgreess(e, iCount, iCurrent);

                            if (tmp != "")
                                strBillNos += "[" + tmp + "]";
                        }
                        #endregion

                        #region 处理没有中间仓 
                        if (dtCL == null || dtCL.Rows.Count == 0)
                            goto Transit;

                        lstOutStock = new List<string>();
                        lstType = new List<string>();
                        lstDep = new List<string>();
                        for (int i = 0; i < dtCL.Rows.Count; i++)
                        {
                            if (!lstOutStock.Contains(dtCL.Rows[i]["调出仓库编码"].ToString()))
                                lstOutStock.Add(dtCL.Rows[i]["调出仓库编码"].ToString());
                            if (!lstType.Contains(dtCL.Rows[i]["调拨类型"].ToString()))
                                lstType.Add(dtCL.Rows[i]["调拨类型"].ToString());
                            if (!lstDep.Contains(dtCL.Rows[i]["领料部门编码"].ToString()) && lstDepSet.Contains(dtCL.Rows[i]["领料部门编码"].ToString()))
                                lstDep.Add(dtCL.Rows[i]["领料部门编码"].ToString());
                        }

                        for (int i = 0; i < lstOutStock.Count; i++)//根据不同的调出仓库
                        {
                            DataTable dt_2 = dtCL.Clone();
                            for (int j = 0; j < dtCL.Rows.Count; j++)
                            {
                                if (lstOutStock[i] == dtCL.Rows[j]["调出仓库编码"].ToString())
                                    dt_2.ImportRow(dtCL.Rows[j]);
                            }
                            if (dt_2.Rows.Count > 0)
                            {
                                for (int m = 0; m < lstDep.Count; m++)//根据不同的领料部门
                                {
                                    DataTable dt_3 = dtCL.Clone();
                                    for (int n = 0; n < dt_2.Rows.Count; n++)
                                    {
                                        if (lstDep[m] == dt_2.Rows[n]["领料部门编码"].ToString())
                                            dt_3.ImportRow(dt_2.Rows[n]);
                                    }
                                    if (dt_3.Rows.Count > 0)
                                    {
                                        for (int p = 0; p < lstType.Count; p++)//根据不同的调拨类型
                                        {
                                            DataTable dt_4 = dtCL.Clone();
                                            for (int q = 0; q < dt_3.Rows.Count; q++)
                                            {
                                                if (lstType[p] == dt_3.Rows[q]["调拨类型"].ToString())
                                                    dt_4.ImportRow(dt_3.Rows[q]);
                                            }

                                            if (dt_4.Rows.Count > 0)
                                            {
                                                tmp = DALCreator.PrdAllocation.TransferDir(dt_4, _dateFrom.Value.ToString("yyyy-MM-dd"));

                                                iCurrent++;
                                                ReportProgreess(e, iCount, iCurrent);

                                                if (tmp != "")
                                                    strBillNos += "[" + tmp + "]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        Transit:
                        #region 处理有中间仓
                        //dtCL_Tran = PrdAllocation.GetTransCL(_dateFrom.Value.ToString("yyyy-MM-dd"), _StockID, _DeptID, strConditionEx, true);
                        if (dtCL_Tran == null || dtCL_Tran.Rows.Count == 0)
                            goto SHOW;

                        lstOutStock = new List<string>();
                        lstType = new List<string>();
                        lstDep = new List<string>();
                        for (int i = 0; i < dtCL_Tran.Rows.Count; i++)
                        {
                            if (!lstOutStock.Contains(dtCL_Tran.Rows[i]["调出仓库编码"].ToString()))
                                lstOutStock.Add(dtCL_Tran.Rows[i]["调出仓库编码"].ToString());
                            if (!lstType.Contains(dtCL_Tran.Rows[i]["调拨类型"].ToString()))
                                lstType.Add(dtCL_Tran.Rows[i]["调拨类型"].ToString());
                            if (!lstDep.Contains(dtCL_Tran.Rows[i]["领料部门编码"].ToString()) && lstDepSet.Contains(dtCL_Tran.Rows[i]["领料部门编码"].ToString()))
                                lstDep.Add(dtCL_Tran.Rows[i]["领料部门编码"].ToString());
                        }

                        for (int i = 0; i < lstOutStock.Count; i++)//根据不同的调出仓库
                        {
                            DataTable dt_2 = dtCL_Tran.Clone();
                            for (int j = 0; j < dtCL_Tran.Rows.Count; j++)
                            {
                                if (lstOutStock[i] == dtCL_Tran.Rows[j]["调出仓库编码"].ToString())
                                    dt_2.ImportRow(dtCL_Tran.Rows[j]);
                            }
                            if (dt_2.Rows.Count > 0)
                            {
                                for (int m = 0; m < lstDep.Count; m++)//根据不同的领料部门
                                {
                                    DataTable dt_3 = dtCL_Tran.Clone();
                                    for (int n = 0; n < dt_2.Rows.Count; n++)
                                    {
                                        if (lstDep[m] == dt_2.Rows[n]["领料部门编码"].ToString())
                                            dt_3.ImportRow(dt_2.Rows[n]);
                                    }
                                    if (dt_3.Rows.Count > 0)
                                    {
                                        for (int p = 0; p < lstType.Count; p++)//根据不同的调拨类型
                                        {
                                            DataTable dt_4 = dtCL_Tran.Clone();
                                            for (int q = 0; q < dt_3.Rows.Count; q++)
                                            {
                                                if (lstType[p] == dt_3.Rows[q]["调拨类型"].ToString())
                                                    dt_4.ImportRow(dt_3.Rows[q]);
                                            }

                                            if (dt_4.Rows.Count > 0)
                                            {
                                                //生成单据-WMS（调出仓库->中间仓）
                                                tmp = DALCreator.PrdAllocation.TransferDir(dt_4, _dateFrom.Value.ToString("yyyy-MM-dd"), true);

                                                //生成单据-ERP（中间仓->调入仓库）
                                                tmp += " " + DALCreator.PrdAllocation.TransferDirERP(dt_4, _dateFrom.Value);

                                                iCurrent++;
                                                ReportProgreess(e, iCount, iCurrent);

                                                if (tmp.Trim() != "")
                                                    strBillNos += "[" + tmp + "]";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        #endregion

                        SHOW:
                        if (strBillNos != "")
                        {
                            DALCreator.PrdAllocation.UpdateDirFieldsCL(_dateFrom.Value.ToString("yyyy-MM-dd"));//更新【已经生成调拨单】状态
                            MessageBox.Show("直接调拨单：" + strBillNos);
                        }
                        else
                            MessageBox.Show("没有数据或者未设置领料部门！");
                        #endregion
                    }
                    break;
                case FormID.PRD_PPBOM_DX:
                    {
                        #region 德旭调拨
                        string strBillNos = string.Empty, tmp;
                        DataTable dtCL = DALCreator.PrdAllocation.GetTransCL(_dateFrom.Value.ToString("yyyy-MM-dd"), 0, 0, "", false, 492501088);
                        if (dtCL == null || dtCL.Rows.Count == 0)
                            goto SHOW2;

                        int iCurrent = 0, iCount = dtCL == null ? 0 : dtCL.Rows.Count;

                        List<string> lstDep;//领料部门List
                        List<string> lstOutStock;//调出仓编码List
                        List<string> lstDepSet = DALCreator.CommFunction.GetPickMtlDepartment(492501088);

                        //dtCL.Columns.Add("部门分组");

                        lstOutStock = new List<string>();
                        lstDep = new List<string>();
                        for (int i = 0; i < dtCL.Rows.Count; i++)
                        {
                            if (!lstOutStock.Contains(dtCL.Rows[i]["调出仓库编码"].ToString()))
                                lstOutStock.Add(dtCL.Rows[i]["调出仓库编码"].ToString());

                            if (lstDepSet.Contains(dtCL.Rows[i]["领料部门分组编码"].ToString()))
                            {
                                if (!lstDep.Contains(dtCL.Rows[i]["领料部门分组编码"].ToString()))
                                    lstDep.Add(dtCL.Rows[i]["领料部门分组编码"].ToString());
                            }
                            else if (lstDepSet.Contains(dtCL.Rows[i]["领料部门编码"].ToString()))
                            {
                                if (!lstDep.Contains(dtCL.Rows[i]["领料部门编码"].ToString()))
                                    lstDep.Add(dtCL.Rows[i]["领料部门编码"].ToString());
                            }
                        }

                        for (int i = 0; i < lstOutStock.Count; i++)//根据不同的调出仓库
                        {
                            DataTable dt_2 = dtCL.Clone();
                            for (int j = 0; j < dtCL.Rows.Count; j++)
                            {
                                if (lstOutStock[i] == dtCL.Rows[j]["调出仓库编码"].ToString())
                                    dt_2.ImportRow(dtCL.Rows[j]);
                            }
                            if (dt_2.Rows.Count > 0)
                            {
                                for (int m = 0; m < lstDep.Count; m++)//根据不同的领料部门
                                {
                                    DataTable dt_3 = dtCL.Clone();
                                    for (int n = 0; n < dt_2.Rows.Count; n++)
                                    {
                                        if (lstDep[m] == dt_2.Rows[n]["领料部门编码"].ToString() || lstDep[m] == dt_2.Rows[n]["领料部门分组编码"].ToString())
                                            dt_3.ImportRow(dt_2.Rows[n]);
                                    }
                                    if (dt_3.Rows.Count > 0)
                                    {
                                        tmp = DALCreator.PrdAllocation.TransferDirERP(dt_3, _dateFrom.Value, _FormId);

                                        iCurrent++;
                                        ReportProgreess(e, iCount, iCurrent);

                                        if (tmp != "")
                                            strBillNos += "[" + tmp + "]";
                                    }
                                }
                            }
                        }

                        SHOW2:
                        if (strBillNos != "")
                        {
                            DALCreator.PrdAllocation.UpdateDirFieldsCL(_dateFrom.Value.ToString("yyyy-MM-dd"), 492501088);//更新【已经生成调拨单】状态
                            MessageBox.Show("直接调拨单：" + strBillNos);
                        }
                        else
                            MessageBox.Show("没有数据或者未设置领料部门！");
                        #endregion
                    }
                    break;
                default:
                    break;
            }
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

            if (_ListOrder.Count == 0) goto ShowResult;

            //占用锁库操作
            DataTable dtLock = DALCreator.CommFunction.GetLockObjectInfo("LOCKSTOCK");

            if (dtLock == null || dtLock.Rows.Count == 0)//新增记录
            {
                DALCreator.CommFunction.DM_LockObject_Add("T_SAL_ORDER", "TABLE", "限制只有一个用户操作订单锁库", "LOCKSTOCK");
            }
            else if (dtLock.Rows[0]["FSTATUS"].ToString() == "0")//没有占用锁库操作时，占用锁库操作
            {
                DALCreator.CommFunction.UpdateLockStatus(1, "LOCKSTOCK");
            }
            else//存在锁表操作记录
            {
                MessageBox.Show("[" + dtLock.Rows[0]["FUSER"].ToString() + "]正在执行操作锁库，请稍后再使用。");
                return -1;
            }

            for (int i = 0; i < _ListOrder.Count; i++)
            {
                dt = new DataTable();
                dt = DALCreator.SalOrder.GetOrderLockByFEntryId(((OrderInfo)_ListOrder[i]).FEntryId);

                if (dt == null || dt.Rows.Count == 0)//锁库失败信息
                {
                    dr = ReturnDT.NewRow();
                    dr["操作"] = "失败";
                    dr["销售订单"] = ((OrderInfo)_ListOrder[i]).FBillNo;
                    dr["物料编码"] = ((OrderInfo)_ListOrder[i]).FMaterialCode;
                    dr["仓库"] = "";
                    dr["信息"] = "没有库存信息";
                    ReturnDT.Rows.Add(dr);

                    //锁库失败记录日志
                    DALCreator.SalOrder.Log_OrderLock((OrderInfo)_ListOrder[i], 1, "没有库存信息");
                }
                else
                {
                    if (((OrderInfo)_ListOrder[i]).FDocumentStatus != "已审核")//备货销售订单不需要锁库
                    {
                        dr = ReturnDT.NewRow();
                        dr["操作"] = "失败";
                        dr["销售订单"] = ((OrderInfo)_ListOrder[i]).FBillNo;
                        dr["物料编码"] = ((OrderInfo)_ListOrder[i]).FMaterialCode;
                        dr["仓库"] = "";
                        dr["信息"] = "单据未审核。";
                        ReturnDT.Rows.Add(dr);

                        //锁库失败记录日志
                        DALCreator.SalOrder.Log_OrderLock((OrderInfo)_ListOrder[i], 1, "单据状态不为[已审核]");
                        continue;
                    }
                    if (((OrderInfo)_ListOrder[i]).FCloseStatus != "正常")//备货销售订单不需要锁库
                    {
                        dr = ReturnDT.NewRow();
                        dr["操作"] = "失败";
                        dr["销售订单"] = ((OrderInfo)_ListOrder[i]).FBillNo;
                        dr["物料编码"] = ((OrderInfo)_ListOrder[i]).FMaterialCode;
                        dr["仓库"] = "";
                        dr["信息"] = "单据已经关闭。";
                        ReturnDT.Rows.Add(dr);

                        //锁库失败记录日志
                        DALCreator.SalOrder.Log_OrderLock((OrderInfo)_ListOrder[i], 1, "单据已经关闭");
                        continue;
                    }

                    if (((OrderInfo)_ListOrder[i]).FBillTypeId == "备货销售订单")//备货销售订单不需要锁库
                    {
                        dr = ReturnDT.NewRow();
                        dr["操作"] = "失败";
                        dr["销售订单"] = ((OrderInfo)_ListOrder[i]).FBillNo;
                        dr["物料编码"] = ((OrderInfo)_ListOrder[i]).FMaterialCode;
                        dr["仓库"] = "";
                        dr["信息"] = "备货销售订单。";
                        ReturnDT.Rows.Add(dr);

                        //锁库失败记录日志
                        DALCreator.SalOrder.Log_OrderLock((OrderInfo)_ListOrder[i], 1, "备货销售订单");
                        continue;
                    }

                    double dCanLockQty = double.Parse(dt.Rows[0]["最大可锁数量"].ToString());//可锁库数量

                    if (dCanLockQty <= 0)//可锁库数量小于等于零时不需要锁库
                    {
                        dr = ReturnDT.NewRow();
                        dr["操作"] = "失败";
                        dr["销售订单"] = ((OrderInfo)_ListOrder[i]).FBillNo;
                        dr["物料编码"] = ((OrderInfo)_ListOrder[i]).FMaterialCode;
                        dr["仓库"] = "";
                        dr["信息"] = "可锁数量小于等于零";
                        ReturnDT.Rows.Add(dr);

                        //锁库失败记录日志
                        DALCreator.SalOrder.Log_OrderLock((OrderInfo)_ListOrder[i], 1, "可锁数量小于等于零");
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
                        dr["销售订单"] = ((OrderInfo)_ListOrder[i]).FBillNo;
                        dr["物料编码"] = ((OrderInfo)_ListOrder[i]).FMaterialCode;
                        dr["仓库"] = "";
                        dr["信息"] = "库存可用量为零";
                        ReturnDT.Rows.Add(dr);

                        //锁库失败记录日志
                        DALCreator.SalOrder.Log_OrderLock((OrderInfo)_ListOrder[i], 1, "库存可用量为零");
                        continue;
                    }

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        double dQTY = double.Parse(dt.Rows[j]["可用量"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[j]["可用量"].ToString());//第i行 库存可用数量

                        if (dQTY <= 0) continue;
                        if (dQTY >= dCanLockQty)//当库存可用量大于或等于可锁库数量时可参与锁库
                        {
                            //添加预留关系
                            if (DALCreator.SalOrder.AddReserveLink(dt.Rows[j], dCanLockQty).IndexOf("FID") < 0)
                                continue;

                            DALCreator.SalOrder.UpdateOrderLock(dCanLockQty.ToString(), int.Parse(dt.Rows[0]["FID"].ToString()), int.Parse(dt.Rows[0]["FENTRYID"].ToString()));

                            //库存锁库列表（销售订单->锁库查询）

                            //新增锁库日志
                            dt.Rows[j]["锁库数量"] = dCanLockQty.ToString();
                            DALCreator.SalOrder.Log_OrderLock(dt.Rows[j], 1);

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
                            if (DALCreator.SalOrder.AddReserveLink(dt.Rows[j], dQTY).IndexOf("FID") < 0)
                                continue;

                            //修改销售订单锁库/预留数量(库存单位)、待锁库/待预留数量(库存单位)FLEFTQTY、批量锁库标识
                            DALCreator.SalOrder.UpdateOrderLock(dQTY.ToString(), int.Parse(dt.Rows[0]["FENTRYID"].ToString()));

                            //库存锁库列表（销售订单->锁库查询）

                            //新增锁库日志
                            dt.Rows[j]["锁库数量"] = dQTY.ToString();
                            DALCreator.SalOrder.Log_OrderLock(dt.Rows[j], 1);

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
                if (_Worker.CancellationPending)
                {
                    e.Cancel = true;
                    goto ShowResult;
                }
                else
                {
                    _Worker.ReportProgress((i + 1) * 100 / _ListOrder.Count);
                    Thread.Sleep(1);
                }
            }

            //Remark
            ShowResult:
            frmLockStockResult lsr = new frmLockStockResult(ReturnDT);
            lsr.ShowDialog();

            //解除锁表标志
            DALCreator.CommFunction.UpdateLockStatus(0, "LOCKSTOCK");

            return -1;
        }
        #endregion

        #region 解锁
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
                    dr["物料编码"] = ((OrderInfo)pList[i]).FMaterialCode;
                    dr["信息"] = "解锁数量:0";
                    ReturnDT.Rows.Add(dr);
                    //continue;
                }
                else
                {
                    DALCreator.SalOrder.UnLockSalOrder(dLockQTY.ToString(), ((OrderInfo)pList[i]).FEntryId);

                    dr["操作"] = "解锁成功";
                    dr["销售订单"] = ((OrderInfo)pList[i]).FBillNo;
                    dr["物料编码"] = ((OrderInfo)pList[i]).FMaterialCode;
                    dr["信息"] = "解锁数量:" + dLockQTY.ToString();
                    ReturnDT.Rows.Add(dr);
                }

                //解锁日志
                DALCreator.SalOrder.Log_OrderLock(dr, 0);
            }

            return ReturnDT;
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
                DALCreator.CommFunction.DM_Log_Local("注销系统", "主窗口", "关闭主窗体并注销用户");//日志

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
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTool_Config_Click(object sender, EventArgs e)
        {
            frmTool_Setting st = new frmTool_Setting(2);
            st.ShowDialog();

            if (st.Logout)
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
            frmTool_Parameter frm = new frmTool_Parameter();
            frm.ShowDialog();
        }

        /// <summary>
        /// 解除倒冲领料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiTool_Occupy_PickMtl_Click(object sender, EventArgs e)
        {
            object oUser = DALCreator.CommFunction.GetLockObjectInfo("PICKMTL", 1);

            if (oUser == null)
            {
                MessageBox.Show("倒冲领料未被占用。");
            }
            else
            {
                if (MessageBox.Show("倒冲领料操作被[" + oUser.ToString() + "]占用\n确定要强行解除吗？", "占用解除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DALCreator.CommFunction.UpdateLockStatus(0, "PICKMTL");
                    //操作日志
                    DALCreator.CommFunction.DM_Log_Local("解除冲突", "菜单->工具->占用解除", "解除倒冲领料");
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
            object oUser = DALCreator.CommFunction.GetLockObjectInfo("TRANS", 1);

            if (oUser == null)
            {
                MessageBox.Show("调拨未被占用。");
            }
            else
            {
                if (MessageBox.Show("调拨操作被[" + oUser.ToString() + "]占用\n确定要强行解除吗？", "占用解除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DALCreator.CommFunction.UpdateLockStatus(0, "TRANS");
                    //操作日志
                    DALCreator.CommFunction.DM_Log_Local("解除冲突", "菜单->工具->占用解除", "解除调拨");
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
            object oUser = DALCreator.CommFunction.GetLockObjectInfo("LOCKSTOCK", 1);

            if (oUser == null)
            {
                MessageBox.Show("锁库操作未被占用。");
            }
            else
            {
                if (MessageBox.Show("锁库操作被[" + oUser.ToString() + "]占用\n确定要强行解除吗？", "占用解除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DALCreator.CommFunction.UpdateLockStatus(0, "LOCKSTOCK");
                    //操作日志
                    DALCreator.CommFunction.DM_Log_Local("解除冲突", "菜单->工具->占用解除", "解除锁库占用");
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
            object oUser = DALCreator.CommFunction.GetLockObjectInfo("ORDERRUN", 1);

            if (oUser == null)
            {
                MessageBox.Show("订单运算操作未被占用。");
            }
            else
            {
                if (MessageBox.Show("订单运算操作被[" + oUser.ToString() + "]占用\n确定要强行解除吗？", "占用解除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DALCreator.CommFunction.UpdateLockStatus(0, "ORDERRUN");
                    //操作日志
                    DALCreator.CommFunction.DM_Log_Local("解除冲突", "菜单->工具->占用解除", "解除订单运算占用");
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
            object oUser = DALCreator.CommFunction.GetLockObjectInfo("LOCKPICKMTL", 1);

            if (oUser == null)
            {
                MessageBox.Show("自动领料未被占用。");
            }
            else
            {
                if (MessageBox.Show("自动领料操作被[" + oUser.ToString() + "]占用\n确定要强行解除吗？", "占用解除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DALCreator.CommFunction.UpdateLockStatus(0, "LOCKPICKMTL");
                    //操作日志
                    DALCreator.CommFunction.DM_Log_Local("解除冲突", "菜单->工具->占用解除", "解除自动领料");
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
            frmTool_Timer frmTime = new frmTool_Timer(_TimerPara);

            if (frmTime.ShowDialog() == DialogResult.OK)
            {
                //TimerPara = frmTime.TimerPara;
                _TimerPara = new TimerParameter(frmTime.TimerPara.ExeTimes, frmTime.TimerPara.PickMinute, frmTime.TimerPara.RunSeconds, frmTime.TimerPara.PauseStatus, frmTime.TimerPara.IsRunning, frmTime.TimerPara.FuncID);

                if (_TimerPara.PauseStatus)
                {
                    if (tSumSecond != null) tSumSecond.Stop();//停止进行时间累计
                    if (_Execute != null) _Execute.Stop();//停止方法自动执行
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
                    _Execute = new System.Timers.Timer();
                    _Execute.Enabled = true;
                    _Execute.Interval = 1000 * 60 * _TimerPara.PickMinute;//每pMinute分钟执行一次
                    _Execute.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                    //_Execute.Start();
                }

                //操作日志
                DALCreator.CommFunction.DM_Log_Local("定时器", "菜单->工具", "操作定时器");
            }
            //frmTime.Dispose();
        }

        /// <summary>
        /// 电商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiPro_Business_Report_Click(object sender, EventArgs e)
        {
            frmPro_Business_Report frm = new SupForm.Menu.frmPro_Business_Report();
            frm.Show(this);
        }

        /// <summary>
        /// 网上订单系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiPro_INOrder_Click(object sender, EventArgs e)
        {
            frmINOrder frm = new frmINOrder();
            frm.Show(this);
        }

        /// <summary>
        /// 调拨单设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiPro_Dir_Click(object sender, EventArgs e)
        {
            frmPro_Dir frm = new frmPro_Dir();
            frm.ShowDialog();
        }

        /// <summary>
        /// 同步K3关联单据数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiPro_K3Data_Click(object sender, EventArgs e)
        {
            frmPro_K3SynData frm = new frmPro_K3SynData();
            frm.Show(this);
        }

        /// <summary>
        /// 同步K3数据到WMS系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiPro_WMSData_Click(object sender, EventArgs e)
        {
            frmPro_WMSData frm = new frmPro_WMSData();
            frm.Show(this);
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

        #region 主窗口大小改变时发生
        /// <summary>
        /// 主窗口大小改变时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (_CurrentRow != 0)
                ResetUCSize(_ListP, _CurrentRow, _ChildCount);
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
            if (_FormId == FormID.PRD_PPBOM)
            {
                bnTop_btnSearch.Enabled = false;
            }
        }
        #endregion

        #region 勾选
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            foreach (DataGridViewRow dr in dgv1.Rows)
            {
                dr.Cells[0].Value = ((CheckBox)sender).Checked;
            }
            dgv1.EndEdit();
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

        /// <summary>
        /// 自动调整chb1.Location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            if (_chb != null && dgv1 != null && dgv1.Rows.Count > 0)
                _chb.Location = new Point(dgv1.Rows[0].HeaderCell.Size.Width + 8, 2);
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //如果自动领料正在执行，关闭自动领料
            if (_Execute != null)
            {
                _Execute.Close();
                DALCreator.CommFunction.UpdateLockStatus(0, "LOCKPICKMTL");
            }

            //日志
            DALCreator.CommFunction.DM_Log_Local("退出系统", "主窗口", "关闭主窗体并退出系统");//日志
        }

        #region 定时器事件
        /// <summary>
        /// 计算RunSeconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSumSecond_Tick(object sender, EventArgs e)
        {
            _TimerPara.RunSeconds++;
        }

        /// <summary>
        /// 定时任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DataTable dt = new DataTable();

            _TimerPara.IsRunning = true;

            try
            {
                dt = DALCreator.PrdPick.GetInstockBillNo(DateTime.Now.AddDays(-1));

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DALCreator.PrdPick.PickMtl(dt.Rows[i]["FBILLNO"].ToString());
                    }
                    _TimerPara.ExeTimes++;
                }
            }
            catch { }

            _TimerPara.IsRunning = false;
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

        #region BindingNavigator
        /// <summary>
        /// 改变页码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnB_cbxPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            DataSourceBinding(2);
        }

        /// <summary>
        /// 功能按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
                return;

            switch (e.ClickedItem.Tag.ToString())
            {
                case "1":
                    Filter();
                    break;
                case "2":
                    Check();
                    break;
                case "3":
                    Search();
                    break;
                case "4":
                    ShowAll();
                    break;
                case "5":
                    Commit();
                    break;
                case "6":
                    UnLock();
                    break;
            }
        }

        /// <summary>
        /// 分页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0 || e.ClickedItem.Tag == null)
                return;

            switch (e.ClickedItem.Tag.ToString())
            {
                case "1":
                    if (_CurrentPage <= 1)
                    {
                        return;
                    }
                    else
                    {
                        _CurrentPage = 1;
                    }
                    break;
                case "2":
                    if (_CurrentPage <= 1)
                    {
                        return;
                    }
                    else
                    {
                        _CurrentPage--;
                    }
                    break;
                case "3":
                    _reg = new Regex(@"^[0-9]*[1-9][0-9]*$");

                    if (!_reg.IsMatch(bnB_txtCurrentPage.Text))
                    {
                        MessageBox.Show("输入的页码格式不正确！");
                        bnB_txtCurrentPage.Focus();
                        bnB_txtCurrentPage.Text = _PageCount.ToString();
                        bnB_txtCurrentPage.Select(0, bnB_txtCurrentPage.Text.Length);
                        return;
                    }
                    if (int.Parse(bnB_txtCurrentPage.Text) > _PageCount)
                    {
                        MessageBox.Show("跳转页超过了总页数！");
                        return;
                    }

                    _CurrentPage = int.Parse(bnB_txtCurrentPage.Text);
                    break;
                case "4":
                    if (_CurrentPage >= _PageCount)
                    {
                        return;
                    }
                    else
                    {
                        _CurrentPage++;
                    }
                    break;
                case "5":
                    if (_CurrentPage >= _PageCount)
                    {
                        return;
                    }
                    else
                    {
                        _CurrentPage = _PageCount;
                    }
                    break;
                default:
                    return;
            }

            DataSourceBinding(0);
        }
        #endregion

        #endregion
    }
}

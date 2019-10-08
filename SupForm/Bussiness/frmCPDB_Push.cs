using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ERPSupport.SupForm.Bussiness
{
    using UserCrtl;
    using UserClass;
    using SQL.K3Cloud;

    /// <summary>
    /// 发货通知单推调拨单
    /// </summary>
    public partial class frmCPDB_Push : Form
    {
        /// <summary>
        /// 初次加载
        /// </summary>
        private bool _Load;
        ///// <summary>
        ///// DGV按键列
        ///// </summary>
        //private DataGridViewButtonColumn _Btn;
        /// <summary>
        /// DGV复选框列
        /// </summary>
        private DataGridViewCheckBoxColumn _Chb;
        /// <summary>
        /// DGV复选框列头
        /// </summary>
        private datagridviewCheckboxHeaderCell _Ch;
        /// <summary>
        /// ToolStrip日期从
        /// </summary>
        private ToolStripDateTimePicker _Date;
        /// <summary>
        /// 部门和日期
        /// </summary>
        private List<string> _List;
        /// <summary>
        /// 数据源
        /// </summary>
        private DataTable _dtDataSource;

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmCPDB_Push(List<string> pList)
        {
            InitializeComponent();

            _List = pList;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCPDB_Push_Load(object sender, EventArgs e)
        {
            //_dtDataSource = new DataTable();
            _Load = true;
            //_Btn = new DataGridViewButtonColumn();
            _Chb = new DataGridViewCheckBoxColumn();

            _Date = new ToolStripDateTimePicker();
            _Date.Size = new Size(120, 21);


            List<ToolStripItem> list = new List<ToolStripItem>();
            list.Add(bnBottom.Items[0]);
            list.Add(_Date);
            list.Add(bnBottom.Items[1]);
            list.Add(bnBottom.Items[2]);
            list.Add(bnBottom.Items[3]);
            list.Add(bnBottom.Items[4]);
            list.Add(bnBottom.Items[5]);

            bnBottom.Items.Clear();
            foreach (ToolStripItem item in list)
                bnBottom.Items.Add(item);

            Text = "根据发货通知单推WMS成品调拨[部门：" + _List[2] + "][调入仓库：" + _List[5] + "]";
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnSearch_Click(object sender, EventArgs e)
        {
            if (_Load)
            {
                //_Btn.DataPropertyName = "BTN";
                //dgv1.Columns.Add(_Btn);
                _Chb.DataPropertyName = "CHB";
                //_Chb.Name = "CHB";
                dgv1.Columns.Add(_Chb);

                _Load = false;
            }

            _dtDataSource = PrdAllocation.GetNotice(_Date.Value, bnBottom_txtBillNo.Text);
            dgv1.DataSource = _dtDataSource;

            //_Btn = dgv1.Columns[0] as DataGridViewButtonColumn;
            //_Btn.HeaderText = "";
            //_Btn.Name = "BTN";
            //_Btn.Width = 60;

            _Ch = new datagridviewCheckboxHeaderCell();
            _Chb = dgv1.Columns[0] as DataGridViewCheckBoxColumn;
            _Chb.Width = 35;
            _Chb.DataPropertyName = "CHB";
            //_Chb.FalseValue = false;
            //_Chb.TrueValue = true;
            _Chb.HeaderCell = _Ch;
            _Chb.HeaderCell.Value = "";
            _Ch.OnCheckBoxClicked += ch_OnCheckBoxClicked;
        }

        /// <summary>
        /// 下推单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnPush_Click(object sender, EventArgs e)
        {
            if (_dtDataSource == null || _dtDataSource.Rows.Count == 0)
                return;

            string strBillNos;
            DataTable dtDate;
            List<string> listCust = new List<string>(), listFBillNos, listFBillNoAll;

            for (int i = 0; i < _dtDataSource.Rows.Count; i++)
                if (!listCust.Contains(_dtDataSource.Rows[i]["客户"].ToString()) && dgv1.Rows[i].Cells[0].Value.ToString() == "1")
                    listCust.Add(_dtDataSource.Rows[i]["客户"].ToString());

            if (listCust.Count == 0)
                return;

            strBillNos = string.Empty;
            listFBillNoAll = new List<string>();

            //根据不用的客户生成单据
            for (int i = 0; i < listCust.Count; i++)
            {
                listFBillNos = new List<string>();
                for (int j = 0; j < _dtDataSource.Rows.Count; j++)
                {
                    if (listCust[i] == _dtDataSource.Rows[j]["客户"].ToString() && !listFBillNos.Contains(_dtDataSource.Rows[j]["单据编号"].ToString()))
                    {
                        listFBillNos.Add(_dtDataSource.Rows[j]["单据编号"].ToString());
                        listFBillNoAll.Add(_dtDataSource.Rows[j]["单据编号"].ToString());
                    }
                }

                dtDate = PrdAllocation.GetTransForP(listFBillNos);
                if (dtDate == null || dtDate.Rows.Count == 0)
                    continue;

                strBillNos += PrdAllocation.TransferDir(dtDate, _List, true);
            }

            //反写发货通知单关联调拨数量
            PrdAllocation.UpdateNotice(listFBillNoAll);

            MessageBox.Show("直接调拨单：" + strBillNos);

            //日志
            CommFunction.DM_Log_Local("成品调拨", "辅助功能//调拨//成品调拨-发货通知单", strBillNos);

            bnTop_btnSearch_Click(null, null);
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnBottom_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 选取相同客户的行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (sender == null || ((DataGridView)sender).Rows.Count == 0 || e.RowIndex < 0)
            //    return;

            //if (e.ColumnIndex == ((DataGridView)sender).Columns["BTN"].Index)
            //{
            //    int rows = ((DataGridView)sender).CurrentRow.Index;

            //    //if (MessageBox.Show("您确定要删除吗？", "重要提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            //    //{
            //        _dtDataSource.Rows.RemoveAt(rows);
            //        ((DataGridView)sender).DataSource = _dtDataSource;
            //    //}
            //}

            if (dgv1 == null || dgv1.Rows.Count == 0 || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)//点击列为CHB列
                for (int i = 0; i < dgv1.Rows.Count; i++)
                    if (dgv1.Rows[i].Cells[4].Value.ToString() == dgv1.CurrentRow.Cells[4].Value.ToString())
                        dgv1.Rows[i].Cells[0].Value = dgv1.CurrentRow.Cells[0].EditedFormattedValue;
        }

        /// <summary>
        /// 勾选行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            foreach (DataGridViewRow dr in dgv1.Rows)
                dr.Cells[0].Value = e.CheckedState;

            //dgv1.EndEdit();
        }
    }
}


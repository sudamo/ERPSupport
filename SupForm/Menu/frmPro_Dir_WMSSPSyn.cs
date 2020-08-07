using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ERPSupport.SupForm.Menu
{
    using UserClass;
    using DALFactory.K3Cloud;

    /// <summary>
    /// WMS仓位同步到ERP
    /// </summary>
    public partial class frmPro_Dir_WMSSPSyn : Form
    {
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
        /// 数据源
        /// </summary>
        private DataTable _DataSourceAll;
        /// <summary>
        /// 用于显示的数据
        /// </summary>
        private DataTable _DataTemp;
        /// <summary>
        /// 初次加载
        /// </summary>
        private bool _Load;
        /// <summary>
        /// DGV复选框列
        /// </summary>
        private DataGridViewCheckBoxColumn _Chb;
        /// <summary>
        /// DGV复选框列头
        /// </summary>
        private datagridviewCheckboxHeaderCell _Ch;
        /// <summary>
        /// Regex
        /// </summary>
        private Regex _reg;

        public frmPro_Dir_WMSSPSyn()
        {
            InitializeComponent();
        }

        private void frmPro_Dir_WMSSPSyn_Load(object sender, EventArgs e)
        {

            _Load = true;
            _Chb = new DataGridViewCheckBoxColumn();

            FillComboBox();
            _PageSize = int.Parse(bn_cbxPageSize.ComboBox.SelectedValue.ToString());

            _DataSourceAll = DALCreator.PrdAllocation.GetWMSSP();
            DataSourceBinding(1);
        }

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
            dr["FName"] = "5000";
            dr["FValue"] = "5000";
            dtComboBox.Rows.Add(dr);

            bn_cbxPageSize.ComboBox.DataSource = dtComboBox;
            bn_cbxPageSize.ComboBox.DisplayMember = "FName";
            bn_cbxPageSize.ComboBox.ValueMember = "FValue";
            bn_cbxPageSize.ComboBox.SelectedIndex = 2;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="pType">Search,ChangePageSize</param>
        private void DataSourceBinding(int pType)
        {
            if (_Load)
            {
                _Chb.DataPropertyName = "chb";
                dgv1.Columns.Add(_Chb);

                _Load = false;
            }

            if (pType == 1)//重新加载数据源
            {
                _DataSource = _DataSourceAll;

                if (_DataSource == null || _DataSource.Rows.Count == 0)
                {
                    dgv1.DataSource = null;
                    return;
                }

                _CurrentPage = 1;//当前页数从1开始
            }
            else if (pType == 2)//改变_PageSize，重新计算 _CurrentPage
            {
                if (dgv1.DataSource == null || dgv1.Rows.Count == 0)
                    return;

                _CurrentPage = _Start / _PageSize + 1;
            }

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

            bn_txtCurrentPage.Text = _CurrentPage.ToString();
            bn_lblPageCount.Text = string.Format("{0}页", _PageCount.ToString());
            bn_lblRecordCount.Text = string.Format("{0}行", _RecordCount.ToString());

            bs1.DataSource = _DataTemp;
            bn1.BindingSource = bs1;
            dgv1.DataSource = bs1;
            dgv1.Columns[5].Visible = false;

            _Ch = new datagridviewCheckboxHeaderCell();
            _Chb = dgv1.Columns[0] as DataGridViewCheckBoxColumn;
            _Chb.Width = 35;
            _Chb.DataPropertyName = "chb";
            _Chb.HeaderCell = _Ch;
            _Chb.HeaderCell.Value = false;
            _Ch.OnCheckBoxClicked += ch_OnCheckBoxClicked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bn1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (_DataSource == null || _DataSource.Rows.Count == 0 || e.ClickedItem.Tag == null)
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
                        //MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                        return;
                    }
                    else
                    {
                        _CurrentPage--;
                    }
                    break;
                case "3":
                    _reg = new Regex(@"^[0-9]*[1-9][0-9]*$");

                    if (!_reg.IsMatch(bn_txtCurrentPage.Text))
                    {
                        MessageBox.Show("输入的页码格式不正确！");
                        bn_txtCurrentPage.Focus();
                        bn_txtCurrentPage.Text = _PageCount.ToString();
                        bn_txtCurrentPage.Select(0, bn_txtCurrentPage.Text.Length);
                        return;
                    }
                    if (int.Parse(bn_txtCurrentPage.Text) > _PageCount)
                    {
                        MessageBox.Show("跳转页超过了总页数！");
                        return;
                    }
                    _CurrentPage = int.Parse(bn_txtCurrentPage.Text);
                    break;
                case "4":
                    if (_CurrentPage >= _PageCount)
                    {
                        //MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
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

            //控制按钮颜色
            if (_PageCount == 1)
            {
                bn_btnStart.Image = Properties.Resources.control_start;
                bn_btnPrevious.Image = Properties.Resources.control_play2;
                bn_btnNext.Image = Properties.Resources.control_play;
                bn_btnLast.Image = Properties.Resources.control_end;

                bn_btnGoto.Image = Properties.Resources.control_repeat;
            }
            else
            {
                if (_CurrentPage == 1)
                {
                    bn_btnStart.Image = Properties.Resources.control_start;
                    bn_btnPrevious.Image = Properties.Resources.control_play2;
                    bn_btnNext.Image = Properties.Resources.control_play_blue;
                    bn_btnLast.Image = Properties.Resources.control_end_blue;
                }
                else if (_CurrentPage != _PageCount)
                {
                    bn_btnStart.Image = Properties.Resources.control_start_blue;
                    bn_btnPrevious.Image = Properties.Resources.control_play2_blue;
                    bn_btnNext.Image = Properties.Resources.control_play_blue;
                    bn_btnLast.Image = Properties.Resources.control_end_blue;
                }
                else
                {
                    bn_btnStart.Image = Properties.Resources.control_start_blue;
                    bn_btnPrevious.Image = Properties.Resources.control_play2_blue;
                    bn_btnNext.Image = Properties.Resources.control_play;
                    bn_btnLast.Image = Properties.Resources.control_end;
                }

                bn_btnGoto.Image = Properties.Resources.control_repeat_blue;
            }

            DataSourceBinding(0);
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
            //foreach (DataGridViewRow dr in dgv1.Rows)
            //{
            //    dr.Cells[0].Value = ((CheckBox)sender).Checked;
            //}

            dgv1.EndEdit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bn_cbxPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            try
            {
                _PageSize = int.Parse(bn_cbxPageSize.ComboBox.SelectedValue.ToString());
                DataSourceBinding(2);
            }
            catch { }
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;

            if (bnTop_txtNumber.Text.Trim().Equals(string.Empty))
            {
                DataSourceBinding(1);
                return;
            }

            try
            {
                //dgv1.DataSource = null;
                string sFNumber = bnTop_txtNumber.Text.Trim();
                DataTable dt = _DataSource.Clone();

                foreach (DataRow dr in _DataSourceAll.Rows)
                {
                    if (dr["物料编码"].ToString().Contains(sFNumber))
                        dt.ImportRow(dr);
                }
                if(dt.Rows.Count==0)
                {
                    MessageBox.Show("没有数据。");
                    return;
                }

                _DataSource = dt;
                DataSourceBinding(2);
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// 同步选的物料的仓位到ERP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnCommit_Click(object sender, EventArgs e)
        {   
            if (dgv1 == null || dgv1.Rows.Count == 0)
                return;

            string sNumbers = string.Empty;
            DataTable dt = _DataSource.Clone();
            DataRow dr;
            if (dgv1.IsCurrentCellDirty)
                dgv1.CommitEdit(DataGridViewDataErrorContexts.Commit);//-----------------提交编辑状态的行，否则获取编辑之前的值。

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value))
                {
                    dr = dt.NewRow();
                    dr["仓位"] = dgv1.Rows[i].Cells[3].Value;
                    dr["FMATERIALID"] = dgv1.Rows[i].Cells[5].Value;
                    dt.Rows.Add(dr);

                    sNumbers += dgv1.Rows[i].Cells[1].Value.ToString();
                }
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有选择任何数据");
                return;
            }

            DALCreator.PrdAllocation.SynSPToERP(dt);

            MessageBox.Show("仓位已经同步。");

            //日志
            DALCreator.CommFunction.DM_Log_Local("仓位同步", "项目->调拨单设置->同步仓位", sNumbers);
        }

        /// <summary>
        /// 同步所有物料的仓位到ERP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnCommitAll_Click(object sender, EventArgs e)
        {
            DALCreator.PrdAllocation.SynSPToERP(_DataSourceAll);
            MessageBox.Show("所有仓位已经同步。");

            //日志
            DALCreator.CommFunction.DM_Log_Local("仓位同步", "项目->调拨单设置->同步仓位", "同步所有WMS仓位");
        }

        /// <summary>
        /// 导入报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTop_btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能开发中。");
            return;
        }
    }
}

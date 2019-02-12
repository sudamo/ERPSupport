using System;

namespace ERPSupport.Model.K3Cloud
{
    /// <summary>
    /// 销售订单实体
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public OrderInfo() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pIndex">序号</param>
        /// <param name="pFEntryId">分录内码</param>
        /// <param name="pBillNo">单据编号</param>
        /// <param name="pBillTypeId">单据类型</param>
        /// <param name="pLockFlag">锁库标识</param>
        /// <param name="pFullLock">完全锁库标识</param>
        /// <param name="pFbatchFlag">批量锁库标识</param>
        public OrderInfo(int pIndex, int pFEntryId, string pBillNo, string pBillTypeId, string pLockFlag, string pFullLock, string pFbatchFlag)
        {
            _Index = pIndex;
            _FEntryId = pFEntryId;
            _FBillNo = pBillNo;
            _FBillTypeId = pBillTypeId;
            _FLockFlag = pLockFlag;
            _FFullLock = pFullLock;
            _FBatchFlag = pFbatchFlag;
        }

        //--------------------字段
        private int _Index;
        //--
        private int _FId;
        private int _FEntryId;
        private string _FBillNo;
        private string _FBillTypeId;
        private int _FMaterialId;
        private string _FMaterialNo;
        private string _FMaterialName;
        private DateTime _FDate;
        private DateTime _FApproveDate;
        private string _FDocumentStatus;
        private string _FCloseStatus;
        private string _FMRPCloseStatus;
        private double _FQTY;
        private double _FLockQTY;
        private int _FSaleOrgId;
        private int _FStockOrgId;
        private string _FLockFlag;
        private string _FFullLock;
        private string _FBatchFlag;
        private string _FStockOrgNumber;
        private string _FUnitNumber;
        private string _FStockNumber;

        //--------------------属性
        /// <summary>
        /// 序号
        /// </summary>
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }
        //--
        /// <summary>
        /// 内码
        /// </summary>
        public int FId
        {
            get { return _FId; }
            set { _FId = value; }
        }
        /// <summary>
        /// 分录内码
        /// </summary>
        public int FEntryId
        {
            get { return _FEntryId; }
            set { _FEntryId = value; }
        }
        /// <summary>
        /// 单据编号
        /// </summary>
        public string FBillNo
        {
            get { return _FBillNo; }
            set { _FBillNo = value; }
        }
        /// <summary>
        /// 单据类型
        /// </summary>
        public string FBILLTYPEID
        {
            get { return _FBillTypeId; }
            set { _FBillTypeId = value; }
        }
        /// <summary>
        /// 物料ID
        /// </summary>
        public int FMaterialId
        {
            get { return _FMaterialId; }
            set { _FMaterialId = value; }
        }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string FMaterialNo
        {
            get { return _FMaterialNo; }
            set { _FMaterialNo = value; }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string FMaterialName
        {
            get { return _FMaterialName; }
            set { _FMaterialName = value; }
        }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime FDate
        {
            get { return _FDate; }
            set { _FDate = value; }
        }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime FApproveDate
        {
            get { return _FApproveDate; }
            set { _FApproveDate = value; }
        }
        /// <summary>
        /// 单据状态
        /// </summary>
        public string FDocumentStatus
        {
            get { return _FDocumentStatus; }
            set { _FDocumentStatus = value; }
        }
        /// <summary>
        /// 关闭状态
        /// </summary>
        public string FCloseStatus
        {
            get { return _FCloseStatus; }
            set { _FCloseStatus = value; }
        }
        /// <summary>
        /// 行关闭状态
        /// </summary>
        public string FMRPCloseStatus
        {
            get { return _FMRPCloseStatus; }
            set { _FMRPCloseStatus = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public double FQTY
        {
            get { return _FQTY; }
            set { _FQTY = value; }
        }
        /// <summary>
        /// 锁库数量
        /// </summary>
        public double FLockQTY
        {
            get { return _FLockQTY; }
            set { _FLockQTY = value; }
        }
        /// <summary>
        /// 销售组织
        /// </summary>
        public int FSaleOrgId
        {
            get { return _FSaleOrgId; }
            set { _FSaleOrgId = value; }
        }
        /// <summary>
        /// 库存组织
        /// </summary>
        public int FStockOrgId
        {
            get { return _FStockOrgId; }
            set { _FStockOrgId = value; }
        }
        /// <summary>
        /// 锁库标识
        /// </summary>
        public string FLockFlag
        {
            get { return _FLockFlag; }
            set { _FLockFlag = value; }
        }
        /// <summary>
        /// 完全锁库标识
        /// </summary>
        public string FFullLock
        {
            get { return _FFullLock; }
            set { _FFullLock = value; }
        }
        /// <summary>
        /// 批量锁库标识
        /// </summary>
        public string FBatchFlag
        {
            get { return _FBatchFlag; }
            set { _FBatchFlag = value; }
        }
        /// <summary>
        /// 库存组织
        /// </summary>
        public string FStockOrgNumber
        {
            get
            {
                return _FStockOrgNumber;
            }

            set
            {
                _FStockOrgNumber = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string FUnitNumber
        {
            get
            {
                return _FUnitNumber;
            }

            set
            {
                _FUnitNumber = value;
            }
        }
        /// <summary>
        /// 仓库
        /// </summary>
        public string FStockNumber
        {
            get
            {
                return _FStockNumber;
            }

            set
            {
                _FStockNumber = value;
            }
        }
    }
}
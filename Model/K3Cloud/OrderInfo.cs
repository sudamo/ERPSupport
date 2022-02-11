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
        /// <param name="pFid">单据内码</param>
        /// <param name="pFEntryId">分录内码</param>
        /// <param name="pError">错误信息</param>
        public OrderInfo(int pIndex, int pFid, int pFEntryId, string pError)
        {
            _Index = pIndex;
            _FId = pFid;
            _FEntryId = pFEntryId;
            _StrError = pError;
        }

        //--------------------字段
        /// <summary>
        /// 序号
        /// </summary>
        private int _Index;
        /// <summary>
        /// 错误信息
        /// </summary>
        private string _StrError;        
        /// <summary>
        /// 单据内码
        /// </summary>
        private int _FId;
        /// <summary>
        /// 分录内码
        /// </summary>
        private int _FEntryId;

        //--------------------单据头
        /// <summary>
        /// 单据编号
        /// </summary>
        private string _FBillNo;
        /// <summary>
        /// 单据类型
        /// </summary>
        private string _FBillTypeId;
        /// <summary>
        /// 日期
        /// </summary>
        private DateTime _FDate;
        /// <summary>
        /// 审核日期
        /// </summary>
        private DateTime _FApproveDate;
        /// <summary>
        /// 销售组织
        /// </summary>
        private int _FSALEORGID;
        /// <summary>
        /// 销售组织编码
        /// </summary>
        private string _FSALEORGCode;
        /// <summary>
        /// 生产组织
        /// </summary>
        private int _F_PAEZ_FACTORGID;
        /// <summary>
        /// 生产组织编码
        /// </summary>
        private string _F_PAEZ_FACTORGCode;
        /// <summary>
        /// 单据状态
        /// </summary>
        private string _FDocumentStatus;
        /// <summary>
        /// 关闭状态
        /// </summary>
        private string _FCloseStatus;
        /// <summary>
        /// 作废状态
        /// </summary>
        private string _FCancleStatus;
        /// <summary>
        /// 对应客户单号
        /// </summary>
        private string _F_CUSTOMERORDERNUMBE;
        /// <summary>
        /// 客户
        /// </summary>
        private int _FCUSTID;
        /// <summary>
        /// 客户编码
        /// </summary>
        private string _FCUSTCode;
        /// <summary>
        /// 客户名称
        /// </summary>
        private string _FCUSTName;
        /// <summary>
        /// 发货类别
        /// </summary>
        private string _FHEADDELIVERYWAY;
        /// <summary>
        /// 发货类别编码
        /// </summary>
        private string _FHEADDELIVERYWAYCode;
        /// <summary>
        /// 发货方式
        /// </summary>
        private string _FDELIVERYMETHOD;
        /// <summary>
        /// 发货方式编码
        /// </summary>
        private string _FDELIVERYMETHODCode;
        /// <summary>
        /// 物流公司
        /// </summary>
        private string _F_PAEZ_LOGISTCSCOMPANY;
        /// <summary>
        /// 物流公司编码
        /// </summary>
        private string _F_PAEZ_LOGISTCSCOMPANYCode;
        /// <summary>
        /// 联系人
        /// </summary>
        private string _F_PAEZ_CONTACTS;
        /// <summary>
        /// 联系电话
        /// </summary>
        private string _F_PAEZ_CONTACTNUMBER;
        /// <summary>
        /// 收货地址
        /// </summary>
        private string _F_PAEZ_HEADLOCADDRESS;
        /// <summary>
        /// 完全锁库
        /// </summary>
        private bool _FFullLock;

        //--------------------单据体
        /// <summary>
        /// 序号
        /// </summary>
        private int _FSeq;
        /// <summary>
        /// 库存组织
        /// </summary>
        private int _FSTOCKORGID;
        /// <summary>
        /// 库存组织编码
        /// </summary>
        private string _FSTOCKORGCode;
        /// <summary>
        /// 结算组织
        /// </summary>
        private int _FSETTLEORGID;
        /// <summary>
        /// 结算组织编码
        /// </summary>
        private string _FSETTLEORGCode;
        /// <summary>
        /// 物料
        /// </summary>
        private int _FMaterialId;
        /// <summary>
        /// 物料编码
        /// </summary>
        private string _FMaterialCode;
        /// <summary>
        /// 物料名称
        /// </summary>
        private string _FMaterialName;
        /// <summary>
        /// 数量
        /// </summary>
        private decimal _FQTY;
        /// <summary>
        /// 单价
        /// </summary>
        private decimal _FPRICE;
        /// <summary>
        /// 单据体备注
        /// </summary>
        private string _FEntryNOTE;
        /// <summary>
        /// 单位
        /// </summary>
        private int _FUnitId;
        /// <summary>
        /// 单位编码
        /// </summary>
        private string _FUnitNumber;
        /// <summary>
        /// 仓库
        /// </summary>
        private int _FStockId;
        /// <summary>
        /// 仓库编码
        /// </summary>
        private string _FStockNumber;
        /// <summary>
        /// 累计出库数量
        /// </summary>
        private double _FBASESTOCKOUTQTY;
        /// <summary>
        /// 可出数量
        /// </summary>
        private double _FBASECANOUTQTY;
        /// <summary>
        /// 锁库数量
        /// </summary>
        private double _FLockQTY;
        /// <summary>
        /// 锁库/预留标识
        /// </summary>
        private bool _FLockFlag;
        /// <summary>
        /// 批量锁库标识
        /// </summary>
        private bool _FBatchFlag;
        /// <summary>
        /// 业务关闭
        /// </summary>
        private string _FMRPCloseStatus;
        /// <summary>
        /// 业务终止
        /// </summary>
        private string _FMRPTerminateStatus;

        //--------------------属性
        /// <summary>
        /// 序号
        /// </summary>
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        public string StrError
        {
            get
            {
                return _StrError;
            }

            set
            {
                _StrError = value;
            }
        }

        public int FId
        {
            get
            {
                return _FId;
            }

            set
            {
                _FId = value;
            }
        }

        public int FEntryId
        {
            get
            {
                return _FEntryId;
            }

            set
            {
                _FEntryId = value;
            }
        }

        //--------------------单据头
        public string FBillNo
        {
            get
            {
                return _FBillNo;
            }

            set
            {
                _FBillNo = value;
            }
        }

        public string FBillTypeId
        {
            get
            {
                return _FBillTypeId;
            }

            set
            {
                _FBillTypeId = value;
            }
        }

        public DateTime FDate
        {
            get
            {
                return _FDate;
            }

            set
            {
                _FDate = value;
            }
        }

        public DateTime FApproveDate
        {
            get
            {
                return _FApproveDate;
            }

            set
            {
                _FApproveDate = value;
            }
        }

        public int FSALEORGID
        {
            get
            {
                return _FSALEORGID;
            }

            set
            {
                _FSALEORGID = value;
            }
        }

        public string FSALEORGCode
        {
            get
            {
                return _FSALEORGCode;
            }

            set
            {
                _FSALEORGCode = value;
            }
        }

        public int F_PAEZ_FACTORGID
        {
            get
            {
                return _F_PAEZ_FACTORGID;
            }

            set
            {
                _F_PAEZ_FACTORGID = value;
            }
        }
        /// <summary>
        /// 生产组织
        /// </summary>
        public string F_PAEZ_FACTORGCode
        {
            get
            {
                return _F_PAEZ_FACTORGCode;
            }

            set
            {
                _F_PAEZ_FACTORGCode = value;
            }
        }

        public string FDocumentStatus
        {
            get
            {
                return _FDocumentStatus;
            }

            set
            {
                _FDocumentStatus = value;
            }
        }
        /// <summary>
        /// 关闭状态
        /// </summary>
        public string FCloseStatus
        {
            get
            {
                return _FCloseStatus;
            }

            set
            {
                _FCloseStatus = value;
            }
        }
        /// <summary>
        /// 作废状态
        /// </summary>
        public string FCancleStatus
        {
            get
            {
                return _FCancleStatus;
            }

            set
            {
                _FCancleStatus = value;
            }
        }

        public string F_CUSTOMERORDERNUMBE
        {
            get
            {
                return _F_CUSTOMERORDERNUMBE;
            }

            set
            {
                _F_CUSTOMERORDERNUMBE = value;
            }
        }

        public int FCUSTID
        {
            get
            {
                return _FCUSTID;
            }

            set
            {
                _FCUSTID = value;
            }
        }

        public string FCUSTCode
        {
            get
            {
                return _FCUSTCode;
            }

            set
            {
                _FCUSTCode = value;
            }
        }

        public string FCUSTName
        {
            get
            {
                return _FCUSTName;
            }

            set
            {
                _FCUSTName = value;
            }
        }

        /// <summary>
        /// 发货类别
        /// </summary>
        public string FHEADDELIVERYWAY
        {
            get
            {
                return _FHEADDELIVERYWAY;
            }

            set
            {
                _FHEADDELIVERYWAY = value;
            }
        }

        public string FHEADDELIVERYWAYCode
        {
            get
            {
                return _FHEADDELIVERYWAYCode;
            }

            set
            {
                _FHEADDELIVERYWAYCode = value;
            }
        }
        /// <summary>
        /// 发货方式
        /// </summary>
        public string FDELIVERYMETHOD
        {
            get
            {
                return _FDELIVERYMETHOD;
            }

            set
            {
                _FDELIVERYMETHOD = value;
            }
        }

        public string FDELIVERYMETHODCode
        {
            get
            {
                return _FDELIVERYMETHODCode;
            }

            set
            {
                _FDELIVERYMETHODCode = value;
            }
        }
        /// <summary>
        /// 物流公司
        /// </summary>
        public string F_PAEZ_LOGISTCSCOMPANY
        {
            get
            {
                return _F_PAEZ_LOGISTCSCOMPANY;
            }

            set
            {
                _F_PAEZ_LOGISTCSCOMPANY = value;
            }
        }

        public string F_PAEZ_LOGISTCSCOMPANYCode
        {
            get
            {
                return _F_PAEZ_LOGISTCSCOMPANYCode;
            }

            set
            {
                _F_PAEZ_LOGISTCSCOMPANYCode = value;
            }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string F_PAEZ_CONTACTS
        {
            get
            {
                return _F_PAEZ_CONTACTS;
            }

            set
            {
                _F_PAEZ_CONTACTS = value;
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string F_PAEZ_CONTACTNUMBER
        {
            get
            {
                return _F_PAEZ_CONTACTNUMBER;
            }

            set
            {
                _F_PAEZ_CONTACTNUMBER = value;
            }
        }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string F_PAEZ_HEADLOCADDRESS
        {
            get
            {
                return _F_PAEZ_HEADLOCADDRESS;
            }

            set
            {
                _F_PAEZ_HEADLOCADDRESS = value;
            }
        }
        /// <summary>
        /// 完全锁库
        /// </summary>
        public bool FFullLock
        {
            get
            {
                return _FFullLock;
            }

            set
            {
                _FFullLock = value;
            }
        }

        //--------------------单据体
        public int FSeq
        {
            get { return _FSeq; }
            set { _FSeq = value; }
        }
        /// <summary>
        /// 库存组织
        /// </summary>
        public int FSTOCKORGID
        {
            get
            {
                return _FSTOCKORGID;
            }

            set
            {
                _FSTOCKORGID = value;
            }
        }

        public string FSTOCKORGCode
        {
            get
            {
                return _FSTOCKORGCode;
            }

            set
            {
                _FSTOCKORGCode = value;
            }
        }
        /// <summary>
        /// 结算组织
        /// </summary>
        public int FSETTLEORGID
        {
            get
            {
                return _FSETTLEORGID;
            }

            set
            {
                _FSETTLEORGID = value;
            }
        }

        public string FSETTLEORGCode
        {
            get
            {
                return _FSETTLEORGCode;
            }

            set
            {
                _FSETTLEORGCode = value;
            }
        }

        public int FMaterialId
        {
            get
            {
                return _FMaterialId;
            }

            set
            {
                _FMaterialId = value;
            }
        }

        public string FMaterialCode
        {
            get
            {
                return _FMaterialCode;
            }

            set
            {
                _FMaterialCode = value;
            }
        }

        public string FMaterialName
        {
            get
            {
                return _FMaterialName;
            }

            set
            {
                _FMaterialName = value;
            }
        }

        public decimal FQTY
        {
            get
            {
                return _FQTY;
            }

            set
            {
                _FQTY = value;
            }
        }

        public decimal FPRICE
        {
            get
            {
                return _FPRICE;
            }

            set
            {
                _FPRICE = value;
            }
        }

        public string FEntryNOTE
        {
            get
            {
                return _FEntryNOTE;
            }

            set
            {
                _FEntryNOTE = value;
            }
        }

        public int FUnitId
        {
            get
            {
                return _FUnitId;
            }

            set
            {
                _FUnitId = value;
            }
        }

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

        public int FStockId
        {
            get
            {
                return _FStockId;
            }

            set
            {
                _FStockId = value;
            }
        }

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
        /// <summary>
        /// 累计出库数量
        /// </summary>
        public double FBASESTOCKOUTQTY
        {
            get
            {
                return _FBASESTOCKOUTQTY;
            }

            set
            {
                _FBASESTOCKOUTQTY = value;
            }
        }
        /// <summary>
        /// 可出数量
        /// </summary>
        public double FBASECANOUTQTY
        {
            get
            {
                return _FBASECANOUTQTY;
            }

            set
            {
                _FBASECANOUTQTY = value;
            }
        }
        /// <summary>
        /// 锁库数量
        /// </summary>
        public double FLockQTY
        {
            get
            {
                return _FLockQTY;
            }

            set
            {
                _FLockQTY = value;
            }
        }
        /// <summary>
        /// 锁库/预留标识
        /// </summary>
        public bool FLockFlag
        {
            get
            {
                return _FLockFlag;
            }

            set
            {
                _FLockFlag = value;
            }
        }
        /// <summary>
        /// 批量锁库标识
        /// </summary>
        public bool FBatchFlag
        {
            get
            {
                return _FBatchFlag;
            }

            set
            {
                _FBatchFlag = value;
            }
        }
        /// <summary>
        /// 业务关闭
        /// </summary>
        public string FMRPCloseStatus
        {
            get
            {
                return _FMRPCloseStatus;
            }

            set
            {
                _FMRPCloseStatus = value;
            }
        }
        /// <summary>
        /// 业务终止
        /// </summary>
        public string FMRPTerminateStatus
        {
            get
            {
                return _FMRPTerminateStatus;
            }

            set
            {
                _FMRPTerminateStatus = value;
            }
        }
        //--
    }
}
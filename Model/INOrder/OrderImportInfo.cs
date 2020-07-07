using System;

namespace ERPSupport.Model.INOrder
{
    /// <summary>
    /// 网上订单系统销售订单实体
    /// </summary>
    public class OrderImportInfo
    {
        public OrderImportInfo() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pBasicDataID"></param>
        /// <param name="pBrandID"></param>
        /// <param name="pSeriesID"></param>
        /// <param name="pCommodityID"></param>
        /// <param name="pPricingFactorID"></param>
        /// <param name="pGeneralFactoryPrice"></param>
        /// <param name="pBranchFactoryPrice"></param>
        public OrderImportInfo (string pBasicDataID,string pBrandID,string pSeriesID,string pCommodityID,string pPricingFactorID,float pGeneralFactoryPrice,float pBranchFactoryPrice)
        {
            _BasicDataID = pBasicDataID;
            _BrandID = pBrandID;
            _SeriesID = pSeriesID;
            _CommodityID = pCommodityID;
            _PricingFactorID = pPricingFactorID;
            _GeneralFactoryPrice = pGeneralFactoryPrice;
            _BranchFactoryPrice = pBranchFactoryPrice;
            _TimeBegin = DateTime.Now;
            _TimeEnd = DateTime.Now.AddYears(1);
            _IsEnable = true;
        }

        private string _BasicDataID;
        private string _BrandID;
        private string _SeriesID;
        private string _CommodityID;
        private string _PricingFactorID;
        private float _GeneralFactoryPrice;
        private float _BranchFactoryPrice;
        private DateTime? _TimeBegin;
        private DateTime? _TimeEnd;
        private bool? _IsEnable;

        /// <summary>
        /// 小类
        /// </summary>
        public string BasicDataID
        {
            get
            {
                return _BasicDataID;
            }

            set
            {
                _BasicDataID = value;
            }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandID
        {
            get
            {
                return _BrandID;
            }

            set
            {
                _BrandID = value;
            }
        }
        /// <summary>
        /// 系列
        /// </summary>
        public string SeriesID
        {
            get
            {
                return _SeriesID;
            }

            set
            {
                _SeriesID = value;
            }
        }
        /// <summary>
        /// 商品名
        /// </summary>
        public string CommodityID
        {
            get
            {
                return _CommodityID;
            }

            set
            {
                _CommodityID = value;
            }
        }
        /// <summary>
        /// 定价要素
        /// </summary>
        public string PricingFactorID
        {
            get
            {
                return _PricingFactorID;
            }

            set
            {
                _PricingFactorID = value;
            }
        }
        /// <summary>
        /// 省代价
        /// </summary>
        public float GeneralFactoryPrice
        {
            get
            {
                return _GeneralFactoryPrice;
            }

            set
            {
                _GeneralFactoryPrice = value;
            }
        }
        /// <summary>
        /// 市代价
        /// </summary>
        public float BranchFactoryPrice
        {
            get
            {
                return _BranchFactoryPrice;
            }

            set
            {
                _BranchFactoryPrice = value;
            }
        }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime? TimeBegin
        {
            get
            {
                return _TimeBegin;
            }

            set
            {
                _TimeBegin = value;
            }
        }
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime? TimeEnd
        {
            get
            {
                return _TimeEnd;
            }

            set
            {
                _TimeEnd = value;
            }
        }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool? IsEnable
        {
            get
            {
                return _IsEnable;
            }

            set
            {
                _IsEnable = value;
            }
        }
    }
}

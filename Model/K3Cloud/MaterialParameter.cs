using System;

namespace ERPSupport.Model.K3Cloud
{
    /// <summary>
    /// 物料参数实体
    /// </summary>
    public class MaterialParameter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialParameter() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pF_PAEZ_SAFEDAYS">安全库存天数</param>
        /// <param name="pF_PAEZ_LOGISTICSDAYS">物流天数</param>
        /// <param name="pF_PAEZ_REPLENISHMENT">补货量（天数）</param>
        /// <param name="pF_PAEZ_LOWQTY">最低订货量</param>
        /// <param name="pF_PAEZ_MINQTY">最小批量</param>
        public MaterialParameter(int pF_PAEZ_SAFEDAYS,int pF_PAEZ_LOGISTICSDAYS,int pF_PAEZ_REPLENISHMENT,decimal pF_PAEZ_LOWQTY,decimal pF_PAEZ_MINQTY)
        {
            _F_PAEZ_SAFEDAYS = pF_PAEZ_SAFEDAYS;
            _F_PAEZ_LOGISTICSDAYS = pF_PAEZ_LOGISTICSDAYS;
            _F_PAEZ_REPLENISHMENT = pF_PAEZ_REPLENISHMENT;
            _F_PAEZ_LOWQTY = pF_PAEZ_LOWQTY;
            _F_PAEZ_MINQTY = pF_PAEZ_MINQTY;
        }

        //--------------------字段
        private int _F_PAEZ_SAFEDAYS;
        private int _F_PAEZ_LOGISTICSDAYS;
        private int _F_PAEZ_REPLENISHMENT;
        private decimal _F_PAEZ_LOWQTY;
        private decimal _F_PAEZ_MINQTY;

        //--------------------属性
        /// <summary>
        /// 安全库存天数
        /// </summary>
        public int F_PAEZ_SAFEDAYS
        {
            get
            {
                return _F_PAEZ_SAFEDAYS;
            }

            set
            {
                _F_PAEZ_SAFEDAYS = value;
            }
        }
        /// <summary>
        /// 物流天数
        /// </summary>
        public int F_PAEZ_LOGISTICSDAYS
        {
            get
            {
                return _F_PAEZ_LOGISTICSDAYS;
            }

            set
            {
                _F_PAEZ_LOGISTICSDAYS = value;
            }
        }
        /// <summary>
        /// 补货量（天数）
        /// </summary>
        public int F_PAEZ_REPLENISHMENT
        {
            get
            {
                return _F_PAEZ_REPLENISHMENT;
            }

            set
            {
                _F_PAEZ_REPLENISHMENT = value;
            }
        }
        /// <summary>
        /// 最低订货量
        /// </summary>
        public decimal F_PAEZ_LOWQTY
        {
            get
            {
                return _F_PAEZ_LOWQTY;
            }

            set
            {
                _F_PAEZ_LOWQTY = value;
            }
        }
        /// <summary>
        /// 最小批量
        /// </summary>
        public decimal F_PAEZ_MINQTY
        {
            get
            {
                return _F_PAEZ_MINQTY;
            }

            set
            {
                _F_PAEZ_MINQTY = value;
            }
        }
    }
}

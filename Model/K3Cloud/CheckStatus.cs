using System;

namespace ERPSupport.Model.K3Cloud
{
    /// <summary>
    /// 状态实体
    /// </summary>
    public class CheckStatus
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CheckStatus() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pSequence">序号</param>
        /// <param name="pChStatus">状态</param>
        public CheckStatus(int pSequence,bool pChStatus)
        {
            _sequence = pSequence;
            _chStatus = pChStatus;
        }

        private int _sequence;
        private bool _chStatus;

        /// <summary>
        /// 序号
        /// </summary>
        public int Sequence
        {
            get
            {
                return _sequence;
            }

            set
            {
                _sequence = value;
            }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public bool ChStatus
        {
            get
            {
                return _chStatus;
            }

            set
            {
                _chStatus = value;
            }
        }
    }
}

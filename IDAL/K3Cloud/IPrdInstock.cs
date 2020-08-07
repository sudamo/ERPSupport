using System;
using System.Data;

namespace ERPSupport.IDAL.K3Cloud
{
    public interface IPrdInstock
    {
        DataTable GetInfo(string pBillNo);

        void UpdateBarcode(string pBillNo);

        /// <summary>
        /// 生产订单信息
        /// </summary>
        /// <param name="pPlanStartDate">计划开工日期</param>
        /// <param name="pFormId">业务标识</param>
        /// <returns></returns>
        DataTable GetMo(string pPlanStartDate, Model.Enum.FormID pFormId);
    }
}

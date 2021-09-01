using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace ERPSupport.IDAL.K3Cloud
{
    public interface ISalOrder
    {
        void Log_OrderLock(Model.K3Cloud.OrderInfo pEntry, int pType, string pRemark);
        void Log_OrderLock(DataRow pDR, int pType);
        DataTable GetDataSource(Model.Enum.FormID pFormId, string pFilter, Model.K3Cloud.OrderInfo pOrderInf);
        DataTable GetOrderLockByFEntryId(int pFEntryId);
        void UpdateOrderLock(string pCanLockQty, int pFID, int pFEntryId);
        void UnLockSalOrder(string pLockQty, int pFEntryId);
        void UpdateOrderLock(string pCanLockQty, int pFEntryId);
        void UpdateBatchFlag(IList pList);
        string AddReserveLink(DataRow pDR, double pQTY);
        DataTable GetInventoryInfByMaterialId(string pFMaterialId);
        DataTable OrderRun(DataTable pDtRun, bool pJoinQty);
        DataTable OrderRun(List<int> pRunEntryId, DateTime pStarTime, DateTime pEndTime, bool pJoinQty);
        void SaveOrderRun(DataRow pDr, string pBillNo, int pSEQ);
        void SaveOrderRunDetail(DataTable pDt, string pFEntryId);
        void UpdateOrderFields(int pFEntryID, string pOweLevel);
        DataTable GetBillInfo(string pType, string pFBillNo);
        string UpdateSingle(string pFBillNo, bool pSingle);
        void UpdateOrderCanOutQty(string pFEntryId, decimal pCanOutQty);
        void UpdateCustomer(string pFBillNo, int pFEntryId, int pCustomerId, bool pOutStock, bool pReceivable, bool pReturnNotice, bool pReturnStock);
        void UpdateUiCityOrders(int pFactoryOrgId, int pSaleOrgId, int pSaleDeptId, int pSalerId, List<string> pFBillNos);
        DataTable NoPriceOrders(string pSaleOrgs);
        string UpdateOrderPirce(DataTable pOrders);
    }
}

using System;
using System.Data;
using System.Collections.Generic;

namespace ERPSupport.IDAL.K3Cloud
{
    public interface IPrdAllocation
    {
        DataTable GetTransPZ(string pFNeedDate, int pStockID, int pDeptID);
        DataTable GetTransCL(string pFNeedDate, int pStockID, int pDeptID, string pCondition);
        DataTable GetTransCL(string pFNeedDate, int pStockID, int pDeptID, string pCondition, bool pIsTran, int pOrgId = 100508);
        string TransferDirERP(DataTable pDataTable, string pDate);
        DataTable GetTransForP(string pFilter);
        DataTable GetTransForP(List<string> pList);
        string TransferDir(DataTable pDataTable, List<string> pList, bool pIsDepart);
        void UpdateDirFieldsCL(string pFNeedDate, int pOrgId = 100508);
        bool SetDefaultStock(DateTime pDateTime, Model.Enum.FormID pFormId);
        int Asyn_PPBom_FNeedDate(DateTime pFrom, DateTime pTo);
        void Syn_PPBom_FNeedDate(DateTime pFrom, DateTime pTo);
        void UpdateMST_Tran();
        string TransferDirWMS(DataTable pDataTable, string pDate);
        string TransferDirWMS(DataTable pDataTable, string pDate, bool pIsTran);
        DataTable GetPPBomByBillNo(string pBillNo);
        void UpdatePPBom(bool pSyn, bool pType, int pFEntryId, string pMTLNumber, string pNewMTLNumber, decimal pFZ, decimal pMustQty, DateTime pNeedDate);
        void UpdatePPBom(string pMoBillNos, bool pDir);
        DataTable GetNotice(DateTime pFDate, string pFBillNo);
        void UpdateNotice(List<string> pList);
        DataTable GetWMSSP();
        void SynSPToERP(DataTable pData);
    }
}

using System;
using System.Data;

namespace ERPSupport.IDAL.K3Cloud
{
    public interface IPrdOutstock
    {
        DataTable DataSource(string pBillNo);

        void UpdateData(string pBillNo, int pUseOrgId);

        void SynPrice(string pYearMonth);
    }
}

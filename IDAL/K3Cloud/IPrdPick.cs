using System;
using System.Data;

namespace ERPSupport.IDAL.K3Cloud
{
    public interface IPrdPick
    {
        string PickMtl(string pBillNO);

        DataTable GetInstockBillNo(DateTime pDateTime);
    }
}

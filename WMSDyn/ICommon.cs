using System;
using System.Data;
using ERPSupport.Model.Drawing;

namespace ERPSupport.WMSDyn
{
    /// <summary>
    /// Common接口
    /// </summary>
    public interface ICommon
    {
        //string this[int index] { get; set; }
        //event EventHandler even;
        //UserInfo User
        //{
        //    get;
        //}

        string UserLogin(string pUserName, string pPassword);
        void UserLogout();
        string GetUserDrawing(string pBarcode);
        DataTable GetUserDrawing();
        string GetUserDrawing(string pName, string pBarcode);
        UserInfo GetUserInfoByName(string pName);
        MoInfo GetMoInfoByBarcode(string pBarcode);
        DrawingInfo GetDrawingInfoByFNumber(string pFNumber);
        MaterialInfo GetMaterialInfoByFNumber(string pFNumber);
        OperationInfo GetOperationInfoByBarcode(string pBarcode);
        DataTable GetOperations(string pBarcode, string pFBillNo, string pOperator, DateTime pFrom, DateTime pTo);
        void Log_Operation(OperationInfo pOperation);
        string EncryptData(string pPassword);
    }
}

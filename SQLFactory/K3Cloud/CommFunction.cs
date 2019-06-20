﻿using System;
using System.Net;
using System.Data;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using Oracle.ManagedDataAccess.Client;
using ERPSupport.Model.Enum;
using ERPSupport.Model.Globa;
using ERPSupport.Model.K3Cloud;

namespace ERPSupport.SQL.K3Cloud
{
    /// <summary>
    /// 公共方法
    /// </summary>
    public static class CommFunction
    {
        #region STATIC
        private static string _SQL;
        private static object _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        static CommFunction()
        {
            _SQL = string.Empty;
            _obj = new object();
        }
        #endregion

        #region 数据库连接检验
        /// <summary>
        /// 数据库连接检验
        /// </summary>
        /// <returns></returns>
        public static int DB_Connection(string pConnectionString)
        {
            OracleConnection conn = new OracleConnection(pConnectionString);
            object oTest = null;
            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT 1 FROM DUAL";
                oTest = cmd.ExecuteScalar();
            }
            catch
            {
                return -1;//数据库连接失败
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            if (oTest == null)
                return 0;//数据库查询失败

            return 1;//数据库测试正常
        }
        #endregion

        #region Foundation
        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="pConnectionString">数据库连接字符串</param>
        /// <param name="pUserName">用户名</param>
        /// <returns>int:UserId</returns>
        public static int GetUserId(string pConnectionString, string pUserName)
        {
            _SQL = "SELECT FUSERID FROM T_SEC_USER WHERE FNAME = '" + pUserName + "'";
            _obj = ORAHelper.ExecuteScalar(pConnectionString, _SQL);

            if (_obj == null)
                return -1;
            else
                return int.Parse(_obj.ToString());
        }

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="pConnectionString"></param>
        /// <param name="pUserName"></param>
        /// <returns></returns>
        public static DataTable GetUserInfoByName(string pConnectionString, string pUserName)
        {
            _SQL = @"SELECT US.FUSERID,NVL(UR.RIDS,' ') RIDS,NVL(WM_CONCAT(R.MIDS),' ') MIDS,US.FPHONE,NVL(DEP.FDEPTID,0) FDEPTID,NVL(DEP.FNUMBER,' ') FDEPTNUMBER,NVL(DEPL.FNAME,' ') FDEPTNAME
            FROM T_SEC_USER US
            LEFT JOIN dm_user_role UR ON US.Fuserid = UR.USERID
            LEFT JOIN dm_role R ON INSTR(UR.RIDS,TO_CHAR(r.RID)) > 0
            LEFT JOIN T_BD_STAFF_L STFL ON US.FUSERACCOUNT = STFL.FNAME
            LEFT JOIN T_BD_STAFF STF ON STFL.FSTAFFID = STF.FSTAFFID
            LEFT JOIN T_BD_DEPARTMENT DEP ON STF.FDEPTID = DEP.FDEPTID
            LEFT JOIN T_BD_DEPARTMENT_L DEPL ON DEP.FDEPTID = DEPL.FDEPTID
            WHERE US.FNAME = '" + pUserName + @"'
            GROUP BY US.FUSERID,UR.RIDS,US.FPHONE,DEP.FDEPTID,DEP.FNUMBER,DEPL.FNAME";

            return ORAHelper.ExecuteTable(pConnectionString, _SQL);
        }

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable User()
        {
            _SQL = @"SELECT UR.FUSERID,UR.FNAME 姓名,URGL.FNAME 部门,UR.FUSERACCOUNT 账号,NVL(UR.FPHONE,' ') 电话
            FROM T_SEC_USER UR
            INNER JOIN T_SEC_USERGROUP_L URGL ON UR.FPRIMARYGROUP = URGL.FID AND URGL.FLOCALEID = 2052
            WHERE UR.FUSERTYPE = '1' AND UR.FFORBIDSTATUS = 'A' AND UR.FPRIMARYGROUP <> 0
            ORDER BY URGL.FNAME,UR.FNAME";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 单据类型
        /// </summary>
        /// <param name="pFbillFormId">业务标识</param>
        /// <returns></returns>
        public static DataTable GetBillType(string pFbillFormId)
        {
            _SQL = @"SELECT A.FBILLTYPEID FValue,AL.FNAME
            FROM T_BAS_BILLTYPE A
            INNER JOIN T_BAS_BILLTYPE_L AL ON A.FBILLTYPEID = AL.FBILLTYPEID AND AL.FLOCALEID = 2052
            WHERE UPPER(FBILLFORMID) = '" + pFbillFormId.ToUpper() + @"' AND FDOCUMENTSTATUS = 'C' AND FFORBIDSTATUS = 'A'
            ORDER BY A.FNUMBER";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取部门ID
        /// </summary>
        /// <param name="pFUseOrgId">使用组织</param>
        /// <param name="pFNumber">编码</param>
        /// <returns></returns>
        public static int GetDepartIdByNumber(int pFUseOrgId, string pFNumber)
        {
            _SQL = "SELECT FDEPTID FROM T_BD_DEPARTMENT WHERE FUSEORGID = " + pFUseOrgId.ToString() + " AND FNUMBER = '" + pFNumber + "'";
            _obj = ORAHelper.ExecuteScalar(_SQL);

            if (_obj == null)
                return -1;
            else
                return int.Parse(_obj.ToString());
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="pType">选择类型</param>
        /// <param name="pUseOrgId">使用组织ID</param>
        /// <param name="pProperty">部门属性名称</param>
        /// <returns></returns>
        public static DataTable GetDepartment(int pType, int pUseOrgId, string pProperty)
        {
            switch (pType)
            {
                case 1:
                    _SQL = @"SELECT A.FNUMBER FVALUE,AL.FNAME
                    FROM T_BD_DEPARTMENT A
                    INNER JOIN T_BD_DEPARTMENT_L AL ON A.FDEPTID = AL.FDEPTID AND AL.FLOCALEID = 2052
                    WHERE A.FDOCUMENTSTATUS = 'C' AND A.FFORBIDSTATUS = 'A' AND A.FUSEORGID = " + pUseOrgId + @"
                    ORDER BY A.FNUMBER";
                    break;
                case 2:
                    _SQL = @"SELECT A.FNUMBER FVALUE,AL.FNAME
                    FROM T_BD_DEPARTMENT A
                    INNER
                    JOIN T_BD_DEPARTMENT_L AL ON A.FDEPTID = AL.FDEPTID AND AL.FLOCALEID = 2052
                    INNER JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL ON A.FDEPTPROPERTY = ASSL.FENTRYID AND ASSL.FLOCALEID = 2052
                    WHERE A.FDOCUMENTSTATUS = 'C' AND A.FFORBIDSTATUS = 'A' AND A.FUSEORGID = " + pUseOrgId + " AND ASSL.FDATAVALUE = '" + pProperty + @"'
                    ORDER BY A.FNUMBER";
                    break;
                case 3:
                    if (pProperty == string.Empty)
                        _SQL = @"SELECT A.FNUMBER||'|'||A.FDEPTID FVALUE,AL.FNAME
                        FROM T_BD_DEPARTMENT A
                        INNER JOIN T_BD_DEPARTMENT_L AL ON A.FDEPTID = AL.FDEPTID AND AL.FLOCALEID = 2052
                        WHERE A.FDOCUMENTSTATUS = 'C' AND A.FFORBIDSTATUS = 'A' AND A.FUSEORGID = " + pUseOrgId + " ORDER BY A.FNUMBER";
                    else//
                        _SQL = @"SELECT N'-1' FVALUE,N'请选择' FNAME FROM DUAL
                        UNION ALL
                        SELECT A.FNUMBER||'|'||A.FDEPTID FVALUE,AL.FNAME
                        FROM T_BD_DEPARTMENT A
                        INNER
                        JOIN T_BD_DEPARTMENT_L AL ON A.FDEPTID = AL.FDEPTID AND AL.FLOCALEID = 2052
                        INNER JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL ON A.FDEPTPROPERTY = ASSL.FENTRYID AND ASSL.FLOCALEID = 2052
                        WHERE A.FDOCUMENTSTATUS = 'C' AND A.FFORBIDSTATUS = 'A' AND A.FUSEORGID = " + pUseOrgId + " AND ASSL.FDATAVALUE = '" + pProperty + @"'
                        ORDER BY FVALUE";
                    break;
                case 4://获取领料部门信息
                    _SQL = "SELECT FNUMBER FROM DM_PICKMTLDEPARTMENT WHERE ISDELETE = '0' ORDER BY FNUMBER";
                    break;
                default:
                    _SQL = @"SELECT A.FNUMBER FVALUE,AL.FNAME
                    FROM T_BD_DEPARTMENT A
                    INNER JOIN T_BD_DEPARTMENT_L AL ON A.FDEPTID = AL.FDEPTID AND AL.FLOCALEID = 2052
                    WHERE A.FDOCUMENTSTATUS = 'C' AND A.FFORBIDSTATUS = 'A' AND A.FUSEORGID = 100508
                    ORDER BY A.FNUMBER";
                    break;
            }
            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取领料部门信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPickMtlDepartment()
        {
            return ORAHelper.ExecuteTable("SELECT FNUMBER FROM DM_PICKMTLDEPARTMENT WHERE ISDELETE = '0' ORDER BY FNUMBER");
        }

        /// <summary>
        /// 获取仓库ID
        /// </summary>
        /// <param name="pFUseOrgId">使用组织</param>
        /// <param name="pFNumber">编码</param>
        /// <returns></returns>
        public static int GetStockIdByNumber(int pFUseOrgId, string pFNumber)
        {
            _SQL = "SELECT FSTOCKID FROM T_BD_STOCK WHERE FUSEORGID = " + pFUseOrgId.ToString() + " AND FNUMBER = '" + pFNumber + "'";
            _obj = ORAHelper.ExecuteScalar(_SQL);

            if (_obj == null)
                return -1;
            else
                return int.Parse(_obj.ToString());
        }

        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <param name="pType">类型</param>
        /// <param name="pUserOrgId">使用组织</param>
        /// <returns></returns>
        public static DataTable GetStock(int pType = -1, int pUserOrgId = 100508)
        {
            switch (pType)
            {
                case 0:
                    _SQL = @"SELECT SK.FNUMBER FVALUE,SKL.FNAME
                    FROM T_BD_STOCK SK
                    INNER JOIN T_BD_STOCK_L SKL ON SK.FSTOCKID = SKL.FSTOCKID AND SKL.FLOCALEID = 2052
                    INNER JOIN T_BD_STOCKGROUP SKG ON SK.FGROUP = SKG.FID
                    WHERE SK.FDOCUMENTSTATUS = 'C' AND SK.FFORBIDSTATUS = 'A'
                    ORDER BY SKL.FNAME";
                    break;
                case 1:
                    _SQL = @"SELECT SK.FNUMBER||'|'||SK.FSTOCKID FVALUE,SKL.FNAME
                    FROM T_BD_STOCK SK
                    INNER JOIN T_BD_STOCK_L SKL ON SK.FSTOCKID = SKL.FSTOCKID AND SKL.FLOCALEID = 2052
                    WHERE SK.FDOCUMENTSTATUS = 'C' AND SK.FFORBIDSTATUS = 'A'
                    ORDER BY SK.FNUMBER";
                    break;
                case 2:
                    _SQL = @"SELECT SK.FNUMBER||'|'||SK.FSTOCKID FVALUE,SKL.FNAME
                    FROM T_BD_STOCK SK
                    INNER JOIN T_BD_STOCK_L SKL ON SK.FSTOCKID = SKL.FSTOCKID AND SKL.FLOCALEID = 2052
                    WHERE SK.FDOCUMENTSTATUS = 'C' AND SK.FFORBIDSTATUS = 'A' AND SK.FUSEORGID = " + pUserOrgId.ToString() + @"
                    ORDER BY SK.FNUMBER";
                    break;
                case 3:
                    _SQL = @"SELECT N'-1' FVALUE,N'请选择' FNAME FROM DUAL
                    UNION ALL
                    SELECT SK.FNUMBER||'|'||SK.FSTOCKID FVALUE,SKL.FNAME
                    FROM T_BD_STOCK SK
                    INNER JOIN T_BD_STOCK_L SKL ON SK.FSTOCKID = SKL.FSTOCKID AND SKL.FLOCALEID = 2052
                    WHERE SK.FDOCUMENTSTATUS = 'C' AND SK.FFORBIDSTATUS = 'A' AND SK.FDEFSTOCKSTATUSID = 10000 --AND SK.FALLOWSUM = '0'
                    ORDER BY FVALUE";
                    break;
                default:
                    _SQL = @"SELECT SK.FNUMBER FValue,SKL.FNAME FName
                    FROM T_BD_STOCK SK
                    INNER JOIN T_BD_STOCK_L SKL ON SK.FSTOCKID = SKL.FSTOCKID AND SKL.FLOCALEID = 2052
                    INNER JOIN T_BD_STOCKGROUP SKG ON SK.FGROUP = SKG.FID
                    WHERE SK.FDOCUMENTSTATUS = 'C' AND SK.FFORBIDSTATUS = 'A' AND SUBSTR(SKG.FNUMBER,1,2) IN('H1','H2')
                    ORDER BY SK.FNUMBER";
                    break;
            }

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 根据仓库名称获取编码
        /// </summary>
        /// <param name="pFName"></param>
        /// <returns></returns>
        public static string GetStockNumber(string pFName)
        {
            _SQL = "SELECT A.FNUMBER FROM T_BD_STOCK A INNER JOIN T_BD_STOCK_L AL ON A.FSTOCKID = AL.FSTOCKID AND AL.FLOCALEID = 2052 WHERE AL.FNAME = '" + pFName + "'";
            _obj = ORAHelper.ExecuteScalar(_SQL);

            if (_obj != null)
                return _obj.ToString();
            else
                return "";
        }

        /// <summary>
        /// 获取组织结构信息
        /// </summary>
        /// <param name="pAcctype">类型：1、法人组织；2、利润中心</param>
        /// <returns></returns>
        public static DataTable GetOrganization(int pAcctype)
        {
            _SQL = @"SELECT ORG.FORGID FVALUE,ORGL.FNAME
            FROM T_ORG_ORGANIZATIONS ORG
            INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON ORG.FORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
            WHERE ORG.FDOCUMENTSTATUS = 'C' AND ORG.FFORBIDSTATUS = 'A' AND ORG.FACCTORGTYPE = " + pAcctype.ToString() + " ORDER BY ORGL.FNAME";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取组织结构信息
        /// </summary>
        /// <param name="pType">所需信息类型</param>
        /// <returns></returns>
        public static DataTable GetOrganization(string pType)
        {
            if (pType == "LOCKSTOCK")
                _SQL = @"SELECT -1 FVALUE,'全部' FNAME FROM DUAL
                UNION
                SELECT ORG.FORGID,TO_CHAR(ORGL.FNAME)
                FROM T_ORG_ORGANIZATIONS ORG
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON ORG.FORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
                WHERE ORG.FDOCUMENTSTATUS = 'C' AND ORG.FFORBIDSTATUS = 'A' AND ORG.FISSYSPRESET = 0 AND ORG.FISBUSINESSORG = 1 AND ORG.FACCTORGTYPE = 2 AND ORG.FORGID <> 100507";
            else
                _SQL = @"SELECT ORG.FORGID FVALUE,TO_CHAR(ORGL.FNAME) FNAME
                FROM T_ORG_ORGANIZATIONS ORG
                INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON ORG.FORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
                WHERE ORG.FDOCUMENTSTATUS = 'C' AND ORG.FFORBIDSTATUS = 'A'";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 根据类别FID获取辅助资料信息
        /// </summary>
        /// <param name="pFID"></param>
        /// <returns></returns>
        public static DataTable GetAssistantDataEntryByFID(string pFID)
        {
            _SQL = @"SELECT ASS.FENTRYID FVALUE,ASSL.FDATAVALUE FNAME
            FROM T_BAS_ASSISTANTDATAENTRY ASS
            INNER JOIN T_BAS_ASSISTANTDATAENTRY_L ASSL ON ASS.FENTRYID = ASSL.FENTRYID AND ASSL.FLOCALEID = 2052
            WHERE ASS.FID = '" + pFID + "'";

            return ORAHelper.ExecuteTable(_SQL);
        }
        #endregion

        #region DM

        /// <summary>
        /// 应用程序状态
        /// </summary>
        /// <param name="pConnectionString">数据库连接字符串</param>
        /// <param name="pAppName">应用程序名</param>
        /// <returns>整形 -1：没有记录；0：未启用；1：启用；2或其他：弃用</returns>
        public static int ApplicationFlag(string pConnectionString, string pAppName)
        {
            _SQL = "SELECT FLAG FROM DM_APP_MANAGE WHERE ISDEL = '0' AND APPNAME = '" + pAppName + "'";

            _obj = ORAHelper.ExecuteScalar(pConnectionString, _SQL);

            if (_obj == null)
                return -1;
            else
                return int.Parse(_obj.ToString());
        }

        /// <summary>
        /// 获取所有二级模块NodeNo
        /// </summary>
        /// <returns></returns>
        public static List<string> GetNavigation()
        {
            List<string> list;
            DataTable dt;

            try
            {
                list = new List<string>();
                dt = ORAHelper.ExecuteTable("SELECT DISTINCT NODENO FROM DM_EXPRESS_NAVIGATION WHERE NODENO IS NOT NULL AND LV = 2");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(dt.Rows[i]["NODENO"].ToString());
                }
                return list;
            }
            catch
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// 根据用户权限获取功能模块
        /// </summary>
        /// <param name="pRIDs">用户角色</param>
        /// <param name="pMIDs">模块</param>
        /// <param name="pFunctionIds">功能</param>
        /// <returns></returns>
        public static DataTable GetNavigation(out string pRIDs, out string pMIDs, out string pFunctionIds)
        {
            //获取二级菜单NODEID
            DataTable dtRuleS;
            object oTemp;

            pRIDs = string.Empty;
            pMIDs = string.Empty;
            pFunctionIds = string.Empty;
            oTemp = ORAHelper.ExecuteScalar("SELECT RIDS FROM DM_USER_ROLE WHERE USERID = " + GlobalParameter.K3Inf.UserId);

            if (oTemp != null && oTemp.ToString().Trim() != string.Empty)
            {
                pRIDs = oTemp.ToString();
                dtRuleS = ORAHelper.ExecuteTable("SELECT MIDS,FUNCTIONID FROM DM_ROLE WHERE RID IN(" + pRIDs + ")");

                if (dtRuleS != null && dtRuleS.Rows.Count > 0)
                {
                    for (int i = 0; i < dtRuleS.Rows.Count; i++)
                    {
                        if (i != 0)
                        {
                            pMIDs += ",";
                            pFunctionIds += ",";
                        }

                        pMIDs += dtRuleS.Rows[i]["MIDS"].ToString();
                        pFunctionIds += dtRuleS.Rows[i]["FUNCTIONID"].ToString();
                    }
                }
            }

            //添加一级菜单NODEID 改用List<string> Contains的方法来判断。
            if (pMIDs.Trim() != "")
            {
                if (pMIDs.IndexOf("10") >= 0)
                    pMIDs += ",1";
                if (pMIDs.IndexOf("20") >= 0)
                    pMIDs += ",2";
                if (pMIDs.IndexOf("30") >= 0)
                    pMIDs += ",3";
                if (pMIDs.IndexOf("40") >= 0)
                    pMIDs += ",4";
                if (pMIDs.IndexOf("50") >= 0)
                    pMIDs += ",5";
            }
            else
                pMIDs = "1";

            //获取一级和二级控件
            string strSQLControls;

            if (GlobalParameter.K3Inf.UserName.ToUpper().Equals("ADMINISTRATOR"))
            {
                strSQLControls = "SELECT NODEID,NODENAME,PARENTID,LV FROM DM_EXPRESS_NAVIGATION ORDER BY NODEID";
            }
            else
            {
                strSQLControls = "SELECT NODEID,NODENAME,PARENTID,LV FROM DM_EXPRESS_NAVIGATION WHERE NODEID IN(" + pMIDs + ") ORDER BY NODEID";
            }

            return ORAHelper.ExecuteTable(strSQLControls);
        }

        /// <summary>
        /// 根据父项ID获取子项数
        /// </summary>
        /// <param name="pK3Inf">配置</param>
        /// <param name="pParentId">父项ID</param>
        /// <returns></returns>
        public static int ChildNumber(string pParentId)
        {
            _SQL = "SELECT COUNT(*) FROM DM_EXPRESS_NAVIGATION WHERE PARENTID = " + pParentId;
            return int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString());
        }

        /// <summary>
        /// 根据类别获取LockObject信息
        /// </summary>
        /// <param name="pCategory">类别</param>
        /// <returns></returns>
        public static DataTable GetLockObjectInfo(string pCategory)
        {
            _SQL = "SELECT FSTATUS,FUSER FROM DM_LOCKOBJECT WHERE CATEGORY = '" + pCategory + "'";
            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 根据类别、状态获取LockObject信息
        /// </summary>
        /// <param name="pCategory">类别</param>
        /// <param name="pStatus">状态</param>
        /// <returns></returns>
        public static object GetLockObjectInfo(string pCategory, int pStatus)
        {
            _SQL = "SELECT FUSER FROM DM_LOCKOBJECT WHERE CATEGORY = '" + pCategory + "' AND FSTATUS = " + pStatus;
            return ORAHelper.ExecuteScalar(_SQL);
        }

        /// <summary>
        /// 更新LockObject
        /// </summary>
        /// <param name="pStatus">状态:0、解除占用；1、占用</param>
        /// <param name="pCategory">类别</param>
        public static void UpdateLockStatus(int pStatus, string pCategory)
        {
            if (pStatus == 1)//设置占用状态
            {
                _SQL = "UPDATE DM_LOCKOBJECT SET MODIFYDATE = SYSDATE, FSTATUS = '1', FUSER = '" + GlobalParameter.K3Inf.UserName + "' WHERE Category = '" + pCategory + "'";
            }
            else if (pStatus == 0)//解除占用状态
            {
                _SQL = "UPDATE DM_LOCKOBJECT SET MODIFYDATE = SYSDATE, FSTATUS = '0', FUSER = 'None' WHERE Category = '" + pCategory + "'";
            }

            if (_SQL != string.Empty)
                ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 获取锁表信息
        /// </summary>
        /// <param name="pCategory">分类</param>
        /// <returns></returns>
        public static DataTable DM_LockObjectInfo(string pCategory)
        {
            _SQL = "SELECT CASE WHEN CEIL((SYSDATE - MODIFYDATE) * 24 * 60) >= 5 THEN '0' ELSE FSTATUS END FSTATUS, FUSER,FTYPE FROM DM_LOCKOBJECT WHERE CATEGORY = '" + pCategory + "'";
            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 根据Category新增LockObject
        /// </summary>
        /// <param name="pCategory"></param>
        public static void DM_LockObject_Add(string pObName, string pFType, string pDescription, string pCategory)
        {
            _SQL = "INSERT INTO DM_LOCKOBJECT(OBNAME,FUSER,FSTATUS,FTYPE,DESCRIPTION,CATEGORY) VALUES('" + pObName + "','None',0,'" + pFType + "','" + pDescription + "','" + pCategory + "')";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 查找方案名是否已存在
        /// </summary>
        /// <param name="pName">方案名</param>
        /// <returns></returns>
        public static int SolutionName(string pName)
        {
            _SQL = "SELECT COUNT(*) FROM DM_FILTER_SOLUTION WHERE SNAME = '" + pName + "'";
            return int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString());
        }

        /// <summary>
        /// 获取方案信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSolution(FormID pFormID)
        {
            _SQL = "SELECT SNAME 方案名,CREATOR 创建人,TO_CHAR(CREATEDATE,'yyyy-mm-dd') 创建日期 FROM DM_FILTER_SOLUTION WHERE INSTR(FORMID,'" + pFormID + "') > 0 AND (ISSHARE = '1' OR CREATOR = '" + Model.Globa.GlobalParameter.K3Inf.UserName + "') ORDER BY SNAME";
            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取方案信息
        /// </summary>
        /// <param name="pName">方案名</param>
        /// <returns></returns>
        public static DataTable GetSolution(string pName)
        {
            _SQL = "SELECT SCONTENT,SROWS,CREATOR FROM DM_FILTER_SOLUTION WHERE SNAME = '" + pName + "'";
            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 保存方案名
        /// </summary>
        /// <param name="pName">方案名</param>
        /// <param name="pIsShare">是否共享</param>
        /// <param name="pContent">内文</param>
        /// <param name="pRows">条件数</param>
        /// <param name="pFromID">业务标识</param>
        public static void SaveSolution(string pName, bool pIsShare, string pContent, int pRows, FormID pFromID)
        {
            if (pFromID == FormID.SAL_SaleOrder)
                pFromID = FormID.SAL_SaleOrderRun;//公用方案

            _SQL = "INSERT INTO DM_FILTER_SOLUTION(SNAME,CREATOR,ISSHARE,SCONTENT,SROWS,FORMID) VALUES('" + pName + "','" + GlobalParameter.K3Inf.UserName + "','" + (pIsShare ? "1" : "0") + "','" + pContent + "'," + pRows.ToString() + ",'" + pFromID + "')";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 更新方案
        /// </summary>
        /// <param name="pName">方案名</param>
        /// <param name="pContent">内文</param>
        /// <param name="pRows">条件数</param>
        public static void UpdateSolution(string pName, string pContent, int pRows)
        {
            _SQL = "UPDATE DM_FILTER_SOLUTION SET SCONTENT = '" + pContent + "',SROWS = " + pRows.ToString() + " WHERE SNAME = '" + pName + "'";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 根据名称删除方案
        /// </summary>
        /// <param name="pName">方案名</param>
        public static void DelSolution(string pName)
        {
            _SQL = "DELETE FROM DM_FILTER_SOLUTION WHERE SNAME = '" + pName + "'";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 运单匹配
        /// </summary>
        /// <param name="pType">类型</param>
        /// <returns></returns>
        public static DataTable NumberMatch(string pType)
        {
            if (pType == "COMPANYNAME")
                _SQL = @"SELECT FID 内码,FNUMBER 匹配运单号,FLENGTH 运单号位数,TYPENAME 快递公司,NVL(DESCRIPTION,' ') 描述 FROM DM_NUMBERMATCH WHERE FTYPE = 'COMPANYNAME' AND ISUSE = '1' AND ISDELETE = '0' ORDER BY FID DESC";
            else if (pType == "UTMTL")
                _SQL = "SELECT FID,FNUMBER 编码前缀,CASE WHEN ISMATCH = '1' THEN '携带' ELSE '排除' END 是否携带,NVL(TYPENAME,' ') 类型名称,NVL(DESCRIPTION,' ') 描述,NVL(CREATOR,' ') 创建人,TO_CHAR(CREATEDATE,'yyyy-mm-dd') 创建日期,NVL(MODIFIER,' ') 修改人,TO_CHAR(MODIFYDATE,'yyyy-mm-dd') 修改日期 FROM DM_NUMBERMATCH WHERE ISUSE = '1' AND ISDELETE = '0' AND FTYPE = 'UTMTL'";
            if (_SQL.Equals(string.Empty))
                return null;
            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 匹配编码唯一性检查
        /// </summary>
        /// <param name="pType">类型</param>
        /// <param name="pNumber">编码</param>
        /// <returns></returns>
        public static bool NumberMatchExists(string pType, string pNumber)
        {
            _SQL = "SELECT COUNT(*) FROM DM_NUMBERMATCH WHERE ISUSE = '1' AND ISDELETE = '0' AND FTYPE = '" + pType + "' AND FNUMBER LIKE '" + pNumber + "%'";
            if (int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString()) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 匹配编码唯一性检查
        /// </summary>
        /// <param name="pType">类型</param>
        /// <param name="pFID">内码</param>
        /// <param name="pNumber">编码</param>
        /// <returns></returns>
        public static bool NumberMatchExists(string pType, int pFID, string pNumber)
        {
            _SQL = "SELECT COUNT(*) FROM DM_NUMBERMATCH WHERE ISUSE = '1' AND ISDELETE = '0' AND FTYPE = '" + pType + "' AND FID <> " + pFID.ToString() + " AND FNUMBER = '" + pNumber + "'";
            if (int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString()) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 匹配编码唯一性检查
        /// </summary>
        /// /// <param name="pType">类型</param>
        /// <param name="pNumber">编码</param>
        /// <param name="pLength">编码长度</param>
        /// <param name="pTypeName">类型</param>
        /// <returns></returns>
        public static bool NumberMatchExists(string pType, string pNumber, int pLength, string pTypeName)
        {
            _SQL = "SELECT COUNT(*) FROM DM_NUMBERMATCH WHERE ISUSE = '1' AND ISDELETE = '0' AND FTYPE = '" + pType + "' AND ((FNUMBER = '" + pNumber + "' AND FLENGTH = " + pLength.ToString() + ") OR TYPENAME = '" + pTypeName + "')";
            if (int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString()) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 匹配编码唯一性检查
        /// </summary>
        /// <param name="pType">类型</param>
        /// <param name="pFID">内码</param>
        /// <param name="pNumber">编码</param>
        /// <param name="pLength">编码长度</param>
        /// <param name="pTypeName">类型</param>
        /// <returns></returns>
        public static bool NumberMatchExists(string pType, int pFID, string pNumber, int pLength, string pTypeName)
        {
            _SQL = "SELECT COUNT(*) FROM DM_NUMBERMATCH WHERE FTYPE = '" + pType + "' AND ISDELETE = '0' AND FID <> " + pFID.ToString() + " AND ((FNUMBER = '" + pNumber + "' AND FLENGTH = " + pLength.ToString() + ") OR TYPENAME = '" + pTypeName + "')";
            if (int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString()) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增NumberMatch
        /// </summary>
        /// <param name="pType">类型</param>
        /// <param name="pNumber">编码</param>
        /// <param name="pLength">编码长度</param>
        /// <param name="pTypeNumber">类型编码</param>
        /// <param name="pTypeName">类型名称</param>
        /// <param name="pDescription">描述</param>
        /// <param name="pIsMatch">是否匹配，默认'0'</param>
        public static void AddNumberMatch(string pNumber, int pLength, string pType, string pTypeNumber, string pTypeName, string pDescription, string pIsMatch)
        {
            _SQL = @"INSERT INTO DM_NUMBERMATCH(FTYPE,FNUMBER,FLENGTH,TYPENUMBER,TYPENAME,CREATOR,DESCRIPTION,ISMATCH) VALUES('" + pType + "','" + pNumber + "'," + pLength.ToString() + ",'" + pTypeNumber + "','" + pTypeName + "','" + Model.Globa.GlobalParameter.K3Inf.UserName + "','" + pDescription + "','" + pIsMatch + "')";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 更新NumberMatch
        /// </summary>
        /// <param name="pFID">内码</param>
        /// <param name="pNumber">编码</param>
        /// <param name="pLength">编码长度</param>
        /// <param name="pTypeName">类型名称</param>
        public static void UpdateNumberMatch(int pFID, string pNumber, int pLength, string pTypeName)
        {
            _SQL = "UPDATE DM_NUMBERMATCH SET FNUMBER = '" + pNumber + "',FLENGTH = '" + pLength.ToString() + "',TYPENAME = '" + pTypeName + "',MODIFIER = '" + GlobalParameter.K3Inf.UserName + "',MODIFYDATE = SYSDATE WHERE FID = " + pFID.ToString();
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 更新NumberMatch
        /// </summary>
        /// <param name="pFID">内码</param>
        /// <param name="pNumber">编码</param>
        /// <param name="pDescription">描述</param>
        /// <param name="pIsMatch">是否匹配，默认'0'</param>
        public static void UpdateNumberMatch(int pFID, string pNumber, string pDescription, string pIsMatch)
        {
            _SQL = "UPDATE DM_NUMBERMATCH SET FNUMBER = '" + pNumber + "',MODIFIER = '" + GlobalParameter.K3Inf.UserName + "',MODIFYDATE = SYSDATE,DESCRIPTION = '" + pDescription + "',ISMATCH = '" + pIsMatch + "' WHERE FID = " + pFID.ToString();
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 删除NumberMatch
        /// </summary>
        /// <param name="pFID">内码</param>
        public static void DelNumberMatch(int pFID)
        {
            _SQL = "UPDATE DM_NUMBERMATCH SET ISDELETE = '1',ISUSE = '0',MODIFIER = '" + GlobalParameter.K3Inf.UserName + "',MODIFYDATE = SYSDATE WHERE FID = " + pFID.ToString();
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 获取CalculateStock
        /// </summary>
        /// <param name="pType">类型</param>
        /// <param name="pIndex">序号</param>
        /// <param name="pUserOrgId">使用组织</param>
        /// <returns></returns>
        public static DataTable CalculateStock(string pType, int pIndex, int pUserOrgId)
        {
            if (pType == "LOCKSTOCK")
            {
                if (pIndex == 0)
                    _SQL = "SELECT FSEQ 序号,FNUMBER 仓库编码,FNAME 仓库名称,FID 内码 FROM DM_CALCULATESTOCK WHERE FTYPE = 'LOCKSTOCK' AND ISDELETE = '0' ORDER BY FSEQ";
                else
                    _SQL = @"SELECT A.FSEQ 序号,A.FNUMBER 仓库编码,A.FNAME 仓库名称,A.FID 内码
                    FROM DM_CALCULATESTOCK A
                    INNER JOIN T_BD_STOCK B ON A.FSTOCKID = B.FSTOCKID
                    WHERE A.FTYPE = 'LOCKSTOCK' AND A.ISDELETE = '0'AND B.FUSEORGID = " + pUserOrgId.ToString() + " ORDER BY A.FSEQ";
            }
            else
            {
                if (pIndex == 0)
                    _SQL = "SELECT FSEQ 序号,FNUMBER 仓库编码,FNAME 仓库名称,FID 内码 FROM DM_CALCULATESTOCK WHERE FTYPE = 'RUNSTOCK' AND ISDELETE = '0' ORDER BY FSEQ";
                else
                    _SQL = @"SELECT A.FSEQ 序号,A.FNUMBER 仓库编码,A.FNAME 仓库名称,A.FID 内码
                    FROM DM_CALCULATESTOCK A
                    INNER JOIN T_BD_STOCK B ON A.FSTOCKID = B.FSTOCKID
                    WHERE A.FTYPE = 'RUNSTOCK' AND A.ISDELETE = '0'AND B.FUSEORGID = " + pUserOrgId.ToString() + " ORDER BY A.FSEQ";
            }

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// Calculate唯一性检查
        /// </summary>
        /// <param name="pType">类型</param>
        /// <param name="pSEQ">序号</param>
        /// <param name="pNumber">编码</param>
        /// <returns></returns>
        public static bool CalculateNumberExists(string pType, int pSEQ, string pNumber)
        {
            _SQL = "SELECT COUNT(1) FROM DM_CALCULATESTOCK WHERE FTYPE = '" + pType + "' AND ISDELETE = '0' AND (FSEQ = " + pSEQ.ToString() + " OR FNUMBER = '" + pNumber + "')";
            if (ORAHelper.ExecuteScalar(_SQL).ToString() != "0")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增CalculateStock
        /// </summary>
        /// <param name="pType">类型</param>
        /// <param name="pSEQ">序号</param>
        /// <param name="pStockId">仓库ID</param>
        /// <param name="pStockNumber">仓库编码</param>
        /// <param name="pStockName">仓库名称</param>
        public static void AddCalculateStock(string pType, int pSEQ, int pStockId, string pStockNumber, string pStockName)
        {
            _SQL = "INSERT INTO DM_CALCULATESTOCK(FTYPE,FSEQ,FSTOCKID,FNUMBER,FNAME,CREATOR) VALUES('" + pType + "'," + pSEQ.ToString() + "," + pStockId.ToString() + ",'" + pStockNumber + "','" + pStockName + "','" + Model.Globa.GlobalParameter.K3Inf.UserName + "')";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 更新CalculateStock
        /// </summary>
        /// <param name="pFID">内码</param>
        public static void UpdateCalculateStock(int pFID)
        {
            _SQL = "UPDATE DM_CALCULATESTOCK SET ISDELETE = '1',MODIFIER = '" + GlobalParameter.K3Inf.UserName + "',MODIFYDATE = SYSDATE WHERE FID = " + pFID.ToString();
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 获取Log_OrderLock
        /// </summary>
        /// <param name="pIndex">序号：1、订单锁库记录；2、订单运算结果；3、订单运算汇总</param>
        /// <param name="pFBillNo">单据编号</param>
        /// <param name="pYSD">运算单号</param>
        /// <param name="pFrom">开始时间</param>
        /// <param name="pTo">结束时间</param>
        /// <returns></returns>
        public static DataTable Log_OrderLock(int pIndex, string pFBillNo, string pYSD, DateTime pFrom, DateTime pTo, string pFFLAG, string pMaterialiNo)
        {
            switch (pIndex)
            {
                case 1:
                    _SQL = @"SELECT FBILLNO 订单编号,FMTLNUMBER 物料代码,NVL(FUNTNUMBER,' ') 单位,NVL(FORGNUMBER,' ') 销售组织,FSALQTY 销售数量,FLOCKQTY 锁库数量,FSTOCKQTY 库存数量,FSTOCKAVBQTY 库存可用数量,FSTOCK 仓库,FREMARK,CASE WHEN FTYPE = 1 THEN '锁库' ELSE '解锁' END 锁库类型,TO_CHAR(FOPERATEDATE,'yyyy-mm-dd hh24:mm:ss') 操作日期,FOPERATOR 操作人,CASE FFLAG WHEN '1' THEN '成功' ELSE '失败' END 操作状态
                    FROM DM_LOG_ORDERLOCK
                    WHERE TO_CHAR(FOPERATEDATE,'yyyy-mm-dd') BETWEEN '" + pFrom.ToString("yyyy-MM-dd") + "' AND '" + pTo.ToString("yyyy-MM-dd") + "'";

                    if (pFFLAG == "1" || pFFLAG == "0")
                        _SQL += " AND FFLAG = '" + pFFLAG + "'";
                    if (pFBillNo != string.Empty)
                        _SQL += " AND FBILLNO LIKE '%" + pFBillNo + "%'";
                    if (pMaterialiNo != string.Empty)
                        _SQL += " AND FMTLNUMBER LIKE '%" + pMaterialiNo + "%'";
                    _SQL += " ORDER BY FOPERATEDATE DESC";
                    break;
                case 2:
                    _SQL = @"SELECT A.YSBILLNO 运单号,A.FBILLNO 销售订单,A.FBILLTYPE 单据类型,A.FCUSTNAME 客户,A.FMTLNUMBER 物料编码,A.FMTLNAME 物料名称,A.FUNIT 单位,A.BOM,A.FQTY 销售数量,A.FLOCKQTY 锁库数量,A.FLACKLEVEL 欠料等级
                           ,AE.FMTLNUMBER 子项物料编码,AE.FMTLNAME 子项物料名称,AE.FNUIT 子项单位,AE.BOM 子项BOM,AE.FSUBQTY 子项需求,AE.FSTOCKQTY 库存数量,AE.FSTOCKAVBQTY 库存可用数量,AE.FNETDEMANDQTY 净需求,AE.FPICQTY 领料数量
                           ,AE.FMINSTOCK 最小库存,AE.FMAXSTOCK 最大库存,AE.FSAFESTOCK 安全库存,AE.FSTOCKDAYS 安全库存天数,AE.FOCCUPYQTY 本次占用数量,AE.FOCCUPYSUMQTY 累计占用数量,AE.FLACKQTY 欠料数量,AE.FSEQ 序号,TO_CHAR(A.FDATE,'yyyy-mm-dd hh24:mm:ss') 运算日期,A.FOPERATOR 操作人,A.F_PAEZ_SUBMITUSERID 提交人
                    FROM DM_LOG_ORDERRUN A
                    INNER JOIN DM_LOG_ORDERRUNSUB AE ON A.PID = AE.PID
                    WHERE TO_CHAR(A.FDATE,'yyyy-mm-dd') BETWEEN '" + pFrom.ToString("yyyy-MM-dd") + "' AND '" + pTo.ToString("yyyy-MM-dd") + "'";

                    if (pFBillNo != string.Empty)
                        _SQL += " AND A.FBILLNO LIKE '%" + pFBillNo + "%'";
                    if (pMaterialiNo != string.Empty)
                        _SQL += " AND A.FMTLNUMBER LIKE '%" + pMaterialiNo + "%'";
                    if (pYSD != string.Empty)
                        _SQL += " AND A.YSBILLNO LIKE '%" + pFBillNo + "%'";
                    _SQL += " ORDER BY A.FSEQ,AE.FSEQ";
                    break;
                case 3:
                    _SQL = @"SELECT FBILLNO 运单号, FMTLNUMBER 物料编码,FMTLNAME 物料名称,FMTLPRO 物料属性,FUNIT 单位,BOM,FREMAINSTOCKINQTY 采购在途,FQTY 生产自制,FSTOCKQTY 库存数量,FSTOCKAVBQTY 库存可用数量,FSTOCKDAYS 库存可用天数,FLOWQTY 最低订货量,FMINQTY 最小批量,FLACKQTY 欠料数量,FSUMQTY 需求汇总,FSEQ 序号,TO_CHAR(FDATE,'yyyy-mm-dd hh24:mm:ss') 汇总日期,FOPERATOR 操作人
                    FROM DM_LOG_ORDERRUNSUM WHERE FBILLNO = '" + pYSD + "'";

                    if (pMaterialiNo != string.Empty)
                        _SQL += " AND FMTLNUMBER LIKE '%" + pMaterialiNo + "%'";
                    _SQL += " ORDER BY FSEQ";
                    break;
            }

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取Log_OrderLock
        /// </summary>
        /// <returns></returns>
        public static DataTable AssistantData()
        {
            _SQL = @"SELECT SUBNO FValue,SUBNAME FName
            FROM DM_ASSISTANTDATA
            WHERE CATEGORYID IN(1，2)";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取ExceptionRecord
        /// </summary>
        /// <returns></returns>
        public static DataTable ExceptionRecord()
        {
            _SQL = @"SELECT '-1' FValue,'全部' FName FROM DUAL
            UNION
            SELECT DISTINCT CREATOR,CREATOR FROM DM_EXCEPTIONRECORD";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取ExceptionRecord
        /// </summary>
        /// <param name="pType">类型</param>
        /// <param name="pTypeValue">类型值</param>
        /// <param name="pOperator">操作</param>
        /// <param name="pOperatorValue">操作值</param>
        /// <param name="pFNumber">编号</param>
        /// <param name="pBarcode">条码</param>
        /// <param name="pCompany">公司</param>
        /// <param name="pFrom">开始时间</param>
        /// <param name="pTo">结束时间</param>
        /// <param name="pSucc">成功</param>
        /// <param name="pFailed">失败</param>
        /// <returns></returns>
        public static DataTable ExceptionRecord(int pType, string pTypeValue, int pOperator, string pOperatorValue, string pFNumber, string pBarcode, string pCompany, DateTime pFrom, DateTime pTo, bool pSucc, bool pFailed)
        {
            _SQL = @"SELECT A.CREATEDATE 日期,NVL(A.FNUMBER,' ') 单号,A.CREATOR 员工,NVL(B.SUBNAME, ' ') 类型,CASE A.FFLAGE WHEN 1 THEN '成功' ELSE '失败' END 状态,NVL(A.BARCODES,' ') 条码,A.DESCRIPTION 说明,NVL(A.ERMESSAGE,' ') 异常信息,A.FIP IP地址
            FROM DM_EXCEPTIONRECORD A
            LEFT JOIN DM_ASSISTANTDATA B ON A.FTYPE = B.SUBNO";

            if (pType == 6 && pCompany != string.Empty)
                _SQL += " INNER JOIN DM_NUMBERMATCH C ON INSTR(A.FNUMBER,C.FNUMBER) = 1 AND C.FTYPE = 'COMPANYNAME' ";
            _SQL += " WHERE A.CREATEDATE BETWEEN TO_DATE('" + pFrom.ToString("yyyy-MM-dd") + "','yyyy-mm-dd') AND TO_DATE('" + pTo.AddDays(1).ToString("yyyy-MM-dd") + "','yyyy-mm-dd') ";

            if (pType != 0)
                _SQL += " AND A.FTYPE = '" + pTypeValue + "' ";
            if (pOperator != 0)
                _SQL += " AND A.CREATOR = '" + pOperatorValue + "' ";
            if (pFNumber != "")
                _SQL += " AND A.FNUMBER LIKE '%" + pFNumber + "%' ";
            if (pBarcode != "")
                _SQL += " AND A.BARCODES LIKE '%" + pBarcode + "%' ";
            if (!(pSucc && pFailed))
            {
                if (pSucc)
                    _SQL += " AND A.FFLAGE = 1 ";
                else
                    _SQL += " AND A.FFLAGE = 0 ";
            }
            if (pType == 6 && pCompany != string.Empty)
                _SQL += " AND C.TYPENAME = '" + pCompany + "'";
            _SQL += " ORDER BY A.CREATEDATE DESC ";

            return ORAHelper.ExecuteTable(_SQL);
        }


        /// <summary>
        /// 获取PickMTLDepartment
        /// </summary>
        /// <returns></returns>
        public static DataTable PickMTLDepartment()
        {
            _SQL = @"SELECT A.FNUMBER 部门编码,A.FNAME 部门名称,BL.FNAME 使用组织
            FROM DM_PICKMTLDEPARTMENT A
            INNER JOIN T_ORG_ORGANIZATIONS_L BL ON A.FUSEORGID = BL.FORGID AND BL.FLOCALEID = 2052
            WHERE ISDELETE = '0'
            ORDER BY A.FNUMBER";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 领料部门编码唯一性检查
        /// </summary>
        /// <param name="pFNumber">部门编码</param>
        /// <returns></returns>
        public static bool PickMTLDeptExists(string pFNumber)
        {
            _SQL = "SELECT COUNT(1) FROM DM_PICKMTLDEPARTMENT WHERE ISDELETE = '0' AND FNUMBER = '" + pFNumber + "'";
            if (int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString()) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加领料部门
        /// </summary>
        /// <param name="pDeptId">部门ID</param>
        /// <param name="pFNumber">部门编码</param>
        /// <param name="pFName">部门名称</param>
        /// <param name="pUseOrgId">使用组织ID</param>
        public static void AddPickMTLDept(string pDeptId, string pFNumber, string pFName, string pUseOrgId)
        {
            _SQL = "INSERT INTO DM_PICKMTLDEPARTMENT(FDEPTID,FNUMBER,FNAME,FUSEORGID) VALUES(" + pDeptId + ",'" + pFNumber + "','" + pFName + "'," + pUseOrgId + ")";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 删除领料部门
        /// </summary>
        /// <param name="pFNumber">部门编码</param>
        public static void DelPickMTLDept(string pFNumber)
        {
            _SQL = "UPDATE DM_PICKMTLDEPARTMENT SET ISDELETE = '1' WHERE FNUMBER = '" + pFNumber + "'";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// BOM查询
        /// </summary>
        /// <param name="pBom">BomChecked</param>
        /// <param name="pBomC">BomChildChecked</param>
        /// <param name="pRG">ReplaceGroupChecked</param>
        /// <param name="pUseOrgIndex">使用组织Index</param>
        /// <param name="pUseOrgValue">使用组织Value</param>
        /// <param name="pLogicValue">LogicValue</param>
        /// <param name="TimesValue">TimesValue</param>
        /// <returns></returns>
        public static DataTable BOMQuery(bool pBom, bool pBomC, bool pRG, int pUseOrgIndex, string pUseOrgValue, string pLogicValue, string TimesValue)
        {
            if (pBom)
            {
                _SQL = @"SELECT B.FNUMBER 物料编码,BL.FNAME 物料名称,CL.FNAME 使用组织, A.FNUMBER BOM,COUNT(A.FNUMBER) 重复次数
                FROM T_ENG_BOM A
                INNER JOIN T_BD_MATERIAL B ON A.FMATERIALID = B.FMATERIALID AND B.FDOCUMENTSTATUS = 'C' AND B.FFORBIDSTATUS = 'A' AND B.FNUMBER LIKE '3%'
                INNER JOIN T_BD_MATERIAL_L BL ON B.FMATERIALID = BL.FMATERIALID AND BL.FLOCALEID = 2052
                INNER JOIN T_ORG_ORGANIZATIONS_L CL ON A.FUSEORGID = CL.FORGID AND CL.FLOCALEID = 2052
                WHERE A.FDOCUMENTSTATUS = 'C' AND A.FFORBIDSTATUS = 'A'
                GROUP BY B.FNUMBER,BL.FNAME,A.FNUMBER,CL.FNAME
                HAVING COUNT(A.FNUMBER) > 1";
            }
            else if (pBomC)
            {
                _SQL = @"SELECT B.FNUMBER 物料编码,BL.FNAME 物料名称,CL.FNAME 使用组织, A.FNUMBER BOM,B2.FNUMBER 子项物料编码, COUNT(B2.FNUMBER) 重复次数
                FROM T_ENG_BOM A
                INNER JOIN T_ENG_BOMCHILD AC ON A.FID = AC.FID
                INNER JOIN T_BD_MATERIAL B ON A.FMATERIALID = B.FMATERIALID AND B.FDOCUMENTSTATUS = 'C' AND B.FFORBIDSTATUS = 'A' AND B.FNUMBER LIKE '3%'
                INNER JOIN T_BD_MATERIAL_L BL ON B.FMATERIALID = BL.FMATERIALID AND BL.FLOCALEID = 2052
                INNER JOIN T_BD_MATERIAL B2 ON AC.FMATERIALID = B2.FMATERIALID
                INNER JOIN T_ORG_ORGANIZATIONS_L CL ON A.FUSEORGID = CL.FORGID AND CL.FLOCALEID = 2052
                WHERE A.FDOCUMENTSTATUS = 'C' AND A.FFORBIDSTATUS = 'A' AND TO_CHAR(A.FCREATEDATE, 'yyyy-MM-dd') >= '" + DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + @"'
                GROUP BY B.FNUMBER,BL.FNAME,A.FNUMBER,CL.FNAME,B2.FNUMBER
                HAVING COUNT(B2.FNUMBER) > 1";
            }
            else if (pRG)
            {
                _SQL = @"SELECT B.FNUMBER 物料编码,BL.FNAME 物料名称,CL.FNAME 使用组织, A.FNUMBER BOM,COUNT(AC.FREPLACEGROUP) 项次
                FROM T_ENG_BOM A
                INNER JOIN T_ENG_BOMCHILD AC ON A.FID = AC.FID
                INNER JOIN T_BD_MATERIAL B ON A.FMATERIALID = B.FMATERIALID AND B.FDOCUMENTSTATUS = 'C' AND B.FFORBIDSTATUS = 'A' AND B.FNUMBER LIKE '3%'
                INNER JOIN T_BD_MATERIAL_L BL ON B.FMATERIALID = BL.FMATERIALID AND BL.FLOCALEID = 2052
                INNER JOIN T_ORG_ORGANIZATIONS_L CL ON A.FUSEORGID = CL.FORGID AND CL.FLOCALEID = 2052
                WHERE A.FDOCUMENTSTATUS = 'C' AND A.FFORBIDSTATUS = 'A' ";

                if (pUseOrgIndex != 0)
                    _SQL += " AND A.FUSEORGID = " + pUseOrgValue;
                _SQL += " GROUP BY B.FNUMBER,BL.FNAME,CL.FNAME,A.FNUMBER HAVING COUNT(AC.FREPLACEGROUP) " + pLogicValue + TimesValue;
            }

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 203物料
        /// </summary>
        /// <param name="pFilter">筛选条件</param>
        /// <returns></returns>
        public static DataTable MTL203(string pFilter)
        {
            _SQL = @"SELECT D.FNAME 部门, B.FSRCBILLNO 销售订单号, E.FNUMBER 产品代码, F.FNAME 产品名称, G.FDATAVALUE 车型
                , H.FDATAVALUE 颜色, B.FQTY 数量, J.FNUMBER 盆子编码, K.FNAME 盆子名称, B.FPRODUCTIONSEQ 生产顺序号
                , B.FPLANSTARTDATE 计划开工时间
            FROM T_PRD_MO A
            INNER JOIN T_PRD_MOENTRY B ON A.FID = B.FID
            INNER JOIN T_BD_DEPARTMENT C ON B.FWORKSHOPID = C.FDEPTID
            INNER JOIN T_BD_DEPARTGROUP_L D ON C.FGROUP = D.FID AND D.FLOCALEID = 2052
            INNER JOIN T_BD_MATERIAL E ON B.FMATERIALID = E.FMATERIALID
            INNER JOIN T_BD_MATERIAL_L F ON B.FMATERIALID = F.FMATERIALID AND F.FLOCALEID = 2052
            INNER JOIN T_BAS_ASSISTANTDATAENTRY_L G ON E.F_PAEZ_CARTYPE = G.FENTRYID AND G.FLOCALEID = 2052
            INNER JOIN T_BAS_ASSISTANTDATAENTRY_L H ON E.F_PAEZ_COLOR = H.FENTRYID AND H.FLOCALEID = 2052
            INNER JOIN T_PRD_PPBOMENTRY I ON B.FENTRYID = I.FMOENTRYID
            INNER JOIN T_BD_MATERIAL J ON I.FMATERIALID = J.FMATERIALID AND J.FNUMBER LIKE '203%'
            INNER JOIN T_BD_MATERIAL_L K ON I.FMATERIALID = K.FMATERIALID AND K.FLOCALEID = 2052
            WHERE ";

            _SQL += pFilter == "" ? " B.FPLANSTARTDATE > ROUND(SYSDATE - 3) " : pFilter;
            _SQL += " AND A.FDOCUMENTSTATUS = 'C' AND B.FSRCBILLNO <> ' '  ORDER BY B.FPLANSTARTDATE DESC";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <param name="pType">类型</param>
        /// <returns></returns>
        public static DataTable Role(int pType)
        {
            if (pType == 0)
                _SQL = "SELECT RID,RNAME FROM DM_ROLE WHERE ISFORBIDDEN = '0'";
            else
                _SQL = "SELECT RID,RNAME 角色,MIDS,FUNCTIONID FROM DM_ROLE WHERE ISFORBIDDEN = '0'";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 角色是否存在
        /// </summary>
        /// <param name="pRName">角色名</param>
        /// <returns></returns>
        public static bool RoleExists(string pRName)
        {
            _SQL = "SELECT COUNT(*) FROM DM_ROLE WHERE RNAME = '" + pRName + "'";
            if (int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString()) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增Role
        /// </summary>
        /// <param name="pRName">角色名</param>
        /// <param name="pMids">Mids</param>
        public static void AddRole(string pRName, string pMids, string pFunctionIds)
        {
            _SQL = "INSERT INTO DM_ROLE(RNAME,MIDS,FUNCTIONID,CREATOR) VALUES('" + pRName + "','" + pMids + "','" + pFunctionIds + "','" + Model.Globa.GlobalParameter.K3Inf.UserName + "')";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 更新Role
        /// </summary>
        /// <param name="pRName">角色名</param>
        /// <param name="pMids">Mids</param>
        public static void UpdateRole(string pRName, string pMids, string pFunctionIds)
        {
            _SQL = "UPDATE DM_ROLE SET MIDS = '" + pMids + "',FUNCTIONID = '" + pFunctionIds + "',MODIFIER = '" + Model.Globa.GlobalParameter.K3Inf.UserName + "',MODIFICATIONDATE = SYSDATE WHERE RNAME = '" + pRName + "'";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 根据RName删除角色
        /// </summary>
        /// <param name="pRName">角色名</param>
        public static void DelRole(string pRName)
        {
            _SQL = "DELETE FROM DM_ROLE WHERE RNAME = '" + pRName + "'";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 根据RIDS获取角色
        /// </summary>
        /// <param name="pRIDS">RIDS</param>
        /// <returns></returns>
        public static DataTable GetRoleByRIDS(string pRIDS)
        {
            _SQL = "SELECT RID,RNAME FROM DM_ROLE WHERE ISFORBIDDEN = '0' AND RID IN(" + pRIDS.ToString() + ")";
            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 根据用户ID获取RIDS
        /// </summary>
        /// <param name="pUserId">用户ID</param>
        /// <returns></returns>
        public static object GetRIDSByUserId(string pUserId)
        {
            _SQL = "SELECT RIDS FROM DM_USER_ROLE WHERE USERID = " + pUserId;
            return ORAHelper.ExecuteScalar(_SQL);
        }

        /// <summary>
        /// 根据RID获取用户
        /// </summary>
        /// <param name="pRID">RID</param>
        /// <returns></returns>
        public static DataTable User_Role(string pRID)
        {
            _SQL = @"SELECT UR.USERID,SU.FNAME
            FROM DM_USER_ROLE UR
            INNER JOIN T_SEC_USER SU ON UR.USERID = SU.FUSERID
            WHERE RIDS LIKE '%," + pRID + ",%' OR RIDS LIKE '%," + pRID + "' OR RIDS LIKE '" + pRID + ",%' OR RIDS = '" + pRID + "'";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 当前用户是否已经分配角色
        /// </summary>
        /// <param name="pUserId">用户ID</param>
        /// <returns></returns>
        public static bool User_RoleExists(string pUserId)
        {
            _SQL = "SELECT COUNT(*) FROM DM_USER_ROLE WHERE USERID = " + pUserId;

            if (int.Parse(ORAHelper.ExecuteScalar(_SQL).ToString()) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增User_Role
        /// </summary>
        /// <param name="pUserId">用户ID</param>
        /// <param name="pRIDS">RIDS</param>
        public static void AddUser_Role(string pUserId, string pRIDS)
        {
            _SQL = "INSERT INTO DM_USER_ROLE(USERID,RIDS,CREATOR) VALUES(" + pUserId + ", '" + pRIDS + "','" + GlobalParameter.K3Inf.UserName + "')";
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 更新User_Role
        /// </summary>
        /// <param name="pUserId">用户ID</param>
        /// <param name="pRIDS">RIDS</param>
        public static void UpdateUser_Role(string pUserId, string pRIDS)
        {
            _SQL = "UPDATE DM_USER_ROLE SET RIDS = '" + pRIDS + "',MODIFIER = '" + GlobalParameter.K3Inf.UserName + "',MODIFICATIONDATE = SYSDATE WHERE USERID = " + pUserId;
            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 获取Navigation
        /// </summary>
        /// <returns></returns>
        public static DataTable Navigation()
        {
            _SQL = "SELECT NODEID,NODENAME FROM DM_EXPRESS_NAVIGATION WHERE LV = 1 ORDER BY NODEID";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 根据父节点获取Navigation
        /// </summary>
        /// <param name="pParentId">父项ID</param>
        /// <returns></returns>
        public static DataTable Navigation(int pParentId)
        {
            _SQL = "SELECT NODEID,NODENAME FROM DM_EXPRESS_NAVIGATION WHERE PARENTID = " + pParentId.ToString() + " ORDER BY NODEID";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 检查MAC是否注册
        /// </summary>
        /// <returns></returns>
        public static bool CheckMAC()
        {
            string strMAC = GetMac();
            _SQL = "SELECT COUNT(1) FROM DM_MAC WHERE ISDELETE = 0 AND MAC = '" + strMAC + "'";

            if ((int)ORAHelper.ExecuteScalar(_SQL) == 0)
                return false;
            return true;
        }

        /// <summary>
        /// 查询本地操作日志
        /// </summary>
        /// <param name="pUser"></param>
        /// <param name="pDate"></param>
        /// <returns></returns>
        public static DataTable GetDM_Log_Local(string pUser, DateTime pDate)
        {
            if (pUser.Equals(string.Empty))
                _SQL = @"SELECT OUSER 用户,IP IP地址,MAC,TO_CHAR(LOGINTIME,'YYYY-MM-DD HH24:MI:SS') 登录时间,TO_CHAR(OTIME,'YYYY-MM-DD HH24:MI:SS') 操作时间,ONAME 操作名称,ONAVI 模块,OCONTENT 操作内容描述,CASE WHEN FLAG = '1' THEN '操作成功' ELSE '操作失败' END 操作状态
                FROM DM_LOG_LOCAL
                WHERE ISDEL = '0' AND TO_CHAR(OTIME,'YYYY-MM-DD') = '" + pDate.ToString("yyyy-MM-dd") + "'";
            else
                _SQL = @"SELECT OUSER 用户,IP IP地址,MAC,TO_CHAR(LOGINTIME,'YYYY-MM-DD HH24:MI:SS') 登录时间,TO_CHAR(OTIME,'YYYY-MM-DD HH24:MI:SS') 操作时间,ONAME 操作名称,ONAVI 模块,OCONTENT 操作内容描述,CASE WHEN FLAG = '1' THEN '操作成功' ELSE '操作失败' END 操作状态
                FROM DM_LOG_LOCAL
                WHERE ISDEL = '0' AND OUSER = '" + pUser + "' AND TO_CHAR(OTIME,'YYYY-MM-DD') = '" + pDate.ToString("yyyy-MM-dd") + "'";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 保存本地操作日志
        /// </summary>
        /// <param name="pOName">操作名称</param>
        /// <param name="pONavi">业务模块</param>
        /// <param name="pOContent">操作信息</param>
        /// <param name="pFlag">标识</param>
        public static void DM_Log_Local(string pOName, string pONavi, string pOContent, string pFlag)
        {
            _SQL = @"INSERT INTO DM_LOG_LOCAL(OUSER,IP,MAC,LOGINTIME,LOGOUTTIME,OTIME,ONAME,ONAVI,OCONTENT,FLAG)
            VALUES('" + GlobalParameter.K3Inf.UserName + "','" + GlobalParameter.LocalInf.IP + "','" + GlobalParameter.LocalInf.MAC + "',TO_DATE('" + GlobalParameter.LocalInf.LoginTime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),TO_DATE('" + GlobalParameter.LocalInf.LogoutTime.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),SYSDATE,'" + pOName + "','" + pONavi + "','" + pOContent + "','" + pFlag + "')";

            ORAHelper.ExecuteNonQuery(_SQL);
        }
        #endregion

        #region Barcode
        /// <summary>
        /// 同步Barcode
        /// </summary>
        /// <param name="pType">类型</param>
        /// <param name="pFBillNo">单据编号</param>
        /// <param name="pBarcodes">条码</param>
        public static void SynBarcodr(string pType, string pFBillNo, string pBarcodes)
        {
            if (pType == "入库")
            {
                _SQL = @"UPDATE C##BARCODE2.PM_BARCODE
                SET INSTOCKSTATUS = 1,KDINSTOCKID =
                (
                SELECT FID FROM T_PRD_INSTOCK WHERE FBILLNO = '" + pFBillNo + @"'
                )
                WHERE KDINSTOCKID IS NULL AND INSTOCKSTATUS = 0 AND
                BARCODE IN(" + pBarcodes + ")";
            }
            else
            {
                _SQL = @"UPDATE C##BARCODE2.PM_BARCODE
                SET UTSTOCKSTATUS = 1,KDUTSTOCKID =
                (
                SELECT FID FROM T_SAL_OUTSTOCK WHERE FBILLNO = '" + pFBillNo + @"'
                )
                WHERE KDUTSTOCKID IS NULL AND UTSTOCKSTATUS = 0 AND
                BARCODE IN(" + pBarcodes + ")";
            }

            ORAHelper.ExecuteNonQuery(_SQL);
        }
        #endregion

        #region ERP
        /// <summary>
        /// 获取ERP操作日志
        /// </summary>
        /// <param name="pUser">用户</param>
        /// <param name="pDate">日期</param>
        /// <returns></returns>
        public static DataTable ERPLog(string pUser, DateTime pDate)
        {
            _SQL = @"SELECT A.FDATETIME 操作时间,B.FNAME 操作用户,ORGL.FNAME 当前组织,SUBL.FNAME 子系统,OBJL.FNAME 业务对象
                ,CASE WHEN A.FENVIRONMENT = 0 THEN '登入系统' WHEN A.FENVIRONMENT = 1 THEN '进入业务对象' WHEN A.FENVIRONMENT = 2 THEN '退出业务对象' WHEN A.FENVIRONMENT = 3 THEN '业务操作'ELSE '退出系统' END 操作场景
                ,A.FOPERATENAME 操作名称,A.FDESCRIPTION 操作描述,A.FCOMPUTERNAME 机器名称,A.FIPADDRESS IP地址
            FROM T_BAS_OPERATELOG A
            INNER JOIN T_SEC_USER B ON A.FUSERID = B.FUSERID
            INNER JOIN T_ORG_ORGANIZATIONS_L ORGL ON A.FLOGONORGID = ORGL.FORGID AND ORGL.FLOCALEID = 2052
            INNER JOIN T_META_OBJECTTYPE_L OBJL ON A.FOBJECTTYPEID = OBJL.FID AND OBJL.FLOCALEID = 2052
            INNER JOIN T_META_SUBSYSTEM_L SUBL ON A.FSUBSYSTEMID = SUBL.FID AND SUBL.FLOCALEID = 2052
            WHERE TO_CHAR(A.FDATETIME,'YYYY-MM-DD') = '" + pDate.ToString("yyyy-MM-dd") + "' AND B.FNAME = '" + pUser + "'";

            return ORAHelper.ExecuteTable(_SQL);
        }
        #endregion

        #region MTL
        /// <summary>
        /// 根据物料编码获取物料ID
        /// </summary>
        /// <param name="pFUseOrgId">使用组织</param>
        /// <param name="pFNumber">物料编码</param>
        /// <returns></returns>
        public static int GetMTLIDByNumber(int pFUseOrgId, string pFNumber)
        {
            _SQL = "SELECT FMATERIALID FROM T_BD_MATERIAL WHERE FDOCUMENTSTATUS = 'C' AND FFORBIDSTATUS = 'A' AND FUSEORGID = " + pFUseOrgId.ToString() + " AND FNUMBER = '" + pFNumber + "'";
            _obj = ORAHelper.ExecuteScalar(_SQL);

            if (_obj == null)
                return -1;
            else
                return int.Parse(_obj.ToString());
        }

        /// <summary>
        /// 更新物料参数
        /// </summary>
        /// <param name="pMTLPara">物料参数</param>
        /// <param name="pMaterialId">物料ID</param>
        public static void UpdateMTLPara(MaterialParameter pMTLPara, int pMaterialId)
        {
            _SQL = @"UPDATE T_BD_MATERIALSTOCK
            SET F_PAEZ_SAFEDAYS = " + pMTLPara.F_PAEZ_SAFEDAYS.ToString() + ",F_PAEZ_LOGISTICSDAYS = " + pMTLPara.F_PAEZ_LOGISTICSDAYS.ToString() + ",F_PAEZ_LOWQTY = " + pMTLPara.F_PAEZ_LOWQTY.ToString() + ", F_PAEZ_MINQTY = " + pMTLPara.F_PAEZ_MINQTY.ToString() + ",F_PAEZ_REPLENISHMENT = " + pMTLPara.F_PAEZ_REPLENISHMENT.ToString() + @"
            WHERE FMATERIALID = " + pMaterialId.ToString();

            ORAHelper.ExecuteNonQuery(_SQL);
        }
        #endregion

        #region T_AUTO_MSTOCKSETTING
        /// <summary>
        /// 获取T_AUTO_MSTOCKSETTING
        /// </summary>
        /// <param name="pMTLFNumber">物料编码</param>
        /// <returns></returns>
        public static DataTable MStockSetting(string pMTLFNumber)
        {
            _SQL = @"SELECT MST.FID,MST.FMATERIALNUMBER 物料编码,MTLL.FNAME 物料名称,DEPL.FNAME 部门,MST.FSTOCKNUMBER 仓库编码,STKL.FNAME 仓库名称
            FROM T_AUTO_MSTOCKSETTING MST
            INNER JOIN T_BD_MATERIAL_L MTLL ON MST.FMATERIALID = MTLL.FMATERIALID AND MTLL.FLOCALEID = 2052
            INNER JOIN T_BD_DEPARTMENT_L DEPL ON MST.FDEPTID = DEPL.FDEPTID AND DEPL.FLOCALEID = 2052
            INNER JOIN T_BD_STOCK_L STKL ON MST.FSTOCKID = STKL.FSTOCKID AND STKL.FLOCALEID = 2052
            WHERE MST.FMATERIALNUMBER = '" + pMTLFNumber + "'";

            return ORAHelper.ExecuteTable(_SQL);
        }

        /// <summary>
        /// 新增MSTOCKSETTING
        /// </summary>
        /// <param name="pMaterialID">物料ID</param>
        /// <param name="pMaterialNumber">物料编码</param>
        /// <param name="pDeptID">部门ID</param>
        /// <param name="pDeptNumber">部门编码</param>
        /// <param name="pStockID">仓库ID</param>
        /// <param name="pStockNumber">仓库编码</param>
        public static void AddMStockSetting(string pMaterialID, string pMaterialNumber, string pDeptID, string pDeptNumber, string pStockID, string pStockNumber)
        {
            _SQL = @"INSERT INTO T_AUTO_MSTOCKSETTING(FMATERIALID,FMATERIALNUMBER,FDEPTID,FDEPTNUMBER,FSTOCKID,FSTOCKNUMBER,FCREATOR)
            VALUES(" + pMaterialID + ",'" + pMaterialNumber + "'," + pDeptID + ",'" + pDeptNumber + "'," + pStockID + ",'" + pStockNumber + "','" + GlobalParameter.K3Inf.UserName + "')";

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 更新MStockSetting
        /// </summary>
        /// <param name="pStockNumber">仓库编码</param>
        /// <param name="pFID">内码</param>
        public static void UpdateMStockSetting(string pStockNumber, int pFID)
        {
            int iStockId = GetStockIdByNumber(100508, pStockNumber);
            _SQL = "UPDATE T_AUTO_MSTOCKSETTING SET FSTOCKID = " + iStockId + ", FSTOCKNUMBER = '" + pStockNumber + "',FCREATOR = '" + GlobalParameter.K3Inf.UserName + "',FCREATEDATE = SYSDATE WHERE FID = " + pFID;

            ORAHelper.ExecuteNonQuery(_SQL);
        }

        /// <summary>
        /// 删除MStockSetting
        /// </summary>
        public static void DelMStockSetting()
        {
            ORAHelper.ExecuteNonQuery("DELETE FROM T_AUTO_MSTOCKSETTING WHERE FSTOCKID IS NULL");
        }
        #endregion

        #region PC Func
        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            //string strIP = string.Empty;
            //try
            //{
            //    string hostInfo = Dns.GetHostName();
            //    IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            //    for (int i = 0; i < addressList.Length; i++)
            //    {
            //        strIP += addressList[i].ToString();
            //    }
            //}
            //catch { return string.Empty; }
            //return strIP;
            //pIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();

            string strIP = string.Empty;
            try
            {
                string hostInfo = Dns.GetHostName();
                IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                for (int i = 0; i < addressList.Length; i++)
                {
                    if (addressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        strIP = addressList[i].ToString();
                        break;
                    }
                }
            }
            catch { return string.Empty; }
            return strIP;
        }

        /// <summary>
        /// 获取本机MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetMac()
        {
            string Mac = string.Empty;
            try
            {
                NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in nis)
                {
                    if (ni.NetworkInterfaceType.ToString().Equals("Ethernet")) //是以太网卡
                    {
                        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + ni.Id + "\\Connection", false);

                        if (registryKey != null)
                        {
                            string fPnpInstanceID = registryKey.GetValue("PnpInstanceID", "").ToString();
                            //int fMediaSubType = Convert.ToInt32(registryKey.GetValue("MediaSubType", 0));
                            if (fPnpInstanceID.Length > 3 && fPnpInstanceID.Substring(0, 3) == "PCI") //是物理网卡
                            {
                                Mac = ni.GetPhysicalAddress().ToString();
                                break;
                            }
                            //else if (fMediaSubType == 1) //虚拟网卡
                            //    continue;
                            //else if (fMediaSubType == 2) //无线网卡(上面判断Ethernet时已经排除了)
                            //    continue;
                        }
                    }
                }
            }
            catch { return string.Empty; }
            return Mac;
        }
        #endregion

        #region DBOperation
        /// <summary>
        /// 通用方法
        /// </summary>
        /// <param name="pType">类型：0、Non；1、Scalar；2、Reader；3、DataTable；4、DataSet</param>
        /// <param name="pStrSQL">SQL语句</param>
        /// <returns></returns>
        private static object SqlOperation(int pType, string pStrSQL)
        {
            object obj;
            OracleDataAdapter adp;
            DataTable dt;
            DataSet ds;

            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = pStrSQL;

                switch (pType)
                {
                    case 0:
                        obj = cmd.ExecuteNonQuery();
                        break;
                    case 1:
                        obj = cmd.ExecuteScalar();
                        break;
                    case 2:
                        obj = cmd.ExecuteReader();
                        break;
                    case 3:
                        dt = new DataTable();
                        adp = new OracleDataAdapter(pStrSQL, conn);
                        adp.Fill(dt);
                        obj = dt;
                        break;
                    case 4:
                        ds = new DataSet();
                        adp = new OracleDataAdapter(pStrSQL, conn);
                        adp.Fill(ds);
                        obj = ds;
                        break;
                    default:
                        obj = null;
                        break;
                }
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }

            return obj;
        }
        #endregion
    }
}
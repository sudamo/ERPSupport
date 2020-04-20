using System;
using System.Data;
using System.Collections;
using Newtonsoft.Json.Linq;
using Kingdee.BOS.WebApi.Client;
using Oracle.ManagedDataAccess.Client;

namespace ERPSupport.SQL.K3Cloud
{
    using Model.Globa;

    /// <summary>
    /// 生产领料
    /// </summary>
    public static class PrdPick
    {
        #region STATIC
        private static string _SQL;
        //private static object _obj;

        /// <summary>
        /// 构造函数
        /// </summary>
        static PrdPick()
        {
            _SQL = string.Empty;
            //_obj = new object();
        }
        #endregion

        /// <summary>
        /// 生成倒冲领料单
        /// 
        /// 根据生产入库单号，
        /// 生产对应的倒冲领料单进行领料。
        /// 入库单对应的用料清单的发料方式必须为“直接倒冲”才能领料。
        /// </summary>
        /// <param name="pBillNO">入库单编号</param>
        /// <returns>领料单</returns>
        public static string PickMtl(string pBillNO)
        {
            string strPMBillNO;
            DataTable dt = null;
            DataRow dr = null;
            bool bAddFirstRow = true;

            if (pBillNO.Trim().Length == 0)
                return "";

            _SQL = @"SELECT DISTINCT NVL(ORG.FNUMBER,'HN02') FPRDORGID,NVL(ORG2.FNUMBER,ORG.FNUMBER) FSUPPLYORG,NVL(DEP.FNUMBER, ' ') FWORKSHOPID,NVL(STK.FNUMBER,' ') FINSTOCKID,NVL(STS.FNUMBER,'KCZT01_SYS') FSTOCKSTATUSID
                ,MTLH.FNUMBER FMATERIALID, ROUND((PBE.FNEEDQTY-PBQ.FSELPICKEDQTY),4) FNEEDQTY,ROUND((PBE.FMUSTQTY*AE.FREALQTY/MO.FQTY),4) FMUSTQTY,NVL(UNT.FNUMBER,' ') FUNITID,NVL(ORG3.FNUMBER,ORG.FNUMBER) FOWNERID
                ,A.FBILLNO INSTOCKBILLNO,A.FID INSTOCKFID,AE.FENTRYID INSTOCKFENTRYID,AE.FSEQ INSTOCKSEQ
                ,AE.FMOBILLNO MOBILLNO,MO.FID MOFID,MO.FENTRYID MOFENTRYID,MO.FSEQ MOSEQ
                ,PB.FBILLNO PPBILLNO,PBE.FID PPFID,PBE.FENTRYID PPFENTRYID,PBE.FSEQ PPFSEQ
                ,A.FFORMID,PBE.FOPERID,A.FDATE,NVL(ORG4.FNUMBER,ORG.FNUMBER) FPARENTOWNERID,MTLC.FNUMBER FPARENTMATERIALID
            FROM T_PRD_INSTOCK A
            INNER JOIN T_PRD_INSTOCKENTRY AE ON A.FID = AE.FID
            INNER JOIN T_PRD_MOENTRY MO ON AE.FMOENTRYID = MO.FENTRYID
            INNER JOIN T_PRD_PPBOM PB ON AE.FMOENTRYID = PB.FMOENTRYID
            INNER JOIN T_PRD_PPBOMENTRY PBE ON PB.FID = PBE.FID
            INNER JOIN T_PRD_PPBOMENTRY_C PBC ON PBE.FENTRYID = PBC.FENTRYID
            INNER JOIN T_PRD_PPBOMENTRY_Q PBQ ON PBE.FENTRYID = PBQ.FENTRYID
            INNER JOIN T_BD_MATERIAL MTLH ON PBE.FMATERIALID = MTLH.FMATERIALID
            INNER JOIN T_BD_MATERIAL MTLC ON PB.FMATERIALID = MTLC.FMATERIALID
            LEFT JOIN T_ORG_ORGANIZATIONS ORG ON PB.FPRDORGID = ORG.FORGID
            LEFT JOIN T_ORG_ORGANIZATIONS ORG2 ON PBC.FSUPPLYORG = ORG2.FORGID
            LEFT JOIN T_ORG_ORGANIZATIONS ORG3 ON PBC.FOWNERID = ORG3.FORGID
            LEFT JOIN T_ORG_ORGANIZATIONS ORG4 ON PBC.FENTRUSTPICKORGID = ORG4.FORGID
            LEFT JOIN T_BD_DEPARTMENT DEP ON PB.FWORKSHOPID = DEP.FDEPTID
            LEFT JOIN T_BD_STOCK STK ON DEP.FINSTOCKID = STK.FSTOCKID
            LEFT JOIN T_BD_UNIT UNT ON PBE.FUNITID = UNT.FUNITID
            LEFT JOIN T_BD_STOCKSTATUS STS ON PBC.FSTOCKSTATUSID = STS.FSTOCKSTATUSID
            LEFT JOIN T_PRD_PICKMTRLDATA_A PICA ON AE.FENTRYID = PICA.FSRCBIZENTRYID
            WHERE A.FBILLNO = '" + pBillNO + "' AND PICA.FSRCBIZBILLNO IS NULL AND PBC.FISSUETYPE = 2";//用料清单的发料方式为直接倒冲。1、直接领料；2、直接倒冲；3、调拨领料；4、调拨倒冲；7、不发料。

            dt = new DataTable();
            dt.Columns.Add("FPRDORGID");
            dt.Columns.Add("FSUPPLYORG");
            dt.Columns.Add("FWORKSHOPID");
            dt.Columns.Add("FINSTOCKID");
            dt.Columns.Add("FSTOCKSTATUSID");

            dt.Columns.Add("FMATERIALID");
            dt.Columns.Add("FNEEDQTY");
            dt.Columns.Add("FMUSTQTY");
            dt.Columns.Add("FUNITID");
            dt.Columns.Add("FOWNERID");

            dt.Columns.Add("INSTOCKBILLNO");
            dt.Columns.Add("INSTOCKFID");
            dt.Columns.Add("INSTOCKFENTRYID");
            dt.Columns.Add("INSTOCKSEQ");

            dt.Columns.Add("MOBILLNO");
            dt.Columns.Add("MOFID");
            dt.Columns.Add("MOFENTRYID");
            dt.Columns.Add("MOSEQ");

            dt.Columns.Add("PPBILLNO");
            dt.Columns.Add("PPFID");
            dt.Columns.Add("PPFENTRYID");
            dt.Columns.Add("PPFSEQ");
            dt.Columns.Add("FFORMID");

            dt.Columns.Add("FOPERID");
            dt.Columns.Add("FDATE");
            dt.Columns.Add("FPARENTOWNERID");
            dt.Columns.Add("FPARENTMATERIALID");

            dt.TableName = "PickMtrlInfo";

            OracleConnection OrclConn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);
            try
            {
                OrclConn.Open();
                OracleCommand cmd = OrclConn.CreateCommand();
                cmd.CommandText = _SQL;

                using (OracleDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (bAddFirstRow)
                        {
                            dr = dt.NewRow();
                            dr["FPRDORGID"] = rdr.GetString(0);
                            dr["FSUPPLYORG"] = rdr.GetString(1);
                            dr["FWORKSHOPID"] = rdr.GetString(2);
                            dr["FINSTOCKID"] = rdr.GetString(3);
                            dr["FSTOCKSTATUSID"] = rdr.GetString(4);

                            dr["FMATERIALID"] = "5120170530001";
                            dr["FNEEDQTY"] = 0;
                            dr["FMUSTQTY"] = 0;
                            dr["FUNITID"] = rdr.GetString(8);
                            dr["FOWNERID"] = rdr.GetString(9);

                            dr["INSTOCKBILLNO"] = rdr.GetString(10);
                            dr["INSTOCKFID"] = rdr.GetInt32(11);
                            dr["INSTOCKFENTRYID"] = rdr.GetInt32(12);
                            dr["INSTOCKSEQ"] = rdr.GetInt32(13);

                            dr["MOBILLNO"] = rdr.GetString(14);
                            dr["MOFID"] = rdr.GetInt32(15);
                            dr["MOFENTRYID"] = rdr.GetInt32(16);
                            dr["MOSEQ"] = rdr.GetInt32(17);

                            dr["PPBILLNO"] = rdr.GetString(18);
                            dr["PPFID"] = rdr.GetInt32(19);
                            dr["PPFENTRYID"] = rdr.GetInt32(20);
                            dr["PPFSEQ"] = rdr.GetInt32(21);
                            dr["FFORMID"] = rdr.GetString(22);

                            dr["FOPERID"] = rdr.GetInt32(23);
                            dr["FDATE"] = rdr.GetDateTime(24);
                            dr["FPARENTOWNERID"] = rdr.GetString(25);
                            dr["FPARENTMATERIALID"] = rdr.GetString(26);
                            dt.Rows.Add(dr);
                            bAddFirstRow = false;
                        }
                        dr = dt.NewRow();
                        dr["FPRDORGID"] = rdr.GetString(0);
                        dr["FSUPPLYORG"] = rdr.GetString(1);
                        dr["FWORKSHOPID"] = rdr.GetString(2);
                        dr["FINSTOCKID"] = rdr.GetString(3);
                        dr["FSTOCKSTATUSID"] = rdr.GetString(4);

                        dr["FMATERIALID"] = rdr.GetString(5);
                        dr["FNEEDQTY"] = rdr.GetDecimal(6) < 0 ? 0 : rdr.GetDecimal(6);
                        dr["FMUSTQTY"] = rdr.GetDecimal(7) < 0 ? 0 : rdr.GetDecimal(7);
                        dr["FUNITID"] = rdr.GetString(8);
                        dr["FOWNERID"] = rdr.GetString(9);

                        dr["INSTOCKBILLNO"] = rdr.GetString(10);
                        dr["INSTOCKFID"] = rdr.GetInt32(11);
                        dr["INSTOCKFENTRYID"] = rdr.GetInt32(12);
                        dr["INSTOCKSEQ"] = rdr.GetInt32(13);

                        dr["MOBILLNO"] = rdr.GetString(14);
                        dr["MOFID"] = rdr.GetInt32(15);
                        dr["MOFENTRYID"] = rdr.GetInt32(16);
                        dr["MOSEQ"] = rdr.GetInt32(17);

                        dr["PPBILLNO"] = rdr.GetString(18);
                        dr["PPFID"] = rdr.GetInt32(19);
                        dr["PPFENTRYID"] = rdr.GetInt32(20);
                        dr["PPFSEQ"] = rdr.GetInt32(21);
                        dr["FFORMID"] = rdr.GetString(22);

                        dr["FOPERID"] = rdr.GetInt32(23);
                        dr["FDATE"] = rdr.GetDateTime(24);
                        dr["FPARENTOWNERID"] = rdr.GetString(25);
                        dr["FPARENTMATERIALID"] = rdr.GetString(26);
                        dt.Rows.Add(dr);
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                return "[" + pBillNO + "]生成失败,错误:" + ex.Message;
            }
            finally
            {
                OrclConn.Close();
            }

            if (dt.Rows.Count < 1) return "[" + pBillNO + "]生成失败,错误:在数据库找不到数据，或者领过料";

            int iStar = 0, iEnd = 0, iIndex; string strMtlNumber = string.Empty, strMessTmep;

            K3CloudApiClient client = new K3CloudApiClient(GlobalParameter.K3Inf.C_ERPADDRESS);
            var bLogin = client.Login(GlobalParameter.K3Inf.C_ZTID, GlobalParameter.K3Inf.UserName, GlobalParameter.K3Inf.UserPWD, 2052);

            if (bLogin)
            {
                JObject jsonRoot = new JObject();
                jsonRoot.Add("Creator", "MANUAL");
                jsonRoot.Add("NeedUpDateFields", new JArray(""));

                JObject model = new JObject();
                jsonRoot.Add("Model", model);
                model.Add("FID", 0);

                JObject basedata = new JObject();
                basedata.Add("FNumber", "SCLLD02_SYS");
                model.Add("FBillType", basedata);

                basedata = new JObject();
                basedata.Add("FNumber", dt.Rows[0]["FSUPPLYORG"].ToString());
                model.Add("FStockOrgId", basedata);

                basedata = new JObject();
                basedata.Add("FNumber", dt.Rows[0]["FPRDORGID"].ToString());
                model.Add("FPrdOrgId", basedata);

                basedata = new JObject();
                basedata.Add("FNumber", dt.Rows[0]["FOWNERID"].ToString());
                model.Add("FOwnerId0", basedata);

                model.Add("FDate", dt.Rows[0]["FDATE"].ToString());
                model.Add("FOwnerTypeId0", "BD_OwnerOrg");

                JArray entryRows = new JArray();
                string entityKey = "FEntity";
                model.Add(entityKey, entryRows);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JObject entryRow = new JObject();
                    entryRows.Add(entryRow);
                    entryRow.Add("FEntryID", 0);

                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FMATERIALID"].ToString());
                    entryRow.Add("FMaterialId", basedata);

                    entryRow.Add("FAppQty", dt.Rows[i]["FNEEDQTY"].ToString());
                    entryRow.Add("FActualQty", dt.Rows[i]["FMUSTQTY"].ToString());

                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FUNITID"].ToString());
                    entryRow.Add("FUnitID", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FUNITID"].ToString());
                    entryRow.Add("FStockUnitId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FUNITID"].ToString());
                    entryRow.Add("FBaseUnitId", basedata);

                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FINSTOCKID"].ToString());
                    entryRow.Add("FStockId", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FSTOCKSTATUSID"].ToString());
                    entryRow.Add("FStockStatusId", basedata);

                    entryRow.Add("FOwnerTypeId", "BD_OwnerOrg");
                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FOWNERID"].ToString());
                    entryRow.Add("FOwnerId", basedata);

                    entryRow.Add("FParentOwnerTypeId", "BD_OwnerOrg");
                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FPARENTOWNERID"].ToString());
                    entryRow.Add("FPARENTOWNERID", basedata);
                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FPARENTMATERIALID"].ToString());
                    entryRow.Add("FPARENTMATERIALID", basedata);

                    entryRow.Add("FKeeperTypeId", "BD_KeeperOrg");
                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FPRDORGID"].ToString());
                    entryRow.Add("FKeeperId", basedata);

                    //单据类型
                    entryRow.Add("FSrcBillType", "PRD_PPBOM");

                    entryRow.Add("FSRCBIZBILLNO", dt.Rows[i]["INSTOCKBILLNO"].ToString());
                    entryRow.Add("FSRCBIZINTERID", dt.Rows[i]["INSTOCKFID"].ToString());
                    entryRow.Add("FSRCBIZENTRYID", dt.Rows[i]["INSTOCKFENTRYID"].ToString());
                    entryRow.Add("FSRCBIZENTRYSEQ", dt.Rows[i]["INSTOCKSEQ"].ToString());

                    entryRow.Add("FMoBillNo", dt.Rows[i]["MOBILLNO"].ToString());
                    entryRow.Add("FMoId", dt.Rows[i]["MOFID"].ToString());
                    entryRow.Add("FMoEntryId", dt.Rows[i]["MOFENTRYID"].ToString());
                    entryRow.Add("FMoEntrySeq", dt.Rows[i]["MOSEQ"].ToString());

                    entryRow.Add("FSrcBillNo", dt.Rows[i]["PPBILLNO"].ToString());
                    entryRow.Add("FEntrySrcInterId", dt.Rows[i]["PPFID"].ToString());
                    entryRow.Add("FEntrySrcEnteryId", dt.Rows[i]["PPFENTRYID"].ToString());
                    entryRow.Add("FEntrySrcEntrySeq", dt.Rows[i]["PPFSEQ"].ToString());

                    entryRow.Add("FPPBomBillNo", dt.Rows[i]["PPBILLNO"].ToString());
                    entryRow.Add("FPPBOMENTRYID", dt.Rows[i]["PPFENTRYID"].ToString());

                    basedata = new JObject();
                    basedata.Add("FNumber", dt.Rows[i]["FWORKSHOPID"].ToString());
                    entryRow.Add("FEntryWorkShopId", basedata);

                    entryRow.Add("FOPERID", dt.Rows[i]["FOPERID"].ToString());

                    //创建与源单之间的关联关系，以支持上查与反写源单
                    entryRow.Add("FSrcBillTypeId", "PRD_PPBOM");
                    JArray linkRows = new JArray();
                    string linkEntityKey = string.Format("{0}_Link", entityKey);
                    entryRow.Add(linkEntityKey, linkRows);
                    JObject linkRow = new JObject();
                    linkRows.Add(linkRow);

                    //FFlowId : 业务流程图，可选
                    string fldFlowIdKey = string.Format("{0}_FFlowId", linkEntityKey);
                    linkRow.Add(fldFlowIdKey, "");
                    //FFlowLineId ：业务流程图路线，可选
                    string fldFlowLineIdKey = string.Format("{0}_FFlowLineId", linkEntityKey);
                    linkRow.Add(fldFlowLineIdKey, "");

                    string fldRuleIdKey = string.Format("{0}_FRuleId", linkEntityKey);
                    linkRow.Add(fldRuleIdKey, "PRD_PPBOM-PRD_PICKMTRL");
                    string fldSTableNameKey = string.Format("{0}_FSTableName", linkEntityKey);
                    linkRow.Add(fldSTableNameKey, "T_PRD_PPBOMENTRY");

                    string fldSBillIdKey = string.Format("{0}_FSBillId", linkEntityKey);
                    linkRow.Add(fldSBillIdKey, int.Parse(dt.Rows[i]["PPFID"].ToString()));
                    string fldSIdKey = string.Format("{0}_FSId", linkEntityKey);
                    linkRow.Add(fldSIdKey, int.Parse(dt.Rows[i]["PPFENTRYID"].ToString()));
                }
                //调用Web API接口服务，保存领料单
                strPMBillNO = client.Save("PRD_PickMtrl", jsonRoot.ToString());
                JObject jo = JObject.Parse(strPMBillNO);

                if (!jo["Result"]["ResponseStatus"]["IsSuccess"].Value<bool>())
                {
                    strPMBillNO = "[" + pBillNO + "]生成失败,错误:";
                    for (int i = 0; i < ((IList)jo["Result"]["ResponseStatus"]["Errors"]).Count; i++)
                    {
                        strMessTmep = jo["Result"]["ResponseStatus"]["Errors"][i]["Message"].Value<string>();
                        iStar = jo["Result"]["ResponseStatus"]["Errors"][i]["Message"].Value<string>().IndexOf("第");
                        iEnd = jo["Result"]["ResponseStatus"]["Errors"][i]["Message"].Value<string>().IndexOf("行字段");

                        if (iStar > 0)//获取出错物料编码
                        {
                            try
                            {
                                iIndex = int.Parse(strMessTmep.Substring(iStar + 1, iEnd - iStar - 1)) - 1;
                                strMtlNumber = dt.Rows[iIndex]["FMATERIALID"].ToString();
                            }
                            catch { strMtlNumber = string.Empty; }
                        }
                        else
                            strMtlNumber = string.Empty;

                        strPMBillNO += strMessTmep + (strMtlNumber.Equals(string.Empty) ? "" : "[" + strMtlNumber + "]") + "\r\n";//保存不成功返错误信息
                    }
                        //strPMBillNO += jo["Result"]["ResponseStatus"]["Errors"][i]["Message"].Value<string>() + "\r\n";//保存不成功返错误信息
                }
                else
                {
                    strPMBillNO = jo["Result"]["Number"].Value<string>();//保存成功返回单据编号FBILLNO
                }
            }
            else
                strPMBillNO = "ERP登录失败";

            return strPMBillNO;
        }

        /// <summary>
        /// 根据日期获取入库单编号
        /// </summary>
        /// <param name="pDateTime">日期</param>
        /// <returns>DataTable</returns>
        public static DataTable GetInstockBillNo(DateTime pDateTime)
        {
            _SQL = @"SELECT DISTINCT A.FBILLNO
            FROM T_PRD_INSTOCK A
            LEFT JOIN T_PRD_PICKMTRLDATA_A PICA ON A.FID = PICA.FSRCBIZINTERID
            WHERE TO_CHAR(A.FDATE, 'yyyy-MM-dd') >= '" + pDateTime.ToString("yyyy-MM-dd") + "' AND  A.FDOCUMENTSTATUS = 'C' AND PICA.FSRCBIZBILLNO IS NULL";

            return ORAHelper.ExecuteTable(_SQL);
        }
    }
}

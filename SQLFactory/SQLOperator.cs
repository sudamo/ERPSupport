/**
 * 
 * DM ST-Group
 * 
 * This is the confidential proprietary property of DM Software This document is
 * protected by copyright. No part of it may be reproduced or copied without the prior written
 * permission of DM Software DM products are supplied under licence and
 * may be used only in accordance with the terms of the contractual agreement between DM
 * and the licence holder. All products, brand names and trademarks referred to in this
 * publication are the property of DM or third party owners. Unauthorised use may
 * constitute an infringement. DM Software Inc reserves the right to change information
 * contained in this publication without notice. All efforts have been made to ensure accuracy
 * however DM Software Inc does not assume responsibility for errors or for any
 * consequences arising from errors in this publication.
 * 
 * 
 *                   Author:Damo
 *            Creation Date:November 1, 2018
 *              Description: 
 *            Last Modifier:Dmao
 *        Modification Date:November 10, 2018
 *    Description of Change:   
 * ======== ======== =====================
 *
 **/

namespace ERPSupport.SQL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// 数据库操作
    /// </summary>
    public class SQLOperator
    {
        /// <summary>
        /// SQLHelper 目前只支持SQLSERVER
        /// </summary>
        /// <param name="pConnectionString">数据库链接字符串</param>
        /// <param name="pType">查询类型</param>
        /// <param name="pCommandText">查询语句</param>
        /// <param name="pDBType">数据库类型</param>
        /// <returns></returns>
        internal object SqlOperation(string pConnectionString, Model.Enum.SQLReturnType pType, string pCommandText, Model.Enum.DBType pDBType = Model.Enum.DBType.SQLServer)
        {
            object obj;

            switch(pDBType)
            {
                case Model.Enum.DBType.SQLServer:

                    SqlDataAdapter adp;
                    SqlConnection conn = new SqlConnection(pConnectionString);

                    try
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = pCommandText;

                        switch (pType)
                        {
                            case Model.Enum.SQLReturnType.NoneQuery:
                                obj = cmd.ExecuteNonQuery();
                                break;
                            case Model.Enum.SQLReturnType.Scalar:
                                obj = cmd.ExecuteScalar();
                                break;
                            case Model.Enum.SQLReturnType.Reader:
                                obj = cmd.ExecuteReader();
                                break;
                            case Model.Enum.SQLReturnType.DataTable:
                                DataTable dt = new DataTable();
                                adp = new SqlDataAdapter(pCommandText, conn);
                                adp.Fill(dt);
                                obj = dt;
                                break;
                            case Model.Enum.SQLReturnType.DataSet:
                                DataSet ds = new DataSet();
                                adp = new SqlDataAdapter(pCommandText, conn);
                                adp.Fill(ds);
                                obj = ds;
                                break;
                            default:
                                obj = null;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        obj = "Error:" + ex.Message.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }
                    break;
                case Model.Enum.DBType.Oracle:
                case Model.Enum.DBType.MySQL:
                    {
                        obj = null;
                    }
                    break;
                default:
                    obj = null;
                    break;
            }

            return obj;
        }
    }
}

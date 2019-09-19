/**
 * Copyright
 * DM Software Inc.
 * 
 * This is the confidential proprietary property of DM Software Inc. This document is 
 * protected by copyright. No part of it may be reproduced or copied without the prior written
 * permission of DM Software Inc. DM products are supplied under licence and
 * may be used only in accordance with the terms of the contractual agreement between DM
 * and the licence holder. All products, brand names and trademarks referred to in this 
 * publication are the property of DM or third party owners. Unauthorised use may
 * constitute an infringement. DM Software Inc reserves the right to change information
 * contained in this publication without notice. All efforts have been made to ensure accuracy
 * however DM Software Inc does not assume responsibility for errors or for any
 * consequences arising from errors in this publication. 
 *
 * Author: Damo
 * Created: November 1, 2018
 * 
 * Modified Date     Description of Change
 * ======== ======== =====================
 * DM	10-24-18 Add methods GenInExpression(int), GenInExpression(string), ReviseSQL(string)
 */

namespace ERPSupport.SQL
{
    using System;
    using System.Data;
    using Model.Globa;
    using Oracle.ManagedDataAccess.Client;

    /// <summary>
    /// 自定义ORAHelper
    /// </summary>
    public static class ORAHelper
    {
        static ORAHelper() { }

        //
        public static string ConnectionChecked(string pConnectionString)
        {
            OracleConnection conn = new OracleConnection(pConnectionString);
            try
            {
                conn.Open();
                return "连接成功";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        //NonQuery
        public static int ExecuteNonQuery(string pCommandText)
        {
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                return cmd.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                conn.Close();
            }
        }

        //Scalar
        public static object ExecuteScalar(string pConnectionString, string pCommandText)
        {
            object o = new object();
            OracleConnection conn = new OracleConnection(pConnectionString);

            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                o = cmd.ExecuteScalar();
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }
            return o;
        }
        public static object ExecuteScalar(string pCommandText)
        {
            object o = new object();
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                o = cmd.ExecuteScalar();
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }
            return o;
        }

        //DataTable
        public static DataTable ExecuteTable(string pConnectionString, string pCommandText)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(pConnectionString);

            try
            {
                conn.Open();
                OracleDataAdapter adp = new OracleDataAdapter(pCommandText, conn);
                adp.Fill(dt);
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public static DataTable ExecuteTable(string pCommandText)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleDataAdapter adp = new OracleDataAdapter(pCommandText, conn);
                adp.SelectCommand.CommandTimeout = 10000;
                adp.Fill(dt);
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        //Reader
        public static OracleDataReader ExecuteReader(string pCommandText)
        {
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                return cmd.ExecuteReader();
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }
        }

        //DataSet
        public static DataSet ExecuteDataSet(string pCommandText)
        {
            DataSet ds = new DataSet();
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleDataAdapter adp = new OracleDataAdapter(pCommandText, conn);
                adp.Fill(ds);
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }

            return ds;
        }
    }
}


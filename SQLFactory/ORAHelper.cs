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
    using System.Data;
    using Model.Globa;
    using Oracle.ManagedDataAccess.Client;

    /// <summary>
    /// 自定义ORAHelper
    /// </summary>
    public static class ORAHelper
    {
        static ORAHelper() { }

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
        public static int ExecuteNonQuery(string pCommandText, OracleParameter[] pParameters)
        {
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                foreach (OracleParameter parm in pParameters)
                {
                    cmd.Parameters.Add(parm);
                }
                return cmd.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                conn.Close();
            }
        }
        public static int ExecuteNonQuery(CommandType pCommandType, string pCommandText, params OracleParameter[] pParameters)
        {
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = pCommandType;
                cmd.CommandText = pCommandText;
                cmd.CommandTimeout = 500;

                if (pCommandType == CommandType.StoredProcedure)
                    cmd.CommandTimeout = 10000;

                if (pParameters != null)
                {
                    foreach (OracleParameter parm in pParameters)
                        cmd.Parameters.Add(parm);
                }

                return cmd.ExecuteNonQuery();
            }
            catch { return -1; }
            finally
            {
                conn.Close();
            }
        }
        public static int ExecuteNonQuery(OracleConnection pConnection, CommandType pCommandType, string pCommandText, params OracleParameter[] pParameters)
        {
            OracleCommand cmd = new OracleCommand();

            CommandSetting(pConnection, cmd, null, pCommandType, pCommandText, pParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            pConnection.Close();
            return val;
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
        public static object ExecuteScalar(string pCommandText, OracleParameter[] pParameters)
        {
            object o = new object();
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                foreach (OracleParameter parm in pParameters)
                {
                    cmd.Parameters.Add(parm);
                }
                o = cmd.ExecuteScalar();
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }
            return o;
        }
        public static object ExecuteScalar(CommandType pCommandType, string pCommandText, params OracleParameter[] pParameters)
        {
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandType = pCommandType;
                cmd.CommandText = pCommandText;
                cmd.CommandTimeout = 500;

                if (pCommandType == CommandType.StoredProcedure)
                    cmd.CommandTimeout = 10000;

                if (pParameters != null)
                {
                    foreach (OracleParameter parm in pParameters)
                        cmd.Parameters.Add(parm);
                }

                return cmd.ExecuteScalar();
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }
        }
        public static object ExecuteScalar(OracleConnection pConnection, CommandType pCommandType, string pCommandText, params OracleParameter[] pParameters)
        {
            try
            {
                if (pConnection.State != ConnectionState.Open)
                    pConnection.Open();

                OracleCommand cmd = pConnection.CreateCommand();
                cmd.CommandType = pCommandType;
                cmd.CommandText = pCommandText;
                cmd.CommandTimeout = 500;

                if (pCommandType == CommandType.StoredProcedure)
                    cmd.CommandTimeout = 10000;

                if (pParameters != null)
                {
                    foreach (OracleParameter parm in pParameters)
                        cmd.Parameters.Add(parm);
                }

                return cmd.ExecuteScalar();
            }
            catch { return null; }
            finally
            {
                pConnection.Close();
            }
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
        public static DataTable ExecuteTable(string pCommandText, OracleParameter[] pParameters)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);

            try
            {
                conn.Open();
                OracleDataAdapter adp = new OracleDataAdapter(pCommandText, conn);
                foreach (OracleParameter parm in pParameters)
                {
                    adp.SelectCommand.Parameters.Add(parm);
                }
                adp.Fill(dt);
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public static DataTable ExecuteTable(CommandType pCommandType, string pCommandText, OracleParameter[] pParameters)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);
            OracleDataAdapter adp = new OracleDataAdapter();

            try
            {
                conn.Open();
                adp.SelectCommand.Connection = conn;
                adp.SelectCommand.CommandText = pCommandText;
                adp.SelectCommand.CommandType = pCommandType;

                if (pCommandType == CommandType.StoredProcedure)
                    adp.SelectCommand.CommandTimeout = 10000;

                foreach (OracleParameter parm in pParameters)
                {
                    adp.SelectCommand.Parameters.Add(parm);
                }
                adp.Fill(dt);
            }
            catch { return null; }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public static DataTable ExecuteTable(OracleConnection pConnection, CommandType pCommandType, string pCommandText, OracleParameter[] pParameters)
        {
            DataTable dt = new DataTable();
            OracleDataAdapter adp = new OracleDataAdapter();

            try
            {
                if (pConnection.State != ConnectionState.Open)
                    pConnection.Open();

                adp.SelectCommand.Connection = pConnection;
                adp.SelectCommand.CommandText = pCommandText;
                adp.SelectCommand.CommandType = pCommandType;

                if (pCommandType == CommandType.StoredProcedure)
                    adp.SelectCommand.CommandTimeout = 10000;

                foreach (OracleParameter parm in pParameters)
                {
                    adp.SelectCommand.Parameters.Add(parm);
                }
                adp.Fill(dt);
            }
            catch { return null; }
            finally
            {
                pConnection.Close();
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
        public static DataSet ExecuteDataSet(CommandType pCommandType, string pCommandText, params OracleParameter[] pParameters)
        {
            DataSet ds = new DataSet("root");
            OracleConnection conn = new OracleConnection(GlobalParameter.K3Inf.C_ORCLADDRESS);
            OracleDataAdapter adp = new OracleDataAdapter();
            //OracleCommand cmd = new OracleCommand();

            try
            {
                conn.Open();
                adp.SelectCommand.Connection = conn;
                //sda.SelectCommand = cmd;
                adp.SelectCommand.CommandText = pCommandText;
                adp.SelectCommand.CommandType = pCommandType;

                if (pCommandType == CommandType.StoredProcedure)
                    adp.SelectCommand.CommandTimeout = 10000;

                if (pParameters != null)
                {
                    foreach (OracleParameter parm in pParameters)
                        adp.SelectCommand.Parameters.Add(parm);
                }
                adp.Fill(ds);
                adp.SelectCommand.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
        public static DataSet ExecuteDataSet(OracleConnection pConnection, CommandType pCommandType, string pCommandText, params OracleParameter[] pParameters)
        {
            DataSet ds = new DataSet();
            OracleDataAdapter adp = new OracleDataAdapter();

            try
            {
                if (pConnection.State != ConnectionState.Open)
                    pConnection.Open();

                adp.SelectCommand.Connection = pConnection;
                adp.SelectCommand.CommandText = pCommandText;
                adp.SelectCommand.CommandType = pCommandType;

                if (pCommandType == CommandType.StoredProcedure)
                    adp.SelectCommand.CommandTimeout = 10000;

                if (pParameters != null)
                {
                    foreach (OracleParameter parm in pParameters)
                        adp.SelectCommand.Parameters.Add(parm);
                }
                adp.Fill(ds);
                adp.SelectCommand.Parameters.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {
                pConnection.Close();
            }

            return ds;
        }

        //Private Custom Methods
        private static void CommandSetting(OracleConnection pConnection, OracleCommand pCommand, OracleTransaction pTransation, CommandType pCommandType, string pCommandText, OracleParameter[] pParameters)
        {

            if (pConnection.State != ConnectionState.Open)
                pConnection.Open();

            pCommand.Connection = pConnection;
            pCommand.CommandText = pCommandText;
            pCommand.CommandTimeout = 500;

            if (pCommandType == CommandType.StoredProcedure) pCommand.CommandTimeout = 10000;

            if (pTransation != null)
                pCommand.Transaction = pTransation;

            pCommand.CommandType = pCommandType;

            if (pParameters != null)
            {
                foreach (OracleParameter parm in pParameters)
                    pCommand.Parameters.Add(parm);
            }
        }

        #region Oracle
        //NonQuery
        //public static void ExecuteNonQuery(string pConnectionString, string pSQL)
        //{
        //    OracleConnection orclConn = new OracleConnection(pConnectionString);
        //    try
        //    {
        //        orclConn.Open();
        //        OracleCommand cmd = orclConn.CreateCommand();
        //        cmd.CommandText = pSQL;
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch { return; }
        //    finally
        //    {
        //        orclConn.Close();
        //    }
        //}

        //public static void ExecuteNonQuery(OracleConnection pOrclConn, string pSQL)
        //{
        //    try
        //    {
        //        pOrclConn.Open();
        //        OracleCommand cmd = pOrclConn.CreateCommand();
        //        cmd.CommandText = pSQL;
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch { return; }
        //    finally
        //    {
        //        pOrclConn.Close();
        //    }
        //}

        //public static void ExecuteNonQuery(OracleConnection pOrclConn, CommandType pCmdType, string pCmdText)
        //{
        //    try
        //    {
        //        pOrclConn.Open();
        //        OracleCommand cmd = pOrclConn.CreateCommand();
        //        cmd.CommandText = pCmdText;
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch { return; }
        //    finally
        //    {
        //        pOrclConn.Close();
        //    }
        //}

        //public static void ExecuteNonQuery(OracleConnection pOrclConn, CommandType pCmdType, string pCmdText, OracleParameter[] pParameters)
        //{
        //    try
        //    {
        //        pOrclConn.Open();
        //        OracleCommand cmd = pOrclConn.CreateCommand();
        //        cmd.CommandText = pCmdText;
        //        if (pParameters != null)
        //        {
        //            foreach (OracleParameter parm in pParameters)
        //                cmd.Parameters.Add(parm);
        //        }
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch { return; }
        //    finally
        //    {
        //        pOrclConn.Close();
        //    }
        //}

        ////Scalar
        //public static object ExecuteScalar(string pConnectionString, string pSQL)
        //{
        //    object o = new object();
        //    OracleConnection orclConn = new OracleConnection(pConnectionString);
        //    try
        //    {
        //        orclConn.Open();
        //        OracleCommand cmd = orclConn.CreateCommand();
        //        cmd.CommandText = pSQL;
        //        o = cmd.ExecuteScalar();
        //    }
        //    catch { return null; }
        //    finally
        //    {
        //        orclConn.Close();
        //    }
        //    return o;
        //}

        //public static object ExecuteScalar(OracleConnection pOrclConn, string pSQL)
        //{
        //    object o = new object();
        //    try
        //    {
        //        pOrclConn.Open();
        //        OracleCommand cmd = pOrclConn.CreateCommand();
        //        cmd.CommandText = pSQL;
        //        o = cmd.ExecuteScalar();
        //    }
        //    catch { return null; }
        //    finally
        //    {
        //        pOrclConn.Close();
        //    }
        //    return o;
        //}

        ////Table
        //public static DataTable ExecuteTable(string pConnectionString, string pSQL)
        //{
        //    DataTable dt = new DataTable();
        //    OracleConnection orclConn = new OracleConnection(pConnectionString);
        //    try
        //    {
        //        orclConn.Open();
        //        //OracleCommand cmd = orclConn.CreateCommand();
        //        //cmd.CommandText = pSQL;
        //        OracleDataAdapter adp = new OracleDataAdapter(pSQL, orclConn);
        //        adp.Fill(dt);
        //    }
        //    catch { return null; }
        //    finally
        //    {
        //        orclConn.Close();
        //    }
        //    return dt;
        //}

        //public static DataTable ExecuteTable(OracleConnection pOrclConn, string pSQL)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        pOrclConn.Open();
        //        //OracleCommand cmd = pOrclConn.CreateCommand();
        //        //cmd.CommandText = pSQL;
        //        OracleDataAdapter adp = new OracleDataAdapter(pSQL, pOrclConn);
        //        adp.Fill(dt);
        //    }
        //    catch { return null; }
        //    finally
        //    {
        //        pOrclConn.Close();
        //    }
        //    return dt;
        //}

        ////DataSet
        //public static DataSet ExecuteDataSet(string pConnectionString, string pSQL)
        //{
        //    DataSet ds = new DataSet();
        //    OracleConnection orclConn = new OracleConnection(pConnectionString);
        //    try
        //    {
        //        orclConn.Open();
        //        OracleCommand cmd = orclConn.CreateCommand();
        //        cmd.CommandText = pSQL;
        //        OracleDataAdapter adp = new OracleDataAdapter(cmd.CommandText, orclConn);
        //        adp.Fill(ds);
        //    }
        //    catch { return null; }
        //    finally
        //    {
        //        orclConn.Close();
        //    }
        //    return ds;
        //}

        //public static DataSet ExecuteDataSet(OracleConnection pOrclConn, string pSQL)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        pOrclConn.Open();
        //        OracleCommand cmd = pOrclConn.CreateCommand();
        //        cmd.CommandText = pSQL;
        //        OracleDataAdapter adp = new OracleDataAdapter(cmd.CommandText, pOrclConn);
        //        adp.Fill(ds);
        //    }
        //    catch { return null; }
        //    finally
        //    {
        //        pOrclConn.Close();
        //    }
        //    return ds;
        //}
        #endregion
    }
}

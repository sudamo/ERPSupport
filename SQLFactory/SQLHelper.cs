/**
 * 
 * DM Software
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
 *        Modification Date:November 11, 2018
 *    Description of Change:   
 * ======== ======== =====================
 * DM   November 11, 2018   Add methods:ExecuteNonQuery(SqlConnection pConn, CommandType pCommandType, string pCommandText);ExecuteNonQuery(SqlConnection pConn, CommandType pCommandType, string pCommandText, SqlParameter[] pParameters)
 * 
 **/

namespace ERPSupport.SQL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Model.Globa;

    /// <summary>
    /// 自定义SQLHelper
    /// </summary>
    internal static class SQLHelper
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static SQLHelper() { }

        //
        public static string ConnectionChecked(string pConnectionString)
        {
            SqlConnection conn = new SqlConnection(pConnectionString);
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
        public static void ExecuteNonQuery(string pCommandText)
        {
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                cmd.ExecuteNonQuery();
            }
            catch { return; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public static void ExecuteNonQuery(string pConnectionString, string pCommandText)
        {
            SqlConnection conn = new SqlConnection(pConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                cmd.ExecuteNonQuery();
            }
            catch { return; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public static void ExecuteNonQuery(string pCommandText, SqlParameter[] pParameters)
        {
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                foreach (SqlParameter parm in pParameters)
                {
                    cmd.Parameters.Add(parm);
                }
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch { return; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public static void ExecuteNonQuery(CommandType pCommandType, string pCommandText, SqlParameter[] pParameters)
        {
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = pCommandType;
                cmd.CommandText = pCommandText;
                if (cmd.CommandType == CommandType.StoredProcedure)
                    cmd.CommandTimeout = 1200;
                if (pParameters != null)
                {
                    foreach (SqlParameter parm in pParameters)
                        cmd.Parameters.Add(parm);
                }
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex) { return; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public static int ExecuteNonQuery(SqlConnection pConnection, CommandType pCommandType, string pCommandText, SqlParameter[] pParameters)
        {
            //try
            //{
            //    pConn.Open();
            //    SqlCommand cmd = pConn.CreateCommand();
            //    cmd.CommandType = pCommandType;
            //    cmd.CommandText = pCommandText;
            //    if (pParameters != null)
            //    {
            //        foreach (SqlParameter parm in pParameters)
            //            cmd.Parameters.Add(parm);
            //    }
            //    cmd.ExecuteNonQuery();
            //}
            //catch { return; }
            //finally
            //{
            //    pConn.Close();
            //}

            int iReturnVal;
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            SqlCommand cmd = conn.CreateCommand();

            CommandSetting(pConnection, cmd, pCommandType, pCommandText, null, pParameters);
            iReturnVal = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            return iReturnVal;
        }
        public static int ExecuteNonQuery(SqlConnection pConnection, SqlTransaction pTransation, CommandType pCommandType, string pCommandText, SqlParameter[] pParameters)
        {
            int val;
            SqlCommand cmd = new SqlCommand();

            CommandSetting(pConnection, cmd, pCommandType, pCommandText, pTransation, pParameters);
            val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        //Scalar
        public static object ExecuteScalar(string pConnectionString, string pCommandText)
        {
            object o = new object();
            SqlConnection conn = new SqlConnection(pConnectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                o = cmd.ExecuteScalar();
            }
            catch { return null; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return o;
        }
        public static object ExecuteScalar(string pCommandText)
        {
            object o = new object();
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                o = cmd.ExecuteScalar();
            }
            catch (Exception ex) { return "ERROR:" + ex.Message; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return o;
        }
        public static object ExecuteScalar(string pCommandText, SqlParameter[] pParameters)
        {
            object o = new object();
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                foreach (SqlParameter parm in pParameters)
                {
                    cmd.Parameters.Add(parm);
                }
                o = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
            }
            catch (Exception ex) { return null; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return o;
        }
        public static object ExecuteScalar(CommandType pCommandType, string pCommandText, SqlParameter[] pParameters)
        {
            object ReturnVal;
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            SqlCommand cmd = conn.CreateCommand();

            CommandSetting(conn, cmd, pCommandType, pCommandText, null, pParameters);
            try
            {
                ReturnVal = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return "ERROR:" + ex.Message;
            }
            finally
            {
                cmd.Parameters.Clear();
            }

            return ReturnVal;
        }

        //DataTable
        public static DataTable ExecuteTable(string pConnectionString, string pCommandText)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(pConnectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter(pCommandText, conn);
                adp.Fill(dt);
            }
            catch { return null; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }
        public static DataTable ExecuteTable(string pCommandText)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter(pCommandText, conn);
                adp.Fill(dt);
            }
            catch { return null; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }
        public static DataTable ExecuteTable(string pCommandText, SqlParameter[] pParameters)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter(pCommandText, conn);
                foreach (SqlParameter parm in pParameters)
                {
                    adp.SelectCommand.Parameters.Add(parm);
                }
                adp.Fill(dt);
                adp.SelectCommand.Parameters.Clear();
            }
            catch { return null; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }

        //Reader
        public static SqlDataReader ExecuteReader(string pCommandText)
        {
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = pCommandText;
                return cmd.ExecuteReader();
            }
            catch { return null; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        //DataSet
        public static DataSet ExecuteDataSet(string pCommandText)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);

            try
            {
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter(pCommandText, conn);
                adp.Fill(ds);
            }
            catch { return null; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return ds;
        }
        public static DataSet ExecuteDataSet(CommandType pCommandType, string pCommandText, params SqlParameter[] pParameters)
        {
            DataSet ds = new DataSet("root");
            SqlConnection conn = new SqlConnection(GlobalParameter.SQLInf.ConnectionString);
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();

            try
            {
                conn.Open();
                adp.SelectCommand = cmd;
                adp.SelectCommand.CommandText = pCommandText;
                adp.SelectCommand.CommandType = pCommandType;

                if (pCommandType == CommandType.StoredProcedure)
                    adp.SelectCommand.CommandTimeout = 10000;
                else
                    adp.SelectCommand.CommandTimeout = 500;

                if (pParameters != null)
                {
                    foreach (SqlParameter parm in pParameters)
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
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return ds;
        }
        public static DataSet ExecuteDataSet(SqlConnection pConnection, CommandType pCommandType, string pCommandText, params SqlParameter[] pParameters)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            SqlCommand cmd = pConnection.CreateCommand();

            try
            {
                if (pConnection.State != ConnectionState.Open)
                    pConnection.Open();

                adp.SelectCommand = cmd;
                adp.SelectCommand.CommandText = pCommandText;
                adp.SelectCommand.CommandType = pCommandType;

                if (pCommandType == CommandType.StoredProcedure)
                    adp.SelectCommand.CommandTimeout = 10000;

                if (pParameters != null)
                {
                    foreach (SqlParameter parm in pParameters)
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
                if (pConnection.State == ConnectionState.Open)
                    pConnection.Close();
            }

            return ds;
        }

        //Private Custom Methods
        private static void CommandSetting(SqlConnection pConnection, SqlCommand pCommand, CommandType pCommandType, string pCommandText, SqlTransaction pTransation = null, SqlParameter[] pParameters = null)
        {
            if (pConnection.State != ConnectionState.Open)
                pConnection.Open();

            pCommand.Connection = pConnection;
            pCommand.CommandType = pCommandType;
            pCommand.CommandText = pCommandText;

            if (pCommandType == CommandType.StoredProcedure)
                pCommand.CommandTimeout = 10000;
            else
                pCommand.CommandTimeout = 500;

            if (pTransation != null)
                pCommand.Transaction = pTransation;

            if (pParameters != null)
            {
                foreach (SqlParameter parm in pParameters)
                    pCommand.Parameters.Add(parm);
            }
        }
    }
}

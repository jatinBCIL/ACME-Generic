using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Security.Cryptography;
using System.IO;

public class SqlDataLayer
{


    #region "Variable Zone"

    public SqlTransaction sqlTran;
    public SqlConnection con;
    public string strLocal = System.Configuration.ConfigurationManager.ConnectionStrings["strLocal"].ConnectionString;
    public string strErp = System.Configuration.ConfigurationManager.ConnectionStrings["strERP"].ConnectionString;

    private static byte[] key = { };
    private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
    public static string fn_Decrypt_String(string stringToDecrypt, string sEncryptionKey)
    {
        byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(stringToDecrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms,
              des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public bool Connect(string strConnection)
    {
        con = new SqlConnection(strConnection);
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = strConnection;
                con.Open();
                return true;
            }
            else if (con.State == ConnectionState.Open)
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            con.Close();
            con = null;
        }
    }

    #endregion


    public string ExecuteProcedureParam(string strConnection, string Proc, SqlParameter[] param, string varOut, string result)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                cmd.CommandTimeout = 30000;
                cmd.CommandText = Proc;
                cmd.ExecuteNonQuery();
                if (cmd.Parameters[result].Value.ToString() != "")
                {
                    sqlTran.Commit();
                    return cmd.Parameters[varOut].Value.ToString();
                }
                else
                { return string.Empty; }
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + Proc);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public string ExecuteProcedureParam_ERP(string strConnection, string Proc, SqlParameter[] param, string varOut, string result)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(param);
                cmd.CommandTimeout = 60000;
                cmd.CommandText = Proc;
                cmd.ExecuteNonQuery();
                if (cmd.Parameters[result].Value.ToString() != "")
                {
                    sqlTran.Commit();
                    return cmd.Parameters[varOut].Value.ToString();
                }
                else
                { return string.Empty; }
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + Proc);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public int ExecuteQueryParam(string strConnection, string Proc, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddRange(param);
                cmd.CommandText = Proc;
                int _Result = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (_Result != 0)
                {
                    sqlTran.Commit();
                    return 1;
                }
                else
                { return 0; }
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + Proc);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public DataTable ExecuteProcedure_Table(string strConnection, string strQuery, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter adp;
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                adp = new SqlDataAdapter(strQuery, con);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                adp.SelectCommand.Parameters.AddRange(param);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                return ds.Tables[0];
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + strQuery);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            con = null;
        }
    }
    

    public DataTable ExecuteProcedureParamTable(string strConnection, string Proc, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();

        SqlDataAdapter adp;
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {

                sqlTran = con.BeginTransaction();
                adp = new SqlDataAdapter(Proc, con);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                adp.SelectCommand.Parameters.AddRange(param);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                return ds.Tables[0];
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n\n" + "Query:" + "\n" + Proc);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public DataSet ExecuteProcedureParamDataset(string strConnection, string Proc, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();

        SqlDataAdapter adp;
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {

                sqlTran = con.BeginTransaction();
                adp = new SqlDataAdapter(Proc, con);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                adp.SelectCommand.Parameters.AddRange(param);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                return ds;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n\n" + "Query:" + "\n" + Proc);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public DataSet ExecuteProcedure_DataSet(string strConnection, string strQuery, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter adp;
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                adp = new SqlDataAdapter(strQuery, con);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                adp.SelectCommand.Parameters.AddRange(param);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                return ds;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + strQuery);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            con = null;
        }
    }
    public DataSet ExecuteDataset(string strConnection, string qry)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter OracleSda = new SqlDataAdapter(qry, con);
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                DataSet ds_Dataset = new DataSet();
                OracleSda.SelectCommand.Transaction = sqlTran;
                OracleSda.SelectCommand.CommandTimeout = 6000;
                OracleSda.Fill(ds_Dataset);
                sqlTran.Commit();
                return ds_Dataset;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            OracleSda = null;
            con = null;
        }

    }
    public SqlDataReader ExecuteDataReader(string strConnection, string qry)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandText = qry;
                SqlDataReader oReader = cmd.ExecuteReader();
                sqlTran.Commit();
                return oReader;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public int ExecuteNonQuery(string strConnection, string qry)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandText = qry;
                int i = (int)cmd.ExecuteNonQuery();
                sqlTran.Commit();
                return i;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public int ExecuteNonQuery_Param(string strConnection, string qry, SqlParameter[] obj)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Parameters.AddRange(obj);
                cmd.Transaction = sqlTran;
                cmd.CommandText = qry;
                int i = (int)cmd.ExecuteNonQuery();
                sqlTran.Commit();
                return i;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public DataSet ExecuteDataset1(string strConnection, string qry)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter OracleSda = new SqlDataAdapter(qry, con);
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                DataSet ds_Dataset = new DataSet();
                OracleSda.SelectCommand.Transaction = sqlTran;
                OracleSda.SelectCommand.CommandTimeout = 6000;
                OracleSda.Fill(ds_Dataset);
                sqlTran.Commit();
                return ds_Dataset;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            OracleSda = null;
            con = null;
        }

    }

    public String ExecuteScalarString_Parameter(string strConnection, string qry, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.Parameters.AddRange(param);
                cmd.CommandText = qry;
                string strOutput = (string)cmd.ExecuteScalar();
                sqlTran.Commit();
                if (strOutput == null || strOutput == DBNull.Value.ToString())
                    return string.Empty;
                return strOutput;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public String ExecuteScalarString(string strConnection, string qry)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandText = qry;
                string strOutput = (string)cmd.ExecuteScalar();
                sqlTran.Commit();
                if (strOutput == null || strOutput == DBNull.Value.ToString())
                    return string.Empty;
                return strOutput;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public int ExecuteScalar(string strConnection, string qry)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.CommandText = qry;
                int intOutput = (Int32)cmd.ExecuteScalar();
                sqlTran.Commit();
                return intOutput;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public int ExecuteScalar_Param(string strConnection, string qry, SqlParameter[] param)
    {
        con = new SqlConnection(strConnection);
        SqlCommand cmd = new SqlCommand();
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = sqlTran;
                cmd.Parameters.AddRange(param);
                cmd.CommandText = qry;
                int intOutput = (Int32)cmd.ExecuteScalar();
                sqlTran.Commit();
                return intOutput;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            cmd = null;
            con = null;
        }
    }

    public DataSet ExecuteDataset_Param(string strConnection, string qry, SqlParameter[] obj)
    {
        con = new SqlConnection(strConnection);
        SqlDataAdapter adp = new SqlDataAdapter(qry, con);
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                sqlTran = con.BeginTransaction();
                //adp = new SqlDataAdapter(qry, con);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.CommandTimeout = 6000;
                adp.SelectCommand.Transaction = sqlTran;
                adp.SelectCommand.Parameters.AddRange(obj);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                sqlTran.Commit();
                // return ds.Tables[0];
                return ds;
            }
            else
            {
                throw new Exception("database connection not found");
            }
        }
        catch (Exception ex)
        {
            sqlTran.Rollback();
            throw new Exception(ex.ToString() + "\n" + "Query:" + "\n" + qry);
        }
        finally
        {
            if (con.State == ConnectionState.Open) { con.Close(); }
            adp = null;
            con = null;
        }
    }

}


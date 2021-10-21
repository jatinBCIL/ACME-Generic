using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BL_Reports
/// </summary>
public class BL_Reports
{

    public DataSet GetReport(string strReport, string strWhere, string strQuery)
    {

        clsReport _DataLayer = new clsReport();
        try
        {
            return _DataLayer.BL_Report_Genrater(strReport, strWhere.Trim(), strQuery);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            _DataLayer = null;
        }

    }


    public void BindSearchGrid(GridView grSearch, string strTable, string strExclude)
    {
        string strQuery;
        SqlDataLayer objSql = new SqlDataLayer();
        DataSet ds = new DataSet();
        try
        {
            strQuery = "SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + strTable + "' ";

            if (strExclude != "")
            {
                strQuery = strQuery + " AND COLUMN_NAME IN (" + strExclude.Substring(0, strExclude.Length - 1) + ")";
            }
            ds = objSql.ExecuteDataset(objSql.strLocal, strQuery);
            grSearch.DataSource = ds;
            grSearch.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objSql = null;
        }
    }



    public void fillCommonDropDown(DropDownList drpCom, string ColName, string TableName, string ConditionCol1, string ConditionValue1)
    {
        SqlDataLayer objDL = new SqlDataLayer();
        DataSet ds = new DataSet();
        string Query;
        try
        {
            Query = "SELECT distinct  \"" + ColName + "\", \"" + ColName + "\" FROM " + TableName + " ";
            ds = objDL.ExecuteDataset(objDL.strLocal, Query);
            drpCom.Items.Clear();
            ListItem lAll = new ListItem("-All-", "-All-");
            drpCom.Items.Add(lAll);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem lm = new ListItem(ds.Tables[0].Rows[i].ItemArray[0].ToString(), ds.Tables[0].Rows[i].ItemArray[1].ToString());
                drpCom.Items.Add(lm);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            ds = null;
            Query = "";
            objDL = null;
        }
    }
}

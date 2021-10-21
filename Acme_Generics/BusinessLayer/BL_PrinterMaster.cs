using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer;
using DataLayer;
using PropertyLayer;

/// <summary>
/// Ref No : 
/// Purpose : Printer Master Transaction
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 29 July 2016
/// Comment : BusinessLayer functions of Printer Master module
/// </summary>


namespace BusinessLayer
{
    public class BL_PrinterMaster
    {
        DL_PrinterMaster objPrinter = new DL_PrinterMaster();

        #region PrinterMasterAPI

        //Inserting And Updating Printer Data
        public string BL_InsertPrinter(PL_PrinterMaster obj)
        {
            string strResult = "";
            strResult = objPrinter.DL_InsertPrinter(obj);
            return strResult;

        }

        //Fetching printer IP and Port
        public DataTable BL_PrinterIPandPort(string strPrinter,string strPlant)
        {
            DataTable dt = new DataTable();
            dt = objPrinter.DL_PrinterIPandPort(strPrinter,strPlant);
            return dt;

        }
        //Fetching data of Printer Master 
        public DataTable BL_PrinterCodes(string strPlant)
        {
            DataTable dt = new DataTable();
            dt = objPrinter.DL_PrinterCodes(strPlant);
            return dt;

        }

        public DataTable BL_GetPrinterDtl(string strWhere, string strPlant)
        {
            DataTable dt = new DataTable();

            dt = objPrinter.DL_getPrinterDtl(strWhere, strPlant);
            return dt;

        }

        //Fetching Department Desc
        public DataTable BL_GetDeptDesc(string strWhere)
        {
            DataTable dt = new DataTable();

            dt = objPrinter.DL_GetDeptDesc(strWhere);
            return dt;

        }

        //Fetching Cubicle Code
        public DataTable BL_GetCubicleCode(string strDeptCode, string strPlantCode)
        {
            DataTable dt = new DataTable();
            dt = objPrinter.DL_GetCubicleCode(strDeptCode, strPlantCode);
            return dt;

        }

        #endregion PrinterMasterAPI

        #region PrinterMasterMM

        //Inserting And Updating Printer Data of MM Module
        public string BL_InsertPrinter_MM(PL_PrinterMaster obj)
        {
            string strResult = "";
            strResult = objPrinter.DL_InsertPrinter_MM(obj);
            return strResult;
        }

        //Fetching Printer Data of MM Module
        public DataTable BL_GetPrinterDtl_MM(string strWhere)
        {
            DataTable dt = new DataTable();

            dt = objPrinter.DL_getPrinterDtl_MM(strWhere);
            return dt;

        }

        //fetching area code against plantcode
        public DataTable BL_GetAreaCode(string strPlantcode)
        {
            DataTable dt = new DataTable();

            dt = objPrinter.DL_GetAreaCode(strPlantcode);
            return dt;

        }

        //fetching Cubicle code against plantcode & Area
        public DataTable BL_GetCubicle(string strPlantCode, string strAreaCode)
        {
            DataTable dt = new DataTable();

            dt = objPrinter.DL_GetCubicle(strPlantCode,strAreaCode);
            return dt;

        }

        #endregion PrinterMasterMM
    }
}

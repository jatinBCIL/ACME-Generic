using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PropertyLayer;

/// <summary>
/// Ref No : 
/// Purpose : Printer Master Transaction
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 29 July 2016
/// Comment : Datalayer functions of Printer Master module
/// </summary>


namespace DataLayer
{
    public class DL_PrinterMaster
    {
        #region PrinterMasterAPI

        //Inserting And Updating Printer Data
        public string DL_InsertPrinter(PL_PrinterMaster obj)
        {
            string strResult = "";
            try
            {
                SqlDataLayer ObjData = new SqlDataLayer();
                SqlParameter[] objparam = new SqlParameter[14];
                objparam[0] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@DEPTCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@DEPTDESC", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@PRINTERCODE", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@PRINTERIP", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@PRINTERPORT", SqlDbType.Int);
                objparam[6] = new SqlParameter("@CUBICLECODE", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@CRBY", SqlDbType.VarChar);
                objparam[8] = new SqlParameter("@MDBY", SqlDbType.VarChar);
                objparam[9] = new SqlParameter("@MODE", SqlDbType.VarChar);
                objparam[10] = new SqlParameter("@REFNO", SqlDbType.Int);
                objparam[11] = new SqlParameter("@STATUS", SqlDbType.Int);
                objparam[12] = new SqlParameter("@REMARK", SqlDbType.VarChar);
                objparam[13] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objparam[0].Value = obj.strPlantCode;
                objparam[1].Value = obj.strDeptCode;
                objparam[2].Value = obj.strDeptDesc;
                objparam[3].Value = obj.strPrinterCode;
                objparam[4].Value = obj.strPrinterIp;
                objparam[5].Value = obj.strPrinterPort;
                objparam[6].Value = obj.strBoothCode;
                objparam[7].Value = obj.strCreatedBy;
                objparam[8].Value = obj.strModifyBy;
                objparam[9].Value = obj.strFlag;
                objparam[10].Value = obj.REFNO;
                objparam[11].Value = obj.iSt;
                objparam[12].Value = obj.strRemark;
                objparam[13].Direction = ParameterDirection.Output;


                strResult = ObjData.ExecuteProcedureParam(ObjData.strLocal, "SP_INSPRINTERMASTER", objparam, "@RESULT", "@RESULT");
                return strResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        //Fetching data of Printer Master 
        public DataTable DL_getPrinterDtl(string strWhere, string strPlant)
        {
            DataSet ds = new DataSet();
            SqlDataLayer objData = new SqlDataLayer();

            if (strWhere.Trim() == "")
            {
                ds = objData.ExecuteDataset(objData.strLocal, "SELECT * FROM VW_PRINTERMASTER where plantcode='" + strPlant + "' ");
                return ds.Tables[0];
            }
            else
            {
                ds = objData.ExecuteDataset(objData.strLocal, "SELECT * FROM VW_PRINTERMASTER " + strWhere.Trim() + " and plantcode='" + strPlant + "'");
                return ds.Tables[0];
            }

        }
        //For Printer IP and Port
        public DataTable DL_PrinterIPandPort(string strPrintercode,string strPlant)
        {
            DataSet ds = new DataSet();
            SqlDataLayer objData = new SqlDataLayer();

            ds = objData.ExecuteDataset(objData.strLocal, "SELECT PRINTERIP, PRINTERPORT FROM VW_PRINTERMASTER WHERE PRINTERCODE='"+strPrintercode+"' AND PLANTCODE='" + strPlant + "'");
            return ds.Tables[0];
        }

        public DataTable DL_PrinterCodes(string strPlant)
        {
            DataSet ds = new DataSet();
            SqlDataLayer objData = new SqlDataLayer();

            ds = objData.ExecuteDataset(objData.strLocal, "SELECT DISTINCT PRINTERCODE FROM VW_PRINTERMASTER WHERE PLANTCODE='" + strPlant + "'");
            return ds.Tables[0];
        }

        //Fetching Department Desc
        public DataTable DL_GetDeptDesc(string strWhere)
        {
            DataSet ds = new DataSet();
            SqlDataLayer objData = new SqlDataLayer();
            ds = objData.ExecuteDataset(objData.strLocal, "SELECT DepartmentDesc FROM VW_DEPARTMENT WHERE DEPARTMENTCODE='" + strWhere.Trim() + "'");
            return ds.Tables[0];

        }


        //Fetching Cubicle Code
        public DataTable DL_GetCubicleCode(string strDeptCode, string strPlantCode)
        {
            DataSet ds = new DataSet();
            SqlDataLayer objData = new SqlDataLayer();
            ds = objData.ExecuteDataset(objData.strLocal, "SELECT  DISTINCT (CUBICLECODE+'-'+CUBICLEDESC) AS CUBICLECODE  FROM VW_CUBICLEMASTER  WHERE PLANTCODE='" + strPlantCode + "'  AND DEPARTMENTDESC=( SELECT TOP 1 DepartmentDesc FROM VW_DEPARTMENT WHERE   STATUS='1' AND DEPARTMENTCODE='" + strDeptCode + "')");
            return ds.Tables[0];

        }

        #endregion PrinterMasterAPI



        #region PrinterMasterMM

        //Inserting And Updating Printer Data of MM Module
        public string DL_InsertPrinter_MM(PL_PrinterMaster obj)
        {
            string strResult = "";
            try
            {
                SqlDataLayer ObjData = new SqlDataLayer();
                SqlParameter[] objparam = new SqlParameter[12];
                objparam[0] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PRINTERCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@PRINTERIP", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@PRINTERPORT", SqlDbType.Int);
                objparam[4] = new SqlParameter("@AREA", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@CUBICLECODE", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@CRBY", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@MDBY", SqlDbType.VarChar);
                objparam[8] = new SqlParameter("@MODE", SqlDbType.VarChar);
                objparam[9] = new SqlParameter("@REFNO", SqlDbType.Int);
                objparam[10] = new SqlParameter("@STATUS", SqlDbType.Int);
                objparam[11] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objparam[0].Value = obj.strPlantCode;
                objparam[1].Value = obj.strPrinterCode;
                objparam[2].Value = obj.strPrinterIp;
                objparam[3].Value = obj.strPrinterPort;
                objparam[4].Value = obj.strArea;
                objparam[5].Value = obj.strBoothCode;
                objparam[6].Value = obj.strCreatedBy;
                objparam[7].Value = obj.strModifyBy;
                objparam[8].Value = obj.strFlag;
                objparam[9].Value = obj.REFNO;
                objparam[10].Value = obj.iSt;
                objparam[11].Direction = ParameterDirection.Output;


                strResult = ObjData.ExecuteProcedureParam(ObjData.strLocal, "SP_INSPRINTERMASTER_MM", objparam, "@RESULT", "@RESULT");
                return strResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        //Fetching Printer Data of MM Module
        public DataTable DL_getPrinterDtl_MM(string strWhere)
        {
            DataSet ds = new DataSet();
            SqlDataLayer objData = new SqlDataLayer();
            ds = objData.ExecuteDataset(objData.strLocal, "SELECT REFNO,[PLANT_CODE],[PRINTER_CODE],[PRINTER_IP],[PRINTER_PORT],[AREA],[CUBICLE_CODE],[STATUS] FROM VW_PRINTERMASTER_MM " + strWhere.Trim());
            return ds.Tables[0];

        }

        //fetching area code against plantcode
        public DataTable DL_GetAreaCode(string strPlantCode)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "select Distinct Area_Code from VW_AREAMASTER where PLANT_CODE='" + strPlantCode + "'").Tables[0];
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

        //fetching Cubicle code against plantcode & Area
        public DataTable DL_GetCubicle(string strPlantCode, string strAreaCode)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "select DISTINCT CUBICLE_ID from VW_TBLCUBICLEMM where PLANTCODE='" + strPlantCode + "' and AREA='" + strAreaCode + "'").Tables[0];
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


        #endregion PrinterMasterMM

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertyLayer;
using System.Data;
using System.Data.SqlClient;

    /// <summary>
    /// Ref No : 
    /// Purpose : Data Transactions of Plant Master
    /// Created By : 
    /// Created On : 
    /// Modified By : Mayur Morye
    /// Modified On : 29 July 2016.
    /// Comment : Datalayer functions of Plant Master module
    /// </summary>


namespace DataLayer
{
    public class DL_PlantMaster
    {
        public DataTable DL_getPlantCode_Desc()
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string str = "";

            try
            {
                str = "SELECT Distinct PLANTCODE+'-'+PLANTDESC as PLANTCODE FROM [vw_PLANTMASTER] ";
                ds = objSql.ExecuteDataset(objSql.strLocal, str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {

                }
                return dt;
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
        public DataTable DL_getAsc_Desc()
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string str = "";

            try
            {
                str = "select distinct ASSOCIATEPLANTCODE+'-'+ASSOCIATEPLANTDESC as AscPlant from [vw_PLANTMASTER] where ASSOCIATEPLANTCODE<>''";
                ds = objSql.ExecuteDataset(objSql.strLocal, str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {

                }
                return dt;
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
        //Insert and Update Data of Plant
        public string DL_InsertPlant(PL_PlantMastercs obj)
        {
            string strResult = "";
            try
            {
                SqlDataLayer ObjData = new SqlDataLayer();
                SqlParameter[] objparam = new SqlParameter[21];
                objparam[0] = new SqlParameter("@LOC", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@PLANTDESC", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@ASCPLANT", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@ASCPLANTDESC", SqlDbType.VarChar);
                
                objparam[5] = new SqlParameter("@HOLDDAYS", SqlDbType.Int);
                objparam[6] = new SqlParameter("@PLANTTYPE", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@CRBY", SqlDbType.VarChar);
                objparam[8] = new SqlParameter("@MDBY", SqlDbType.VarChar);
                objparam[9] = new SqlParameter("@MODE", SqlDbType.VarChar);
                objparam[10] = new SqlParameter("@REFNO", SqlDbType.Int);
                objparam[11] = new SqlParameter("@STATUS", SqlDbType.Int);
                objparam[12] = new SqlParameter("@REMARK", SqlDbType.VarChar);

                objparam[13] = new SqlParameter("@ADDRESS1", SqlDbType.VarChar);
                objparam[14] = new SqlParameter("@ADDRESS2", SqlDbType.VarChar);
                objparam[15] = new SqlParameter("@ADDRESS3 ", SqlDbType.VarChar);
                objparam[16] = new SqlParameter("@ADDRESS4 ", SqlDbType.VarChar);
                objparam[17] = new SqlParameter("@STATE ", SqlDbType.VarChar);
                objparam[18] = new SqlParameter("@CITY ", SqlDbType.VarChar);
                objparam[19] = new SqlParameter("@PINCODE ", SqlDbType.VarChar);



                objparam[20] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objparam[0].Value = obj.strLoc;
                objparam[1].Value = obj.strPlantCode;
                objparam[2].Value = obj.strPlantDesc;
                objparam[3].Value = obj.strAscPlant;
                objparam[4].Value = obj.strAscPlantDesc;
                objparam[5].Value = obj.strHoldDays;
                objparam[6].Value = obj.strPlantType;
                objparam[7].Value = obj.strCreatedBy;
                objparam[8].Value = obj.strModifyBy;
                objparam[9].Value = obj.strFlag;
                objparam[10].Value = obj.REFNO;
                objparam[11].Value = obj.iSt;
                objparam[12].Value = obj.strRemark;
                objparam[13].Value = obj.strAddress1;
                objparam[14].Value = obj.strAddress2;

                objparam[15].Value = obj.strAddress3;
                objparam[16].Value = obj.strAddress4;
                objparam[17].Value = obj.strState;
                objparam[18].Value = obj.strCity;
                objparam[19].Value = obj.strPincode;

                objparam[20].Direction = ParameterDirection.Output;


                strResult = ObjData.ExecuteProcedureParam(ObjData.strLocal, "SP_INSPLANTMASTER", objparam, "@RESULT", "@RESULT");
                return strResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        //Fetch Data of Plant
        public DataTable DL_getPlantDtl(string strWhere)
        {
            DataSet ds = new DataSet();
            SqlDataLayer objData = new SqlDataLayer();
            ds = objData.ExecuteDataset(objData.strLocal, "SELECT * FROM VW_PLANTMASTER " + strWhere.Trim());
            return ds.Tables[0];

        }
        public DataTable DL_getPlantDtl_Master(string strWhere)
        {
            DataSet ds = new DataSet();
            SqlDataLayer objData = new SqlDataLayer();
            ds = objData.ExecuteDataset(objData.strLocal, "SELECT * FROM VW_PLANTMASTER_DTL_FORMASTER " + strWhere.Trim());
            return ds.Tables[0];

        }


        //Fetch Plant Code from Data
        public DataTable DL_Get_Plant_Recipe()
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string str = "";

            try
            {
                str = "SELECT DISTINCT PLANTCODE FROM [vw_PLANTMASTER] where STATUS='ACTIVATE' ";
                ds = objSql.ExecuteDataset(objSql.strLocal, str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {

                }
                return dt;
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

        public DataTable DL_getPlantCode(string Plant_Code)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string str = "";

            try
            {
                str = "SELECT DISTINCT (PLANTCODE+'-'+PLANTDESC ) AS PLANTCODE FROM [vw_PLANTMASTER] where PLANTCODE ='"+ Plant_Code +"' and  status='ACTIVATE' ";
                ds = objSql.ExecuteDataset(objSql.strLocal, str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {

                }
                return dt;
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


        //Fetch Plant Type from Data
        public DataTable DL_Get_Plant_Type()
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string str = "";

            try
            {
                str = "SELECT DISTINCT PLANTTYPE FROM [vw_PLANTMASTER] ";
                ds = objSql.ExecuteDataset(objSql.strLocal, str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {

                }
                return dt;
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





    }
}

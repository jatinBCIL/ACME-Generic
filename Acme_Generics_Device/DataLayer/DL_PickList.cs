using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DL_PickList
    {

        public string DL_GeneratePicklist(DataTable dt_Temp, string strUser, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[4];
            try
            {
                objparam[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = dt_Temp;
                objparam[1].Value = strPlant;
                objparam[2].Value = strUser;
                objparam[3].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_GeneratePicklist", objparam, "@RESULT", "@RESULT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }
        public string DL_StockAdjust(string strBarcode, string strAdQty, string strType, string strUser, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[6];
            try
            {
                objparam[0] = new SqlParameter("@MATERIALBARCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@ADJUSTQTY", SqlDbType.Decimal);
                objparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBarcode;
                objparam[1].Value = double.Parse(strAdQty);
                objparam[2].Value = strType;
                objparam[3].Value = strPlant;
                objparam[4].Value = strUser;
                objparam[5].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParam(objSql.strLocal, "Val_BarcodeStckAdjust", objparam, "@RESULT", "@RESULT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }
        public string DL_ValidateReversePicking(string strBarcode,string strBin,string strType, string strUser, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[6];
            try
            {
                objparam[0] = new SqlParameter("@MATERIALBARCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@LOCCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBarcode;
                objparam[1].Value = strBin;
                objparam[2].Value = strType;
                objparam[3].Value = strPlant;
                objparam[4].Value = strUser;
                objparam[5].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_Validate_ReversePicking", objparam, "@RESULT", "@RESULT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }
        public DataTable DL_GetPicklistMat(string strPickListNo, string strUser, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[4];
            try
            {
                objparam[0] = new SqlParameter("@PICKLISTNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strPickListNo;
                objparam[1].Value = strPlant;
                objparam[2].Value = strUser;
                objparam[3].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetPickListDtl_MatCode", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }
        public DataTable DL_GetPickPicklist(string strPickListNo, string strUser, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[4];
            try
            {
                objparam[0] = new SqlParameter("@PICKLISTNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strPickListNo;
                objparam[1].Value = strPlant;
                objparam[2].Value = strUser;
                objparam[3].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetPickListDtl_ToPick", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }
        public DataTable DL_GetForReversePicking(string strBatchNo, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[3];
            try
            {
                objparam[0] = new SqlParameter("@BATCHNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBatchNo;
                objparam[1].Value = strPlant;
                objparam[2].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetForReversePicking", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }
        public DataTable DL_GetPicklistN(string strPick, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            // SqlParameter[] objparam = new SqlParameter[3];
            try
            {
                string Query = "SELECT PICKLISTNO FROM TBLPICKLIST WHERE PLANTCODE='" + strPlant + "' AND PICKLISTNO LIKE '%" + strPick + "'";
                return objSql.ExecuteDataset1(objSql.strLocal, Query).Tables[0];
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
        public DataTable DL_GetPicklistNo(string strPick, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[3];
            try
            {
                objparam[0] = new SqlParameter("@PICKLIST", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strPick;
                objparam[1].Value = strPlant;
                objparam[2].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetPicklist", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }
        public string DL_ValidatePicking(string strPickListNo, string strBin, string strMaterial, string strProcOrder, string strBatchNo, string strBarcodeNo, string strType, Double Rqty, string strUser, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[11];
            try
            {
                objparam[0] = new SqlParameter("@PICKLISTNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@Bin", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@PROCESSORDERNO", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@MATERIALCODE", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@MATERIALBATCH", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@BARCODENO", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@RQTY", SqlDbType.Decimal);
                objparam[8] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[9] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[10] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strPickListNo;
                objparam[1].Value = strBin;
                objparam[2].Value = strProcOrder;
                objparam[3].Value = strMaterial;
                objparam[4].Value = strBatchNo;
                objparam[5].Value = strBarcodeNo;
                objparam[6].Value = strType;
                objparam[7].Value = Rqty;
                objparam[8].Value = strPlant;
                objparam[9].Value = strUser;
                objparam[10].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_ValidateBarcodePicking", objparam, "@RESULT", "@RESULT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }


        }
    }
}

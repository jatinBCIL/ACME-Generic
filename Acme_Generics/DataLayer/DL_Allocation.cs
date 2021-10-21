using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class DL_Allocation
    {
        public string DL_ValidateBin(string strRackCode, string strMaterialBarcode, string strType, string strUser, string strPlantCode)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[6];
            try
            {
                objparam[0] = new SqlParameter("@LOCCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@MATERIALBARCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strRackCode;
                objparam[1].Value = strMaterialBarcode;
                objparam[2].Value = strType;
                objparam[3].Value = strPlantCode;
                objparam[4].Value = strUser;
                objparam[5].Direction = ParameterDirection.Output;


                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_Validae_BinAllocation", objparam, "@RESULT", "@RESULT");
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

        public string DL_ValidateBin_LocationTransfer(string strFromCode,string strToCode, string strMaterialBarcode, string strType, string strUser, string strPlantCode)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[7];
            try
            {
                objparam[0] = new SqlParameter("@FROMLOCCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@TOLOCCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@MATERIALBARCODE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strFromCode;
                objparam[1].Value = strToCode;
                objparam[2].Value = strMaterialBarcode;
                objparam[3].Value = strType;
                objparam[4].Value = strPlantCode;
                objparam[5].Value = strUser;
                objparam[6].Direction = ParameterDirection.Output;


                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_Validae_LocationTransfer", objparam, "@RESULT", "@RESULT");
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

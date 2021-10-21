using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
   public class DL_MRNLabel
    {
        public string DL_ValidateMRNBarcode(string strMaterialBarcode, string strPlantCode)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[3];
            try
            {
                objparam[0] = new SqlParameter("@MATERIALBARCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 150);


                objparam[0].Value = strMaterialBarcode;
                objparam[1].Value = strPlantCode;
                objparam[2].Direction = ParameterDirection.Output;


                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_ValidateMRNBarcode", objparam, "@RESULT", "@RESULT");
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

        public string DL_SaveMRNBarcode(string strMaterialBarcode, string strUser,string strPlantCode)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[4];
            try
            {
                objparam[0] = new SqlParameter("@MATERIALBARCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 150);

                objparam[0].Value = strMaterialBarcode;
                objparam[1].Value = strUser;
                objparam[2].Value = strPlantCode;
                objparam[3].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParam_ERP(objSql.strLocal, "sp_SaveMRNVerify_V1", objparam, "@RESULT", "@RESULT");
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

        public string DL_SaveMRNBarcode_ERP(string strMRNQty,string strPBatch,string strLine,string strType,string strARNo,string strMRNBacode, string strUser, string strPlantCode)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            int i = 0;
            string strQuery="";
            try
            {
                strQuery=string.Format("UPDATE [dbo].[Acme Generics Pvt_ Ltd_$Dispensing Detail] SET [Scan Quantity]=[Scan Quantity]+{0},[Status]={1} where " +
                                              "[Product Batch No_]='{2}' and [AR No]='{3}' and ([Prod_ Order Comp_ Line No_]='{4}' or  [Line No_]='{4}' )" +
                                              "and [Document Type]=3 and [Status]=0", strMRNQty, strType, strPBatch, strARNo, strLine);
                objSql.ExecuteNonQuery(objSql.strErp, strQuery);

                strQuery = string.Format("UPDATE TBLGRN_TRANS SET MRN_ST=1,MRNVerifyBy='{0}',[MRNVerfyOn]=GETDATE()" +
                                            " WHERE BarcodeNo='{1}' AND PlantCode='{2}'", strUser, strMRNBacode, strPlantCode);
                i = objSql.ExecuteNonQuery(objSql.strLocal, strQuery);

                 if (i > 0)
                 {
                     return "0|MRN Container has been verified.";
                 }
                 else
                 {
                     return "1|There is some problem.";
                 }

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

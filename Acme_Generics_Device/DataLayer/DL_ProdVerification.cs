using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DL_ProdVerificatiOn
    {

        public DataTable DL_GetMaterialBatch(string strBatchNo, string strPlant,string strBarcodeNo,string strType,string strMaterialCode)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[6];
            try
            {
                objparam[0] = new SqlParameter("@BATCHNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@BARCODENO", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@MATERIALCODE", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBatchNo;
                objparam[1].Value = strPlant;
                objparam[2].Value = strBarcodeNo;
                objparam[3].Value = strType;
                objparam[4].Value = strMaterialCode;
                objparam[5].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetProdVerifDetails", objparam);
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



        public DataTable DL_GetBoothCode(string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataSet ds = new DataSet();
            try
            {

                ds = objSql.ExecuteDataset(objSql.strLocal, "SELECT DISTINCT BOOTHCODE+'-'+BOOTHDESC as 'BOOTH' FROM [dbo].[VW_BOOTHMASTER] WHERE [Status]=1 AND PLANTID='" + strPlant + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;

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

        public string DL_ValidatePicking(string strPickListNo, string strMaterial, string strBatchNo, string strBarcodeNo, string strType, string strUser, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[8];
            try
            {
                objparam[0] = new SqlParameter("@PICKLISTNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@MATERIALCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@MATERIALBATCH", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@BARCODENO", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strPickListNo;
                objparam[1].Value = strMaterial;
                objparam[2].Value = strBatchNo;
                objparam[3].Value = strBarcodeNo;
                objparam[4].Value = strType;
                objparam[5].Value = strPlant;
                objparam[6].Value = strUser;
                objparam[7].Direction = ParameterDirection.Output;

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



        public string DL_ValidateBarcodeDispensing(string strBarcodeNo, string strMaterialCode, string strBatchNo, string strType, string strUser, string strPlant)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[7];
            try
            {

                objparam[0] = new SqlParameter("@MATERIALBARCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@MATERIALCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@BATCHNO", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBarcodeNo;
                objparam[1].Value = strMaterialCode;
                objparam[2].Value = strBatchNo;
                objparam[3].Value = strType;
                objparam[4].Value = strPlant;
                objparam[5].Value = strUser;
                objparam[6].Direction = ParameterDirection.Output;


                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_ValidateBarcodeDispensing", objparam, "@RESULT", "@RESULT");
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

        public DataTable DL_PrintDispensingBarcode(string strBoothCode, string strBatchNo, string strMaterialCode,
           string strIsseUom, string strMaterialBarcode, string strWeighingBalance, decimal DGrossWt, decimal DTareWt, decimal DNetwt, string strUser, string strPlant)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[12];
            try
            {

                objparam[0] = new SqlParameter("@BOOTHCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@MATBATCHNO", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@MATERIALCODE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@ISSUEUOM", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@MATERIALBARCODE", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@WEIGHINGCODE", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@GROSSWT", SqlDbType.Decimal);
                objparam[7] = new SqlParameter("@TAREWT", SqlDbType.Decimal);
                objparam[8] = new SqlParameter("@NETWT", SqlDbType.Decimal);
                objparam[9] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[10] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[11] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBoothCode;
                objparam[1].Value = strBatchNo;
                objparam[2].Value = strMaterialCode;
                objparam[3].Value = strIsseUom;
                objparam[4].Value = strMaterialBarcode;
                objparam[5].Value = strWeighingBalance;
                objparam[6].Value = DGrossWt;
                objparam[7].Value = DTareWt;
                objparam[8].Value = DNetwt;
                objparam[9].Value = strPlant;
                objparam[10].Value = strUser;
                objparam[11].Direction = ParameterDirection.Output;


                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_Print_DispensingBarcode", objparam);
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

        public string DL_ValidateBalanceCode(string strBoothCode, string strBalanceCode, string strType, string strUser, string strPlant)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[6];
            try
            {

                objparam[0] = new SqlParameter("@BOOTHCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@BALANCECODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBoothCode;
                objparam[1].Value = strBalanceCode;
                objparam[2].Value = strType;
                objparam[3].Value = strPlant;
                objparam[4].Value = strUser;
                objparam[5].Direction = ParameterDirection.Output;


                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_ValidateBalanceCode", objparam, "@RESULT", "@RESULT");
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

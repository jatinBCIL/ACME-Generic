using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DL_SamplePrinting
    {

        public DataTable DL_GetARDetails(string strARNo, string strType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                if (strType == "PRINT")
                {

                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT BatchNo,GrnDate,GRNNo,MaterialCode,MaterialName,NoofContainer,MaterialType FROM tblGrn_Master  WITH (NOLOCK) WHERE [InwardNo]='" + strARNo + "' and Printed_Qty>0").Tables[0];
                }
                else
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM tblSample_Trans WITH (NOLOCK) WHERE [InwardNo]='" + strARNo + "'").Tables[0];

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable DL_GetARNumber(string strARNo, string strType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                if (strType == "PRINT")
                {

                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT [InwardNo] FROM tblGrn_Master with (nolock) WHERE [InwardNo] like '%" + strARNo + "' and SamplePrint=0 and Printed_Qty>0").Tables[0];
                }
                else
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT [InwardNo] FROM tblSample_Trans with (nolock) WHERE [InwardNo] like '%" + strARNo + "'").Tables[0];

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable DL_GetBarcodeDetails(string strSampleBarcodeNo, string strMaterialBarcode, string strType, string strUser, string strPlant)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[6];
            try
            {
                objparam[0] = new SqlParameter("@SAMPLEBARCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@MATERIALBARCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strSampleBarcodeNo;
                objparam[1].Value = strMaterialBarcode;
                objparam[2].Value = strType;
                objparam[3].Value = strPlant;
                objparam[4].Value = strUser;
                objparam[5].Direction = ParameterDirection.Output;


                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_Sample_LabelScanning", objparam);
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


        public DataTable DL_GetSampleBarcodeNo(string strGRNno, string strLineItem, string strMatCode, string strQty, string strPackSize, string strPlantCode, string strUser, string strType,string strReason)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[9];
            try
            {
                objparam[0] = new SqlParameter("@GRN_NO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@LINEITEM", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@MATCODE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@QTY", SqlDbType.Decimal);
                objparam[4] = new SqlParameter("@PACKSIZE", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[8] = new SqlParameter("@REASON", SqlDbType.VarChar);

                objparam[0].Value = strGRNno;
                objparam[1].Value = strLineItem;
                objparam[2].Value = strMatCode;
                objparam[3].Value = strQty;
                objparam[4].Value = strPackSize;
                objparam[5].Value = strPlantCode;
                objparam[6].Value = strUser;
                objparam[7].Value = strType;
                objparam[8].Value = strReason;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_Sample_LabelPrinting", objparam);
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

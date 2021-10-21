using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
   public class DL_MRNLabel
    {
        public DataTable DL_GetMRNDetails(string strpre, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct [ProductBatch] FROM [dbo].[tblPickList] WITH(NOLOCK) WHERE [Status]=3 AND [ProductBatch] like '" + strpre + "%' AND PlantCode='" + strPlant + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetMRNData(string strBatch, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT DISTINCT [PRODUCTCODE] FROM [DBO].[TBLPICKLIST] WITH (NOLOCK) WHERE [PRODUCTBATCH]='" + strBatch + "' AND PLANTCODE='" + strPlant + "' AND [status]=3  GROUP BY [PROCESSORDERNO],[PRODUCTBATCH],[PRODUCTCODE],[PRODUCTNAME],MATERIALCODE,[ARNO],UOM,[LineItem] ").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetMRNData(string strBatch, string strProdCode ,string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT [PROCESSORDERNO],[PRODUCTBATCH],[PRODUCTCODE],[PRODUCTNAME],MATERIALCODE,[ARNO],UOM,sum(SCANNEDQUANTITY)SCANNEDQUANTITY,isnull([LineItem],'0')[LineItem] FROM [DBO].[TBLPICKLIST] WITH (NOLOCK) WHERE [PRODUCTBATCH]='" + strBatch + "' AND PRODUCTCODE='"+ strProdCode +"'   AND PLANTCODE='" + strPlant + "' AND [status]=3  GROUP BY [PROCESSORDERNO],[PRODUCTBATCH],[PRODUCTCODE],[PRODUCTNAME],MATERIALCODE,[ARNO],UOM,[LineItem] ").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetMRNBarcodeNo(string strARNo, string strContQty, string strMatCode,string strUser, string strTWeight, string strNWeight, string strGWeight,string strPBatch,string strPName,string strPLineItem)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[10];
            try
            {
                objparam[0] = new SqlParameter("@ARNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@CONTAINERQTY", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@MATCODE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@TWeight", SqlDbType.Decimal);
                objparam[4] = new SqlParameter("@NWeight", SqlDbType.Decimal);
                objparam[5] = new SqlParameter("@GWeight", SqlDbType.Decimal);
                objparam[6] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@PBATCH", SqlDbType.VarChar);
                objparam[8] = new SqlParameter("@PNAME", SqlDbType.VarChar);
                objparam[9] = new SqlParameter("@PLINEITEM", SqlDbType.VarChar);

                objparam[0].Value = strARNo;
                objparam[1].Value = strContQty;
                objparam[2].Value = strMatCode;
                objparam[3].Value = double.Parse(strTWeight);
                objparam[4].Value = double.Parse(strNWeight);
                objparam[5].Value = double.Parse(strGWeight);
                objparam[6].Value = strUser;
                objparam[7].Value = strPBatch;
                objparam[8].Value = strPName;
                objparam[9].Value = strPLineItem;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GenMRNLabel", objparam);
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

        public DataTable DL_GetReprintMRNBarcodeNo(string strBarcode, string strReason, string strUser)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[3];
            try
            {
                objparam[0] = new SqlParameter("@BARCODENONO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@REASON", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@USER", SqlDbType.VarChar);

                objparam[0].Value = strBarcode;
                objparam[1].Value = strReason;
                objparam[2].Value = strUser;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_RePrintMRNLabel", objparam);
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

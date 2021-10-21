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

                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM tblGrn_Master WHERE [ARNo]='" + strARNo + "'").Tables[0];
                }
                else
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM tblSample_Trans WHERE [ARNo]='" + strARNo + "'").Tables[0];

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetDisplayDetails(string strBarcode, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT [BarcodeNo],[GRNNo],[InwardNo],[MaterialCode],[MaterialName],[MaterialType],[BatchNo],CAST(cast([MFGDate] as date) AS varchar)MFGDate,CAST(CAST([EXPDate] AS DATE) AS varchar) EXPDate,ManufactureName,CASE WHEN UPPER(MaterialType)='RM' then ContainerQty else PackQty end [ContainerQty],[SupplierName],[ManufactureName],[StoragCondition],[ARNo],CAST(CAST([RETESTDATE] AS DATE) AS VARCHAR)RETESTDATE,[UDCODE],[Status], [SupplierName],[SampledStatus],isnull(LocationCode,'NA')LocationCode FROM [dbo].[tblGrn_Trans] WITH (NOLOCK) where BarcodeNo='" + strBarcode + "' and PlantCode='" + strPlant + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetBarcodeDetails(string strSampleBarcodeNo, string strMaterialBarcode, string strType, string strUser, string qty, string strCompQty, string strMLTQty, string strPlant,string strUOM)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[10];
            try
            {
                objparam[0] = new SqlParameter("@SAMPLEBARCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@MATERIALBARCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@SQTY", SqlDbType.Decimal);
                objparam[6] = new SqlParameter("@COMP_QTY", SqlDbType.Decimal);
                objparam[7] = new SqlParameter("@MLT_QTY", SqlDbType.Decimal);
                objparam[8] = new SqlParameter("@SUOM", SqlDbType.VarChar);
                objparam[9] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strSampleBarcodeNo;
                objparam[1].Value = strMaterialBarcode;
                objparam[2].Value = strType;
                objparam[3].Value = strPlant;
                objparam[4].Value = strUser;
                objparam[5].Value = double.Parse(qty);
                objparam[6].Value = double.Parse(strCompQty);
                objparam[7].Value = double.Parse(strMLTQty);
                objparam[8].Value = strUOM.Trim()  ;
                objparam[9].Direction = ParameterDirection.Output;


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


        public DataTable DL_GetSampleBarcodeNo(string strGRNno, string strLineItem, string strMatCode, string strQty, string strPackSize, string strPlantCode, string strUser, string strType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[8];
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

                objparam[0].Value = strGRNno;
                objparam[1].Value = strLineItem;
                objparam[2].Value = strMatCode;
                objparam[3].Value = strQty;
                objparam[4].Value = strPackSize;
                objparam[5].Value = strPlantCode;
                objparam[6].Value = strUser;
                objparam[7].Value = strType;

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

        public string DL_ValidateSampBalance(string strBalanceCode, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[3];
            try
            {
                objparam[0] = new SqlParameter("@BALANCECODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBalanceCode;
                objparam[1].Value = strPlant;
                objparam[2].Direction = ParameterDirection.Output;


                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_ValidateSampBalance", objparam, "@RESULT", "@RESULT");
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

        public DataTable DL_GetPrinter(string strPrinter, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT TOP(1) [PRINTERIP],[PRINTERPORT] FROM [dbo].[tblPPPrinter_M] WHERE PRINTERCODE = '" + strPrinter + "' and PlantCode='" + strPlant + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

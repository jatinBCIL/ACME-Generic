using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DL_Dispensing
    {

        public DataTable DL_GetDispensingDtl(string strBatchNo, string strPlant)
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

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetDispensingDtl", objparam);
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

        public DataTable DL_GetDispensingBatchDtl(string strBatchNo, string strPlant)
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

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetDispensBatchDtl", objparam);
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
        public DataTable DL_GetPrinterCode(string strBoothCode)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataSet ds = new DataSet();
            try
            {

                ds = objSql.ExecuteDataset(objSql.strLocal, "SELECT TOP(1) [PRINTERIP],[PRINTERPORT] FROM [dbo].[tblPPPrinter_M] WITH (NOLOCK) where BOOTHCODE='" + strBoothCode + "' ");
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
        public DataTable DL_GetBoothCode(string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataSet ds = new DataSet();
            try
            {

                ds = objSql.ExecuteDataset(objSql.strLocal, "SELECT DISTINCT BOOTHCODE+'/'+BOOTHDESC as 'BOOTH',COUNT FROM [dbo].[VW_BOOTHMASTER] WHERE [Status]=1 AND PLANTID='" + strPlant + "' order by [COUNT] asc");
               
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

        public string DL_GetLotNo(string strMatBatNo, string strMaterialCode, string strProBatNo, string strProcOrder, string strLot, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[7];
            try
            {
                objparam[0] = new SqlParameter("@MATBATCHNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@MATERIALCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@PRODBATCH", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@PROCESSORDERNO", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@LOT", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strMatBatNo;
                objparam[1].Value = strMaterialCode;
                objparam[2].Value = strProBatNo;
                objparam[3].Value = strProcOrder;
                objparam[4].Value = strLot;
                objparam[5].Value = strPlant;
                objparam[6].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_Get_LotNo", objparam, "@RESULT", "@RESULT");
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

        public string DL_ValidateBulkBarcodeDispensing(string strBarcodeNo, string strMaterialCode, string strBatchNo, string strType, string strUser, string strPlant)
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

                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_ValidateBulkBarcodeDispensing", objparam, "@RESULT", "@RESULT");
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
           string strIsseUom, string strMaterialBarcode, string strWeighingBalance, decimal DGrossWt, decimal DTareWt, decimal DNetwt, string strProdBatch,
           string strProcOrderNo, string strLotNo, int Count, string strUser, string strPlant,decimal Rqty,string strLineNo)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[18];
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
                objparam[9] = new SqlParameter("@PRODBATCH", SqlDbType.VarChar);
                objparam[10] = new SqlParameter("@PROCESSORDERNO", SqlDbType.VarChar);
                objparam[11] = new SqlParameter("@LOT", SqlDbType.VarChar);
                objparam[12] = new SqlParameter("@TCOUNT", SqlDbType.Int);
                objparam[13] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[14] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[15] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);
                objparam[16] = new SqlParameter("@RQTY", SqlDbType.Decimal);
                objparam[17] = new SqlParameter("@LINENO", SqlDbType.VarChar);


                objparam[0].Value = strBoothCode;
                objparam[1].Value = strBatchNo;
                objparam[2].Value = strMaterialCode;
                objparam[3].Value = strIsseUom;
                objparam[4].Value = strMaterialBarcode;
                objparam[5].Value = strWeighingBalance;
                objparam[6].Value = DGrossWt;
                objparam[7].Value = DTareWt;
                objparam[8].Value = DNetwt;
                objparam[9].Value = strProdBatch;
                objparam[10].Value = strProcOrderNo;
                objparam[11].Value = strLotNo;
                objparam[12].Value = Count;
                objparam[13].Value = strPlant;
                objparam[14].Value = strUser;
                objparam[15].Direction = ParameterDirection.Output;
                objparam[16].Value = Rqty;
                objparam[17].Value = strLineNo;


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

        public DataTable DL_PrintDispensingBarcodeMulti(DataTable dt, string strBoothCode, string strBatchNo, string strMaterialCode, string strIsseUom,string strWeighingBalance, 
                                                         string strProdBatch,string strProcOrderNo, string strLotNo,
                                                         int Count, string strUser, string strPlant,string strGWeight,string strTWeight,string strLineNo)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[16];
            try
            {

                objparam[0] = new SqlParameter("@BOOTHCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@MATBATCHNO", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@MATERIALCODE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@ISSUEUOM", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@WEIGHINGCODE", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@PRODBATCH", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@PROCESSORDERNO", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@LOT", SqlDbType.VarChar);
                objparam[8] = new SqlParameter("@TCOUNT", SqlDbType.Int);
                objparam[9] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[10] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[11] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);
                objparam[12] = new SqlParameter("@TEMP", SqlDbType.Structured);
                objparam[13] = new SqlParameter("@GROSSWT", SqlDbType.Decimal);
                objparam[14] = new SqlParameter("@TAREWT", SqlDbType.Decimal);
                objparam[15] = new SqlParameter("@LINENO", SqlDbType.VarChar);

                objparam[0].Value = strBoothCode;
                objparam[1].Value = strBatchNo;
                objparam[2].Value = strMaterialCode;
                objparam[3].Value = strIsseUom;
                objparam[4].Value = strWeighingBalance;
                objparam[5].Value = strProdBatch;
                objparam[6].Value = strProcOrderNo;
                objparam[7].Value = strLotNo;
                objparam[8].Value = Count;
                objparam[9].Value = strPlant;
                objparam[10].Value = strUser;
                objparam[11].Direction = ParameterDirection.Output;
                objparam[12].Value = dt;
                objparam[13].Value = double.Parse(strGWeight);
                objparam[14].Value = double.Parse(strTWeight);
                objparam[15].Value = strLineNo;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_Print_DispensingBarcode_Multi", objparam);
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

        public DataTable DL_PrintDispensingBarcodeBulk(DataTable dt, string strBoothCode, string strBatchNo, string strMaterialCode, string strIsseUom, string strWeighingBalance,
                                                      string strProdBatch, string strProcOrderNo, string strLotNo, int Count, string strUser, string strPlant,string strLineNo)
        {

            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[14];
            try
            {

                objparam[0] = new SqlParameter("@BOOTHCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@MATBATCHNO", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@MATERIALCODE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@ISSUEUOM", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@WEIGHINGCODE", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@PRODBATCH", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@PROCESSORDERNO", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@LOT", SqlDbType.VarChar);
                objparam[8] = new SqlParameter("@TCOUNT", SqlDbType.Int);
                objparam[9] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[10] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[11] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);
                objparam[12] = new SqlParameter("@TEMP", SqlDbType.Structured);
                objparam[13] = new SqlParameter("@LINENO", SqlDbType.VarChar);

                objparam[0].Value = strBoothCode;
                objparam[1].Value = strBatchNo;
                objparam[2].Value = strMaterialCode;
                objparam[3].Value = strIsseUom;
                objparam[4].Value = strWeighingBalance;
                objparam[5].Value = strProdBatch;
                objparam[6].Value = strProcOrderNo;
                objparam[7].Value = strLotNo;
                objparam[8].Value = Count;
                objparam[9].Value = strPlant;
                objparam[10].Value = strUser;
                objparam[11].Direction = ParameterDirection.Output;
                objparam[12].Value = dt;
                objparam[13].Value = strLineNo;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_Print_DispensingBarcode_Bulk", objparam);
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


                objparam[0].Value = strBoothCode.Trim();
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

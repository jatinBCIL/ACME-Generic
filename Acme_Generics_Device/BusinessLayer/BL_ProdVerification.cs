using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataLayer;

namespace BusinessLayer
{
    public class BL_ProdVerification
    {

        public DataTable BL_GetMaterialBatch(string strBatchNo, string strPlant, string strBarcodeNo, string strType,string strMaterialCode)
        {
            DL_ProdVerificatiOn objDL = new DL_ProdVerificatiOn();
            try
            {
                return objDL.DL_GetMaterialBatch(strBatchNo, strPlant, strBarcodeNo, strType, strMaterialCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
        public DataTable BL_GetBoothCode(string strPlant)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_GetBoothCode(strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable BL_GetPickPicklist(string strPickListNo, string strUser, string strPlant)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetPickPicklist(strPickListNo, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public string BL_ValidatePicking(string strPickListNo, string Bin ,string strMaterial, string strBatchNo, string strBarcodeNo, string strType, string strUser, string strPlant)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_ValidatePicking(strPickListNo, Bin, strMaterial,"0", strBatchNo, strBarcodeNo, strType,0.00 ,strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string BL_ValidateBarcodeDispensing(string strBarcodeNo, string strMaterialCode, string strBatchNo, string strType, string strUser, string strPlant)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_ValidateBarcodeDispensing(strBarcodeNo, strMaterialCode, strBatchNo, strType, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string BL_ValidateBalanceCode(string strBoothCode, string strBalanceCode, string strType, string strUser, string strPlant)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_ValidateBalanceCode(strBoothCode, strBalanceCode, strType, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable BL_PrintDispensingBarcode(string strBoothCode, string strBatchNo, string strMaterialCode,
                                                    string strIsseUom, string strMaterialBarcode, string strWeighingBalance,
                                                    decimal DGrossWt, decimal DTareWt, decimal DNetwt, string strProdBatch,
                                                    string strProcOrderNo, string strLotNo, int Count, string strUser, string strPlant, decimal RQTY)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_PrintDispensingBarcode(strBoothCode, strBatchNo, strMaterialCode,
                                                       strIsseUom, strMaterialBarcode, strWeighingBalance,
                                                       DGrossWt, DTareWt, DNetwt, strProdBatch, strProcOrderNo,
                                                       strLotNo, Count, strUser, strPlant, RQTY,"");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

    }
}

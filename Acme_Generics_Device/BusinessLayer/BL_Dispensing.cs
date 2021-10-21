using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataLayer;

namespace BusinessLayer
{
    public class BL_Dispensing
    {

        public DataTable BL_GetDispensingDtl(string strBatchNO, string strPlant)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_GetDispensingDtl(strBatchNO, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public DataTable BL_GetDispensingBatchDtl(string strBatchNO, string strPlant)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_GetDispensingBatchDtl(strBatchNO, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public DataTable BL_GetPrinterCode(string strBoothCode)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_GetPrinterCode(strBoothCode);
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
        public string BL_ValidatePicking(string strPickListNo, string Bin, string strMaterial, string strBatchNo, string strBarcodeNo, string strType, string strUser, string strPlant)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_ValidatePicking(strPickListNo,Bin, strMaterial,"0", strBatchNo, strBarcodeNo, strType,0.00, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string BL_GetLotNo(string strMatBatNo, string strMaterialCode, string strProBatNo, string strProcOrder, string strLot, string strPlant)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_GetLotNo(strMatBatNo, strMaterialCode, strProBatNo, strProcOrder, strLot, strPlant);
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

        public string BL_ValidateBulkBarcodeDispensing(string strBarcodeNo, string strMaterialCode, string strBatchNo, string strType, string strUser, string strPlant)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_ValidateBulkBarcodeDispensing(strBarcodeNo, strMaterialCode, strBatchNo, strType, strUser, strPlant);
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
                                                   string strProcOrderNo, string strLotNo,int Count,string strUser, string strPlant,decimal RQTY,string strLine)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_PrintDispensingBarcode(strBoothCode, strBatchNo, strMaterialCode,
                                                       strIsseUom, strMaterialBarcode, strWeighingBalance,
                                                       DGrossWt, DTareWt, DNetwt,strProdBatch,strProcOrderNo,
                                                       strLotNo, Count, strUser, strPlant, RQTY, strLine);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
        public DataTable BL_PrintDispensingBarcodeMulit(DataTable dt, string strBoothCode, string strBatchNo, string strMaterialCode, 
            string strIsseUom, string strWeighingBalance, string strProdBatch, string strProcOrderNo, string strLotNo, int Count, 
            string strUser, string strPlant, string strGWeight, string strTWeight,string strItemNo)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_PrintDispensingBarcodeMulti(dt,strBoothCode, strBatchNo, strMaterialCode,
                                                       strIsseUom, strWeighingBalance, strProdBatch, strProcOrderNo,
                                                       strLotNo, Count, strUser, strPlant,strGWeight,strTWeight,strItemNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
        public DataTable BL_PrintDispensingBarcodeBulk(DataTable dt, string strBoothCode, string strBatchNo, string strMaterialCode, string strIsseUom, string strWeighingBalance, string strProdBatch, string strProcOrderNo, string strLotNo, int Count, string strUser, string strPlant,string strLineNo)
        {
            DL_Dispensing objDL = new DL_Dispensing();
            try
            {
                return objDL.DL_PrintDispensingBarcodeBulk(dt, strBoothCode, strBatchNo, strMaterialCode,
                                                       strIsseUom, strWeighingBalance, strProdBatch, strProcOrderNo,
                                                       strLotNo, Count, strUser, strPlant, strLineNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class BL_GrnPrinting
    {
        public DataTable BL_GetDocumenDetails(string strDocumentNo,string strPrintType)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_GetDocumenDetails(strDocumentNo, strPrintType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetARDocumenDetails(string strDocumentNo, string strPrintType)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_GetARDocumenDetails(strDocumentNo, strPrintType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetGRNPrintedCount(string strDocumentNo, string strInwardNo)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_GetGRNPrintedCount(strDocumentNo, strInwardNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetStockDtl(string strDocumentNo, string strPlant)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_GetStockDtl(strDocumentNo, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

      

        public int BL_ResetARNo(string strBarCodeNo, string strOldARNo, string strNewARNo, string strPlant)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_ResetARNo(strBarCodeNo, strOldARNo, strNewARNo, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable BL_GetARNoDtl(string strDocumentNo, string strPlant)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_GetARNoDtl(strDocumentNo, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetDocumentNo(string strDocumentNo, string strPrintType)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_GetDocumentNo(strDocumentNo, strPrintType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetARDocumentNo(string strDocumentNo, string strPrintType)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_GetARDocumentNo(strDocumentNo, strPrintType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable BL_GetBarcodeNo(string strGRNno, string strLineItem, string strMatCode, string strQty,string strPackSize, string strPlantCode, string strUser,string strType,int iNoOfContainers,string srrMatBatch,string strReason)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_GetBarcodeNo(strGRNno, strLineItem, strMatCode, strQty, strPackSize, strPlantCode, strUser, strType, iNoOfContainers, srrMatBatch, strReason);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string BL_SaveArStock(string strBarcode, string strQty)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_SaveARStock(strBarcode,strQty);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public int BL_SaveGRNERPUpdate(string strDocumentNo, string strMatcode, string strArNo)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_SaveGRNERPPrint(strDocumentNo, strMatcode, strArNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public int BL_SaveGRNErpStock(string strDocumentNo,string strcount, string strArNo, double tQty)
        {
            DL_GrnPrinting objDL = new DL_GrnPrinting();
            try
            {
                return objDL.DL_SaveGRNErpStock(strDocumentNo, strcount, strArNo, tQty);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
       
    }
}

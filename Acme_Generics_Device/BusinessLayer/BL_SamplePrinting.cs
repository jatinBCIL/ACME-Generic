using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class BL_SamplePrinting
    {
        public DataTable BL_GetARDetails(string strARNo,string strType)
        {
            DL_SamplePrinting objDL = new DL_SamplePrinting();
            try
            {
                return objDL.DL_GetARDetails(strARNo, strType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetDisplayDetails(string strBarcode, string strPlant)
        {
            DL_SamplePrinting objDL = new DL_SamplePrinting();
            try
            {
                return objDL.DL_GetDisplayDetails(strBarcode, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable BL_GetSampleBarcodeNo(string strGRNno, string strLineItem, string strMatCode, string strQty, string strPackSize, string strPlantCode, string strUser, string strType)
        {
            DL_SamplePrinting objDL = new DL_SamplePrinting();
            try
            {
                return objDL.DL_GetSampleBarcodeNo(strGRNno, strLineItem, strMatCode, strQty, strPackSize, strPlantCode, strUser, strType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetBarcodeDetails(string strSampleBarcodeNo, string strMaterialBarcode, string strType, string strUser,string qty, string strCompQty, string strMLTQty, string strPlant,string strUOM)
        {
            DL_SamplePrinting objDL = new DL_SamplePrinting();
            try
            {
                return objDL.DL_GetBarcodeDetails(strSampleBarcodeNo, strMaterialBarcode, strType, strUser, qty, strCompQty, strMLTQty, strPlant, strUOM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string BL_ValidateSampBalance(string strSampleBalance, string strPlant)
        {
            DL_SamplePrinting objDL = new DL_SamplePrinting();
            try
            {
                return objDL.DL_ValidateSampBalance(strSampleBalance, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetPrinter(string strPrinter, string strPlant)
        {
            DL_SamplePrinting objDL = new DL_SamplePrinting();
            try
            {
                return objDL.DL_GetPrinter(strPrinter, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

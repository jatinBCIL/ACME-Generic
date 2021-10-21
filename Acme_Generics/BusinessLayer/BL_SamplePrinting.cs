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
        public DataTable BL_GetARNumber(string strARNo, string strType)
        {
            DL_SamplePrinting objDL = new DL_SamplePrinting();
            try
            {
                return objDL.DL_GetARNumber(strARNo, strType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable BL_GetSampleBarcodeNo(string strGRNno, string strLineItem, string strMatCode, string strQty, string strPackSize, string strPlantCode, string strUser, string strType,string strReason)
        {
            DL_SamplePrinting objDL = new DL_SamplePrinting();
            try
            {
                return objDL.DL_GetSampleBarcodeNo(strGRNno, strLineItem, strMatCode, strQty, strPackSize, strPlantCode, strUser, strType,strReason);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetBarcodeDetails(string strSampleBarcodeNo, string strMaterialBarcode, string strType, string strUser, string strPlant)
        {
            DL_SamplePrinting objDL = new DL_SamplePrinting();
            try
            {
                return objDL.DL_GetBarcodeDetails(strSampleBarcodeNo, strMaterialBarcode, strType, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;

namespace BusinessLayer
{
   public class BL_MRNLabel
    {
        public string BL_ValidateMRNBarcode(string strMaterialBarcode,string strPlantCode)
        {
            DL_MRNLabel objDl = new DL_MRNLabel();
            try
            {
                return objDl.DL_ValidateMRNBarcode(strMaterialBarcode, strPlantCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
            }
        }

        public string BL_SaveMRNBarcode(string strMaterialBarcode,string strUser, string strPlantCode)
        {
            DL_MRNLabel objDl = new DL_MRNLabel();
            try
            {
                return objDl.DL_SaveMRNBarcode(strMaterialBarcode, strUser ,strPlantCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objDl = null;
            }
        }

        public string BL_SaveMRNBarcode_ERP(string strMRNQty, string strPBatch, string strLine, string strType, string strARNo, string strMRNBacode, string strUser, string strPlantCode)
        {
            DL_MRNLabel objDl = new DL_MRNLabel();
            try
            {
                return objDl.DL_SaveMRNBarcode_ERP(strMRNQty,strPBatch,strLine,strType,strARNo,strMRNBacode,strUser,strPlantCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objDl = null;
            }
        }

    }
}

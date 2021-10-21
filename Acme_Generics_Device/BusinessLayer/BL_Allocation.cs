using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class BL_Allocation
    {

        public string BL_ValidateBin(string strRackCode, string strMaterialBarcode, string strType, string strUser, string strPlantCode)
        {
            DL_Allocation objDl = new DL_Allocation();
            try
            {
                return objDl.DL_ValidateBin(strRackCode, strMaterialBarcode, strType, strUser, strPlantCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
            }
        }

        public string BL_ValidateBin_LocationTransfer(string strFromCode, string strToCode, string strMaterialBarcode, string strType, string strUser, string strPlantCode)
        {
            DL_Allocation objDl = new DL_Allocation();
            try
            {
                return objDl.DL_ValidateBin_LocationTransfer(strFromCode, strToCode, strMaterialBarcode, strType, strUser, strPlantCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
            }
        }

        public DataTable BL_GetRackDetails(string strRack, string strPlant)
        {
            DL_Allocation objDl = new DL_Allocation();
            try
            {
                return objDl.DL_GetRackDetails(strRack, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
            }
        }

        //public DataTable BL_GetRackDetails(string strRack, string strPlant)
        //{
        //    DL_Allocation objDl = new DL_Allocation();
        //    try
        //    {
        //        return objDl.DL_GetRackDetails(strRack, strPlant);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //}
    }
}

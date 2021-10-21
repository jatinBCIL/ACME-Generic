using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataLayer;

namespace BusinessLayer
{
    public class BL_PickList
    {


        public string BL_GeneratePicklist(DataTable dt_Temp, string strUser, string strPlant)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GeneratePicklist(dt_Temp, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
        public string BL_StockAdjust(string strBarcode, string strAdQty, string strType, string strUser, string strPlant)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_StockAdjust(strBarcode, strAdQty, strType, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public string BL_ValidateReversePicking(string strBarcode, string strBin, string strType, string strUser, string strPlant)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_ValidateReversePicking(strBarcode, strBin, strType, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }


        public DataTable BL_GetForReversePicking(string strBatchNO, string strPlant)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetForReversePicking(strBatchNO, strPlant);
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
        public DataTable BL_GetPicklistMat(string strPickListNo, string strUser, string strPlant)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetPicklistMat(strPickListNo, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public string BL_ValidatePicking(string strPickListNo, string strBin, string strMaterial, string strProcOrder, string strBatchNo, string strBarcodeNo, string strType, double Rqty, string strUser, string strPlant)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_ValidatePicking(strPickListNo,strBin, strMaterial,strProcOrder, strBatchNo, strBarcodeNo, strType,Rqty, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable BL_GetPicklist(string strPickListNo, string strPlant)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetPicklistNo(strPickListNo, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

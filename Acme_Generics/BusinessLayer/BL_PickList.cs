using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class BL_PickList
    {

        public DataTable DL_GetBatchDetails(string strFromDate, string strToDate, string strBatchNo, string strType)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetBatchDetails(strFromDate, strToDate, strBatchNo, strType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string BL_UpdateERPData(string strBatchNo, string lineNo, string ARNo)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_SaveERPBatch(strBatchNo, lineNo, ARNo).ToString(); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public string BL_UpdateERPData( string strBatchNo)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_SaveERPBatch(strBatchNo).ToString(); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
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

        public DataTable BL_RefreshPicklist(string strBatchNo, string strType, string strPlant)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_RefreshPicklist(strBatchNo, strType, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetDspensingConfirmation(string strBatchNo, string strType, string strPlant)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetDspensingConfirmation(strBatchNo, strType, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public string BL_ConfirmPicking_Dispensing(string strBatchNo, string strProdCode, string strProdBatch, string strProcessOrderNo,string strLineItem, string strUser, string strPlant)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_ConfirmPicking_Dispensing(strBatchNo, strProdCode, strProdBatch, strProcessOrderNo,strLineItem, strUser, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }


        public int BL_ConfirmPicking_Dispensing_ERP(string strBatchNo, string strProdCode, string strProdBatch, string strProcessOrderNo, string strLineItem, string strUser, string strPlant,string strQty)
        {
            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_ConfirmPicking_Dispensing_ERP(strBatchNo, strProdCode, strProdBatch, strProcessOrderNo, strLineItem, strUser, strPlant,strQty);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public DataTable BL_GetMRNReprint(string strPBath)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetMRNReprint(strPBath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetProcessOrderReprinting(string strProcessOrderNo,string strReason,string strUser, string strType, string strPlant)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetProcessOrderReprinting(strProcessOrderNo,strReason,strUser, strType, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable BL_GetDispHeaderData(string strProcessOrderNo, string strReason, string strUser, string strType, string strPlant)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetDispHeaderData(strProcessOrderNo, strReason, strUser, strType, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

       public DataTable BL_GetLocSheetData(string strARNo, string strBlock, string strUser, string strPlant, string strArea, int Mattype )
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetLocSheetData(strARNo, strBlock, strUser, strPlant, Mattype, strArea);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
       public DataTable BL_GetARNoLocDtl(string strARNo, string strPlantcode,int MatType)
       {

           DL_PickList objDL = new DL_PickList();
           try
           {
               return objDL.DL_GetARNoLocDtl(strARNo, strPlantcode, MatType);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }

        public DataTable BL_GetDispensingSheetData(string strProcessOrderNo, string strReason, string strUser, string strType, string strPlant)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetDispensingSheetData(strProcessOrderNo, strReason, strUser, strType, strPlant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable BL_GetProcessOrderReprintNo(string strProcessOrderNo)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetProcessOrderReprintNo(strProcessOrderNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetMRNBatchNo(string strProcessOrderNo)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetMRNBatchNo(strProcessOrderNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetARNoDtl(string strARNo, string strPlantcode)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetARNoDtl(strARNo,strPlantcode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetBlock(string strBlock, string strPlantcode)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetBlockName(strBlock, strPlantcode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetArea(string strArea, string strPlantcode)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetAreaName(strArea, strPlantcode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable BL_GetLocDtl(string strLoc, int type, string strARNo, string strPlantcode)
        {

            DL_PickList objDL = new DL_PickList();
            try
            {
                return objDL.DL_GetLocDtl(strLoc, type, strARNo, strPlantcode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

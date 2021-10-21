using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
   public class BL_MRNLabel
   {
       public DataTable BL_GetMRNDetails(string strPre,string strPlant)
       {
           DL_MRNLabel objDL = new DL_MRNLabel();
           try
           {
               return objDL.DL_GetMRNDetails(strPre,strPlant);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }

       public DataTable BL_GetMRNData(string strPre, string strPlant)
       {
           DL_MRNLabel objDL = new DL_MRNLabel();
           try
           {
               return objDL.DL_GetMRNData(strPre, strPlant);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }

       public DataTable BL_GetMRNData(string strPre,string strProdCode, string strPlant)
       {
           DL_MRNLabel objDL = new DL_MRNLabel();
           try
           {
               return objDL.DL_GetMRNData(strPre,strProdCode, strPlant);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }

       public DataTable BL_GetMRNBarcodeNo(string strARNo, string strContQty, string strMatCode, string strTWeight, string strNWeight, string strGWeight, string strUser,string strPBatch,string strPName,string strPLineItem)
       {
           DL_MRNLabel objDL = new DL_MRNLabel();
           try
           {
               return objDL.DL_GetMRNBarcodeNo(strARNo, strContQty, strMatCode, strUser, strTWeight, strNWeight, strGWeight, strPBatch, strPName, strPLineItem);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }

       public DataTable BL_GetReprintMRNBarcodeNo(string strBarcode, string strReason, string strUser)
       {
           DL_MRNLabel objDL = new DL_MRNLabel();
           try
           {
               return objDL.DL_GetReprintMRNBarcodeNo(strBarcode,strReason,strUser);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
   }
}

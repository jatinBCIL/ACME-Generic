using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyLayer
{
   public class PLAPI_InProcLabelPrinting
    {

        /// <summary>
        /// Ref No : API03
        /// Purpose : In Process Label,In Process By Product Label Printing 
        /// Created By : Sayali A Palav.
        /// Created On : 12 Sept 2016.
        /// Modified By : 
        /// Modified On : 
        /// Comment : Property Layer functions of In Process Label,In Process By Product Label Printing Module
        /// </summary>
        ///

        public string strPlantCode { get; set; }
        public string strBarcode { get; set; }
        public string strWeightID { get; set; }
        public decimal dTareWt { get; set; }
        public decimal dNetWt { get; set; }
        public decimal dGrossWt { get; set; }
        public string strReason { get; set; }
        public string strProcess { get; set; }
        public string strPONum { get; set; }
        public Boolean isLastLot { get; set; }
        public string strProdOpt { get; set; }
        public string strProdOptDesc { get; set; }
        public string strProdNxtOpt { get; set; }
        public string strProdNxtOptDesc { get; set; }
        public string strProdLot { get; set; }
        public string strUsername { get; set; }
        public string strMatCode { get; set; }
        public int iQty { get; set; }

        
        public string strGRNo { get; set; }
        public string strProdCode { get; set; }
        public string strMatBatch { get; set; }
        public string strprodBatch { get; set; }
        public decimal dQty { get; set; }
        public string strUom { get; set; }

        public string strAnalysis_Matcode { get; set; }
        public string strMfgMatcode { get; set; }
        public string dtpMfgDate { get; set; }
        public string strPurpose { get; set; }
        public string strRemark { get; set; }
        public string strBatchType { get; set; }
        public string strLabelType { get; set; }

        
    }
}

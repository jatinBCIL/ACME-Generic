using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyLayer
{
   public class PLStore_LabelPrinting
    {
        /// Ref No : MM1,MM18
        /// Purpose : receipt label printing & Re-printing.
        /// Created By : Sayali A Palav.
        /// Created On : 26 July 2016.
        /// Modified By : 
        /// Modified On : 06 Sept 2016
        /// Comment : Properites of receipt label printing & Re-printing module


        public string strPlantCode { get; set; }
        public string strBarcode { get; set; }
        public string strReason { get; set; }
        public string strGRN { get; set; }
        public string strLineItem { get; set; }
        public string strUsername { get; set; }
        public string strMatCode { get; set; }
        public decimal iQty { get; set; }
        
    }
}

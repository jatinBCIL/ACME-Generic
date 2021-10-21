using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyLayer
{
   public  class PLStore_LabelRegulation
    {
          /// Ref No : MM1,MM18
        /// Purpose : receipt label printing & Re-printing.
        /// Created By : Shubhangi Thange
        /// Created On : 12 Sept 2016.
        /// Modified By : 
        /// Modified On : 
        /// Comment : Properites of receipt label Regulation.


        public string strPlantCode { get; set; }
        public string strBarcode { get; set; }
        public string strReason { get; set; }
        public decimal iNoOfContainer {get; set;}
        public string strGRN { get; set; }
        public string strLineItem { get; set; }
        public string strUsername { get; set; }
        public string strMatCode { get; set; }
        public string strPrinter { get; set; }
        public decimal iQty { get; set; }

        public decimal DTotCont { get; set; }
        
    }
 }


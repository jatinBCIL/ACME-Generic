using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyLayer
{
    /// <summary>
    /// Ref No : pp05
    /// Purpose : Code To Code Transfer
    /// Created By : Sayali A Palav.
    /// Created On : 05 Nov 2016.
    /// Modified By : 
    /// Modified On : 
    /// Comment : Property functions of Code To Code Transfer
    /// </summary>
    ///

    public class PL_For_CodeToCode
    {
        public string strPlantCode { get; set; }
        public string strBarcode { get; set; }
        public string strWeightID { get; set; }
        public decimal dTareWt { get; set; }
        public decimal dNetWt { get; set; }
        public decimal dGrossWt { get; set; }
        public string strReason { get; set; }
        public string strProcess { get; set; }
        public string strUsername { get; set; }
        public string strMatDocNo { get; set; }
        public string strCTCType { get; set; }
    }
}

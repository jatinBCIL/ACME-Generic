using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : Part Master Transaction
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 02 Aug 2016
/// Comment : Properites of Part Master module
/// </summary>


namespace PropertyLayer
{
    public class PL_PartMaster
    {
        public string strPlantCode { get; set; }
        public string strPartNo { get; set; }
        public string strPartDesc { get; set; }
        public string strUsername { get; set; }
        public string strMODE { get; set; }
        public int intStatus { get; set; }
        public int REFNO { get; set; }
        public string strRemark { get; set; }
    }
}

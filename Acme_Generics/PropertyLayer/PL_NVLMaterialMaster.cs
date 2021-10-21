using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : NVL Material Master Transactions
/// Created By :
/// Created On :
/// Modified By : Mayur Morye
/// Modified On : 04 Aug 2016
/// Comment : Properites of NVL Material Master module
/// </summary>


namespace PropertyLayer
{
    public class PL_NVLMaterialMaster
    {
        public string strPlantCode { get; set; }
        public string strMaterialCode { get; set; }
        public string strMaterialType { get; set; }
        public string strUsername { get; set; }
        public string strMODE { get; set; }
        public int intStatus { get; set; }
        public int REFNO { get; set; }
        public string strRemark { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : Final Operation Master
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 05 Aug 2016
/// Comment : Properites of Operation Master module
/// </summary>

namespace PropertyLayer
{
    public class PL_FinalOperationMaster
    {
        public string strPlantCode { get; set; }
        public string strDescription { get; set; }
        public string strUsername { get; set; }
        public string strMODE { get; set; }
        public int intStatus { get; set; }
        public int REFNO { get; set; }
        public string strRemark { get; set; }
    }
}

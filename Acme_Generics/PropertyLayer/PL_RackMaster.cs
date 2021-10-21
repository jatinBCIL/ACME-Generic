using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : Rack Master Transaction
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 02 Aug 2016
/// Comment : Properites of Rack Master module
/// </summary>

namespace PropertyLayer
{
   public class PL_RackMaster
    {
        public string strPlantCode { get; set; }
        public string strCubicleCode { get; set; }
        public string strRackCode { get; set; }
        public string strShelfCode { get; set; }
        public string strCreatedBy { get; set; }
        public string strModifyBy { get; set; }
        public string strFlag { get; set; }
        public int REFNO { get; set; }
        public int iSt { get; set; }
        public string strRemark { get; set; } 
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : Reason And Reason Category Master Transaction
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 29 July 2016
/// Comment : Properites of Reason And Reason Category Master module
/// </summary>


namespace PropertyLayer
{
    public class PL_ReasonMaster
    {
        
        public string strPlantCode { get; set; }
        public string strResCat { get; set; }
        public string strResCode { get; set; }
        public string strModule { get; set; }
        public string strResDesc { get; set; }
        public string strCreatedBy { get; set; }
        public string strModifyBy { get; set; }
        public string strFlag { get; set; }
        public int REFNO { get; set; }
        public int iSt { get; set; }
        public string strRemark1 { get; set; }
        public string strRemark2 { get; set; }
    }
}

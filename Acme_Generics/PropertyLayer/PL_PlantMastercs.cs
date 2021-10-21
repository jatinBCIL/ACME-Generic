using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    /// <summary>
    /// Ref No : 
    /// Purpose : Transactions of Plant Master
    /// Created By : 
    /// Created On : 
    /// Modified By : Mayur Morye
    /// Modified On : 29 July 2016.
    /// Comment : Properites of Plant Master module
    /// </summary>


namespace PropertyLayer
{
    public class PL_PlantMastercs
    {
        public string strLoc { get; set; }
        public string strPlantCode { get; set; }
        public string strPlantDesc { get; set; }
        public string strAscPlant { get; set; }
        public string strAscPlantDesc { get; set; }
        public string strAddress { get; set; }
        public int strHoldDays { get; set; }
        public string strPlantType { get; set; }
        public string strCreatedBy { get; set; }
        public string strModifyBy { get; set; }
        public string strFlag { get; set; }
        public int REFNO { get; set; }
        public int iSt { get; set; }
        public string strRemark { get; set; }


        public string strAddress1 { get; set; }
        public string strAddress2 { get; set;  }
        public string strAddress3 { get; set; }
        public string strAddress4 { get; set; }
        public string strState { set; get; }
        public string strCity { set; get; }
        public string strPincode { set; get; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : Lot Master Transaction
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 01 Aug 2016
/// Comment : Properites of Lot Master module
/// </summary>


namespace PropertyLayer
{
    public class PL_LotMaster
    {
        public string strPlantCode { get; set; }
        public string strLotNo { get; set; }
        public string strUsername { get; set; }
        public string strMODE { get; set; }
        public int intStatus { get; set; }
        public int REFNO { get; set; }
        public string strRemark { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : BulkHoldPeriodsMaterialMaster
/// Created By : 
/// Created On : 
/// Modified By : Sachin Bali
/// Modified On : 11-08-2016
/// Comment : Data Layer of BulkHoldPeriodsMaterialMaster
/// </summary>


namespace PropertyLayer
{
    public class PL_BulkHoldPeriodsMaterial
    {

        public string strPlantCode { get; set; }
        public string strMaterilCode { get; set; }
        public int StatusCode { get; set; }
        public string strRemark { get; set; }
        public string strUsername { get; set; }
        public string strModifiedBy { get; set; }
        public string strCreatedBy { get; set; }
        public int bulkholdperiod { get; set; }
        public string strBULK_HOLD_PERIOD_UNIT { get; set; }
        public string strCreatedOn { get; set; }
        public string strFlag { get; set; }
        

    }
}

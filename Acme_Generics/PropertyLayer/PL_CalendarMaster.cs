using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : Clendar Master Transactions
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 04 Aug 2016
/// Comment : Properites of Calendar Master module
/// </summary>


namespace PropertyLayer
{
    public class PL_CalendarMaster
    {
        public string strPlantCode { get; set; }
        public string Date { get; set; }
        public string strType { get; set; }
        public string strCreatedBy { get; set; }
        public string strModifyBy { get; set; }
        public string strFlag { get; set; }
        public int REFNO { get; set; }
        public int iSt { get; set; }
        public string strRemark { get; set; }
    }
}

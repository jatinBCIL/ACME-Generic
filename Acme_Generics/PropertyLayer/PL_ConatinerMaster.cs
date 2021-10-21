using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyLayer
{
    public class PL_ConatinerMaster
    {
        public string strPlantCode { get; set; }
        public string strContNo { get; set; }
        public string strContDesc { get; set; }
        public decimal dTareWt { get; set; }
        public string strTareUnit { get; set; }
        public string strHoldDayForClen { get; set; }
        public string strHoldDayTobeClen { get; set; }
        public string strHoldUnit { get; set; }
        public string strUsername { get; set; }
        public string strMODE { get; set; }
        public int intStatus { get; set; }
        public int REFNO { get; set; }
        public string strRemark { get; set; }
        public string strSOPNo { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyLayer
{
   public class PL_LabelMaster
    {
        public string strPlantCode { get; set; }
        public string strLabelType { get; set; }
        public string strPlantType { get; set; }
        public string strCreatedBy { get; set; }
        public string strModifyBy { get; set; }
        public string strFlag { get; set; }
        public int REFNO { get; set; }
        public int iSt { get; set; }
        public string strRemark { set; get; }
    }
}

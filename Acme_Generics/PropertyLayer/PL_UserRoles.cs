using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyLayer
{
    public class PL_UserRoles
    {
        public string strRole { get; set; }
        public string strUserType { get; set; }
        public string strTransType { get; set; }
        public string strRight { get; set; }
        public string strMODE { get; set; }
        public int REFNO { get; set; }

        public int intStatus { get; set; }
        public string strCreatedBy { get; set; }
    }
}

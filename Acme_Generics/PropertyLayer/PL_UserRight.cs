using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyLayer
{
    public class PL_UserRight
    {
        public string strUserID { get; set; }
        public string strT_PlantID { get; set; }
        public string strT_Department { get; set; }
        public string strT_Roles { get; set; }
        public string DT_T_ACCESSUPTO { get; set; }
        public string strD_PlantID { get; set; }
        public string strD_Department { get; set; }
        public string strD_Roles { get; set; }
        public string DT_D_ACCESSUPTO { get; set; }
        public int REFNO { get; set; }
        public int intStatus { get; set; }
        public string strCreatedBy { get; set; }
        public string strMethod { get; set; }
    }
}

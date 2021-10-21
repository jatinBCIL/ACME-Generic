using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyLayer
{
    public class PL_Username
    {
        public static int iExpiry = 0;

        public string strUserID { get; set; }
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public string strModule { get; set; }
        public string strDepartment { get; set; }
        public string strUsername { get; set; }
        public string strPassword { get; set; }
        public int REFNO { get; set; }
        public string strPlantCode { get; set; }
        public string strEmpCode { get; set; }
        public string strEmailID { get; set; }
        public string strUserType { get; set; }
        public string strRemarks { get; set; }
        public string strMethod { get; set; }

        public string strRights { get; set; }
        public int intStatus { get; set; }
        public string strCreatedBy { get; set; }
    }
}

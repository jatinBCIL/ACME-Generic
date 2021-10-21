using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : Transaction Against Department
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 29 July 2016
/// Comment : Property Layer of Department Master Module
/// </summary>


namespace PropertyLayer
{
    public class PL_DepartmentMaster
    {
        public string strPlantCode { get; set; }
        public string strDeptCode { get; set; }
        public string strDeptDesc { get; set; }
        public string strUsername { get; set; }
        public string strMODE { get; set; }
        public int intStatus { get; set; }
        public int REFNO { get; set; }
        public string strRemark { get; set; }
    }
}

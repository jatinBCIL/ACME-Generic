using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : Printer Master Transaction
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 29 July 2016
/// Comment : Properites of Printer Master module
/// </summary>


namespace PropertyLayer
{
    public class PL_PrinterMaster
    {
        public string strPlantCode { get; set; }
        public string strPrinterCode { get; set; }
        public string strPrinterIp { get; set; }
        public int strPrinterPort { get; set; }
        public string strArea { get; set; }
        public string strBoothCode { get; set; }
        public string strCreatedBy { get; set; }
        public string strModifyBy { get; set; }
        public string strFlag { get; set; }
        public int REFNO { get; set; }
        public int iSt { get; set; }
        public string strRemark { get; set; }
        public string strDeptCode { get; set; }
        public string strDeptDesc { get; set; }
    }
}

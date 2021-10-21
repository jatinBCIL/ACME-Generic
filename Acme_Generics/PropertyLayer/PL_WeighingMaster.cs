using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyLayer
{

    /// <summary>
    /// Ref No : Process ID MT2
    /// Purpose : (Stores) Empty Bin.
    /// Created By : Rohan Sukre.
    /// Created On : 06 Sep 2016.
    /// Modified By : 
    /// Modified On :
    /// Comment : Properties of Weighing Master
    /// </summary>


    public class PL_WeighingMaster
    {
        public string strPlantCode { get; set; }
        public string strWeighingCode { get; set; }
        public string strWeighingIP { get; set; }
        public string strPort { get; set; }
        public decimal DScaleCapacity { get; set; }
        public decimal ILeastCount { get; set; }
        public decimal DMinValue { get; set; }
        public decimal DMaxValue { get; set; }
        public string strBooth { get; set; }
        public int IStatus { get; set; }
        public string strUser { get; set; }
        public string strPlant { get; set; }
        public string strMode { get; set; }
        public string strRemark { get; set; }
        public int REFNO { get; set; }
    }
}

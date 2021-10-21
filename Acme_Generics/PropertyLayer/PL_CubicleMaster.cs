using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : Cubicle Master Transactions
/// Created By : 
/// Created On : 
/// Modified By : Mayur Morye
/// Modified On : 29 July 2016
/// Comment : Properites of Cubicle label Master
/// </summary>


namespace PropertyLayer
{
    public class PL_CubicleMaster
    {
        #region Cubicle Master API

        public string strPlantCode { get; set; }
        public string strDepartDesc { get; set; }
        public string strCubicleCode { get; set; }
        public string strCubicleDesc { get; set; }
        public int IHoldPeriodClean { get; set; }
        public string strHoldPeriodClean { get; set; }
        public int IHoldPeriondToBeClean { get; set; }
        public string strToBeHoldPeriod { get; set; }
        public string strCreatedBy { get; set; }
        public string strModifyBy { get; set; }
        public string strFlag { get; set; }
        public int REFNO { get; set; }
        public int iSt { get; set; }
        public string strRemark { get; set; }
        public string strDept { get; set; }
        public string strSOPNo { get; set; }

        #endregion 

        #region Cubicle Master MM

        public string strPlantCodeMM { get; set; }
        public string strCubicleCodeMM { get; set; }
        public string strCubicleDescMM { get; set; }
        public string strRoomNoMM { get; set; }
        public string strAreaMM { get; set; }
        public string strDepartMentMM { get; set; }
        public string strEquipmentMM { get; set; }
        public string strCodeMM  { get; set; }
        public string strCleaningMM { get; set; }
        public string strCreatedByMM { get; set; }
        public string strModifyByMM { get; set; }
        public string strFlagMM { get; set; }
        public int REFNOMM { get; set; }
        public int iStMM { get; set; }

        #endregion

        #region Cubicle Equipment MM

        public string strEquip_NO { get; set; }
        public string strCode_NO { get; set; }
        public string strCleaningSOP_NO { get; set; }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Ref No : 
/// Purpose : EquipmentAccessories
/// Created By : 
/// Created On : 17-08-2016
/// Modified By : Sachin Bali
/// Modified On : 
/// Comment : PropertyLayer For Equip And Access Master
/// </summary>

namespace PropertyLayer
{
    public class PL_EquipAndAccessMaster
    {
        public string plant_code { get; set; }
        public string equip_access_code { get; set; }
        public string equip_access_desc { get; set; }
        public string department_code { get; set; }
        public string equip_type { get; set; }
        public string cubicle_area { get; set; }
        public string remark { get; set; }
        public int status { get; set; }
        public string user { get; set; }
        public string mod { get; set; }
        public string strSopNo { get; set; }
        public string strPortType { get; set; }
    }
}

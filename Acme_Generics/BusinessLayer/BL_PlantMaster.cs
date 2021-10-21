using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using PropertyLayer;
using System.Data;

/// <summary>
/// Ref No : 
/// Purpose : Transactions of Plant Master
/// Created By :
/// Created On :
/// Modified By : Mayur Morye
/// Modified On : 29 July 2016.
/// Comment : BusinessLayer functions Plant Master module
/// </summary>


namespace BusinessLayer
{
    public class BL_PlantMaster
    {
        DL_PlantMaster objPlant = new DL_PlantMaster();

        //Insert and Update Data of Plant
        public DataTable BL_Get_Plant_with_Desc()
        {
            DataTable dtPlantCode;
            dtPlantCode = objPlant.DL_getPlantCode_Desc();
            return dtPlantCode;

        }

        public DataTable BL_getAsc_Desc()
        {
            DataTable dtPlantCode;
            dtPlantCode = objPlant.DL_getAsc_Desc();
            return dtPlantCode;

        }

        public string BL_InsertPlant(PL_PlantMastercs obj)
        {
            string strResult = "";
            strResult = objPlant.DL_InsertPlant(obj);
            return strResult;

        }

        //Fetch Plant Code from Data
        public DataTable BL_Get_Plant(string strPlant)
        {
            DataTable dtPlantCode;
            dtPlantCode = objPlant.DL_getPlantCode(strPlant);
            return dtPlantCode;
        }


        //Fetch Data of Plant
        public DataTable BL_GetPlantDtl(string strWhere)
        {
            DataTable dt = new DataTable();
            string strResult = "";
            dt = objPlant.DL_getPlantDtl(strWhere);
            return dt;

        }

        public DataTable BL_GetPlantDtl_Master(string strWhere)
        {
            DataTable dt = new DataTable();
            string strResult = "";
            dt = objPlant.DL_getPlantDtl_Master(strWhere);
            return dt;

        }

        //Fetch Plant Code from Data
        //public DataTable BL_Get_Plant(string strPlant)
        //{
        //    DataTable dtPlantCode;
        //    dtPlantCode = objPlant.DL_getPlantCode(strPlant);
        //    return dtPlantCode;
        //}

        public DataTable BL_Get_Plant_Recipe()
        {
            DataTable dtPlantCode;
            dtPlantCode = objPlant.DL_Get_Plant_Recipe();
            return dtPlantCode;

        }



        //Fetch Plant Type from Data
        public DataTable BL_Get_Plant_Type()
        {
            DataTable dtPlantCode;
            dtPlantCode = objPlant.DL_Get_Plant_Type();
            return dtPlantCode;

        }

    }
}

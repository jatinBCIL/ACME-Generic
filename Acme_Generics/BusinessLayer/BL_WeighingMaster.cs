using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataLayer;
using PropertyLayer;

namespace BusinessLayer
{
    /// Ref No : Process ID MT2
    /// Purpose : Weighing Master.
    /// Created By : Rohan Sukre.
    /// Created On : 06 Sep 2016.
    /// Modified By : 
    /// Modified On :
    /// Comment : BusinessLayer functions of Weighing Master
    /// </summary>


    public class BL_WeighingMaster
    {
        DL_WeighingMaster objWeigh = new DL_WeighingMaster();

        public DataTable BL_GetPlantCode(PL_WeighingMaster obj)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = objWeigh.DL_GetPlantCode(obj);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }


        }

        //fetching area code against plantcode
    
     

       
      

        public string BL_InsertWeighingMaster(PL_WeighingMaster obj)
        {
            string strResult = "";
            try
            {
                strResult = objWeigh.DL_InsertWeighing(obj);
                return strResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
            }

        }
        public DataTable BL_GetWeighingDisplayData(string strWhere)
        {
            DL_WeighingMaster _DataLayer = new DL_WeighingMaster();
            try
            {
                return _DataLayer.DL_GetWeighingDisplayData(strWhere);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                _DataLayer = null;
            }
        }

     

     
    }
}

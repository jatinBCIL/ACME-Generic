using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;


namespace BusinessLayer
{
    public class BL_Chnage
    {


        // cubicle //area master
        public string Bl_get_strPlant_desc(string strplantcode)
        {
            DL_Change objChange = new DL_Change();
            try {

                string strResult=objChange.Dl_get_strPlant_desc(strplantcode);
                return strResult;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
        }

        public string Bl_get_strDept_desc(string strDepartment)
        {
            DL_Change objChange = new DL_Change();
            try
            {

                string strResult = objChange.Dl_get_strDepartment_desc(strDepartment);
                return strResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public string Bl_get_strArea_desc(string strAreaCode)
        {

            DL_Change objChange = new DL_Change();
            try
            {

                string strResult = objChange.Dl_get_strAreae_desc(strAreaCode);
                return strResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public string Bl_get_strCubicle_desc(string strcubiclecode)
        {

            DL_Change objChange = new DL_Change();
            try
            {

                string strResult = objChange.Dl_get_strCubicle_desc(strcubiclecode);
                return strResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }


    


       
    }
}

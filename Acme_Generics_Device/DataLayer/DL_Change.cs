using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PropertyLayer;
using DataLayer;

namespace DataLayer
{
    public class DL_Change
    {

        //plant
        public string Dl_get_strPlant_desc(string strplantcode)
        {
            SqlDataLayer objsql = new SqlDataLayer();
            try {

                string strq = "SELECT DISTINCT (PLANTCODE+'-'+PLANTDESC ) AS PLANTCODE FROM [vw_PLANTMASTER] where PLANTCODE='"+strplantcode+"'";
                string strResult = objsql.ExecuteScalarString(objsql.strLocal,strq);
                return strResult;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                objsql = null
                    ;
            }
        }

        //desc
        public string Dl_get_strDepartment_desc(string strDepartment)
        {
            SqlDataLayer objsql = new SqlDataLayer();
            try
            {

                string strq = "SELECT distinct (DepartmentCode+'-'+DepartmentDesc)FROM [dbo].[VW_DEPARTMENT] where DepartmentCode='" + strDepartment + "'";
                string strResult = objsql.ExecuteScalarString(objsql.strLocal, strq);
                return strResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objsql = null
                    ;
            }
        }

        //cubicle/area
        public string Dl_get_strCubicle_desc(string strcubiclecode)
        {
            SqlDataLayer objsql = new SqlDataLayer();
            try
            {

                string strq = "SELECT  DISTINCT (CUBICLE_ID+'-'+CUBICLE_DESC) AS CUBICLECODE FROM VW_TBLCUBICLEMM WHERE  CUBICLE_ID='" + strcubiclecode + "'";
                string strResult = objsql.ExecuteScalarString(objsql.strLocal, strq);
                return strResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objsql = null
                    ;
            }
        }

        //area
        public string Dl_get_strAreae_desc(string strAreaCode)
        {
            SqlDataLayer objsql = new SqlDataLayer();
            try
            {

                string strq = "SELECT  DISTINCT ([AREA_CODE]+'-'+[AREA_DESC]) AS [VW_TBLCUBICLEMM] FROM [VW_AREAMASTER] WHERE  AREA_CODE='" + strAreaCode + "'";
                string strResult = objsql.ExecuteScalarString(objsql.strLocal, strq);
                return strResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objsql = null
                    ;
            }
        }


    }
}

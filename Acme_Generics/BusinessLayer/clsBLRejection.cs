using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsBLRejection
    {
        public DataTable getPlants(string strWhere)
        {
            clsDLRejection _DataLayer = new clsDLRejection();
            try
            {
                return _DataLayer.GetPlants(strWhere.Trim());
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
        public DataTable GetLineType(string strWhere)
        {
            clsDLRejection _DataLayer = new clsDLRejection();
            try
            {
                return _DataLayer.GetLineType(strWhere.Trim());
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

        public DataTable GetPlantUsers(string strWhere)
        {
            clsDLRejection _DataLayer = new clsDLRejection();
            try
            {
                return _DataLayer.GetPlantsUsers(strWhere.Trim());
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

        public DataTable getBatch(string strWhere)
        {
            clsDLRejection _DataLayer = new clsDLRejection();
            try
            {
                return _DataLayer.GetBatch(strWhere.Trim());
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

        public static string GetUserType(string strWhere)
        {
            clsDLRejection _DataLayer = new clsDLRejection();
            try
            {
                return _DataLayer.GetUserType(strWhere.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                
            }
        }



        public DataTable GetRejectionData(string strWhere,string Plant)
        {
            clsDLRejection _DataLayer = new clsDLRejection();
            try
            {
                return _DataLayer.GetRejectionData(strWhere.Trim(),Plant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {

            }
        }
        public DataTable GetSNRejectionData(string [] strField,string[] strWhere)
        {
            clsDLRejection _DataLayer = new clsDLRejection();
            try
            {
                return _DataLayer.GetSNRejectionData(strField,strWhere);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {

            }
        }

        public int RejectData(string strWhere)
        {
            clsDLRejection _DataLayer = new clsDLRejection();
            try
            {
                return _DataLayer.RejectData(strWhere.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {

            }

        }


        public string RejectSNData(string strWhere,string Type)
        {
            clsDLRejection _DataLayer = new clsDLRejection();
            try
            {
                return _DataLayer.RejectSNData(strWhere.Trim(),Type);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {

            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PropertyLayer;
using DataLayer;

namespace BusinessLayer
{
    public class BL_UserMaster
    {
        public DataTable getUsers(string strWhere)
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.GetUsers(strWhere.Trim());
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

        public DataTable BL_GetUserID()
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.DL_GetUserID();
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

        public DataTable getPlant(string strWhere)
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.GetPlant(strWhere.Trim());
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

        public string BL_Save_Users(PL_Username objFields)
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.DL_Save_UserMaster(objFields);
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

        public DataTable BL_getModules()
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.getModules();
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

        public string BL_getRights(string strUserId)
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.getRights(strUserId);
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

     

        #region "User Roles"

        public DataTable BL_GetUserRoles(string strWhere)
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.DL_GetUserRoles(strWhere);
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

       

        #endregion

    }
}


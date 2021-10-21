using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PropertyLayer;
using DataLayer;

namespace BusinessLayer
{
    public class BL_BinMaster
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

        public DataTable GetBinDisplayData(string strWhere)
        {
            DL_BinMaster _DataLayer = new DL_BinMaster();
            try
            {
                return _DataLayer.DL_GetBinDisplayData(strWhere.Trim());
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
        public DataTable BL_CheckUserID(string strUserId)
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.DL_CheckUserID(strUserId);
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
        public DataTable getModule(string strWhere)
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.GetModule(strWhere.Trim());
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

       

        public string BL_Save_Bin(PL_BinMaster objFields)
        {
            DL_BinMaster _DataLayer = new DL_BinMaster();
            try
            {
                return _DataLayer.DL_Save_BinMaster(objFields);
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

        public string BL_Save_UserRights(PL_UserRight objFields)
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.DL_Save_UserRights(objFields);
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

        public string BL_InsertUserRoles(PL_UserRoles obj)
        {
            DL_UserMaster objMaster = new DL_UserMaster();
            try
            {
                string strResult = "";
                strResult = objMaster.DL_InsertUserRoles(obj);
                return strResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMaster = null;
            }
        }

        #endregion

        public DataSet BL_GetuserRols(string strPlant)
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.DL_GetuserRols(strPlant);
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

        public DataTable BL_GetExistingRoles(string strUserName)
        {
            DL_UserMaster _DataLayer = new DL_UserMaster();
            try
            {
                return _DataLayer.DL_GetExistingRoles(strUserName);
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


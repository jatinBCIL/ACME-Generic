using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;
using DataLayer;
using PropertyLayer;
using System.Web.UI;
using System.Web.UI.WebControls;


public class clsBLCommon
{
    #region "Login, ChangePassword, User existance"

    public string Login(string strUsername, string strPassword, string strPlant,string strType)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.Login(strUsername.Trim(), strPassword.Trim(), strPlant.Trim(), strType);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public string DeviceLogin(string strUsername, string strPassword)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.DeviceLogin (strUsername.Trim(), strPassword.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }


    public string ChangePassword(string strUsername, string strOldPassword, string strNewPassword)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.ChangePassword(strUsername.Trim(), strOldPassword.Trim(), strNewPassword.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public static Boolean ChangeMobileNumber(string strUser, string strMobile)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.ChangeMobileNumber(strUser, strMobile);
        }
        catch
        {
            return false;
        }
        finally
        {
            objCommon = null;
        }
    }

    public static string getMobileNumber(string strUser)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.getMobileNumber(strUser.Trim());
        }
        catch
        {
            return "";
        }
        finally
        {
            objCommon = null;
        }
    }

    public static Boolean IsUserExists(string strUser)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.IsUserExists(strUser.Trim());
        }
        catch
        {
            return false;
        }
        finally
        {
            objCommon = null;
        }
    }

    public Boolean UpdatePassword(string strUser, string currentpassword)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.UpdatePassword(strUser.Trim(), currentpassword.Trim());
        }
        catch
        {
            return false;
        }
        finally
        {
            objCommon = null;
        }
    }



    #endregion

    #region "Session Concurrency"

    public Boolean IsSessionExists(string strUser)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.IsSessionExists(strUser.Trim());
        }
        catch
        {
            return false;
        }
        finally
        {
            objCommon = null;
        }
    }

    public static Boolean IsSessionIdExists(string strUser, string strSession_Id, string strMAC)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.IsSessionIdExists(strUser.Trim(), strSession_Id.Trim(), strMAC.Trim());
        }
        catch
        {
            return false;
        }
        finally
        {
            objCommon = null;
        }
    }

    public Boolean NewSessionEntry(string strUser, string strSession_Id, string strMAC)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.NewSessionEntry(strUser.Trim(), strSession_Id.Trim(), strMAC.Trim());
        }
        catch
        {
            return false;
        }
        finally
        {
            objCommon = null;
        }
    }

    public Boolean CloseSession(string strUser, string strMacID, int Status)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.CloseSession(strUser.Trim(), strMacID.Trim(), Status);
        }
        catch
        {
            return false;
        }
        finally
        {
            objCommon = null;
        }
    }



    #endregion

    #region "Lock User, Expiry, Forgot Password"

    public Boolean LockUser(string strUser)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.LockUser(strUser.Trim());
        }
        catch
        {
            return false;
        }
        finally
        {
            objCommon = null;
        }
    }

    public static Boolean UnLockUser(string strUser)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.UnLockUser(strUser.Trim());
        }
        catch
        {
            return false;
        }
        finally
        {
            objCommon = null;
        }
    }

    public Boolean isLocked(string strUser)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.isLocked(strUser.Trim());
        }
        catch
        {
            return false;
        }
        finally
        {
            objCommon = null;
        }
    }
    public static Boolean isExpired(string strUserId, string strFlag)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.isExpired(strUserId.Trim(), strFlag.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public int forgotPassword(string strAuto_Password, string strEmail_Address)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.forgotPassword(strAuto_Password, strEmail_Address.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public static void Run_AutoExpiry(int intExpiry)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            objCommon.Run_AutoExpiry(intExpiry);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            objCommon = null;
        }
    }

    #endregion

    #region "User Master"

    public string Save_Username(PL_Username objFields, string strMode)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.Save_Username(objFields, strMode);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public DataTable getUserDetails(string strWhereStatement)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.getUserDetails(strWhereStatement);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    #endregion

    #region "GetMyEmail, Get Divisions, Get Modules, Get Rights, GetUser_Role, Get Vendor List"

    //public static string getMyEmail(string strName)
    //{
    //    clsDLCommon objCommon = new clsDLCommon();
    //    try
    //    {
    //        return objCommon.getMyEmail(strName.Trim());
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());
    //    }
    //    finally
    //    {
    //        objCommon = null;
    //    }
    //}

    //public static string getMyMobile(string strName)
    //{
    //    clsDLCommon objCommon = new clsDLCommon();
    //    try
    //    {
    //        return objCommon.getMyMobile(strName.Trim());
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());
    //    }
    //    finally
    //    {
    //        objCommon = null;
    //    }
    //}

    //public static string getMyRole(string strName)
    //{
    //    clsDLCommon objCommon = new clsDLCommon();
    //    try
    //    {
    //        return objCommon.getMyRole(strName.Trim());
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());
    //    }
    //    finally
    //    {
    //        objCommon = null;
    //    }
    //}

    //public static DataTable BL_getDivisions()
    //{
    //    clsDLCommon objCommon = new clsDLCommon();
    //    try
    //    {
    //        return objCommon.BL_getDivisions();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());
    //    }
    //    finally
    //    {
    //        objCommon = null;
    //    }
    //}

    //public static DataTable BL_getModules()
    //{
    //    clsDLCommon objCommon = new clsDLCommon();
    //    try
    //    {
    //        return objCommon.BL_getModules();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());
    //    }
    //    finally
    //    {
    //        objCommon = null;
    //    }
    //}

    public static DataSet getMyRights(string strUsername)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.getMyRights(strUsername.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public static DataSet getReportRights(string strUsername)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.getReportRights(strUsername.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }


    public static string getMyEmail(string strName)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.getMyEmail(strName.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public static string getMyMobile(string strName)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.getMyMobile(strName.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public static string getMyRole(string strName)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.getMyRole(strName.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public static DataTable BL_getDivisions()
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.BL_getDivisions();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public static DataTable BL_getModules()
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.BL_getModules();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }


    public DataTable getVendorList()
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.getVendorList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    #endregion

    #region "Common Single field Fetching Function, Get Table Query"

    public static string fetchfield(string strField, string strTable, string strWhere)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.fetchfield(strField.Trim(), strTable.Trim(), strWhere.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public static DataTable getTable_Query_WithParameter(string strQuery, SqlParameter[] _Parameter)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.getTable_Query_WithParameter(strQuery.Trim(), _Parameter);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    public static DataTable getTable_Query_WithoutParameter(string strQuery)
    {
        clsDLCommon objCommon = new clsDLCommon();
        try
        {
            return objCommon.getTable_Query_WithoutParameter(strQuery.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objCommon = null;
        }
    }

    #endregion

    public static void ClearControl(params Control[] clr)
    {
        foreach (Control cl in clr)
        {
            if (cl is TextBox)
            {
                (cl as TextBox).Text = "";
            }
            if (cl is DropDownList)
            {
                (cl as DropDownList).SelectedIndex = 0;
            }
            if (cl is GridView)
            {
                (cl as GridView).DataSource = null;
                (cl as GridView).DataBind();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Text;
using PropertyLayer;

namespace DataLayer
{
    public class clsDLCommon
    {
        #region "Login, ChangePassword, User existance"

        public DataSet getMyRights(string strUsername)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            try
            {
                objParameters[0] = new SqlParameter("@USERID", SqlDbType.NVarChar);

                objParameters[0].Value = strUsername;
                return objSql.ExecuteProcedureParamDataset(objSql.strLocal, "SP_GETRIGHTS", objParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objParameters = null;
                objSql = null;
            }
        }

        public string Login(string strUsername, string strPassword, string strPlant, string strType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[5];
            try
            {
                objParameters[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objParameters[4] = new SqlParameter("@RESULT", SqlDbType.VarChar, 1000);

                objParameters[0].Value = strUsername.Trim();
                objParameters[1].Value = strPassword.Trim();
                objParameters[2].Value = strPlant.Trim();
                objParameters[3].Value = strType.Trim();
                objParameters[4].Direction = ParameterDirection.Output;

                if (objSql.ExecuteProcedureParam(objSql.strLocal, "sp_Login", objParameters, "@RESULT", "@RESULT") != "")
                {
                    return objParameters[4].Value.ToString();
                }
                else
                {
                    throw new Exception("Invalid login details");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objParameters = null;
                objSql = null;
            }
        }

        public string DeviceLogin(string strUsername, string strPassword)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[3];
            try
            {
                objParameters[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 1000);

                objParameters[0].Value = strUsername.Trim();
                objParameters[1].Value = strPassword.Trim();
                objParameters[2].Direction = ParameterDirection.Output;

                if (objSql.ExecuteProcedureParam(objSql.strLocal, "sp_Login_Device_FOR", objParameters, "@RESULT", "@RESULT") != "")
                {
                    return objParameters[2].Value.ToString();
                }
                else
                {
                    throw new Exception("Invalid login details");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objParameters = null;
                objSql = null;
            }
        }

        public string ChangePassword(string strUsername, string strOldPassword, string strNewPassword)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[4];
            try
            {
                objParameters[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@NEWPASSWORD", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objParameters[0].Value = strUsername.Trim();
                objParameters[1].Value = strOldPassword.Trim();
                objParameters[2].Value = strNewPassword.Trim();
                objParameters[3].Direction = ParameterDirection.Output;

                if (objSql.ExecuteProcedureParam(objSql.strLocal, "sp_Forgot_Password", objParameters, "@RESULT", "@RESULT") != "")
                {
                    return objParameters[3].Value.ToString();
                }
                else
                {
                    throw new Exception("Problem in change password");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objParameters = null;
                objSql = null;
            }
        }


        public Boolean ChangeMobileNumber(string strUser, string strMobile)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[2];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
                objParameters[0].Value = strUser.Trim();
                objParameters[1].Value = strMobile.Trim();
                if (_Sql.ExecuteNonQuery_Param(_Sql.strLocal, "UPDATE TBLUSER_MASTER SET MOBILE = @PARAM2 WHERE USER_ID = @PARAM1", objParameters) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        public string getMobileNumber(string strUser)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[0].Value = strUser.Trim();
                return _Sql.ExecuteScalarString_Parameter(_Sql.strLocal, "SELECT MOBILE FROM TBLUSER_MASTER WHERE USER_ID = @PARAM1", objParameters);
            }
            catch
            {
                return "";
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        public Boolean IsUserExists(string strUser)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
                objParameters[0].Value = strUser.Trim();
                if (_Sql.ExecuteScalar_Param(_Sql.strLocal, "SELECT COUNT(USER_ID) FROM TBLUSER_MASTER WHERE USER_ID = @PARAM", objParameters) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        public Boolean UpdatePassword(string strUser, string currentpassword)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[2];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
                objParameters[0].Value = strUser.Trim();
                objParameters[1] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[1].Value = currentpassword.Trim();
                if (_Sql.ExecuteNonQuery_Param(_Sql.strLocal, "UPDATE TBLUSER_MASTER SET PASS_WORD = CAST(@PARAM1 AS VARBINARY(500)) WHERE USER_ID = @PARAM", objParameters) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }



        #endregion

        #region "Session Concurrency"

        public Boolean IsSessionExists(string strUser)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
                objParameters[0].Value = strUser.Trim();
                if (_Sql.ExecuteScalar_Param(_Sql.strLocal, "SELECT COUNT(USER_ID) FROM TBLMY_SESSION WHERE USER_ID = @PARAM AND ST = 1", objParameters) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        public Boolean IsSessionIdExists(string strUser, string strSession_Id, string strMAC)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[3];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
                objParameters[0].Value = strSession_Id.Trim();
                objParameters[1].Value = strMAC.Trim();
                objParameters[2].Value = strUser.Trim();

                if (_Sql.ExecuteScalar_Param(_Sql.strLocal, "SELECT COUNT(USER_ID) FROM TBLMY_SESSION WHERE USER_ID = @PARAM2 AND SESSION_ID = @PARAM AND MAC_ADD = @PARAM1 AND ST = 1", objParameters) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        public Boolean NewSessionEntry(string strUser, string strSession_Id, string strMAC)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[3];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
                objParameters[0].Value = strUser.Trim();
                objParameters[1] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[1].Value = strMAC.Trim();
                objParameters[2] = new SqlParameter("@PARAM2", SqlDbType.VarChar);
                objParameters[2].Value = strSession_Id.Trim();
                if (_Sql.ExecuteNonQuery_Param(_Sql.strLocal, "INSERT INTO TBLMY_SESSION (USER_ID, SESSION_ID, MAC_ADD, CRDATE, ST) VALUES (@PARAM, @PARAM2, @PARAM1, GETDATE(), 1)", objParameters) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        public Boolean CloseSession(string strUser, string strMacID, int Status)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[3];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PARAM1", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PARAM2", SqlDbType.Int);

                objParameters[0].Value = strUser.Trim();
                objParameters[1].Value = strMacID.Trim();
                objParameters[2].Value = Status;
                if (_Sql.ExecuteNonQuery_Param(_Sql.strLocal, "UPDATE TBLMY_SESSION SET ST = @PARAM2, CLDATE = GETDATE() WHERE USER_ID = @PARAM", objParameters) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        #endregion

        #region "Lock User, Expiry, Forgot Password"

        public Boolean LockUser(string strUser)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
                objParameters[0].Value = strUser.Trim();
                if (_Sql.ExecuteNonQuery_Param(_Sql.strLocal, "UPDATE TBLUSER_MASTER SET ACTIVATE_ST = 0, ACTIVE_DATE = NULL WHERE USER_ID = @PARAM", objParameters) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        public Boolean UnLockUser(string strUser)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
                objParameters[0].Value = strUser.Trim();
                if (_Sql.ExecuteNonQuery_Param(_Sql.strLocal, "UPDATE TBLUSER_MASTER SET ACTIVATE_ST = 1, ACTIVE_DATE = getdate() WHERE USER_ID = @PARAM", objParameters) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        public Boolean isLocked(string strUser)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
                objParameters[0].Value = strUser.Trim();
                if (_Sql.ExecuteScalar_Param(_Sql.strLocal, "SELECT ACTIVATE_ST TBLMASTER_USER WHERE USER_ID = @PARAM", objParameters) == 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }
        public Boolean isExpired(string strUserId, string strFlag)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[3];
            try
            {
                objParameters[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@FLAG", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objParameters[0].Value = strUserId.Trim();
                objParameters[1].Value = strFlag.Trim();
                objParameters[2].Direction = ParameterDirection.Output;

                if (objSql.ExecuteProcedureParam(objSql.strLocal, "sp_IsExpired", objParameters, "@RESULT", "@RESULT") != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objParameters = null;
                objSql = null;
            }
        }

        public int forgotPassword(string strAutoPass, string strEmail_Address)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            SqlParameter[] _objParameters = new SqlParameter[1];
            SqlParameter[] _Parameters = new SqlParameter[2];
            try
            {
                _objParameters[0] = new SqlParameter("@EMAIL", SqlDbType.VarChar);
                _objParameters[0].Value = strEmail_Address.Trim();

                if (objSql.ExecuteScalar_Param(objSql.strLocal, "SELECT COUNT(USER_ID) FROM TBLUSER_MASTER WHERE EMAIL_ADDRESS = @EMAIL", _objParameters) > 1)
                {
                    throw new Exception("Email address is registered with more than one user id.");
                }

                objParameters[0] = new SqlParameter("@EMAIL", SqlDbType.VarChar);
                objParameters[0].Value = strEmail_Address.Trim();

                string strResult = objSql.ExecuteScalarString_Parameter(objSql.strLocal, "SELECT USER_ID FROM TBLUSER_MASTER WHERE EMAIL_ADDRESS = @EMAIL", objParameters);
                if (strResult != "")
                {
                    string strPassword = strAutoPass.Trim();

                    _Parameters[0] = new SqlParameter("@USER_ID", SqlDbType.VarChar);
                    _Parameters[0].Value = strResult.Trim();
                    _Parameters[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar);
                    _Parameters[1].Value = strPassword.Trim();

                    if (objSql.ExecuteNonQuery_Param(objSql.strLocal, "UPDATE TBLUSER_MASTER SET PASS_WORD = CAST(@PASSWORD AS VARBINARY(1000)), ACTIVATE_ST = 1, ACTIVE_DATE = GETDATE() WHERE USER_ID = @USER_ID", _Parameters) > 0)
                    {
                        //ArrayList _arrList = new ArrayList();
                        //_arrList.Add(strEmail_Address.Trim());
                        //string strBody = clsMail.read_MailBody("Forgot.htm");
                        //strBody = strBody.Replace("{User}", strResult.Trim());
                        //strBody = strBody.Replace("{Pass}", strPassword.Trim());
                        //strBody = strBody.Replace("{URL}", ConfigurationManager.AppSettings["MyURL"]);
                        //clsMail.Send(clsMail.New_Email(_arrList, "Your temporary password.", strBody.Trim(), 0));
                        return 1;
                    }
                    else
                    {
                        throw new Exception("Unable to recover your password.");
                    }
                }
                else
                {
                    throw new Exception("Email address you have entered is not registered.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                objParameters = null;
                objSql = null;
            }
        }

        public void Run_AutoExpiry(int intExpiry)
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM1", SqlDbType.Int);
                objParameters[0].Value = intExpiry;
                _Sql.ExecuteNonQuery_Param(_Sql.strLocal, "UPDATE dbo.TBLSESSION SET ST = 0, CLDATE = GETDATE() WHERE DATEDIFF(MINUTE, CRDATE, GETDATE()) > @PARAM1 AND ST = 1", objParameters);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        #endregion

        #region "User Master"

        public string Save_Username(PL_Username objFields, string strMode)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[12];
            try
            {
                objParameters[0] = new SqlParameter("@USERID", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@UNAME", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PASSWORD", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@EMPCODE", SqlDbType.VarChar);
                objParameters[4] = new SqlParameter("@EMAILID", SqlDbType.VarChar);
                objParameters[5] = new SqlParameter("@UTYPE", SqlDbType.VarChar);
                objParameters[6] = new SqlParameter("@REMARK", SqlDbType.VarChar);
                objParameters[7] = new SqlParameter("@RIGHTS", SqlDbType.VarChar);
                objParameters[8] = new SqlParameter("@STATUS", SqlDbType.Int);
                objParameters[9] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
                objParameters[10] = new SqlParameter("@DIVISION", SqlDbType.VarChar);
                objParameters[11] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objParameters[0].Value = objFields.strUserID.Trim();
                objParameters[1].Value = objFields.strUsername.Trim();
                objParameters[2].Value = objFields.strPassword.Trim();
                objParameters[3].Value = objFields.strEmpCode.Trim();
                objParameters[4].Value = objFields.strEmailID.Trim();
                objParameters[5].Value = objFields.strUserType.Trim();
                objParameters[6].Value = objFields.strRemarks.Trim();
                objParameters[7].Value = objFields.strRights.Trim();
                objParameters[8].Value = objFields.intStatus;
                objParameters[9].Value = objFields.strCreatedBy.Trim();
                objParameters[10].Value = objFields.strPlantCode.Trim();
                objParameters[11].Direction = ParameterDirection.Output;

                if (objSql.ExecuteProcedureParam(objSql.strLocal, "sp_Users_Entry", objParameters, "@RESULT", "@RESULT") != "")
                {
                    return objParameters[11].Value.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objParameters = null;
                objSql = null;
            }
        }

        public DataTable getUserDetails(string strWhereStatement)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT RECNO, DIVISION, USER_ID, USER_NAME, EMP_ID, EMAIL_ADDRESS, USER_TYPE, CRDATE, CRUSER, MDDATE, MDUSER, RIGHTS, REMARK, ACTIVE_DATE, CASE ACTIVATE_ST WHEN 0 THEN 'Deactivated' ELSE 'Activated' END AS ST FROM dbo.TBLUSER_MASTER " + strWhereStatement.Trim()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null;
            }
        }

        #endregion


        #region Country List

        public static List<string> countrylist()
        {
            List<string> countrylist = new List<string>();

            CultureInfo[] getcultureinfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo Culture in getcultureinfo)
            {
                RegionInfo getrg = new RegionInfo(Culture.LCID);
                if (!(countrylist.Contains(getrg.EnglishName)))
                {
                    countrylist.Add(getrg.EnglishName);
                }
            }
            countrylist.Sort();
            return countrylist;
        }
        #endregion

        #region "GetMyEmail, Get Divisions, Get Modules, Get Rights, GetUser_Role, Get Vendor List"

        public string getMyEmail(string strName)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] _Parameter = new SqlParameter[1];
            try
            {
                _Parameter[0] = new SqlParameter("@NAME", SqlDbType.VarChar);
                _Parameter[0].Value = strName.Trim();
                return objSql.ExecuteScalarString_Parameter(objSql.strLocal, "SELECT EMAIL_ADDRESS FROM TBLUSER_MASTER WHERE USER_ID = @NAME", _Parameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null;
            }
        }

        public string getMyMobile(string strName)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] _Parameter = new SqlParameter[1];
            try
            {
                _Parameter[0] = new SqlParameter("@NAME", SqlDbType.VarChar);
                _Parameter[0].Value = strName.Trim();
                return objSql.ExecuteScalarString_Parameter(objSql.strLocal, "SELECT MOBILE FROM TBLUSER_MASTER WHERE USER_ID = @NAME", _Parameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null;
            }
        }

        public string getMyRole(string strName)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] _Parameter = new SqlParameter[1];
            try
            {
                _Parameter[0] = new SqlParameter("@NAME", SqlDbType.VarChar);
                _Parameter[0].Value = strName.Trim();
                return objSql.ExecuteScalarString_Parameter(objSql.strLocal, "SELECT USER_TYPE FROM TBLUSER_MASTER WHERE USER_ID = @NAME", _Parameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null;
            }
        }

        public DataTable BL_getDivisions()
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT DIVISION_NAME FROM TBLDIVISIONS ORDER BY DIVISION_NAME").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null;
            }
        }

        public DataTable BL_getModules()
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT MNUC, CAP, CHLD FROM TBLMASTER_USER_ROLES ORDER BY MNUC").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null;
            }
        }

        //public string getMyRights(string strUsername)
        //{
        //    SqlDataLayer objSql = new SqlDataLayer();
        //    SqlParameter[] objParameters = new SqlParameter[1];
        //    try
        //    {
        //        objParameters[0] = new SqlParameter("@SQL", SqlDbType.NVarChar);
        //        objParameters[0].Value = "SELECT RIGHTS FROM TBLMASTER_USER WHERE [USER_ID] = '" + strUsername.Trim() + "'";
        //        return objSql.ExecuteDataset_Param(objSql.strLocal, "sp_Execute_Report_Query", objParameters).Tables[0].Rows[0][0].ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //    finally
        //    {
        //        objParameters = null;
        //        objSql = null;
        //    }
        //}

        public DataTable getVendorList()
        {
            SqlDataLayer _Sql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            try
            {
                objParameters[0] = new SqlParameter("@PARAM", SqlDbType.VarChar);
                objParameters[0].Value = "Vendor";
                return _Sql.ExecuteProcedure_Table(_Sql.strLocal, "SELECT USER_ID FROM TBLUSER_MASTER WHERE USER_TYPE = @PARAM AND ACTIVATE_ST = 1", objParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objParameters = null;
                _Sql = null;
            }
        }

        #endregion

        #region "Common Single field Fetching Function, Get Table Query"

        public string fetchfield(string strField, string strTable, string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameter = new SqlParameter[4];
            try
            {
                objParameter[0] = new SqlParameter("@TABLE", SqlDbType.VarChar);
                objParameter[1] = new SqlParameter("@COLUMN", SqlDbType.VarChar);
                objParameter[2] = new SqlParameter("@VALUE", SqlDbType.VarChar);
                objParameter[3] = new SqlParameter("@WCOLUMN", SqlDbType.VarChar);

                objParameter[0].Value = strTable.Trim();
                objParameter[1].Value = strField.Trim();
                objParameter[2].Value = strWhere.Split('=').GetValue(1).ToString();
                objParameter[3].Value = strWhere.Split('=').GetValue(0).ToString();

                if (strWhere.Trim() != string.Empty)
                {
                    return objSql.ExecuteScalarString_Parameter(objSql.strLocal, "SELECT @COLUMN FROM @TABLE WHERE @WCOLUMN = @VALUE", objParameter);
                }
                else
                {
                    return objSql.ExecuteScalarString_Parameter(objSql.strLocal, "SELECT @COLUMN FROM @TABLE", objParameter);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objParameter = null;
                objSql = null;
            }
        }

        public DataTable getTable_Query_WithParameter(string strQuery, SqlParameter[] _Parameter)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteProcedure_Table(objSql.strLocal, strQuery.Trim(), _Parameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null;
            }
        }

        public DataTable getTable_Query_WithoutParameter(string strQuery)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, strQuery.Trim()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null;
            }
        }

        #endregion
    }
}

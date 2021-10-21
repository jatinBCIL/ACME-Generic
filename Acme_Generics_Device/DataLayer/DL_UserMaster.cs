using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PropertyLayer;

namespace DataLayer
{

    public class DL_UserMaster
    {
        public DataTable GetUsers(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT *  FROM [VW_USERMASTER] " + strWhere.Trim()).Tables[0];
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

        public DataTable DL_GetUserID()
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct USER_ID FROM [VW_USERMASTER]").Tables[0];
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

        public DataTable GetPlant(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT  distinct PLANT_CODE FROM [VW_PLANTMASTER] " + strWhere.Trim()).Tables[0];
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

        public string DL_Save_UserMaster(PL_Username objFields)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[15];
            try
            {
                objParameters[0] = new SqlParameter("@USERID", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@UNAME", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@FIRSTNAME", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@LASTNAME", SqlDbType.VarChar);
                objParameters[4] = new SqlParameter("@EMPCODE", SqlDbType.VarChar);
                objParameters[5] = new SqlParameter("@EMAILID", SqlDbType.VarChar);
                objParameters[6] = new SqlParameter("@UTYPE", SqlDbType.VarChar);
                objParameters[7] = new SqlParameter("@DEPARTMENT", SqlDbType.VarChar);
                objParameters[8] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);
                objParameters[9] = new SqlParameter("@MODULE", SqlDbType.VarChar);
                objParameters[10] = new SqlParameter("@STATUS", SqlDbType.Int);
                objParameters[11] = new SqlParameter("@METHOD", SqlDbType.VarChar);
                objParameters[12] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
                objParameters[13] = new SqlParameter("@REFNO", SqlDbType.VarChar);
                objParameters[14] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objParameters[0].Value = objFields.strUserID.Trim();
                objParameters[1].Value = objFields.strUsername.Trim();
                objParameters[2].Value = objFields.strFirstName.Trim();
                objParameters[3].Value = objFields.strLastName.Trim();
                objParameters[4].Value = objFields.strEmpCode.Trim();
                objParameters[5].Value = objFields.strEmailID.Trim();
                objParameters[6].Value = objFields.strUserType.Trim();
                objParameters[7].Value = objFields.strDepartment.Trim();
                objParameters[8].Value = objFields.strPlantCode.Trim();
                objParameters[9].Value = objFields.strModule.Trim();
                objParameters[10].Value = objFields.intStatus;
                objParameters[11].Value = objFields.strMethod.Trim();
                objParameters[12].Value = objFields.strCreatedBy.Trim();
                objParameters[13].Value = objFields.REFNO;
                objParameters[14].Direction = ParameterDirection.Output;

                if (objSql.ExecuteProcedureParam(objSql.strLocal, "sp_INSERTUSERMASTER", objParameters, "@RESULT", "@RESULT") != "")
                {
                    return objParameters[14].Value.ToString();
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

        public DataTable getModules()
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

        public string getRights(string strUserID)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteScalarString(objSql.strLocal, "SELECT [RIGHTS] FROM TBLMASTER_USER WHERE USER_ID='" + strUserID + "'");
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


      
        #region "User Roles"

        public DataTable DL_GetUserRoles(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT REFNO,ROLES, USERTYPE, TRANSTYPE, STATUS, RIGHTS, CREATEDBY, CREATEDON, MODIFIEDBY, MODIFIEDON FROM VW_USERROLES " + strWhere.Trim()).Tables[0];
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

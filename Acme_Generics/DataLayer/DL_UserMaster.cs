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
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM [VW_USERMASTER] " + strWhere.Trim()).Tables[0];
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

        public DataTable GetUsersDisplayData(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM [VW_DISPLAYUSERVIEW] " + strWhere.Trim()).Tables[0];
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

        public DataSet DL_GetuserRols(string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[1];
            try
            {
                objParameters[0] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);



                objParameters[0].Value = strPlant;


                return objSql.ExecuteProcedureParamDataset(objSql.strLocal, "sp_For_GetUserRoles", objParameters);

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

        public DataTable DL_GetExistingRoles(string strUserName)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT [T_PLANTID],[T_DEPARTMENT],[T_ROLES],convert(varchar,[T_ACCESSUPTO] ,101) AS T_ACCESSUPTO,[D_PLANTID],[D_DEPARTMENT],[D_ROLES],convert(varchar,[D_ACCESSUPTO] ,101) AS D_ACCESSUPTO FROM TBLMASTER_USER_RIGHTS WHERE USER_ID='" + strUserName + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
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

        public DataTable DL_CheckUserID(string strUseid)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct USER_ID FROM [VW_USERMASTER] WHERE USER_ID='" + strUseid.Trim() + "'").Tables[0];
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
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT  distinct PLANTCODE FROM [VW_PLANTMASTER] WHERE UPPER(ISNULL(STATUS,''))='ACTIVATE'" + strWhere.Trim()).Tables[0];
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
        public DataTable GetModule(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT  distinct MODULE_NAME FROM [VW_MODULE] " + strWhere.Trim()).Tables[0];
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


        public string DL_Save_UserRights(PL_UserRight objFields)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[14];
            try
            {
                objParameters[0] = new SqlParameter("@USERID", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@T_PLANTID", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@T_DEPARTMENT", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@T_ROLES", SqlDbType.VarChar);
                objParameters[4] = new SqlParameter("@T_ACCESSUPTO", SqlDbType.VarChar);
                objParameters[5] = new SqlParameter("@D_PLANTID", SqlDbType.VarChar);
                objParameters[6] = new SqlParameter("@D_DEPARTMENT", SqlDbType.VarChar);
                objParameters[7] = new SqlParameter("@D_ROLES", SqlDbType.VarChar);
                objParameters[8] = new SqlParameter("@D_ACCESSUPTO", SqlDbType.VarChar);
                objParameters[9] = new SqlParameter("@STATUS", SqlDbType.Int);
                objParameters[10] = new SqlParameter("@METHOD", SqlDbType.VarChar);
                objParameters[11] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
                objParameters[12] = new SqlParameter("@REFNO", SqlDbType.VarChar);
                objParameters[13] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objParameters[0].Value = objFields.strUserID.Trim();
                objParameters[1].Value = objFields.strT_PlantID.Trim();
                objParameters[2].Value = objFields.strT_Department.Trim();
                objParameters[3].Value = objFields.strT_Roles.Trim();
                objParameters[4].Value = objFields.DT_T_ACCESSUPTO;
                objParameters[5].Value = objFields.strD_PlantID.Trim();
                objParameters[6].Value = objFields.strD_Department.Trim();
                objParameters[7].Value = objFields.strD_Roles.Trim();
                objParameters[8].Value = objFields.DT_D_ACCESSUPTO;
                objParameters[9].Value = objFields.intStatus;
                objParameters[10].Value = objFields.strMethod.Trim();
                objParameters[11].Value = objFields.strCreatedBy.Trim();
                objParameters[12].Value = objFields.REFNO;
                objParameters[13].Direction = ParameterDirection.Output;

                if (objSql.ExecuteProcedureParam(objSql.strLocal, "sp_INSERTUSERMASTER_RIGHTS", objParameters, "@RESULT", "@RESULT") != "")
                {
                    return objParameters[13].Value.ToString();
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

        #region "User Roles"

        public DataTable DL_GetUserRoles(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT REFNO,ROLES, USERTYPE, TRANSTYPE, CASE Status WHEN 'TRUE' THEN 'Activate' ELSE 'Deactivate' END AS STATUS, RIGHTS, CREATEDBY, CREATEDON, MODIFIEDBY, MODIFIEDON FROM VW_USERROLES " + strWhere.Trim()).Tables[0];
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

        public string DL_InsertUserRoles(PL_UserRoles obj)
        {
            SqlDataLayer ObjData = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[8];
            try
            {
                objparam[0] = new SqlParameter("@ROLES", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@USERTYPE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@TRANSTYPE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@STATUS", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@RIGHTS", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@MODE", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objparam[0].Value = obj.strRole;
                objparam[1].Value = obj.strUserType;
                objparam[2].Value = obj.strTransType;
                objparam[3].Value = obj.intStatus;
                objparam[4].Value = obj.strRight;
                objparam[5].Value = obj.strMODE;
                objparam[6].Value = obj.strCreatedBy;
                objparam[7].Direction = ParameterDirection.Output;

                if (ObjData.ExecuteProcedureParam(ObjData.strLocal, "sp_INSERT_USERROLES", objparam, "@RESULT", "@RESULT") != "")
                {
                    return objparam[7].Value.ToString();
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
                objparam = null;
                ObjData = null;
            }

        }

        #endregion


    }
}

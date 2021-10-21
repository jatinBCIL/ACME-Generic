using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PropertyLayer;

namespace DataLayer
{

    public class DL_BoothMaster
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

        public DataTable DL_GetBoothDisplayData(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM [VW_BOOTHMASTER] " + strWhere.Trim()).Tables[0];
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

        public DataTable DL_GetBoothCode(string strPlantCode)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string str = "";

            try
            {
                str = "SELECT DISTINCT BOOTHCODE FROM [dbo].[tblBooth_M] WHERE PLANTID='" + strPlantCode + "' AND [Status]=1";
                ds = objSql.ExecuteDataset(objSql.strLocal, str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                else
                {

                }
                return dt;
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


        public string DL_Save_BoothMaster(PL_BoothMaster objFields)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[10];
            try
            {
                objParameters[0] = new SqlParameter("@BOOTHCODE", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@BOOTHDESC", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@STORAGELOC", SqlDbType.VarChar);
                objParameters[4] = new SqlParameter("@CRBY", SqlDbType.VarChar);
                objParameters[5] = new SqlParameter("@STATUS", SqlDbType.Int);
                objParameters[6] = new SqlParameter("@METHOD", SqlDbType.VarChar);
                objParameters[7] = new SqlParameter("@REFNO", SqlDbType.VarChar);
                objParameters[8] = new SqlParameter("@REMARK", SqlDbType.VarChar);
                objParameters[9] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objParameters[0].Value = objFields.strBoothCode.Trim();
                objParameters[1].Value = objFields.strBoothDesc.Trim();
                objParameters[2].Value = objFields.strPlantCode.Trim();
                objParameters[3].Value = objFields.strStorageLocation.Trim();
                objParameters[4].Value = objFields.strCreatedBy.Trim();
                objParameters[5].Value = objFields.intStatus;
                objParameters[6].Value = objFields.strMODE.Trim();
                objParameters[7].Value = objFields.REFNO;
                objParameters[8].Value = objFields.strRemark;
                objParameters[9].Direction = ParameterDirection.Output;

                if (objSql.ExecuteProcedureParam(objSql.strLocal, "sp_INSERTBOOTHMASTER", objParameters, "@RESULT", "@RESULT") != "")
                {
                    return objParameters[9].Value.ToString();
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

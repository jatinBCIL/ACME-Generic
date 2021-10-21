using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class clsDLRejection
    {
        public DataTable GetPlants(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT DISTINCT PLANT_ID FROM TBLMASTER_PLANT " + strWhere.Trim()).Tables[0];
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

        public DataTable GetPlantsUsers(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM DBO.BreakStringIntoRows ('" + strWhere.Trim() + "')").Tables[0];
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

        public DataTable GetLineType(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT DISTINCT LINE_TYPE FROM TBLMASTER_LINETYPE " + strWhere.Trim()).Tables[0];
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

        public DataTable GetBatch(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT DISTINCT BATCH_NO FROM [vw_GenHrd] " + strWhere.Trim()).Tables[0];
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

        public DataTable GetRejectionData(string strWhere, string Plant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                if (Plant != string.Empty)
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM [vw_GenHrd] " + strWhere.Trim() + "AND PLANT='" + Plant.Trim() + "'").Tables[0];
                }
                else
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM [vw_GenHrd] " + strWhere.Trim()).Tables[0];

                }
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

        public DataTable GetSNRejectionData(string[] strField, string[] strPacking)
        {
            string Where = "";
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                for (int i = 1; i < strPacking.Length; i++)
                {
                    if (strPacking[i].ToString() != string.Empty && strPacking[i].ToString() != "Select")
                    {
                        if (Where == string.Empty)
                        {
                            Where = " AND " + strField[i].ToString() + " LIKE '%" + strPacking[i].ToString() + "%'";
                        }
                        else
                        {
                            Where = Where + " AND " + strField[i].ToString() + " LIKE '%" + strPacking[i].ToString() + "%'";
                        }

                    }
                }
                if (strPacking[0].ToString() == "Tertiary")
                {

                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT T.BARCODE,H.GTIN_ID,H.PROD_DESC1,H.BATCH_NO,H.MFG_DATE,H.EXP_DATE FROM TBLGEN_HDR H,TBLTER_TRANS T WHERE T.BCIL_ID=H.BCIL_ID AND T.STATUS IN (0,1) " + Where + "").Tables[0];
                }
                else
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT T.BARCODE,H.GTIN_ID,H.PROD_DESC1,H.BATCH_NO,H.MFG_DATE,H.EXP_DATE FROM TBLGEN_HDR H,TBLSEC_TRANS T WHERE T.BCIL_ID=H.BCIL_ID AND T.STATUS IN (0,1) " + Where + "").Tables[0];
                }

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

        public string GetUserType(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteScalarString(objSql.strLocal, "SELECT USER_TYPE FROM [vw_Users] " + strWhere.Trim());
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
        public DataTable GetLine(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM [vw_GenHrd] " + strWhere.Trim()).Tables[0];
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
        public DataTable GetBatchNo(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM [vw_GenHrd] " + strWhere.Trim()).Tables[0];
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
        public DataTable GetLabelType(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM [vw_GenHrd] " + strWhere.Trim()).Tables[0];
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

        public int RejectData(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteNonQuery(objSql.strLocal, "UPDATE TBLGEN_HDR SET [STATUS]=9" + strWhere.Trim());
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
        public string RejectSNData(string Barcode, string Type)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                SqlParameter[] objparameters = new SqlParameter[4];
                objparameters[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);
                if (Type == "Tertiary")
                {
                    objparameters[0] = new SqlParameter("@MODE", "T");
                }
                else
                {
                    objparameters[0] = new SqlParameter("@MODE", "S");
                }

                objparameters[1] = new SqlParameter("@BARCODE", Barcode);
                objparameters[2] = new SqlParameter("@USERNAME", "1");
                objparameters[3].Direction = ParameterDirection.Output;


                if (objSql.ExecuteProcedureParam(objSql.strLocal, "sp_Reject_Barcode", objparameters, "@RESULT", "@RESULT") != "")
                {
                    return objparameters[3].Value.ToString();
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
                objSql = null;
            }
        }



    }
}

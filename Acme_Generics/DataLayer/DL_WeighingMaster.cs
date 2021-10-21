using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PropertyLayer;

namespace DataLayer
{
   

    public class DL_WeighingMaster
    {

        public DataTable DL_GetPlantCode(PL_WeighingMaster obj)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataTable dtDetails = new DataTable();
            SqlParameter[] objParameters = new SqlParameter[0];
            try
            {

                dtDetails = objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_STR_GETPLANT", objParameters);
                if (dtDetails.Rows.Count > 0)
                {
                    return dtDetails;
                }
                else
                {
                    throw new Exception("Problem in Fetching Data.");
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

        //fetching area code against plantcode
      
        public string DL_InsertWeighing(PL_WeighingMaster obj)
        {
            SqlDataLayer ObjData = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[15];
            try
            {
              
                objparam[0] = new SqlParameter("@PLANTCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@WEIGHINGCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@WEIGHINGIP", SqlDbType.Decimal);
                objparam[3] = new SqlParameter("@WEIGHINGPORT", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@WEIGHINGCAPACITY", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@LEASTCOUNT", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@MINVALUE", SqlDbType.Decimal);
                objparam[7] = new SqlParameter("@MAXVALUE", SqlDbType.VarChar);
                objparam[8] = new SqlParameter("@BOOTH", SqlDbType.VarChar);
                objparam[9] = new SqlParameter("@STATUS", SqlDbType.Int);
                objparam[10] = new SqlParameter("@METHOD", SqlDbType.VarChar);
                objparam[11] = new SqlParameter("@REMARK", SqlDbType.VarChar);
                objparam[12] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[13] = new SqlParameter("@REFNO", SqlDbType.Int);
                objparam[14] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objparam[0].Value = obj.strPlantCode;
                objparam[1].Value = obj.strWeighingCode;
                objparam[2].Value = obj.strWeighingIP;
                objparam[3].Value = obj.strPort;
                objparam[4].Value = obj.DScaleCapacity;
                objparam[5].Value = obj.ILeastCount;
                objparam[6].Value = obj.DMinValue;
                objparam[7].Value = obj.DMaxValue;
                objparam[8].Value = obj.strBooth;
                objparam[9].Value = obj.IStatus;
                objparam[10].Value = obj.strMode;
                objparam[11].Value = obj.strRemark;
                objparam[12].Value = obj.strUser;
                objparam[13].Value = obj.REFNO;
                objparam[14].Direction = ParameterDirection.Output;

                if (ObjData.ExecuteProcedureParam(ObjData.strLocal, "sp_INSERTWEIGHINGMASTER", objparam, "@RESULT", "@RESULT") != "")
                {
                    return objparam[14].Value.ToString();
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
    
        // Insert Weighing EXCEL Import Data

        public DataTable DL_GetWeighingDisplayData(string strWhere)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM [VW_WEIGHINGMASTER] " + strWhere.Trim()).Tables[0];
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

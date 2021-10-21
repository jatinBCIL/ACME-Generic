using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PropertyLayer;

namespace DataLayer
{
    /// <summary>
    /// Ref No : 
    /// Purpose : Dispensed Container Status
    /// Created By : Abhishek P Plawankar
    /// Created On : 14 Jan 2017.
    /// Modified By : 
    /// Modified On :
    /// Comment : Datalayer functions of Material Status
    /// </summary>
    /// 
    public class DL_Status_Cont_MM
    {
        public DataTable DL_GetContDetails(PL_Status_Cont_MM objPL)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[3];
            try
            {
                objParameters[0] = new SqlParameter("@CONTCODE", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objParameters[0].Value = objPL.strBarcodeNo;
                objParameters[1].Value = objPL.strPlantCode;
                objParameters[2].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetDispContStatus", objParameters);
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
        
        //    public DataTable DL_GetMaterialDetails(PL_Status_Bin_MM objPL)
        //{
        //   SqlDataLayer objSql = new SqlDataLayer();
        //   SqlParameter[] objParameters = new SqlParameter[6];
        //   try
        //   {
        //       objParameters[0] = new SqlParameter("@BinBarcode", SqlDbType.VarChar);
        //       objParameters[1] = new SqlParameter("@MATCode", SqlDbType.VarChar);
        //       objParameters[2] = new SqlParameter("@SAPBatch", SqlDbType.VarChar);
        //       objParameters[3] = new SqlParameter("@USER", SqlDbType.VarChar);
        //       objParameters[4] = new SqlParameter("@PLANT", SqlDbType.VarChar);
        //       objParameters[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

        //       objParameters[0].Value = objPL.strBinBarcode;
        //       objParameters[1].Value = objPL.strMatCode;
        //       objParameters[2].Value = objPL.strSAPBatch;
        //       objParameters[3].Value = objPL.PrintedBy;
        //       objParameters[4].Value = objPL.strPlantCode;
        //       objParameters[5].Direction = ParameterDirection.Output;

        //       return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetMaterialDetails", objParameters);
        //   }
          
        //   catch (Exception ex)
        //   {
        //       throw new Exception(ex.ToString());
        //   }
        //   finally
        //   {
        //       objSql = null;
        //   }

        //}
    }
}

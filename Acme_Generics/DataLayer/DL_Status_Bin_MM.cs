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
    /// Ref No : MM2,MM3
    /// Purpose : Material Status
    /// Created By : Shubhangi Thange
    /// Created On : 210 Nov 2016.
    /// Modified By : 
    /// Modified On :
    /// Comment : Datalayer functions of Material Status
    /// </summary>
    /// 
    public class DL_Status_Bin_MM
    {
        public DataTable DL_GetBinDetails(PL_Status_Bin_MM objPL)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objParameters = new SqlParameter[4];
            try
            {
                objParameters[0] = new SqlParameter("@BINCODE", SqlDbType.VarChar);
                objParameters[1] = new SqlParameter("@USER", SqlDbType.VarChar);
                objParameters[2] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objParameters[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objParameters[0].Value = objPL.strBarcodeNo;
                objParameters[1].Value = objPL.PrintedBy;
                objParameters[2].Value = objPL.strPlantCode;
                objParameters[3].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_ValidateBinStatus", objParameters);
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
        
            public DataTable DL_GetMaterialDetails(PL_Status_Bin_MM objPL)
        {
           SqlDataLayer objSql = new SqlDataLayer();
           SqlParameter[] objParameters = new SqlParameter[6];
           try
           {
               objParameters[0] = new SqlParameter("@BinBarcode", SqlDbType.VarChar);
               objParameters[1] = new SqlParameter("@MATCode", SqlDbType.VarChar);
               objParameters[2] = new SqlParameter("@SAPBatch", SqlDbType.VarChar);
               objParameters[3] = new SqlParameter("@USER", SqlDbType.VarChar);
               objParameters[4] = new SqlParameter("@PLANT", SqlDbType.VarChar);
               objParameters[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

               objParameters[0].Value = objPL.strBinBarcode;
               objParameters[1].Value = objPL.strMatCode;
               objParameters[2].Value = objPL.strSAPBatch;
               objParameters[3].Value = objPL.PrintedBy;
               objParameters[4].Value = objPL.strPlantCode;
               objParameters[5].Direction = ParameterDirection.Output;

               return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetMaterialDetails", objParameters);
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

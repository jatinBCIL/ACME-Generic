using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DL_PickList
    {

        public DataTable DL_GetBatchDetails(string strFromDate, string strToDate, string strBatchNo, string strType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[5];
            try
            {
                objparam[0] = new SqlParameter("@BATCH", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@FROMDATE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@TODATE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBatchNo;
                objparam[1].Value = strFromDate;
                objparam[2].Value = strToDate;
                objparam[3].Value = strType;
                objparam[4].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetPickListDetails", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }

        public int DL_SaveERPBatch(string strBatch)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteNonQuery(objSql.strErp, string.Format("UPDATE [dbo].[Acme Generics Pvt_ Ltd_$Dispensing Detail] SET [Status]=1 WHERE [Product Batch No_]='{0}' and [Status]=0 and [ByPassed]=0 and [Posted]=0",strBatch));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public int DL_SaveERPBatch(string strBatch, string lineNo, string ARNo)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteNonQuery(objSql.strErp, string.Format("UPDATE [dbo].[Acme Generics Pvt_ Ltd_$Dispensing Detail] SET [Status]=1 " +
                   " WHERE [Product Batch No_]='{0}' and [Prod_ Order Comp_ Line No_] = '" + lineNo + "' and [AR No] = '" + ARNo + "' and [Status]=0 and [ByPassed]=0 " +
                    " and [Posted]=0", strBatch));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetDspensingConfirmation(string strBatchNo, string strType, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[4];
            try
            {
                objparam[0] = new SqlParameter("@BATCHNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBatchNo;
                objparam[1].Value = strType;
                objparam[2].Value = strPlant;
                objparam[3].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetDispensingConfirmation", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }

        public DataTable DL_RefreshPicklist(string strBatchNo, string strType, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[4];
            try
            {
                objparam[0] = new SqlParameter("@BATCHNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBatchNo;
                objparam[1].Value = strType;
                objparam[2].Value = strPlant;
                objparam[3].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_RefreshPicklist", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }


        public string DL_GeneratePicklist(DataTable dt_Temp, string strUser, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[4];
            try
            {
                objparam[0] = new SqlParameter("@TEMP", SqlDbType.Structured);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = dt_Temp;
                objparam[1].Value = strPlant;
                objparam[2].Value = strUser;
                objparam[3].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_GeneratePicklist", objparam, "@RESULT", "@RESULT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }


        public string DL_ConfirmPicking_Dispensing(string strBatchNo, string strProdCode, string strProdBatch, string strProcessOrderNo,string strLineItem, string strUser, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[8];
            try
            {
                objparam[0] = new SqlParameter("@BATCHNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PRODCODE", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@PRODBATCH", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@PROCESSORDERNO", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@LINEITEM", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[6] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strBatchNo;
                objparam[1].Value = strProdCode;
                objparam[2].Value = strProdBatch;
                objparam[3].Value = strProcessOrderNo;
                objparam[4].Value = strLineItem;
                objparam[5].Value = strUser;
                objparam[6].Value = strPlant;
                objparam[7].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamERP(objSql.strLocal, "sp_ConfirmDispensing_v1", objparam, "@RESULT", "@RESULT");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }

        public int DL_ConfirmPicking_Dispensing_ERP(string strBatchNo, string strProdCode, string strProdBatch, string strProcessOrderNo, string strLineItem, string strUser, string strPlant,string strScanQty)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                try
                {
                    objSql.ExecuteNonQuery(objSql.strErp, string.Format("UPDATE [Acme Generics Pvt_ Ltd_$Dispensing Detail] SET [Scan Quantity]={0},[Status]=2 " +
                                                                           "WHERE [Product Batch No_]='{1}' AND [Process Order No_]='{2}' AND [Material Code]='{3}'" +
                                                                           "AND [AR No]='{4}' and [Prod_ Order Comp_ Line No_]='{5}'  " +
                                                                           "and [Status]=1", strScanQty, strProdBatch, strProcessOrderNo, strProdCode, strBatchNo, strLineItem));
                }
                catch (Exception)
                {
                    throw new Exception("Problem in ERP Connection.");
                }

                return objSql.ExecuteNonQuery(objSql.strLocal, string.Format("UPDATE TBLPICKLIST SET STATUS=3,[ConfirmedOn]=GETDATE(),[ConfirmedBy]='{0}' WHERE " +
                                                                             "PROCESSORDERNO='{1}' AND ARNo='{2}' AND MaterialCode='{3}' AND PRODUCTBATCH='{4}' AND " +
                                                                             "STATUS=2 AND LineItem='{5}'", strUser, strProcessOrderNo, strBatchNo, strProdCode, strProdBatch, strLineItem));
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

        public DataTable DL_GetProcessOrderReprintNo(string strDocumentNo)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct [ProdBatch]  FROM [tblSTR_DISPENSING] WITH (NOLOCK) WHERE [ProdBatch] like '" + strDocumentNo + "%'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable DL_GetMRNBatchNo(string strDocumentNo)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct [MRN_PBatch]  FROM [tblGrn_Trans] WITH (NOLOCK) WHERE [MRN_PBatch] like '" + strDocumentNo + "%' and [MRN_PBatch] is not null").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetMRNReprint(string strPBatch)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT [BarcodeNo],[InwardNo],[GRNDate] ,[MaterialCode],[MaterialName],[MaterialType],[TotalQty],(case when MaterialType='RM' then ContainerQty else PackQty end) [NWeight] , [ContainerQty] ,[GWeight] ,[TWeight] ,[ARNo] ,[PackQty] ,[MRN_ST] ,[MRNVerifyBy],[MRN_PBatch],[MRN_PName] FROM [dbo].[tblGrn_Trans] where  [MRN_PBatch] ='" + strPBatch + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetProcessOrderReprinting(string strProcessOrderNo,string strReason,string strUser, string strType, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[6];
            try
            {
                objparam[0] = new SqlParameter("@PROCESSORDERNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@REASON", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strProcessOrderNo;
                objparam[1].Value = strPlant;
                objparam[2].Value = strType;
                objparam[3].Value = strReason;
                objparam[4].Value = strUser;
                objparam[5].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetDispensingReprint", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }

        public DataTable DL_GetDispensingSheetData(string strProcessOrderNo, string strReason, string strUser, string strType, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[6];
            try
            {
                objparam[0] = new SqlParameter("@PROCESSORDERNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@REASON", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strProcessOrderNo;
                objparam[1].Value = strPlant;
                objparam[2].Value = strType;
                objparam[3].Value = strReason;
                objparam[4].Value = strUser;
                objparam[5].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetDispDetails", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }

        public DataTable DL_GetDispHeaderData(string strProcessOrderNo, string strReason, string strUser, string strType, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[6];
            try
            {
                objparam[0] = new SqlParameter("@PROCESSORDERNO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@REASON", SqlDbType.VarChar);
                objparam[4] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[5] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);


                objparam[0].Value = strProcessOrderNo;
                objparam[1].Value = strPlant;
                objparam[2].Value = strType;
                objparam[3].Value = strReason;
                objparam[4].Value = strUser;
                objparam[5].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetDispSheet", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }

        public DataTable DL_GetLocSheetData(string strARNo, string strBlock, string strUser, string strPlant,int MatType, string strArea)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[4];
            try
            {
                objparam[0] = new SqlParameter("@LOC", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@MATTYPE", SqlDbType.Int);


                objparam[0].Value = strARNo;
                objparam[1].Value = strPlant;
                objparam[2].Value = strUser;
                objparam[3].Value = MatType;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GetLocSheet", objparam);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null; objparam = null;
            }
        }
        public DataTable DL_GetARNoLocDtl(string strARNo, string strPlantCode, int matType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                if (matType == 1)
                {
                    return objSql.ExecuteDataset(objSql.strLocal, string.Format("select distinct LocationCode from tblGrn_Trans where ARNo='{0}' and PlantCode='{1}' and ContainerQty>0 and LocationCode is not null", strARNo, strPlantCode)).Tables[0];
                }

                return objSql.ExecuteDataset(objSql.strLocal, string.Format("select distinct LocationCode from tblGrn_Trans where ARNo='{0}' and PlantCode='{1}' and PackQty>0 and LocationCode is not null", strARNo, strPlantCode)).Tables[0];
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable DL_GetARNoDtl(string strARNo, string strPlantCode)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT MaterialBatch FROM [dbo].[tblSTR_Allocation_T] with (nolock) where MaterialBatch like '" + strARNo + "%'  and PlantCode='" + strPlantCode + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable DL_GetBlockName(string strBlock, string strPlantCode)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct [LOCNM] from [dbo].[tblSTR_Bin_M] where LOCNM like '" + strBlock + "%'  and PLANTID='" + strPlantCode + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable DL_GetAreaName(string strArea, string strPlantCode)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct WH_TYPE from [dbo].[tblSTR_Bin_M] where WH_TYPE like '" + strArea + "%'  and PLANTID='" + strPlantCode + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public DataTable DL_GetLocDtl(string strARNo, int type , string strMatCode , string strPlantCode)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                if (type == 0)
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT Bin FROM [dbo].[tblSTR_Allocation_T] with (nolock) where Bin like '" + strARNo + "%'  and MaterialBatch='" + strMatCode + "' and PlantCode='" + strPlantCode + "'").Tables[0];
                }
                else
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT Bin FROM [dbo].[tblSTR_Allocation_T] with (nolock) where Bin like '" + strARNo + "%'  and PlantCode='" + strPlantCode + "'").Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

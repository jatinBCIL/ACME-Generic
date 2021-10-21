using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DL_GrnPrinting
    {

        public DataTable DL_GetDocumenDetails(string strDocumentNo, string strPrintType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                if (strPrintType.Trim() == "PRINT")
                {
                    return objSql.ExecuteDataset(objSql.strErp, "SELECT [GRN No_],[GRN Item No_],[Inward No_],[GRN Date], [Material Code],[Material Name], [Material Type],[Batch No_],cast([MFG Date] as date)[MFG Date],cast([EXP Date] as date)[EXP Date],[No_ Of Container],cast([Total Qty_] as numeric(18,3))[Total Qty_],[Supplier Name],[Manufacture Name],[Batch No_],[Storage Condition],[AR NO] FROM [dbo].[Acme Generics Pvt_ Ltd_$GRN Detail] WHERE [GRN No_]='" + strDocumentNo + "' AND ISNULL(Status,0)=0").Tables[0];
                }
                else
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT [BarcodeNo],[GRNNo],[InwardNo],[MaterialCode],[MaterialName],[MaterialType],[BatchNo],cast([TotalQty] as numeric(18,3))[TotalQty],[NoOfContainer],(case when MaterialType='RM' then cast(ContainerQty as numeric(18,3)) else PackQty end) ContainerQty FROM [dbo].[tblGrn_Trans] with (nolock) WHERE [GRNNo]='" + strDocumentNo + "'").Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public DataTable DL_GetARDocumenDetails(string strDocumentNo, string strPrintType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                if (strPrintType.Trim() == "PRINT")
                {
                    return objSql.ExecuteDataset(objSql.strErp, "SELECT [GRN No_],[GRN Item No_],[Inward No_],[GRN Date], [Material Code],[Material Name], [Material Type],[Batch No_],cast([MFG Date] as date)[MFG Date],cast([EXP Date] as date)[EXP Date],[No_ Of Container],cast([Total Qty_] as numeric(18,3))[Total Qty_],[Supplier Name],[Manufacture Name],[Batch No_],[Storage Condition],[AR NO] FROM [dbo].[Acme Generics Pvt_ Ltd_$GRN Detail] WHERE [AR NO]='" + strDocumentNo + "' AND ISNULL(Status,0)=0").Tables[0];
                }
                else
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT * FROM tblGrn_Trans WHERE [GRNNo]='" + strDocumentNo + "'").Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetGRNPrintedCount(string strDocumentNo, string strInwardNo)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT [Printed_Container],[Printed_Qty] FROM [dbo].[tblGrn_Master] with (nolock) WHERE GRNNo='" + strDocumentNo + "' AND InwardNo='" + strInwardNo + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetERPStockDetails(string strDocumentNo, string strPrintType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strErp, "SELECT [GRN No_],[GRN Item No_],[Inward No_],[GRN Date], [Material Code],[Material Name], [Material Type],[Batch No_],cast([MFG Date] as date)[MFG Date],cast([EXP Date] as date)[EXP Date],[No_ Of Container],cast([Total Qty_] as numeric(18,3))[Total Qty_],[Supplier Name],[Manufacture Name],[Batch No_],[Storage Condition],[AR NO] FROM [dbo].[Acme Generics Pvt_ Ltd_$GRN Detail] WHERE [GRN No_]='" + strDocumentNo + "' AND ISNULL(Status,0)=0").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public int DL_SaveGRNErpStock(string strDocumentNo,string strcont, string strArNo,double tQty)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteNonQuery(objSql.strErp, "UPDATE [Acme Generics Pvt_ Ltd_$GRN Detail] SET [Total Qty_]=" + tQty + " ,[No_ Of Container]=" + int.Parse(strcont) + "  where [GRN No_] = '" + strDocumentNo + "' and [AR NO] = '" + strArNo + "'");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public int DL_SaveGRNERPPrint(string strDocumentNo, string strMatcode, string strInwardno)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteNonQuery(objSql.strErp, "UPDATE [Acme Generics Pvt_ Ltd_$GRN Detail] SET [Status]=1 WHERE [GRN No_]='" + strDocumentNo + "' AND [GRN Item No_]='" + strMatcode + "' AND [Material Code]='" + strMatcode + "' and [Inward No_]='" + strInwardno + "'");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public DataTable DL_GetStockDtl(string strDocumentNo,string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT [BarcodeNo],[GRNNo],[GRNItemNo],[InwardNo],[GRNDate],[MaterialCode],[MaterialName],[MaterialType],[TotalQty],case when [MaterialType]='RM' then [ContainerQty] else [PackQty] end [Qty],[PickQty],[ARNo],[UOM] FROM [dbo].[tblGrn_Trans] where ARNo='" + strDocumentNo + "' and LocationCode is not null and PlantCode='" + strPlant + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        //public int DL_ResetARNo(string strBarCodeNo, string strOldARNo, string strNewARNo, string strPlant)
        //{
        //    SqlDataLayer objSql = new SqlDataLayer();
        //    try
        //    {
        //        return objSql.ExecuteDataset(objSql.strLocal, " Update [dbo].[tblGrn_Trans] set ARNo = '"+ strNewARNo + "' where BarcodeNo='" + strBarCodeNo + "' and ARNo ='" + strOldARNo + " PlantCode='" + strPlant + "'");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //}

        public int DL_ResetARNo(string strBarCodeNo, string strOldARNo, string strNewARNo, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteNonQuery(objSql.strLocal, "Update [dbo].[tblGrn_Trans] set ARNo = '" + strNewARNo + "' where BarcodeNo='" + strBarCodeNo + "' and ARNo ='" + strOldARNo + "' and PlantCode='" + strPlant + "'");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetARNoDtl(string strDocumentNo, string strPlant)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            try
            {
                return objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct [ARNo] FROM [dbo].[tblGrn_Trans] where ARNo like '" + strDocumentNo + "%' and LocationCode is not null and PlantCode='" + strPlant + "'").Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetDocumentNo(string strDocumentNo, string strPrintType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataTable dt = new DataTable();
            try
            {
                if (strPrintType.Trim() == "PRINT")
                {
                    dt= objSql.ExecuteDataset(objSql.strErp, "SELECT [GRN No_][GRNNo] FROM [dbo].[Acme Generics Pvt_ Ltd_$GRN Detail] WITH (NOLOCK) WHERE [GRN No_] LIKE '%" + strDocumentNo + "' AND ISNULL(Status,0)=0").Tables[0];

                    if (dt.Rows.Count == 0)
                    {
                        dt = objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct [GRNNo] FROM tblGrn_Trans WITH (NOLOCK) WHERE [GRNNo] like '%" + strDocumentNo + "'").Tables[0];
                    }

                    return dt;
                }
                else
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct [GRNNo] FROM tblGrn_Trans WITH (NOLOCK) WHERE [GRNNo] like '%" + strDocumentNo + "'").Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable DL_GetARDocumentNo(string strDocumentNo, string strPrintType)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            DataTable dt = new DataTable();
            try
            {
                if (strPrintType.Trim() == "PRINT")
                {
                    dt = objSql.ExecuteDataset(objSql.strErp, "SELECT [AR NO][ARNo] FROM [dbo].[Acme Generics Pvt_ Ltd_$GRN Detail] WITH (NOLOCK) WHERE [AR NO] LIKE '%" + strDocumentNo + "' AND ISNULL(Status,0)=0").Tables[0];

                    if (dt.Rows.Count == 0)
                    {
                        dt = objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct [GRNNo] FROM tblGrn_Trans WITH (NOLOCK) WHERE [GRNNo] like '%" + strDocumentNo + "'").Tables[0];
                    }

                    return dt;
                }
                else
                {
                    return objSql.ExecuteDataset(objSql.strLocal, "SELECT distinct [GRNNo] FROM tblGrn_Trans WITH (NOLOCK) WHERE [GRNNo] like '%" + strDocumentNo + "'").Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public DataTable DL_GetBarcodeNo(string strGRNno, string strLineItem, string strMatCode, string strQty, string strPackSize, string strPlantCode, string strUser,string strType,int iNoofContainers,string strMatBatch,string strReason)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[11];
            try
            {
                objparam[0] = new SqlParameter("@GRN_NO", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@LINEITEM", SqlDbType.VarChar);
                objparam[2] = new SqlParameter("@MATCODE", SqlDbType.VarChar);
                objparam[3] = new SqlParameter("@QTY", SqlDbType.Decimal);
                objparam[4] = new SqlParameter("@PACKSIZE", SqlDbType.Decimal);
                objparam[5] = new SqlParameter("@NOOFCONTAINERS", SqlDbType.Int);
                objparam[6] = new SqlParameter("@MATBATCH", SqlDbType.VarChar);
                objparam[7] = new SqlParameter("@PLANT", SqlDbType.VarChar);
                objparam[8] = new SqlParameter("@USER", SqlDbType.VarChar);
                objparam[9] = new SqlParameter("@TYPE", SqlDbType.VarChar);
                objparam[10] = new SqlParameter("@REASON", SqlDbType.VarChar);

                objparam[0].Value = strGRNno;
                objparam[1].Value = strLineItem;
                objparam[2].Value = strMatCode;
                objparam[3].Value = strQty;
                objparam[4].Value = double.Parse(strPackSize);
                objparam[5].Value = iNoofContainers;
                if (strMatBatch == "&nbsp;")
                {
                    objparam[6].Value = "";
                }
                else
                {
                    objparam[6].Value = strMatBatch;
                }
                objparam[7].Value = strPlantCode;
                objparam[8].Value = strUser;
                objparam[9].Value = strType;
                objparam[10].Value = strReason;

                return objSql.ExecuteProcedureParamTable(objSql.strLocal, "sp_GRN_ReceiptLabel", objparam);
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

        public string DL_SaveARStock(string strBarcode, string strQty)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            SqlParameter[] objparam = new SqlParameter[3];
            try
            {
                objparam[0] = new SqlParameter("@BARCODE", SqlDbType.VarChar);
                objparam[1] = new SqlParameter("@QTY", SqlDbType.Decimal);
                objparam[2] = new SqlParameter("@RESULT", SqlDbType.VarChar, 500);

                objparam[0].Value = strBarcode;
                objparam[1].Value = double.Parse(strQty);
                objparam[2].Direction = ParameterDirection.Output;

                return objSql.ExecuteProcedureParam(objSql.strLocal, "sp_SaveStockDtl", objparam, "@RESULT", "@RESULT");
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
      
    }
}

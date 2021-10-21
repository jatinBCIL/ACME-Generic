using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


   public  class clsReport
    {
        public DataSet BL_Report_Genrater(string strReport, string strWhere, string strQuery)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            string strMyQuery = string.Empty;
            try
            {
                if (strReport == "RPT_Sample")
                {
                    strMyQuery = "SELECT [Barcode No],[GRN No],[Inward No],convert(varchar,[GRN Date],103),[Material Code],[Material Name],[Material Type],[Batch No],[No Of Container],[Total Qty],[AR No],convert(varchar,[RETEST DATE],103)[RETEST DATE],[UD CODE],[Base Uom],[Print By],[Print On],[Reprint By],[Reprint On],[Re-Print Count],[Pack Qty],[UOM],[Sampled Status],[Reprint Reason],[Sampled on],[Sampled By]  FROM [DB_ACME_Barcode].[dbo].[VW_Sample_RPT] " + strWhere.Trim();
                }
                if (strReport == "RPT_MaterialReport")
                {
                    strMyQuery = "SELECT [BarcodeNo],[GRN No],[Inward No],convert(varchar,[GRN Date],103)[GRN Date],[Material Code],[Material Name],[Material Type],[Batch No],convert(varchar,[MFG Date], 103)[MFG Date],convert(varchar,[EXP Date], 103)[EXP Date],[No Of Container],cast([Total Qty] as numeric(18,3))[Total Qty],cast([Container Qty] as numeric(18,3))[Container Qty],[AR No],[Status],[BaseUom],[Printed By],[Printed On],isnull([Location Code],'')[Location Code],isnull([Allocated By],'')[Allocated By],isnull(cast([Allocated On] as varchar),'')[Allocated On],[Plant Code] FROM [DB_ACME_Barcode].[dbo].[VW_MAT_RPT] " + strWhere.Trim();
                }
                if (strReport == "RPT_BatTrackingReport")
                {
                    strMyQuery = "SELECT [Picklist No],[Product Batch],[Line Item],[Product Code],[Product Name],[Material Code],[Material Batch],[Material Name],[AR No],[Quantity],[Scanned Quantity],[Pick Qty],[Uom],[Bin Code],[Picklist By],[Picklist On],[Picked By],[Picked On],[Dispensed On],[Dispensed By],[Confirmed On],[Confirmed By],[Plant Code],[Status] FROM [dbo].[VW_BATCH_TRACKING] " + strWhere.Trim();
                }
                if (strReport == "RPT_PickingReport")
                {
                    strMyQuery = "SELECT [Product Batch],[Line Item],[Product Code],[Product Name],[Material Code],[Material Batch],[Material Name],[AR No],[Quantity],[Scanned Quantity],[Pick Qty],[Uom],[Bin Code],[Picked By],[Picked On] FROM [dbo].[VW_PICKING] " + strWhere.Trim();
                }
                if (strReport == "RPT_PicklistReport")
                {
                    strMyQuery = "SELECT [Product Batch],[Line Item],[Product Code],[Product Name],[Material Code],[Material Batch],[Material Name],[AR No],[Quantity],[Scanned Quantity],[Picklist Created By],[Picklist Created On],[Plant Code] FROM [dbo].[VW_PICKLIST] " + strWhere.Trim();
                }
                if (strReport == "RPT_DispenseReport")
                {
                    strMyQuery = "SELECT [Product Batch],[Line Item],[Product Code],[Product Name],[Material Code],[Material Batch],[Material Name],[AR No],[Quantity],[Scanned Quantity],[Pick Qty],[Uom],[Bin Code],[Dispensed On],[Dispensed By],[Plant Code] FROM [dbo].[VW_DISPENSING] " + strWhere.Trim();
                }
                if (strReport == "RPT_DispenseConfirmReport")
                {
                    strMyQuery = "SELECT [Product Batch],[Line Item],[Product Code],[Product Name],[Material Code],[Material Batch],[Material Name],[AR No],[Quantity],[Scanned Quantity],[Pick Qty],[Uom],[Confirmed On],[Confirmed By],[Plant Code] FROM [dbo].[VW_DISPENSING_CONFIRM] " + strWhere.Trim();
                }
                if (strReport == "RPT_DispensingDetailsReport")
                {
                    strMyQuery = "SELECT [Barcode No],[Product Code],[Product Desc],[Product Batch],[Line Item No],[Material Code],[Material Desc],[Material Batch],[UOM],[AR No],[Gross Weight],[Net Weight],[Tare Weight],[Weighing Scale],[Material Barcode],[Status],[Mfg Date],[Exp Date],[Batch Size],[Container No],[Created By],[Created On],[Plant Code],[Reprint By],[Re-Print On],[Reprint Count],[Reprint Reason] FROM [dbo].[VW_DISP_DTL] " + strWhere.Trim();
                }

                strQuery = strMyQuery;

                SqlParameter[] objParameter = new SqlParameter[1];
                try
                {
                    objParameter[0] = new SqlParameter("@SQL", SqlDbType.VarChar);
                    objParameter[0].Value = strMyQuery;
                    return objSql.ExecuteDataset_Param(objSql.strLocal, "sp_Execute_Report_Query", objParameter);
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
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objSql = null;
            }
        }

        public DataSet BL_Report_Genrater_EXL(string strReport, string strWhere, string strQuery)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            string strMyQuery = string.Empty;
            try
            {
                if (strReport == "RPT_Sample")
                {
                    strMyQuery = "SELECT ''''+[Barcode No] as [Sample Barcode],[GRN No],[Inward No],convert(varchar,[GRN Date],103),[Material Code],[Material Name],[Material Type],[Batch No],[No Of Container],[Total Qty],[AR No],convert(varchar,[RETEST DATE],103)[RETEST DATE],[UD CODE],[Base Uom],[Print By],[Print On],[Reprint By],[Reprint On],[Re-Print Count],[Pack Qty],[UOM],[Sampled Status],[Reprint Reason],[Sampled on],[Sampled By]  FROM [DB_ACME_Barcode].[dbo].[VW_Sample_RPT] " + strWhere.Trim();
                }

                if (strReport == "RPT_MaterialReport")
                {
                    strMyQuery = "SELECT ''''+[BarcodeNo],[GRN No],[Inward No],convert(varchar,[GRN Date],103)[GRN Date],[Material Code],[Material Name],[Material Type],[Batch No],convert(varchar,[MFG Date], 103)[MFG Date],convert(varchar,[EXP Date], 103)[EXP Date],[No Of Container],cast([Total Qty] as numeric(18,3))[Total Qty],cast([Container Qty] as numeric(18,3))[Container Qty],[AR No],[Status],[BaseUom],[Printed By],[Printed On],isnull([Location Code],'')[Location Code],isnull([Allocated By],'')[Allocated By],isnull(cast([Allocated On] as varchar),'')[Allocated On],[Plant Code] FROM [DB_ACME_Barcode].[dbo].[VW_MAT_RPT] " + strWhere.Trim();
                }

                if (strReport == "RPT_BatTrackingReport")
                {
                    strMyQuery = "SELECT ''''+[Picklist No],[Product Batch],[Line Item],[Product Code],[Product Name],[Material Code],[Material Batch],[Material Name],[AR No],[Quantity],[Scanned Quantity],[Pick Qty],[Uom],[Bin Code],[Picklist By],[Picklist On],[Picked By],[Picked On],[Dispensed On],[Dispensed By],[Confirmed On],[Confirmed By],[Plant Code],[Status] FROM [dbo].[VW_BATCH_TRACKING] " + strWhere.Trim();
                }

                if (strReport == "RPT_PickingReport")
                {
                    strMyQuery = "SELECT ''''+[Product Batch],[Line Item],[Product Code],[Product Name],[Material Code],[Material Batch],[Material Name],[AR No],[Quantity],[Scanned Quantity],[Pick Qty],[Uom],[Bin Code],[Picked By],[Picked On] FROM [dbo].[VW_PICKING] " + strWhere.Trim();
                }

                if (strReport == "RPT_PicklistReport")
                {
                    strMyQuery = "SELECT ''''+[Product Batch],[Line Item],[Product Code],[Product Name],[Material Code],[Material Batch],[Material Name],[AR No],[Quantity],[Scanned Quantity],[Picklist Created By],[Picklist Created On],[Plant Code] FROM [dbo].[VW_PICKLIST] " + strWhere.Trim();
                }
                if (strReport == "RPT_DispenseReport")
                {
                    strMyQuery = "SELECT ''''+[Product Batch],[Line Item],[Product Code],[Product Name],[Material Code],[Material Batch],[Material Name],[AR No],[Quantity],[Scanned Quantity],[Pick Qty],[Uom],[Bin Code],[Dispensed On],[Dispensed By],[Plant Code] FROM [dbo].[VW_DISPENSING] " + strWhere.Trim();
                }
                if (strReport == "RPT_DispenseConfirmReport")
                {
                    strMyQuery = "SELECT ''''+[Product Batch],[Line Item],[Product Code],[Product Name],[Material Code],[Material Batch],[Material Name],[AR No],[Quantity],[Scanned Quantity],[Pick Qty],[Uom],[Confirmed On],[Confirmed By],[Plant Code] FROM [dbo].[VW_DISPENSING_CONFIRM] " + strWhere.Trim();
                }
                if (strReport == "RPT_DispensingDetailsReport")
                {
                    strMyQuery = "SELECT ''''+[Barcode No],[Product Code],[Product Desc],[Product Batch],[Line Item No],[Material Code],[Material Desc],[Material Batch],[UOM],[AR No],[Gross Weight],[Net Weight],[Tare Weight],[Weighing Scale],[Material Barcode],[Status],[Mfg Date],[Exp Date],[Batch Size],[Container No],[Created By],[Created On],[Plant Code],[Reprint By],[Re-Print On],[Reprint Count],[Reprint Reason] FROM [dbo].[VW_DISP_DTL] " + strWhere.Trim();
                }

                
                strQuery = strMyQuery;

                SqlParameter[] objParameter = new SqlParameter[1];
                try
                {
                    objParameter[0] = new SqlParameter("@SQL", SqlDbType.VarChar);
                    objParameter[0].Value = strMyQuery;
                    return objSql.ExecuteDataset_Param(objSql.strLocal, "sp_Execute_Report_Query", objParameter);
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


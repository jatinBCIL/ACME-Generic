using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using PropertyLayer;
using BusinessLayer;
using System.Configuration;
using System.DirectoryServices;

public partial class frmGrn_Printing : System.Web.UI.Page
{

    public static string strFlg = "";
    DataTable dtImport = new DataTable();

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> GetProccno(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_PickList objBL = new BL_PickList();
        try
        {
            List<string> Items = new List<string>();
            dt = objBL.BL_GetProcessOrderReprintNo(prefixText);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Items.Add(dt.Rows[i]["ProdBatch"].ToString());
                }
            }
            return Items;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objBL = null;
            dt = null;
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            BL_PrinterMaster objPrint = new BL_PrinterMaster();
            DataTable dt = new DataTable();
            DataTable dt_Plant = new DataTable();
            DataTable dt_AscPlant = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                clsStandards.fillCombobox(ddlPrinterName, objPrint.BL_PrinterCodes(clsStandards.current_Plant()), "PRINTERCODE");

            }
            catch (Exception ex)
            {
                clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
            finally
            {
                objPrint = null;
            }
            MultiView1.SetActiveView(View1);
            strFlg = "ADD";


        }

    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    DataTable dtPrint = new DataTable();
    //    BL_PickList objGrn = new BL_PickList();
    //    bool bFlag = false;

    //    try
    //    {
    //        if (GrGRNDetails.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
    //            {


    //                CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
    //                if (cb.Checked == true)
    //                {
    //                    dtPrint = objGrn.BL_GetProcessOrderReprinting(GrGRNDetails.Rows[i].Cells[1].Text.ToString(), "", "", "REPRINT", clsStandards.current_Plant().ToString());


    //                    if (dtPrint.Columns.Count > 1)
    //                    {

    //                        bFlag = PrintDirect.Print_DispenseRawLabel(
    //                              ddlPrinterName.Text.Trim(),
    //                               dtPrint.Rows[0]["BarcodeNo"].ToString(),
    //                                dtPrint.Rows[0]["MatCode"].ToString(),
    //                               dtPrint.Rows[0]["MatDesc"].ToString(),
    //                               dtPrint.Rows[0]["MaterialBatch"].ToString(),
    //                               dtPrint.Rows[0]["MfgDate"].ToString(),
    //                               dtPrint.Rows[0]["ExpDate"].ToString(),
    //                               dtPrint.Rows[0]["ProcessOrder"].ToString(),
    //                               dtPrint.Rows[0]["ProdCode"].ToString(),
    //                               dtPrint.Rows[0]["ProdBatch"].ToString(),
    //                               dtPrint.Rows[0]["ProductDesc"].ToString(),
    //                              Convert.ToDecimal(dtPrint.Rows[0]["GrossWt"].ToString()),
    //                                Convert.ToDecimal(dtPrint.Rows[0]["NetWt"].ToString()),
    //                                Convert.ToDecimal(dtPrint.Rows[0]["TareWt"].ToString()),
    //                               dtPrint.Rows[0]["CreatedBy"].ToString(),
    //                               dtPrint.Rows[0]["CreatedOn"].ToString(),
    //                               dtPrint.Rows[0]["UOM"].ToString(),
    //                               dtPrint.Rows[0]["PlantCode"].ToString(),
    //                               dtPrint.Rows[0]["BatchSize"].ToString(),
    //                               dtPrint.Rows[0]["ARNo"].ToString(),
    //                               dtPrint.Rows[0]["ContainerNo"].ToString()
    //                               , "");

    //                        if (bFlag == true)
    //                        {
    //                            clsStandards.WriteLog(this, new Exception("Barcode Printed Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //                            //txtGrossWt.Text = "";
    //                            //txtNetWt.Text = "";
    //                            //txtTareWt.Text = "";
    //                            //txtGrossWt.Focus();
    //                            return;
    //                        }
    //                        else
    //                        {
    //                            clsStandards.WriteLog(this, new Exception("Transaction Failed"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //                            return;
    //                        }

    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            clsStandards.WriteLog(this, new Exception("No details to print against this document"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //        }



    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());

    //    }
    //    finally
    //    {

    //    }
    //}

    protected void btnGet_Click(object sender, EventArgs e)
    {
        BL_PickList objBL = new BL_PickList();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetProcessOrderReprinting(txtProcessOrderNo.Text.Trim(), " ", " ", "GET", clsStandards.current_Plant().ToString());
            if (dtGrn.Rows.Count > 0)
            {
                GrGRNDetails.DataSource = dtGrn;
                GrGRNDetails.DataBind();
            }
            else
            {
                GrGRNDetails.DataSource = null;
                GrGRNDetails.DataBind();
                clsStandards.WriteLog(this, new Exception("No details found for document"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);

            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {

        }

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        try
        {
            HttpContext.Current.Response.Redirect(ResolveUrl("~/Modules/frmMain.aspx"), false);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
        }
    }


    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    DataTable dtPrint = new DataTable();
    //    BL_PickList objGrn = new BL_PickList();
    //    bool bFlag = false;

    //    try
    //    {
    //        if (GrGRNDetails.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
    //            {


    //                CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
    //                if (cb.Checked == true)
    //                {
    //                    dtPrint = objGrn.BL_GetProcessOrderReprinting(GrGRNDetails.Rows[i].Cells[1].Text.ToString(), txtReason.Text.Trim(), clsStandards.current_Username().ToString(), "REPRINT", clsStandards.current_Plant().ToString());


    //                    if (dtPrint.Columns.Count > 1)
    //                    {

    //                        bFlag = PrintDirect.Print_DispenseRawLabel(
    //                                ddlPrinterName.Text.Trim(),
    //                                dtPrint.Rows[0]["BarcodeNo"].ToString(),
    //                                dtPrint.Rows[0]["MatCode"].ToString(),
    //                                dtPrint.Rows[0]["MatDesc"].ToString(),
    //                                dtPrint.Rows[0]["MaterialBatch"].ToString(),
    //                                DateTime.Parse(dtPrint.Rows[0]["MfgDate"].ToString()).ToString("dd/MM/yyyy"),
    //                                DateTime.Parse(dtPrint.Rows[0]["ExpDate"].ToString()).ToString("dd/MM/yyyy"),
    //                                dtPrint.Rows[0]["ProcessOrder"].ToString(),
    //                                dtPrint.Rows[0]["ProdCode"].ToString(),
    //                                dtPrint.Rows[0]["ProdBatch"].ToString(),
    //                                dtPrint.Rows[0]["ProductDesc"].ToString(),
    //                                Convert.ToDecimal(dtPrint.Rows[0]["GrossWt"].ToString()),
    //                                Convert.ToDecimal(dtPrint.Rows[0]["NetWt"].ToString()),
    //                                Convert.ToDecimal(dtPrint.Rows[0]["TareWt"].ToString()),
    //                                dtPrint.Rows[0]["CreatedBy"].ToString(),
    //                                dtPrint.Rows[0]["CreatedOn"].ToString(),
    //                                dtPrint.Rows[0]["UOM"].ToString(),
    //                                dtPrint.Rows[0]["PlantCode"].ToString(),
    //                                dtPrint.Rows[0]["BatchSize"].ToString(),
    //                                dtPrint.Rows[0]["ARNo"].ToString(),
    //                                dtPrint.Rows[0]["TOTALCONTAINER"].ToString() + "of" + dtPrint.Rows[0]["COUNT"].ToString(),
    //                                dtPrint.Rows[0]["LotNo"].ToString());


    //                        if (bFlag == true)
    //                        {
    //                            clsStandards.WriteLog(this, new Exception("Barcode Printed Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //                            //txtGrossWt.Text = "";
    //                            //txtNetWt.Text = "";
    //                            //txtTareWt.Text = "";
    //                            //txtGrossWt.Focus();
    //                            return;
    //                        }
    //                        else
    //                        {
    //                            clsStandards.WriteLog(this, new Exception("Transaction Failed"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //                            return;
    //                        }

    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            clsStandards.WriteLog(this, new Exception("No details to print against this document"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //        }



    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());

    //    }
    //    finally
    //    {

    //    }
    //}
    //protected void Btntest_Click(object sender, EventArgs e)
    //{
    //    string str = "Test";
    //}
    protected void btnPrint_Click1(object sender, EventArgs e)
    {
        DataTable dtPrint = new DataTable();
        BL_PickList objGrn = new BL_PickList();
        BL_PrinterMaster objPrint = new BL_PrinterMaster();
        DataTable dt = new DataTable();
        string strIp, strPort;

        bool bFlag = false;

        try
        {
            dt = objPrint.BL_PrinterIPandPort(ddlPrinterName.Text.Trim(), clsStandards.current_Plant().ToString());

            if (dt.Rows.Count > 0)
            {
                strIp = dt.Rows[0][0].ToString();
                strPort = dt.Rows[0][1].ToString();
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Printer Details not found"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }

            if (GrGRNDetails.Rows.Count > 0)
            {
                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {


                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                    if (cb.Checked == true)
                    {
                        dtPrint = objGrn.BL_GetProcessOrderReprinting(GrGRNDetails.Rows[i].Cells[1].Text.ToString(), txtReason.Text.Trim(), clsStandards.current_Username().ToString(), "REPRINT", clsStandards.current_Plant().ToString());


                        if (dtPrint.Columns.Count > 1)
                        {

                            bFlag = PrintDirect.Print_DispenseRawLabel(
                                    ddlPrinterName.Text.Trim(),
                                    dtPrint.Rows[0]["BarcodeNo"].ToString(),
                                    dtPrint.Rows[0]["MatCode"].ToString(),
                                    dtPrint.Rows[0]["MatDesc"].ToString(),
                                    dtPrint.Rows[0]["MaterialBatch"].ToString(),
                                    DateTime.Parse(dtPrint.Rows[0]["MfgDate"].ToString()).ToString("yyyy") == "1753" ? "To be established" : DateTime.Parse(dtPrint.Rows[0]["MfgDate"].ToString()).ToString("MMM yyyy"),
                                    DateTime.Parse(dtPrint.Rows[0]["MfgDate"].ToString()).ToString("yyyy") == "1753" ? "To be established" : DateTime.Parse(dtPrint.Rows[0]["ExpDate"].ToString()).ToString("MMM yyyy"),
                                    dtPrint.Rows[0]["ProcessOrder"].ToString(),
                                    dtPrint.Rows[0]["ProdCode"].ToString(),
                                    dtPrint.Rows[0]["ProdBatch"].ToString(),
                                    dtPrint.Rows[0]["ProductDesc"].ToString(),
                                    Convert.ToDecimal(dtPrint.Rows[0]["GrossWt"].ToString()),
                                    Convert.ToDecimal(dtPrint.Rows[0]["NetWt"].ToString()),
                                    Convert.ToDecimal(dtPrint.Rows[0]["TareWt"].ToString()),
                                    dtPrint.Rows[0]["CreatedBy"].ToString(),
                                    dtPrint.Rows[0]["CreatedOn"].ToString(),
                                    dtPrint.Rows[0]["UOM"].ToString(),
                                    dtPrint.Rows[0]["PlantCode"].ToString(),
                                    dtPrint.Rows[0]["BatchSize"].ToString(),
                                    dtPrint.Rows[0]["ARNo"].ToString(),
                                    dtPrint.Rows[0]["COUNT"].ToString() + " of " + dtPrint.Rows[0]["TOTALCONTAINER"].ToString(),
                                    dtPrint.Rows[0]["LotNo"].ToString()
                                    , strIp, strPort, dtPrint.Rows[0]["Print_Flag"].ToString());


                            if (bFlag == true)
                            {
                                clsStandards.WriteLog(this, new Exception("Barcode Printed Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                                txtReason.Text = "";
                                return;
                            }
                            else
                            {
                                clsStandards.WriteLog(this, new Exception("Transaction Failed"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                                return;
                            }

                        }
                    }
                }
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("No details to print against this document"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }



        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
        finally
        {

        }
    }
    protected void GrGRNDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        
        if (chkSelectAll.Checked == true)
        {
            foreach (GridViewRow gvRow in GrGRNDetails.Rows)
            {
                CheckBox chksel = (CheckBox)gvRow.FindControl("chkSelect");

                chksel.Checked = true;

            }
        }
        else
        {
            foreach (GridViewRow gvRow in GrGRNDetails.Rows)
            {
                CheckBox chksel = (CheckBox)gvRow.FindControl("chkSelect");

                chksel.Checked = false;

            }
        }

    }
}
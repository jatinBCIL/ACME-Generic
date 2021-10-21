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

public partial class frmMRNLableReprinting : System.Web.UI.Page
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
            dt = objBL.BL_GetMRNBatchNo(prefixText);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Items.Add(dt.Rows[i]["MRN_PBatch"].ToString());
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

    protected void btnGet_Click(object sender, EventArgs e)
    {
        
        BL_PickList objBL = new BL_PickList();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetMRNReprint(txtProcessOrderNo.Text.Trim());
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
    protected void Btntest_Click(object sender, EventArgs e)
    {
        string str = "Test";
    }
    protected void btnPrint_Click1(object sender, EventArgs e)
    {
        DataTable dtPrint = new DataTable();
        BL_MRNLabel objGrn = new BL_MRNLabel();
        bool bFlag = false;
        int PCount=0;

        try
        {
            if (GrGRNDetails.Rows.Count > 0)
            {
                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {


                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                    if (cb.Checked == true)
                    {
                        dtPrint = objGrn.BL_GetReprintMRNBarcodeNo(GrGRNDetails.Rows[i].Cells[1].Text.ToString(), txtReason.Text.Trim(), clsStandards.current_Username().ToString());


                        if (dtPrint.Columns.Count > 1)
                        {

                            bFlag = PrintDirect.Print_DispenseRawLabel(
                                      ddlPrinterName.Text.Trim(),
                                      dtPrint.Rows[0]["BarcodeNo"].ToString(),
                                      dtPrint.Rows[0]["MaterialCode"].ToString(),
                                      dtPrint.Rows[0]["MaterialName"].ToString(),
                                      dtPrint.Rows[0]["MaterialType"].ToString(),
                                      DateTime.Parse(dtPrint.Rows[0]["MFGDate"].ToString()).ToString("dd/MM/yyyy"),
                                      DateTime.Parse(dtPrint.Rows[0]["EXPDate"].ToString()).ToString("dd/MM/yyyy"),
                                      dtPrint.Rows[0]["ProcessOrderNo"].ToString(),
                                      dtPrint.Rows[0]["MaterialCode"].ToString(),
                                      dtPrint.Rows[0]["MRN_PBatch"].ToString(),
                                      dtPrint.Rows[0]["MRN_PName"].ToString(),
                                      Convert.ToDecimal(dtPrint.Rows[0]["GWeight"].ToString()),
                                      Convert.ToDecimal(dtPrint.Rows[0]["NWeight"].ToString()),
                                      Convert.ToDecimal(dtPrint.Rows[0]["TWeight"].ToString()),
                                      dtPrint.Rows[0]["AllocatedBy"].ToString(),
                                      dtPrint.Rows[0]["AllocatedOn"].ToString(),
                                      dtPrint.Rows[0]["UOM"].ToString(),
                                      dtPrint.Rows[0]["PlantCode"].ToString(),
                                      "",
                                      dtPrint.Rows[0]["ARNo"].ToString(),
                                      dtPrint.Rows[0]["NoOfContainer"].ToString(),
                                      dtPrint.Rows[0]["InwardNo"].ToString()
                                      , "", "", "");


                            if (bFlag == true)
                            {
                                PCount++;

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

            if (PCount > 0)
            {
                clsStandards.WriteLog(this, new Exception("Barcode Printed Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                txtReason.Text = "";
                return;
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
}
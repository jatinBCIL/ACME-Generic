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

public partial class frmDispensingSheet: System.Web.UI.Page
{

    public static string strFlg = "";
    DataTable dtImport = new DataTable();

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
                //clsStandards.fillCombobox(ddlPrinterName, objPrint.BL_PrinterCodes(clsStandards.current_Plant()), "PRINTERCODE");
            }
            catch (Exception ex)
            {
                clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
            finally
            {
                objPrint = null;
            }


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
            dtGrn = objBL.BL_GetDispensingSheetData(txtProcessOrderNo.Text.Trim(), "", "", "GET", clsStandards.current_Plant().ToString());
            if (dtGrn.Rows.Count > 0)
            {
                Session["DispDetails"] = dtGrn;
                lblMessage.Text = " ";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "No Details found for entered batch";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objBL = null;
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dtPrint = new DataTable();
        BL_PickList objGrn = new BL_PickList();
        try
        {
            dtPrint = objGrn.BL_GetDispHeaderData(txtProcessOrderNo.Text.Trim(), "", "", "GET", clsStandards.current_Plant().ToString());

            if (dtPrint.Rows.Count > 0)
            {
                Session["ProdCode"] = dtPrint.Rows[0]["ProdCode"].ToString();
                Session["ProductDesc"] = dtPrint.Rows[0]["ProductDesc"].ToString();
                Session["ProdBatch"] = dtPrint.Rows[0]["ProdBatch"].ToString();
                Session["MaterialBatch"] = dtPrint.Rows[0]["MaterialBatch"].ToString();
                Session["MfgDate"] = dtPrint.Rows[0]["MfgDate"].ToString();
                Session["ExpDate"] = dtPrint.Rows[0]["ExpDate"].ToString();
                Session["SlipNo"] = txtSlipNo.Text.Trim();
                Session["Stage"] = txtStage.Text.Trim();
                Session["Packing"] = txtPacking.Text.Trim();
                Session["Date"] = txtDate.Text.Trim();
                Session["BatchSize"] =double.Parse(dtPrint.Rows[0]["BatchSize"].ToString()).ToString();
                ScriptManager.RegisterStartupScript(btnPrint, this.GetType(), "OpenWindow", "window.open('" + Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute(System.Web.Configuration.WebConfigurationManager.AppSettings["Report"].ToString()) + "rptDispSheet" + ".aspx" + "','_newtab');", true);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objGrn = null;
        }
    }
    protected void GrGRNDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
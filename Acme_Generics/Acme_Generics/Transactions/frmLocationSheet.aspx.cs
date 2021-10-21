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

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> getArNo(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_PickList objPick = new BL_PickList();
        try
        {
            List<string> items = new List<string>();
            dt = objPick.BL_GetARNoDtl(prefixText, clsStandards.current_Plant());
            foreach (DataRow dr in dt.Rows)
            {
                items.Add(dr["MaterialBatch"].ToString());
            }
            return items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objPick = null;
        }
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> getBlockNo(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_PickList objPick = new BL_PickList();
        try
        {
            List<string> items = new List<string>();
            dt = objPick.BL_GetBlock(prefixText, clsStandards.current_Plant());
            foreach (DataRow dr in dt.Rows)
            {
                items.Add(dr["LOCNM"].ToString());
            }
            return items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objPick = null;
        }
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> getAreaName(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_PickList objPick = new BL_PickList();
        try
        {
            List<string> items = new List<string>();
            dt = objPick.BL_GetArea(prefixText, clsStandards.current_Plant());
            foreach (DataRow dr in dt.Rows)
            {
                items.Add(dr["WH_TYPE"].ToString());
            }
            return items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            objPick = null;
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
        DataTable dtPrintLoc = new DataTable();
        BL_PickList objGrn = new BL_PickList();
        int matType;
        try
        {
            if (rbRM.Checked == true) { matType = 1; } else { matType = 0;}

            dtPrint = objGrn.BL_GetLocSheetData(txtBinCode.Text.Trim(), txtBlockName.Text.Trim(), clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString().Trim(), txtAreaName.Text.Trim(), matType);

            foreach (DataRow dr in dtPrint.Rows)
            {
                string strLoc=string.Empty;
                dtPrintLoc = objGrn.BL_GetARNoLocDtl(dr["ARNo"].ToString(), clsStandards.current_Plant(), matType);
                foreach (DataRow subdr in dtPrintLoc.Rows)
                {
                    if (strLoc == string.Empty)
                    {
                        strLoc = subdr["LocationCode"].ToString();
                    }
                    else
                    {
                        strLoc = strLoc + "," + (strLoc.Contains(subdr["LocationCode"].ToString().Substring(0, subdr["LocationCode"].ToString().Length - 2)) ?
                            subdr["LocationCode"].ToString().Substring(subdr["LocationCode"].ToString().Length - 2) : subdr["LocationCode"].ToString());
                    }
                }
                dr["BIN"] = strLoc;
            }

            if (dtPrint.Rows.Count > 0)
            {
                Session["LocationDtl"] = dtPrint;

                if (rbRM.Checked == true) { Session["LocHeading"] = "LOCATION CHART OF RM"; }
                else { Session["LocHeading"] = "LOCATION CHART OF PM"; }

                Session["Block"] = txtBlockName.Text.Trim();
                Session["Area"] = txtAreaName.Text.Trim();
                lblMessage.Text = string.Empty;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterStartupScript(btnPrint, this.GetType(), "OpenWindow", "window.open('" + Request.Url.GetLeftPart(UriPartial.Authority) + "/" + ConfigurationManager.AppSettings["Website"].ToString() + "/Reports/" + "rptLocationSheet" + ".aspx" + "','_newtab');", true);  //replaced "/Reports/ inplace of VirtualPathUtility.ToAbsolute(System.Web.Configuration.WebConfigurationManager.AppSettings["Report"].ToString())
            }
            else
            {
                lblMessage.Text = "No data Found";
                lblMessage.ForeColor = System.Drawing.Color.Red;
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
    protected void txtArNo_TextChanged(object sender, EventArgs e)
    {
     ViewState["ArNo"] = txtBinCode.Text.Trim();
    }
}
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

public partial class frmGrn_OfflineUpdate : System.Web.UI.Page
{

    public static string strFlg = "";
    DataTable dtImport = new DataTable();

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> GetDocno(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_GrnPrinting objBL = new BL_GrnPrinting();
        try
        {
            List<string> Items = new List<string>();
            dt = objBL.BL_GetARDocumentNo(prefixText, "PRINT");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Items.Add(dt.Rows[i]["ARNo"].ToString());
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
        #region
   
        #endregion

        if (!IsPostBack)
        {

            BL_PrinterMaster objPrint = new BL_PrinterMaster();
            DataTable dt = new DataTable();
            DataTable dt_Plant = new DataTable();
            DataTable dt_AscPlant = new DataTable();
            DataSet ds = new DataSet();
            try
            {
               // clsStandards.fillCombobox(ddlPrinterName, objPrint.BL_PrinterCodes(clsStandards.current_Plant()), "PRINTERCODE");

            }
            catch (Exception ex)
            {
                clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
            finally
            {
                objPrint = null;
            }

           // strFlg = "ADD";


        }

    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        BL_GrnPrinting objBL = new BL_GrnPrinting();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetARDocumenDetails(txtDocumentNo.Text.Trim(), "PRINT");
            chkSelectAll.Checked=false;
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
    protected bool CheckPrinterCon(string strIP, string strPort)
    {
        try
        {
            return PrintDirect.CheckConnection(strIP, strPort);
        }
        catch (Exception ex)
        {
            return false;
            throw ex;
        }
       
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        BL_GrnPrinting objGrn = new BL_GrnPrinting();
        DataTable dt = new DataTable();
        int Count = 0;
        try
        {
            for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                if (cb.Checked == true)
                {
                    Count = Count + 1;
                    TextBox tb = (TextBox)GrGRNDetails.Rows[i].FindControl("txtTotalQty");
                    TextBox tb1 = (TextBox)GrGRNDetails.Rows[i].FindControl("txtNoofContainer");

                    if (objGrn.BL_SaveGRNErpStock(GrGRNDetails.Rows[i].Cells[1].Text,tb1.Text.Trim(), GrGRNDetails.Rows[i].Cells[4].Text, double.Parse(tb.Text.Trim())) == 1)
                    {
                        clsStandards.WriteLog(this, new Exception("Stock has been updated."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                        btnGet_Click(sender, e);
                    }
                    // if(objGrn.BL_SaveGRNErpStock(GrGRNDetails
                }
            }

            if (Count == 0)
            {
                clsStandards.WriteLog(this, new Exception("Select any Record"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Thread was being aborted"))
            {
             HttpContext.Current.Response.Redirect(ResolveUrl("~/Modules/frmMain.aspx"), false);
            }
            throw new Exception(ex.ToString());
        }
        finally
        {
            objGrn = null;
            dt = null;
        }
    }

    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        string strMaterialType = "";
        string strNoOfCont = "";
        try
        {
            if (GrGRNDetails.Rows.Count > 0)
            {
                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {

                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                    if (cb.Checked == true)
                    {
                        //strMaterialType = GrGRNDetails.Rows[i].Cells[15].Text.ToString();
                        //strNoOfCont = GrGRNDetails.Rows[i].Cells[13].Text.ToString();
                    }
                }
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
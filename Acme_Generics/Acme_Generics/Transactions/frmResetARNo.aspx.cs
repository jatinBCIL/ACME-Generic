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

public partial class frmResetARNo : System.Web.UI.Page
{

    public static string strFlg = "";
    DataTable dtImport = new DataTable();

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
   


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
              //  clsStandards.fillCombobox(ddlPrinterName, objPrint.BL_PrinterCodes(clsStandards.current_Plant()), "PRINTERCODE");

            }
            catch (Exception ex)
            {
                clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
            finally
            {
                objPrint = null;
            }
            //MultiView1.SetActiveView(View1);
            strFlg = "ADD";
            txtBarCodeNumber.Text = null;
            txtNewArNumber.Text = null;
            txtOldArNumber.Text = null;


        }

    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    private void clear()
    {
        txtBarCodeNumber.Text = null;
        txtNewArNumber.Text = null;
        txtOldArNumber.Text = null;
    }
   

    protected void Save_Click(object sender, EventArgs e)
    {
        BL_GrnPrinting objGrn = new BL_GrnPrinting();
       
        try
        {
            // strResult = objGrn.BL_ResetARNo(txtBarCodeNumber.Text.Trim(), txtOldArNumber.Text.Trim(), txtNewArNumber.Text.Trim(), clsStandards.current_Plant());
            objGrn.BL_ResetARNo(txtBarCodeNumber.Text.Trim(), txtOldArNumber.Text.Trim(), txtNewArNumber.Text.Trim(), clsStandards.current_Plant());
            
            clsStandards.WriteLog(this, new Exception("Reset Number has been completed. Old No. : " + txtOldArNumber.Text.Trim() + "New No. : "+ txtNewArNumber.Text.Trim()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
            
            clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            clear();
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

    
}
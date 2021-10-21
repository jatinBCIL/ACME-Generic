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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //BL_PrinterMaster objPrint = new BL_PrinterMaster();
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
                //objPrint = null;
            }
            MultiView1.SetActiveView(View1);
            strFlg = "ADD";


        }

    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void btnRepost_Click(object sender, EventArgs e)
    {
        BL_PickList objBL = new BL_PickList();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetDspensingConfirmation(txtBatchNo.Text.Trim(), "REPOST", clsStandards.current_Plant().ToString());
            if (dtGrn.Rows.Count > 0)
            {
                GrGRNDetails.DataSource = dtGrn;
                GrGRNDetails.DataBind();
            }
            else
            {
                GrGRNDetails.DataSource = null;
                GrGRNDetails.DataBind();
                // clsStandards.WriteLog(this, new Exception("No details found for document"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
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

    protected void btnGet_Click(object sender, EventArgs e)
    {
        BL_PickList objBL = new BL_PickList();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetDspensingConfirmation(txtBatchNo.Text.Trim(), "PRINT", clsStandards.current_Plant().ToString());
            if (dtGrn.Rows.Count > 0)
            {
                GrGRNDetails.DataSource = dtGrn;
                GrGRNDetails.DataBind();
            }
            else
            {
                GrGRNDetails.DataSource = null;
                GrGRNDetails.DataBind();
               // clsStandards.WriteLog(this, new Exception("No details found for document"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
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
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        DataTable dtPRint = new DataTable();
        BL_PickList objGrn = new BL_PickList();
        string strResult = "";

        try
        {
            if (GrGRNDetails.Rows.Count > 0)
            {
                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                    if (cb.Checked == true)
                    {
                        strResult = objGrn.BL_ConfirmPicking_Dispensing(GrGRNDetails.Rows[i].Cells[9].Text.ToString(), GrGRNDetails.Rows[i].Cells[6].Text.ToString(), GrGRNDetails.Rows[i].Cells[3].Text.ToString(), GrGRNDetails.Rows[i].Cells[2].Text.ToString(), GrGRNDetails.Rows[i].Cells[12].Text.Trim(), clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
                        if (strResult.StartsWith("0"))
                        {
                            objGrn.BL_ConfirmPicking_Dispensing_ERP(GrGRNDetails.Rows[i].Cells[9].Text.ToString(), GrGRNDetails.Rows[i].Cells[6].Text.ToString(), GrGRNDetails.Rows[i].Cells[3].Text.ToString(), GrGRNDetails.Rows[i].Cells[2].Text.ToString(), GrGRNDetails.Rows[i].Cells[12].Text.Trim(), clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString(), strResult.Split('|').GetValue(1).ToString());
                        }
                    }
                }

                if (strResult.StartsWith("0"))
                {
                    clsStandards.WriteLog(this, new Exception("Dispensing Confirmtation has been completed."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    btnGet_Click(sender, e);
                    return;
                }
            }
            else
            {
                clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, new Exception(ex.ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            dtPRint = null; objGrn = null;
        }
    }
}
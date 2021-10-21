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

public partial class frmArStockAdust : System.Web.UI.Page
{

    public static string strFlg = "";
    DataTable dtImport = new DataTable();

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> GetBatchNo(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_GrnPrinting objBL = new BL_GrnPrinting();
        try
        {
            List<string> Items = new List<string>();
            dt = objBL.BL_GetARNoDtl(prefixText, clsStandards.current_Plant());
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
            dtGrn = objBL.BL_GetStockDtl(txtBatchNo.Text.Trim(), clsStandards.current_Plant());
            chkSelectAll.Checked = false;
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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        DataTable dtPRint = new DataTable();
        string strResult;
        BL_GrnPrinting objGrn = new BL_GrnPrinting();
        int Count = 0;
        //int iPackSize = 0;
        try
        {
            if (GrGRNDetails.Rows.Count > 0)
            {
                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {


                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");

                    if (cb.Checked == true)
                    {

                        TextBox tb = (TextBox)GrGRNDetails.Rows[i].FindControl("txtContQty");
                        //iPackSize = Convert.ToInt32(txtPackQty.Text.Trim());
                        strResult = objGrn.BL_SaveArStock(GrGRNDetails.Rows[i].Cells[1].Text.Trim(), tb.Text.Trim());
                        if (strResult.StartsWith("0"))
                        {
                            Count = Count + 1;
                        }
                        // PrintDirect.Print_MaterialLabel(ddlPrinterName.Text.Trim(), clsStandards.current_Username().ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), dtPRint);
                    }
                }
                if (Count > 0)
                {
                    clsStandards.WriteLog(this, new Exception("Stock has been updated."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    btnGet_Click(sender, e);
                    return;
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

    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        string strMaterialType = "";
        try
        {
            if (GrGRNDetails.Rows.Count > 0)
            {
                //for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                //{

                //    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                //    if (cb.Checked == true)
                //    {
                //        strMaterialType = GrGRNDetails.Rows[i].Cells[15].ToString();
                //        if (strMaterialType == "RM")
                //        {
                //            pnlPackQty.Visible = false;
                //        }
                //        else
                //        {
                //            pnlPackQty.Visible = true;
                //        }
                //    }
                //}
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
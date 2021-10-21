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
        #region
        //if (!IsPostBack)
        //{
        //    ViewState["EDIT"] = null;
        //    BL_PlantMaster objPlant = new BL_PlantMaster();
        //    BL_DepartmentMaster objDepartment = new BL_DepartmentMaster();
        //    BL_UserMaster objMaster = new BL_UserMaster();
        //    DataTable dt_AscPlant = new DataTable();
        //    DataTable dt = new DataTable();
        //    DataTable dt_Plant = new DataTable();
        //    DataSet ds = new DataSet();
        //    try
        //    {



        //        ds = objMaster.BL_GetuserRols("");
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                cblTRole.Items.Add(ds.Tables[0].Rows[i][0].ToString());

        //            }

        //        }
        //        if (ds.Tables[1].Rows.Count > 0)
        //        {
        //            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //            {

        //                cblDRole.Items.Add(ds.Tables[1].Rows[i][0].ToString());
        //            }

        //        }
        //        //clsStandards.fillCombobox(ddPlantcode, objPlant.BL_Get_Plant(), "PLANTCODE");
        //        clsStandards.fillCombobox(ddPlantcode, objPlant.BL_Get_Plant_with_Desc(), "PLANTCODE");
        //        //   clsStandards.fillCombobox(ddDepartment, objDepartment.BL_GetDepartmentCode(), "DEPARTMENTCODE");

        //        //dt = objDepartment.BL_GetDepartmentCode();
        //        //if (dt.Rows.Count > 0)
        //        //{
        //        //    for (int i = 0; i < dt.Rows.Count; i++)
        //        //    {
        //        //        cblTDept.Items.Add(dt.Rows[i][0].ToString());
        //        //        cblDDept.Items.Add(dt.Rows[i][0].ToString());
        //        //    }
        //        //}

        //        dt_Plant = objPlant.BL_Get_Plant_with_Desc();

        //        dt_AscPlant = objPlant.BL_getAsc_Desc();
        //        if (dt_Plant.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt_Plant.Rows.Count; i++)
        //            {
        //                cblTPlant.Items.Add(dt_Plant.Rows[i][0].ToString());
        //                cblDPlant.Items.Add(dt_Plant.Rows[i][0].ToString());
        //            }
        //        }
        //        clsStandards.fillCombobox(ddlUserid, objMaster.BL_GetUserID(), "USER_ID");

        //        grPlant1.DataSource = null;
        //        grPlant1.DataBind();
        //        pnlImport.Visible = false;

        //        grdExcelRight.DataSource = null;
        //        grdExcelRight.DataBind();
        //        Panel1.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        //    }
        //    finally
        //    {
        //        objPlant = null;
        //    }
        //    MultiView1.SetActiveView(View2);
        //    strFlg = "ADD";
        //}
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
        BL_GrnPrinting objBL = new BL_GrnPrinting();
        DataTable dtGrn = new DataTable();
        try
        {
           // dtGrn = objBL.BL_GetDocumenDetails(txtDocumentNo.Text.Trim(), "REPRINT");
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
        BL_GrnPrinting objGrn = new BL_GrnPrinting();
        int iQty = 0;
        int iPackSize = 0;
        try
        {
            if (GrGRNDetails.Rows.Count > 0)
            {
                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {


                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                    if (cb.Checked == true)
                    {


                        //iPackSize = Convert.ToInt32(txtPackQty.Text.Trim());
                        dtPRint = objGrn.BL_GetBarcodeNo(GrGRNDetails.Rows[i].Cells[2].Text.Trim(), GrGRNDetails.Rows[i].Cells[3].Text.Trim(),
                            GrGRNDetails.Rows[i].Cells[5].Text.Trim(), GrGRNDetails.Rows[i].Cells[13].Text.Trim(), iPackSize.ToString(), clsStandards.current_Plant().ToString(), clsStandards.current_Username().ToString(), (GrGRNDetails.Rows[i].Cells[1].Text.Trim()), 0, "","");

                        PrintDirect.Print_MaterialLabel(ddlPrinterName.Text.Trim(), clsStandards.current_Username().ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), dtPRint);
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

    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        string strMaterialType = "";
        try
        {
            if (GrGRNDetails.Rows.Count > 0)
            {
                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {

                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                    if (cb.Checked == true)
                    {
                        strMaterialType = GrGRNDetails.Rows[i].Cells[15].ToString();
                        if (strMaterialType == "RM")
                        {
                            pnlPackQty.Visible = false;
                        }
                        else
                        {
                            pnlPackQty.Visible = true;
                        }
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
            throw new Exception(ex.ToString());
        }
        finally
        {
        }
    }

}
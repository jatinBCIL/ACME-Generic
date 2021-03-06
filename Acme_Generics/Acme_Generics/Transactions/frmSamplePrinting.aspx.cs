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
    public static List<string> GetARNo(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_SamplePrinting objBL = new BL_SamplePrinting();
        try
        {
            List<string> Items = new List<string>();
            dt = objBL.BL_GetARNumber(prefixText, "PRINT");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Items.Add(dt.Rows[i]["InwardNo"].ToString());
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
                trCont1.Visible = false;
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
        BL_SamplePrinting objBL = new BL_SamplePrinting();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetARDetails(txtARNo.Text.Trim(), "PRINT");
            if (dtGrn.Rows.Count > 0)
            {
                lblBatchNo.Text = dtGrn.Rows[0]["BatchNo"].ToString();
                lblGRNDate.Text = dtGrn.Rows[0]["GrnDate"].ToString();
                lblGRNNo.Text = dtGrn.Rows[0]["GRNNo"].ToString();
                lblMaterialCode.Text = dtGrn.Rows[0]["MaterialCode"].ToString();
                lblMaterialDesc.Text = dtGrn.Rows[0]["MaterialName"].ToString();
                //ViewState["MatType"] = dtGrn.Rows[0]["MaterialType"].ToString();
                lblTotalContainers.Text = dtGrn.Rows[0]["NoofContainer"].ToString();
            }
            else
            {

                clsStandards.WriteLog(this, new Exception("No details found for AR no."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);

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
        bool PFlag = false;
        DataTable dtPRint = new DataTable();
        BL_SamplePrinting objGrn = new BL_SamplePrinting();
        BL_PrinterMaster objPrint = new BL_PrinterMaster();
        int iQty = 0;
        int iPackSize = 0;
        string strIp, strPort;
        DataTable dt = new DataTable();
            
        try
        {
            dt = objPrint.BL_PrinterIPandPort(ddlPrinterName.Text.Trim(), clsStandards.current_Plant().ToString());

            if (dt.Rows.Count > 0)
            {
                strIp = dt.Rows[0][0].ToString();
                strPort = dt.Rows[0][1].ToString();

                //if (CheckPrinterCon(strIp, strPort) == false)
                //{
                //    clsStandards.WriteLog(this, new Exception("Printer is not connected. Please check IP and Port Number for '" + ddlPrinterName.Text + "'"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                //    return;
                //}
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Printer Details not found"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }

            if (rbPM.Checked == true)
            {
                foreach (string str in txtNoContainer.Text.Split(','))
                {
                    DataTable dt1 = new DataTable();

                    dt1 = objGrn.BL_GetSampleBarcodeNo(lblGRNNo.Text.Trim(), "", lblMaterialCode.Text.Trim()
                        , str, Convert.ToString("0"), clsStandards.current_Plant().ToString(), clsStandards.current_Username().ToString(), "SINGLE", "");

                    dtPRint.Merge(dt1);
                }

            }
            else
            {
                dtPRint = objGrn.BL_GetSampleBarcodeNo(lblGRNNo.Text.Trim(), "", lblMaterialCode.Text.Trim()
                            , lblTotalContainers.Text.Trim(), Convert.ToString("0"), clsStandards.current_Plant().ToString(), clsStandards.current_Username().ToString(), "PRINT", "");
            }
            PFlag = PrintDirect.Print_SampleLabelIP(ddlPrinterName.Text.Trim(), clsStandards.current_Username().ToString(), System.DateTime.Now.ToString("dd/MM/yy"),strIp,strPort, dtPRint);

            if (PFlag == true)
            {
                clsStandards.WriteLog(this, new Exception("Sample labels printed successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                clsBLCommon.ClearControl(txtARNo, lblMaterialDesc, lblMaterialCode, lblPrintername, lblTotalContainers, lblARNo, lblBatchNo, lblGRNDate, lblGRNNo);
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Problem in printing"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
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

    protected void rbRM_CheckedChanged(object sender, EventArgs e)
    {
        if (rbRM.Checked == true)
        {
            trCont1.Visible = false;
        }
    }

    protected void rbPM_CheckedChanged(object sender, EventArgs e)
    {
        if (rbPM.Checked == true)
        {
            trCont1.Visible = true;
        }
        else
        {
            trCont1.Visible = false;
        }

    }
}
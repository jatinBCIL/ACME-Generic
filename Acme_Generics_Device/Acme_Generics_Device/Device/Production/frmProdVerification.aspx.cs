using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PropertyLayer;
using BusinessLayer;
using System.Data;
using BusinessLayer;

public partial class frmPicking : System.Web.UI.Page
{
    /// <summary>
    /// Ref No : MM4
    /// Purpose : Picking.
    /// Created By : Sayali A Palav.
    /// Created On : 17 August 2016.
    /// Modified By : 
    /// Modified On :
    /// Comment : 
    /// </summary>
    /// 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BL_Dispensing objBL = new BL_Dispensing();
            try
            {
                ViewState["DISPTBL"] = "";
                clsStandards.fillCombobox(ddlBoothCode, objBL.BL_GetBoothCode(clsStandards.current_Plant().ToString()), "BOOTH");
                txtDispBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanBarcode.ClientID + "'); return DisableSplChars(event);");
                txtScanWeight.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanWeighing.ClientID + "'); return DisableSplChars(event);");
                txtBatchNo.Attributes.Add("onkeypress", "button_click(this,'" + this.btnBatchNo.ClientID + "'); return DisableSplChars(event);");
                clear();


            }
            catch (Exception ex)
            {
                clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
        }
    }

    public void clear()
    {
        //txtCubicle.Text = string.Empty;
        //txtPWONo.Text = string.Empty;
        ddlMaterialCode.Items.Clear();
        ddlMaterialCode.Items.Add("Select");
        ddlMaterialCode.SelectedValue = "Select";
        //txtDescp.Text = string.Empty;
        //ddlBatch.Items.Clear();
        //ddlBatch.Items.Add("Select");
        //ddlBatch.SelectedValue = "Select";
        //lblReq.Text = string.Empty;
        //ddlSuggestBin.Items.Clear();
        //ddlSuggestBin.Items.Add("Select");
        //ddlSuggestBin.SelectedValue = "Select";
        //txtBin.Text = string.Empty;
        //txtBarcode.Text = string.Empty;
        //lblCount.Text = "0";

    }


    protected void btnBatchNo_Click(object sender, EventArgs e)
    {
        BL_ProdVerification objBl = new BL_ProdVerification();
        DataTable dtmat = new DataTable();
        try
        {
            dtmat = objBl.BL_GetMaterialBatch(txtBatchNo.Text.Trim(), clsStandards.current_Plant().ToString(), txtDispBarcode.Text.Trim(), "GETDATA", ddlMaterialCode.Text.Trim());
            clsStandards.fillCombobox(ddlMaterialCode, dtmat, "MatCode");
            ViewState["DISPTBL"] = dtmat;
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Device/frmDevice_Main.aspx");
    }

    protected void btnimgClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Device/frmDevice_Main.aspx");
    }

    protected void btnScanBarcode_Click(object sender, EventArgs e)
    {
        DataTable dtmat = new DataTable();
        BL_ProdVerification objBl = new BL_ProdVerification();

        try
        {
            dtmat = objBl.BL_GetMaterialBatch(txtBatchNo.Text.Trim(), clsStandards.current_Plant().ToString(), txtDispBarcode.Text.Trim(), "VALIDATEBARCODE", ddlMaterialCode.Text.Trim());
            //clsStandards.fillCombobox(ddlMaterialCode, dtmat, "MatCode");
            //ViewState["DISPTBL"] = dtmat;
            if (dtmat.Rows.Count > 0)
            {
                if (dtmat.Columns.Count > 1)
                {
                    txtGrossWt.Text = dtmat.Rows[0][0].ToString();
                    txtNetWt.Text = dtmat.Rows[0][1].ToString();
                    txtTareWt.Text = dtmat.Rows[0][2].ToString();
                    lblUOM.Text = dtmat.Rows[0][3].ToString();
                    lblARNo.Text = dtmat.Rows[0][4].ToString();
                }
                else
                {
                    clsStandards.WriteLog(this, new Exception(dtmat.Rows[0][0].ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    return;
                }
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Problem in validating barcode"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }


        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        BL_ProdVerification objBl = new BL_ProdVerification();
        DataTable dtmat = new DataTable();
        try
        {
            dtmat = objBl.BL_GetMaterialBatch(txtBatchNo.Text.Trim(), clsStandards.current_Plant().ToString(), txtDispBarcode.Text.Trim(), "VERIFYBARCODE", ddlMaterialCode.Text.Trim());
            //clsStandards.fillCombobox(ddlMaterialCode, dtmat, "MatCode");
            //ViewState["DISPTBL"] = dtmat;
            if (dtmat.Rows.Count > 0)
            {
                clsStandards.WriteLog(this, new Exception(dtmat.Rows[0][0].ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Problem in Verifying barcode"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }


        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
    }


    protected void btnScanWeighing_Click(object sender, EventArgs e)
    {

        BL_Dispensing objBL = new BL_Dispensing();
        ViewState["Printer"] = "";
        string strResult = "";
        try
        {
            strResult = objBL.BL_ValidateBalanceCode(ddlBoothCode.Text.Trim().Split('-').GetValue(0).ToString(), txtScanWeight.Text.Trim(), "VALIDATE", clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                txtGrossWt.Focus();
            }
            else
            {
                clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                txtScanWeight.Text = "";
                txtScanWeight.Focus();

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

    protected void ddlMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        BL_PickList objBL = new BL_PickList();
        DataTable dt = new DataTable();
        DataTable dtNew = new DataTable();
        try
        {

            dt = (DataTable)ViewState["DISPTBL"];
            dtNew = dt.Clone();
            dtNew = dt.Select("Matcode = '" + ddlMaterialCode.Text.Trim().ToString() + "'").CopyToDataTable();

            dtNew.AcceptChanges();
            if (dtNew.Rows.Count > 0)
            {
                lblVerifyContainers.Text = dtNew.Rows[0][2].ToString() + "/" + dtNew.Rows[0][3].ToString();
            }


        }
        catch (Exception ex)
        {
        }


    }
}

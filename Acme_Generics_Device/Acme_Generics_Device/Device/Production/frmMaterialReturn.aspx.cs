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
               // clsStandards.fillCombobox(ddlBoothCode, objBL.BL_GetBoothCode(clsStandards.current_Plant().ToString()), "BOOTH");
                txtMRNBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanBarcode.ClientID + "'); return DisableSplChars(event);");
               // txtScanWeight.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanWeighing.ClientID + "'); return DisableSplChars(event);");
               // txtBatchNo.Attributes.Add("onkeypress", "button_click(this,'" + this.btnBatchNo.ClientID + "'); return DisableSplChars(event);");
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

    }


    protected void btnBatchNo_Click(object sender, EventArgs e)
    {
        BL_ProdVerification objBl = new BL_ProdVerification();
        DataTable dtmat = new DataTable();
        try
        {
           // dtmat = objBl.BL_GetMaterialBatch(txtBatchNo.Text.Trim(), clsStandards.current_Plant().ToString(), txtDispBarcode.Text.Trim(), "GETDATA", ddlMaterialCode.Text.Trim());
           // clsStandards.fillCombobox(ddlMaterialCode, dtmat, "MatCode");
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
        string strResult;
        BL_MRNLabel objBl = new BL_MRNLabel();

        try
        {
            strResult = objBl.BL_ValidateMRNBarcode(txtMRNBarcode.Text.Trim(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                lblMessage.Text = string.Empty;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblARNo.Text = strResult.Split('|').GetValue(2).ToString();
                lblMaterialCode.Text = strResult.Split('|').GetValue(3).ToString();
                lblMatDesc.Text = strResult.Split('|').GetValue(4).ToString();
                lblQty.Text = strResult.Split('|').GetValue(5).ToString();
            }
            else if (strResult.StartsWith("1"))
            {
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtMRNBarcode.Text = "";
                txtMRNBarcode.Focus();
            }
            else
            {
                txtMRNBarcode.Text = "";
                txtMRNBarcode.Focus();
                clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }

        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strResult;
        BL_MRNLabel objBl = new BL_MRNLabel();
        try
        {
           // Application.
            strResult = objBl.BL_SaveMRNBarcode(txtMRNBarcode.Text.Trim(),clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (!strResult.StartsWith("1"))
            {
                strResult = objBl.BL_SaveMRNBarcode_ERP(strResult.Split('|').GetValue(1).ToString(), strResult.Split('|').GetValue(2).ToString(),
                                                      strResult.Split('|').GetValue(3).ToString(), strResult.Split('|').GetValue(0).ToString(),
                                                      strResult.Split('|').GetValue(4).ToString(), txtMRNBarcode.Text.Trim(),
                                                      clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
                if (strResult.Split('|').GetValue(0).ToString() == "0")
                {
                    lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtMRNBarcode.Text = string.Empty;
                    lblARNo.Text = string.Empty;
                    lblMatDesc.Text = string.Empty;
                    lblMaterialCode.Text = string.Empty;
                    lblQty.Text = string.Empty;
                }
                else
                {
                    lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (strResult.StartsWith("1"))
            {
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
    }

}

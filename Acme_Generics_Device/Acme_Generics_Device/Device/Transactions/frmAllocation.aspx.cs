using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PropertyLayer;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Collections;

public partial class frm_FOR_Allocation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txtLocationCode.Focus();
            txtLocationCode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnGo.ClientID + "');");
            txtMaterialBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanMaterial.ClientID + "');");
        }
    }


    protected void btnGo_Click(object sender, EventArgs e)
    {
        BL_Allocation objBL = new BL_Allocation();
        string strResult = "";
        try
        {
            strResult = objBL.BL_ValidateBin(txtLocationCode.Text.Trim(), "", "LOCATIONCODE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                txtMaterialBarcode.Text = "";
                lblMessage.Text = "";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                txtMaterialBarcode.Focus();
            }
            else
            {
                txtMaterialBarcode.Text = "";
                txtLocationCode.Text = "";
                txtLocationCode.Focus();
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
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


    protected void btnScanMaterial_Click(object sender, EventArgs e)
    {
        BL_Allocation objBL = new BL_Allocation();
        string strResult = "";
        try
        {
            strResult = objBL.BL_ValidateBin(txtLocationCode.Text.Trim(), txtMaterialBarcode.Text.Trim(), "MATERIALBARCODE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblCount.Text = Convert.ToString(Convert.ToInt32(lblCount.Text.Trim()) + 1);
                txtMaterialBarcode.Text = "";
                txtMaterialBarcode.Focus();
            }
            else if (strResult.StartsWith("1"))
            {
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtMaterialBarcode.Text = "";
                lblMessage.Focus();
            }
            else
            {
                txtMaterialBarcode.Text = "";
                clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
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
            Response.Redirect("~/Device/frmDevice_Main.aspx", false);
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
        Response.Redirect("~/Device/frmDevice_Main.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtLocationCode.Text = "";
        txtMaterialBarcode.Text = "";
        txtLocationCode.Focus();
    }
}
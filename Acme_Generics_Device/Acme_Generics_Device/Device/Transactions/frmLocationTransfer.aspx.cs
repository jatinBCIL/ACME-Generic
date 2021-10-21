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

    //Modified By jagdish Joshi
    //Procedure change/Cs Change/Design Change/Font Change
    //On :25-12-2016


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txtToLocation.Attributes.Add("onkeypress", "button_click(this,'" + this.btnToGo.ClientID + "');");
            txtMaterialBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanMaterial.ClientID + "');");
        }

    }



    protected void btnFromGo_Click(object sender, EventArgs e)
    {
        BL_Allocation objBL = new BL_Allocation();
        string strResult = "";
        try
        {
            strResult = objBL.BL_ValidateBin_LocationTransfer(" ", txtToLocation.Text.Trim(), txtMaterialBarcode.Text.Trim(), "FROMLOCCODE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                txtToLocation.Text = "";
                txtToLocation.Focus();
                lblMessage.Text = "";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
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

    protected void btnToGo_Click(object sender, EventArgs e)
    {
        BL_Allocation objBL = new BL_Allocation();
        string strResult = "";
        try
        {
            strResult = objBL.BL_ValidateBin_LocationTransfer(" ", txtToLocation.Text.Trim(), txtMaterialBarcode.Text.Trim(), "TOLOCCODE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                txtMaterialBarcode.Focus();
                lblMessage.Text = "";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtToLocation.Text = "";
                txtToLocation.Focus();
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
            strResult = objBL.BL_ValidateBin_LocationTransfer(" ", txtToLocation.Text.Trim(), txtMaterialBarcode.Text.Trim(), "MATERIALBARCODE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString(); lblMessage.ForeColor = System.Drawing.Color.Green;
                lblCount.Text = Convert.ToString(Convert.ToInt32(lblCount.Text.Trim()) + 1);
                txtMaterialBarcode.Text = "";
                txtMaterialBarcode.Focus();
            }
            else
            {
                txtMaterialBarcode.Text = "";
                txtMaterialBarcode.Focus();
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtMaterialBarcode.Text = string.Empty;
        txtToLocation.Text = string.Empty;
        lblMessage.Text = String.Empty;
        lblMessage.ForeColor = System.Drawing.Color.Green;
        txtToLocation.Focus();
    }
    protected void Button1_Click(object sender, EventArgs e)
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
}
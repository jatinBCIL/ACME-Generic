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
            
            //txtFromLocationCode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnFromGo.ClientID + "');");
            txtToLocation.Attributes.Add("onkeypress", "button_click(this,'" + this.btnToGo.ClientID + "');");
            txtMaterialBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanMaterial.ClientID + "');");
        }
        //txtRack.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScan.ClientID + "'); return DisableSplChars(event);");
        //txtContiner.Attributes.Add("onkeypress", "button_click(this,'" + this.BtnScanContainer.ClientID + "'); return DisableSplChars(event);");

    }



    protected void btnFromGo_Click(object sender, EventArgs e)
    {
        BL_Allocation objBL = new BL_Allocation();
        string strResult = "";
        try
        {
            //strResult = objBL.BL_ValidateBin_LocationTransfer(txtFromLocationCode.Text.Trim(), txtToLocation.Text.Trim(), txtMaterialBarcode.Text.Trim(), "FROMLOCCODE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                //clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                txtMaterialBarcode.Text = "";
                txtMaterialBarcode.Focus();
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

    protected void btnToGo_Click(object sender, EventArgs e)
    {
        BL_Allocation objBL = new BL_Allocation();
        string strResult = "";
        try
        {
           // strResult = objBL.BL_ValidateBin_LocationTransfer(txtFromLocationCode.Text.Trim(), txtToLocation.Text.Trim(), txtMaterialBarcode.Text.Trim(), "TOLOCCODE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                //clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                txtMaterialBarcode.Text = "";
                txtMaterialBarcode.Focus();
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


    protected void btnScanMaterial_Click(object sender, EventArgs e)
    {
        BL_Allocation objBL = new BL_Allocation();
        string strResult = "";
        try
        {
            //strResult = objBL.BL_ValidateBin_LocationTransfer(txtFromLocationCode.Text.Trim(), txtToLocation.Text.Trim(), txtMaterialBarcode.Text.Trim(), "MATERIALBARCODE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                txtMaterialBarcode.Text = "";
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
}
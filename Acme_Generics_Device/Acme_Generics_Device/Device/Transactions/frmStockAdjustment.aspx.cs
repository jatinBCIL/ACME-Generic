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

public partial class frmStockAdjustment : System.Web.UI.Page
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
        try
        {

            if (!Page.IsPostBack)
            {
                txtBatchNo.Attributes.Add("onkeypress", "button_click(this,'" + this.btnGo.ClientID + "');");
                txtbin.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanBin.ClientID + "');");
               
            }
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
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

    protected void btnGo_Click(object sender, EventArgs e)
    {
        BL_PickList objBL = new BL_PickList();
        string str = "";
        DataTable dtDispensing = new DataTable();
        try
        {
            str = objBL.BL_StockAdjust(txtBatchNo.Text.Trim(), "0", "MATERIALBARCODE", clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());

            if (str.Split('|').GetValue(0).ToString() == "1")
            {
                lblMessage.Text = str.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtBatchNo.Text = "";
                txtBatchNo.Focus();
            }
            else
            {
                lblRemainingCount.Text = clsBLCommon.Qty(str.Split('|').GetValue(1).ToString());
                txtbin.Focus();
                lblMessage.Text = "";
                lblMessage.ForeColor = System.Drawing.Color.Green;
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

    protected bool validateControl()
    {
        try
        {
            if (txtBatchNo.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "Please Scan Material Barcode";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            } 
            if (txtReason.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "Please Enter Reason";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (txtbin.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "Please Enter Adjust Qty";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            lblMessage.Text = String.Empty;
            lblMessage.ForeColor = System.Drawing.Color.Green;
            return true;
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    protected void btnReverse_Click(object sender, EventArgs e)
    {
        BL_PickList objBL = new BL_PickList();
        string str = "";
        DataTable dtDispensing = new DataTable();
        try
        {
            if (validateControl())
            {
                str = objBL.BL_StockAdjust(txtBatchNo.Text.Trim(), txtbin.Text.Trim(), "ADJUST", clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());

                if (str.Split('|').GetValue(0).ToString() == "1")
                {
                    lblMessage.Text = str.Split('|').GetValue(1).ToString();
                    txtBatchNo.Text = "";
                    txtBatchNo.Focus();
                }
                else
                {
                    lblRemainingCount.Text = clsBLCommon.Qty(str.Split('|').GetValue(1).ToString());
                    txtbin.Focus();
                    lblMessage.Text = "";
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
    protected void btnScanBin_Click(object sender, EventArgs e)
    {
        BL_PickList objBL = new BL_PickList();
        string str = "";
        DataTable dtDispensing = new DataTable();
        try
        {
            str = objBL.BL_ValidateReversePicking(txtBatchNo.Text.Trim(), txtbin.Text.Trim(), "LOCATIONCODE", clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());

            if (str.Split('|').GetValue(0).ToString() == "1")
            {
                lblMessage.Text = str.Split('|').GetValue(1).ToString();
                txtbin.Text = "";
                txtbin.Focus();
            }
            else
            {
                lblMessage.Text = str.Split('|').GetValue(1).ToString();
                txtbin.Text = "";
                lblRemainingCount.Text = "";
                txtBatchNo.Text = "";
                txtBatchNo.Focus();
                
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
}

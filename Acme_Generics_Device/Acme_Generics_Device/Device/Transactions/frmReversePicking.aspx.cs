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
            str = objBL.BL_ValidateReversePicking(txtBatchNo.Text.Trim(), "", "MATERIALBARCODE", clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());

            if (str.Split('|').GetValue(0).ToString() == "1")
            {
                txtBatchNo.Text = "";
                lblMessage.Text = str.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Focus();
            }
            else
            {
                lblRemainingCount.Text = clsBLCommon.Qty(str.Split('|').GetValue(1).ToString());
                //txtbin.Focus();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "";
                lblMessage.Focus();
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


    protected void btnReverse_Click(object sender, EventArgs e)
    {
        BL_Dispensing objBL = new BL_Dispensing();
        DataTable dt = (DataTable)ViewState["Dispensing"];
        try
        {
            if (gvMaterial.Rows.Count > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < gvMaterial.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)gvMaterial.Rows[i].FindControl("chkSelect");

                    if (cb.Checked == true)
                    {
                       
                    }
                }

            }

        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
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
            str = objBL.BL_ValidateReversePicking(txtBatchNo.Text.Trim(), txtbin.Text.Trim(), "LOCATIONCODE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());

            if (str.Split('|').GetValue(0).ToString() == "1")
            {
                lblMessage.Text = str.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtbin.Text = "";
                lblMessage.Focus();
            }
            else
            {
                lblMessage.Text = str.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                txtbin.Text = "";
                lblRemainingCount.Text = "";
                txtBatchNo.Text = "";
                lblMessage.Focus();
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

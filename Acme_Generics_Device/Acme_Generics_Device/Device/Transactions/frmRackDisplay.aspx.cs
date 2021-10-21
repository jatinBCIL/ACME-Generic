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

public partial class frmRackDisplay : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtRackNo.Attributes.Add("onkeypress", "button_click(this,'" + this.btnGo.ClientID + "');");
            txtRackNo.Focus();
        }
       
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        BL_Allocation objBL = new BL_Allocation();
        DataTable dtGrn = new DataTable();
        try
        {
            lblScannedRack.Text = txtRackNo.Text;
            txtRackNo.Text = "";
            gvMaterial.DataSource = objBL.BL_GetRackDetails(lblScannedRack.Text, clsStandards.current_Plant());
            gvMaterial.DataBind();
            txtRackNo.Focus();
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
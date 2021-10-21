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
            txtBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnGo.ClientID + "'); return DisableSplChars(event);");
        }
       
    }



    protected void btnGo_Click(object sender, EventArgs e)
    {
        BL_SamplePrinting objBL = new BL_SamplePrinting();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetDisplayDetails(txtBarcode.Text.Trim(), clsStandards.current_Plant());
            Clear();
            if (dtGrn.Rows.Count > 0)
            {
                lblItem.Text = dtGrn.Rows[0]["MaterialCode"].ToString();
                lblItemName.Text = dtGrn.Rows[0]["MaterialName"].ToString();
                lblGRNNo.Text = dtGrn.Rows[0]["GRNNo"].ToString();
                lblExpDate.Text = dtGrn.Rows[0]["EXPDate"].ToString();
                lblMfgDate.Text = dtGrn.Rows[0]["MFGDate"].ToString();
                lblArNO1.Text = dtGrn.Rows[0]["ARNo"].ToString();
                lblBatch.Text = dtGrn.Rows[0]["InwardNo"].ToString();
                lblVBatch.Text = dtGrn.Rows[0]["BatchNo"].ToString();
                lblSupplier.Text = dtGrn.Rows[0]["SupplierName"].ToString();
                lblRetest.Text = dtGrn.Rows[0]["RETESTDATE"].ToString() != "1753-01-01" ? dtGrn.Rows[0]["RETESTDATE"].ToString() : "NA";
                lblMatType.Text = dtGrn.Rows[0]["MaterialType"].ToString();
                lblMFGName.Text = dtGrn.Rows[0]["ManufactureName"].ToString();
                lblContQty.Text = double.Parse(dtGrn.Rows[0]["ContainerQty"].ToString()).ToString();
                lblQCStatus.Text = dtGrn.Rows[0]["UDCODE"].ToString() == "1" ? "Approved" : "Undertest";
                lblLoc.Text = dtGrn.Rows[0]["LocationCode"].ToString();
                lblQCStatus.ForeColor = dtGrn.Rows[0]["UDCODE"].ToString() == "1" ? System.Drawing.Color.Green : System.Drawing.Color.Yellow;
            }
            else
            {
                lblResult.Text = "Invalid Barcode Scanned";
                lblResult.ForeColor = System.Drawing.Color.Red;
                txtBarcode.Text = string.Empty;
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

    private void ClearControls()
    {
        lblARNo.Text = "";
       // lblBatchNo.Text = "";
    }
    protected void btnScanMaterial_Click(object sender, EventArgs e)
    {
        BL_SamplePrinting objBL = new BL_SamplePrinting();
        DataTable dtGrn = new DataTable();
        try
        {
            //dtGrn = objBL.BL_GetBarcodeDetails(txtSampleBarcode.Text.Trim(), txtMaterialBarcode.Text.Trim(), "MATERIALBARCODE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (dtGrn.Rows.Count > 0)
            {
                clsStandards.WriteLog(this, new Exception(dtGrn.Rows[0][0].ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
            else
            {
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
    protected void Clear()
    {
        lblItem.Text = string.Empty;
        lblItemName.Text = string.Empty;
        lblGRNNo.Text = string.Empty;
        lblExpDate.Text = string.Empty;
        lblMfgDate.Text = string.Empty;
        lblBatch.Text = string.Empty;
        lblVBatch.Text = string.Empty;
        lblSupplier.Text = string.Empty;
        lblRetest.Text = string.Empty;
        lblMatType.Text = string.Empty;
        lblMFGName.Text = string.Empty;
        lblContQty.Text = string.Empty;
        lblQCStatus.Text = string.Empty;
    }
}
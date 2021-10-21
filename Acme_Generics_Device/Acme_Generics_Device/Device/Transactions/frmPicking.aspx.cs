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
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> GetPicklistNo(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_PickList objBL = new BL_PickList();
        try
        {
            List<string> Items = new List<string>();
            dt = objBL.BL_GetPicklist(prefixText, clsStandards.current_Plant().ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Items.Add(dt.Rows[i]["PICKLISTNO"].ToString());
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
        try
        {

            if (!Page.IsPostBack)
            {
                ViewState["PICKLIST"] = null;
                txtMaterialBarCode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanBarcode.ClientID + "'); return DisableSplChars(event);");
                txtBinCode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanBin.ClientID + "'); return DisableSplChars(event);");
                txtPicklistNo.Attributes.Add("onkeypress", "button_click(this,'" + this.btnPickList.ClientID + "'); return DisableSplChars(event);");
                clear();

            }
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
    }

    public void clear()
    {
        ddlMaterialCode.Items.Clear();
        ddlMaterialCode.Items.Add("Select");
        ddlMaterialCode.SelectedValue = "Select";

        ddlMatBatch.Items.Clear();
        ddlMatBatch.Items.Add("Select");
        ddlMatBatch.SelectedValue = "Select";

        //ddlSuggestedBin.Items.Clear();
        //ddlSuggestedBin.Items.Add("Select");
        //ddlSuggestedBin.SelectedValue = "Select";
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
        
        string strResult = "";
        BL_PickList objBL = new BL_PickList();
        try
        {

            if (txtPicklistNo.Text.Trim() == "")
            {
                clsStandards.WriteLog(this, new Exception("Please enter picklist no"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }

            strResult = objBL.BL_ValidatePicking(txtPicklistNo.Text.Trim(),txtBinCode.Text.Trim(), ddlMaterialCode.Text.Trim(), ddlMaterialCode.Text.Trim(), ddlMatBatch.Text.Trim(), txtMaterialBarCode.Text.Trim(), "VALIDATE", double.Parse(lblRequiredQty.Text), clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());

            if (strResult.StartsWith("2"))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                ClearControl();
                btnPickList_Click(sender, e);
            }
            
            else if (strResult.StartsWith("0"))
            {
                lblNoofContainers.Text = (Convert.ToInt32(lblNoofContainers.Text.Trim()) + 1).ToString();
                lblRequiredQty.Text = strResult.Split('|').GetValue(2).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "";
                txtMaterialBarCode.Text = "";
                lblMessage.Focus();
            }
            else
            {
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtMaterialBarCode.Text = "";
                lblMessage.Focus();
            }

        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
    }
    protected void ClearControl()
    {
        lblARNo.Text = "";
        //lblBatchNo.Text = "";
        ddlMatBatch.SelectedIndex = 0;
        lblMaterialDesc.Text = "";
        //lblCode.Text = "";
        txtMaterialBarCode.Text = "";
        txtBinCode.Text = "";
        LblQty.Text = "";
        lblRequiredQty.Text = "";
        lblNoofContainers.Text = "0";
        clear();
    }
    protected void btnScanBin_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {

            if (lblSBin.Text.Contains(txtBinCode.Text.Trim()))
            {
                lblMessage.Text = "";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                txtMaterialBarCode.Focus();
                return;
            }
            else
            {
                txtBinCode.Text = "";
                lblMessage.Text = "Invalid 'Bin' scanned. Please check 'Suggested Bin'";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Focus();
            }
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
    }

    protected void btnPickList_Click(object sender, EventArgs e)
    {
        lblNoofContainers.Text = "0";
        ViewState["PICKLIST"] = null;
        DataTable dtPickList = new DataTable();
        DataTable dtMatdt = new DataTable();
        BL_PickList objBL = new BL_PickList();
        try
        {
            ClearControl();

            if (txtPicklistNo.Text.Trim() == "")
            {
                clsStandards.WriteLog(this, new Exception("Please enter picklist no"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }

            dtPickList = objBL.BL_GetPickPicklist(txtPicklistNo.Text.Trim(), clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());
            dtMatdt = objBL.BL_GetPicklistMat(txtPicklistNo.Text.Trim(), clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());
            if (dtPickList.Rows.Count > 0)
            {
                //clsStandards.fillCombobox(ddlMaterialCode, dtPickList, "ProcessOrderNo");
                ViewState["PICKLIST"] = dtPickList;
            }
            if (dtMatdt.Rows.Count > 0)
            {
                clsStandards.fillCombobox(ddlMaterialCode, dtMatdt, "MATERIALCODE");
            }
            

        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
    }



    protected void ddlMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        BL_PickList objBL = new BL_PickList();
        DataTable dt = new DataTable();
        DataTable dtNew = new DataTable();
        try
        {
            if (ddlMaterialCode.Text != "Select")
            {
                dt = (DataTable)ViewState["PICKLIST"];
                dtNew = dt.Clone();
                dtNew = dt.Select("MATERIALCODE = '" + ddlMaterialCode.Text.Trim().ToString() + "'").CopyToDataTable();

                var chr = (from r in dtNew.AsEnumerable() select r["ARNo"]).Distinct().ToList();

                ddlMatBatch.Items.Clear();
                ddlMatBatch.Items.Add("Select");
                foreach (string str in chr)
                {
                    ddlMatBatch.Items.Add(str);
                }

                if (ddlMatBatch.Items.Count > 0)
                {
                    ddlMatBatch.SelectedIndex = 0;
                }

                dtNew.AcceptChanges();
            }
        }
        catch (Exception ex)
        {
        }


    }

    protected void ddlSuggestedBin_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            txtBinCode.Focus();
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    protected void getqty()
    {
        var chr = (from r in ((DataTable)ViewState["PICKLIST"]).Select("MATERIALCODE = '" + ddlMaterialCode.Text.Trim().ToString() + "' and MaterialBatch= '" +
                                      ddlMatBatch.Text.Trim() + "'").CopyToDataTable().AsEnumerable()
                   select r["MaterialBatch"]).Distinct().ToList();
    }
    protected string getQTY()
    {
        Double qty=0.000;
        var chr = (from r in ((DataTable)ViewState["PICKLIST"]).Select("MATERIALCODE = '" + ddlMaterialCode.Text.Trim().ToString() + "' and ARNo= '" +
                                      ddlMatBatch.Text.Trim() + "'").CopyToDataTable().AsEnumerable()
                   select r["Quantity"]).Distinct().ToList();
        for (int i = 0; i < chr.Count; i++)
        {
            qty = qty + double.Parse(chr[i].ToString());
        }

        return qty.ToString();
    }
    protected void getBin()
    {
        
        var chr = (from r in ((DataTable)ViewState["PICKLIST"]).Select("MATERIALCODE = '" + ddlMaterialCode.Text.Trim().ToString() + "' and MaterialBatch= '" +
                                      ddlMatBatch.Text.Trim() + "'").CopyToDataTable().AsEnumerable()
                   select r["BinCode"]).Distinct().ToList();

        //ddlSuggestedBin.Items.Clear();
        //ddlSuggestedBin.Items.Add("Select");
        foreach (string str in chr)
        {
          //  ddlSuggestedBin.Items.Add(str);
        }

        //if (ddlSuggestedBin.Items.Count > 0)
        //{
        //    ddlSuggestedBin.SelectedIndex = 0;
        //}


    }
    protected void ddlMatBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BL_PickList objBL = new BL_PickList();
        DataTable dt = new DataTable();
        DataTable dtNew = new DataTable();
        try
        {
            if (ddlMatBatch.Text != "Select")
            {
                dt = (DataTable)ViewState["PICKLIST"];
                dtNew = dt.Clone();
                dtNew = dt.Select("MATERIALCODE = '" + ddlMaterialCode.Text.Trim().ToString() + "' and ARNo= '" + ddlMatBatch.Text.Trim() + "'").CopyToDataTable();

                

                dtNew.AcceptChanges();
                if (dtNew.Rows.Count > 0)
                {
                    //lblCode.Text = dtNew.Rows[0]["MaterialCode"].ToString();
                    lblMaterialDesc.Text = dtNew.Rows[0]["MaterialName"].ToString();
                    lblARNo.Text = dtNew.Rows[0]["ARNo"].ToString();
                    // lblBatchNo.Text = dtNew.Rows[0]["MaterialBatch"].ToString();
                    lblSBin.Text = dtNew.Rows[0]["BinCode"].ToString();
                    LblQty.Text = getQTY();
                    lblRequiredQty.Text = clsBLCommon.Qty(dtNew.Rows[0]["QTY"].ToString());
                    //clsStandards.fillCombobox(ddlSuggestedBin, dtNew, "BinCode");
                    //getBin();
                    clsBLCommon.ClearControl(txtMaterialBarCode, txtBinCode);
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnPick_Click(object sender, EventArgs e)
    {
        lblNoofContainers.Text = "0";
        ViewState["PICKLIST"] = null;
        DataTable dtPickList = new DataTable();
        DataTable dtMatdt = new DataTable();
        BL_PickList objBL = new BL_PickList();
        try
        {
            ClearControl();

            if (txtPicklistNo.Text.Trim() == "")
            {
                clsStandards.WriteLog(this, new Exception("Please enter picklist no"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }

            dtPickList = objBL.BL_GetPickPicklist(txtPicklistNo.Text.Trim(), clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());
            dtMatdt = objBL.BL_GetPicklistMat(txtPicklistNo.Text.Trim(), clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());
            if (dtPickList.Rows.Count > 0)
            {
                //clsStandards.fillCombobox(ddlMaterialCode, dtPickList, "ProcessOrderNo");
                ViewState["PICKLIST"] = dtPickList;
            }
            if (dtMatdt.Rows.Count > 0)
            {
                clsStandards.fillCombobox(ddlMaterialCode, dtMatdt, "MATERIALCODE");

                if (ddlMaterialCode.Items.Count > 1)
                {
                    ddlMaterialCode.SelectedIndex = 1;
                    ddlMaterialCode_SelectedIndexChanged(sender, e);
                }
            }


        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }

    }
}

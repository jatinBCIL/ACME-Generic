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
            BL_Dispensing objBL = new BL_Dispensing();
            try
            {
                ViewState["Printer"] = "";
                ViewState["Dispensing"] = null;
                //string[] CONATINERN = new string();
                //txtBatchNo.Attributes.Add("onkeypress", "button_click(this,'" + this.btnGo.ClientID + "');");
                txtMaterialBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanMaterial.ClientID + "');");
                //txtWeighingBalance.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanWeighing.ClientID + "');");
                MultiView1.SetActiveView(View1);
                //clsStandards.fillCombobox(ddlBooth, objBL.BL_GetBoothCode(clsStandards.current_Plant().ToString()), "BOOTH");
            }
            catch (Exception ex)
            {
            }
            finally
            {

            }
        }
        //txtRack.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScan.ClientID + "'); return DisableSplChars(event);");
        //txtContiner.Attributes.Add("onkeypress", "button_click(this,'" + this.BtnScanContainer.ClientID + "'); return DisableSplChars(event);");

    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        BL_Dispensing objBL = new BL_Dispensing();
        DataTable dtDispensing = new DataTable();
        try
        {
            //dtDispensing = objBL.BL_GetDispensingDtl(txtBatchNo.Text.Trim(), clsStandards.current_Plant().ToString());
            if (dtDispensing.Rows.Count > 0)
            {
                ViewState["Dispensing"] = dtDispensing;
                //gvMaterial.DataSource = dtDispensing;
                //gvMaterial.DataBind();
            }
            else
            {

                clsStandards.WriteLog(this, new Exception("No details found for AR no."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);

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

    public void btnScanBalance_Click(object sender, EventArgs e)
    {
        BL_Dispensing objBL = new BL_Dispensing();
        ViewState["Printer"] = "";
        string strResult = "";
        try
        {
            //strResult = objBL.BL_ValidateBalanceCode(ddlBooth.Text.Trim().Split('-').GetValue(0).ToString(), txtWeighingBalance.Text.Trim(), "VALIDATE", clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                if (strResult.Split('|').GetValue(1).ToString() == "NA")
                {
                    clsStandards.WriteLog(this, new Exception("Printer not maintained against this weighing ID"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    return;
                }
                else
                {
                    ViewState["Printer"] = strResult.Split('|').GetValue(1).ToString();
                }
               // txtNetWt.Focus();
            }
            else
            {
                clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                //txtWeighingBalance.Text = "";
                //txtWeighingBalance.Focus();

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
        //lblARNo.Text = "";
        //lblBatchNo.Text = "";
    }

    protected void btnScanMaterial_Click(object sender, EventArgs e)
    {
        BL_Dispensing objBL = new BL_Dispensing();
        string strResult = "";
        try
        {
           // strResult = objBL.BL_ValidateBarcodeDispensing(txtMaterialBarcode.Text.Trim(), lblMaterial.Text.Trim().Split('/').GetValue(0).ToString(), txtBatchNo.Text.Trim(), "VALIDATE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
               // txtWeighingBalance.Focus();
            }
            else
            {
                clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                txtMaterialBarcode.Text = "";
                txtMaterialBarcode.Focus();
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

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        BL_Dispensing objDisp = new BL_Dispensing();
        DataTable dtPrint = new DataTable();
        bool bFlag = false;
        try
        {
            if (ViewState["Printer"].ToString().Trim() == "")
            {
                clsStandards.WriteLog(this, new Exception("Please select printer"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }
           // dtPrint = objDisp.BL_PrintDispensingBarcode(ddlBooth.Text.Trim().Split('-').GetValue(0).ToString(), txtBatchNo.Text.Trim(), lblMaterial.Text.Trim().Split('/').GetValue(0).ToString(), ddlUnit.Text.Trim(), txtMaterialBarcode.Text.Trim(), txtWeighingBalance.Text.Trim(), Convert.ToDecimal(txtGrossWt.Text.Trim()), Convert.ToDecimal(txtTareWt.Text.Trim()), Convert.ToDecimal(txtNetWt.Text.Trim()), clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());
            if (dtPrint.Rows.Count > 0)
            {
                if (dtPrint.Columns.Count > 1)
                {

                    bFlag = PrintDirect.Print_DispenseRawLabel(
                           ViewState["Printer"].ToString().Trim(),
                           dtPrint.Rows[0]["BarcodeNo"].ToString(),
                            dtPrint.Rows[0]["MatCode"].ToString(),
                           dtPrint.Rows[0]["MatDesc"].ToString(),
                           dtPrint.Rows[0]["MaterialBatch"].ToString(),
                           dtPrint.Rows[0]["MfgDate"].ToString(),
                           dtPrint.Rows[0]["ExpDate"].ToString(),
                           dtPrint.Rows[0]["ProcessOrder"].ToString(),
                           dtPrint.Rows[0]["ProdCode"].ToString(),
                           dtPrint.Rows[0]["ProdBatch"].ToString(),
                           dtPrint.Rows[0]["ProductDesc"].ToString(),
                          Convert.ToDecimal(dtPrint.Rows[0]["GrossWt"].ToString()),
                            Convert.ToDecimal(dtPrint.Rows[0]["NetWt"].ToString()),
                            Convert.ToDecimal(dtPrint.Rows[0]["TareWt"].ToString()),
                           dtPrint.Rows[0]["CreatedBy"].ToString(),
                           dtPrint.Rows[0]["CreatedOn"].ToString(),
                           dtPrint.Rows[0]["UOM"].ToString(),
                           dtPrint.Rows[0]["PlantCode"].ToString(),
                           dtPrint.Rows[0]["BatchSize"].ToString(),
                           dtPrint.Rows[0]["ARNo"].ToString(),
                           dtPrint.Rows[0]["ContainerNo"].ToString(),
                           "","","","");

                    if (bFlag == true)
                    {
                        clsStandards.WriteLog(this, new Exception("Barcode Printed Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                        //txtGrossWt.Text = "";
                        //txtNetWt.Text = "";
                        //txtTareWt.Text = "";
                        //txtGrossWt.Focus();
                        return;
                    }
                    else
                    {
                        clsStandards.WriteLog(this, new Exception("Transaction Failed"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                        return;
                    }
                }
                else
                {
                    clsStandards.WriteLog(this, new Exception(dtPrint.Rows[0][0].ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    //txtGrossWt.Focus();
                    return;

                }
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Problem in printing"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
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

    protected string GetSelectedRecords(GridView grid)
    {
        int iSelect = 0, iIndex = 0;
        foreach (GridViewRow row in grid.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkSelect") as CheckBox);
                if (chkRow.Checked)
                {
                    iSelect++;
                    iIndex = row.RowIndex;
                }
            }
        }

        return iSelect.ToString() + "~" + iIndex.ToString();
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        BL_Dispensing objBL = new BL_Dispensing();
        DataTable dt = (DataTable)ViewState["Dispensing"];
        try
        {
            //if (gvMaterial.Rows.Count > 0 && dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < gvMaterial.Rows.Count; i++)
            //    {
            //        CheckBox cb = (CheckBox)gvMaterial.Rows[i].FindControl("chkSelect");

            //        if (cb.Checked == true)
            //        {
            //            DataRow[] dr = dt.Select("MaterialCode='" + gvMaterial.Rows[i].Cells[1].Text.ToString() + "' AND MaterialBatch='" + gvMaterial.Rows[i].Cells[3].Text.ToString() + "'");
            //            if (dr.Length > 0)
            //            {
            //                lblARno.Text = dr[0][8].ToString();
            //                lblMaterial.Text = dr[0][5].ToString() + " / " + dr[0][6].ToString();
            //                lblQty.Text = dr[0][9].ToString();
            //                lblRemQty.Text = dr[0][9].ToString();
            //                lblScanQty.Text = dr[0][9].ToString();
            //                lblUom.Text = dr[0][10].ToString();
            //                clsStandards.fillCombobox(ddlUnit, dt, "UOM");
            //                MultiView1.SetActiveView(View2);
            //            }
            //        }
            //    }

            //}

        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
        }
    }

    protected void txtGrossWt_TextChanged(object sender, EventArgs e)
    {
        //try
        //{

        //    if (txtTareWt.Text != "" && txtGrossWt.Text != "")
        //    {
        //        txtNetWt.Text = (Convert.ToDecimal(txtGrossWt.Text.Trim()) - Convert.ToDecimal(txtTareWt.Text.Trim())).ToString();
        //    }

        //}
        //catch (Exception ex)
        //{
        //    clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        //}
        //finally
        //{

        //}
    }

    protected void txtTareWt_TextChanged(object sender, EventArgs e)
    {

        try
        {
            //if (txtTareWt.Text != "" && txtGrossWt.Text != "")
            //{
            //    txtNetWt.Text = (Convert.ToDecimal(txtGrossWt.Text.Trim()) - Convert.ToDecimal(txtTareWt.Text.Trim())).ToString();
            //}
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {

        }
    }

    private void clearControls()
    {
        //lblARno.Text = "";
        //lblMaterial.Text = "";
        //lblQty.Text = "";
        //lblRemQty.Text = "";
        //lblScanQty.Text = "";
        //lblUom.Text = "";
        //ddlBooth.SelectedIndex = 0; ;
        //ddlUnit.Items.Clear();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        clearControls();
        btnNext.Focus();
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
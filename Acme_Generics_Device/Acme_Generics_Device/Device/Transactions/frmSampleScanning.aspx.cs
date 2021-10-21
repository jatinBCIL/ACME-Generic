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
using System.Text.RegularExpressions;

public partial class frm_FOR_Allocation : System.Web.UI.Page
{

    //Modified By jagdish Joshi
    //Procedure change/Cs Change/Design Change/Font Change
    //On :25-12-2016


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SqlDataLayer objSql = new SqlDataLayer();
            txtSampleBarcode.Focus();
            //string[] CONATINERN = new string();
            txtSampleBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnGo.ClientID + "');");
            txtMaterialBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanMaterial.ClientID + "');");
            txtbalance.Attributes.Add("onkeypress", "button_click(this,'" + this.btnBalance.ClientID + "');");
            txtSQty.Enabled = false;
            txtCompWt.Enabled = false;
            txtMLTWt.Enabled = false;
            ddlUOM.Enabled = false;
            clsStandards.fillCombobox(cboPrinter, objSql.ExecuteDataset(objSql.strLocal, "SELECT DISTINCT PRINTERCODE FROM [dbo].[tblPPPrinter_M] WHERE PLANTCODE = '" + clsStandards.current_Plant() + "'").Tables[0], "PRINTERCODE");
        }
    }



    protected void btnGo_Click(object sender, EventArgs e)
    {
        BL_SamplePrinting objBL = new BL_SamplePrinting();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetBarcodeDetails(txtSampleBarcode.Text.Trim(), "", "SAMPLEBARCODE", clsStandards.current_Username().ToString(), "0", "0", "0", clsStandards.current_Plant().ToString(),ddlUOM.Text.Trim());
            if (dtGrn.Rows.Count > 0)
            {
                if (dtGrn.Rows[0][0].ToString().Split('|').GetValue(0).ToString() != "1")
                {

                    lblBatchNo.Text = dtGrn.Rows[0]["InwardNo"].ToString();
                    //lblGRNDate.Text = dtGrn.Rows[0]["GrnDate"].ToString();
                    lblGRNNo.Text = dtGrn.Rows[0]["GRNNo"].ToString() + " - " + DateTime.Parse(dtGrn.Rows[0]["GrnDate"].ToString()).ToString("dd/MM/yyy");
                    lblMaterialCode.Text = dtGrn.Rows[0]["MaterialCode"].ToString();
                    lblMaterialDesc.Text = dtGrn.Rows[0]["MaterialName"].ToString();
                    lblTotalContainers.Text = dtGrn.Rows[0]["NoofContainer"].ToString();
                    ViewState["ARNO"] = dtGrn.Rows[0]["ARNO"].ToString();
                    ViewState["GRNDATE"] = DateTime.Parse(dtGrn.Rows[0]["GrnDate"].ToString()).ToString("dd/MM/yyy");
                    ViewState["GRNNO"] = dtGrn.Rows[0]["GRNNo"].ToString();
                    ViewState["BATCHNO"] = dtGrn.Rows[0]["BatchNo"].ToString();
                    ViewState["Count"] = dtGrn.Rows[0]["LabelCount"].ToString() + " of " + dtGrn.Rows[0]["NoofContainer"].ToString();
                    lblMessage.Text = "";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtMaterialBarcode.Focus();
                }
                else
                {
                    lblMessage.Text = dtGrn.Rows[0][0].ToString().Split('|').GetValue(1).ToString();
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Focus();
                    txtSampleBarcode.Text = string.Empty;
                }
            }
            else
            {

                clsStandards.WriteLog(this, new Exception("No details found for Scanned Barcode"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                txtSampleBarcode.Focus();
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
        lblBatchNo.Text = "";
        lblGRNNo.Text = "";
        lblMaterialBarcode.Text = "";
        lblMaterialCode.Text = "";
        lblMaterialDesc.Text = "";
        lblTotalContainers.Text = "";
        txtMaterialBarcode.Text = "";
        txtSampleBarcode.Text = "";
        txtSQty.Text = string.Empty;
        txtSampleBarcode.Focus();
        txtCompWt.Text = "";
        txtMLTWt.Text = "";
        ddlUOM.Enabled = false;
    }
    protected void btnScanMaterial_Click(object sender, EventArgs e)
    {
        BL_SamplePrinting objBL = new BL_SamplePrinting();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetBarcodeDetails(txtSampleBarcode.Text.Trim(), txtMaterialBarcode.Text.Trim(), "VALBARCODE", clsStandards.current_Username().ToString(), "0", "0", "0", clsStandards.current_Plant().ToString(), ddlUOM.Text.Trim());
            if (dtGrn.Rows.Count > 0)
            {
                if (dtGrn.Rows[0][0].ToString().Split('|').GetValue(0).ToString() == "0")
                {
                    txtSQty.Focus();
                    lblMessage.Text = string.Format("{0}  {1}",clsStandards.getRound(dtGrn.Rows[0][0].ToString().Split('|').GetValue(2).ToString(),3 ), 
                                      dtGrn.Rows[0][0].ToString().Split('|').GetValue(3).ToString());
                    ddlUOM.Text = dtGrn.Rows[0][0].ToString().Split('|').GetValue(3).ToString();
                    ViewState["SUOM"] = dtGrn.Rows[0][0].ToString().Split('|').GetValue(3).ToString();
                    ddlUOM.SelectedValue = dtGrn.Rows[0][0].ToString().Split('|').GetValue(3).ToString();
                    ViewState["Sqty"] = dtGrn.Rows[0][0].ToString().Split('|').GetValue(2).ToString();
                    ddlUOM.Enabled = true;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Focus();
                }
                else
                {

                    lblMessage.Text = dtGrn.Rows[0][0].ToString().Split('|').GetValue(1).ToString();
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Focus();
                }
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Problem in updation"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                lblMessage.Text = "There is some Problem";
                txtMaterialBarcode.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objBL = null;
            dtGrn = null;
        }
    }

    protected string getGMQty()
    {
        if (ViewState["SUOM"].ToString() == "NOS")
        {
            if (ViewState["SUOM"].ToString() != ddlUOM.Text.Trim())
            {
                return string.Empty;
            }
        }
        if (ddlUOM.Text == "GM")
        {
            return (double.Parse(txtSQty.Text) / 1000).ToString();
        }

        return txtSQty.Text.Trim();
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        BL_SamplePrinting objBL = new BL_SamplePrinting();
        DataTable dtGrn = new DataTable();
        DataTable dtPrint = new DataTable();
        double b;
        string strSqty;
        try
        {
            if (cboPrinter.Text.Trim() == "Select")
            {
                lblMessage.Text = "Please Select Printer";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Focus();
                return;
            }

            if (double.TryParse(txtSQty.Text, out b) == false)
            {
                lblMessage.Text = "Enter Valid Qty";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Focus();
                txtSQty.Text = string.Empty;
                return;
            }
            else
            {
                lblMessage.Text = string.Empty;
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }

            if (double.Parse(txtSQty.Text.Trim()) > double.Parse(ViewState["Sqty"].ToString()))
            {
                lblMessage.Text = "Container Qty is : " + double.Parse(ViewState["Sqty"].ToString()).ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtSQty.Text = string.Empty;
                lblMessage.Focus();
                return;
            }
            else
            {
                lblMessage.Text = string.Empty;
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }

            strSqty = getGMQty();

            if (strSqty == string.Empty)
            {
                lblMessage.Text = "Base UOM is NOS. Please select correct UOM.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                lblMessage.Text = string.Empty;
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }

            dtGrn = objBL.BL_GetBarcodeDetails(txtSampleBarcode.Text.Trim(), txtMaterialBarcode.Text.Trim(), "MATERIALBARCODE", clsStandards.current_Username().ToString(), strSqty, txtCompWt.Text, txtMLTWt.Text, clsStandards.current_Plant().ToString(), ddlUOM.Text.Trim()  );
            if (dtGrn.Rows.Count > 0)
            {
                dtPrint = objBL.BL_GetPrinter(cboPrinter.Text, clsStandards.current_Plant());

                if (dtPrint.Rows.Count > 0)
                {
                    if (PrintDirect.CheckConnection(dtPrint.Rows[0]["PRINTERIP"].ToString(), dtPrint.Rows[0]["PRINTERPORT"].ToString()) == false)
                    {
                        lblMessage.Text = "Printer is not connected";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        lblMessage.Text = string.Empty;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    lblMessage.Text = "Printer Details not found Select Correct Printer";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                //clsStandards.WriteLog(this, new Exception(dtGrn.Rows[0][0].ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                PrintDirect.PrintSampleLabel(lblMaterialDesc.Text, lblMaterialCode.Text, ViewState["BATCHNO"].ToString(), ViewState["ARNO"].ToString(), ViewState["GRNNO"].ToString(), ViewState["GRNDATE"].ToString().ToString(), txtSQty.Text, txtCompWt.Text, txtMLTWt.Text, clsStandards.current_User(), System.DateTime.Now.ToString("dd/MM/yy"), txtSampleBarcode.Text, dtPrint.Rows[0]["PRINTERIP"].ToString(), dtPrint.Rows[0]["PRINTERPORT"].ToString(), cboPrinter.Text, ddlUOM.Text.Trim(), ViewState["Count"].ToString() );
                lblMessage.Text = dtGrn.Rows[0][0].ToString();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ClearControls();
            }
            else
            {
                //clsStandards.WriteLog(this, new Exception("Problem in updation"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                lblMessage.Text = "Problem in updation";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally
        {
            objBL = null;
            dtGrn = null;
        }

    }
    protected void chkManual_CheckedChanged(object sender, EventArgs e)
    {
        if (chkManual.Checked == true)
        {
            txtbalance.Enabled = false;
            txtSQty.Enabled = true;
            txtCompWt.Enabled = true;
            txtMLTWt.Enabled = true;
        }
        else
        {
            txtbalance.Enabled = true;
            txtSQty.Enabled = false;
            txtCompWt.Enabled = false;
            txtMLTWt.Enabled = false;
        }
    }
    protected void btnBalance_Click(object sender, EventArgs e)
    {
        BL_SamplePrinting objBL = new BL_SamplePrinting();
        string strResult = "";
        try
        {
            strResult = objBL.BL_ValidateSampBalance(txtbalance.Text.Trim(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                ViewState["IPADDRESS"] = strResult.Split('|').GetValue(1).ToString();
                ViewState["PORT"] = strResult.Split('|').GetValue(2).ToString();
                ViewState["UOM"] = strResult.Split('|').GetValue(3).ToString();
                strResult = getWeight(ViewState["IPADDRESS"].ToString(), ViewState["PORT"].ToString());
                if (strResult != "Balance is not connected." && strResult != string.Empty)
                {
                    if (chkCont.Checked == true)
                    {
                        txtSQty.Text = clsStandards.getRound(ViewState["UOM"].ToString() == "GM" ? clsStandards.getGMtoKG(strResult) : strResult, 3);
                        txtSQty.Text = txtSQty.Text == "000" ? string.Empty : txtSQty.Text;
                    }
                    else if (chkCompWt.Checked == true)
                    {
                        txtCompWt.Text = clsStandards.getRound(ViewState["UOM"].ToString() == "GM" ? clsStandards.getGMtoKG(strResult) : strResult, 3);
                        txtCompWt.Text = txtSQty.Text == "000" ? string.Empty : txtCompWt.Text;
                    }
                    else if (chkMLTWt.Checked == true)
                    {
                        txtMLTWt.Text = clsStandards.getRound(ViewState["UOM"].ToString() == "GM" ? clsStandards.getGMtoKG(strResult) : strResult, 3);
                        txtMLTWt.Text = txtSQty.Text == "000" ? string.Empty : txtMLTWt.Text;
                    }

                    // txtSQty.Text = strResult;
                    lblMessage.Text = string.Empty;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    if (chkCont.Checked == true)
                    {
                        txtSQty.Text = string.Empty;
                    }
                    else if (chkCompWt.Checked == true)
                    {
                        txtCompWt.Text = string.Empty;
                    }
                    else if (chkMLTWt.Checked == true)
                    {
                        txtMLTWt.Text = string.Empty;
                    }
                    lblMessage.Text = strResult;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                
            }
            else
            {
                lblMessage.Text=string.Format("{0} : {1}",strResult.Split('|').GetValue(1).ToString(),txtbalance.Text.Trim());
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Focus();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
        finally 
        {
            objBL = null;
        }
    }

    private string getWeight(string WeighID, string Port)
    {
        clsWeighing objServer = new clsWeighing();
        string strResult = string.Empty;

        try
        {
            if ((objServer.InitializeTCPIPClient(WeighID, Port) == 1))
            {
                clsStandards.WriteLog(this, new Exception("Not Connected"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return "Balance is not connected.";
            }
            else
            {
                strResult = objServer.ReceiveDataFromServer();
                strResult = Regex.Replace(strResult.ToString(), "[^0-9. ]", "").Trim();
                return strResult.Trim();  //objServer.Calculate_Weight(strResult).ToString();
            }

        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, new Exception("Not Connected"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            throw new Exception(ex.ToString());
        }
        finally
        {
            objServer = null;
        }
    }
    protected void ddlUOM_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUOM.Text == "NOS")
        {
            if (ViewState["SUOM"].ToString() == "KG")
            {
                ddlUOM.SelectedValue = ViewState["SUOM"].ToString();
                lblMessage.Text = "Material Base UOM is : " + ViewState["SUOM"].ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Focus();
            }
            else
            {
                lblMessage.Text = string.Empty;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Focus();
            }
            
        }
        else
        {
            lblMessage.Text = string.Empty;
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Focus();
        }
    }
}
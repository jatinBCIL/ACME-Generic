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

    //public string strWeight;
    //public string strMatType;
    DataTable dtMulti = new DataTable();
    DataTable dtBulk = new DataTable();
    

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> GetBatchNo(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_Dispensing objBL = new BL_Dispensing();
        try
        {
            List<string> Items = new List<string>();
            dt = objBL.BL_GetDispensingBatchDtl(prefixText, clsStandards.current_Plant().ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Items.Add(dt.Rows[i]["PRODUCTBATCH"].ToString());
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


    public void add()
    {
        dtMulti.Columns.Add("Barcode");
        dtMulti.Columns.Add("NWeight");
    }

    public void Bulkadd()
    {
        dtBulk.Columns.Add("Barcode");
        dtBulk.Columns.Add("GWeight");
    }
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

                txtMaterialBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanMaterial.ClientID + "'); return DisableSplChars(event);");
                txtWeighingBalance.Attributes.Add("onkeypress", "button_click(this,'" + this.btnScanWeighing.ClientID + "'); return DisableSplChars(event);");

                txtBRMBarcode.Attributes.Add("onkeypress", "button_click(this,'" + this.btnBRMBarcode.ClientID + "'); return DisableSplChars(event);");

                txtBatchNo.Attributes.Add("onkeypress", "button_click(this,'" + this.btnGo.ClientID + "');");
                MultiView1.SetActiveView(View1);
                clsStandards.fillCombobox(ddlBooth, objBL.BL_GetBoothCode(clsStandards.current_Plant().ToString()), "BOOTH");
                clsStandards.fillCombobox(ddlBBooth, objBL.BL_GetBoothCode(clsStandards.current_Plant().ToString()), "BOOTH");
                
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
            dtDispensing = objBL.BL_GetDispensingDtl(txtBatchNo.Text.Trim(), clsStandards.current_Plant().ToString());
            if (dtDispensing.Rows.Count > 0)
            {
                ViewState["Dispensing"] = dtDispensing;
                gvMaterial.DataSource = dtDispensing;
                gvMaterial.DataBind();

                lblMessage0.Text = " ";
                lblMessage0.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage0.Text = "No Data Found for : " + txtBatchNo.Text.Trim();
                lblMessage0.ForeColor = System.Drawing.Color.Red;
                gvMaterial.DataSource = null;
                txtBatchNo.Text.Trim();
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

    public static string getWeight_p(string WeighID, string Port, string strWeighingType)
    {
        clsWeighing objServer = new clsWeighing();
        //DLServerFunctions objServer = new DLServerFunctions();
        string strResult = string.Empty;

        try
        {
            if ((objServer.InitializeTCPIPClient(WeighID, Port) == 1))
            {
               return "Not Connected";
            }
            else
            {
                if (strWeighingType == "0")
                {
                    strResult = objServer.ReceiveDataFromServer();
                    //lblActResult.Text = strResult;
                    strResult = strResult.Substring(4);
                    strResult = strResult.Substring(0, strResult.Length - 4);
                }
                else
                {
                    strResult = objServer.ReceiveDataFromServer();
                    //lblActResult.Text = strResult;
                    strResult = Regex.Replace(strResult.ToString(), "[^0-9. ]", "").Trim(); ;

                }
                return strResult.Trim();  //objServer.Calculate_Weight(strResult).ToString();
            }

        }
        catch (Exception ex)
        {
            //clsStandards.WriteLog(this, new Exception("Not Connected"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            throw new Exception(ex.ToString());
            //MessageBox.Show(ex.ToString());
        }
        finally
        {
        }

    }

    private string getWeight(string WeighID, string Port)
    {
        clsWeighing objServer = new clsWeighing();
        //DLServerFunctions objServer = new DLServerFunctions();
        string strResult = string.Empty;

        try
        {
            if ((objServer.InitializeTCPIPClient(WeighID, Port) == 1))
            {
                //objServer.Add_Log_Entry(ListView1, dr("LINE_CODE").ToString(), "Weighing scale disconnected", 1);
                // MessageBox.Show("Weighing scale disconnected");
                clsStandards.WriteLog(this, new Exception("Not Connected"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return "Balance is not connected.";

            }
            else
            {

                strResult = objServer.ReceiveDataFromServer();
                //lblActResult.Text = strResult;
                strResult = Regex.Replace(strResult.ToString(), "[^0-9. ]", "").Trim();
                return strResult.Trim();  //objServer.Calculate_Weight(strResult).ToString();


            }

        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, new Exception("Not Connected"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            throw new Exception(ex.ToString());
            //MessageBox.Show(ex.ToString());
        }
        finally
        {
            objServer = null;
        }

    }

    protected void btnScanBalance_Click(object sender, EventArgs e)
    {
        //if (txtMaterialBarcode.Text.Trim() != "")
        //{
            BL_Dispensing objBL = new BL_Dispensing();
            ViewState["Printer"] = "";
            string strResult = "";
            try
            {
                strResult = objBL.BL_ValidateBalanceCode(ddlBooth.Text.Trim().Split('/').GetValue(0).ToString(), txtWeighingBalance.Text.Trim(), "VALIDATE", clsStandards.current_User().ToString(), clsStandards.current_Plant().ToString());
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
                        ViewState["IPADDRESS"] = strResult.Split('|').GetValue(2).ToString();
                        ViewState["PORT"] = strResult.Split('|').GetValue(3).ToString();
                        ViewState["UOM"] = strResult.Split('|').GetValue(4).ToString();

                        if (txtTareWt.Text == "")
                        {
                            if (ViewState["UOM"].ToString() == "GM")
                            {
                                if (ddlUnit.Text.Trim() == "GM")
                                {
                                    txtTareWt.Text = clsStandards.getRound(getWeight(ViewState["IPADDRESS"].ToString(), ViewState["PORT"].ToString()), 3);
                                    txtTareWt.Text = txtTareWt.Text == "000" ? string.Empty : txtTareWt.Text;
                                    lblMessage.Text = string.Empty;
                                    lblMessage.ForeColor = System.Drawing.Color.Green;
                                    lblMessage.Focus();
                                }
                                else
                                {
                                    txtTareWt.Text = clsStandards.getRound(clsStandards.getGMtoKG(getWeight(ViewState["IPADDRESS"].ToString(), ViewState["PORT"].ToString())), 3);
                                    txtTareWt.Text = txtTareWt.Text == "000" ? string.Empty : txtTareWt.Text;
                                    lblMessage.Text = string.Empty;
                                    lblMessage.ForeColor = System.Drawing.Color.Green;
                                    lblMessage.Focus();
                                }
                            }
                            else
                            {
                                txtTareWt.Text = clsStandards.getRound(getWeight(ViewState["IPADDRESS"].ToString(), ViewState["PORT"].ToString()), 3);
                                txtTareWt.Text = txtTareWt.Text == "000" ? string.Empty : txtTareWt.Text;
                                lblMessage.Text = string.Empty;
                                lblMessage.ForeColor = System.Drawing.Color.Green;
                                lblMessage.Focus();
                            }

                            if (txtTareWt.Text == string.Empty)
                            {
                                txtTareWt.Text = "0";
                            }
                            else
                            {
                                txtWeighingBalance.Text = string.Empty;
                                txtWeighingBalance.Focus();
                            }
                        }
                        else if (txtNetWt.Text == "")
                        {
                            if (ViewState["UOM"].ToString() == "GM")
                            {
                                if (ddlUnit.Text.Trim() == "GM")
                                {
                                    txtNetWt.Text = clsStandards.getRound(getWeight(ViewState["IPADDRESS"].ToString(), ViewState["PORT"].ToString()), 3);
                                    txtNetWt.Text = txtNetWt.Text == "000" ? string.Empty : txtNetWt.Text;
                                    lblMessage.Text = string.Empty;
                                    lblMessage.ForeColor = System.Drawing.Color.Green;
                                    lblMessage.Focus();
                                }
                                else
                                {
                                    txtNetWt.Text = clsStandards.getRound(clsStandards.getGMtoKG(getWeight(ViewState["IPADDRESS"].ToString(), ViewState["PORT"].ToString())), 3);
                                    txtNetWt.Text = txtNetWt.Text == "000" ? string.Empty : txtNetWt.Text;
                                    lblMessage.Text = string.Empty;
                                    lblMessage.ForeColor = System.Drawing.Color.Green;
                                    lblMessage.Focus();
                                }
                            }
                            else
                            {
                                txtNetWt.Text = clsStandards.getRound(getWeight(ViewState["IPADDRESS"].ToString(), ViewState["PORT"].ToString()), 3);
                                txtNetWt.Text = txtNetWt.Text == "000" ? string.Empty : txtNetWt.Text;
                                lblMessage.Text = string.Empty;
                                lblMessage.ForeColor = System.Drawing.Color.Green;
                                lblMessage.Focus();
                            }

                            if (ViewState["MultiDt"] == null)
                            {
                                if (ddlUnit.Text.Trim() == "GM")
                                {
                                    if ((double.Parse(txtNetWt.Text.Trim())/1000) > double.Parse(ViewState["Weight"].ToString()))
                                    {
                                        lblMessage.Text = ViewState["Weight"].ToString() + " Quantity available in Container";
                                        lblMessage.ForeColor = System.Drawing.Color.Red;
                                        lblMessage.Focus();
                                        txtNetWt.Text = string.Empty;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (double.Parse(txtNetWt.Text.Trim()) > double.Parse(ViewState["Weight"].ToString()))
                                    {
                                        lblMessage.Text = ViewState["Weight"].ToString() + " Quantity available in Container";
                                        lblMessage.ForeColor = System.Drawing.Color.Red;
                                        lblMessage.Focus();
                                        txtNetWt.Text = string.Empty;
                                        return;
                                    }
 
                                }

                            }
                                if (ViewState["MatType"].ToString() == "RM")
                                {
                                    if (ddlUnit.Text.Trim() == "GM")
                                    {
                                        if (Math.Round((double.Parse(txtNetWt.Text.Trim())/1000),6) > Math.Round(double.Parse(lblRemQty.Text.Trim()),6))
                                        {
                                            lblMessage.Text = "Required Quantity is: " + lblRemQty.Text.Trim();
                                            lblMessage.ForeColor = System.Drawing.Color.Red;
                                            lblMessage.Focus();
                                            txtNetWt.Text = string.Empty;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (double.Parse(txtNetWt.Text.Trim()) > Math.Round(double.Parse(lblRemQty.Text.Trim()),3))
                                        {
                                            lblMessage.Text = "Required Quantity is: " + Math.Round(double.Parse(lblRemQty.Text.Trim()), 3).ToString();
                                            lblMessage.ForeColor = System.Drawing.Color.Red;
                                            lblMessage.Focus();
                                            txtNetWt.Text = string.Empty;
                                            return;
                                        }
                                    }
                                }
                            
                            if (txtNetWt.Text == string.Empty)  
                            {
                                txtNetWt.Text = "0";
                            }
                            if (txtNetWt.Text != string.Empty)
                            {
                                txtGrossWt.Text = Convert.ToDecimal(Convert.ToDecimal(txtNetWt.Text) + Convert.ToDecimal(txtTareWt.Text)).ToString();
                                lblMessage.Text = "";
                                lblMessage.ForeColor = System.Drawing.Color.Black;
                                lblMessage.Focus();
                                btnPrint.Focus();
                            }
                        }
                    }
                }
                //txtNetWt.Focus();
                else
                {
                    clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    txtWeighingBalance.Text = "";
                    txtWeighingBalance.Focus();

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
    protected void SetBMessage(string message, int type)
    {
        if (type == 0)
        {
            lblMessage1.Text = message;
            lblMessage1.ForeColor = System.Drawing.Color.Red;
            lblMessage1.Focus();
        }
        else
        {
            lblMessage1.Text = message;
            lblMessage1.ForeColor = System.Drawing.Color.Green;
            lblMessage1.Focus();
        }
    }
    protected void SetMessage(string message, int type)
    {
        if (type == 0)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Focus();
        }
        else
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Focus();
        }
    }

    protected bool validateOthers(int i)
    {
        if(ddlBooth.Text.Trim()=="Select" || ddlBooth.Text.Trim()=="")
        {
            SetMessage("Please Select Booth", 0);
            return false;
        }
        if (i == 1)
        {
            if (txtMaterialBarcode.Text == "")
            {
                SetMessage("Please Scan RM", 0);
                return false;
            }
            if (txtNetWt.Text.Trim() == "")
            {
                SetMessage("Please Capture/Enter Weight", 0);
                return false;
            }
        }
        if (ddlLot.Text.Trim() == "Select" || ddlLot.Text.Trim() == "")
        {
            SetMessage("Please Select Lot No.", 0);
            return false;
        }

        if (txtCount.Visible == true)
        {
            if (txtCount.Text.Trim() == "")
            {
                SetMessage("Please Enter Lot Quantity", 0);
                return false;
            }
        }
        if (ddlUnit.Text.Trim() == "Select" || ddlUnit.Text.Trim() == "")
        {
            SetMessage("Please Select Unit Of Issuance", 0);
            return false;
        }
        SetMessage("", 1);
        return true;
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
            strResult = objBL.BL_ValidateBarcodeDispensing(txtMaterialBarcode.Text.Trim(), lblMaterial.Text.Trim(), lblARno.Text.Trim(), "VALIDATE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                txtWeighingBalance.Focus();
                ViewState["Weight"] = strResult.Split('|').GetValue(2).ToString();
                ViewState["MatType"] = strResult.Split('|').GetValue(3).ToString();
                

                if (ViewState["MultiDt"] != null)
                {
                    foreach (DataRow dr in ((DataTable)ViewState["MultiDt"]).Rows)
                    {
                        if (dr[0].ToString() == txtMaterialBarcode.Text.Trim())
                        {
                            btnAdd1.Text = "Remove";
                            return;
                        }
                    }
                }
                SetMessage("Container Qty : " + strResult.Split('|').GetValue(2).ToString(), 1);
            }
            else
            {
                //clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                SetMessage(strResult.Split('|').GetValue(1).ToString(), 0);
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
        DataTable dtmulti = new DataTable();
        DataTable dtPrinter= new DataTable();
        bool bFlag = false;
        int qty;
        try
        {
            if (txtCount.Visible == false)
            {
                qty = int.Parse(lblCont.Text);
            }
            else
            {
                if (txtCount.Text != string.Empty)
                {
                    qty = int.Parse(txtCount.Text);
                }
                else
                {
                    clsStandards.WriteLog(this, new Exception("Enter Container Count"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    return;
                }
            }

            if (ddlBooth.Text.Trim() =="Select")
            {
                SetMessage("Please Select Booth", 0);
                return;
            }

            dtPrinter = objDisp.BL_GetPrinterCode(ddlBooth.Text.Trim().Split('/').GetValue(0).ToString());

            if (dtPrinter.Rows.Count > 0)
            {
                if (PrintDirect.CheckConnection(dtPrinter.Rows[0]["PRINTERIP"].ToString(), dtPrinter.Rows[0]["PRINTERPORT"].ToString()) == false)
                {
                    SetMessage("Printer is not connected", 0);
                    return;
                }
            }
            else
            {
                SetMessage("Printer Details not found Select Correct Booth", 0);
                return;
            }

            if (ViewState["MultiDt"] != null)
            {
                dtmulti = clsStandards.GridToDataTable(dgvbarcode);

                if (dtmulti.Rows.Count > 0)
                {
                    int lCount = 0;
                    int cCount = 0;
                    foreach (DataRow dr in dtmulti.Rows)
                    {
                        if (dr[1].ToString() == "0")
                        {
                            lCount = lCount + 1;
                        }
                        if (dr[1].ToString() != "0")
                        {
                            cCount = cCount + 1;
                        }
                    }

                    if (lCount != 0 && cCount!=0)
                    {
                        foreach (DataRow dr in dtmulti.Rows)
                        {
                            if (dr[1].ToString() == "0")
                            {
                                if (ddlUnit.Text == "GM")
                                {
                                    if ((double.Parse(txtNetWt.Text.Trim())/1000 - double.Parse((ViewState["TNWeight"]).ToString())) > 0)
                                    {
                                        if ((double.Parse(txtNetWt.Text.Trim())/1000 - double.Parse((ViewState["TNWeight"]).ToString()) <= double.Parse((ViewState["LNWeight"]).ToString())))
                                        {
                                            dr[1] = (double.Parse(txtNetWt.Text.Trim())/1000 - (double.Parse((ViewState["TNWeight"]).ToString()))).ToString();
                                        }
                                        else
                                        {
                                            SetMessage("Loose Container: " + dr[0].ToString() + " Qty is " + double.Parse((ViewState["LNWeight"]).ToString()) + " is less than " + (double.Parse(txtNetWt.Text.Trim()) - double.Parse((ViewState["TNWeight"]).ToString())).ToString(), 0);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        SetMessage("Net Weight is less than total containers", 0);
                                        return;
                                    }
                                }
                                else
                                {
                                    if ((double.Parse(txtNetWt.Text.Trim()) - double.Parse((ViewState["TNWeight"]).ToString())) > 0)
                                    {
                                        if ((double.Parse(txtNetWt.Text.Trim()) - double.Parse((ViewState["TNWeight"]).ToString()) <= double.Parse((ViewState["LNWeight"]).ToString())))
                                        {
                                            dr[1] = (double.Parse(txtNetWt.Text.Trim()) - (double.Parse((ViewState["TNWeight"]).ToString()))).ToString();
                                        }
                                        else
                                        {
                                            SetMessage("Loose Container: " + dr[0].ToString() + " Qty is " + double.Parse((ViewState["LNWeight"]).ToString()) + " is less than " + (double.Parse(txtNetWt.Text.Trim()) - double.Parse((ViewState["TNWeight"]).ToString())).ToString(), 0);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        SetMessage("Net Weight is less than total containers", 0);
                                        return;
                                    }
                                }
                            }
                        }

                        dtPrint = objDisp.BL_PrintDispensingBarcodeMulit(dtmulti, ddlBooth.Text.Trim().Split('/').GetValue(0).ToString(), lblARno.Text.Trim(),
                                                                    lblMaterial.Text.Trim(), ddlUnit.Text.Trim(), txtWeighingBalance.Text.Trim(), txtBatchNo.Text,
                                                                    ViewState["ProcOrder"].ToString(), ddlLot.Text.Trim(),
                                                                    qty, clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString(), txtGrossWt.Text.Trim(), txtTareWt.Text.Trim(), ViewState["LineItem"].ToString());
                    }
                    else
                    {
                        if (lCount == 0)
                        {
                            SetMessage("Please scan loose container", 1);
                            return;
                        }
                        else
                        {
                            SetMessage("Please scan Complete container", 1);
                            return;
                        }
                    }
                }
            }
            else
            {
                if (DivNO.Visible == false)
                {
                    dtPrint = objDisp.BL_PrintDispensingBarcode(ddlBooth.Text.Trim().Split('/').GetValue(0).ToString(), lblARno.Text.Trim(),
                                                           lblMaterial.Text.Trim(), ddlUnit.Text.Trim(), txtMaterialBarcode.Text.Trim(),
                                                           txtWeighingBalance.Text.Trim(), Convert.ToDecimal(txtGrossWt.Text.Trim()),
                                                           Convert.ToDecimal(txtTareWt.Text.Trim()), Convert.ToDecimal(txtNetWt.Text.Trim()),
                                                           txtBatchNo.Text, ViewState["ProcOrder"].ToString(), ddlLot.Text.Trim(),
                                                           qty, clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString(), 
                                                           Convert.ToDecimal(lblQty.Text.Trim()), ViewState["LineItem"].ToString());
                }
                else
                {
                    if (ValidateUnits())
                    {
                        dtPrint = objDisp.BL_PrintDispensingBarcode(ddlBooth.Text.Trim().Split('/').GetValue(0).ToString(), lblARno.Text.Trim(),
                                                                              lblMaterial.Text.Trim(), ddlUnit.Text.Trim(), txtMaterialBarcode.Text.Trim(),
                                                                              txtWeighingBalance.Text.Trim(), Convert.ToDecimal("0"),
                                                                              Convert.ToDecimal("0"), Convert.ToDecimal(txtUnit.Text.Trim()),
                                                                              txtBatchNo.Text, ViewState["ProcOrder"].ToString(), ddlLot.Text.Trim(),
                                                                              qty, clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString(), 
                                                                              Convert.ToDecimal(lblQty.Text.Trim()), ViewState["LineItem"].ToString());
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (dtPrint.Rows.Count > 0)
            {
                if (dtPrint.Columns.Count > 1)
                {
                    btnPrint.Enabled = false;

                    if (dtPrint.Rows[0]["Result"].ToString().Split('|').GetValue(0).ToString() == "2")
                    {
                        lblMessage.Text = "Dispensing had been Completed.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblScanQty.Text = clsBLCommon.Qty(dtPrint.Rows[0]["SQTY"].ToString());
                        lblRemQty.Text = (double.Parse(lblQty.Text) - double.Parse(dtPrint.Rows[0]["SQTY"].ToString())).ToString();
                        txtWeighingBalance.Text = "";
                        txtMaterialBarcode.Text = "";
                        txtGrossWt.Text = "";
                        txtNetWt.Text = "";
                        txtTareWt.Text = "";
                        txtUnit.Text = "";
                        ViewState["cCount"] = null;
                        ViewState["lCount"] = null;
                        ViewState["MultiDt"] = null;
                        dgvbarcode.DataSource = null;
                        dgvbarcode.DataBind();
                        ViewState["TNWeight"] = null;
                        ViewState["LNWeight"] = null;
                    }
                    else
                    {
                        lblScanQty.Text = clsBLCommon.Qty(dtPrint.Rows[0]["SQTY"].ToString());
                        lblRemQty.Text = (double.Parse(lblQty.Text) - double.Parse(dtPrint.Rows[0]["SQTY"].ToString())).ToString();
                        txtWeighingBalance.Text = "";
                        txtMaterialBarcode.Text = "";
                        txtGrossWt.Text = "";
                        txtNetWt.Text = "";
                        txtTareWt.Text = "";
                        txtUnit.Text = "";
                        ViewState["cCount"] = null;
                        ViewState["lCount"] = null;
                        ViewState["MultiDt"] = null;
                        dgvbarcode.DataSource = null;
                        dgvbarcode.DataBind();
                        ViewState["TNWeight"] = null;
                        ViewState["LNWeight"] = null;
                    }

                    bFlag = PrintDirect.Print_DispenseRawLabel(
                           ViewState["Printer"].ToString().Trim(),
                           dtPrint.Rows[0]["BarcodeNo"].ToString(),
                           dtPrint.Rows[0]["MatCode"].ToString(),
                           LblDesc.Text.Trim(),
                           dtPrint.Rows[0]["ProdBatch"].ToString(),
                           DateTime.Parse(dtPrint.Rows[0]["MfgDate"].ToString()).ToString("yyyy") == "1753" ? "To be established" : DateTime.Parse(dtPrint.Rows[0]["MfgDate"].ToString()).ToString("MMM yyyy"),
                           DateTime.Parse(dtPrint.Rows[0]["MfgDate"].ToString()).ToString("yyyy") == "1753" ? "To be established" : DateTime.Parse(dtPrint.Rows[0]["ExpDate"].ToString()).ToString("MMM yyyy"),
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
                           lblARno.Text.Trim(),
                           dtPrint.Rows[0]["COUNT"].ToString() + " of " + dtPrint.Rows[0]["TOTALCONTAINER"].ToString(),
                           dtPrint.Rows[0]["LotNo"].ToString(),
                           dtPrint.Rows[0]["PRINT"].ToString().Split('|').GetValue(0).ToString(),
                           dtPrint.Rows[0]["PRINT"].ToString().Split('|').GetValue(1).ToString(),
                           dtPrint.Rows[0]["EX_ST"].ToString());

                    if (bFlag == true)
                    {
                        clsStandards.WriteLog(this, new Exception("Barcode Printed Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                        btnPrint.Enabled = true;
                        return;
                        //lblMessage.Text = "Barcode Printed Successfully";
                    }
                    else
                    {
                        clsStandards.WriteLog(this, new Exception("Please Check Printer Connection"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                        return;
                    }
                }
                else
                {
                    clsStandards.WriteLog(this, new Exception(dtPrint.Rows[0][0].ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    txtGrossWt.Focus();
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
    protected void clear()
    {
        txtGrossWt.Text = "";
        txtNetWt.Text = "";
        txtGrossWt.Text = "";
        txtMaterialBarcode.Text = "";
        txtWeighingBalance.Text = "";
    }

    protected void btnNext_Click(object sender, EventArgs e)
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
                        DataRow[] dr = dt.Select("MaterialCode='" + gvMaterial.Rows[i].Cells[1].Text.ToString() + "' AND MaterialBatch='" + gvMaterial.Rows[i].Cells[2].Text.ToString() + "'AND LineItem='" + gvMaterial.Rows[i].Cells[5].Text.ToString() + "' AND [STATUS]=1");
                        if (dr.Length > 0)
                        {
                            lblMessage0.Text = "";
                            lblMessage0.ForeColor = System.Drawing.Color.Green;
                            btnPrint.Enabled = true;
                            lblARno.Text = dr[0][8].ToString();
                            lblMaterial.Text = dr[0][5].ToString();
                            lblQty.Text = clsBLCommon.Qty(dr[0][9].ToString());
                            LblDesc.Text = dr[0][6].ToString();
                            lblBatchNo.Text = dr[0]["MaterialBatch"].ToString();
                            lblRemQty.Text = (Double.Parse(dr[0][9].ToString()) - Double.Parse(dr[0]["SQTY"].ToString())).ToString();
                            lblScanQty.Text = clsBLCommon.Qty(dr[0]["SQTY"].ToString());
                            lblUom.Text = dr[0]["UOM"].ToString();
                            ddlUnit.SelectedValue = dr[0]["UOM"].ToString();
                            ViewState["LineItem"] = gvMaterial.Rows[i].Cells[5].Text.ToString();
                            ViewState["ProcOrder"] = dr[0]["PROCESSORDERNO"].ToString();
                            ViewState["cCount"] = null;
                            ViewState["lCount"] = null;
                            ViewState["MultiDt"] = null;
                            dgvbarcode.DataSource = null;
                            dgvbarcode.DataBind();
                            ViewState["TNWeight"] = null;
                            ViewState["LNWeight"] = null;
                            MultiView1.SetActiveView(View2);
                            if (dr[0]["UOM"].ToString() == "NOS")
                            {
                                DivWeight.Visible = false;
                                DivNO.Visible = true;
                                divAdd.Visible = false;
                                txtWeighingBalance.Enabled = false;
                                chkManual.Enabled = false;
                            }
                            else
                            {
                                txtWeighingBalance.Enabled = true;
                                chkManual.Enabled = true;
                                divAdd.Visible = true;
                                DivNO.Visible = false;
                                DivWeight.Visible = true;
                            }
                        }
                        else
                        {
                            lblMessage0.Text = "Please complete picking process first.";
                            lblMessage0.ForeColor = System.Drawing.Color.Red;
                        }
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

    protected void txtGrossWt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtTareWt.Text != "" && txtGrossWt.Text != "")
            {
                txtNetWt.Text = (Convert.ToDecimal(txtGrossWt.Text.Trim()) - Convert.ToDecimal(txtTareWt.Text.Trim())).ToString();

                if (ddlUnit.Text.Trim() == "GM")
                {
                    if (Math.Round((double.Parse(txtNetWt.Text) / 1000), 6) > Math.Round(double.Parse(lblRemQty.Text), 6))
                    {
                        txtNetWt.Text = "";
                        txtGrossWt.Text = "";
                        lblMessage.Text = "Rquired Qty is: " + Math.Round(double.Parse(lblRemQty.Text), 6).ToString() + " Please scan correct qty";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Focus();
                        return;
                    }
                }
                else
                {
                    if (double.Parse(txtNetWt.Text) > Math.Round(double.Parse(lblRemQty.Text), 3))
                    {
                        txtNetWt.Text = "";
                        txtGrossWt.Text = "";
                        txtGrossWt.Focus();
                        lblMessage.Text = "Rquired Qty is: " + Math.Round(double.Parse(lblRemQty.Text), 3).ToString() + " Please scan correct qty";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Focus();
                        return;
                    }
                }

                if (ViewState["MatType"].ToString() == "RM")
                {
                    if (ddlUnit.Text.Trim() == "GM")
                    {
                        if (Math.Round((double.Parse(txtNetWt.Text) / 1000), 6) > double.Parse(ViewState["Weight"].ToString()))
                        {
                            txtNetWt.Text = "";
                            txtGrossWt.Text = "";
                            lblMessage.Text = "Container Qty is: " + double.Parse(ViewState["Weight"].ToString());
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Focus();
                            return;
                        }
                    }
                    else
                    {
                        if (double.Parse(txtNetWt.Text) > double.Parse(ViewState["Weight"].ToString()))
                        {
                            txtNetWt.Text = "";
                            txtGrossWt.Text = "";
                            lblMessage.Text = "Container Qty is: " + double.Parse(ViewState["Weight"].ToString());
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Focus();
                            return;
                        }
                    }
                }

                SetMessage("", 1);
            }
            else
            {
                txtTareWt.Focus();
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

    protected void txtTareWt_TextChanged(object sender, EventArgs e)
    {

        try
        {
            if (txtTareWt.Text != "" && txtGrossWt.Text != "")
            {
                txtNetWt.Text = (Convert.ToDecimal(txtGrossWt.Text.Trim()) - Convert.ToDecimal(txtTareWt.Text.Trim())).ToString();

                if (ddlUnit.Text.Trim() == "GM")
                {
                    if (Math.Round((double.Parse(txtNetWt.Text) / 1000), 6) > Math.Round(double.Parse(lblRemQty.Text), 6))
                    {
                        txtNetWt.Text = "";
                        txtGrossWt.Text = "";
                        lblMessage.Text = "Rquired Qty is: " + Math.Round(double.Parse(lblRemQty.Text), 6).ToString() + " Please scan correct qty";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Focus();
                        return;
                    }
                }
                else
                {
                    if (double.Parse(txtNetWt.Text) > Math.Round(double.Parse(lblRemQty.Text), 3))
                    {
                        txtNetWt.Text = "";
                        txtGrossWt.Text = "";
                        txtGrossWt.Focus();
                        lblMessage.Text = "Rquired Qty is: " + Math.Round(double.Parse(lblRemQty.Text), 3).ToString() + " Please scan correct qty";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Focus();
                        return;
                    }
                }

                if (ViewState["MatType"].ToString() == "RM")
                {
                    if (ddlUnit.Text.Trim() == "GM")
                    {
                        if (Math.Round((double.Parse(txtNetWt.Text) / 1000), 6) > double.Parse(ViewState["Weight"].ToString()))
                        {
                            txtNetWt.Text = "";
                            txtGrossWt.Text = "";
                            lblMessage.Text = "Container Qty is: " + double.Parse(ViewState["Weight"].ToString());
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Focus();
                            return;
                        }
                    }
                    else
                    {
                        if (double.Parse(txtNetWt.Text) > double.Parse(ViewState["Weight"].ToString()))
                        {
                            txtNetWt.Text = "";
                            txtGrossWt.Text = "";
                            lblMessage.Text = "Container Qty is: " + double.Parse(ViewState["Weight"].ToString());
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Focus();
                            return;
                        }
                    }
                }

                SetMessage("", 1);
            }
            else
            {
                txtGrossWt.Focus();
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

    private void clearControls()
    {
        lblARno.Text = "";
        lblMaterial.Text = "";
        lblQty.Text = "";
        lblRemQty.Text = "";
        lblScanQty.Text = "";
        lblUom.Text = "";
        ddlBooth.SelectedIndex = 0;
        lblMessage.Text = "";
        dtMulti = null;
        //ddlUnit.Items.Clear();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        btnGo_Click(sender, e);
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
    protected void ddlLot_SelectedIndexChanged(object sender, EventArgs e)
    {
        BL_Dispensing objBL = new BL_Dispensing();
        string strResult = "";
        try
        {
            strResult = objBL.BL_GetLotNo(lblBatchNo.Text.Trim(), lblMaterial.Text.Trim(), txtBatchNo.Text.Trim(), ((DataTable)ViewState["Dispensing"]).Rows[0]["ProcessOrderNo"].ToString(), ddlLot.Text.Trim(), clsStandards.current_Plant().ToString());
            
            if (strResult.StartsWith("0"))
            {
                lblCont.Visible = false;
                txtCount.Visible = true;
                txtCount.Text = "";
                lblMessage.Text = "";
                btnPrint.Enabled = true;
            }
            else if (strResult.StartsWith("1"))
            {
                lblCont.Visible = true;
                txtCount.Visible = false;
                lblCont.Text= strResult.Split('|').GetValue(1).ToString();
                lblMessage.Text = "";
                btnPrint.Enabled = true;
            }
            else if (strResult.StartsWith("2"))
            {
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                lblCont.Visible = false;
                txtCount.Visible = false;
                btnPrint.Enabled = false;
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
    protected void chkManual_CheckedChanged(object sender, EventArgs e)
    {
        if (chkManual.Checked == true)
        {
            txtNetWt.ReadOnly = false;
            txtWeighingBalance.Enabled = false;
        }
        else
        {
            txtWeighingBalance.Enabled = true;
            txtNetWt.ReadOnly=true;
        }
    }
    protected void ddlLot_SelectedIndexChanged1(object sender, EventArgs e)
    {
        BL_Dispensing objBL = new BL_Dispensing();
        string strResult = "";
        try
        {
            strResult = objBL.BL_GetLotNo(txtMaterialBarcode.Text.Trim(), lblMaterial.Text.Trim(), txtBatchNo.Text.Trim(), ((DataTable)ViewState["Dispensing"]).Rows[0]["ProcessOrderNo"].ToString(), ddlLot.Text, clsStandards.current_Plant().ToString());

            if (strResult.StartsWith("0"))
            {
                lblCont.Visible = false;
                txtCount.Visible = true;
                txtCount.Text = "";
                lblMessage.Text = "";
                btnPrint.Enabled = true;
            }
            else if (strResult.StartsWith("1"))
            {
                lblCont.Visible = true;
                txtCount.Visible = false;
                lblCont.Text = strResult.Split('|').GetValue(1).ToString();
                lblMessage.Text = "";
                btnPrint.Enabled = true;
            }
            else if (strResult.StartsWith("2"))
            {
                lblMessage.Text = strResult.Split('|').GetValue(1).ToString();
                lblCont.Visible = false;
                txtCount.Visible = false;
                btnPrint.Enabled = false;
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
    protected void addContainer()
    {
        if (txtBatchNo.Text.Trim() != "" && txtGrossWt.Text.Trim() != "" && txtNetWt.Text.Trim() != "")
        {
            DataRow dr = dtMulti.NewRow();
            dr["Barcode"] = txtMaterialBarcode.Text.Trim();
            dr["GWeight"] = txtGrossWt.Text.Trim();
            dr["TWeight"] = txtTareWt.Text.Trim();
            dr["NWeight"] = txtNetWt.Text.Trim();
            dtMulti.Rows.Add(dr);
        }
    }
    protected void btnAdd1_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnAdd1.Text == "Add")
            {
                if (chkType.Checked == true)
                {
                    dgvbarcode.DataSource = null;
                    add();
                    DataRow dr = dtMulti.NewRow();
                    dr["Barcode"] = txtMaterialBarcode.Text.Trim();
                    dr["NWeight"] = ViewState["Weight"].ToString();
                    if (ViewState["TNWeight"] == null)
                    {
                        ViewState["TNWeight"] = ViewState["Weight"].ToString();
                    }
                    else
                    {
                        ViewState["TNWeight"] = (double.Parse(ViewState["TNWeight"].ToString())+double.Parse(ViewState["Weight"].ToString())).ToString();
                    }
                    txtMaterialBarcode.Text = "";
                    dtMulti.Rows.Add(dr);
                    if (ViewState["MultiDt"] == null)
                    {
                        ViewState["MultiDt"] = dtMulti;
                        dgvbarcode.DataSource = dtMulti;
                        dgvbarcode.DataBind();
                        ViewState["cCount"] = "1";
                    }
                    else
                    {
                        ((DataTable)ViewState["MultiDt"]).Merge(dtMulti);
                        dgvbarcode.DataSource = (DataTable)ViewState["MultiDt"];
                        dgvbarcode.DataBind();
                        ViewState["cCount"] = ViewState["cCount"] == null ? "1" : (int.Parse(ViewState["cCount"].ToString()) + 1).ToString();
                    }

                    SetMessage(ViewState["lCount"] == null ? "Complete : " + ViewState["cCount"].ToString() + " Loose : 0" : "Complete : " + ViewState["cCount"].ToString() + " Loose : " + ViewState["lCount"].ToString(), 1);
                }
                else
                {
                    dgvbarcode.DataSource = null;
                    add();
                    DataRow dr = dtMulti.NewRow();
                    dr["Barcode"] = txtMaterialBarcode.Text.Trim();
                    dr["NWeight"] = "0";
                    ViewState["LNWeight"] = ViewState["Weight"].ToString();
                    txtMaterialBarcode.Text = "";
                    dtMulti.Rows.Add(dr);

                    if (ViewState["MultiDt"] == null)
                    {
                        ViewState["MultiDt"] = dtMulti;
                        dgvbarcode.DataSource = dtMulti;
                        dgvbarcode.DataBind();
                        ViewState["lCount"] = "1";
                    }
                    else
                    {
                        foreach (DataRow dr1 in ((DataTable)ViewState["MultiDt"]).Rows)
                        {
                            if (dr1[1].ToString() =="0")
                            {
                                SetMessage("loose Container is already present: "+dr1[0].ToString(), 1);
                                return;
                            }

                        }
                        ((DataTable)ViewState["MultiDt"]).Merge(dtMulti);
                        dgvbarcode.DataSource = (DataTable)ViewState["MultiDt"];
                        dgvbarcode.DataBind();
                        ViewState["lCount"] = "1";
                    }
                    SetMessage(ViewState["cCount"] == null ? "Complete : 0 Loose :" + ViewState["lCount"].ToString() : "Complete : " + ViewState["cCount"].ToString() + " Loose : " + ViewState["lCount"].ToString()+"", 1);
                }
            }
            else
            {
                foreach (DataRow dr1 in ((DataTable)ViewState["MultiDt"]).Rows)
                {
                    if (dr1[0].ToString() == txtMaterialBarcode.Text.Trim())
                    {
                        
                        if (dr1[1].ToString() == "0")
                        {
                            ViewState["LNWeight"] = null;
                            ViewState["lCount"] = null;
                        }
                        else
                        {
                            ViewState["TNWeight"] = (double.Parse(ViewState["TNWeight"].ToString()) - double.Parse(dr1[1].ToString())).ToString();
                            ViewState["cCount"] =  (int.Parse(ViewState["cCount"].ToString())-1).ToString();
                        }
                        txtMaterialBarcode.Text = string.Empty;
                        btnAdd1.Text = "Add";
                        ((DataTable)ViewState["MultiDt"]).Rows.Remove(dr1);
                        dgvbarcode.DataSource = (DataTable)ViewState["MultiDt"];
                        dgvbarcode.DataBind();
                        SetMessage("Complete : " + (ViewState["cCount"] == null ? "0" : ViewState["cCount"].ToString()) + " Loose : " + (ViewState["lCount"] == null ? "0" : ViewState["lCount"].ToString()), 1);
                        return;
                    }
                    else
                    {
                        lblMessage1.Text = string.Empty;
                        lblMessage1.ForeColor = System.Drawing.Color.Green;
                    }
                }
                
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
        }
    }
    protected void btnClear1_Click(object sender, EventArgs e)
    {
        if (txtGrossWt.Text != string.Empty)
        {
            txtNetWt.Text = string.Empty;
            txtGrossWt.Text = string.Empty;
        }
        else
        {
            txtTareWt.Text = string.Empty;
        }
    }
    protected bool ValidateUnits()
    {
        if (txtUnit.Text.Trim() == string.Empty)
        {
            lblMessage.Text = "Please Enter Qty";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Focus();
            return false;
        }
        else if (double.Parse(txtUnit.Text) > double.Parse(ViewState["Weight"].ToString()))
        {
            txtUnit.Text = "";
            lblMessage.Text = "Pack Qty is: " + ViewState["Weight"].ToString() + " Please scan correct qty";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Focus();
            return false;
        }
        else if (double.Parse(txtUnit.Text.Trim()) > Math.Round(double.Parse(lblRemQty.Text.Trim()), 3))
        {
            lblMessage.Text = "Remaining qty is: " + Math.Round(double.Parse(lblRemQty.Text.Trim()), 3).ToString();
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Focus();
            return false;
        }

        lblMessage.Text = "";
        lblMessage.ForeColor = System.Drawing.Color.Green;
        return true;
    }
    protected void txtUnit_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (double.Parse(ViewState["Weight"].ToString()) > double.Parse(txtUnit.Text))
            {
                txtUnit.Text = "";
                txtUnit.Focus();
                lblMessage.Text = "Pack Qty is:" + ViewState["Weight"].ToString() + " Please scan correct qty";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }

        }
        catch (Exception ex)
        {
           
        }
    }
    protected void btnBulkDisp_Click(object sender, EventArgs e)
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
                        DataRow[] dr = dt.Select("MaterialCode='" + gvMaterial.Rows[i].Cells[1].Text.ToString() + "' AND MaterialBatch='" + gvMaterial.Rows[i].Cells[2].Text.ToString() + "' AND LineItem='" + gvMaterial.Rows[i].Cells[5].Text.ToString() + "' ");
                        if (dr.Length > 0)
                        {
                            btnPrint.Enabled = true;

                            lblBArno.Text = dr[0][8].ToString();
                            lblBMatCode.Text = dr[0][5].ToString();
                            lblBQty.Text = clsBLCommon.Qty(dr[0][9].ToString());
                            lblBMatDesc.Text = dr[0][6].ToString();
                            lblBMatBat.Text = dr[0]["MaterialBatch"].ToString();
                            lblBRem.Text = (Double.Parse(dr[0][9].ToString()) - Double.Parse(dr[0]["SQTY"].ToString())).ToString();
                            lblBScan.Text = clsBLCommon.Qty(dr[0]["SQTY"].ToString());
                            lblBUOM.Text = dr[0]["UOM"].ToString();
                            btnAdd.Enabled = true;
                            btnBPrint.Enabled = false;
                            gvBulkdtl.DataSource = null;
                            gvBulkdtl.DataBind();
                            ViewState["Bulk"] = null;
                            ViewState["BProcOrder"] = dr[0]["PROCESSORDERNO"].ToString();
                            ddlBUOM.SelectedValue = dr[0]["UOM"].ToString();
                            ViewState["LineItem"] = gvMaterial.Rows[i].Cells[5].Text.ToString();
                            MultiView1.SetActiveView(vwBulkDispense);
                        }
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
    protected void btnBRMBarcode_Click(object sender, EventArgs e)
    {
        BL_Dispensing objBL = new BL_Dispensing();
        string strResult = "";
        try
        {
            strResult = objBL.BL_ValidateBulkBarcodeDispensing(txtBRMBarcode.Text.Trim(), lblBMatCode.Text.Trim(), lblBArno.Text.Trim(), "VALIDATE", clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString());
            if (strResult.StartsWith("0"))
            {
                txtBQty.Text = strResult.Split('|').GetValue(2).ToString();
                ViewState["BQty"] = strResult.Split('|').GetValue(2).ToString();
                SetBMessage("", 1);
            }
            else
            {
                txtBRMBarcode.Text = "";
                SetBMessage(strResult.Split('|').GetValue(1).ToString(), 0);
                //txtBRMBarcode.Focus();
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (double.Parse(ViewState["BQty"].ToString()) < double.Parse(txtBQty.Text))
            {
                lblMessage1.Text = "Invalid Quantity Container Quantity is : " + ViewState["BQty"].ToString();
                txtBQty.Text = ViewState["BQty"].ToString();
                lblMessage1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else if(double.Parse(lblBRem.Text) < double.Parse(txtBQty.Text))
            {
                lblMessage1.Text = "Remaining Qty is  : " + lblBRem.Text.Trim();
                lblMessage1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                dgvbarcode.DataSource = null;
                Bulkadd();
                DataRow dr = dtBulk.NewRow();
                dr["Barcode"] = txtBRMBarcode.Text.Trim();
                dr["GWeight"] = txtBQty.Text.Trim();
                dtBulk.Rows.Add(dr);


                if (ViewState["Bulk"] == null)
                {
                    ViewState["Bulk"] = dtBulk;
                    btnBPrint.Enabled = true;
                }
                else
                {

                    foreach (DataRow dr1 in ((DataTable)ViewState["Bulk"]).Rows)
                    {
                        if (dr1[0].ToString() == txtBRMBarcode.Text.Trim())
                        {
                            lblMessage1.Text = txtBRMBarcode.Text.Trim() + " barcode is already scanned.";
                            lblMessage1.ForeColor = System.Drawing.Color.Red;
                            txtBRMBarcode.Text = string.Empty;
                            txtBQty.Text = string.Empty;
                            lblMessage1.Focus();
                            return;
                        }
                        else
                        {
                            lblMessage1.Text = string.Empty;
                            lblMessage1.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    ((DataTable)ViewState["Bulk"]).Merge(dtBulk);
                    btnBPrint.Enabled = true;
                }
                gvBulkdtl.DataSource = ((DataTable)ViewState["Bulk"]);
                gvBulkdtl.DataBind();
                ClearBulkScan();
            }
        }
        catch (Exception ex)
        {

        }

    }
 
    protected void ClearBulkScan()
    {
        lblMessage1.Text = "Last Sr. No Scanned: " + txtBRMBarcode.Text.Trim();
        lblMessage1.ForeColor = System.Drawing.Color.Green;
        lblBScan.Text = (double.Parse(lblBScan.Text)+double.Parse(txtBQty.Text.ToString())).ToString();
        lblBRem.Text = (double.Parse(lblBQty.Text) - double.Parse(lblBScan.Text)).ToString();
        txtBRMBarcode.Text = string.Empty;
        txtBQty.Text = string.Empty;
        txtBRMBarcode.Focus();
        if (double.Parse(lblBScan.Text) >= double.Parse(lblBQty.Text))
        {
            lblMessage1.Text = "Quantity has been completed.";
            btnAdd.Enabled = false;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            txtBRMBarcode.Text = string.Empty;
            txtBQty.Text = string.Empty;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnBBack_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.SetActiveView(View1);
            btnGo_Click(sender, e);
            txtBRMBarcode.Text = string.Empty;
            txtBQty.Text = string.Empty;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnBPrint_Click(object sender, EventArgs e)
    {
        BL_Dispensing objDisp = new BL_Dispensing();
        DataTable dtPrint = new DataTable();
        DataTable dtPrinter = new DataTable();
        DataTable dtbulk = new DataTable();
        bool bFlag = false;
        int qty;
       
        try
        {
            if (txtBCont.Visible == false)
            {
                qty = int.Parse(lblBCont.Text);
            }
            else
            {
                if (txtBCont.Text != string.Empty)
                {

                    qty = int.Parse(txtBCont.Text);
                    lblMessage1.Text = "";
                    lblMessage1.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                   // clsStandards.WriteLog(this, new Exception("Enter Container Count"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    lblMessage1.Text = "Please Enter Container Count";
                    lblMessage1.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }

            dtPrinter = objDisp.BL_GetPrinterCode(ddlBBooth.Text.Trim().Split('/').GetValue(0).ToString());

            if (dtPrinter.Rows.Count > 0)
            {
                if (PrintDirect.CheckConnection(dtPrinter.Rows[0]["PRINTERIP"].ToString(), dtPrinter.Rows[0]["PRINTERPORT"].ToString()) == false)
                {
                    SetBMessage("Printer is not connected", 0);
                    return;
                }
            }
            else
            {
                SetBMessage("Printer Details not found Select Correct Booth", 0);
                return;
            }
            dtbulk = clsStandards.GridToDataTable(gvBulkdtl);

            if (dtbulk.Rows.Count > 0)
            {
               // addContainer();
                lblMessage1.Text = "";
                lblMessage1.ForeColor = System.Drawing.Color.Green;
                dtPrint = objDisp.BL_PrintDispensingBarcodeBulk(dtbulk, ddlBBooth.Text.Trim().Split('/').GetValue(0).ToString(), lblBArno.Text.Trim(),
                                                                lblBMatCode.Text.Trim(), ddlBUOM.Text.Trim(), "", txtBatchNo.Text, ViewState["BProcOrder"].ToString(), ddlBLotNo.Text.Trim()
                                                                , qty, clsStandards.current_Username().ToString(), clsStandards.current_Plant().ToString(), ViewState["LineItem"].ToString());
            }
            else
            {
                lblMessage1.Text = "Please scan any material barcode.";
                lblMessage1.ForeColor = System.Drawing.Color.Red;
            }
            if (dtPrint.Rows.Count > 0)
            {
                if (dtPrint.Columns.Count > 1)
                {
                    btnPrint.Enabled = false;
                    bFlag = PrintDirect.Print_DispenseRawLabel(
                           ViewState["Printer"].ToString().Trim(),
                           dtPrint.Rows[0]["BarcodeNo"].ToString(),
                           dtPrint.Rows[0]["MatCode"].ToString(),
                           lblBMatDesc.Text.Trim(),
                           dtPrint.Rows[0]["ProdBatch"].ToString(),
                           DateTime.Parse(dtPrint.Rows[0]["MfgDate"].ToString()).ToString("MMM yyyy"),
                           DateTime.Parse(dtPrint.Rows[0]["ExpDate"].ToString()).ToString("MMM yyyy"),
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
                           lblBArno.Text.Trim(),
                           dtPrint.Rows[0]["COUNT"].ToString() + " of " + dtPrint.Rows[0]["TOTALCONTAINER"].ToString(),
                           dtPrint.Rows[0]["LotNo"].ToString(),
                           dtPrint.Rows[0]["PRINT"].ToString().Split('|').GetValue(0).ToString(),
                           dtPrint.Rows[0]["PRINT"].ToString().Split('|').GetValue(1).ToString(),
                           dtPrint.Rows[0]["EX_ST"].ToString());

                    if (bFlag == true)
                    {
                        btnPrint.Enabled = false;
                        clsStandards.WriteLog(this, new Exception("Barcode Printed Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);

                        if (dtPrint.Rows[0]["Result"].ToString().Split('|').GetValue(0).ToString() == "2")
                        {
                            lblMessage1.Text = "Dispensing had been Completed.";
                            lblBMatBat.Text = "";
                            lblBMatCode.Text = "";
                            lblBMatDesc.Text = "";
                            lblBCont.Text = "";
                            ViewState["Bulk"] = null;
                            gvBulkdtl.DataSource = null;
                            gvBulkdtl.DataBind();
                            ddlBBooth.SelectedIndex = 0;
                            ddlBLotNo.SelectedIndex = 0;
                            ddlBUOM.SelectedIndex = 0;
                            btnAdd.Enabled = true;
                            return;
                        }

                        lblMessage1.Text = "Dispensing had been Completed.";
                        ViewState["Bulk"] = null;
                        lblBMatBat.Text = "";
                        lblBMatCode.Text = "";
                        lblBMatDesc.Text = "";
                        lblBCont.Text = "";
                        gvBulkdtl.DataSource = null;
                        gvBulkdtl.DataBind();
                        ddlBBooth.SelectedIndex = 0;
                        ddlBLotNo.SelectedIndex = 0;
                        ddlBUOM.SelectedIndex = 0;
                        btnAdd.Enabled = true;
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
                    txtGrossWt.Focus();
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
            clsStandards.WriteLog(this, new Exception(ex.ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
        }
    }
}
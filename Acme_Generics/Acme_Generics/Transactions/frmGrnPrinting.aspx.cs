using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using DataLayer;
using PropertyLayer;
using BusinessLayer;
using System.Configuration;
using System.DirectoryServices;

public partial class frmGrn_Printing : System.Web.UI.Page
{

    public static string strFlg = "";
    DataTable dtImport = new DataTable();

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> GetDocno(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_GrnPrinting objBL = new BL_GrnPrinting();
        try
        {
            List<string> Items = new List<string>();
            dt = objBL.BL_GetDocumentNo(prefixText, "PRINT");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Items.Add(dt.Rows[i]["GRNNo"].ToString());
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
        #region
   
        #endregion

        if (!IsPostBack)
        {

            BL_PrinterMaster objPrint = new BL_PrinterMaster();
            DataTable dt = new DataTable();
            DataTable dt_Plant = new DataTable();
            DataTable dt_AscPlant = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                clsStandards.fillCombobox(ddlPrinterName, objPrint.BL_PrinterCodes(clsStandards.current_Plant()), "PRINTERCODE");

            }
            catch (Exception ex)
            {
                clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
            finally
            {
                objPrint = null;
            }
            MultiView1.SetActiveView(View1);
            strFlg = "ADD";


        }

    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        BL_GrnPrinting objBL = new BL_GrnPrinting();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetDocumenDetails(txtDocumentNo.Text.Trim(), "PRINT");
            if (dtGrn.Rows.Count > 0)
            {
                GrGRNDetails.DataSource = dtGrn;
                GrGRNDetails.DataBind();
            }
            else
            {
                GrGRNDetails.DataSource = null;
                GrGRNDetails.DataBind();
                clsStandards.WriteLog(this, new Exception("No details found for document"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);

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
    protected bool CheckPrinterCon(string strIP, string strPort)
    {
        try
        {
            return PrintDirect.CheckConnection(strIP, strPort);
        }
        catch (Exception ex)
        {
            return false;
            throw ex;
        }
       
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        bool pFlag = false;
        DataTable dtPRint = new DataTable();
        BL_GrnPrinting objGrn = new BL_GrnPrinting();
        BL_PrinterMaster objPrint = new BL_PrinterMaster();
        int iQty = 0;
        int iPackSize = 0;
        int pCount = 0;
        string strIp, strPort;
        DataTable dt = new DataTable();

        try
        {
            dt = objPrint.BL_PrinterIPandPort(ddlPrinterName.Text.Trim(), clsStandards.current_Plant().ToString());

            btnPrint.Enabled = false;

            if (dt.Rows.Count > 0)
            {
                strIp = dt.Rows[0][0].ToString();
                strPort = dt.Rows[0][1].ToString();

                if (CheckPrinterCon(strIp, strPort) == false)
                {
                    clsStandards.WriteLog(this, new Exception("Printer is not connected. Please check IP and Port Number for '" + ddlPrinterName.Text + "'"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    return;
                }
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Printer Details not found"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return;
            }

            if (GrGRNDetails.Rows.Count > 0)
            {
                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                    if (cb.Checked == true)
                    {
                        pCount = pCount + 1;
                        if (pnlPackQty.Visible == true)
                        {
                            if (!checkCont(GrGRNDetails.Rows[i].Cells[13].Text.Trim()))
                            {
                                return;
                            }
                            if (!checkQty(GrGRNDetails.Rows[i].Cells[12].Text.Trim()))
                            {
                                return;
                            }
                            if (pnlNoofCon.Visible == false)
                            {
                                iPackSize = Convert.ToInt32(txtPackQty.Text.Trim());
                                dtPRint = objGrn.BL_GetBarcodeNo(GrGRNDetails.Rows[i].Cells[1].Text.Trim(), GrGRNDetails.Rows[i].Cells[2].Text.Trim(),
                                GrGRNDetails.Rows[i].Cells[4].Text.Trim(), GrGRNDetails.Rows[i].Cells[12].Text.Trim(), iPackSize.ToString(), 
                                clsStandards.current_Plant().ToString(), clsStandards.current_Username().ToString(),
                                "PRINT", Convert.ToInt32(GrGRNDetails.Rows[i].Cells[13].Text.Trim()), GrGRNDetails.Rows[i].Cells[6].Text.Trim(), "");
                            }
                            else
                            {
                                int number;
                                bool success = int.TryParse(txtNoof.Text.Trim(), out number);

                                if (success)
                                {
                                    dtPRint = objGrn.BL_GetBarcodeNo(GrGRNDetails.Rows[i].Cells[1].Text.Trim(), GrGRNDetails.Rows[i].Cells[2].Text.Trim(),
                                    GrGRNDetails.Rows[i].Cells[4].Text.Trim(), GrGRNDetails.Rows[i].Cells[12].Text.Trim(), 
                                    txtPackQty.Text.Trim(), clsStandards.current_Plant().ToString(), clsStandards.current_Username().ToString(),
                                    "PRINT", number, GrGRNDetails.Rows[i].Cells[6].Text.Trim(), "");
                                }
                                else
                                {
                                    clsStandards.WriteLog(this, new Exception("Please enter correct container number"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                                    txtNoof.Text = string.Empty;
                                    txtNoof.Focus();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (pnlNoofCon.Visible == false)
                            {
                                dtPRint = objGrn.BL_GetBarcodeNo(GrGRNDetails.Rows[i].Cells[1].Text.Trim(), GrGRNDetails.Rows[i].Cells[2].Text.Trim(),
                                      GrGRNDetails.Rows[i].Cells[4].Text.Trim(), GrGRNDetails.Rows[i].Cells[12].Text.Trim(),
                                      Convert.ToString("0"), clsStandards.current_Plant().ToString(), clsStandards.current_Username().ToString(), "PRINT",
                                      Convert.ToInt32(GrGRNDetails.Rows[i].Cells[13].Text.Trim()), GrGRNDetails.Rows[i].Cells[6].Text.Trim(), "");
                            }
                            else
                            {
                                int number;
                                bool success = int.TryParse(txtNoof.Text.Trim(), out number);

                                if (success)
                                {
                                    dtPRint = objGrn.BL_GetBarcodeNo(GrGRNDetails.Rows[i].Cells[1].Text.Trim(), GrGRNDetails.Rows[i].Cells[2].Text.Trim(),
                                          GrGRNDetails.Rows[i].Cells[4].Text.Trim(), GrGRNDetails.Rows[i].Cells[12].Text.Trim(),
                                          Convert.ToString("0"), clsStandards.current_Plant().ToString(),
                                          clsStandards.current_Username().ToString(), "PRINT", number, GrGRNDetails.Rows[i].Cells[6].Text.Trim(), "");
                                }
                                else
                                {
                                    clsStandards.WriteLog(this, new Exception("Please enter correct container number"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                                    txtNoof.Text = string.Empty;
                                    txtNoof.Focus();
                                    return;
                                }
                            }
                        }


                        if (dtPRint.Rows[0]["Printst"].ToString() == "0")
                        {
                            objGrn.BL_SaveGRNERPUpdate(GrGRNDetails.Rows[i].Cells[1].Text.Trim(), GrGRNDetails.Rows[i].Cells[4].Text.Trim(), GrGRNDetails.Rows[i].Cells[6].Text.Trim());
                        }

                        pFlag = PrintDirect.Print_MaterialLabelIP(ddlPrinterName.Text.Trim(), clsStandards.current_Username().ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"),strIp,strPort,dtPRint);
                        
                        if (pFlag == true)
                        {
                            clsStandards.WriteLog(this, new Exception("Barcode Printed Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                            clsBLCommon.ClearControl(txtDocumentNo,txtPackQty,GrGRNDetails,ddlPrinterName,txtNoof);
                            lblNoofCont.Text = "";
                            lblRemainingQty.Text = "";
                            ViewState["PrintQty"] =null;
                            ViewState["PrintCount"] = null;
                            btnPrint.Enabled = true;
                        }
                        else
                        {
                            clsStandards.WriteLog(this, new Exception("Problem in Printing"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                        }
                    }
                }
                if (pCount == 0)
                {
                    clsStandards.WriteLog(this, new Exception("Please select any record for Printing"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                }
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("No details to print against this document"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }



        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Thread was being aborted"))
            {
             HttpContext.Current.Response.Redirect(ResolveUrl("~/Modules/frmMain.aspx"), false);
            }
            clsStandards.WriteLog(this, new Exception(ex.ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true); 
        }
        finally
        {
            objGrn = null;
            objPrint = null;
            dt = null;
        }
    }
    protected bool checkCont(string strCount)
    {
        if (ViewState["PrintCount"] == null)
        {
            int number;
            bool success = int.TryParse(txtNoof.Text.Trim(), out number);

            if (!success)
            {
                clsStandards.WriteLog(this, new Exception("Enter Correct Container Qty"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return false;
            }

            if (int.Parse(txtNoof.Text.Trim()) <= int.Parse(strCount))
            {
                return true;
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Container Count is : "+strCount), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return false;
            }
        }
        else
        {
            int number;
            bool success = int.TryParse(txtNoof.Text.Trim(), out number);

            if (!success)
            {
                clsStandards.WriteLog(this, new Exception("Enter Correct Container Qty"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return false;
            }
            if (int.Parse(txtNoof.Text.Trim()) <= (int.Parse(strCount) - int.Parse(ViewState["PrintCount"].ToString())))
            {
                return true;
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Available container Count is : " + (int.Parse(strCount) - int.Parse(ViewState["PrintCount"].ToString())).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return false;
            }

        }
    }
    protected bool checkQty(string strQty)
    {
        if (ViewState["PrintQty"] == null)
        {
            if (Math.Round((int.Parse(txtNoof.Text.Trim()) * double.Parse(txtPackQty.Text.Trim())),3) <= double.Parse(strQty))
            {
                return true;
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Total quantity is : " + strQty), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return false;
            }
        }
        else
        {
            if (int.Parse(txtNoof.Text.Trim()) * double.Parse(txtPackQty.Text.Trim()) <= Math.Round(((double.Parse(strQty) - double.Parse(ViewState["PrintQty"].ToString()))),3))
            {
                return true;
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Available quantity is : " + (double.Parse(strQty) - double.Parse(ViewState["PrintQty"].ToString())).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                return false;
            }
        }
    }
    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        string strMaterialType = "";
        string strNoOfCont = "";
        BL_GrnPrinting objBL = new BL_GrnPrinting();
        DataTable dtGrn = new DataTable();
        try
        {
            if (GrGRNDetails.Rows.Count > 0)
            {
                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {

                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                    if (cb.Checked == true)
                    {
                        strMaterialType = GrGRNDetails.Rows[i].Cells[15].Text.ToString();
                        strNoOfCont = GrGRNDetails.Rows[i].Cells[13].Text.ToString();

                        dtGrn = objBL.BL_GetGRNPrintedCount(txtDocumentNo.Text.Trim(), GrGRNDetails.Rows[i].Cells[6].Text);

                        if (dtGrn.Rows.Count > 0)
                        {
                            lblRemainingQty.Text = "Remaining Qty : " + (double.Parse(GrGRNDetails.Rows[i].Cells[12].Text.ToString()) - double.Parse(dtGrn.Rows[0]["Printed_Qty"].ToString())).ToString();
                            lblRemainingQty.ForeColor = System.Drawing.Color.Green;
                            lblNoofCont.Text = "Remaining Container : " + (int.Parse(GrGRNDetails.Rows[i].Cells[13].Text.ToString()) - int.Parse(dtGrn.Rows[0]["Printed_Container"].ToString())).ToString();
                            lblNoofCont.ForeColor = System.Drawing.Color.Green;
                            ViewState["PrintQty"] = double.Parse(dtGrn.Rows[0]["Printed_Qty"].ToString()).ToString();
                            ViewState["PrintCount"] = double.Parse(dtGrn.Rows[0]["Printed_Container"].ToString()).ToString();
                        }
                        else
                        {
                            lblRemainingQty.Text = string.Empty;
                            lblNoofCont.Text = string.Empty;
 
                        }
                        pnlPackQty.Visible = true;
                        pnlNoofCon.Visible = true;
                        return;

                    }
                    else
                    {
                        pnlPackQty.Visible = false;
                        pnlNoofCon.Visible = false;
                    }
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


    protected void btnClose_Click(object sender, EventArgs e)
    {
        try
        {
            HttpContext.Current.Response.Redirect(ResolveUrl("~/Modules/frmMain.aspx"), false);
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    protected void GrGRNDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
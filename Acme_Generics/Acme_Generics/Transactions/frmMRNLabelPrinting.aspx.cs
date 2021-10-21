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

public partial class frmMRNLabelPrinting : System.Web.UI.Page
{

    public static string strFlg = "";
    DataTable dtImport = new DataTable();


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<string> GetBatchNo(string prefixText, int count, string contextKey)
    {
        DataTable dt = new DataTable();
        BL_MRNLabel objBL = new BL_MRNLabel();
        try
        {
            List<string> Items = new List<string>();
            dt = objBL.BL_GetMRNDetails(prefixText, clsStandards.current_Plant());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Items.Add(dt.Rows[i]["ProductBatch"].ToString());
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
            strFlg = "ADD";


        }

    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


    protected void btnGet_Click(object sender, EventArgs e)
    {
        BL_MRNLabel objBL = new BL_MRNLabel();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_GetMRNData(txtBatchNo.Text.Trim(), clsStandards.current_Plant());

            if (dtGrn.Rows.Count > 0)
            {
                ddlProdCode.Items.Clear();
                ddlProdCode.Items.Add("Select");

                foreach (DataRow dr in dtGrn.Rows)
                {
                    ddlProdCode.Items.Add(dr["PRODUCTCODE"].ToString());
                }

                ddlProdCode.SelectedIndex = 1;
                ddlProdCode_SelectedIndexChanged(sender, e);
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("No details For Product Batch"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
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
            throw new Exception(ex.ToString());
        }
        finally
        {
        }
    }


    protected void ddlMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMaterialCode.Text != "Select")
        {
            DataTable dt = new DataTable();
            DataTable dtNew = new DataTable();

            dt = (DataTable)ViewState["MRNData"];
            dtNew = dt.Clone();
            dtNew = dt.Select("MATERIALCODE = '" + ddlMaterialCode.Text.Trim().ToString() + "'").CopyToDataTable();

            var chr = (from r in dtNew.AsEnumerable() select r["ARNo"]).Distinct().ToList();

            lblUOM.Text = dtNew.Rows[0]["UOM"].ToString();

            if (dtNew.Rows[0]["UOM"].ToString() == "NOS")
            {
                txtGWeight.Text = "0";
                txtTWeight.Text = "0";
            }

            ddlARNo.Items.Clear();
            ddlARNo.Items.Add("Select");

            foreach (string str in chr)
            {
                ddlARNo.Items.Add(str);
            }

            if (ddlARNo.Items.Count > 1)
            {
                ddlARNo.SelectedIndex = 1;
                ddlARNo_SelectedIndexChanged(sender, e);
            }
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
    protected void ClearControl()
    {
        txtGWeight.Text = string.Empty;
        txtNWeight.Text = string.Empty;
        txtTWeight.Text = string.Empty;
        txtContNo.Text = string.Empty;
    }
    protected void btnPrint_Click1(object sender, EventArgs e)
    {
        
        DataTable dtPRint = new DataTable();
        DataTable dt = new DataTable();
        BL_MRNLabel objGrn = new BL_MRNLabel();
        BL_PrinterMaster objPrint = new BL_PrinterMaster();
        string strIp, strPort;

        try
        {
            dt = objPrint.BL_PrinterIPandPort(ddlPrinterName.Text.Trim(), clsStandards.current_Plant().ToString());

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

            dtPRint = objGrn.BL_GetMRNBarcodeNo(ddlARNo.Text.Trim(), txtContNo.Text.Trim(), ddlMaterialCode.Text.Trim(), txtTWeight.Text.Trim(), txtNWeight.Text.Trim(), txtGWeight.Text.Trim(), clsStandards.current_Username().ToString(), txtBatchNo.Text.Trim(), lblProdName.Text.Trim(),ddlLineItem.Text.Trim());

            if (PrintDirect.Print_MRNLabelIP(ddlPrinterName.Text.Trim(), clsStandards.current_Username().ToString(), System.DateTime.Now.ToString("dd/MM/yyyy"), strIp, strPort, dtPRint, txtBatchNo.Text.Trim(), lblProdName.Text.Trim(),lblUOM.Text) == true)
            {
                clsStandards.WriteLog(this, new Exception("Label Printed Successfully."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                ClearControl();
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Problem in Printing."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
        }
        catch (Exception ex)

        {
            throw new Exception(ex.ToString());

        }
        finally
        {
            objGrn = null;
            objPrint = null;

        }
    }
    protected void ddlARNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlARNo.Text != "Select")
        {
            DataTable dt = new DataTable();
            DataTable dtNew = new DataTable();

            dt = (DataTable)ViewState["MRNData"];
            dtNew = dt.Clone();
            dtNew = dt.Select("MATERIALCODE = '" + ddlMaterialCode.Text.Trim().ToString() + "' and ARNO ='" + ddlARNo.Text.Trim() + "'").CopyToDataTable();

            var chr = (from r in dtNew.AsEnumerable() select r["LineItem"]).Distinct().ToList();

            ddlLineItem.Items.Clear();
            ddlLineItem.Items.Add("Select");

            foreach (string str in chr)
            {
                ddlLineItem.Items.Add(str);
            }

            if (ddlLineItem.Items.Count > 1)
            {
                ddlLineItem.SelectedIndex = 1;
                ddlLineItem_SelectedIndexChanged(sender, e);
            }

            //lblDispQty.Text = double.Parse(dtNew.Rows[0]["SCANNEDQUANTITY"].ToString()).ToString();
        }
        else
        {
            lblDispQty.Text = string.Empty;
        }

    }
    protected void txtTWeight_TextChanged(object sender, EventArgs e)
    {
        if (txtGWeight.Text.Trim() != string.Empty && txtTWeight.Text.Trim() != string.Empty)
        {
            if (txtGWeight.Text.Trim() != "0" && txtTWeight.Text.Trim() != "0")
            {
                txtNWeight.Text = (double.Parse(txtGWeight.Text.Trim()) - double.Parse(txtTWeight.Text.Trim())).ToString();
            }
        }
    }
    protected void txtGWeight_TextChanged(object sender, EventArgs e)
    {
        if (txtGWeight.Text.Trim() != string.Empty && txtTWeight.Text.Trim() != string.Empty)
        {
            if (txtGWeight.Text.Trim() != "0" && txtTWeight.Text.Trim() != "0")
            {
                txtNWeight.Text = (double.Parse(txtGWeight.Text.Trim()) - double.Parse(txtTWeight.Text.Trim())).ToString();
            }
        }
    }
    protected void ddlLineItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataTable dtNew = new DataTable();

        try
        {
            dt = (DataTable)ViewState["MRNData"];
            dtNew = dt.Clone();
            dtNew = dt.Select("MATERIALCODE = '" + ddlMaterialCode.Text.Trim().ToString() + "' and ARNO ='" + ddlARNo.Text.Trim() + "'  and LineItem ='" +ddlLineItem.Text.Trim()+ "'").CopyToDataTable();

            lblDispQty.Text = double.Parse(dtNew.Rows[0]["SCANNEDQUANTITY"].ToString()).ToString();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dt = null;
            dtNew = null;
        }
    }
    protected void ddlProdCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        BL_MRNLabel objBL = new BL_MRNLabel();
        DataTable dtGrn = new DataTable();
        try
        {

            dtGrn = objBL.BL_GetMRNData(txtBatchNo.Text.Trim(), ddlProdCode.Text.Trim(), clsStandards.current_Plant().ToString());
           
            if (ViewState["MRNData"] != null)
            {
                ViewState["MRNData"] = null;
            }

            if (dtGrn.Rows.Count > 0)
            {
                ViewState["MRNData"] = dtGrn;
                lblProdName.Text = dtGrn.Rows[0]["PRODUCTNAME"].ToString();
                lblProOrder.Text = dtGrn.Rows[0]["PROCESSORDERNO"].ToString();
                clsStandards.fillCombobox(ddlMaterialCode, dtGrn, "MATERIALCODE");
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
 
        }
    }

}
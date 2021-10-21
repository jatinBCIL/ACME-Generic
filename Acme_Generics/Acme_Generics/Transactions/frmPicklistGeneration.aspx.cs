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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
        BL_PickList objBL = new BL_PickList();
        DataTable dtGrn = new DataTable();
        try
        {
            if (txtBatchNo.Text.Trim() != "")
            {
                foreach (string str in txtBatchNo.Text.Split(','))
                {
                    DataTable dt1 = new DataTable();

                    dt1 = objBL.DL_GetBatchDetails(txtFrom.Text.Trim(), txtTo.Text.Trim(), str, "BATCH");
                   
                    //if (dt1.Rows.Count > 0)
                    //{
                    //    if (dt1.Rows[0]["PICK"].ToString() == "1")
                    //    {
                    //        objBL.BL_UpdateERPData(str);
                            
                    //    }
                    //}
                    
                    dtGrn.Merge(dt1);
                }
                //dtGrn = objBL.DL_GetBatchDetails(txtFrom.Text.Trim(), txtTo.Text.Trim(), txtBatchNo.Text.Trim(), "BATCH");
            }
            else
            {
                dtGrn = objBL.DL_GetBatchDetails(txtFrom.Text.Trim(), txtTo.Text.Trim(), txtBatchNo.Text.Trim(), "BYDATE");
            }
            if (dtGrn.Rows.Count > 0)
            {
                GrGRNDetails.DataSource = dtGrn;
                GrGRNDetails.DataBind();
                btnGeneratePicklist.Enabled = true;
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
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BL_PickList objBL = new BL_PickList();
        DataTable dtGrn = new DataTable();
        try
        {
            dtGrn = objBL.BL_RefreshPicklist(txtBatchNo.Text.Trim(), "GET", clsStandards.current_Plant().ToString());
            if (dtGrn.Rows.Count > 0)
            {
                GrGRNDetails.DataSource = dtGrn;
                GrGRNDetails.DataBind();
            }
            else
            {
                GrGRNDetails.DataSource = null;
                GrGRNDetails.DataBind();
                // clsStandards.WriteLog(this, new Exception("No details found for document"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
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

    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        string strMaterialType = "";
        try
        {
            if (GrGRNDetails.Rows.Count > 0)
            {
                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {

                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                    if (cb.Checked == true)
                    {
                        strMaterialType = GrGRNDetails.Rows[i].Cells[15].ToString();
                        if (strMaterialType == "RM")
                        {
                            //pnlPackQty.Visible = false;
                        }
                        else
                        {
                            // pnlPackQty.Visible = true;
                        }
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
    protected void btnGeneratePicklist_Click(object sender, EventArgs e)
    {
        string strResult = "";
        BL_PickList objBL = new BL_PickList();
        DataTable dt = new DataTable();
        try
        {
            if (GrGRNDetails.Rows.Count > 0)
            {
                dt.Columns.Add("MATERIALBATCH", typeof(string));
                dt.Columns.Add("MATERIALCODE", typeof(string));
                dt.Columns.Add("PRODUCTCODE", typeof(string));
                dt.Columns.Add("PRODUCTBATCH", typeof(string));
                dt.Columns.Add("PROCESSORDERNO", typeof(string));
                dt.Columns.Add("PRODUCTNAME", typeof(string));
                dt.Columns.Add("QTY", typeof(decimal));
                dt.Columns.Add("LOCQTY", typeof(decimal));
                dt.Columns.Add("LINEITEM", typeof(string));

                for (int i = 0; i < GrGRNDetails.Rows.Count; i++)
                {

                    CheckBox cb = (CheckBox)GrGRNDetails.Rows[i].FindControl("chkSelect");
                    if (cb.Checked == true)
                    {
                        DataRow dr = dt.NewRow();
                        dr["MATERIALBATCH"] = GrGRNDetails.Rows[i].Cells[8].Text.ToString();
                        dr["MATERIALCODE"] = GrGRNDetails.Rows[i].Cells[5].Text.ToString();
                        dr["PRODUCTCODE"] = GrGRNDetails.Rows[i].Cells[3].Text.ToString();
                        dr["PRODUCTBATCH"] = GrGRNDetails.Rows[i].Cells[2].Text.ToString();
                        dr["PROCESSORDERNO"] = GrGRNDetails.Rows[i].Cells[1].Text.ToString();
                        dr["PRODUCTNAME"] = GrGRNDetails.Rows[i].Cells[4].Text.ToString();
                        dr["QTY"] = GrGRNDetails.Rows[i].Cells[9].Text.ToString();
                        dr["LOCQTY"] = GrGRNDetails.Rows[i].Cells[10].Text.ToString();
                        dr["LINEITEM"] = GrGRNDetails.Rows[i].Cells[11].Text.ToString();
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                        btnGeneratePicklist.Enabled = false;
                        objBL.BL_UpdateERPData(GrGRNDetails.Rows[i].Cells[2].Text.ToString(), GrGRNDetails.Rows[i].Cells[11].Text.ToString(),
                          GrGRNDetails.Rows[i].Cells[8].Text.ToString());
                    }

                }
                strResult = objBL.BL_GeneratePicklist(dt, clsStandards.current_Username().ToString(), clsStandards.current_Plant());
                if (strResult.StartsWith("0"))
                {
                    GrGRNDetails.DataSource = null;
                    GrGRNDetails.DataBind();
                    clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    clsBLCommon.ClearControl(txtBatchNo, txtFrom, txtTo, GrGRNDetails);
                }
                else
                {
                    clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                }

            }
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            objBL = null;
            dt = null;
            btnGeneratePicklist.Enabled = true;
        }
    }
    protected void GrGRNDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
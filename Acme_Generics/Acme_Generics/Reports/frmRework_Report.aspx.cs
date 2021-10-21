using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
//using CrystalDecisions.ReportSource;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;

public partial class frmRework_Report : System.Web.UI.Page
{
    //ReportDocument oReport = new ReportDocument();
    BL_Reports objReports = new BL_Reports();
    clsReport objClReport = new clsReport();
    int _intRows;
    int _intTotalQty;
    double _dblValue;
    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod]


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            MultiView1.SetActiveView(View1);
            DataTable rpDt = new DataTable();
            ddlrpttype.Items.Clear();
            try
            {
                rpDt = clsBLCommon.getReportRights(clsStandards.current_Username()).Tables[0];

                ddlrpttype.Items.Add("Select Report");

                if (rpDt.Rows.Count > 0)
                {
                    foreach (DataRow dr in rpDt.Rows)
                    {
                        ddlrpttype.Items.Add(dr["Cap"].ToString());
                    }
                }
                //btnClose.PostBackUrl = ResolveUrl(System.Web.Configuration.WebConfigurationManager.AppSettings["PostBackURL"].ToString());
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            ViewState["Query"] = string.Empty;
        }
    }

    protected void ddlrpttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlrpttype.Text == "Sampling Report")
            {
                ViewState["Filters"] = "'AR No','Sampled on','Sampled By',";
                objReports.BindSearchGrid(grSearch, "VW_Sample_RPT", ViewState["Filters"].ToString());
            }
            else if (ddlrpttype.Text == "Material Status Report")
            {
                ViewState["Filters"] = "'Inward No','AR No' ,'Material Code' ,'Printed By','Printed On','Allocated On','Allocated By','Plant Code',";
                objReports.BindSearchGrid(grSearch, "VW_MAT_RPT", ViewState["Filters"].ToString());
            }

            else if (ddlrpttype.Text == "Batch Tracking Report")
            {
                ViewState["Filters"] = "'Picklist No','Product Batch','Picklist Created By','Picklist Created On','Picked By','Picked On','Dispensed On','Dispensed By','Confirmed On','Confirmed By','Plant Code',";
                objReports.BindSearchGrid(grSearch, "VW_BATCH_TRACKING", ViewState["Filters"].ToString());
            }
            else if (ddlrpttype.Text == "Picklist Report")
            {
                ViewState["Filters"] = "'Product Batch','Picklist Created By','Picklist Created On','Plant Code',";
                objReports.BindSearchGrid(grSearch, "VW_PICKING", ViewState["Filters"].ToString());
            }
            else if (ddlrpttype.Text == "Picking Report")
            {
                ViewState["Filters"] = "'Product Batch','Picked By','Picked On','Plant Code',";
                objReports.BindSearchGrid(grSearch, "VW_PICKLIST", ViewState["Filters"].ToString());
            }
            else if (ddlrpttype.Text == "Dispesing Report")
            {
                ViewState["Filters"] = "'Product Batch','Dispensed On','Dispensed By','Plant Code',";
                objReports.BindSearchGrid(grSearch, "VW_DISPENSING", ViewState["Filters"].ToString());
            }
            //else if (ddlrpttype.Text == "Mapping Report")
            else if (ddlrpttype.Text == "Dispesing Confirmation Report")
            {
                ViewState["Filters"] = "'Product Batch','Confirmed On','Confirmed By','Plant Code',";
                objReports.BindSearchGrid(grSearch, "VW_DISPENSING_CONFIRM", ViewState["Filters"].ToString());
            }

            else if (ddlrpttype.Text == "Dispesing Details Report")
            {
                ViewState["Filters"] = "'Product Batch','Created On','Created By','Plant Code',";
                objReports.BindSearchGrid(grSearch, "VW_DISP_DTL", ViewState["Filters"].ToString());
            }

            for (int i = 0; i < grSearch.Rows.Count; i++)
            {
                if ((grSearch.Rows[i].Cells[1].Text == "datetime") || (grSearch.Rows[i].Cells[1].Text == "date"))
                {
                    ((DropDownList)grSearch.Rows[i].Cells[2].FindControl("cboCriteria")).Visible = false;
                    ((TextBox)grSearch.Rows[i].Cells[3].FindControl("txtSearch")).Visible = false;
                    ((System.Web.UI.HtmlControls.HtmlTable)grSearch.Rows[i].Cells[3].FindControl("tblDate")).Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, new Exception(ex.Message), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
        }
    }

    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        string strQuery = string.Empty;
        DataSet ds = new DataSet();

        try
        {
            string strWhere = "";

            for (int j = 0; j < grSearch.Rows.Count; j++)
            {
                if (grSearch.Rows[j].Cells[1].Text == "datetime" || (grSearch.Rows[j].Cells[1].Text == "date"))
                {
                    if (((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtFrom")).Text != "" || ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtTo")).Text != "")
                    {
                        if (strWhere == "")
                        {
                            strWhere = createDateCondition(grSearch.Rows[j].Cells[0].Text, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtFrom")).Text, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtTo")).Text);
                        }
                        else
                        {
                            strWhere = strWhere + "AND " + createDateCondition(grSearch.Rows[j].Cells[0].Text, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtFrom")).Text, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtTo")).Text);
                        }
                    }
                }
                else
                {
                    if (((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtSearch")).Text != "")
                    {
                        if (strWhere == "")
                        {
                            strWhere = createCondition(grSearch.Rows[j].Cells[0].Text, ((DropDownList)grSearch.Rows[j].Cells[2].FindControl("cboCriteria")).SelectedValue, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtSearch")).Text);
                        }
                        else
                        {
                            strWhere = strWhere + "AND " + createCondition(grSearch.Rows[j].Cells[0].Text, ((DropDownList)grSearch.Rows[j].Cells[2].FindControl("cboCriteria")).SelectedValue, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtSearch")).Text);
                        }
                    }
                }
            }
            {
                if (strWhere.Length != 0)
                {
                    strWhere = "Where " + strWhere;
                }
                if (ddlrpttype.Text == "Sampling Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_Sample", "", strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Material Status Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_MaterialReport", "", strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Batch Tracking Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_BatTrackingReport", "", strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Picklist Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_PicklistReport", "", strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Picking Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_PickingReport", "", strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }

                else if (ddlrpttype.Text == "Dispesing Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_DispenseReport", "", strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }

                else if (ddlrpttype.Text == "Dispesing Confirmation Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_DispenseConfirmReport", "", strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }

                else if (ddlrpttype.Text == "Dispesing Details Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_DispensingDetailsReport", "", strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }

                else if (ddlrpttype.Text == "Select Report ")
                {
                    clsStandards.WriteLog(this, new Exception("Select Report Name To Display"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
                }
                ViewState["Query"] = strQuery;
                ViewState["Where"] = strWhere;
            }
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, new Exception(ex.Message), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
        }
        finally
        {

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strQuery = string.Empty;
        DataSet ds = new DataSet();
        int st = 0;

        try
        {
            string strWhere = "";

            for (int j = 0; j < grSearch.Rows.Count; j++)
            {
                if (grSearch.Rows[j].Cells[1].Text == "datetime" || (grSearch.Rows[j].Cells[1].Text == "date"))
                {
                    if (((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtFrom")).Text != "" || ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtTo")).Text != "")
                    {
                        st++;
                        if (strWhere == "")
                        {
                            strWhere = createDateCondition(grSearch.Rows[j].Cells[0].Text, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtFrom")).Text, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtTo")).Text);
                        }
                        else
                        {
                            strWhere = strWhere + "AND " + createDateCondition(grSearch.Rows[j].Cells[0].Text, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtFrom")).Text, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtTo")).Text);
                        }
                    }
                }
                else
                {
                    if (((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtSearch")).Text != "")
                    {
                        st++;
                        if (strWhere == "")
                        {
                            strWhere = createCondition(grSearch.Rows[j].Cells[0].Text, ((DropDownList)grSearch.Rows[j].Cells[2].FindControl("cboCriteria")).SelectedValue, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtSearch")).Text);
                        }
                        else
                        {
                            strWhere = strWhere + "AND " + createCondition(grSearch.Rows[j].Cells[0].Text, ((DropDownList)grSearch.Rows[j].Cells[2].FindControl("cboCriteria")).SelectedValue, ((TextBox)grSearch.Rows[j].Cells[3].FindControl("txtSearch")).Text);
                        }
                    }
                }
            }
            {
                if (strWhere.Length != 0)
                {
                    strWhere = "Where " + strWhere;
                }
                if (ddlrpttype.Text == "Sampling Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_Sample", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Material Status Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_MaterialReport", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Batch Tracking Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_BatTrackingReport", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Picklist Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_PicklistReport", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Picking Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_PickingReport", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }

                else if (ddlrpttype.Text == "Dispesing Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_DispenseReport", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }

                else if (ddlrpttype.Text == "Dispesing Confirmation Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_DispenseConfirmReport", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Dispesing Details Report")
                {
                    ds = objClReport.BL_Report_Genrater("RPT_DispensingDetailsReport", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                    //else if (ddlrpttype.Text == "Mapping Report")
                else if (ddlrpttype.Text == "Parent Child Report")
                {
                    if (st > 0)
                    {
                        ds = objClReport.BL_Report_Genrater("rptRelation", strWhere, strQuery);
                    }
                    else
                    {
                        ds = null;
                    }
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Secondary Rejection Report")
                {
                    ds = objClReport.BL_Report_Genrater("rptRejectionSec", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Tertiary Rejection Report")
                {
                    ds = objClReport.BL_Report_Genrater("rptRejectionTer", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Secondary Validation Report")
                {
                    ds = objClReport.BL_Report_Genrater("rptValidationSec", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Tertiary Validation Report")
                {
                    ds = objClReport.BL_Report_Genrater("rptValidationTer", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Secondary Unutilization Report")
                {
                    ds = objClReport.BL_Report_Genrater("rptUtlSec", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Tertiary Unutilization Report")
                {
                    ds = objClReport.BL_Report_Genrater("rptUtlTer", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Audit Trail Report")
                {
                    ds = objClReport.BL_Report_Genrater("rptAudit", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }
                else if (ddlrpttype.Text == "Batch Report")
                {
                    ds = objClReport.BL_Report_Genrater("rptBatch", strWhere, strQuery);
                    GrPlants.DataSource = ds;
                    GrPlants.DataBind();
                    MultiView1.SetActiveView(View2);
                }

                else if (ddlrpttype.Text == "Select Report ")
                {
                    clsStandards.WriteLog(this, new Exception("Select Report Name To Display"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
                }
                ViewState["Query"] = strQuery;
                ViewState["Where"] = strWhere;
            }
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, new Exception(ex.Message), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
        }
        finally
        {

        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
    }

    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        string strWhere = "";
        string strQuery = string.Empty;
        DataSet ds = new DataSet();
        BL_Reports objReports = new BL_Reports();
        try
        {
            if (ddlrpttype.Text == "Sampling Report")
            {
                clsxlsExport.ConvertToxls(objClReport.BL_Report_Genrater_EXL("RPT_Sample", ViewState["Where"].ToString(), strQuery).Tables[0], "Generation_Report");
            }

            else if (ddlrpttype.Text == "Material Status Report")
            {
                clsxlsExport.ConvertToxls(objClReport.BL_Report_Genrater_EXL("RPT_MaterialReport", ViewState["Where"].ToString(), strQuery).Tables[0], "Tertiary_Printing_Report");
            }

            else if (ddlrpttype.Text == "Picklist Report")
            {
                clsxlsExport.ConvertToxls(objClReport.BL_Report_Genrater_EXL("RPT_PicklistReport", ViewState["Where"].ToString(), strQuery).Tables[0], "Tertiary_Printing_Report");
               
            }
            else if (ddlrpttype.Text == "Picking Report")
            {
                clsxlsExport.ConvertToxls(objClReport.BL_Report_Genrater_EXL("RPT_PickingReport", ViewState["Where"].ToString(), strQuery).Tables[0], "Tertiary_Printing_Report");
            }

            else if (ddlrpttype.Text == "Dispesing Report")
            {
                clsxlsExport.ConvertToxls(objClReport.BL_Report_Genrater_EXL("RPT_DispenseReport", ViewState["Where"].ToString(), strQuery).Tables[0], "Tertiary_Printing_Report");
            }

            else if (ddlrpttype.Text == "Dispesing Confirmation Report")
            {
                clsxlsExport.ConvertToxls(objClReport.BL_Report_Genrater_EXL("RPT_DispenseConfirmReport", ViewState["Where"].ToString(), strQuery).Tables[0], "Tertiary_Printing_Report");
            }

            else if (ddlrpttype.Text == "Dispesing Details Report")
            {
                clsxlsExport.ConvertToxls(objClReport.BL_Report_Genrater_EXL("RPT_DispensingDetailsReport", ViewState["Where"].ToString(), strQuery).Tables[0], "Tertiary_Printing_Report");
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

    protected void GrPlants_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string strWhere = "";
        DataSet ds = new DataSet();
        GrPlants.PageIndex = e.NewPageIndex;
        string strQuery = string.Empty;
        //GrPlants.Caption = "Report Header : Loyalty Program Barcode Generation Request Report, Generated By : " + clsStandards.current_Username() + ", Generated On : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        //GrPlants.DataSource = clsCommon.getTable_Query_WithoutParameter(ViewState["Query"].ToString());
        //GrPlants.DataBind();
        try
        {
            if (ddlrpttype.Text == "Sampling Report")
            {
                ds = objClReport.BL_Report_Genrater("RPT_Sample", ViewState["Where"].ToString(), strQuery);
                GrPlants.DataSource = ds;
                GrPlants.DataBind();
            }
            else if (ddlrpttype.Text == "Material Status Report")
            {
                ds = objClReport.BL_Report_Genrater("RPT_MaterialReport", ViewState["Where"].ToString(), strQuery);
                GrPlants.DataSource = ds;
                GrPlants.DataBind();
                MultiView1.SetActiveView(View2);
            }
            else if (ddlrpttype.Text == "Batch Tracking Report")
            {
                ds = objClReport.BL_Report_Genrater("RPT_BatTrackingReport", ViewState["Where"].ToString(), strQuery);
                GrPlants.DataSource = ds;
                GrPlants.DataBind();
                MultiView1.SetActiveView(View2);
            }
            else if (ddlrpttype.Text == "Picklist Report")
            {
                ds = objClReport.BL_Report_Genrater("RPT_PicklistReport", ViewState["Where"].ToString(), strQuery);
                GrPlants.DataSource = ds;
                GrPlants.DataBind();
                MultiView1.SetActiveView(View2);
            }
            else if (ddlrpttype.Text == "Picking Report")
            {
                ds = objClReport.BL_Report_Genrater("RPT_PickingReport", ViewState["Where"].ToString(), strQuery);
                GrPlants.DataSource = ds;
                GrPlants.DataBind();
                MultiView1.SetActiveView(View2);
            }

            else if (ddlrpttype.Text == "Dispesing Report")
            {
                ds = objClReport.BL_Report_Genrater("RPT_DispenseReport", ViewState["Where"].ToString(), strQuery);
                GrPlants.DataSource = ds;
                GrPlants.DataBind();
                MultiView1.SetActiveView(View2);
            }

            else if (ddlrpttype.Text == "Dispesing Confirmation Report")
            {
                ds = objClReport.BL_Report_Genrater("RPT_DispenseConfirmReport", ViewState["Where"].ToString(), strQuery);
                GrPlants.DataSource = ds;
                GrPlants.DataBind();
                MultiView1.SetActiveView(View2);
            }
            else if (ddlrpttype.Text == "Dispesing Details Report")
            {
                ds = objClReport.BL_Report_Genrater("RPT_DispensingDetailsReport", ViewState["Where"].ToString(), strQuery);
                GrPlants.DataSource = ds;
                GrPlants.DataBind();
                MultiView1.SetActiveView(View2);
            }

        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, new Exception(ex.Message), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
        }

    }

    private string createCondition(string strColumn, string strPattern, string strValue)
    {
        string strReturn = "";
        strColumn = "\"" + strColumn + "\"";
        if (strValue != "")
        {
            if (strPattern == "=")
            {
                strReturn = strColumn + " = '" + strValue + "'";
            }
            else if (strPattern == "<>")
            {
                strReturn = strColumn + " <> '" + strValue + "'";
            }
            else if (strPattern == "like")
            {
                strReturn = strColumn + " like " + "'%" + strValue + "%'";
            }
            else if (strPattern == "likestart")
            {
                strReturn = strColumn + " like '" + strValue + "%'";
            }
            else if (strPattern == "likeend")
            {
                strReturn = strColumn + " like " + "'%" + strValue + "'";
            }
        }
        return strReturn;
    }

    private string createDateCondition(string strColumn, string dtstart, string dtEnd)
    {
        //return strColumn + " = " + strValue;
        string dtcon = "";
        if (dtstart.Trim() != "")
            dtcon = " CAST([" + strColumn + "] AS DATE) >= CAST('" + dtstart + "' AS DATE)";
        if (dtEnd.Trim() != "")
        {
            if (dtcon.Trim() == "")
                dtcon = dtcon + " CAST([" + strColumn + "] AS DATE) <=  CAST('" + dtEnd + "' AS DATE)";
            else
                dtcon = dtcon + " AND CAST([" + strColumn + "] AS DATE) <=  CAST('" + dtEnd + "' AS DATE)";
        }
        return dtcon;
    }

    protected void GrPlants_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int _intRows = 0, _intTotalQty = 0, _dblValue = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            _intRows += 1;
            //_intTotalQty = _intTotalQty + Convert.ToInt32(e.Row.Cells[7].Text);
            //_dblValue = _dblValue + Convert.ToDouble(e.Row.Cells[8].Text);
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Page " + (GrPlants.PageIndex + 1) + " of " + GrPlants.PageCount;
            e.Row.Cells[1].Text = clsStandards.FooterInfoReport(GrPlants);
            //e.Row.Cells[6].Text = "Total";
            //e.Row.Cells[7].Text = _intTotalQty.ToString();
            //e.Row.Cells[8].Text =  _dblValue.ToString();

            _intRows = 0;
            _intTotalQty = 0;
            _dblValue = 0;
        }
    }

    protected void btnClosePage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Main/frmMain.aspx");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


}

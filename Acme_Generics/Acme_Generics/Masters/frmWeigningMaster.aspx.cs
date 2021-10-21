using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using PropertyLayer;
using System.Data;

public partial class Masters_frmWeigningMaster : System.Web.UI.Page
{
    public static string strFlg = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
        BL_PlantMaster objPlant = new BL_PlantMaster();
        BL_BoothMaster objBooth = new BL_BoothMaster();
        if (!IsPostBack)
        {
            strFlg = "ADD";
            ViewState["REFNO"] = "";
            MultiView1.SetActiveView(View2);
            clsStandards.fillCombobox(ddPlantcode, objPlant.BL_Get_Plant_with_Desc(), "PLANTCODE");
            clsStandards.fillCombobox(ddlBooth, objBooth.BL_GetBoothCode(clsStandards.current_Plant().Trim().ToString()), "BOOTHCODE");
        }

    }
    protected void imgCloseV1_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.SetActiveView(View1);
    }
    protected void imgDetails_Click(object sender, ImageClickEventArgs e)
    {
        BL_WeighingMaster objMaster = new BL_WeighingMaster();
        try
        {

            cboSearch.Items.Clear();
            cboSearch.Items.Add(new ListItem("Location ID", "LOCID"));
            cboSearch.Items.Add(new ListItem("Location Name", "LOCNM"));
            cboSearch.Items.Add(new ListItem("Warehouse Type", "WH_TYPE"));
            clsStandards.populateGrid(objMaster.BL_GetWeighingDisplayData(clsStandards.WhereStatement_NoST(string.Empty, string.Empty, string.Empty)), GrPlant, "REFNO");
            //clsStandards.populateGrid(objMaster.getUsers(clsStandards.WhereStatement(0, cboSearch.SelectedValue, cboCriteria.SelectedValue, txtSearch.Text.Trim())), GrUser, "RECNO");

            //MultiView1.SetActiveView(View2);
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally { objMaster = null; }
        MultiView1.SetActiveView(View1);
    }

    public int status()
    {
        if (RBactivate.Checked)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {

        PL_WeighingMaster objField = new PL_WeighingMaster();
        BL_WeighingMaster objMaster = new BL_WeighingMaster();
        try
        {
            //string data1 = ddDepartment.Text.ToString();
            //string[] splitData1 = data1.Split('-');

            //objField.strDepartment = splitData1[0].ToString();




            objField.strPlantCode = ddPlantcode.SelectedItem.ToString().Trim().Split('-').GetValue(0).ToString();
            objField.strWeighingCode = txtWeighingCode.Text.Trim();
            objField.strWeighingIP = txtWeighingIP.Text.Trim();
            objField.strPort = txtWeighingPort.Text.Trim();
            objField.DScaleCapacity = Convert.ToDecimal(txtWeighingCapacity.Text.Trim());
            objField.ILeastCount = Convert.ToInt32(txtLeastCount.Text.Trim());
            objField.DMinValue = Convert.ToDecimal(txtMinValue.Text.Trim());
            objField.DMaxValue = Convert.ToDecimal(txtMaxValue.Text.Trim());


            objField.strMode = strFlg;

            objField.strBooth = ddlBooth.Text.Trim();

            //  objField.intStatus = clsStandards.ActivationStatus(chkStatus);
            objField.IStatus = status();
            objField.strUser = clsStandards.current_Username();
            if (strFlg == "EDIT" && ViewState["REFNO"].ToString() != "")
            {
                if (txtRemark.Text == "" || txtRemark.Text == null)
                {
                    clsStandards.WriteLog(this, new Exception("Remark Field Empty"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                    return;
                    //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Remark Field Empty');", true);
                    //return;
                }
                objField.REFNO = Convert.ToInt32(ViewState["REFNO"].ToString());
            }
            else
            {
                objField.REFNO = 0;
            }
            //  objField.strUsername = clsStandards.current_Username();
            objField.strRemark = txtRemark.Text.Trim();
            string strResult = objMaster.BL_InsertWeighingMaster(objField);
            if (strResult.StartsWith("0"))
            {
                clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
            }
            else if (strResult.StartsWith("1"))
            {
                clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 1, true);
            }
            else
            {
                clsStandards.WriteLog(this, new Exception("Problem in save."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
            try
            {
                clear();
                strFlg = "ADD";

            }
            catch (Exception ex)
            {
                clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }

        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            objMaster = null;
            objField = null;
        }
    }
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        BL_WeighingMaster objItems = new BL_WeighingMaster();
        try
        {
            clsStandards.populateGrid(objItems.BL_GetWeighingDisplayData(clsStandards.WhereStatement(0, cboSearch.SelectedValue, cboCriteria.SelectedValue, txtSearch.Text.Trim())), GrPlant, "REFNO");
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            objItems = null;
        }
        MultiView1.SetActiveView(View1);

    }
    protected void GrPlant_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrPlant.PageIndex = e.NewPageIndex;
        BL_WeighingMaster objMaster = new BL_WeighingMaster();
        try
        {
            clsStandards.populateGrid(objMaster.BL_GetWeighingDisplayData(clsStandards.WhereStatement_NoST(cboSearch.SelectedValue, cboCriteria.SelectedValue, txtSearch.Text.Trim())), GrPlant, "REFNO");
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            objMaster = null;
        }
    }

    public void VisibleRemarkTrue()
    {
        lblRemark.Visible = true;
        txtRemark.Visible = true;
    }

    //sets the Remark fields Visible False
    public void VisibleRemarkFalse()
    {
        lblRemark.Visible = false;
        txtRemark.Visible = false;
    }

    public void clear()
    {
        //BL_DepartmentMaster objDepartment = new BL_DepartmentMaster();
        txtLeastCount.Enabled = true;
        txtMaxValue.Text = string.Empty;
        txtMinValue.Text = string.Empty;
        txtRemark.Text = string.Empty;
        txtWeighingCapacity.Text = string.Empty;
        txtWeighingCode.Text = string.Empty;
        txtWeighingIP.Text = string.Empty;
        txtWeighingPort.Text = string.Empty;

        try
        {
            //clsStandards.fillCombobox(ddDepartment, objDepartment.BL_GetDepartmentCode(), "DEPARTMENTCODE");
            ddPlantcode.SelectedValue = "Select";
            ddlBooth.SelectedValue = "Select";

            //ddDepartment.SelectedValue = "Select";
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }

    }
    protected void imgAdd1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            VisibleRemarkFalse();
            clear();
            MultiView1.SetActiveView(View2);
            strFlg = "ADD";
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
    }
    protected void imgExport_Click(object sender, ImageClickEventArgs e)
    {
        BL_WeighingMaster objMaster = new BL_WeighingMaster();
        try
        {
            GrPlant.AllowPaging = false;
            GrPlant.AllowSorting = false;

            //clsxlsExport.ExportExcel(GrPlant, "Company.xls");
            // clsStandards.populateGrid(objMaster.GetUsersDisplayData(clsStandards.WhereStatement_NoST(string.Empty, string.Empty, string.Empty)), GrUser, "RECNO");
            clsxlsExport.ConvertToxls(objMaster.BL_GetWeighingDisplayData(clsStandards.WhereStatement_NoST(cboSearch.SelectedValue, cboCriteria.SelectedValue, txtSearch.Text.Trim())), "WeighingMaster");
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            objMaster = null;
        }
    }
    protected void GrPlant_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL_BinMaster objDepartment = new BL_BinMaster();
        if (e.CommandName == "Select")
        {
            int RowInd = ((GridViewRow)(((LinkButton)e.CommandSource).NamingContainer)).RowIndex;
            // GridViewRow gr = GrDept.Rows[Convert.ToInt32(e.CommandArgument)];
            DataTable dt = new DataTable();
            BL_WeighingMaster objMaster = new BL_WeighingMaster();
            PL_WeighingMaster objCon = new PL_WeighingMaster();
            BL_Chnage blChange = new BL_Chnage();
            try
            {
                dt = objMaster.BL_GetWeighingDisplayData(clsStandards.WhereStatement_NoST("[REFNO]", "Equal to", GrPlant.DataKeys[RowInd].Value.ToString()));
                if (dt.Rows.Count != 0)
                {
                    //ddDepartment.Items.Clear();
                    //clsStandards.fillCombobox(ddDepartment, objDepartment.BL_GetDepartmentCode(), "DEPARTMENTCODE");
                    try
                    {
                        //ddPlantcode.SelectedValue = dt.Rows[0]["PLANTCODE"].ToString();
                        ddPlantcode.SelectedValue = blChange.Bl_get_strPlant_desc(dt.Rows[0]["PLANTCODE"].ToString());
                        ddlBooth.SelectedValue = dt.Rows[0]["BOOTH"].ToString();
                        //ddDepartment.SelectedValue = dt.Rows[0]["DEPARTMENT"].ToString();
                        //ddDepartment.SelectedValue = blChange.Bl_get_strDept_desc(dt.Rows[0]["DEPARTMENT"].ToString());
                        //ddModule.SelectedValue = dt.Rows[0]["MODULE"].ToString();
                        //ddType.SelectedValue = dt.Rows[0]["USER_TYPE"].ToString();
                    }
                    catch
                    {
                    }

                    txtLeastCount.Text = dt.Rows[0]["LEASTCOUNT"].ToString();
                    txtMaxValue.Text = dt.Rows[0]["MAXVALUE"].ToString();
                    txtMinValue.Text = dt.Rows[0]["MINVALUE"].ToString();
                    txtRemark.Text = dt.Rows[0]["REMARK"].ToString();
                    txtWeighingCapacity.Text = dt.Rows[0]["WEIGHINGCAPACITY"].ToString();
                    txtWeighingCode.Text = dt.Rows[0]["WEIGHINGCODE"].ToString();
                    txtWeighingIP.Text = dt.Rows[0]["WEIGHINGIP"].ToString();
                    txtWeighingPort.Text = dt.Rows[0]["WEIGHINGPORT"].ToString();
                    RBactivate.Checked = ((dt.Rows[0]["Status"].ToString() == "Activate") ? true : false);
                    RBdeactivate.Checked = ((dt.Rows[0]["Status"].ToString() == "Deactivate") ? true : false);

                    ViewState["REFNO"] = dt.Rows[0]["REFNO"].ToString();
                    strFlg = "EDIT";
                    imgSave.Enabled = true;
                    VisibleRemarkTrue();
                    MultiView1.SetActiveView(View2);


                }
                else
                {
                    clsStandards.WriteLog(this, new Exception("Problem fetching details for selected Other Cleaning."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                }
            }
            catch (Exception ex)
            {
                clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
            finally
            {
                dt = null;
                objMaster = null;
            }

        }
    }
}
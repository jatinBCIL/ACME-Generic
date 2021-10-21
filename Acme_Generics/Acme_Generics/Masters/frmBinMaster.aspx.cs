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

public partial class frmBin_Master : System.Web.UI.Page
{

    public static string strFlg = "";
    DataTable dtImport = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region
        //if (!IsPostBack)
        //{
        //    ViewState["EDIT"] = null;
        //    BL_PlantMaster objPlant = new BL_PlantMaster();
        //    BL_DepartmentMaster objDepartment = new BL_DepartmentMaster();
        //    BL_UserMaster objMaster = new BL_UserMaster();
        //    DataTable dt_AscPlant = new DataTable();
        //    DataTable dt = new DataTable();
        //    DataTable dt_Plant = new DataTable();
        //    DataSet ds = new DataSet();
        //    try
        //    {



        //        ds = objMaster.BL_GetuserRols("");
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                cblTRole.Items.Add(ds.Tables[0].Rows[i][0].ToString());

        //            }

        //        }
        //        if (ds.Tables[1].Rows.Count > 0)
        //        {
        //            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //            {

        //                cblDRole.Items.Add(ds.Tables[1].Rows[i][0].ToString());
        //            }

        //        }
        //        //clsStandards.fillCombobox(ddPlantcode, objPlant.BL_Get_Plant(), "PLANTCODE");
        //        clsStandards.fillCombobox(ddPlantcode, objPlant.BL_Get_Plant_with_Desc(), "PLANTCODE");
        //        //   clsStandards.fillCombobox(ddDepartment, objDepartment.BL_GetDepartmentCode(), "DEPARTMENTCODE");

        //        //dt = objDepartment.BL_GetDepartmentCode();
        //        //if (dt.Rows.Count > 0)
        //        //{
        //        //    for (int i = 0; i < dt.Rows.Count; i++)
        //        //    {
        //        //        cblTDept.Items.Add(dt.Rows[i][0].ToString());
        //        //        cblDDept.Items.Add(dt.Rows[i][0].ToString());
        //        //    }
        //        //}

        //        dt_Plant = objPlant.BL_Get_Plant_with_Desc();

        //        dt_AscPlant = objPlant.BL_getAsc_Desc();
        //        if (dt_Plant.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt_Plant.Rows.Count; i++)
        //            {
        //                cblTPlant.Items.Add(dt_Plant.Rows[i][0].ToString());
        //                cblDPlant.Items.Add(dt_Plant.Rows[i][0].ToString());
        //            }
        //        }
        //        clsStandards.fillCombobox(ddlUserid, objMaster.BL_GetUserID(), "USER_ID");

        //        grPlant1.DataSource = null;
        //        grPlant1.DataBind();
        //        pnlImport.Visible = false;

        //        grdExcelRight.DataSource = null;
        //        grdExcelRight.DataBind();
        //        Panel1.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        //    }
        //    finally
        //    {
        //        objPlant = null;
        //    }
        //    MultiView1.SetActiveView(View2);
        //    strFlg = "ADD";
        //}
        #endregion

        if (!IsPostBack)
        {
            ViewState["EDIT"] = null;
            BL_PlantMaster objPlant = new BL_PlantMaster();
            BL_UserMaster objMaster = new BL_UserMaster();
            DataTable dt = new DataTable();
            DataTable dt_Plant = new DataTable();
            DataTable dt_AscPlant = new DataTable();
            DataSet ds = new DataSet();
            try
            {



                //ds = objMaster.BL_GetuserRols("");
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {
                //        cblTRole.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                //    }

                //}
                //if (ds.Tables[1].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                //    {

                //        //cblDRole.Items.Add(ds.Tables[1].Rows[i][0].ToString());
                //    }

                //}
                //clsStandards.fillCombobox(ddPlantcode, objPlant.BL_Get_Plant(), "PLANTCODE");
                clsStandards.fillCombobox(ddPlantcode, objPlant.BL_Get_Plant_with_Desc(), "PLANTCODE");
                //   clsStandards.fillCombobox(ddDepartment, objDepartment.BL_GetDepartmentCode(), "DEPARTMENTCODE");

                //dt = objDepartment.BL_GetDepartmentCode();
                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        cblTDept.Items.Add(dt.Rows[i][0].ToString());
                //        cblDDept.Items.Add(dt.Rows[i][0].ToString());
                //    }
                //}

                //dt_Plant = objPlant.BL_Get_Plant_with_Desc();
                //dt_AscPlant = objPlant.BL_getAsc_Desc();
                //if (dt_Plant.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt_Plant.Rows.Count; i++)
                //    {
                //        cblTPlant.Items.Add(dt_Plant.Rows[i][0].ToString());

                //        //cblDPlant.Items.Add(dt_Plant.Rows[i][0].ToString());
                //    }
                //}
                //if (dt_AscPlant.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt_AscPlant.Rows.Count; i++)
                //    {
                //        //cbTAssociatePlant.Items.Add(dt_AscPlant.Rows[i][0].ToString());
                //        // cbDAscPlant.Items.Add(dt_AscPlant.Rows[i][0].ToString());
                //    }
                //}

                //clsStandards.fillCombobox(ddlUserid, objMaster.BL_GetUserID(), "USER_ID");

                grPlant1.DataSource = null;
                grPlant1.DataBind();
                pnlImport.Visible = true;

                //grdExcelRight.DataSource = null;
                //grdExcelRight.DataBind();
                //Panel1.Visible = true;

                btnSave.Visible = false;
                btnCancel.Visible = false;
                //btnSaveRightExcel.Visible = false;
                //btnCancelRightExcel.Visible = false;
            }
            catch (Exception ex)
            {
                clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
            finally
            {
                objPlant = null;
            }
            MultiView1.SetActiveView(View2);
            strFlg = "ADD";


        }



    }



    protected void imgDetails_Click(object sender, ImageClickEventArgs e)
    {
        BL_BinMaster objMaster = new BL_BinMaster();



        try
        {

            cboSearch.Items.Clear();
            cboSearch.Items.Add(new ListItem("Location ID", "LOCID"));
            cboSearch.Items.Add(new ListItem("Location Name", "LOCNM"));
            cboSearch.Items.Add(new ListItem("Warehouse Type", "WH_TYPE"));
            clsStandards.populateGrid(objMaster.GetBinDisplayData(clsStandards.WhereStatement_NoST(string.Empty, string.Empty, string.Empty)), GrUser, "REFNO");
            //clsStandards.populateGrid(objMaster.getUsers(clsStandards.WhereStatement(0, cboSearch.SelectedValue, cboCriteria.SelectedValue, txtSearch.Text.Trim())), GrUser, "RECNO");

            MultiView1.SetActiveView(View1);
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally { objMaster = null; }
    }
    protected void imgCloseV1_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.SetActiveView(View2);
    }
    protected void imgCloseV2_Click(object sender, ImageClickEventArgs e)
    {

    }
    //public void clear()
    //{
    //    BL_DepartmentMaster objDepartment = new BL_DepartmentMaster();
    //    txtUserId.Text = string.Empty;
    //    txtFirstName.Text = string.Empty;
    //    txtEmpAdd.Text = string.Empty;
    //    txtEmpId.Text = string.Empty;
    //    txtLastName.Text = string.Empty;
    //    txtUserId.Enabled = true;
    //    try
    //    {
    //        //clsStandards.fillCombobox(ddDepartment, objDepartment.BL_GetDepartmentCode(), "DEPARTMENTCODE");
    //        ddPlantcode.SelectedValue = "Select";
    //        ddModule.SelectedValue = "Select";
    //        ddType.SelectedValue = "Select";
    //        //ddDepartment.SelectedValue = "Select";
    //    }
    //    catch (Exception ex)
    //    {
    //        clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //    }

    //}

    //public void Rightsclear()
    //{
    //    grdUserDtls.DataSource = null;
    //    grdUserDtls.DataBind();
    //    txtTDate.Text = string.Empty;
    //    //txtDdate.Text = string.Empty;

    //    txtTplant.Text = string.Empty;
    //    //txtDPlant.Text = string.Empty;
    //    //txtTdepartment.Text = string.Empty;
    //    //txtDDepartment.Text = string.Empty;
    //    //txtTRole.Text = string.Empty;
    //    //txtDRole.Text = string.Empty;

    //    try
    //    {

    //        ddlUserid.SelectedValue = "Select";
    //        cblTPlant.Items.Clear();
    //        //cblDPlant.Items.Clear();
    //        //cblTDept.Items.Clear();
    //        //cblDDept.Items.Clear();
    //        //cblTRole.Items.Clear();
    //        //cblDRole.Items.Clear();
    //    }
    //    catch (Exception ex)
    //    {
    //        clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //    }

    //}


    //public void SelectedDataClear()
    //{
    //    txtTDate.Text = string.Empty;
    //    //txtDdate.Text = string.Empty;
    //    txtTplant.Text = string.Empty;
    //    //txtDPlant.Text = string.Empty;
    //    //txtTdepartment.Text = string.Empty;
    //    //txtDDepartment.Text = string.Empty;
    //    //txtTRole.Text = string.Empty;
    //    //txtDRole.Text = string.Empty;
    //    cblTPlant.Items.Clear();
    //    // cblDPlant.Items.Clear();
    //    //cblTDept.Items.Clear();
    //    // cblDDept.Items.Clear();
    //    //cblTRole.Items.Clear();
    //    //cblDRole.Items.Clear();
    //}
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {

        PL_BinMaster objField = new PL_BinMaster();
        BL_BinMaster objMaster = new BL_BinMaster();
        try
        {
            //string data1 = ddDepartment.Text.ToString();
            //string[] splitData1 = data1.Split('-');

            //objField.strDepartment = splitData1[0].ToString();
            objField.strLocationID = txtLocaionId.Text.Trim();
            objField.strLocationName = txtLocationName.Text.Trim();
            objField.strWarehouseType = ddWHType.Text.Trim();
            objField.strPlantCode = ddPlantcode.SelectedItem.ToString().Trim().Split('-').GetValue(0).ToString();

            objField.strMODE = strFlg;
           
            //  objField.intStatus = clsStandards.ActivationStatus(chkStatus);
            objField.intStatus = status();
            objField.strCreatedBy = clsStandards.current_Username();
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
            string strResult = objMaster.BL_Save_Bin(objField);
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        strFlg = "ADD";
        int pass = 0;
        int tcount = 0;
        //PL_DepartmentMaster objField = new PL_DepartmentMaster();
        //BL_DepartmentMaster objMaster = new BL_DepartmentMaster();
        PL_Username objField = new PL_Username();
        BL_UserMaster objMaster = new BL_UserMaster();
        string strResult = "";
        dtImport = (DataTable)ViewState["Import"];
        tcount = dtImport.Rows.Count;
        try
        {
            if (dtImport.Rows.Count > 0)
            {
                for (int i = 0; i < dtImport.Rows.Count; i++)
                {
                    objField.strUserID = clsStandards.filter(dtImport.Rows[i][0].ToString());
                    objField.strUsername = "";
                    objField.strFirstName = clsStandards.filter(dtImport.Rows[i][1].ToString());
                    objField.strLastName = clsStandards.filter(dtImport.Rows[i][2].ToString());
                    objField.strEmpCode = clsStandards.filter(dtImport.Rows[i][3].ToString());
                    objField.strEmailID = clsStandards.filter(dtImport.Rows[i][4].ToString());

                    objField.strPlantCode = clsStandards.filter(dtImport.Rows[i][5].ToString());

                    objField.strDepartment = clsStandards.filter(dtImport.Rows[i][6].ToString());

                    objField.strModule = clsStandards.filter(dtImport.Rows[i][7].ToString());

                    objField.strUserType = clsStandards.filter(dtImport.Rows[i][8].ToString());

                    objField.strMethod = strFlg;

                    objField.intStatus = 1;

                    objField.strCreatedBy = clsStandards.current_Username();

                    strResult = objMaster.BL_Save_Users(objField);
                    if (strResult.StartsWith("0") == true)
                    {
                        //clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                        pass++;
                    }
                    else
                    {

                        //grPlant1.Rows[i].BackColor = System.Drawing.Color.Red;
                        //grPlant1.Rows[i].ForeColor = System.Drawing.Color.Wheat;

                    }

                }

                clsStandards.WriteLog(this, new Exception(tcount + " Out Of " + pass + "Record Inserted"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
                tcount = pass = 0;

                // clear();

            }

            grPlant1.DataSource = null;
            grPlant1.DataBind();
            pnlImport.Visible = false;
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);

        }
        finally
        {
            objField = null;
            objMaster = null; strResult = null;
            // ViewState["Import"] = null;
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
        BL_BinMaster objMaster = new BL_BinMaster();
        try
        {
            GrUser.AllowPaging = false;
            GrUser.AllowSorting = false;

            //clsxlsExport.ExportExcel(GrPlant, "Company.xls");
            // clsStandards.populateGrid(objMaster.GetUsersDisplayData(clsStandards.WhereStatement_NoST(string.Empty, string.Empty, string.Empty)), GrUser, "RECNO");
            clsxlsExport.ConvertToxls(objMaster.GetBinDisplayData(clsStandards.WhereStatement_NoST(cboSearch.SelectedValue, cboCriteria.SelectedValue, txtSearch.Text.Trim())), "User_Master");
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
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        BL_BinMaster objItems = new BL_BinMaster();
        try
        {
            clsStandards.populateGrid(objItems.GetBinDisplayData(clsStandards.WhereStatement(0, cboSearch.SelectedValue, cboCriteria.SelectedValue, txtSearch.Text.Trim())), GrUser, "REFNO");
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


    protected void GrUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrUser.PageIndex = e.NewPageIndex;
        BL_BinMaster objMaster = new BL_BinMaster();
        try
        {
            clsStandards.populateGrid(objMaster.GetBinDisplayData(clsStandards.WhereStatement_NoST(cboSearch.SelectedValue, cboCriteria.SelectedValue, txtSearch.Text.Trim())), GrUser, "REFNO");
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



    protected void GrUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BL_BinMaster objDepartment = new BL_BinMaster();
        if (e.CommandName == "Select")
        {
            int RowInd = ((GridViewRow)(((LinkButton)e.CommandSource).NamingContainer)).RowIndex;
            // GridViewRow gr = GrDept.Rows[Convert.ToInt32(e.CommandArgument)];
            DataTable dt = new DataTable();
            BL_BinMaster objMaster = new BL_BinMaster();
            PL_BinMaster objCon = new PL_BinMaster();
            BL_Chnage blChange = new BL_Chnage();
            try
            {
                dt = objMaster.GetBinDisplayData(clsStandards.WhereStatement_NoST("[REFNO]", "Equal to", GrUser.DataKeys[RowInd].Value.ToString()));
                if (dt.Rows.Count != 0)
                {
                    //ddDepartment.Items.Clear();
                    //clsStandards.fillCombobox(ddDepartment, objDepartment.BL_GetDepartmentCode(), "DEPARTMENTCODE");
                    try
                    {
                        //ddPlantcode.SelectedValue = dt.Rows[0]["PLANTCODE"].ToString();
                        ddPlantcode.SelectedValue = blChange.Bl_get_strPlant_desc(dt.Rows[0]["PLANTID"].ToString());
                        //ddDepartment.SelectedValue = dt.Rows[0]["DEPARTMENT"].ToString();
                        //ddDepartment.SelectedValue = blChange.Bl_get_strDept_desc(dt.Rows[0]["DEPARTMENT"].ToString());
                        //ddModule.SelectedValue = dt.Rows[0]["MODULE"].ToString();
                        //ddType.SelectedValue = dt.Rows[0]["USER_TYPE"].ToString();
                    }
                    catch
                    {
                    }
                    txtLocaionId.Text = dt.Rows[0]["LOCID"].ToString();
                    txtLocationName.Text = dt.Rows[0]["LOCNM"].ToString();
                    ddWHType.Text = dt.Rows[0]["WH_TYPE"].ToString();
                    //chkStatus.Checked = ((dt.Rows[0]["STATUS"].ToString() == "True") ? true : false);
                    RBactivate.Checked = ((dt.Rows[0]["Status"].ToString() == "Activate") ? true : false);
                    RBdeactivate.Checked = ((dt.Rows[0]["Status"].ToString() == "Deactivate") ? true : false);

                    ViewState["REFNO"] = dt.Rows[0]["REFNO"].ToString();


                    strFlg = "EDIT";

                    txtLocaionId.Enabled = false;

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
        txtLocaionId.Enabled = true;
        txtLocaionId.Text = string.Empty;
        txtLocationName.Text = string.Empty;
        txtRemark.Text = string.Empty;
        try
        {
            //clsStandards.fillCombobox(ddDepartment, objDepartment.BL_GetDepartmentCode(), "DEPARTMENTCODE");
            ddPlantcode.SelectedValue = "Select";
            ddWHType.SelectedValue = "Select";

            //ddDepartment.SelectedValue = "Select";
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }

    }
    protected void GrUser_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Page " + (GrUser.PageIndex + 1) + " of " + GrUser.PageCount;
            e.Row.Cells[1].Text = clsStandards.FooterInfo(GrUser);
        }
    }
    protected void GrUser_Sorting(object sender, GridViewSortEventArgs e)
    {
        BL_BinMaster objMaster = new BL_BinMaster();
        try
        {
            clsStandards.populateGrid(objMaster.GetBinDisplayData(clsStandards.WhereStatement_NoST(cboSearch.SelectedValue, cboCriteria.SelectedValue, txtSearch.Text.Trim())), GrUser, e.SortExpression.ToString());
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

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void ddlUserid_SelectedIndexChanged1(object sender, EventArgs e)
    {
        #region "Comments"
        //BL_UserMaster objItems = new BL_UserMaster();
        //BL_PlantMaster objplant = new BL_PlantMaster();
        //BL_DepartmentMaster objDept = new BL_DepartmentMaster();
        //DataTable dt = new DataTable();

        //string[] strTransRole, strDispRole;

        //try
        //{

        //    SelectedDataClear();

        //    clsStandards.FillMultiCheckList(cblTPlant, objplant.BL_Get_Plant_with_Desc(), "PLANTCODE");
        //    clsStandards.FillMultiCheckList(cblDPlant, objplant.BL_Get_Plant_with_Desc(), "PLANTCODE");

        //    //clsStandards.FillMultiCheckList(cblTDept, objDept.BL_GetDepartmentCode(), "DEPARTMENTCODE");
        //    //clsStandards.FillMultiCheckList(cblDDept, objDept.BL_GetDepartmentCode(), "DEPARTMENTCODE");

        //    clsStandards.populateGrid(objItems.getUsers(clsStandards.WhereStatementUserMaster(1, "USER_ID", "Equal to", ddlUserid.Text.Trim())), grdUserDtls, "USER_ID");
        //    dt = objItems.BL_GetExistingRoles(ddlUserid.Text.Trim());
        //    if (dt.Rows.Count > 0)
        //    {
        //        #region Transaction Rights

        //        txtTDate.Text = dt.Rows[0]["T_ACCESSUPTO"].ToString();
        //        txtTdepartment.Text = dt.Rows[0]["T_DEPARTMENT"].ToString();
        //        txtTplant.Text = dt.Rows[0]["T_PLANTID"].ToString();
        //        txtTRole.Text = dt.Rows[0]["T_ROLES"].ToString();

        //        strTransRole = dt.Rows[0]["T_ROLES"].ToString().Split(',');

        //        clsStandards.FillMultiCheckList(cblTDept, objDept.BL_GetDepartmentCodeforPlant(txtTplant.Text.Trim()), "DEPARTMENTCODE");
        //        for (int i = 0; i < cblTDept.Items.Count; i++)
        //        {
        //            if (dt.Rows[0]["T_DEPARTMENT"].ToString().Contains(cblTDept.Items[i].Text.Trim().Split('-').GetValue(0).ToString()))
        //            {
        //                cblTDept.Items[i].Selected = true;
        //            }
        //        }
        //        for (int i = 0; i < cblTPlant.Items.Count; i++)
        //        {
        //            if (dt.Rows[0]["T_PLANTID"].ToString().Contains(cblTPlant.Items[i].Text.Trim().Split('-').GetValue(0).ToString()))
        //            {
        //                cblTPlant.Items[i].Selected = true;
        //            }
        //        }

        //        //for (int i = 0; i < cblTRole.Items.Count; i++)
        //        //{
        //        //    if (dt.Rows[0]["T_ROLES"].ToString().ToUpper() == cblTRole.Items[i].Text.ToUpper())
        //        //    {
        //        //        cblTRole.Items[i].Selected = true;
        //        //    }
        //        //}

        //        for (int i = 0; i < strTransRole.Length; i++)
        //        {
        //            for (int j = 0; j < cblTRole.Items.Count; j++)
        //            {
        //                if (cblTRole.Items[j].Text.ToUpper() == strTransRole[i].ToUpper())
        //                {
        //                    cblTRole.Items[j].Selected = true;
        //                    break;
        //                }
        //            }
        //        }

        //        ViewState["EDIT"] = "EDIT";
        //        #endregion

        //        #region DisPlay Rights


        //        txtDdate.Text = dt.Rows[0]["D_ACCESSUPTO"].ToString();
        //        txtDDepartment.Text = dt.Rows[0]["D_DEPARTMENT"].ToString();
        //        txtDPlant.Text = dt.Rows[0]["D_PLANTID"].ToString();
        //        txtDRole.Text = dt.Rows[0]["D_ROLES"].ToString();

        //        strDispRole = dt.Rows[0]["D_ROLES"].ToString().Split(',');

        //        clsStandards.FillMultiCheckList(cblDDept, objDept.BL_GetDepartmentCodeforPlant(txtDPlant.Text.Trim()), "DEPARTMENTCODE");
        //        for (int i = 0; i < cblDDept.Items.Count; i++)
        //        {
        //            if (dt.Rows[0]["D_DEPARTMENT"].ToString().Contains(cblDDept.Items[i].Text.Trim().Split('-').GetValue(0).ToString()))
        //            {
        //                cblDDept.Items[i].Selected = true;
        //            }
        //        }

        //        for (int i = 0; i < cblDPlant.Items.Count; i++)
        //        {
        //            if (dt.Rows[0]["D_PLANTID"].ToString().Contains(cblDPlant.Items[i].Text.Trim().Split('-').GetValue(0).ToString()))
        //            {
        //                cblDPlant.Items[i].Selected = true;
        //            }
        //        }

        //        //for (int i = 0; i < cblDRole.Items.Count; i++)
        //        //{
        //        //    if (dt.Rows[0]["D_ROLES"].ToString() == cblDRole.Items[i].Text)
        //        //    {
        //        //        cblDRole.Items[i].Selected = true;
        //        //    }
        //        //}

        //        for (int i = 0; i < strDispRole.Length; i++)
        //        {
        //            for (int j = 0; j < cblDRole.Items.Count; j++)
        //            {
        //                if (cblDRole.Items[j].Text.ToUpper() == strDispRole[i].ToUpper())
        //                {
        //                    cblDRole.Items[j].Selected = true;
        //                    break;
        //                }
        //            }
        //        }

        //        #endregion


        //    }

        //}
        //catch (Exception ex)
        //{
        //    clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        //}
        //finally
        //{
        //    objItems = null;
        //}

        #endregion

        BL_UserMaster objItems = new BL_UserMaster();
        BL_PlantMaster objplant = new BL_PlantMaster();
        //BL_DepartmentMaster objDept = new BL_DepartmentMaster();
        DataTable dt = new DataTable();

        string[] strTransRole, strDispRole;

        try
        {

            //SelectedDataClear();

            //clsStandards.FillMultiCheckList(cblTPlant, objplant.BL_Get_Plant_with_Desc(), "PLANTCODE");
            //clsStandards.FillMultiCheckList(cblDPlant, objplant.BL_Get_Plant_with_Desc(), "PLANTCODE");

            //clsStandards.FillMultiCheckList(cblTDept, objDept.BL_GetDepartmentCode(), "DEPARTMENTCODE");
            //clsStandards.FillMultiCheckList(cblDDept, objDept.BL_GetDepartmentCode(), "DEPARTMENTCODE");

            //clsStandards.populateGrid(objItems.getUsers(clsStandards.WhereStatementUserMaster(1, "USER_ID", "Equal to", ddlUserid.Text.Trim())), grdUserDtls, "USER_ID");
            //dt = objItems.BL_GetExistingRoles(ddlUserid.Text.Trim());
            //if (dt.Rows.Count > 0)
            //{
            //    #region Transaction Rights

            //    txtTDate.Text = dt.Rows[0]["T_ACCESSUPTO"].ToString();
            //    //txtTdepartment.Text = dt.Rows[0]["T_DEPARTMENT"].ToString();
            //    txtTplant.Text = dt.Rows[0]["T_PLANTID"].ToString();
            //    txtTRole.Text = dt.Rows[0]["T_ROLES"].ToString();

            //    strTransRole = dt.Rows[0]["T_ROLES"].ToString().Split(',');

            //    //clsStandards.FillMultiCheckList(cblTDept, objDept.BL_GetDepartmentCodeforPlant(txtTplant.Text.Trim()), "DEPARTMENTCODE");
            //    //for (int i = 0; i < cblTDept.Items.Count; i++)
            //    //{
            //    //    if (dt.Rows[0]["T_DEPARTMENT"].ToString().Contains(cblTDept.Items[i].Text.Trim().Split('-').GetValue(0).ToString()))
            //    //    {
            //    //        cblTDept.Items[i].Selected = true;
            //    //    }
            //    //}
            //    for (int i = 0; i < cblTPlant.Items.Count; i++)
            //    {
            //        if (dt.Rows[0]["T_PLANTID"].ToString().Contains(cblTPlant.Items[i].Text.Trim().Split('-').GetValue(0).ToString()))
            //        {
            //            cblTPlant.Items[i].Selected = true;
            //        }
            //    }
            //    //for (int i = 0; i < cbTAssociatePlant.Items.Count; i++)
            //    //{
            //    //    if (dt.Rows[0]["T_PLANTID"].ToString().Contains(cbTAssociatePlant.Items[i].Text.Trim().Split('-').GetValue(0).ToString()))
            //    //    {
            //    //        cbTAssociatePlant.Items[i].Selected = true;
            //    //    }
            //    //}

            //    //for (int i = 0; i < cblTRole.Items.Count; i++)
            //    //{
            //    //    if (dt.Rows[0]["T_ROLES"].ToString().ToUpper() == cblTRole.Items[i].Text.ToUpper())
            //    //    {
            //    //        cblTRole.Items[i].Selected = true;
            //    //    }
            //    //}

            //    for (int i = 0; i < strTransRole.Length; i++)
            //    {
            //        for (int j = 0; j < cblTRole.Items.Count; j++)
            //        {
            //            if (cblTRole.Items[j].Text.ToUpper() == strTransRole[i].ToUpper())
            //            {
            //                cblTRole.Items[j].Selected = true;
            //                break;
            //            }
            //        }
            //    }

            //    ViewState["EDIT"] = "EDIT";
            //    #endregion

            //    #region DisPlay Rights


            //    //txtDdate.Text = dt.Rows[0]["D_ACCESSUPTO"].ToString();
            //    //txtDDepartment.Text = dt.Rows[0]["D_DEPARTMENT"].ToString();
            //    //txtDPlant.Text = dt.Rows[0]["D_PLANTID"].ToString();
            //    //txtDRole.Text = dt.Rows[0]["D_ROLES"].ToString();

            //    strDispRole = dt.Rows[0]["D_ROLES"].ToString().Split(',');

            //    //clsStandards.FillMultiCheckList(cblDDept, objDept.BL_GetDepartmentCodeforPlant(txtDPlant.Text.Trim()), "DEPARTMENTCODE");
            //    //for (int i = 0; i < cblDDept.Items.Count; i++)
            //    //{
            //    //    if (dt.Rows[0]["D_DEPARTMENT"].ToString().Contains(cblDDept.Items[i].Text.Trim().Split('-').GetValue(0).ToString()))
            //    //    {
            //    //        cblDDept.Items[i].Selected = true;
            //    //    }
            //    //}

            //    //for (int i = 0; i < cblDPlant.Items.Count; i++)
            //    //{
            //    //    if (dt.Rows[0]["D_PLANTID"].ToString().Contains(cblDPlant.Items[i].Text.Trim().Split('-').GetValue(0).ToString()))
            //    //    {
            //    //        cblDPlant.Items[i].Selected = true;
            //    //    }
            //    //}

            //    //for (int i = 0; i < cbDAscPlant.Items.Count; i++)
            //    //{
            //    //    if (dt.Rows[0]["D_PLANTID"].ToString().Contains(cbDAscPlant.Items[i].Text.Trim().Split('-').GetValue(0).ToString()))
            //    //    {
            //    //        cbDAscPlant.Items[i].Selected = true;
            //    //    }
            //    //}

            //    //for (int i = 0; i < cblDRole.Items.Count; i++)
            //    //{
            //    //    if (dt.Rows[0]["D_ROLES"].ToString() == cblDRole.Items[i].Text)
            //    //    {
            //    //        cblDRole.Items[i].Selected = true;
            //    //    }
            //    //}

            //    //for (int i = 0; i < strDispRole.Length; i++)
            //    //{
            //    //    for (int j = 0; j < cblDRole.Items.Count; j++)
            //    //    {
            //    //        if (cblDRole.Items[j].Text.ToUpper() == strDispRole[i].ToUpper())
            //    //        {
            //    //            cblDRole.Items[j].Selected = true;
            //    //            break;
            //    //        }
            //    //    }
            //    //}

            //    #endregion


            //}

        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            objItems = null;
        }
    }

    protected void btnTPlantOk_Click(object sender, EventArgs e)
    {

        DataTable dtTranDept;
        //BL_DepartmentMaster objDepartment = new BL_DepartmentMaster();
        //string strAscPlant = clsStandards.GetSelectedItems_WODESC(cbTAssociatePlant);


        //txtTplant.Text = clsStandards.GetSelectedItems_WODESC(cblTPlant);



        //try
        //{
        //    //cblTDept.Items.Clear();
        //    dtTranDept = objDepartment.BL_GetDepartmentCodeforPlant(clsStandards.GetSelectedItems_WODESC(cblTPlant));
        //    if (dtTranDept.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtTranDept.Rows.Count; i++)
        //        {
        //            // cblTDept.Items.Add(dtTranDept.Rows[i][0].ToString());
        //            //cblDDept.Items.Add(dt.Rows[i][0].ToString());
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        //}
        //finally
        //{
        //    objDepartment = null;
        //}
    }
    protected void btnTPlant_Cancel_Click(object sender, EventArgs e)
    {
        // txtTplant.Text = "";
        //clsStandards.ClearCheckbox(cblTPlant);
    }
    protected void btnTDeptOk_Click(object sender, EventArgs e)
    {
        // txtTdepartment.Text = clsStandards.GetSelectedItems_WODESC(cblTDept);

    }
    protected void btnTDept_Cancel_Click(object sender, EventArgs e)
    {
        //txtTdepartment.Text = "";
        //clsStandards.ClearCheckbox(cblTDept);
    }
    protected void btnTRoleOk_Click(object sender, EventArgs e)
    {
       // txtTRole.Text = clsStandards.GetSelectedItems(cblTRole);

    }
    protected void btnTRoleCancel_Click(object sender, EventArgs e)
    {
        //txtTRole.Text = "";
        //clsStandards.ClearCheckbox(cblTRole);
    }

    protected void btnDPlantOk_Click(object sender, EventArgs e)
    {
        //DataTable dtDispDept;
        //BL_DepartmentMaster objDepartment = new BL_DepartmentMaster();

        //txtDPlant.Text = clsStandards.GetSelectedItems_WODESC(cblDPlant);

        //try
        //{
        //    cblDDept.Items.Clear();
        //    dtDispDept = objDepartment.BL_GetDepartmentCodeforPlant(clsStandards.GetSelectedItems_WODESC(cblDPlant));
        //    if (dtDispDept.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtDispDept.Rows.Count; i++)
        //        {
        //            cblDDept.Items.Add(dtDispDept.Rows[i][0].ToString());
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        //}
        //finally
        //{
        //    objDepartment = null;
        //}

        DataTable dtDispDept;
        //BL_DepartmentMaster objDepartment = new BL_DepartmentMaster();
        string strDAscPlant = "";

        //strDAscPlant = clsStandards.GetSelectedItems_WODESC(cbDAscPlant);
        //if (strDAscPlant == "")
        //{
        //    txtDPlant.Text = clsStandards.GetSelectedItems_WODESC(cblDPlant);
        //}
        //else
        //{
        //    txtDPlant.Text = clsStandards.GetSelectedItems_WODESC(cblDPlant) + ',' + clsStandards.GetSelectedItems_WODESC(cbDAscPlant);
        //}


        try
        {
            // cblDDept.Items.Clear();
            // dtDispDept = objDepartment.BL_GetDepartmentCodeforPlant(clsStandards.GetSelectedItems_WODESC(cblDPlant));
            //if (dtDispDept.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtDispDept.Rows.Count; i++)
            //    {
            //      //  cblDDept.Items.Add(dtDispDept.Rows[i][0].ToString());
            //    }
            //}
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            //objDepartment = null;
        }


    }
    protected void btnDPlant_Cancel_Click(object sender, EventArgs e)
    {
        // txtDPlant.Text = "";
        // clsStandards.ClearCheckbox(cblDPlant);
    }
    protected void btnDDeptOk_Click(object sender, EventArgs e)
    {
        // txtDDepartment.Text = clsStandards.GetSelectedItems_WODESC(cblDDept);

    }
    protected void btnDDept_Cancel_Click(object sender, EventArgs e)
    {
        //txtDDepartment.Text = "";
        //clsStandards.ClearCheckbox(cblDDept);
    }
    protected void btnDRoleOk_Click(object sender, EventArgs e)
    {
        //txtDRole.Text = clsStandards.GetSelectedItems(cblDRole);

    }
    protected void btnDRoleCancel_Click(object sender, EventArgs e)
    {
        //txtDRole.Text = "";
        //clsStandards.ClearCheckbox(cblDRole);
    }
    protected void btnSaveRight_Click(object sender, EventArgs e)
    {

    }
   

    //protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    //{
    //    BL_UserMaster objMaster = new BL_UserMaster();
    //    DataTable dtUserCHK;
    //    try
    //    {


    //        if (txtUserId.Text.Trim() == string.Empty)
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('User id is required.');", true);
    //            return;
    //        }

    //        dtUserCHK = objMaster.BL_CheckUserID(txtUserId.Text.Trim());
    //        if (dtUserCHK.Rows.Count > 0)
    //        {
    //            clsStandards.WriteLog(this, new Exception("User Id already exists"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 1, true);
    //            return;
    //        }
    //        ActiveDirectoryHelper adh = new ActiveDirectoryHelper();
    //        ADUserDetail ad = adh.GetUserByLoginName(txtUserId.Text);
    //        txtFirstName.Text = ad.FirstName.ToString();
    //        txtLastName.Text = ad.LastName.ToString();
    //        txtEmpId.Text = "";
    //        txtEmpAdd.Text = ad.EmailAddress.ToString();
    //        //ddDepartment.Items.Clear();
    //        //ddDepartment.Items.Add(ad.Department.ToString());
    //        //ddDepartment.SelectedIndex = -1;
    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('No Data Found');", true);
    //        clear();
    //    }
    //    finally
    //    {
    //        dtUserCHK = null;
    //        objMaster = null;
    //    }
    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        grPlant1.DataSource = null;
        grPlant1.DataBind();
        dtImport = null;
        ViewState["Import"] = null;
        pnlImport.Visible = false;
    }

    protected void grPlant1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            dtImport = ViewState["Import"] == null ? new DataTable() : (DataTable)ViewState["Import"];
            grPlant1.PageIndex = e.NewPageIndex;
            grPlant1.DataSource = dtImport;
            grPlant1.DataBind();
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
        }
    }
    protected void grPlant1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Page " + (grPlant1.PageIndex + 1) + " of " + grPlant1.PageCount;
            e.Row.Cells[1].Text = clsStandards.FooterInfo(grPlant1);
        }
    }
    protected void btnImp_Click1(object sender, EventArgs e)
    {
        btnCancel.Visible = true;
        btnSave.Visible = true;
        grPlant1.Visible = true;

        try
        {
            string SheetName;
            if (FlUpload.HasFile)
            {
                string excelPath = Server.MapPath(ConfigurationManager.AppSettings["Data"].ToString()) + Path.GetFileName(FlUpload.PostedFile.FileName);
                FlUpload.SaveAs(excelPath);

                string conString = string.Empty;
                string extension = Path.GetExtension(FlUpload.PostedFile.FileName);
                if (extension == ".xls" || extension == ".xlsx")
                {
                    switch (extension)
                    {
                        case "xls": //Excel 97-03
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //Excel 07 or higher
                            conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                            break;

                    }
                    conString = string.Format(conString, excelPath);
                    using (OleDbConnection excel_con = new OleDbConnection(conString))
                    {

                        //Get the name of the First Sheet.

                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            cmd.Connection = excel_con;
                            excel_con.Open();
                            DataTable dtExcelSchema = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            excel_con.Close();
                        }
                    }


                    //Read Data from the First Sheet.
                    using (OleDbConnection con = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            using (OleDbDataAdapter oda = new OleDbDataAdapter())
                            {
                                DataTable dt = new DataTable();
                                cmd.CommandText = "SELECT * From [" + SheetName + "]";
                                cmd.Connection = con;
                                con.Open();
                                oda.SelectCommand = cmd;
                                oda.Fill(dtImport);
                                con.Close();

                                //Populate DataGridView.
                                string Header = Path.GetFileName(excelPath);
                                if (dtImport.Rows.Count > 0)
                                {
                                    grPlant1.DataSource = dtImport;
                                    grPlant1.DataBind();
                                    ViewState["Import"] = dtImport;
                                    pnlImport.Visible = true;
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('No records found in excel');", true);
                                    return;
                                }

                            }

                        }

                    }
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('File Format not supported');", true);
                    return;

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
    //protected void btnImpRight_Click(object sender, EventArgs e)
    //{
    //    btnCancelRight.Visible = true;
    //    btnSaveRight.Visible = true;
    //    grdExcelRight.Visible = true;
    //    btnSaveRightExcel.Visible = true;
    //    btnCancelRightExcel.Visible = true;

    //    try
    //    {
    //        string SheetName;
    //        if (uploadRight.HasFile)
    //        {
    //            string excelPath = Server.MapPath(ConfigurationManager.AppSettings["Data"].ToString()) + Path.GetFileName(uploadRight.PostedFile.FileName);
    //            uploadRight.SaveAs(excelPath);

    //            string conString = string.Empty;
    //            string extension = Path.GetExtension(uploadRight.PostedFile.FileName);
    //            if (extension == ".xls" || extension == ".xlsx")
    //            {
    //                switch (extension)
    //                {
    //                    case "xls": //Excel 97-03
    //                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
    //                        break;
    //                    case ".xlsx": //Excel 07 or higher
    //                        conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
    //                        break;

    //                }
    //                conString = string.Format(conString, excelPath);
    //                using (OleDbConnection excel_con = new OleDbConnection(conString))
    //                {

    //                    //Get the name of the First Sheet.

    //                    using (OleDbCommand cmd = new OleDbCommand())
    //                    {
    //                        cmd.Connection = excel_con;
    //                        excel_con.Open();
    //                        DataTable dtExcelSchema = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //                        SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
    //                        excel_con.Close();
    //                    }
    //                }


    //                //Read Data from the First Sheet.
    //                using (OleDbConnection con = new OleDbConnection(conString))
    //                {
    //                    using (OleDbCommand cmd = new OleDbCommand())
    //                    {
    //                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
    //                        {
    //                            DataTable dt = new DataTable();
    //                            cmd.CommandText = "SELECT * From [" + SheetName + "]";
    //                            cmd.Connection = con;
    //                            con.Open();
    //                            oda.SelectCommand = cmd;
    //                            oda.Fill(dtImport);
    //                            con.Close();

    //                            //Populate DataGridView.
    //                            string Header = Path.GetFileName(excelPath);
    //                            if (dtImport.Rows.Count > 0)
    //                            {
    //                                grdExcelRight.DataSource = dtImport;
    //                                grdExcelRight.DataBind();
    //                                ViewState["Import"] = dtImport;
    //                                Panel1.Visible = true;
    //                            }
    //                            else
    //                            {
    //                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('No records found in excel');", true);
    //                                return;
    //                            }

    //                        }

    //                    }

    //                }
    //            }
    //            else
    //            {

    //                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('File Format not supported');", true);
    //                return;

    //            }
    //        }
    //    }


    //    catch (Exception ex)
    //    {
    //        clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //    }
    //    finally
    //    {

    //    }
    //}
    //protected void btnSaveRightExcel_Click(object sender, EventArgs e)
    //{
    //    strFlg = "ADD";
    //    int PASSCOUNT = 0;


    //    //PL_DepartmentMaster objField = new PL_DepartmentMaster();
    //    //BL_DepartmentMaster objMaster = new BL_DepartmentMaster();
    //    PL_UserRight objField = new PL_UserRight();
    //    BL_UserMaster objMaster = new BL_UserMaster();
    //    string strResult = "";
    //    dtImport = (DataTable)ViewState["Import"];
    //    int TOTCOUNT = dtImport.Rows.Count;
    //    try
    //    {
    //        if (dtImport.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < dtImport.Rows.Count; i++)
    //            {
    //                objField.strUserID = clsStandards.filter(dtImport.Rows[i][0].ToString());

    //                objField.strT_PlantID = clsStandards.filter(dtImport.Rows[i][1].ToString());

    //                objField.strT_Department = clsStandards.filter(dtImport.Rows[i][2].ToString());

    //                objField.strT_Roles = "";

    //                objField.DT_T_ACCESSUPTO = clsStandards.filter(dtImport.Rows[i][3].ToString());


    //                objField.strD_PlantID = clsStandards.filter(dtImport.Rows[i][4].ToString());

    //                objField.strD_Department = clsStandards.filter(dtImport.Rows[i][5].ToString());

    //                objField.strD_Roles = "";

    //                objField.DT_D_ACCESSUPTO = clsStandards.filter(dtImport.Rows[i][6].ToString());

    //                objField.strMethod = strFlg;
    //                objField.intStatus = 1;
    //                objField.strCreatedBy = clsStandards.current_Username();

    //                //strResult = objMaster.BL_InsertDepartment(objField);
    //                strResult = objMaster.BL_Save_UserRights(objField);
    //                if (strResult.StartsWith("0") == true)
    //                {
    //                    // clsStandards.WriteLog(this, new Exception(strResult.Split('|').GetValue(1).ToString()), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //                    PASSCOUNT++;

    //                }
    //                else
    //                {
    //                    //grdExcelRight.Rows[i].BackColor = System.Drawing.Color.Red;
    //                    //grdExcelRight.Rows[i].ForeColor = System.Drawing.Color.Wheat;
    //                }

    //            }
    //            clsStandards.WriteLog(this, new Exception(PASSCOUNT + " Out Of " + TOTCOUNT + "Record Inserted"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
    //            PASSCOUNT = 0;
    //            TOTCOUNT = 0;
    //            clear();


    //        }

    //        grdExcelRight.DataSource = null;
    //        grdExcelRight.DataBind();
    //        Panel1.Visible = false;
    //    }
    //    catch (Exception ex)
    //    {
    //        clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);

    //    }
    //    finally
    //    {
    //        objField = null;
    //        objMaster = null; strResult = null;
    //        // ViewState["Import"] = null;
    //    }
    //}
    //protected void btnCancelRightExcel_Click(object sender, EventArgs e)
    //{
    //    grdExcelRight.DataSource = null;
    //    grdExcelRight.DataBind();
    //    dtImport = null;
    //    ViewState["Import"] = null;
    //    Panel1.Visible = false;
    //}
    //protected void grdExcelRight_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        dtImport = ViewState["Import"] == null ? new DataTable() : (DataTable)ViewState["Import"];
    //        grdExcelRight.PageIndex = e.NewPageIndex;
    //        grdExcelRight.DataSource = dtImport;
    //        grdExcelRight.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //    }
    //    finally
    //    {
    //    }
    //}
    //protected void grdExcelRight_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        e.Row.Cells[0].Text = "Page " + (grdExcelRight.PageIndex + 1) + " of " + grdExcelRight.PageCount;
    //        e.Row.Cells[1].Text = clsStandards.FooterInfo(grdExcelRight);
    //    }
    //}



    //protected void ddPlantcode_SelectedIndexChanged1(object sender, EventArgs e)
    //{
    //    BL_AreaMaster objArea = new BL_AreaMaster();
    //    DataTable dt = new DataTable();

    //    try
    //    {
    //        string data = ddPlantcode.SelectedItem.Text.ToString();

    //        BL_PrinterMaster objPrinter = new BL_PrinterMaster();
    //        string[] splitData = data.Split('-');

    //        // clsStandards.fillCombobox(ddDepartment, objArea.GetDeptCode(splitData[0].ToString()), "DEPT_CODE");
    //    }
    //    catch (Exception ex)
    //    {
    //        clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
    //    }
    //    finally
    //    {
    //        objArea = null;
    //    }
    //}
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

    protected void btnTDepartment_Click(object sender, EventArgs e)
    {
        DataTable dtTranDept;
        //BL_DepartmentMaster objDepartment = new BL_DepartmentMaster();
        try
        {
            //dtTranDept = objDepartment.BL_GetDepartmentCodeforPlant(txtDPlant.Text.Trim());
            //if (dtTranDept.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtTranDept.Rows.Count; i++)
            //    {
            //        cblTDept.Items.Add(dtTranDept.Rows[i][0].ToString());
            //        //cblDDept.Items.Add(dt.Rows[i][0].ToString());
            //    }
            //}
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            //objDepartment = null;
        }

    }
}
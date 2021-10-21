using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Web.Services;
using System.Web.Security;
using System.Net.NetworkInformation;
using PropertyLayer;
using System.Data;

public partial class Device_Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (clsBLCommon.IsSessionIdExists(clsStandards.current_Username(), HttpContext.Current.Session["Token_Number"].ToString(), clsStandards.GetMAC()) == false)
                {
                    HttpContext.Current.Session["UserID"] = null;
                    HttpContext.Current.Session["UserType"] = null;
                    HttpContext.Current.Session["Token_Number"] = null;
                    HttpContext.Current.Session["PlantID"] = null;
                    HttpContext.Current.Response.Redirect("~/Device/frmDevice_Login.aspx");

                }

                DataSet ds = clsBLCommon.getMyRights(clsStandards.current_Username());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr[0].ToString().Trim() != null)
                            {
                                //Converting string value into array of string.
                                string[] Filter = dr[0].ToString().Split(',');

                                //Loading rights on master page menu control.
                                for (int i = 0; i <= Filter.Length - 1; i++)
                                {
                                    try
                                    {
                                        switch (Filter[i].ToString())
                                        {
                                            case "401":
                                                A401.Visible = true; break;
                                            case "402":
                                                A402.Visible = true; break;
                                            case "403":
                                                A403.Visible = true; break;
                                            case "404":
                                                A404.Visible = true; break;
                                            case "405":
                                                A405.Visible = true; break;
                                            case "406":
                                                A406.Visible = true; break;
                                            case "407":
                                                A407.Visible = true; break;
                                        }
                                    }
                                    catch { }
                                }
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("~/Device/frmDevice_Login.aspx");
            }
        }
    }


    public void vailidateMenu()
    {


    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Application["Users"] = null;

        clsBLCommon _BusinessLayer = new clsBLCommon();
        try
        {
            if (_BusinessLayer.CloseSession(clsStandards.current_Username(), clsStandards.GetMAC(), 0) == true)
            {

                clsStandards.WriteLog(new Page(), new Exception("User Logged Out Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
                //clsStandards.WriteLog('1', new Exception("User Logged Out Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, false);
                string strFlag = "0";

                if (HttpContext.Current.Session["LoginFlag"].ToString() == "1")
                {
                    strFlag = "1";
                }

                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Expires = -1500;
                HttpContext.Current.Response.CacheControl = "no-cache";

                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Cookies.Clear();

                if (strFlag == "0")
                {
                    HttpContext.Current.Response.Redirect("~/Device/frmDevice_Login.aspx");
                }
                else
                {
                    HttpContext.Current.Response.Redirect("~/Device/frmDevice_Login.aspx");
                }
            }
            else
            {
                clsStandards.WriteLog(Page, new Exception("Could not close current session."), "Device Main Page", "Logout", 0, false);
            }
        }
        catch (Exception ex)
        {
            clsStandards.WriteLog(Page, ex, "Device Main Page", "Logout", 0, false);
        }
        finally
        {
            _BusinessLayer = null;
        }

    }
}


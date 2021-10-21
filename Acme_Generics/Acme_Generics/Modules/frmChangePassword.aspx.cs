using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class frmChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //throw new UnauthorizedAccessException();
            txtUsername.Focus();
            if (Request.QueryString["Id"] != null)
            {

                string ID = Request.QueryString["Id"].ToString();
                txtUsername.Text = ID;
            }
            txtPassword.Text = clsStandards.current_User_pass().ToString();

        }
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        string msg = "";
        if (txtNewPassword.Text.Trim() == string.Empty)
        {
            clsStandards.WriteLog(this, new Exception("New password is required."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            return;
        }

        if (txtPassword.Text.Trim() == string.Empty)
        {
            clsStandards.WriteLog(this, new Exception("Old password is required."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            return;
        }

        if (txtConfirmPassword.Text.Trim() == string.Empty)
        {
            clsStandards.WriteLog(this, new Exception("Confirm new password is required."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            return;
        }

        clsBLCommon _Common = new clsBLCommon();
        try
        {

            msg = _Common.ChangePassword(txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtNewPassword.Text.Trim());
            if (msg.Contains('0'))
            {
                //clsStandards.WriteLog(this, new Exception(msg), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Please Enter Old Crediatianls Right!!');", true);

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtUsername.Focus();
                return;

            }
            else if (msg.Contains('0') == false || msg.Contains('1') == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Password Changed Successfully!!');", true);
                //clsStandards.WriteLog(this, new Exception(msg), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
                HttpContext.Current.Response.Redirect(VirtualPathUtility.ToAbsolute(System.Web.Configuration.WebConfigurationManager.AppSettings["Login"].ToString()));
            }
            //clsStandards.WriteLog(this, new Exception(msg), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, true);
            //txtPassword.Text = string.Empty;
            //txtNewPassword.Text = string.Empty;
            //txtConfirmPassword.Text = string.Empty;
            //btnChangePassword.Visible = false;
            //btnCancel.Visible = false;
            //lnkBack.Visible = true;
            //txtPassword.Focus();
        }
        catch (Exception ex)
        {
            string strError = ex.ToString();
            strError = strError.Replace("System.Exception: System.Data.SqlClient.SqlException (0x80131904): ", "");
            clsStandards.WriteLog(this, new Exception(strError), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            _Common = null;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Application["Users"] = null;

        //clsBLCommon _Common = new clsBLCommon();
        //try
        //{
        //    if (_Common.CloseSession(clsStandards.current_Username(), clsStandards.GetMAC(), 0) == true)
        //    {
        //        HttpContext.Current.Response.Buffer = true;
        //        HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        //        HttpContext.Current.Response.Expires = -1500;
        //        HttpContext.Current.Response.CacheControl = "no-cache";

        //        HttpContext.Current.Session.Clear();
        //        HttpContext.Current.Session.Abandon();
        //        HttpContext.Current.Response.Cookies.Clear();
        //        HttpContext.Current.Response.Redirect("~/Default.aspx");
        //    }
        //    else
        //    {
        //        clsStandards.WriteLog(Page, new Exception("Could not close current session."), "Main Page", "Logout", 0, false);
        //    }
        //}
        //catch (Exception ex)
        //{
        //    clsStandards.WriteLog(Page, ex, "Main Page", "Logout", 0, false);
        //}
        //finally
        //{
        //    _Common = null;
        //}
    }
}

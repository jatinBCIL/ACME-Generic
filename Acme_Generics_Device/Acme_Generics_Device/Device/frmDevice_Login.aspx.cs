using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessLayer;
using PropertyLayer;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

public partial class frmDevice_Login : System.Web.UI.Page
{

    /// <summary>
    /// Ref No : 
    /// Purpose : Device Login Screen.
    /// Created By : Jagdish Joshi
    /// Created On : 26 July 2016.
    /// Modified By : 
    /// Modified On :
    /// Comment :
    /// </summary>



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BL_UserMaster objUser = new BL_UserMaster();

            try
            {

                txtUsername.Attributes.Add("onkeypress", "button_click(this,'" + this.btnGetPlant.ClientID + "'); return DisableSplChars(event);");
                if (clsStandards.IsConnected() == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Could Not Connect To Database');", true);
                    return;
                }
                ddlPlant.Items.Clear();
                ddlPlant.Items.Add("Select");
                ddlPlant.SelectedValue = "Select";

                txtUsername.Focus();
                EnableDetails(false);

            }
            catch (Exception ex)
            {
                string strResult = ex.ToString().Replace("System.Exception: System.Data.SqlClient.SqlException:", "");
                strResult = strResult.Replace("System.Exception:", "").Split('.').GetValue(1).ToString().Replace("'", "");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('" + strResult.Trim() + "');", true);
            }
            finally
            {
                objUser = null;
            }
        }
    }

    public bool AuthenticateUser(string domain, string username, string password, string LdapPath, out string Errmsg)
    {
        Errmsg = "";
        string domainAndUsername = domain + @"\" + username;
        DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, password);
        try
        {
            // Bind to the native AdsObject to force authentication.
            Object obj = entry.NativeObject;
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + username + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
            if (null == result)
            {
                return false;
            }

            string surname;

            if (result.Properties.Contains("sn"))
            {
                surname = result.Properties["sn"][0].ToString();
            }

            // Update the new path to the user in the directory
            LdapPath = result.Path;
            string _filterAttribute = (String)result.Properties["cn"][0];
        }
        catch (Exception ex)
        {
            Errmsg = ex.Message;
            return false;
            throw new Exception("Error authenticating user." + ex.Message);
        }
        return true;
    }

    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            GetPlants("LOGIN");
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }

    }

    private void GetPlants(string strType)
    {
        string strLogin_Result = "";
        string strPlant = "";
        try
        {
            if (txtUsername.Text.Trim() == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Login id is required.');", true);
                return;
            }

            if (txtPassword.Text.Trim() == string.Empty && strType == "LOGIN")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Login password is required.');", true);
                return;
            }


            clsBLCommon _BusinessLayer = new clsBLCommon();
            try
            {

                if (clsStandards.IsConnected() == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Could Not Connect To Database');", true);
                    return;
                }

                if (_BusinessLayer.isLocked(txtUsername.Text.Trim()) == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('User id is locked due to failure of 3 login attempt');", true);
                    return;
                }

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('lock Sucesss');", true);
                //clsLogException.WriteLog(this, new Exception("Lock Sucesss"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);


                //--AD Login

                //string dominName = string.Empty;
                //string adPath = string.Empty;
                //string userName = txtUserID.Text.Trim().ToUpper();
                //string strError = string.Empty;

                //foreach (string key in System.Web.Configuration.WebConfigurationManager.AppSettings.Keys)
                //{
                //    dominName = System.Web.Configuration.WebConfigurationManager.AppSettings["LDAPDomain"].ToString();
                //    adPath = System.Web.Configuration.WebConfigurationManager.AppSettings["LDAPPath"].ToString();
                //    dominName = key.Contains("LDAPDomain") ? System.Web.Configuration.WebConfigurationManager.AppSettings[key] : dominName;
                //    adPath = key.Contains("LDAPPath") ? System.Web.Configuration.WebConfigurationManager.AppSettings[key] : adPath;
                //    if (!String.IsNullOrEmpty(dominName) && !String.IsNullOrEmpty(adPath))
                //    {

                //        if (true == AuthenticateUser(dominName, userName, txtPassword.Text, adPath, out strError))
                //        {
                //            //HttpContext.Current.Response.Redirect(ResolveUrl("~/Modules/frmMain.aspx"), false);
                //        }
                //        dominName = string.Empty;
                //        adPath = string.Empty;
                //        if (String.IsNullOrEmpty(strError))
                //        {
                //            break;
                //        }
                //    }
                //    else
                //    {
                //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Enter Valid User Id.!!!');", true);
                //        return;
                //    }
                //}
                //if (!string.IsNullOrEmpty(strError))
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Invalid User Name or Password..!!!');", true);
                //    return;
                //}

                strLogin_Result = _BusinessLayer.Login(txtUsername.Text, txtPassword.Text, ddlPlant.Text.Trim(), strType);
                if (strLogin_Result.StartsWith("1"))
                {
                    try
                    {
                        if (strType == "GETPLANT")
                        {
                            strPlant = strLogin_Result.Split('@').GetValue(1).ToString();
                            clsStandards.fillCombo(ddlPlant, strPlant);
                            EnableDetails(true);
                            return;
                        }
                        if (_BusinessLayer.IsSessionExists(txtUsername.Text.Trim()) == true)
                        {
                            pnlExpire.Visible = true;
                            pnlLogin.Visible = false;
                            return;
                        }
                        else
                        {
                            pnlLogin.Visible = false;
                            pnlExpire.Visible = true;
                        }


                        if (strLogin_Result.Split('@').GetValue(1).ToString() == "First Time Login.")
                        {
                           // Response.Redirect("~/Modules/frmChangePassword.aspx?Id=" + txtUsername.Text.Trim() + "");
                        }
                        else
                        {
                            HttpContext.Current.Session["LoginFlag"] = "0";
                            HttpContext.Current.Session["UserId"] = clsStandards.fn_Encrypt_String(txtUsername.Text.Trim(), "B0C0I0L0");
                            HttpContext.Current.Session["Token_Number"] = clsStandards.Generate_Token();
                            HttpContext.Current.Session["Timeout"] = DateTime.Now.ToString();
                            HttpContext.Current.Session["MyPlant"] = strLogin_Result.Split('@').GetValue(2).ToString();
                            HttpContext.Current.Session["MyName"] = strLogin_Result.Split('@').GetValue(1).ToString();
                            HttpContext.Current.Session["USERTYPE"] = strLogin_Result.Split('@').GetValue(3).ToString();
                            HttpContext.Current.Session["DATETIME"] = System.DateTime.Now.ToString("dd/MM/yyyy").Replace("-", "/");
                            PL_Username.iExpiry = 30 - Convert.ToInt32(strLogin_Result.Trim().Split('@').GetValue(5).ToString());
                            HttpContext.Current.Session["MyDept"] = strLogin_Result.Split('@').GetValue(6).ToString();
                            HttpContext.Current.Session["PlantType"] = strLogin_Result.Split('@').GetValue(7).ToString();

                            _BusinessLayer.NewSessionEntry(txtUsername.Text.Trim(), HttpContext.Current.Session["Token_Number"].ToString(), clsStandards.GetMAC());
                            _BusinessLayer.UpdatePassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                            if (clsBLCommon.isExpired(txtUsername.Text.Trim(), "0") == true)
                            {
                               // HttpContext.Current.Response.Redirect("~/Modules/frmPassword.aspx?id=" + txtUsername.Text, false);
                            }
                            else
                            {
                                clsStandards.WriteLog(this, new Exception("User Logged in Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, false);
                                HttpContext.Current.Response.Redirect(ResolveUrl("~/Device/frmDevice_Main.aspx"), false);
                            }
                        }


                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {

                    if (ViewState["Failed_Attempt"] == null)
                    {
                        ViewState["Failed_Attempt"] = 0;
                    }

                    ///Counting failure attempt.
                    ViewState["Failed_Attempt"] = Convert.ToInt32(ViewState["Failed_Attempt"]) + 1;

                    ///Performing lock action if user login fail 5 times continuously.
                    if (Convert.ToInt32(ViewState["Failed_Attempt"]) >= 5)
                    {
                        ///Locking user account.
                        if (_BusinessLayer.LockUser(txtUsername.Text.Trim()) == true)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "alert('" + txtUsername.Text.Trim() + " : User id has been locked due to five attempt failed.');", true);
                            ViewState["Failed_Attempt"] = 0;
                            return;
                        }
                    }
                    string strMessage_Err = string.Empty;
                    try
                    {
                        strMessage_Err = strLogin_Result.Split('@').GetValue(1).ToString();
                    }
                    catch
                    {
                        strMessage_Err = "Invalid login credentials entered";
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('" + strMessage_Err + "');", true);
                }
            }
            catch (Exception ex)
            {
                string strResult = ex.ToString().Replace("System.Exception: System.Data.SqlClient.SqlException:", "");
                strResult = strResult.Replace("System.Exception:", "").Split('.').GetValue(1).ToString().Replace("'", "");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('" + strResult.Trim() + "');", true);

                //clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
            finally
            {
                _BusinessLayer = null;
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            strLogin_Result = null;
            strPlant = null;
        }
    }

    protected void btnGetPlant_Click(object sender, EventArgs e)
    {
        string strPlant = "";
        try
        {
            if (txtUsername.Text == string.Empty)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('User id is required.');", true);
                Page.Controls.Add(new LiteralControl("<script>alert('User id is required');</script>"));
                return;
            }

            GetPlants("GETPLANT");

        }
        catch (Exception ex)
        {

        }
    }

    private void EnableDetails(bool value)
    {
        lblPassword.Visible = value;
        txtPassword.Visible = value;
        lblSelectPlant.Visible = value;
        ddlPlant.Visible = value;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text.Trim() == string.Empty)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Login id is required.');", true);
            return;
        }

        clsBLCommon _BusinessLayer = new clsBLCommon();
        try
        {
            if (_BusinessLayer.CloseSession(txtUsername.Text.Trim(), clsStandards.GetMAC(), 0) == true)
            {
                pnlExpire.Visible = false;
                //clsStandards.WriteLog(this, new Exception("Previous session has been closed .Please try to login now"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Previous session has been closed .Please try to login now');", true);
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Expires = -1500;
                HttpContext.Current.Response.CacheControl = "no-cache";

                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Cookies.Clear();
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Previous session has been closed .Please try to login now');", true);

                pnlLogin.Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Could not close previous session.');", true);
                //clsStandards.WriteLog(this, new Exception("Could not close previous session."), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
            }
        }
        catch (Exception ex)
        {
            string strResult = ex.ToString().Replace("System.Exception: System.Data.SqlClient.SqlException:", "");
            strResult = strResult.Replace("System.Exception:", "").Split('.').GetValue(1).ToString().Replace("'", "");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('" + strResult.Trim() + "');", true);

            //clsStandards.WriteLog(this, ex, clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
        }
        finally
        {
            _BusinessLayer = null;
        }
    }
}
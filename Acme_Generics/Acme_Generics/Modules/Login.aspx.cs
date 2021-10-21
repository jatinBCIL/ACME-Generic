using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using PropertyLayer;
using BusinessLayer;
using System.DirectoryServices;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BL_UserMaster objUser = new BL_UserMaster();

            try
            {
                txtUserID.Attributes.Add("onkeypress", "button_click(this,'" + this.btnGetPlant.ClientID + "'); return DisableSplChars(event);");
                if (clsStandards.IsConnected() == false)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Could Not Connect To Database');", true);
                    return;
                }

                txtUserID.Focus();
                clsStandards.fillCombobox(dd_PlantCode, objUser.getPlant(""), "PLANTCODE");
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

    protected void lnkForgot_Click(object sender, EventArgs e)
    {

    }

    protected void lnkForce_Login_Click(object sender, EventArgs e)
    {
        if (txtUserID.Text.Trim() == string.Empty)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Login id is required.');", true);
            return;
        }

        clsBLCommon _BusinessLayer = new clsBLCommon();
        try
        {
            if (_BusinessLayer.CloseSession(txtUserID.Text.Trim(), clsStandards.GetMAC(), 0) == true)
            {
                pnlConCurrent.Visible = false;
                clsStandards.WriteLog(this, new Exception("Previous session has been closed .Please try to login now"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 0, true);
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Expires = -1500;
                HttpContext.Current.Response.CacheControl = "no-cache";

                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Cookies.Clear();
                Panel1.Visible = true;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('Could not close previous session.');", true);
           }
        }
        catch (Exception ex)
        {
            string strResult = ex.ToString().Replace("System.Exception: System.Data.SqlClient.SqlException:", "");
            strResult = strResult.Replace("System.Exception:", "").Split('.').GetValue(1).ToString().Replace("'", "");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('" + strResult.Trim() + "');", true);

        }
        finally
        {
            _BusinessLayer = null;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Modules/frmChangePassword.aspx");
    }

    private void GetPlants(string strType)
    {
        string strLogin_Result = "";
        string strPlant = "";
        try
        {
            if (txtUserID.Text.Trim() == string.Empty)
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

                if (_BusinessLayer.isLocked(txtUserID.Text.Trim()) == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), @"alert('User id is locked due to failure of 3 login attempt');", true);
                    return;
                }

                strLogin_Result = _BusinessLayer.Login(txtUserID.Text, txtPassword.Text, dd_PlantCode.Text.Trim(), strType);
                if (strLogin_Result.StartsWith("1"))
                {
                    try
                    {
                        if (strType == "GETPLANT")
                        {
                            strPlant = strLogin_Result.Split('@').GetValue(1).ToString();
                            clsStandards.fillCombo(dd_PlantCode, strPlant);
                            return;
                        }
                        if (_BusinessLayer.IsSessionExists(txtUserID.Text.Trim()) == true)
                        {
                            pnlConCurrent.Visible = true;
                            Panel1.Visible = false;
                            return;
                        }
                        else
                        {
                            pnlConCurrent.Visible = false;
                            Panel1.Visible = true;
                        }


                        if (strLogin_Result.Split('@').GetValue(1).ToString() == "First Time Login.")
                        {
                            HttpContext.Current.Session["UserId"] = clsStandards.fn_Encrypt_String(txtUserID.Text.Trim(), "B0C0I0L0");
                            HttpContext.Current.Session["MyPass"] = txtPassword.Text.Trim();
                            Response.Redirect("~/Modules/frmChangePassword.aspx?Id=" + txtUserID.Text.Trim() + "");
                        }
                        else
                        {
                            HttpContext.Current.Session["LoginFlag"] = "0";
                            HttpContext.Current.Session["UserId"] = clsStandards.fn_Encrypt_String(txtUserID.Text.Trim(), "B0C0I0L0");
                            HttpContext.Current.Session["Token_Number"] = clsStandards.Generate_Token();
                            HttpContext.Current.Session["Timeout"] = DateTime.Now.ToString();
                            HttpContext.Current.Session["MyPlant"] = strLogin_Result.Split('@').GetValue(2).ToString();
                            HttpContext.Current.Session["MyName"] = strLogin_Result.Split('@').GetValue(1).ToString();
                            HttpContext.Current.Session["USERTYPE"] = strLogin_Result.Split('@').GetValue(3).ToString();
                            HttpContext.Current.Session["DATETIME"] = System.DateTime.Now.ToString("dd/MM/yyyy").Replace("-", "/");
                            PL_Username.iExpiry = 30 - Convert.ToInt32(strLogin_Result.Trim().Split('@').GetValue(5).ToString());
                            HttpContext.Current.Session["MyDept"] = strLogin_Result.Split('@').GetValue(6).ToString();
                            HttpContext.Current.Session["PlantType"] = strLogin_Result.Split('@').GetValue(7).ToString();

                            _BusinessLayer.NewSessionEntry(txtUserID.Text.Trim(), HttpContext.Current.Session["Token_Number"].ToString(), clsStandards.GetMAC());
                            _BusinessLayer.UpdatePassword(txtUserID.Text.Trim(), txtPassword.Text.Trim());

                            if (clsBLCommon.isExpired(txtUserID.Text.Trim(), "0") == true)
                            {
                                HttpContext.Current.Response.Redirect("~/Modules/frmPassword.aspx?id=" + txtUserID.Text, false);
                            }
                            else
                            {
                                clsStandards.WriteLog(this, new Exception("User Logged in Successfully"), clsStandards.GetCurrentPageName(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), 2, false);
                                HttpContext.Current.Response.Redirect(ResolveUrl("~/Modules/frmMain.aspx"), false);
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
                        if (_BusinessLayer.LockUser(txtUserID.Text.Trim()) == true)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "alert('" + txtUserID.Text.Trim() + " : User id has been locked due to five attempt failed.');", true);
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
            if (txtUserID.Text == string.Empty)
            {
                Page.Controls.Add(new LiteralControl("<script>alert('User id is required');</script>"));
                return;
            }

            GetPlants("GETPLANT");

        }
        catch (Exception ex)
        {

        }
    }


}

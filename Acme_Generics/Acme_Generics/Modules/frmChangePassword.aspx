<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmChangePassword.aspx.cs"
    Inherits="frmChangePassword" Title="e-Track-Change Password" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script src="../JavaScripts/JScript.js" type="text/javascript"></script>
<head runat="server">
    <link href="../App_Themes/Styles/Style_Controls.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Styles/Style_Design.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Styles/Style_Grid.css" rel="stylesheet" type="text/css" />
</head>
<body style="height: 272px; width: 1274px">
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
    <div style="width: 100%; height: 300px;">
        <center>
            <table cellpadding="0" cellspacing="0" width="50%">
                <tr>
                    <td style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                        background-repeat: repeat-x">
                        <asp:Label ID="Label35" ForeColor="white" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Change Password"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Username"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUsername" runat="server" autocomplete="off" 
                                        CssClass="TextBox" Width="174px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                                        ErrorMessage="*" Font-Bold="True" Font-Size="Large" ToolTip="User id not found."
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Old Password"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" autocomplete="off" CssClass="TextBox"
                                        onkeypress="Javascript:return isRestructionKey(event);" TextMode="Password" Width="174px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                        ErrorMessage="*" Font-Bold="True" Font-Size="Large" ToolTip="Password is required."
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" CssClass="Label" Text="New Password"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNewPassword" runat="server" autocomplete="off" CssClass="TextBox"
                                        MaxLength="15" onkeypress="Javascript:return isRestructionKey(event);" 
                                        TextMode="Password" Width="174px"></asp:TextBox>
                                    <asp:PasswordStrength ID="ps" runat="server" BehaviorID="lblPass" StrengthIndicatorType="Text"
                                        TargetControlID="txtNewPassword">
                                    </asp:PasswordStrength>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewPassword"
                                        ErrorMessage="*" Font-Bold="True" Font-Size="Large" ToolTip="New password is required."
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                                <td> 
                                   <asp:Label ID="lblPass" runat="server"></asp:Label>
                                   <asp:RegularExpressionValidator ID="regexpValidation" runat="server"  CssClass="Validation"  ToolTip="Password Must contain special Char,Small and Capital Later and number"
                                    ErrorMessage="*" ValidationGroup="Save" ControlToValidate="txtNewPassword" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}">
                                </asp:RegularExpressionValidator>
                             
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" CssClass="Label" Text="Confirm New Password"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" autocomplete="off" CssClass="TextBox"
                                        MaxLength="15" onkeypress="Javascript:return isRestructionKey(event);" 
                                        TextMode="Password" Width="174px" ></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirmPassword"
                                        ErrorMessage="*" Font-Bold="True" Font-Size="Large" ToolTip="Enter Confirm Password"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    
                                </td>
                                <td>
                                   <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword" CssClass="Validation"
                                        ControlToValidate="txtConfirmPassword" ErrorMessage="*" 
                                        ToolTip="The confirm new password must match with new password." ValidationGroup="Save"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnChangePassword" runat="server" CssClass="Button" OnClick="btnChangePassword_Click"
                                                    Text="Change Password" ValidationGroup="Save" Height="28px" 
                                                    Width="150px" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" CssClass="Button" OnClick="btnCancel_Click"
                                                    PostBackUrl="~/Modules/Login.aspx" Text="Cancel" Height="28px" 
                                                    Width="120px"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkBack" runat="server" OnClick="LinkButton1_Click" Visible="False">Click here for relogin.</asp:LinkButton>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <%--</ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnChangePassword"/>
        </Triggers>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true" CodeFile="frmPassword.aspx.cs" Inherits="Tools_frmPassword" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../JavaScripts/JScript.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="height: 30px; background-image: url('App_Themes/Styles/Images/Form_Title.JPG');
                        background-repeat: repeat-x">
                        <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" 
                            Text="&amp;nbsp;Change Password"></asp:Label>
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
                                        CssClass="TextBox" Enabled="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtUsername" ErrorMessage="*" Font-Bold="True" 
                                        Font-Size="Large" ToolTip="User id not found." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Old Password"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" autocomplete="off" 
                                        CssClass="TextBox" onkeypress="Javascript:return isRestructionKey(event);" 
                                        TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtPassword" ErrorMessage="*" Font-Bold="True" 
                                        Font-Size="Large" ToolTip="Password is required." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" CssClass="Label" Text="New Password"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNewPassword" runat="server" autocomplete="off" 
                                        CssClass="TextBox" MaxLength="15" 
                                        onkeypress="Javascript:return isRestructionKey(event);" 
                                        TextMode="Password"></asp:TextBox>
                                    <asp:PasswordStrength ID="ps" runat="server" BehaviorID="lblPass" 
                                        StrengthIndicatorType="Text" TargetControlID="txtNewPassword">
                                    </asp:PasswordStrength>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="txtNewPassword" ErrorMessage="*" Font-Bold="True" 
                                        Font-Size="Large" ToolTip="New password is required." ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblPass" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" CssClass="Label" 
                                        Text="Confirm New Password"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" autocomplete="off" 
                                        CssClass="TextBox" MaxLength="15" 
                                        onkeypress="Javascript:return isRestructionKey(event);" 
                                        TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" 
                                        ErrorMessage="*" Font-Bold="True" Font-Size="Large" 
                                        ToolTip="The confirm new password must match with new password." 
                                        ValidationGroup="Save"></asp:CompareValidator>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnChangePassword" runat="server" CssClass="Button" 
                                                    onclick="btnChangePassword_Click" Text="Change Password" 
                                                    ValidationGroup="Save" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" CssClass="Button" 
                                                    onclick="btnCancel_Click" PostBackUrl="../frmMain.aspx" Text="Cancel" 
                                                    Width="75px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:LinkButton ID="lnkBack" runat="server" onclick="LinkButton1_Click" 
                                        Visible="False">Click here for relogin.</asp:LinkButton>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnChangePassword" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    
    </asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!------------------<<Import Style sheet Reference>>------------------------>
    <title>MTS |Login </title>
    <link rel="icon" href="~/App_Themes/Styles/Images/WebSiteLogo.png">
    <link href="../App_Themes/Styles/Style_Controls.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Styles/Style_Design.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Styles/Style_Grid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style5
        {
            height: 23px;
        }
        .style8
        {
            width: 313px;
        }
    </style>
    <style type="text/css">
        .Progress_Login
        {
            font-family: "Arial";
        }
        #Background
        {
            background-color: #F2F2F2;
        }
        #test
        {
            width: 100%;
            margin: 0px auto;
            height: 50px;
            position: fixed;
            bottom: 0;
        }
        .style1
        {
            font-family: "Arial";
            font-size: 11pt;
        }
        #Img1
        {
            height: 122px;
            width: 135px;
        }
        .style9
        {
            width: 104px;
        }
        .style13
        {
            width: 184px;
        }
        .style14
        {
            width: 181px;
        }
    </style>
</head>
<body class="body" style="margin: 0; font-family: Arial; background-repeat: repeat-x;
    font-size: 12pt;">
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div style="margin: 0; width: 100%;">
        <table cellpadding="0" cellspacing="0" style="background-image: url('App_Themes/Images/b2.jpg');
            width: 100%">
            <tr>
                <td align="right" class="style9" style=" width:85px">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/App_Themes/Styles/Images/Acme_Generics_Logo.png"
                        Width="70px" Height="60px" />
                </td>
                <td style="text-align:  inherit" align="left">
                    <h2 style="color: #808080;">
                        Acme Generics Pvt Ltd</h2>
                </td>
                <td style="width: 50px">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: center;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td style="padding-left: 10px; padding-right: 10px">
                            <table cellpadding="0" cellspacing="0" height="100%" style="width: 100%">
                                <tr>
                                    <td style="background-image: url('App_Themes/Styles/Images/b2.jpg'); background-repeat: repeat-x;">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" height="100%" style="border-top-style: solid;
                                            border-top-width: 3px; border-top-color: #808184;" width="100%">
                                            <tr>
                                                <td align="center" height="100px" style="vertical-align: top;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="vertical-align: top;" height="100px">
                                                    <br />
                                                    <table cellpadding="0" cellspacing="0" style="border: 1px solid #C0C0C0; width: 430px;
                                                        height: 220px">
                                                        <tr>
                                                            <td style="text-align: center; border-bottom-color: #666633; border-bottom-width: 1px;
                                                                border-bottom-style: dotted; height: 25px; background-image: url('App_Themes/Images/ButtonOut.png');
                                                                color: #FFFFFF; padding-left: 10px; background-color: #808184;">
                                                                <asp:Label ID="lblHeading" runat="server" Font-Bold="true" Text="Material Tracking System (MTS)." />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Panel ID="Panel1" runat="server">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td class="style14"  style="text-align:center;"" >
                                                                                <asp:Label ID="lblUsername" runat="server" CssClass="Label" Text="User ID"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align:left">
                                                                                <asp:TextBox ID="txtUserID" runat="server" CssClass="TextBox" Width="223px" Height="20px"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserID"
                                                                                    CssClass="Validation" ErrorMessage="*" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style14" style="text-align:center;" >
                                                                                <asp:Label ID="lblPassword" runat="server" CssClass="Label" Text="Password"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align:left">
                                                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" MaxLength="15" 
                                                                                    TextMode="Password"  Width="223px" Height="20px"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                                                                    CssClass="Validation" ErrorMessage="*" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style14" style="text-align:center;"" >
                                                                                <asp:Label ID="lblPassword0" runat="server" CssClass="Label" Text="Plant"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align:center">
                                                                                <asp:DropDownList ID="dd_PlantCode" runat="server" CssClass="Combobox" 
                                                                                    Height="22px" Width="250px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style14">
                                                                                <asp:Button ID="btnGetPlant" runat="server" float="left" class="btn-primary" Text="Get Plant"
                                                                                    Height="30px" Width="49%" ValidationGroup="SCAN" CssClass="HiddenButton" OnClick="btnGetPlant_Click" />
                                                                            </td>
                                                                            <td align="left" colspan="0" rowspan="0" class="style8">
                                                                                <asp:ImageButton ID="btnLogin" runat="server" Height="41px" ImageUrl="~/App_Themes/Styles/Images/btnlogin.jpg"
                                                                                    Width="113px" ValidationGroup="Login" OnClick="btnLogin_Click" />
                                                                            </td>
                                                                            <td align="left" colspan="0" class="style8">
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LinkButton" OnClick="LinkButton1_Click"
                                                                                    Visible="False">Change Password</asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                                <asp:Panel ID="pnlConCurrent" runat="server" Visible="False" Height="160px">
                                                                    <table>
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
                                                                            <td valign="middle">
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
                                                                            <td valign="middle">
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
                                                                                <asp:Label ID="Label113" runat="server" ForeColor="Red" Text="Previous session of user active click "></asp:Label>
                                                                                <asp:LinkButton ID="lnkForce_Login" runat="server" CssClass="LinkButton" Font-Size="16pt"
                                                                                    OnClick="lnkForce_Login_Click">Next</asp:LinkButton>
                                                                            </td>
                                                                            <td valign="middle">
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style5">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="style5">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="style5">
                                                                                <asp:Label ID="Label114" runat="server" ForeColor="Red" Text=" to Close the previous session."></asp:Label>
                                                                            </td>
                                                                            <td class="style5" valign="middle">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="style5">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style5">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="style5">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="style5">
                                                                            </td>
                                                                            <td class="style5" valign="middle">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="style5">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left; border-bottom-color: #666633; border-bottom-width: 1px;
                                                                border-bottom-style: dotted; height: 25px; background-image: url('App_Themes/Images/ButtonOut.png');
                                                                color: #FFFFFF; padding-left: 10px; background-color: #F89B32;">
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table>
                                                        <tr>
                                                            <td align="center" style="text-align: right; padding-top: 15px;">
                                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                                                    DisplayAfter="0" DynamicLayout="true">
                                                                    <ProgressTemplate>
                                                                        <%--<div id="Background"></div>--%>
                                                                        <div id="Progress" align="left">
                                                                            <img id="Img1" runat="server" src="~/App_Themes/Styles/Images/pleaseWait.gif" />
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="0" height="20" style="vertical-align: middle; background-image: url('Images/BottomTitle.png');
                                                    background-repeat: repeat-x; background-attachment: scroll;" valign="middle"
                                                    class="style1">
                                                    This system is intended for limited (authorised) use and is subject to company policies.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="0" height="20" style="font-size: 9pt; vertical-align: middle;
                                                    background-image: url('Images/BottomTitle.png'); background-repeat: repeat-x;
                                                    background-attachment: scroll;" valign="middle">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </tr> </table>
                <table id="test" style="text-align: center; color: #FFFFFF; font-family: HP Simplified;
                    font-size: 12px; width: 100%; height: 80px;">
                    <tr>
                        <td style="text-align: left; padding-left: 5px; height: 140px; background-image: url('../App_Themes/Styles/Images/Top_Add.png')"
                            colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; width: 350px; padding-left: 5px; height: 40px;">
                            <span style="color: #FFFFFF;">Version: v6.0.152 | Build Id : 210916 | Environment :
                            </span>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="text-align: right; padding-right: 15px;">
                            Copyright 2013 © for <a style="font-style: italic; color: #FFFFFF;" target="_search">
                                BlueStar Limited</a>. All rights reserved. Developed by <a href="http://www.barcodeindia.com"
                                    style="font-style: italic; color: #FFFFFF;" target="_search">Bar Code India Ltd.</a>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnLogin" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>

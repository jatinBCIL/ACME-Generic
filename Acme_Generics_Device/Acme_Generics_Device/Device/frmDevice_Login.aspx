<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDevice_Login.aspx.cs"
    Inherits="frmDevice_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>e-Track | Version 1.0</title>
    <link href="../../Styles/Style_Controls.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Style_Design.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Style_Grid.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/ex.css" rel="stylesheet" type="text/css">
    <link href="../cdn/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="../cdn/jquery.min.js"></script>
    <script src="../cdn/bootstrap.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style type="text/css">
        .Label
        {
            font-family: Calibri;
            font-size: 11pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }
        
        .Button
        {
            border-top-left-radius: 3px;
            border-top-right-radius: 3px;
            border-bottom-left-radius: 3px;
            border-bottom-right-radius: 3px;
            border-color: #006699;
            border-width: 0px;
            background-image: url('../App_Themes/Styles/Images/ButtonOut.png');
            font-family: Arial;
            font-size: 12px;
            color: #FFFFFF;
            width: 120px;
            height: 24px;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            cursor: inherit;
        }
        
        .TextBox
        {
            border: 1px solid #c0c0c0;
            font-family: Arial;
            font-size: 10px;
            color: Black;
            margin-left: 0px;
            width: 350px;
            height: 18px;
            padding-left: 2px;
            padding-right: 2px;
        }
        
        .auto-style1
        {
            position: relative;
            min-height: 1px;
            float: left;
            width: 33.33333333%;
            height: 34px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</head>
<body style="background-image: none; background-color: White; margin: 0; font-family: Arial;
    font-size: 12pt;">
    <div class="container-fluid">
        <form role="form" id="form1" runat="server" class="form-horizontal" autocomplete="off">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="Upd1" runat="Server">
            <ContentTemplate>
                <table width="100%" style="border: 1px solid black;">
                    <tr>
                        <%-- <td align="left">
                            <asp:Image ID="Image1" Style="margin: 10px" runat="server" ImageUrl="~/App_Themes/Styles/Images/logo1.png"
                                Height="39px" Width="113px" />
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>--%>
                    </tr>
                    <tr>
                        <td style="height: 25px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                            background-repeat: repeat-x; width: 100%;">
                            <asp:Label ID="Label35" align="right" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Login"
                                ForeColor="White" Font-Bold="True"></asp:Label>
                        </td>
                        <td style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                            background-repeat: repeat-x">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <asp:Panel ID="pnlLogin" Visible="true" runat="server">
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <div class="control-label col-sm-4">
                                        <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Enter your user Id"></asp:Label>
                                    </div>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtUsername" class="form-control" runat="server" autocomplete="off"
                                            ValidationGroup="Login" Width="90%"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <div class="control-label col-sm-4">
                                        <asp:Label ID="lblPassword" runat="server" CssClass="Label" Text="Enter your password"></asp:Label>
                                    </div>
                                    <div class="control-label col-sm-4">
                                        <asp:TextBox class="form-control" Width="90%" ID="txtPassword" runat="server" autocomplete="off"
                                            TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <div class="control-label col-sm-4">
                                        <asp:Label ID="lblSelectPlant" runat="server" CssClass="Label" Text="Select Plant"></asp:Label>
                                    </div>
                                    <div class="control-label col-sm-4">
                                        <asp:DropDownList ID="ddlPlant" runat="server" class="form-control" Width="90%">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="pnlExpire" Visible="false" runat="server">
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <div class="control-label col-sm-12">
                                        <center>
                                            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Previous Session of User Active."></asp:Label>
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Click</asp:LinkButton>
                                            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="Here to Close The Previous Session."></asp:Label>
                                        </center>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td colspan="2">
                            <div class="form-group">
                                <div class="col-sm-offset-4 col-sm-8">
                                    <asp:ImageButton ID="btnLogin" runat="server" float="right" Width="30%" Height="41px"
                                        ImageUrl="../App_Themes/Styles/Images/btnlogin.jpg" ValidationGroup="Login" OnClick="btnLogin_Click" />
                                    <%--<asp:Image ID="Image4" runat="server" Width="30%" float="left" align="right" ImageUrl="~/App_Themes/Styles/Images/logo_Comp2.png"
                                Height="36px" />--%>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="form-group">
                                <div class="col-sm-offset-4 col-sm-8">
                                    <table style="width: 90%">
                                        <tr>
                                            <td style="width: 50%">
                                                <asp:ImageButton ID="ImageButton1" runat="server" float="right" Width="17%" Height="29px"
                                                    ImageUrl="../App_Themes/Styles/Images/Acme_Generics_Logo.png" />
                                            </td>
                                            <td style="float: right; text-align: right">
                                                <asp:Image ID="Image3" runat="server" Width="40%" ImageUrl="~/App_Themes/Styles/Images/logo_Comp2.png"
                                                    Height="36px" />
                                            </td>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div>
                                <hr style="border: 1px solid black" />
                                <p align="right" style="margin-top: 1px; margin-right: 3px">
                                    Copyright @ 2018 Barcode India Ltd
                                </p>
                            </div>
                        </td>
                    </tr>
                    <asp:Button ID="btnGetPlant" runat="server" float="left" class="btn-primary" Text="Get Plant"
                        Height="30px" Width="49%" ValidationGroup="SCAN" CssClass="hidden" OnClick="btnGetPlant_Click" />
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnLogin" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </form>
    </div>
</body>
</html>

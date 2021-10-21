<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMaterialReturn.aspx.cs"
    Inherits="frmPicking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MTS | Version 1.0</title>
    <link href="../../Styles/Style_Controls.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Style_Design.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Style_Grid.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/ex.css" rel="stylesheet" type="text/css">
    <link href="../../cdn/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="../../cdn/jquery.min.js"></script>
    <script src="../../cdn/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../cdn/jquery.min.js"></script>
    <script type="text/javascript" src="../../cdn/bootstrap.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style type="text/css">
        .Label
        {
            font-family: Calibri;
            font-size: 10pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }
        
        .InfoLabel
        {
            font-family: Calibri;
            font-size: 8pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }
        
        .QtyLabel
        {
            font-family: Calibri;
            font-size: 8pt;
            color: White;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }
        .Button
        {
            border-color: #006699;
            border-width: 0px;
            background-image: url('../../App_Themes/Styles/Images/ButtonOut.png');
            font-family: Calibri;
            font-size: 14px;
            color: #FFFFFF;
            width: 120px;
            height: 24px;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            cursor: inherit;
        }
        .BTextBox
        {
            border: 1px solid #c0c0c0;
            font-family: Calibri;
            font-size: 10px;
            color: Black;
            margin-left: 0px;
            padding-left: 2px;
            padding-right: 2px;
            width: 50px;
            height: 25px;
        }
        .TextBox
        {
            border: 1px solid #c0c0c0;
            font-family: Calibri;
            font-size: 9px;
            color: Black;
            margin-left: 0px;
            padding-left: 2px;
            padding-right: 2px;
            width: 50px;
            height: 30px;
        }
        
        .DropDownList
        {
            font-family: Calibri;
            font-size: 10pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 50px;
            height: 30px;
            text-align: left;
        }
        .MiniDropDownList
        {
            font-family: Calibri;
            font-size: 9pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 40px;
            height: 20px;
            text-align: left;
        }
        
        .Checkbox
        {
            width: 20px;
            height: 20px;
            display: block;
            background: url("link_to_image");
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
        .style13
        {
            width: 184px;
        }
        .style14
        {
            width: 97px;
        }
        .style16
        {
            width: 14%;
        }
    </style>
</head>
<body>
    <div class="container-fluid">
        <form role="form" class="form-horizontal" id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="table" style="width: 100%; height: 305px;">
                    <tr>
                        <td>
                            <div class="form-group">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 98%; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                                            background-repeat: repeat-x;" class="style1">
                                            <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Material Return"
                                                ForeColor="White" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="2" style="height: 40px; width: 2%; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                                            background-repeat: repeat-x">
                                            <asp:Button ID="btnimgClose" class="btn-danger" runat="server" Text="X" Width="30px"
                                                Height="25px" OnClick="btnimgClose_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="form-group">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 50%">
                                            <asp:Label ID="Label1" CssClass="InfoLabel" runat="server" Text="Scan MRN Barcode :"></asp:Label>
                                        </td>
                                        <td style="width: 48%">
                                            <asp:TextBox ID="txtMRNBarcode" CssClass="TextBox" class="form-control" runat="server"
                                                autocomplete="off" Width="100%"></asp:TextBox>
                                        </td>
                                        <td style="width: 2%">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 50%">
                                            <asp:Label ID="Label9" CssClass="InfoLabel" runat="server" Text="Material Code :"></asp:Label>
                                        </td>
                                        <td style="width: 48%">
                                            <asp:Label ID="lblMaterialCode" CssClass="InfoLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 2%">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 50%">
                                            <asp:Label ID="Label2" CssClass="InfoLabel" runat="server" Text="Material Desc :"></asp:Label>
                                        </td>
                                        <td style="width: 48%">
                                            <asp:Label ID="lblMatDesc" CssClass="InfoLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 2%">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%">
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%">
                                                <tr>
                                                    <td width="25%">
                                                        <asp:Label ID="Label7" CssClass="InfoLabel" runat="server" Text="AR No. :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblARNo" CssClass="InfoLabel" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Label ID="Label5" CssClass="InfoLabel" runat="server" Text="Qty. :"></asp:Label>
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Label ID="lblQty" CssClass="InfoLabel" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 100%; text-align: center;">
                                            <asp:Label ID="lblMessage" CssClass="InfoLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:Button ID="btnSave" runat="server" class="btn-primary" CssClass="Button" ValidationGroup="SAVE"
                                                Text="Verify" Height="30px" Width="90%" OnClick="btnSave_Click" />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Button ID="btnClose" runat="server" class="btn-primary" CssClass="Button" Text="Close"
                                                Height="30px" CausesValidation="false" Width="90%" OnClick="btnClose_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div align="Center">
        <table style="text-align: center;">
            <tr>
                <td style="text-align: center;">
                    <div>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                            DisplayAfter="0" DynamicLayout="true">
                            <ProgressTemplate>
                                <%--<div id="Background"></div>--%>
                                <div id="Progress" align="Center">
                                    <img id="Img1" runat="server" alt="" src="~/App_Themes/Styles/Images/pleaseWait.gif" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Button ID="btnScanBarcode" runat="server" float="left" class="btn-primary" Text="Scan Barcode"
                            Height="30px" Width="49%" CssClass="hidden" OnClick="btnScanBarcode_Click" ValidationGroup="SCAN" />
                    </div>
                </td>
            </tr>
        </table>
        </div>
        </form>
    </div>
</body>
</html>

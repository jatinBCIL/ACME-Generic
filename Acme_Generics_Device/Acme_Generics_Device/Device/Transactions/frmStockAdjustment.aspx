<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmStockAdjustment.aspx.cs"
    Inherits="frmStockAdjustment" %>

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
        <asp:ScriptManager runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <%--        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>--%>
                <table class="table" style="width: 100%">
                    <tr>
                        <td>
                            <div class="form-group">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 98%; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                                            background-repeat: repeat-x;" class="style1">
                                            <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="Stock Adjustment"
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
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 50%;">
                                            <asp:Label ID="lblBatch" runat="server" CssClass="Label" Text="Material Barcode:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBatchNo" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                Width="80%" autocomplete="off"></asp:TextBox>
                                            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" CssClass="hidden"
                                                Height="30px" Width="38px" ValidationGroup="Scan" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 50%;">
                                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Available Qty:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRemainingCount" runat="server" CssClass="Label" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 50%;">
                                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Reason:"></asp:Label>
                                        </td>
                                        <td>
                                            <%--<asp:DropDownList ID="ddlReason" class="form-control" Width="220px" runat="server">
                                                <asp:ListItem>Select</asp:ListItem>
                                                <asp:ListItem>Sampling</asp:ListItem>
                                                <asp:ListItem>Wrong Input</asp:ListItem>
                                            </asp:DropDownList>--%>
                                            <asp:TextBox ID="txtReason" runat="server" CssClass="TextBox" Height="80px" SkinID="NAME"
                                                Width="80%" TextMode="MultiLine" />  
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 50%;">
                                            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Adjust Qty:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtbin" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                Width="80%"></asp:TextBox>
                                            <asp:Button ID="btnScanBin" runat="server" Text="Go" CssClass="hidden" Height="30px"
                                                Width="38px" ValidationGroup="Scan" OnClick="btnScanBin_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblMessage" runat="server" CssClass="Label" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 50%; text-align: center">
                                            <asp:Button ID="btnClose" runat="server" CssClass="Button" Text="Close" Width="90%"
                                                Height="30px" float="left" OnClick="btnClose_Click" />
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Button ID="btnReverse" runat="server" CssClass="Button" Text="Adjust Stock"
                                                Width="90%" Height="30px" float="left" OnClick="btnReverse_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        </form>
    </div>
</body>
</html>

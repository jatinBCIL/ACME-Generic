<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmAllocation.aspx.cs" Inherits="frm_FOR_Allocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MTS | Version 1.0</title>
    <link href="../../cdn/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="../../cdn/jquery.min.js?v=1.0.2"></script>
    <script src="../../cdn/bootstrap.min.js"></script>
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
<body style="background-image: none; background-color: White; margin: 0; font-family: Arial;
    font-size: 12pt;">
    <div class="container-fluid">
        <form role="form" id="form1" method="post" runat="server" class="form-horizontal">
        <asp:ScriptManager ID="scriptmanager1" runat="server">
        </asp:ScriptManager><%--
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>--%>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
        <table class="table">
            <tr>
                <td style="height: 25px; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                    background-repeat: repeat-x; width: 100%;">
                    <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Allocation"
                        ForeColor="White" Font-Bold="True"></asp:Label>
                </td>
                <td colsm="2" style="height: 30px; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                    background-repeat: repeat-x">
                    <asp:Button ID="Button1" class="btn-danger" runat="server" Text="X" Width="30px"
                        Height="25px" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div class="form-group">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 50%;">
                                    <asp:Label ID="lblLocationCode" runat="server" CssClass="Label" Text="Location Code :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLocationCode" runat="server" CssClass="TextBox" Height="25px"
                                        SkinID="NAME" Width="80%" autocomplete="off"></asp:TextBox>
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
                                    <asp:Label ID="lblMaterialBarcode" runat="server" CssClass="Label" Text="Material Barcode:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMaterialBarcode" runat="server" CssClass="TextBox" Height="25px"
                                        SkinID="NAME" Width="80%" autocomplete="off"></asp:TextBox>
                                    <asp:Button ID="btnScanMaterial" runat="server" Text="Go" OnClick="btnScanMaterial_Click"
                                        CssClass="hidden" Height="30px" Width="38px" ValidationGroup="Scan" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="form-group">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 50%;">
                                    <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Total Count :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCount" runat="server" CssClass="Label" Text="0"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="form-group">
                        <table style="width: 100%;">
                            <tr>
                                <td style="text-align:center;" >
                                    <asp:Label ID="lblMessage" runat="server" CssClass="Label" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="form-group">
                        <table style="width: 100%;">
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnClear" runat="server" class="btn-primary" CssClass="Button" Text="Clear" Width="90%"
                                        Height="30px" float="left" OnClick="btnClear_Click" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Button ID="btnClose" runat="server" class="btn-primary" CssClass="Button" Text="Close" Width="90%"
                                        Height="30px" float="left" OnClick="btnClose_Click" />
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

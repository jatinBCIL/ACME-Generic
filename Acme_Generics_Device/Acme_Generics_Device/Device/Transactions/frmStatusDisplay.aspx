<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmStatusDisplay.aspx.cs"
    Inherits="frm_FOR_Allocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MTS | Version 1.0</title>
    <link href="../../cdn/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="../../cdn/jquery.min.js"></script>
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
        <%--        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table class="table">
                    <tr>
                        <td style="height: 25px; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                            background-repeat: repeat-x; width: 100%;">
                            <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Status Display"
                                ForeColor="White" Font-Bold="True"></asp:Label>
                        </td>
                        <td colsm="2" style="height: 30px; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                            background-repeat: repeat-x">
                            <asp:Button ID="Button1" class="btn-danger" runat="server" Text="X" Width="30px"
                                Height="25px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 50%;">
                                            <asp:Label ID="lblARNo" runat="server" CssClass="Label" Text="Scan Barcode :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBarcode" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
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
                                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="QC Status :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblQCStatus" runat="server" CssClass="Label" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 50%;">
                                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Item :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblItem" runat="server" CssClass="Label" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 50%;">
                                            <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Item Name :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblItemName" runat="server" CssClass="Label" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 22%;">
                                            <asp:Label ID="Label2" runat="server" CssClass="InfoLabel" Text="GRN No.:"></asp:Label>
                                        </td>
                                        <td style="width: 28%; text-align: left">
                                            <asp:Label ID="lblGRNNo" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 22%;">
                                            <asp:Label ID="Label5" runat="server" CssClass="InfoLabel" Text="AR No.:"></asp:Label>
                                        </td>
                                        <td style="width: 28%; text-align: left">
                                            <asp:Label ID="lblArNO1" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 25%;">
                                            <asp:Label ID="Label4" runat="server" CssClass="InfoLabel" Text="MFG Date :"></asp:Label>
                                        </td>
                                        <td style="width: 25%; text-align: left">
                                            <asp:Label ID="lblMfgDate" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 25%;">
                                            <asp:Label ID="Label7" runat="server" CssClass="InfoLabel" Text="EXP. Date :"></asp:Label>
                                        </td>
                                        <td style="width: 25%; text-align: left">
                                            <asp:Label ID="lblExpDate" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 15%;">
                                            <asp:Label ID="Label6" runat="server" CssClass="InfoLabel" Text="Inward no :"></asp:Label>
                                        </td>
                                        <td style="width: 35%; text-align: left">
                                            <asp:Label ID="lblBatch" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%;">
                                            <asp:Label ID="Label9" runat="server" CssClass="InfoLabel" Text="Retest :"></asp:Label>
                                        </td>
                                        <td style="width: 30%; text-align: left">
                                            <asp:Label ID="lblRetest" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 35%;">
                                            <asp:Label ID="Label12" runat="server" CssClass="InfoLabel" Text="Container Qty:"></asp:Label>
                                        </td>
                                        <td style="width: 15%;">
                                            <asp:Label ID="lblContQty" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 35%;">
                                            <asp:Label ID="Label13" runat="server" CssClass="InfoLabel" Text="Material Type:"></asp:Label>
                                        </td>
                                        <td style="width: 15%;">
                                            <asp:Label ID="lblMatType" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 25%;">
                                            <asp:Label ID="Label10" runat="server" CssClass="InfoLabel" Text="V Batch:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblVBatch" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 25%;">
                                            <asp:Label ID="Label14" runat="server" CssClass="InfoLabel" Text="Location:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLoc" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                        </td>
                                    </tr>

                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 50%;">
                                            <asp:Label ID="Label8" runat="server" CssClass="Label" Text="Supplier:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSupplier" runat="server" CssClass="Label" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 30%;">
                                            <asp:Label ID="Label11" runat="server" CssClass="Label" Text="MFG Name:"></asp:Label>
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Label ID="lblMFGName" runat="server" CssClass="Label" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%; text-align: center;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblResult" Text="" CssClass="Label" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Button ID="btnClose" runat="server" CssClass="Button" Text="Close" Width="30%"
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

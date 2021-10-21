<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmReversePicking.aspx.cs"
    Inherits="frmPicking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MTS | Version 1.0</title>
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
            font-size: 9pt;
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
        .DropDownList
        {
            font-family: Calibri;
            font-size: 9pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 30px;
            text-align: left;
        }
        
        .Button
        {
            border-color: #006699;
            border-width: 0px;
            background-image: url('../../App_Themes/Styles/Images/ButtonOut.png');
            font-family: Arial;
            font-size: 12px;
            color: #FFFFFF;
            width: 120px;
            height: 18px;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            cursor: inherit;
        }
        
        .TextBox
        {
            border: 1px solid #c0c0c0;
            font-family: Calibri;
            font-size: 9pt;
            color: Black;
            margin-left: 0px;
            width: 350px;
            height: 30px;
            padding-left: 2px;
            padding-right: 2px;
        }
        
        .style1
        {
            height: 22px;
        }
        .style3
        {
            height: 40px;
        }
    </style>
</head>
<body>
    <div class="container-fluid">
        <form role="form" class="form-horizontal" id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table class="table" style="width: 100%">
            <tr>
                <td>
                    <div class="form-group">
                        <table width="100%">
                            <tr>
                                <td style="width: 98%; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                                    background-repeat: repeat-x;" class="style1">
                                    <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="Reverse Picking"
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
                                    <asp:Label ID="lblBatch" runat="server" CssClass="Label" Text="Scan Material Barcode:"></asp:Label>
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
                    <div class="form-group" runat="server" visible="false">
                        <div id="Div2" runat="server" visible="false" style="border: 1px solid #999999; width: 100%;
                            overflow: auto; visibility: collapse; height: 200px">
                            <table width="100%">
                                <tr>
                                    <td style="height: 50%; width: 100%" valign="top">
                                        <asp:GridView ID="gvMaterial" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                                            CellPadding="4" HeaderStyle-BackColor="#FFC90D" class="table" HeaderStyle-ForeColor="White"
                                            Width="100%" Height="60%" Font-Size="12px" EmptyDataText="There are no items to show in this view."
                                            PageSize="5">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Material No" DataField="MaterialCode" />
                                                <asp:BoundField HeaderText="Material Desc" DataField="MaterialName" />
                                                <asp:BoundField HeaderText="Batch No" DataField="MaterialBatch" />
                                                <asp:BoundField HeaderText="Dispensing Quantity" DataField="Quantity" />
                                            </Columns>
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <EditRowStyle CssClass="GridViewEditRowStyle" />
                                            <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="form-group">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 50%;">
                                    <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Remaining Qty:"></asp:Label>
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
                                    <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Scan Bin:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtbin" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                        Width="80%" autocomplete="off"></asp:TextBox>
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
                                <td style="width: 30%; text-align: center">
                                </td>
                                <td style="width: 50%; text-align: center">
                                    <asp:Button ID="btnClose" runat="server" CssClass="Button" Text="Close" Width="60%"
                                        Height="30px" float="left" OnClick="btnClose_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Button ID="btnReverse" runat="server" CssClass="Button" Text="Reverse" Width="10%"
                                        Height="30px" float="left" OnClick="btnReverse_Click" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>

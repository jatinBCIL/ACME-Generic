<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmRackDisplay.aspx.cs"
    Inherits="frmRackDisplay" %>

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
        .Label {
            font-family: Calibri;
            font-size: 10pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }

        .InfoLabel {
            font-family: Calibri;
            font-size: 8pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }

        .Button {
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

        .BTextBox {
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

        .TextBox {
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

        .DropDownList {
            font-family: Calibri;
            font-size: 10pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 50px;
            height: 30px;
            text-align: left;
        }

        .MiniDropDownList {
            font-family: Calibri;
            font-size: 9pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 40px;
            height: 20px;
            text-align: left;
        }

        .Checkbox {
            width: 20px;
            height: 20px;
            display: block;
            background: url("link_to_image");
        }

        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 33.33333333%;
            height: 34px;
            padding-left: 15px;
            padding-right: 15px;
        }

        .style13 {
            width: 184px;
        }

        .style14 {
            width: 97px;
        }

        .style16 {
            width: 14%;
        }
    </style>
</head>
<body style="background-image: none; background-color: White; margin: 0; font-family: Arial; font-size: 12pt;">
    <div class="container-fluid">
        <form role="form" id="form1" method="post" runat="server" class="form-horizontal">
            <%--        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <table class="table">
                        <tr>
                            <td style="height: 25px; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG'); background-repeat: repeat-x; width: 100%;">
                                <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Rack Details"
                                    ForeColor="White" Font-Bold="True"></asp:Label>
                            </td>
                            <td colsm="2" style="height: 30px; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG'); background-repeat: repeat-x">
                                <asp:Button ID="Button1" class="btn-danger" runat="server" Text="X" Width="30px"
                                    Height="25px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="width: 30%;">
                                                <asp:Label ID="lblRackNo" runat="server" CssClass="Label" Text="Rack No. :"></asp:Label>
                                            </td>
                                            <td style="width: 50%;">
                                                <asp:TextBox ID="txtRackNo" runat="server" CssClass="TextBox" Height="30px" SkinID="NAME"
                                                    Width="80%" autocomplete="off"></asp:TextBox>
                                            </td>
                                            <td style="vertical-align: middle">&nbsp;
                                                    <asp:Button ID="btnGo" runat="server" AutoPostBack ="true" Text="Go" OnClick="btnGo_Click" CssClass="Button"
                                                        Height="30px" Width="38px" ValidationGroup="Scan" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Scanned Rack No. :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblScannedRack" runat="server" CssClass="Label" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="form-group">
                                    <div id="Div2" runat="server" style="border: 1px solid #999999; width: 100%; overflow: auto; height: 300px">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="height: 70%; width: 100%;">
                                                    <asp:GridView ID="gvMaterial" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                                                        CellPadding="4" HeaderStyle-BackColor="#FFC90D" class="table" HeaderStyle-ForeColor="White"
                                                        Width="100%" Height="80%" Font-Size="9px" EmptyDataText="There are no items to show in this view."
                                                        PageSize="5">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Material No" DataField="MaterialCode" />
                                                            <asp:BoundField HeaderText="AR No" DataField="MaterialBatch" />
                                                            <asp:BoundField HeaderText="Rack No" DataField="Bin" />
                                                            <asp:BoundField HeaderText="Container" DataField="Cont" />
                                                            <asp:BoundField HeaderText="Quantity" DataField="Qty" />
                                                            <asp:BoundField HeaderText="Status" DataField="Status" />
                                                            <asp:BoundField HeaderText="Allocated By" DataField="Allocate_By" />
                                                            <asp:BoundField HeaderText="Allocated On" DataField="Allocate_On" />
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

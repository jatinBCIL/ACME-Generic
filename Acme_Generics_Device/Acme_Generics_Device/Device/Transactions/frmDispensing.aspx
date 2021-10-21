<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDispensing.aspx.cs" Inherits="frm_FOR_Allocation" %>

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
        /*AutoComplete flyout */
        .completionList
        {
            border: solid 1px #444444;
            margin: 0px;
            padding: 2px;
            height: 100px;
            overflow: auto;
            background-color: #FFFFFF;
        }
        
        .listItem
        {
            color: #1C1C1C;
        }
        
        .itemHighlighted
        {
            background-color: #ffc0c0;
        }
    </style>
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
<body style="background-image: none; background-color: White; margin: 0; font-family: Arial;
    font-size: 12pt;">
    <div class="container-fluid">
        <form role="form" id="form1" method="post" runat="server" class="form-horizontal">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table class="table">
                    <tr>
                        <td style="height: 25px; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                            background-repeat: repeat-x; width: 100%;">
                            <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Dispensing"
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
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="lblBatch" runat="server" CssClass="Label" Text="Batch No. :"></asp:Label>
                                                </td>
                                                <td style="width: 50%;">
                                                    <asp:TextBox ID="txtBatchNo" runat="server" CssClass="BTextBox" Height="30px" SkinID="NAME"
                                                        Width="80%" autocomplete="off"></asp:TextBox>
                                                    <asp:AutoCompleteExtender CompletionListHighlightedItemCssClass="itemHighlighted"
                                                        CompletionListItemCssClass="listItem" runat="server" CompletionInterval="100"
                                                        CompletionSetCount="1" EnableCaching="true" ServiceMethod="GetBatchNo" ID="AutoCompleteExtender3"
                                                        DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtBatchNo"
                                                        MinimumPrefixLength="1" UseContextKey="True">
                                                    </asp:AutoCompleteExtender>
                                                </td>
                                                <td style="vertical-align: middle">
                                                    &nbsp;
                                                    <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" CssClass="Button"
                                                        Height="30px" Width="38px" ValidationGroup="Scan" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <div id="Div2" runat="server" style="border: 1px solid #999999; width: 100%; overflow: auto;
                                            height: 200px">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="height: 50%; width: 100%;">
                                                        <asp:GridView ID="gvMaterial" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                                                            CellPadding="4" HeaderStyle-BackColor="#FFC90D" class="table" HeaderStyle-ForeColor="White"
                                                            Width="100%" Height="60%" Font-Size="9px" EmptyDataText="There are no items to show in this view."
                                                            PageSize="5">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Material No" DataField="MaterialCode" />
                                                                <asp:BoundField HeaderText="Batch No" DataField="MaterialBatch" />
                                                                <asp:BoundField HeaderText="Dispensing Quantity" DataField="Quantity" />
                                                                <asp:BoundField HeaderText="UOM" DataField="UOM" />
                                                                <asp:BoundField HeaderText="Line No" DataField="LineItem" />
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
                                                <td style="text-align: center">
                                                    <asp:Label CssClass="Label" Text="" ID="lblMessage0" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 33%; text-align: center">
                                                    <asp:Button ID="btnClose" runat="server" CssClass="Button" Text="Close" Width="80%"
                                                        Height="30px" float="left" OnClick="btnClose_Click" />
                                                </td>
                                                <td style="width: 33%; text-align: center">
                                                    <asp:Button ID="btnBulkDisp" runat="server" CssClass="Button" Text="Bulk" Width="80%"
                                                        Height="30px" float="left" OnClick="btnBulkDisp_Click" />
                                                </td>
                                                <td style="width: 33%; text-align: center">
                                                    <asp:Button ID="btnNext" runat="server" CssClass="Button" Text="Next" Width="80%"
                                                        Height="30px" float="left" OnClick="btnNext_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 40%;">
                                                    <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Select Booth :"></asp:Label>
                                                </td>
                                                <td style="width: 40%;">
                                                    <asp:DropDownList ID="ddlBooth" class="form-control" CssClass="DropDownList" Width="80%"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 50%;">
                                                    <asp:Label ID="Label8" runat="server" CssClass="InfoLabel" Text="Material Code :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMaterial" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="Label11" runat="server" CssClass="InfoLabel" Text="Material Desc :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="LblDesc" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 20%;">
                                                    <asp:Label ID="Label3" runat="server" CssClass="InfoLabel" Text="Mat.Batch:"></asp:Label>
                                                </td>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="lblBatchNo" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 20%;">
                                                    <asp:Label ID="Label1" runat="server" CssClass="InfoLabel" Text="AR No :"></asp:Label>
                                                </td>
                                                <td style="width: 29%;">
                                                    <asp:Label ID="lblARno" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%; background-color: #3588FD">
                                            <tr>
                                                <td class="style14" style="width: 17%;">
                                                    <asp:Label ID="Label13" runat="server" CssClass="QtyLabel" Text="Qty :"></asp:Label>
                                                </td>
                                                <td class="style13" style="width: 29%;">
                                                    <asp:Label ID="lblQty" runat="server" CssClass="QtyLabel" Text=""></asp:Label>
                                                </td>
                                                <td class="style16" style="width: 17%;">
                                                    <asp:Label ID="Label15" runat="server" CssClass="QtyLabel" Text="UOM"></asp:Label>
                                                </td>
                                                <td style="width: 29%;">
                                                    <asp:Label ID="lblUom" runat="server" CssClass="QtyLabel" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style14" style="width: 25%;">
                                                    <asp:Label ID="Label2" runat="server" CssClass="QtyLabel" Text="Rem Qty :"></asp:Label>
                                                </td>
                                                <td class="style13" style="width: 25%;">
                                                    <asp:Label ID="lblRemQty" runat="server" CssClass="QtyLabel" Text=""></asp:Label>
                                                </td>
                                                <td class="style16" style="width: 25%;">
                                                    <asp:Label ID="Label5" runat="server" CssClass="QtyLabel" Text="Scan Qty :"></asp:Label>
                                                </td>
                                                <td style="width: 25%;">
                                                    <asp:Label ID="lblScanQty" runat="server" CssClass="QtyLabel" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%; margin-bottom: 0px;">
                                            <tr>
                                                <td style="width: 20%;">
                                                    <asp:Label ID="Label12" runat="server" CssClass="InfoLabel" Text="Lot No:"></asp:Label>
                                                </td>
                                                <td style="width: 25%;">
                                                    <asp:DropDownList ID="ddlLot" runat="server" Width="90px" CssClass="MiniDropDownList"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlLot_SelectedIndexChanged">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>NA</asp:ListItem>
                                                        <asp:ListItem>I</asp:ListItem>
                                                        <asp:ListItem>II</asp:ListItem>
                                                        <asp:ListItem>III</asp:ListItem>
                                                        <asp:ListItem>IV</asp:ListItem>
                                                        <asp:ListItem>V</asp:ListItem>
                                                        <asp:ListItem>VI</asp:ListItem>
                                                        <asp:ListItem>VII</asp:ListItem>
                                                        <asp:ListItem>VIII</asp:ListItem>
                                                        <asp:ListItem>IX</asp:ListItem>
                                                        <asp:ListItem>X</asp:ListItem>
                                                        <asp:ListItem>XI</asp:ListItem>
                                                        <asp:ListItem>XII</asp:ListItem>
                                                        <asp:ListItem>XIII</asp:ListItem>
                                                        <asp:ListItem>XIV</asp:ListItem>
                                                        <asp:ListItem>XV</asp:ListItem>
                                                        <asp:ListItem>XVI</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 25%;">
                                                    <asp:Label ID="Label16" runat="server" CssClass="InfoLabel" Text="Container:"></asp:Label>
                                                </td>
                                                <td style="width: 25%;">
                                                    <asp:Label ID="lblCont" runat="server" CssClass="InfoLabel" Text="" Visible="false"
                                                        AutoPostBack="true"></asp:Label>
                                                    <asp:TextBox ID="txtCount" runat="server" CssClass="BTextBox" Height="27px" Width="70px"
                                                        autocomplete="off" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 20%;">
                                                    <asp:Label ID="Label9" runat="server" CssClass="InfoLabel" Text="UOI:"></asp:Label>
                                                </td>
                                                <td style="width: 30%;">
                                                    <asp:DropDownList ID="ddlUnit" CssClass="MiniDropDownList" runat="server" AutoPostBack="true"
                                                        Width="90px">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>KG</asp:ListItem>
                                                        <asp:ListItem>NOS</asp:ListItem>
                                                        <asp:ListItem>GM</asp:ListItem>
                                                        <asp:ListItem>LIT</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 45%;">
                                                    <asp:CheckBox ID="chkManual" Text="" runat="server" Checked="false" OnCheckedChanged="chkManual_CheckedChanged"
                                                        AutoPostBack="true" />
                                                    <asp:Label ID="Label7" runat="server" CssClass="InfoLabel" Text="Manual Weight"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="Label20" runat="server" CssClass="Label" Text="Scan Material :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMaterialBarcode" runat="server" CssClass="TextBox" Height="25px"
                                                        Width="70%" autocomplete="off"></asp:TextBox>
                                                    <asp:CheckBox ID="chkType" Text="" runat="server" Checked="false" OnCheckedChanged="chkManual_CheckedChanged"
                                                        AutoPostBack="true" />
                                                    <asp:Label ID="Label23" runat="server" CssClass="InfoLabel" Text="Full"></asp:Label>
                                                    <asp:Button ID="btnScanMaterial" runat="server" Text="Go" OnClick="btnScanMaterial_Click"
                                                        CssClass="hidden" Height="30px" Width="38px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="Label10" runat="server" CssClass="Label" Text="Scan Balance:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtWeighingBalance" runat="server" CssClass="TextBox" Height="25px"
                                                        Width="70%" autocomplete="off"></asp:TextBox>
                                                    <asp:Button ID="btnScanWeighing" runat="server" Text="Go" OnClick="btnScanBalance_Click"
                                                        CssClass="hidden" Height="30px" Width="38px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="DivNO" runat="server" class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 30%;">
                                                    <asp:Label ID="Label4" runat="server" CssClass="Label" Text="No of Unit:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUnit" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                        Width="70%" autocomplete="off"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <div id="DivWeight" runat="server" class="col-sm-12">
                                            <table class="table">
                                                <tr>
                                                    <td class="col-sm-2">
                                                        <asp:Label ID="Label434" CssClass="Label" runat="server" Text="Gross wt." />
                                                    </td>
                                                    <td class="col-sm-1">
                                                        <asp:Label ID="Label43" CssClass="Label" runat="server" Text="Tare wt."> </asp:Label>
                                                    </td>
                                                    <td class="col-sm-1">
                                                        <asp:Label ID="Label44" CssClass="Label" runat="server" Text="Net wt."> </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="col-sm-2">
                                                        <asp:TextBox ID="txtGrossWt" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            onkeypress="return validateFloatKeyPress(this)" autocomplete="off" Width="80px"
                                                            OnTextChanged="txtGrossWt_TextChanged"> </asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers"
                                                            ValidChars="." TargetControlID="txtGrossWt" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </td>
                                                    <td class="col-sm-1">
                                                        <asp:TextBox ID="txtTareWt" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            autocomplete="off" onkeypress="return isDecimal(event)" Width="80px" OnTextChanged="txtTareWt_TextChanged"></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers"
                                                            ValidChars="." TargetControlID="txtTareWt" Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </td>
                                                    <td class="col-sm-1">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtNetWt" runat="server" ReadOnly="true" AutoPostBack="true" CssClass="form-control"
                                                                        BackColor="LightGray" onkeypress="return isDecimal(event)" autocomplete="off"
                                                                        Width="80px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblNetUom" runat="server" CssClass="Label" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
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
                                    <div class="form-group" runat="server" id="divAdd">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 100%; text-align: center">
                                                    <asp:Button ID="btnClear1" runat="server" class="btn-primary" CssClass="Button" Text="Clear"
                                                        Width="46%" Height="30px" OnClick="btnClear1_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnAdd1" runat="server" class="btn-primary" CssClass="Button" Text="Add"
                                                        Width="46%" Height="30px" OnClick="btnAdd1_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 100%; text-align: center">
                                                    <asp:Button ID="btnBack" runat="server" class="btn-primary" CssClass="Button" Text="Back"
                                                        Width="46%" Height="30px" float="left" OnClick="btnBack_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnPrint" runat="server" class="btn-primary" CssClass="Button" Text="Print"
                                                        Width="46%" Height="30px" float="left" OnClick="btnPrint_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <asp:GridView ID="dgvbarcode" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                                        CellPadding="4" HeaderStyle-BackColor="#FFC90D" class="table" HeaderStyle-ForeColor="White"
                                        Width="100%" Height="60%" Font-Size="9px" EmptyDataText="There are no items to show in this view."
                                        PageSize="5">
                                        <Columns>
                                            <asp:BoundField HeaderText="Material Barcode" DataField="Barcode" />
                                            <asp:BoundField HeaderText="NetWeight" DataField="NWeight" />
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
                                </asp:View>
                                <asp:View ID="vwBulkDispense" runat="server">
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 50%;">
                                                    <asp:Label ID="Label18" runat="server" CssClass="Label" Text="Dispense Booth :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBBooth" CssClass="DropDownList" Width="80%" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 50%;">
                                                    <asp:Label ID="Label17" runat="server" CssClass="Label" Text="Material Code :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblBMatCode" runat="server" CssClass="Label" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 50%;">
                                                    <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Material Desc :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblBMatDesc" runat="server" CssClass="Label" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 26%;">
                                                    <asp:Label ID="Label22" runat="server" CssClass="InfoLabel" Text="Mat. Batch No:"></asp:Label>
                                                </td>
                                                <td style="width: 23%;">
                                                    <asp:Label ID="lblBMatBat" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 15%;">
                                                    <asp:Label ID="Label24" runat="server" CssClass="InfoLabel" Text="AR No :"></asp:Label>
                                                </td>
                                                <td style="width: 35%;">
                                                    <asp:Label ID="lblBArno" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%; background-color: #3588FD">
                                            <tr>
                                                <td class="style14" style="width: 17%;">
                                                    <asp:Label ID="Label26" runat="server" CssClass="QtyLabel" Text="Qty :"></asp:Label>
                                                </td>
                                                <td class="style13" style="width: 29%;">
                                                    <asp:Label ID="lblBQty" runat="server" CssClass="QtyLabel" Text=""></asp:Label>
                                                </td>
                                                <td class="style16" style="width: 17%;">
                                                    <asp:Label ID="Label28" runat="server" CssClass="QtyLabel" Text="UOM :"></asp:Label>
                                                </td>
                                                <td style="width: 29%;">
                                                    <asp:Label ID="lblBUOM" runat="server" CssClass="QtyLabel" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style14" style="width: 17%;">
                                                    <asp:Label ID="Label30" runat="server" CssClass="QtyLabel" Text="Rem Qty :"></asp:Label>
                                                </td>
                                                <td class="style13" style="width: 29%;">
                                                    <asp:Label ID="lblBRem" runat="server" CssClass="QtyLabel" Text=""></asp:Label>
                                                </td>
                                                <td class="style16" style="width: 17%;">
                                                    <asp:Label ID="Label32" runat="server" CssClass="QtyLabel" Text="Scan Qty :"></asp:Label>
                                                </td>
                                                <td style="width: 29%;">
                                                    <asp:Label ID="lblBScan" runat="server" CssClass="QtyLabel" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%; margin-bottom: 0px;">
                                            <tr>
                                                <td style="width: 15%;">
                                                    <asp:Label ID="Label34" runat="server" CssClass="InfoLabel" Text="Lot No:"></asp:Label>
                                                </td>
                                                <td style="width: 25%; text-align: left">
                                                    <asp:DropDownList ID="ddlBLotNo" CssClass="MiniDropDownList" AutoPostBack="true"
                                                        runat="server" Width="80px">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>NA</asp:ListItem>
                                                        <asp:ListItem>I</asp:ListItem>
                                                        <asp:ListItem>II</asp:ListItem>
                                                        <asp:ListItem>III</asp:ListItem>
                                                        <asp:ListItem>IV</asp:ListItem>
                                                        <asp:ListItem>V</asp:ListItem>
                                                        <asp:ListItem>VI</asp:ListItem>
                                                        <asp:ListItem>VII</asp:ListItem>
                                                        <asp:ListItem>VIII</asp:ListItem>
                                                        <asp:ListItem>IX</asp:ListItem>
                                                        <asp:ListItem>X</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 15%;">
                                                    <asp:Label ID="Label14" runat="server" CssClass="InfoLabel" Text="Container:"></asp:Label>
                                                </td>
                                                <td style="width: 25%; text-align: left">
                                                    <asp:Label ID="lblBCont" runat="server" Text="" Visible="false" AutoPostBack="true"
                                                        CssClass="InfoLabel"></asp:Label>
                                                    <asp:TextBox ID="txtBCont" runat="server" CssClass="TextBox" Height="27px" Width="70px"
                                                        autocomplete="off" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%; margin-bottom: 0px;">
                                            <tr>
                                                <td style="width: 50%;">
                                                    <asp:Label ID="Label38" runat="server" CssClass="Label" Text="Unit of Issue :"></asp:Label>
                                                </td>
                                                <td style="width: 50%;">
                                                    <asp:DropDownList ID="ddlBUOM" CssClass="DropDownList" runat="server" Width="80%">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>KG</asp:ListItem>
                                                        <asp:ListItem>NOS</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 50%;">
                                                    <asp:Label ID="Label40" runat="server" CssClass="Label" Text="Scan Material:"></asp:Label>
                                                </td>
                                                <td style="width: 50%;">
                                                    <asp:TextBox ID="txtBRMBarcode" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                        Width="80%" autocomplete="off"></asp:TextBox>
                                                    <asp:Button ID="btnBRMBarcode" runat="server" Text="Go" CssClass="hidden" Height="30px"
                                                        Width="38px" ValidationGroup="Scan" OnClick="btnBRMBarcode_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 50%;">
                                                    <asp:Label ID="Label21" runat="server" CssClass="Label" Text="Available Qty:"></asp:Label>
                                                </td>
                                                <td style="width: 50%;">
                                                    <asp:TextBox ID="txtBQty" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                        Width="80%" autocomplete="off"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblMessage1" runat="server" CssClass="Label" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group" runat="server" id="div1">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 50%; text-align: center">
                                                    <asp:Button ID="btnClear" runat="server" class="btn-primary" CssClass="Button" Text="Clear"
                                                        Width="90%" Height="30px" OnClick="btnClear_Click" />
                                                </td>
                                                <td style="width: 50%; text-align: center">
                                                    <asp:Button ID="btnAdd" runat="server" class="btn-primary" CssClass="Button" Text="Add"
                                                        Width="90%" Height="30px" OnClick="btnAdd_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 50%; text-align: center">
                                                    <asp:Button ID="btnBBack" runat="server" class="btn-primary" CssClass="Button" Text="Back"
                                                        Width="90%" Height="30px" float="left" OnClick="btnBBack_Click" />
                                                </td>
                                                <td style="width: 50%; text-align: center">
                                                    <asp:Button ID="btnBPrint" runat="server" class="btn-primary" CssClass="Button" Text="Print"
                                                        Width="90%" Height="30px" float="left" OnClick="btnBPrint_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:View>
                                <asp:View ID="View4" runat="server">
                                    <asp:GridView ID="gvBulkdtl" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                                        CellPadding="4" HeaderStyle-BackColor="#FFC90D" class="table" HeaderStyle-ForeColor="White"
                                        Width="100%" Height="60%" Font-Size="10px" EmptyDataText="There are no items to show in this view."
                                        PageSize="5">
                                        <Columns>
                                            <asp:BoundField HeaderText="Material Barcode" DataField="Barcode" />
                                            <asp:BoundField HeaderText="GrossWeight" DataField="GWeight" />
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
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--
        <asp:ScriptManager ID="ScriptManager1" runat="server" />--%>
        </form>
    </div>
</body>
</html>

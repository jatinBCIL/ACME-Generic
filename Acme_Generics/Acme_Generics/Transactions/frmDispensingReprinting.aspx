<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmDispensingReprinting.aspx.cs" Inherits="frmGrn_Printing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/Style_Controls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Style_Design.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Style_Grid.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/ex.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        div#tipDiv
        {
            font-size: 13px;
            line-height: 1.2;
            color: #3333CC;
            background-color: #33CCCC;
            border: 1px solid #667295;
            padding: 4px;
            width: 270px;
            font-family: calibri;
        }
        .style18
        {
            height: 46px;
        }
    </style>
    <script src="../Javascript/dw_tooltip_c.js" type="text/javascript"></script>
    <script type="text/javascript">

        dw_Tooltip.defaultProps = {
            //supportTouch: true, // set false by default
            hoverable: true
        }

        dw_Tooltip.content_vars = {
            L1: 'Field Name : Test' + '\n' + 'Field Name : Test',
            L3: 'Field Name : Test',
            L4: 'Field Name : Test',
            L5: 'Field Name : Test',
            L6: 'test'
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                        background-repeat: repeat-x">
                        <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="Dispensing Reprinting"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                            <table cellpadding="5">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDocumentNo" runat="server" CssClass="Label" Text="Product Batch :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtProcessOrderNo" runat="server" CssClass="TextBox" Height="25px"
                                                            SkinID="NAME" Width="220px"></asp:TextBox>
                                                        <asp:AutoCompleteExtender CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted"
                                                            CompletionListItemCssClass="listItem" runat="server" CompletionInterval="100"
                                                            CompletionSetCount="1" EnableCaching="true" ServiceMethod="GetProccno" ID="AutoCompleteExtender1"
                                                            DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtProcessOrderNo"
                                                            MinimumPrefixLength="1" UseContextKey="True">
                                                        </asp:AutoCompleteExtender>
                                                        <asp:Image ID="Image1" runat="server" Height="10px" ImageUrl="../App_Themes/Styles/Images/img_mand.png"
                                                            ToolTip="Mandatory Field!!!" Width="10px" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProcessOrderNo"
                                                            ErrorMessage="RequiredFieldValidator" ToolTip="Process order no. is Required"
                                                            ValidationGroup="Get"><img src="../App_Themes/Styles/Images/err1.png"
                                                            title="Process order no. is required!!!" /></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnGet" runat="server" CssClass="Button" Text="Get" Width="75px"
                                                            ValidationGroup="Get" OnClick="btnGet_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Btntest" runat="server" CssClass="Button" Text="Print" ValidationGroup="PrintLabel"
                                                            Width="75px" Visible="false" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" 
                                                Text="Select All" oncheckedchanged="chkSelectAll_CheckedChanged" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 30px;">
                                            <asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Auto">
                                                <asp:GridView ID="GrGRNDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                    CaptionAlign="Left" CellPadding="4" CssClass="GridViewStyle" EmptyDataText="There are no items to show in this view."
                                                    ShowFooter="True" Width="100%" OnSelectedIndexChanged="GrGRNDetails_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:TemplateField ControlStyle-Width="15px" HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="BarcodeNo" HeaderText="BarcodeNo" SortExpression="BarcodeNo" />
                                                        <asp:BoundField DataField="ProcessOrder" HeaderText="Process Order" SortExpression="GRN No" />
                                                        <asp:BoundField DataField="ProdCode" HeaderText="Product Code" SortExpression="GRN Item No_" />
                                                        <asp:BoundField DataField="ProductDesc" HeaderText="Product Desc" SortExpression="GRN Date" />
                                                        <asp:BoundField DataField="ProdBatch" HeaderText="Product Batch" SortExpression="Material Code" />
                                                        <asp:BoundField DataField="LineItemNo" HeaderText="Line Item No" SortExpression="Material Name" />
                                                        <asp:BoundField DataField="MatCode" HeaderText="Material Code" SortExpression="Batch No_" />
                                                        <asp:BoundField DataField="MatDesc" HeaderText="Material Desc" SortExpression="MFG Date" />
                                                        <asp:BoundField DataField="MaterialBatch" HeaderText="Material Batch" SortExpression="EXP Date" />
                                                        <asp:BoundField DataField="GrossWt" HeaderText="Gross Wt" SortExpression="Vendor Batch no_" />
                                                        <asp:BoundField DataField="NetWt" HeaderText="Net Wt" SortExpression="Supplier Name" />
                                                        <asp:BoundField DataField="TareWt" HeaderText="Tare Wt" SortExpression="Manufacture Name" />
                                                    </Columns>
                                                    <PagerSettings Position="TopAndBottom" />
                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    <EditRowStyle CssClass="GridViewEditRowStyle" />
                                                    <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Reason :&amp;nbsp;"></asp:Label>
                                                    </td>
                                                    <%--<td>
                                                        <asp:DropDownList ID="ddlReason" runat="server" CssClass="Combobox">
                                                            <asp:ListItem>
                                                         Select
                                                            </asp:ListItem>
                                                            <asp:ListItem>
                                                         Label Damage
                                                            </asp:ListItem>
                                                            <asp:ListItem>
                                                         Label Missing
                                                            </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>--%>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="txtReason" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                            Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReason"
                                                            ErrorMessage="RequiredFieldValidator" ToolTip="Reason is required!!!" ValidationGroup="PrintLabel"><img src="../App_Themes/Styles/Images/err1.png" 
                                                            title="Reason is required!!!" /></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPrintername" runat="server" CssClass="Label" Text="Printer&amp;nbsp;Name :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="Combobox" Height="26px"
                                                            Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="style18">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="Select" runat="server"
                                                            ControlToValidate="ddlPrinterName" ErrorMessage="RequiredFieldValidator" ToolTip="Printer Name is required!!!"
                                                            ValidationGroup="PrintLabel"><img src="../App_Themes/Styles/Images/err1.png" 
                                                            title="Printer Name is required!!!" /></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="5">
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnPrint" runat="server" CssClass="Button" Text="Print" Width="75px"
                                                            ValidationGroup="PrintLabel" OnClick="btnPrint_Click1" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnClose" runat="server" CssClass="Button" Text="Close" Width="75px"
                                                            OnClick="btnClose_Click" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            <table cellpadding="5">
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="Button" Width="75px"
                                                            OnClick="btnPrint_Click1" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnClose" runat="server" CssClass="Button" Text="Close" Width="75px"
                                                            OnClick="btnClose_Click" />
                                                    </td>
                                                    <td>
                                                    <asp:Button ID="btnPrint1" runat="server" CssClass="Button" Text="Print" 
                                                            Width="75px" onclick="btnPrint1_Click" ValidationGroup="PrintLabel" />
                                                    </td>
                                                    
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>--%>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGet" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

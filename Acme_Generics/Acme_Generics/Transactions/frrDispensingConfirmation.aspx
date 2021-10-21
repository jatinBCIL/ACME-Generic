<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true"
    CodeFile="frrDispensingConfirmation.aspx.cs" Inherits="frmGrn_Printing" %>

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
        .style15
        {
            width: 12px;
        }
        .style18
        {
            height: 46px;
        }
        .style20
        {
            width: 133px;
            height: 46px;
        }
        .style21
        {
            width: 8px;
            height: 46px;
        }
        .style22
        {
            width: 32px;
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <%--  <tr>
                    <td style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                        background-repeat: repeat-x">
                        <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="Dispensing confirmation"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td height="30" style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                                            background-repeat: repeat-x">
                                            <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="Dispensing confirmation"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="5">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDocumentNo" runat="server" CssClass="Label" Text="Batch No :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBatchNo" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                            Width="220px"></asp:TextBox>
                                                        <asp:AutoCompleteExtender CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted"
                                                            CompletionListItemCssClass="listItem" runat="server" CompletionInterval="100"
                                                            CompletionSetCount="1" EnableCaching="true" ServiceMethod="getBatchNo" ID="aceBatchNo"
                                                            DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtBatchNo"
                                                            MinimumPrefixLength="1" UseContextKey="True">
                                                        </asp:AutoCompleteExtender>
                                                        <asp:Image ID="Image1" runat="server" Height="10px" ImageUrl="../App_Themes/Styles/Images/img_mand.png"
                                                            ToolTip="Mandatory Field!!!" Width="10px" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBatchNo"
                                                            ErrorMessage="RequiredFieldValidator" ToolTip="Batch is Required" ValidationGroup="Get"><img 
                                                                                src="../App_Themes/Styles/Images/err1.png" 
                                                                                title="Batch is required!!!" /></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnGet" runat="server" CssClass="Button" Text="Get" Width="75px"
                                                            ValidationGroup="Get" OnClick="btnGet_Click" />
                                                        <%-- <asp:Button ID="Button1" runat="server" CssClass="Button" Style="margin-left: 800px" Text="R" Width="40px"
                                                            ValidationGroup="Get" OnClick="btnRepost_Click" />--%>
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
                                    <tr>
                                        <td style="height: 30px;">
                                            <asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Auto">
                                                <asp:GridView ID="GrGRNDetails" runat="server"  AllowSorting="True"
                                                    AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" CssClass="GridViewStyle"
                                                    EmptyDataText="There are no items to show in this view."  ShowFooter="True"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField ControlStyle-Width="15px" HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PickListNo" HeaderText="Pick List No" SortExpression="GRN No_" />
                                                        <asp:BoundField DataField="ProcessOrderNo" HeaderText="Process Order No" SortExpression="GRN Item No_" />
                                                        <asp:BoundField DataField="ProductBatch" HeaderText="Product Batch" SortExpression="GRN Date" />
                                                        <asp:BoundField DataField="ProductCode" HeaderText="Product Code" SortExpression="Material Code" />
                                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="Material Name" />
                                                        <asp:BoundField DataField="MaterialCode" HeaderText="Material Code" SortExpression="Batch No_" />
                                                        <asp:BoundField DataField="MaterialBatch" HeaderText="Material Batch" SortExpression="MFG Date" />
                                                        <asp:BoundField DataField="MaterialName" HeaderText="Material Name" SortExpression="EXP Date" />
                                                        <asp:BoundField DataField="ARNo" HeaderText="AR No" SortExpression="Vendor Batch no_" />
                                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Supplier Name" />
                                                        <asp:BoundField DataField="Uom" HeaderText="Uom" SortExpression="Manufacture Name" />
                                                        <asp:BoundField DataField="Lineitem" HeaderText="Line Item" SortExpression="Total Qty_" />
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
                                            <table cellpadding="5">
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnConfirm" runat="server" CssClass="Button" Text="Confirm" Width="75px"
                                                            OnClick="btnConfirm_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnClose" runat="server" CssClass="Button" Text="Close" Width="75px"
                                                            OnClick="btnClose_Click" />
                                                    </td>
                                                    <td>
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

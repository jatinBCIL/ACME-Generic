<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmARStockAdjust.aspx.cs" Inherits="frmArStockAdust" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <%--<tr>
                    <td style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                        background-repeat: repeat-x">
                   
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td height="30" style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                                    background-repeat: repeat-x">
                                    <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="Offline Stock Update"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="5">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDocumentNo" runat="server" CssClass="Label" Text="Ar No :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBatchNo" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                    Width="220px"></asp:TextBox>
                                                <asp:AutoCompleteExtender CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted"
                                                    CompletionListItemCssClass="listItem" runat="server" CompletionInterval="100"
                                                    CompletionSetCount="1" EnableCaching="true" ServiceMethod="GetBatchNo" ID="AutoCompleteExtender1"
                                                    DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtBatchNo"
                                                    MinimumPrefixLength="1" UseContextKey="True">
                                                </asp:AutoCompleteExtender>
                                                <asp:Image ID="Image1" runat="server" Height="10px" ImageUrl="../App_Themes/Styles/Images/img_mand.png"
                                                    ToolTip="Mandatory Field!!!" Width="10px" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBatchNo"
                                                    ErrorMessage="RequiredFieldValidator" ToolTip="Batch No is Required" ValidationGroup="Get"><img 
                                                                                src="../App_Themes/Styles/Images/err1.png" 
                                                                                title="Batch No. is required!!!" /></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnGet" runat="server" CssClass="Button" Text="Get" Width="75px"
                                                    ValidationGroup="Get" OnClick="btnGet_Click" />
                                                 
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
                                <td>
                                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" 
                                        Text="Select All" oncheckedchanged="chkSelectAll_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                            <td>
                             &nbsp;
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
                                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChkSelect_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="BarcodeNo" HeaderText="BarcodeNo" SortExpression="BarcodeNo" />
                                                <asp:BoundField DataField="GRNNo" HeaderText="GRN No" SortExpression="GRN No" />
                                                <asp:BoundField DataField="GRNItemNo" HeaderText="GRN Item No" SortExpression="GRN Item No_" />
                                                <asp:BoundField DataField="MaterialCode" HeaderText="Material Code" SortExpression="Material Code" />
                                                <asp:BoundField DataField="MaterialName" HeaderText="Material Name" SortExpression="Material Name" />
                                                <asp:BoundField DataField="InwardNo" HeaderText="Batch No" SortExpression="Batch No_" />
                                                <asp:BoundField DataField="ARNo" HeaderText="AR No" SortExpression="AR No" />
                                                <asp:TemplateField HeaderText="Containter Qty">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtContQty" Width="100%" onkeypress="CheckNumeric(event);" runat="server"
                                                            Text='<%# Bind("Qty") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="MaterialType" HeaderText="Material Type" SortExpression="Material Type" />
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
                                    <table cellpadding="5">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnPrint" runat="server" CssClass="Button" Text="Save" Width="75px"
                                                    ValidationGroup="Get" OnClick="btnPrint_Click" />
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGet" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

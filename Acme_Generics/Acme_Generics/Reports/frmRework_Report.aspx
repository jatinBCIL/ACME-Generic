<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Modules/MasterPage.master"
    CodeFile="frmRework_Report.aspx.cs" Inherits="frmRework_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script language="javascript" src="..Master/Javascript/JScript.js" type="text/javascript"></script>

    <style type="text/css">
        .hiddencol
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                        background-repeat: repeat-x">
                        <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Reports"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblSearch0" runat="server" CssClass="Label" Text="Report Name "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlrpttype" runat="server" AutoPostBack="True" CssClass="Combobox"
                                                        OnSelectedIndexChanged="ddlrpttype_SelectedIndexChanged" Height="25px" 
                                                        Width="172px">
                                                        <asp:ListItem>Select Report </asp:ListItem>
                                                        <asp:ListItem>Sampling Report</asp:ListItem>
                                                        <asp:ListItem>Material Status Report</asp:ListItem>
                                                        <asp:ListItem>Batch Tracking Report</asp:ListItem>
                                                        <asp:ListItem>Picklist Report</asp:ListItem>
                                                        <asp:ListItem>Picking Report</asp:ListItem>
                                                        <asp:ListItem>Dispesing Report</asp:ListItem>
                                                        <asp:ListItem>Dispesing Confirmation Report</asp:ListItem>
                                                        <asp:ListItem>Dispesing Details Report</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grSearch" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CaptionAlign="Left" CellPadding="4" CssClass="GridViewStyle" EmptyDataText="There are no items to show in this view."
                                            PageSize="20">
                                            <Columns>
                                                <asp:BoundField DataField="COLUMN_NAME" HeaderText="Field Name" SortExpression="COLUMN_NAME" />
                                                <asp:BoundField DataField="DATA_TYPE" HeaderStyle-CssClass="hiddencol" HeaderText="Data Type"
                                                    ItemStyle-CssClass="hiddencol" SortExpression="DATA_TYPE">
                                                    <HeaderStyle CssClass="hiddencol" />
                                                    <ItemStyle CssClass="hiddencol" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Search Criteria">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="cboCriteria" runat="server" CssClass="Combobox" Width="120px">
                                                            <asp:ListItem Selected="True" Value="=">Equal to</asp:ListItem>
                                                            <asp:ListItem Value="&lt;&gt;">Not equal to</asp:ListItem>
                                                            <asp:ListItem Value="like">Contains</asp:ListItem>
                                                            <asp:ListItem Value="likestart">Start with</asp:ListItem>
                                                            <asp:ListItem Value="likeend">End with</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Search Value">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="TextBox" ValidationGroup="Search" autocomplete="off"></asp:TextBox>
                                                        <table id="tblDate" runat="server" visible="false">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblSearch" runat="server" CssClass="Label" Text="From Date"></asp:Label>
                                                                    <asp:TextBox ID="txtFrom" runat="server" CssClass="TextBox" Width="150px" autocomplete="off"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="txtShelf_CalendarExtender" runat="server" Enabled="True"
                                                                        TargetControlID="txtFrom"></asp:CalendarExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label1" runat="server" CssClass="Label" Text="To Date"></asp:Label>
                                                                    <asp:TextBox ID="txtTo" runat="server" CssClass="TextBox" Width="150px" autocomplete="off"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtTo"></asp:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSearch" runat="server" CssClass="Button" OnClick="btnSearch_Click"
                                                        Text="Search" ValidationGroup="Search" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnViewAll" runat="server" CssClass="Button" OnClick="btnViewAll_Click"
                                                        Text="View All" Visible="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnBack" runat="server" CssClass="Button" OnClick="btnBack_Click"
                                                        Text="Back To Search" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnExcel" runat="server" CssClass="CCSImage" ImageUrl="~/App_Themes/Styles/Images/excel.png"
                                                        OnClick="btnExcel_Click" ToolTip="Click on this button to export details to excel"
                                                        Width="20px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GrPlants" runat="server" CaptionAlign="Left" AllowSorting="true"
                                            CellPadding="4" CssClass="GridViewStyle" EmptyDataText="There are no items to show in this view."
                                            OnRowDataBound="GrPlants_RowDataBound" PageSize="20" ShowFooter="True" AllowPaging="true"
                                            OnPageIndexChanging="GrPlants_PageIndexChanging">
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <EditRowStyle CssClass="GridViewEditRowStyle" />
                                            <EmptyDataRowStyle CssClass="EmptyDataRowStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <PagerSettings Position="TopAndBottom" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

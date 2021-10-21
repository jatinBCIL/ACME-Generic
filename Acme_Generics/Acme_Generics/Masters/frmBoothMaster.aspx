<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmBoothMaster.aspx.cs" Inherits="frmBooth_Master" %>

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
                <tr>
                    <td style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                        background-repeat: repeat-x">
                        <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Booth Master"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View2" runat="server">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td height="30" style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.png');
                                            background-repeat: repeat-x">
                                            <table cellpadding="5">
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="imgCloseV2" runat="server" Height="24px" ImageUrl="~/App_Themes/Styles/Images/exit.ico"
                                                            ToolTip="Close Page" Width="24px" OnClick="imgCloseV2_Click" PostBackUrl="~/Modules/frmMain.aspx" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgSave" runat="server" Height="24px" ImageUrl="~/App_Themes/Styles/Images/media_floppy_green.jpg"
                                                            ToolTip="Save Transaction" Width="24px" ValidationGroup="Save" OnClick="imgSave_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDetails" runat="server" Width="27px" Height="27px" ImageUrl="~/App_Themes/Styles/Images/imgDtl.jpg"
                                                            ToolTip="Click For Details" OnClick="imgDetails_Click" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style15">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style15">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td width="100%">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellpadding="5">
                                                <tr>
                                                    <td>
                                                        <table width="100%">
                                                            <tr valign="top">
                                                                <td style="width: 40%;">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label14" runat="server" CssClass="Label" Text="Plant Code"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddPlantcode" runat="server" AutoPostBack="True" CssClass="Combobox"
                                                                                    Height="25px" Width="224px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:Image ID="Image10" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                                                    ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvPlantcode" runat="server" ControlToValidate="ddPlantcode"
                                                                                    InitialValue="Select" ErrorMessage="Plant Code is required!!!" Text="&lt;img src='../App_Themes/Styles/Images/err1.png' title='Plant Code is required!!!' /&gt;"
                                                                                    ToolTip="Plant Code is required!!!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblItemCode13" runat="server" CssClass="Label" Text="Booth Code :"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtBoothCode" runat="server" SkinID="NAME" CssClass="TextBox" Width="220px"
                                                                                    MaxLength="500"></asp:TextBox>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:Image ID="Image1" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                                                    ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvPlantnm" runat="server" ControlToValidate="txtBoothCode"
                                                                                    ErrorMessage="Booth code is required!!!" Text="&lt;img src='../App_Themes/Styles/Images/err1.png' title='Booth code is required!!!' /&gt;"
                                                                                    ToolTip="Booth code is required!!!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Booth Desc :"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtBoothDesc" runat="server" SkinID="NAME" CssClass="TextBox" Width="220px"
                                                                                    MaxLength="500"></asp:TextBox>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:Image ID="Image2" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                                                    ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBoothDesc"
                                                                                    ErrorMessage="Booth desc is required!!!" Text="&lt;img src='../App_Themes/Styles/Images/err1.png' title='Booth desc is required!!!' /&gt;"
                                                                                    ToolTip="Booth desc is required!!!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Booth Type :"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButton ID="rbBType1" Checked="True" Text="Excipient" runat="server" ValidationGroup="A"
                                                                                    GroupName="Bgrp" />&nbsp;&nbsp;
                                                                                <asp:RadioButton ID="rbBType2" Text="API" runat="server" ValidationGroup="A" GroupName="Bgrp" />&nbsp;&nbsp;
                                                                                <asp:RadioButton ID="rbBType3" Text="PM" runat="server" ValidationGroup="A" GroupName="Bgrp" />
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:Image ID="Image3" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                                                    ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label9" runat="server" CssClass="Label" Text="User&amp;nbsp;Status"></asp:Label>
                                                                            </td>
                                                                            <%--  <td>
                                                                                            <asp:CheckBox ID="chkStatus" runat="server" CssClass="Checkbox" Text="Active" />
                                                                                        </td>--%>
                                                                            <td>
                                                                                <asp:RadioButton ID="RBactivate" Checked="True" Text="Activate" runat="server" ValidationGroup="A"
                                                                                    GroupName="RDgrp" />&nbsp;&nbsp;
                                                                                <asp:RadioButton ID="RBdeactivate" Text="De-Activate" runat="server" ValidationGroup="A"
                                                                                    GroupName="RDgrp" />
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:Image ID="Image14" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                                                    ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblRemark" runat="server" Visible="False" CssClass="Label" Text="Remark :"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtRemark" runat="server" Visible="False" CssClass="TextBox" Height="25px"
                                                                                    MaxLength="500" SkinID="NAME" Width="220px"></asp:TextBox>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 30px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View1" runat="server">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td height="30" style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.png');
                                            background-repeat: repeat-x">
                                            <table cellpadding="5">
                                                <tr>
                                                    <td class="style22">
                                                        <asp:ImageButton ID="imgCloseV1" runat="server" Height="24px" ImageUrl="~/App_Themes/Styles/Images/exit.ico"
                                                            ToolTip="Close Page" Width="24px" OnClick="imgCloseV1_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgAdd1" runat="server" Height="24px" ImageUrl="~/App_Themes/Styles/Images/window_new.png"
                                                            ToolTip="Add Transaction" Width="24px" OnClick="imgAdd1_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgExport" runat="server" Height="24px" ImageUrl="~/App_Themes/Styles/Images/excel.png"
                                                            ToolTip="Download data in excel format" Width="24px" OnClick="imgExport_Click" />
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
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td width="100%">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" style="height: 30px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblSearch" runat="server" CssClass="Label" Text="Search Criteria"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="cboSearch" runat="server" CssClass="Combobox">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="cboCriteria" runat="server" CssClass="Combobox" Width="120px">
                                                            <asp:ListItem Selected="True" Value="Equal to">Equal to</asp:ListItem>
                                                            <asp:ListItem Value="Not equal to">Not equal to</asp:ListItem>
                                                            <asp:ListItem Value="Contains">Contains</asp:ListItem>
                                                            <asp:ListItem Value="Start with">Start with</asp:ListItem>
                                                            <asp:ListItem Value="End with">End with</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="TextBox" ValidationGroup="Search"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/App_Themes/Styles/Images/search.png"
                                                            OnClick="imgSearch_Click" />
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
                                            <asp:GridView ID="GrUser" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                                CaptionAlign="Left" CellPadding="4" CssClass="GridViewStyle" EmptyDataText="There are no items to show in this view."
                                                PageSize="20" ShowFooter="True" OnRowDataBound="GrUser_RowDataBound" DataKeyNames="REFNO"
                                                OnPageIndexChanging="GrUser_PageIndexChanging" OnRowCommand="GrUser_RowCommand"
                                                OnSorting="GrUser_Sorting" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" CommandName="Select" Text="Select" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="BOOTHCODE" HeaderText="STORAGE LOC" SortExpression="VW_BOOTHMASTER" />
                                                    <asp:BoundField DataField="BOOTHDESC" HeaderText="BOOTH DESC" SortExpression="BOOTHDESC" />
                                                    <asp:BoundField DataField="PLANTID" HeaderText="PLANT ID" SortExpression="PLANTID" />
                                                    <asp:BoundField DataField="STORAGELOC" HeaderText="STORAGE LOCATION" SortExpression="STORAGELOC" />
                                                    <asp:BoundField DataField="CREATEDBY" HeaderText="CREATED BY" SortExpression="CREATEDBY" />
                                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
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
            <asp:PostBackTrigger ControlID="imgExport" />
            <asp:PostBackTrigger ControlID="imgSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

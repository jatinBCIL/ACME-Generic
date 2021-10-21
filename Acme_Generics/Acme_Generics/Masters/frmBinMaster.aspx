<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmBinMaster.aspx.cs" Inherits="frmBin_Master" %>

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
                        <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Bin Master"></asp:Label>
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
                                                                                <asp:Label ID="lblItemCode13" runat="server" CssClass="Label" Text="Location Id :"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLocaionId" runat="server" SkinID="NAME" CssClass="TextBox" Width="220px"
                                                                                    MaxLength="500"></asp:TextBox>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:Image ID="Image1" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                                                    ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvPlantnm" runat="server" ControlToValidate="txtLocaionId"
                                                                                    ErrorMessage="Location ID is required!!!" Text="&lt;img src='../App_Themes/Styles/Images/err1.png' title='Location ID is required!!!' /&gt;"
                                                                                    ToolTip="Location ID is required!!!" ValidationGroup="Save"></asp:RequiredFieldValidator>
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
                                                                                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Location Name :"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLocationName" runat="server" SkinID="NAME" CssClass="TextBox"
                                                                                    Width="220px" MaxLength="500"></asp:TextBox>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:Image ID="Image2" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                                                    ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLocaionId"
                                                                                    ErrorMessage="Location name is required!!!" Text="&lt;img src='../App_Themes/Styles/Images/err1.png' title='Location name is required!!!' /&gt;"
                                                                                    ToolTip="Location name is required!!!" ValidationGroup="Save"></asp:RequiredFieldValidator>
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
                                                                                <asp:Label ID="Label18" runat="server" CssClass="Label" Text="Warehouse Type"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddWHType" runat="server" AutoPostBack="True" CssClass="Combobox"
                                                                                    Height="25px" Width="224px">
                                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                                    <asp:ListItem>Import</asp:ListItem>
                                                                                    <asp:ListItem>Export</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:Image ID="Image13" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                                                    ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddWHType"
                                                                                    InitialValue="Select" ErrorMessage="Warehouse type is required!!!" Text="&lt;img src='../App_Themes/Styles/Images/err1.png' title='Warehouse type is required!!!' /&gt;"
                                                                                    ToolTip="Warehouse type is required!!!" ValidationGroup="Save"></asp:RequiredFieldValidator>
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
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" style="height: 10px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                                                                                background-repeat: repeat-x">
                                                                                <asp:Label ID="Label22" runat="server" CssClass="HeadingLabel" Font-Size="15px" Text="&amp;nbsp;Import Excel"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" class="style18">
                                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td class="style21">
                                                                                                    &nbsp;&nbsp;
                                                                                                </td>
                                                                                                <td class="style18">
                                                                                                    <asp:Label ID="lblBrowse" runat="server" CssClass="Label" Text="Browse:"></asp:Label>
                                                                                                </td>
                                                                                                <td class="style18">
                                                                                                    <asp:FileUpload ID="FlUpload" runat="server" />
                                                                                                </td>
                                                                                                <td valign="top" class="style20">
                                                                                                </td>
                                                                                                <td class="style21">
                                                                                                    <asp:Button ID="btnImp" runat="server" CssClass="Button" OnClick="btnImp_Click1"
                                                                                                        Text="Import" Width="60px" />
                                                                                                </td>
                                                                                                <td class="style18">
                                                                                                </td>
                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="btnImp" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" style="height: 10px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                                                                                background-repeat: repeat-x">
                                                                            </td>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </tr>
                                                                    </table>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="width: 50%;" valign="top">
                                                                                <asp:Panel ID="pnlImport" runat="server" ScrollBars="Auto" Height="400px">
                                                                                    <asp:GridView ID="grPlant1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                                        AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" CssClass="style22"
                                                                                        EmptyDataText="There are no items to show in this view." Height="16px" PageSize="10"
                                                                                        ShowFooter="True" Width="900px" OnPageIndexChanging="grPlant1_PageIndexChanging"
                                                                                        OnRowDataBound="grPlant1_RowDataBound">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="USER ID" HeaderText="USER ID" SortExpression="USER ID" />
                                                                                            <asp:BoundField DataField="FIRST NAME" HeaderText="FIRST NAME" SortExpression="FIRST NAME" />
                                                                                            <asp:BoundField DataField="LAST NAME" HeaderText="LAST NAME" SortExpression="LAST NAME" />
                                                                                            <asp:BoundField DataField="EMP ID" HeaderText="EMP ID" SortExpression="EMP ID" />
                                                                                            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
                                                                                            <asp:BoundField DataField="PLANT" HeaderText="PLANT" SortExpression="PLANT" />
                                                                                            <asp:BoundField DataField="DEPARTMENT" HeaderText="DEPARTMENT" SortExpression="DEPARTMENT">
                                                                                                <HeaderStyle Width="120px" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="MODULE" HeaderText="MODULE" SortExpression="MODULE" />
                                                                                            <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
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
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    <asp:Button ID="btnSave" runat="server" CssClass="Button" OnClick="btnSave_Click"
                                                                                        Text="Save" Width="60px" />
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                    <asp:Button ID="btnCancel" runat="server" CssClass="Button" Text="Cancel" Width="60px"
                                                                                        OnClick="btnCancel_Click" />
                                                                                </asp:Panel>
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
                                                    <asp:BoundField DataField="LOCID" HeaderText="LOCATION ID" SortExpression="LOCID" />
                                                    <asp:BoundField DataField="LOCNM" HeaderText="LOCATION NAME" SortExpression="LOCNM" />
                                                    <asp:BoundField DataField="PLANTID" HeaderText="PLANT ID" SortExpression="PLANTID" />
                                                    <asp:BoundField DataField="WH_TYPE" HeaderText="WAREHOUSE TYPE" SortExpression="WH_TYPE" />
                                                    <asp:BoundField DataField="CREATEDBY" HeaderText="CREATED BY" SortExpression="CREATEDBY" />
                                                    <asp:BoundField DataField="REMARK" HeaderText="REMARK" SortExpression="REMARK" />
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmLocationSheet.aspx.cs" Inherits="frmDispensingSheet" %>

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
        .style8
        {
            width: 99px;
        }
        .style9
        {
            width: 98px;
        }
        .style10
        {
            width: 97px;
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
            <div id="dDispSheet">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                                        background-repeat: repeat-x">
                                        <asp:Label ID="Label1" runat="server" CssClass="HeadingLabel" Text="Location Chart"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 120px;">
                                                    <asp:RadioButton ID="rbRM" Text="" runat="server" GroupName="MatType" Checked="true" />
                                                    <asp:Label ID="Label3" Text="RM" runat="server" />
                                                </td>
                                                <td style="width: 120px;">
                                                    <asp:RadioButton ID="rbPM" Text="" runat="server" GroupName="MatType" />
                                                    <asp:Label ID="Label4" Text="PM" runat="server" />
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="text-align: center;">
                                            <tr>
                                                <td style="text-align: center;" class="style10">
                                                    <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Block Name :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBlockName" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                        AutoPostBack="true" Width="200px"></asp:TextBox>
                                                </td>
                                                <asp:AutoCompleteExtender CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted"
                                                    CompletionListItemCssClass="listItem" runat="server" CompletionInterval="100"
                                                    CompletionSetCount="1" EnableCaching="true" ServiceMethod="getBlockNo" ID="AutoCompleteExtender1"
                                                    DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtBlockName"
                                                    MinimumPrefixLength="1" UseContextKey="True">
                                                </asp:AutoCompleteExtender>
                                                <td valign="top">
                                                    <asp:Image ID="Image2" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                        ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBlockName"
                                                        ErrorMessage="Block Name is required!!!" Text="&lt;img src='../App_Themes/Styles/Images/err1.png' title='Block Name is required!!!' /&gt;"
                                                        ToolTip="Block Name is required!!!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="text-align: center;">
                                            <tr>
                                                <td style="text-align: center" class="style9">
                                                    <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Area Name :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAreaName" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                        AutoPostBack="true" Width="200px"></asp:TextBox>
                                                </td>
                                                <asp:AutoCompleteExtender CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted"
                                                    CompletionListItemCssClass="listItem" runat="server" CompletionInterval="100"
                                                    CompletionSetCount="1" EnableCaching="true" ServiceMethod="getAreaName" ID="AutoCompleteExtender2"
                                                    DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtAreaName"
                                                    MinimumPrefixLength="1" UseContextKey="True">
                                                </asp:AutoCompleteExtender>
                                                <td valign="top">
                                                    <asp:Image ID="Image1" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                        ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAreaName"
                                                        ErrorMessage="Area Name is required!!!" Text="&lt;img src='../App_Themes/Styles/Images/err1.png' title='Area Name is required!!!' /&gt;"
                                                        ToolTip="Area Name is required!!!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <tr>
                                        <td>
                                            <table style="text-align: center;">
                                                <tr>
                                                    <td style="text-align: center" class="style8">
                                                        <asp:Label ID="lblDocumentNo" runat="server" CssClass="Label" Text="Bin Location :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBinCode" runat="server" AutoPostBack="true" CssClass="TextBox"
                                                            Height="25px" OnTextChanged="txtArNo_TextChanged" SkinID="NAME" Width="200px" autocomplete="off" ></asp:TextBox>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Image ID="Image3" runat="server" Height="10px" Width="10px" ToolTip="Mandatory Field!!!"
                                                            ImageUrl="../App_Themes/Styles/Images/img_mand.png" />
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBinCode"
                                                            ErrorMessage="Location is required!!!" Text="&lt;img src='../App_Themes/Styles/Images/err1.png' title='Location is required!!!' /&gt;"
                                                            ToolTip="Location is required!!!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <%-- <asp:AutoCompleteExtender ID="aceArNO" runat="server" CompletionInterval="100" CompletionListCssClass="completionList"
                                                        CompletionListHighlightedItemCssClass="itemHighlighted" CompletionListItemCssClass="listItem"
                                                        CompletionSetCount="1" DelimiterCharacters="" EnableCaching="true" Enabled="True"
                                                        MinimumPrefixLength="1" ServiceMethod="getArNo" ServicePath="" TargetControlID="txtBinCode"
                                                        UseContextKey="True">
                                                    </asp:AutoCompleteExtender>--%>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 100%; text-align: Left">
                                        <asp:Label Text="" ID="lblMessage" runat="server" />
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
                                        <asp:Button ID="btnPrint" runat="server" Text="Generate Report" CssClass="Button"
                                            Width="110px" OnClick="Button1_Click" ValidationGroup="Save" />
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
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPrint" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

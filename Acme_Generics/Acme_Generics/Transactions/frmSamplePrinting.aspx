<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmSamplePrinting.aspx.cs" Inherits="frmGrn_Printing" %>

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
        .style20
        {
            height: 30px;
        }
        .style28
        {
            width: 282px;
        }
        .style29
        {
            width: 282px;
            height: 30px;
        }
        .style32
        {
            width: 269px;
        }
        .style33
        {
            height: 30px;
            width: 269px;
        }
        .style34
        {
            width: 287px;
        }
        .style35
        {
            width: 287px;
            height: 30px;
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
                        <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;User Master"></asp:Label>
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
                                            <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Sample label Printing"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="5" style="width: 680px;">
                                                <tr>
                                                    <td class="style32">
                                                        <asp:Label ID="lblARNo" runat="server" CssClass="Label" Text="Inward No. :"></asp:Label>
                                                    </td>
                                                    <td class="style34">
                                                        <asp:TextBox ID="txtARNo" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                            Width="220px" AutoComplete="off"  ></asp:TextBox>
                                                        <asp:AutoCompleteExtender CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted"
                                                            CompletionListItemCssClass="listItem" runat="server" CompletionInterval="100"
                                                            CompletionSetCount="1" EnableCaching="true" ServiceMethod="GetARNo" ID="AutoCompleteExtender1"
                                                            DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtARNo"
                                                            MinimumPrefixLength="1" UseContextKey="True">
                                                        </asp:AutoCompleteExtender>
                                                        <asp:Image ID="Image1" runat="server" Height="10px" ImageUrl="../App_Themes/Styles/Images/img_mand.png"
                                                            ToolTip="Mandatory Field!!!" Width="10px" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtARNo"
                                                            ErrorMessage="RequiredFieldValidator" ToolTip="AR No. is Required" ValidationGroup="Get"><img 
                                                                                src="../App_Themes/Styles/Images/err1.png" 
                                                                                title="AR No. is required!!!" /></asp:RequiredFieldValidator>
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
                                                <tr>
                                                    <td class="style32">
                                                        <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Material code :"></asp:Label>
                                                    </td>
                                                    <td class="style34">
                                                        <asp:Label ID="lblMaterialCode" runat="server" CssClass="Label" Text=""></asp:Label>
                                                    </td>
                                                    <td valign="top">
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style32">
                                                        <asp:Label ID="Label4" runat="server" CssClass="Label" Text="Material Name"></asp:Label>
                                                    </td>
                                                    <td class="style34">
                                                        <asp:Label ID="lblMaterialDesc" runat="server" CssClass="Label" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style32">
                                                        <asp:Label ID="Label19" runat="server" CssClass="Label" Text="Batch Name"></asp:Label>
                                                    </td>
                                                    <td class="style34">
                                                        <asp:Label ID="lblBatchNo" runat="server" CssClass="Label" Text=""></asp:Label>
                                                    </td>
                                                    <td valign="top">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style32">
                                                        <asp:Label ID="Label1" runat="server" CssClass="Label" Text="GRN No."></asp:Label>
                                                    </td>
                                                    <td class="style34">
                                                        <asp:Label ID="lblGRNNo" runat="server" CssClass="Label" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style32">
                                                        <asp:Label ID="Label2" runat="server" CssClass="Label" Text="GRN Date"></asp:Label>
                                                    </td>
                                                    <td class="style34">
                                                        <asp:Label ID="lblGRNDate" runat="server" CssClass="Label" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style32">
                                                        <asp:RadioButton ID="rbRM" Text="" runat="server" GroupName="MatType" 
                                                            AutoPostBack="True" oncheckedchanged="rbRM_CheckedChanged"  />
                                                        <asp:Label ID="Label6"  CssClass="Label" Text="100% Labeling" runat="server" />
                                                    </td>
                                                    <td class="style34">
                                                        <asp:RadioButton ID="rbPM" Text="" runat="server" GroupName="MatType" 
                                                            AutoPostBack="True" oncheckedchanged="rbPM_CheckedChanged" />
                                                        <asp:Label ID="Label7"  CssClass="Label"  Text="Non-100%" runat="server" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trCont1">
                                                    <td class="style33">
                                                        <asp:Label ID="Label5" runat="server" CssClass="Label" 
                                                            Text="Container to be sampled:"></asp:Label>
                                                    </td>
                                                    <td class="style35">
                                                        <asp:TextBox ID="txtNoContainer" runat="server" CssClass="TextBox" Height="25px"
                                                            SkinID="NAME" Width="220px" autocomplete="off" ></asp:TextBox>
                                                    </td>
                                                    <td class="style20">
                                                      <asp:Label ID="Label8" runat="server" CssClass="Label" 
                                                            Text="Eg: 1,5,7"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trCont">
                                                    <td class="style33">
                                                        <asp:Label ID="Label10" runat="server" CssClass="Label" Text="Total No. of Container:"></asp:Label>
                                                    </td>
                                                    <td class="style35">
                                                        <asp:Label ID="lblTotalContainers" runat="server" CssClass="Label" Text=""></asp:Label>
                                                    </td>
                                                    <td class="style20">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style32">
                                                        <asp:Label ID="lblPrintername" runat="server" CssClass="Label" Text="Printer&amp;nbsp;Name:"></asp:Label>
                                                    </td>
                                                    <td class="style34">
                                                        <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="Combobox" Height="26px" Width="220px">
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
                                                            ValidationGroup="PrintLabel" OnClick="btnPrint_Click" />
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmFGLabelPrinting.aspx.cs" Inherits="frmGrn_Printing" %>

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
                <tr>
                    <td height="30" style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                        background-repeat: repeat-x">
                        <asp:Label ID="Label8" runat="server" CssClass="HeadingLabel" Text="FG Label Printing"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="5">
                            <tr>
                                <td>
                                    <table width="100%" style="border: 1px solid black">
                                        <tr valign="top">
                                            <td style="width: 40%;">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label14" runat="server" CssClass="Label" Text="Batch No. :"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBatchNo" runat="server" SkinID="NAME" CssClass="TextBox" Width="220px"
                                                                MaxLength="500"></asp:TextBox>
                                                        </td>
                                                        <td valign="top">
                                                            <asp:Button ID="btnGet" runat="server" CssClass="Button" Text="Get" Width="75px"
                                                                ValidationGroup="Get" OnClick="btnGet_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvPlantcode" runat="server" ControlToValidate="txtBatchNo"
                                                                ErrorMessage="Batch No. is required!!!" Text="&lt;img src='../App_Themes/Styles/Images/err1.png' title='Batch No.e is required!!!' /&gt;"
                                                                ToolTip="Batch No. is required!!!" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblItemCode13" runat="server" CssClass="Label" Text="Product Code :"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblProductCode" runat="server" CssClass="Label" Text=""></asp:Label>
                                                        </td>
                                                        <td valign="top">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Product Name :"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblProdName" runat="server" CssClass="Label" Text=""></asp:Label>
                                                        </td>
                                                        <td valign="top">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Product Batch:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblProdBatch" runat="server" CssClass="Label" Text=""></asp:Label>
                                                        </td>
                                                        <td valign="top">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblRemark" runat="server" CssClass="Label" Text="Pack Qty :"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPackQty" runat="server" CssClass="Label" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" CssClass="Label" Text="UOM :"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUOM" runat="server" CssClass="Label" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" CssClass="Label" Text="No. of container Packed :"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNoOfContainers" runat="server" CssClass="Label" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Scan weighing balance code :"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtWeighingBalance" runat="server" SkinID="NAME" CssClass="TextBox"
                                                                Width="220px" MaxLength="500"></asp:TextBox>
                                                        </td>
                                                        <td valign="top">
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Gross Wt.:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtGrossWt" runat="server" SkinID="NAME" CssClass="TextBox" Width="220px"
                                                                MaxLength="500"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="Label7" runat="server" CssClass="Label" Text="UOM:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblWeighingUom" runat="server" CssClass="Label" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblPrintername" runat="server" CssClass="Label" Text="Printer&amp;nbsp;Name:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="Combobox" Width="220px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="style18">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="Select" runat="server"
                                                                ControlToValidate="ddlPrinterName" ErrorMessage="RequiredFieldValidator" ToolTip="Printer Name is required!!!"
                                                                ValidationGroup="PrintLabel"><img src="../App_Themes/Styles/Images/err1.png" 
                                                                                          title="Printer Name is required!!!" /></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td valign="top">
                                                        </td>
                                                        <td>
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGet" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmDispensingSheet.aspx.cs" Inherits="frmDispensingSheet" %>

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
                                        <asp:Label ID="Label1" runat="server" CssClass="HeadingLabel" Text="Dispensing Sheet"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="text-align: center;">
                                            <tr>
                                                <td style="width: 120px; text-align: center">
                                                    <asp:Label ID="lblDocumentNo" runat="server" CssClass="Label" Text="Product Batch No:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtProcessOrderNo" runat="server" CssClass="TextBox" Height="25px"
                                                        SkinID="NAME" Width="220px" ></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Image ID="Image1" runat="server" Height="10px" ImageUrl="../App_Themes/Styles/Images/img_mand.png"
                                                        ToolTip="Mandatory Field!!!" Width="10px" AutoComplete="off" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProcessOrderNo"
                                                        ErrorMessage="RequiredFieldValidator" ToolTip="Process order no. is Required"
                                                        ValidationGroup="Get"><img 
                                                                                src="../App_Themes/Styles/Images/err1.png" 
                                                                                title="Process order no. is required!!!" /></asp:RequiredFieldValidator>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Button ID="btnGet" runat="server" CssClass="Button" Text="Get" Width="75px"
                                                        ValidationGroup="Get" OnClick="btnGet_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" CssClass="Label" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="text-align: center;">
                                            <tr>
                                                <td style="width: 80px; text-align: center">
                                                    <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Stage:" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtStage" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                        Width="150px" autocomplete="off " Visible="false"></asp:TextBox>
                                                </td>
                                                <td style="width: 20%">
                                                </td>
                                                <td style="width: 80px; text-align: center">
                                                    <asp:Label ID="Label4" runat="server" CssClass="Label" Text="SlipNo:" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSlipNo" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                        Width="150px" autocomplete="off" Visible="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 80px; text-align: center">
                                                    <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Packing:" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPacking" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                        Width="150px" autocomplete="off" Visible="false"></asp:TextBox>
                                                </td>
                                                <td style="width: 20%">
                                                </td>
                                                <td style="width: 80px; text-align: center">
                                                    <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Date:" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                                                        Width="150px" autocomplete="off" Visible="false"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtShelf_CalendarExtender" runat="server" Format="MM/dd/yyyy"
                                                        Enabled="True" TargetControlID="txtDate">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 100%; text-align: center">
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
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="Button" Width="75px"
                                            OnClick="Button1_Click" />
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
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGet" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

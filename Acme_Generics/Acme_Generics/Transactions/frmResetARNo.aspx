<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true"
    CodeFile="frmResetARNo.aspx.cs" Inherits="frmResetARNo" %>

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
        .auto-style3 {
        width: 108px;
    }
    .auto-style4 {
        width: 110px;
    }
        .auto-style5 {
            border: 1px solid #c0c0c0;
            font-family: Arial;
            font-size: 12px;
            color: Black;
            margin-left: 7px;
            padding-left: 2px;
            padding-right: 2px;
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
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="height: 30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');
                                        background-repeat: repeat-x">
                                        <asp:Label ID="Label1" runat="server" CssClass="HeadingLabel" Text="Reset AR Number"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                     
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="text-align: center;">
                                            <tr>
                                                <td style="text-align: center;" class="auto-style3">
                                                    <asp:Label ID="Label5" runat="server" CssClass="Label" Text="Bar Code No."></asp:Label>
                                                </td>
                                                <td style="margin-left: 10px">
                                                    <asp:TextBox ID="txtBarCodeNumber" runat="server" CssClass="auto-style5"  Height="25px" 
                                                        AutoPostBack="true" Width="215px"></asp:TextBox>
                                                </td>
                                              
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="text-align: center;">
                                            <tr>
                                                <td style="text-align: center" class="auto-style4">
                                                    <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Old AR Number"></asp:Label>
                                                </td>
                                                <td style="margin-left: 2px" >
                                                    <asp:TextBox ID="txtOldArNumber" runat="server" CssClass="TextBox" Height="25px" 
                                                        AutoPostBack="true" Width="215px"></asp:TextBox>
                                                </td>
                                            
                                            </tr>
                                        </table>
                                    </td>
                                    <tr>
                                        <td>
                                            <table style="text-align: center;">
                                                <tr>
                                                    <td style="text-align: center" class="style8">
                                                        <asp:Label ID="lblDocumentNo" runat="server" CssClass="Label" Text="New Ar Number"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNewArNumber" runat="server" AutoPostBack="true" CssClass="TextBox"
                                                            Height="25px"  Width="215px" autocomplete="off" ></asp:TextBox>
                                                    </td>
                                                  
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
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Button"
                                            Width="110px" OnClick="Save_Click" ValidationGroup="Save" />
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
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

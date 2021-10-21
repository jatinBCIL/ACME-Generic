<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPicking.aspx.cs" Inherits="frmPicking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MTS | Version 1.0</title>
    <link href="../../cdn/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="../../cdn/jquery.min.js"></script>
    <script src="../../cdn/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../cdn/jquery.min.js"></script>
    <script type="text/javascript" src="../../cdn/bootstrap.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style type="text/css">
        /*AutoComplete flyout */
        .completionList
        {
            border: solid 1px #444444;
            margin: 0px;
            padding: 2px;
            height: 100px;
            overflow: auto;
            background-color: #FFFFFF;
        }
        
        .listItem
        {
            color: #1C1C1C;
        }
        
        .itemHighlighted
        {
            background-color: #ffc0c0;
        }
    </style>
    <style type="text/css">
        .Label
        {
            font-family: Calibri;
            font-size: 9pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }
        
        .InfoLabel
        {
            font-family: Calibri;
            font-size: 8pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }
        
        .QtyLabel
        {
            font-family: Calibri;
            font-size: 8pt;
            color: White;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }
        .DropDownList
        {
            font-family: Calibri;
            font-size: 9pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 30px;
            text-align: left;
        }
        
        .Button
        {
            border-color: #006699;
            border-width: 0px;
            background-image: url('../../App_Themes/Styles/Images/ButtonOut.png');
            font-family: Arial;
            font-size: 12px;
            color: #FFFFFF;
            width: 120px;
            height: 18px;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            cursor: inherit;
        }
        
        .TextBox
        {
            border: 1px solid #c0c0c0;
            font-family: Calibri;
            font-size: 9pt;
            color: Black;
            margin-left: 0px;
            width: 350px;
            height: 30px;
            padding-left: 2px;
            padding-right: 2px;
        }
        
        .style1
        {
            height: 22px;
        }
        .style3
        {
            height: 40px;
        }
    </style>
</head>
<body>
    <div class="container-fluid">
        <form role="form" class="form-horizontal" id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table class="table" style="width: 100%">
                    <tr>
                        <td class="style3">
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 100%; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                                            background-repeat: repeat-x;" class="style1">
                                            <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Picking"
                                                ForeColor="White" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td colspan="2" style="height: 30px; width: 2%; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG');
                                            background-repeat: repeat-x">
                                            <asp:Button ID="btnimgClose" class="btn-danger" runat="server" Text="X" Width="30px"
                                                Height="25px" OnClick="btnimgClose_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="form-group">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 46%">
                                            <asp:Label ID="Label7" CssClass="Label" runat="server" Text="Picklist No.:"></asp:Label>
                                        </td>
                                        <td style="width: 42%">
                                            <asp:TextBox ID="txtPicklistNo" CssClass="TextBox" class="form-control" runat="server"
                                                autocomplete="off" Width="100%"></asp:TextBox>
                                            <asp:AutoCompleteExtender CompletionListCssClass="completionList" CompletionListHighlightedItemCssClass="itemHighlighted"
                                                CompletionListItemCssClass="listItem" runat="server" CompletionInterval="100"
                                                CompletionSetCount="1" EnableCaching="true" ServiceMethod="GetPicklistNo" ID="AutoCompleteExtender3"
                                                DelimiterCharacters="" Enabled="True" ServicePath="" TargetControlID="txtPicklistNo"
                                                MinimumPrefixLength="1" UseContextKey="True">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                        <td style="width: 12%; text-align: center">
                                            &nbsp;
                                            <asp:Button ID="btnPick" runat="server" class="Button" Text="Go" Height="30px" Width="80%"
                                                OnClick="btnPick_Click" />
                                        </td>
                                        <td style="width: 2%">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 45%">
                                            <asp:Label ID="Label9" CssClass="Label" runat="server" Text="Material Code :"></asp:Label>
                                        </td>
                                        <td style="width: 52%">
                                            <asp:DropDownList Width="80%" AutoPostBack="true" ID="ddlMaterialCode" class="form-control"
                                                CssClass="DropDownList" runat="server" OnSelectedIndexChanged="ddlMaterialCode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <%--                                      <td style="width: 2%">
                                            <asp:RequiredFieldValidator ID="rvPWONo" runat="server" ControlToValidate="ddlMaterialCode"
                                                ErrorMessage="Select Material code" ToolTip="Select Material code" ValidationGroup="SAVE"><img
                                        src="../../App_Themes/Styles/Images/err1.png" title="Select Material code!!!" /></asp:RequiredFieldValidator>
                                        </td>--%>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 45%">
                                            <asp:Label ID="Label2" CssClass="Label" runat="server" Text="AR No :"></asp:Label>
                                        </td>
                                        <td style="width: 52%">
                                            <asp:DropDownList Width="80%" AutoPostBack="true" ID="ddlMatBatch" class="form-control"
                                                runat="server" CssClass="DropDownList" OnSelectedIndexChanged="ddlMatBatch_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 45%">
                                            <asp:Label ID="Label3" CssClass="Label" runat="server" Text="Material Desc"></asp:Label>
                                        </td>
                                        <td style="width: 52%">
                                            <asp:Label ID="lblMaterialDesc" CssClass="Label" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group" runat="server" visible="false">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 45%">
                                            <asp:Label ID="Label10" CssClass="Label" runat="server" Text="AR No."></asp:Label>
                                        </td>
                                        <td style="width: 52%">
                                            <asp:Label ID="lblARNo" CssClass="Label" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%; background-color:#3588FD">
                                    <tr>
                                        <td style="width: 25%">
                                            <asp:Label ID="Label4" CssClass="QtyLabel" runat="server" Text="T.Qty:"></asp:Label>
                                        </td>
                                        <td style="width: 25%">
                                            <asp:Label ID="LblQty" CssClass="QtyLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 25%">
                                            <asp:Label ID="Label5" CssClass="QtyLabel" runat="server" Text="S.Qty:"></asp:Label>
                                        </td>
                                        <td style="width: 25%">
                                            <asp:Label ID="lblRequiredQty" CssClass="QtyLabel" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 38%">
                                            <asp:Label ID="Label13" CssClass="Label" runat="server" Text="Suggested Bin"></asp:Label>
                                        </td>
                                        <%--<td style="width: 1%">
                                            <asp:DropDownList Width="3%" ID="ddlSuggestedBin" class="form-control" AutoPostBack="true"
                                                runat="server" OnSelectedIndexChanged="ddlSuggestedBin_SelectedIndexChanged"
                                                Visible="false">
                                            </asp:DropDownList>
                                        </td>--%>
                                        <td style="width: 49%">
                                            <asp:Label ID="lblSBin" CssClass="Label" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 2%">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 45%">
                                            <asp:Label ID="Label14" CssClass="Label" runat="server" Text="Scan Bin"></asp:Label>
                                        </td>
                                        <td style="width: 52%">
                                            <asp:TextBox ID="txtBinCode" CssClass="TextBox" class="form-control" runat="server"
                                                autocomplete="off" Width="80%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                          
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 45%">
                                            <asp:Label ID="Label15" CssClass="Label" runat="server" Text="Scan Material"></asp:Label>
                                        </td>
                                        <td style="width: 52%">
                                            <asp:TextBox ID="txtMaterialBarCode" CssClass="TextBox" class="form-control" runat="server"
                                                autocomplete="off" Width="80%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 43%">
                                            <asp:Label ID="Label1" CssClass="Label" runat="server" Text="No of containers :"></asp:Label>
                                        </td>
                                        <td style="width: 48%">
                                            <asp:Label ID="lblNoofContainers" CssClass="Label" runat="server" Text="0"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="width: 43%; text-align: center">
                                            <asp:Label ID="lblMessage" CssClass="Label" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-group">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center; width: 50%">
                                            <asp:Button ID="btnSave" runat="server"  class="btn-primary" CssClass="Button" ValidationGroup="SAVE"
                                                Text="Save" Height="30px" Width="80%" OnClick="btnSave_Click" Visible="false" />
                                        </td>
                                        <td style="text-align: center; width: 50%">
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnClose" runat="server" class="btn-primary"  CssClass="Button" Text="Close" Height="30px"
                                                CausesValidation="false" Width="80%" OnClick="btnClose_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Button ID="btnScanBarcode" runat="server" float="left" class="btn-primary" Text="Scan Barcode"
                                Height="30px" Width="49%" CssClass="hidden" OnClick="btnScanBarcode_Click" ValidationGroup="SCAN" />
                            <asp:Button ID="btnScanBin" runat="server" float="left" class="btn-primary" Text="Scan Bin"
                                Height="30px" Width="49%" CssClass="hidden" OnClick="btnScanBin_Click" />
                            <asp:Button ID="btnPickList" runat="server" float="left" class="btn-primary" Text="Scan Bin"
                                Height="30px" Width="49%" CssClass="hidden" OnClick="btnPickList_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        </form>
    </div>
</body>
</html>

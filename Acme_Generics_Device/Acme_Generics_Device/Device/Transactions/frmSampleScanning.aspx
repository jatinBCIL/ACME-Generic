<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmSampleScanning.aspx.cs"
    Inherits="frm_FOR_Allocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MTS | Version 1.0</title>
    <link href="../../cdn/bootstrap.min.css" rel="stylesheet" type="text/css">
    <script src="../../cdn/jquery.min.js"></script>
    <script src="../../cdn/bootstrap.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style type="text/css">
        .Label {
            font-family: Calibri;
            font-size: 9pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }

        .InfoLabel {
            font-family: Calibri;
            font-size: 8pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 22px;
            text-align: left;
        }

        .DropDownList {
            font-family: Calibri;
            font-size: 9pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 100px;
            height: 30px;
            text-align: left;
        }

        .Button {
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

        .MiniDropDownList {
            font-family: Calibri;
            font-size: 9pt;
            color: Black;
            padding-left: 5px;
            padding-right: 5px;
            width: 40px;
            height: 20px;
            text-align: left;
        }

        .TextBox {
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

        .style1 {
            height: 22px;
        }

        .style3 {
            height: 40px;
        }
    </style>
</head>
<body style="background-image: none; background-color: White; margin: 0; font-family: Arial; font-size: 12pt;">
    <div class="container-fluid">
        <form role="form" id="form1" method="post" runat="server" class="form-horizontal">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <table class="table">
                <tr>
                    <td style="height: 25px; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG'); background-repeat: repeat-x; width: 100%;">
                        <asp:Label ID="Label35" runat="server" CssClass="HeadingLabel" Text="&amp;nbsp;Sample Scanning"
                            ForeColor="White" Font-Bold="True"></asp:Label>
                    </td>
                    <td colsm="2" style="height: 30px; background-image: url('../../App_Themes/Styles/Images/Form_Title.JPG'); background-repeat: repeat-x">
                        <asp:Button ID="Button1" class="btn-danger" runat="server" Text="X" Width="30px"
                            Height="25px" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="form-group">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 50%;">
                                        <asp:Label ID="lblARNo" runat="server" CssClass="InfoLabel" Text="Sample Barcode :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSampleBarcode" runat="server" CssClass="TextBox" Height="25px"
                                            SkinID="NAME" Width="190px" autocomplete="off"></asp:TextBox>
                                        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" CssClass="hidden"
                                            Height="30px" Width="38px" ValidationGroup="Scan" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="form-group">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 20%;">
                                        <asp:Label ID="Label3" runat="server" CssClass="InfoLabel" Text="Material code :"></asp:Label>
                                    </td>
                                    <td style="width: 30%;">
                                        <asp:Label ID="lblMaterialCode" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 20%;">
                                        <asp:Label ID="Label19" runat="server" CssClass="InfoLabel" Text="Inward No."></asp:Label>
                                    </td>
                                    <td style="width: 30%;">
                                        <asp:Label ID="lblBatchNo" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="form-group">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 50%;">
                                        <asp:Label ID="Label1" runat="server" CssClass="InfoLabel" Text="Material Name"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMaterialDesc" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="form-group">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 50%;">
                                        <asp:Label ID="Label2" runat="server" CssClass="InfoLabel" Text="GRN No./Date"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblGRNNo" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="form-group">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 50%;">
                                        <asp:Label ID="Label10" runat="server" CssClass="InfoLabel" Text="Total No. of Container:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalContainers" runat="server" CssClass="InfoLabel" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="form-group">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 50%;">
                                        <asp:Label ID="lblMaterialBarcode" runat="server" CssClass="InfoLabel" Text="Material Barcode:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMaterialBarcode" runat="server" CssClass="TextBox" Height="25px"
                                            SkinID="NAME" Width="190px" autocomplete="off"></asp:TextBox>
                                        <asp:Button ID="btnScanMaterial" runat="server" Text="Go" OnClick="btnScanMaterial_Click"
                                            CssClass="hidden" Height="30px" Width="38px" ValidationGroup="Scan" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="form-group">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 25%;">
                                        <asp:Label ID="Label4" runat="server" CssClass="InfoLabel" Text="Sample UOM:"></asp:Label>
                                    </td>
                                    <td style="width: 25%;">
                                        <asp:DropDownList ID="ddlUOM" CssClass="MiniDropDownList" runat="server"
                                            Width="110px" OnSelectedIndexChanged="ddlUOM_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>KG</asp:ListItem>
                                            <asp:ListItem>GM</asp:ListItem>
                                            <asp:ListItem>NOS</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 50%;">
                                        <asp:CheckBox ID="chkManual" Text="" runat="server" Checked="false"
                                            AutoPostBack="true" OnCheckedChanged="chkManual_CheckedChanged" />
                                        <asp:Label ID="Label7" runat="server" CssClass="InfoLabel" Text="Manual Weight"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
    </div>
    <div class="form-group">
        <table style="width: 100%;">
            <tr>
                <td style="width: 50%;">
                    <asp:Label ID="Label6" runat="server" CssClass="InfoLabel" Text="Scan Balance:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbalance" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                        Width="190px" autocomplete="off"></asp:TextBox>
                    <asp:Button ID="btnBalance" runat="server" Text="Go"
                        CssClass="hidden" Height="30px" Width="38px" ValidationGroup="Scan" OnClick="btnBalance_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="form-group">
        <table style="width: 100%;">
            <tr>
                <td style="width: 50%;">
                    <asp:Label ID="Label5" runat="server" CssClass="InfoLabel" Text="Cont Wt. :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSQty" runat="server" CssClass="TextBox" Height="25px"
                        Width="190px" autocomplete="off"></asp:TextBox>
                    <asp:CheckBox ID="chkCont" Text="Container Wt" runat="server" Checked="false"
                        AutoPostBack="true" />
                    <%--<asp:Button ID="Button3" runat="server" Text="Go" OnClick="btnScanMaterial_Click"
                        CssClass="hidden" Height="30px" Width="38px" ValidationGroup="Scan" />--%>
                </td>
            </tr>
            <tr>
                <td style="width: 50%;">
                    <asp:Label ID="Label8" runat="server" CssClass="InfoLabel" Text="Composite Wt. :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCompWt" runat="server" CssClass="TextBox" Height="25px"
                        Width="190px" autocomplete="off"></asp:TextBox>
                    <asp:CheckBox ID="chkCompWt" Text="Composite Wt" runat="server" Checked="false"
                        AutoPostBack="true" />
                    <%--<asp:Button ID="Button2" runat="server" Text="Go" OnClick="btnScanMaterial_Click"
                        CssClass="hidden" Height="30px" Width="38px" ValidationGroup="Scan" />--%>
                </td>
            </tr>
            <tr>
                <td style="width: 50%;">
                    <asp:Label ID="Label9" runat="server" CssClass="InfoLabel" Text="MLT Wt. :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMLTWt" runat="server" CssClass="TextBox" Height="25px" SkinID="NAME"
                        Width="190px" autocomplete="off"></asp:TextBox>
                    <asp:CheckBox ID="chkMLTWt" Text="MLT Wt" runat="server" Checked="false"
                        AutoPostBack="true" />
                    <%--<asp:Button ID="Button4" runat="server" Text="Go" OnClick="btnScanMaterial_Click"
                        CssClass="hidden" Height="30px" Width="38px" ValidationGroup="Scan" />--%>
                </td>
            </tr>
        </table>
    </div>
    <div class="form-group">
        <table style="width: 100%; text-align: center">
            <tr>
                <td>
                    <asp:Label Text="" ID="lblMessage" CssClass="InfoLabel" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div class="form-group">
        <table style="width: 100%;">
            <tr>
                <td style="width: 50%;">
                    <asp:Label ID="Label11" runat="server" CssClass="InfoLabel" Text="Select Printer :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID ="cboPrinter" runat="server" Width="250px" CssClass="DropDownList"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>

                </td>
            </tr>
        </table>
        <table style="width: 100%; text-align: center">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnClose" runat="server" CssClass="Button" Text="Close" Width="80%"
                        Height="30px" float="left" OnClick="btnClose_Click" />
                </td>
                <td style="text-align: center">
                    <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="Save" Width="80%"
                        Height="30px" float="left" ValidationGroup="Scan" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    </td> </tr> </table> </form> </div>
</body>
</html>

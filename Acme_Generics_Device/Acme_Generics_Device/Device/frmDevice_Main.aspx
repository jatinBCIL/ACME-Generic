<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmDevice_Main.aspx.cs" Inherits="Device_Main" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../cdn/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../cdn/jquery.min.js" type="text/javascript"></script>
    <script src="../cdn/bootstrap.min.js" type="text/javascript"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style type="text/css">
        .style1 {
            height: 23px;
        }
    </style>
</head>
<body style="background-image: none; background-color: White; margin: 0; font-family: Arial; font-size: 12pt">
    <div class="container-fluid">
        <form id="form1" runat="server" class="form-group">
            <div class="row">
                <table width="100%" cellspacing="1px">
                    <tr class="alert alert-primary" style="">
                        <td style="background-image: url('../App_Themes/Styles/Images/Form_Title.JPG'); background-repeat: repeat-x; height: 45px"
                            colspan="2" class="style1" bgcolor="#7F65A8">
                            <span style="color: white; height: 30px">&nbsp;&nbsp;&nbsp; Menu</span>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="row">
                <div class="panel-group">
                    <div class="panel panel-default">
                        <!--Process Order-->
                        <asp:HyperLink ID="A401" runat="server" data-toggle="collapse" class="list-group-item"
                            Style="background-color: #2466a8; color: white" href="#processOrder0" Visible="False">Quality</asp:HyperLink>
                        <div id="processOrder0" class="panel-collapse collapse">
                            <asp:HyperLink runat="server" ID="A8011" Style="background-color: #006666; color: white"
                                class="list-group-item" Visible="true" NavigateUrl="~/Device/Transactions/frmSampleScanning.aspx">Sampling</asp:HyperLink>
                        </div>
                    </div>
                    <!--Resevation-->
                    <asp:HyperLink ID="A402" runat="server" data-toggle="collapse" class="list-group-item"
                        Style="background-color: #2466a8; color: white" href="#resevation0" Visible="False">Allocation</asp:HyperLink>
                    <div id="resevation0" class="panel-collapse collapse">
                        <asp:HyperLink runat="server" ID="A8041" Style="background-color: #006666; color: white"
                            class="list-group-item" Visible="true" NavigateUrl="~/Device/Transactions/frmAllocation.aspx">
                        Material Allocation</asp:HyperLink>
                        <asp:HyperLink runat="server" ID="A8042" Visible="true" NavigateUrl="~/Device/Transactions/frmLocationTransfer.aspx"
                            Style="background-color: #006666; color: white" class="list-group-item">Location Transfer </asp:HyperLink>
                        <%--<div class="panel-footer">Panel Footer</div>--%>
                        <!--                    <div class="panel-footer" style="background-color: #2466a8; color: white">Reservation End</div>-->
                    </div>
                    <div class="panel panel-default">
                        <asp:HyperLink ID="A403" runat="server" data-toggle="collapse" class="list-group-item"
                            Style="background-color: #2466a8; color: white" Visible="False" href="#Div1">Picking</asp:HyperLink>
                        <div id="Div1" class="panel-collapse collapse">
                            <asp:HyperLink runat="server" ID="HyperLink3" Style="background-color: #006666; color: white"
                                class="list-group-item" Visible="true" NavigateUrl="~/Device/Transactions/frmPicking.aspx">Picking</asp:HyperLink>
                            <asp:HyperLink runat="server" ID="HyperLink4" Style="background-color: #006666; color: white"
                                class="list-group-item" Visible="true" NavigateUrl="~/Device/Transactions/frmReversePicking.aspx">Reverse Picking</asp:HyperLink>
                        </div>
                    </div>
                    <asp:HyperLink ID="A404" runat="server" class="list-group-item" Style="background-color: #2466a8; color: white; top: 0px; left: 0px;"
                        Visible="False" NavigateUrl="~/Device/Transactions/frmDispensing.aspx">Dispensing</asp:HyperLink>
                    <asp:HyperLink ID="A405" runat="server" class="list-group-item" Style="background-color: #2466a8; color: white; top: 0px; left: 0px;"
                        Visible="False" NavigateUrl="~/Device/Transactions/frmStockAdjustment.aspx">Stock Adjustment</asp:HyperLink>
                    <asp:HyperLink ID="A406" runat="server" class="list-group-item" Style="background-color: #2466a8; color: white"
                        Visible="False" NavigateUrl="~/Device/Production/frmMaterialReturn.aspx">MRN Verify</asp:HyperLink>
                    <div class="panel panel-default">
                        <asp:HyperLink ID="A407" runat="server" data-toggle="collapse" class="list-group-item"
                            Style="background-color: #2466a8; color: white" Visible="False" href="#Div2">Display</asp:HyperLink>
                        <div id="Div2" class="panel-collapse collapse">
                            <asp:HyperLink ID="A4071" runat="server" class="list-group-item" Style="background-color: #006666; color: white"
                             NavigateUrl="~/Device/Transactions/frmStatusDisplay.aspx">Display Status</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink1" runat="server" class="list-group-item" Style="background-color: #006666; color: white"
                             NavigateUrl="~/Device/Transactions/frmRackDisplay.aspx">Rack Details</asp:HyperLink>
                        </div>
                    </div>
                    <asp:Button ID="btnLogout" Style="background-color: #990033; width: 100%; text-align: left; color: white"
                        class="list-group-item" runat="server" Text="Log Out" OnClick="btnLogout_Click" />
                    <div id="logOut0" class="panel-collapse collapse">
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>

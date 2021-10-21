<%@ Page Title="MTS -Home " Language="C#" MasterPageFile="~/Modules/MasterPage.master" AutoEventWireup="true" CodeFile="frmMain.aspx.cs" Inherits="frmMain" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Styles/Style_Controls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Style_Design.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Style_Grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
         <table width="100%" cellpadding="0" cellspacing="0" style="visibility: hidden">
           <tr>
                    <td style="height:30px; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG'); background-repeat: repeat-x">
                        <asp:Label ID="Label35" runat="server" Font-Bold="True" Font-Italic="True" 
                            Font-Names="Calibri" Font-Size="14pt" Text="&amp;nbsp;My Dashboard" 
                            ForeColor="White"></asp:Label>
                    </td>
                </tr>
             <tr>
                 <td style="background-repeat: repeat-x; background-image: url('../App_Themes/Styles/Images/Form_Title.JPG');" 
                     class="style4">
                     <table>
                         <tr>
                             <td>
                                 &nbsp;</td>
                             <td>
                                 <asp:Image ID="Image2" runat="server" Height="24px" 
                                     ImageUrl="~/App_Themes/Styles/Images/gtk_refresh.png" Width="24px" />
                             </td>
                             <td>
                                 &nbsp;</td>
                             <td>
                                 <asp:Image ID="Image4" runat="server" Height="24px" 
                                     ImageUrl="~/App_Themes/Styles/Images/excel.png" Width="24px" />
                             </td>
                             <td>
                                 &nbsp;</td>
                         </tr>
                     </table>
                     </td>
             </tr>
             <tr>
                 <td style="border: 1px solid #CCFF99; height:250px; padding-top: 5px; padding-left: 5px;" 
                     valign="top">
                         &nbsp;</td>
             </tr>
            <tr>
                <td>
                    
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


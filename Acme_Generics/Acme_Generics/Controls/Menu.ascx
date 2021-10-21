<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Controls_Menu" %>
<script type="text/javascript">
    $(function () {
        if ($.browser.msie && $.browser.version.substr(0, 1) < 7) {
            $('li').has('ul').mouseover(function () {
                $(this).children('ul').css('visibility', 'visible');
            }).mouseout(function () {
                $(this).children('ul').css('visibility', 'hidden');
            })
        }

        /* Mobile */
        $('#menu-wrap').prepend('<div id="menu-trigger">Menu</div>');
        $("#menu-trigger").on("click", function () {
            $("#menu").slideToggle();
        });

        // iPad
        var isiPad = navigator.userAgent.match(/iPad/i) != null;
        if (isiPad) $('#menu ul').addClass('no-transition');
    });          
</script>
<script data-type="T" src="menu/wj.js" type="text/javascript"></script>
<script src="menu/jquery.min.js" type="text/javascript"></script>
<style type="text/css">
    body
    {
        font: 13px 'trebuchet MS' , Arial, Helvetica;
    }
    
    h2, p
    {
        text-align: center;
        color: black;
        text-shadow: 0 1px 0 #fff;
    }
    
    a
    {
        color: black;
    }
    
    /* You don't need the above styles, they are demo-specific ----------- */
    
    #menu, #menu ul
    {
        margin: 0;
        padding: 0;
        list-style: none;
    }
    
    ul
    {
        
    }
    
    #menu
    {
        width: 80%;
        margin: 0px auto;
        border: 0px solid #222;
        background-color: white;
        background-image: -moz-linear-gradient(white, white);
        background-image: -webkit-gradient(linear, left top, left bottom, from(white), to(white));
        background-image: -webkit-linear-gradient(white, white);
        background-image: -o-linear-gradient(white, white);
        background-image: -ms-linear-gradient(white, white);
        background-image: linear-gradient(white, white);
        background-image: url('../App_Themes/Styles/Images/Header.JPG');
        background-repeat: repeat-x;
        -moz-border-radius: 3px;
        -webkit-border-radius: 3px;
        -moz-box-shadow: 0 1px 1px #777, 0 1px 0 #666 inset;
        -webkit-box-shadow: 0 1px 1px #777, 0 1px 0 #666 inset;
    }
    
    #menu:before, #menu:after
    {
        content: "";
        display: table;
    }
    
    #menu:after
    {
        clear: both;
    }
    
    #menu
    {
        zoom: 1;
    }
    
    #menu li
    {
        float: left;
        border-right: 1px solid #222;
        -moz-box-shadow: 1px 0 0 #CBDFAB;
        -webkit-box-shadow: 1px 0 0 #CBDFAB;
        box-shadow: 1px 0 0 #CBDFAB;
        position: relative;
    }
    
    #menu a
    {
        float: left;
        padding: 12px 30px;
        color: Black;
        text-transform: uppercase;
        font: bold 12px Arial, Helvetica;
        text-decoration: none;
        text-shadow: 0 1px 0 #000;
    }
    
    #menu li:hover > a
    {
        color: black;
    }
    
    *html #menu li a:hover
    {
        /* IE6 only */
        color: Red;
    }
    
    #menu ul
    {
        margin: 20px 0 0 0;
        _margin: 0; /*IE6 only*/
        opacity: 0;
        color: Red;
        visibility: hidden;
        position: absolute;
        top: 38px;
        left: 0;
        z-index: 1;
        background: white;
        background: -moz-linear-gradient(white, white);
        background-image: -webkit-gradient(linear, left top, left bottom, from(white), to(white));
        background: -webkit-linear-gradient(white, white);
        background: -o-linear-gradient(white, white);
        background: -ms-linear-gradient(white, white);
        background: linear-gradient(white, white);
        -moz-box-shadow: 0 -1px rgba(255,255,255,.3);
        -webkit-box-shadow: 0 -1px 0 rgba(255,255,255,.3);
        box-shadow: 0 -1px 0 rgba(255,255,255,.3);
        -moz-border-radius: 3px;
        -webkit-border-radius: 3px;
        border-radius: 3px;
        -webkit-transition: all .2s ease-in-out;
        -moz-transition: all .2s ease-in-out;
        -ms-transition: all .2s ease-in-out;
        -o-transition: all .2s ease-in-out;
        transition: all .2s ease-in-out;
    }
    
    #menu li:hover > ul
    {
        opacity: 1;
        visibility: visible;
        margin: 0;
    }
    
    #menu ul ul
    {
        top: 0;
        left: 150px;
        margin: 0 0 0 20px;
        color: Lime;
        _margin: 0; /*IE6 only*/
        -moz-box-shadow: -1px 0 0 rgba(255,255,255,.3);
        -webkit-box-shadow: -1px 0 0 rgba(255,255,255,.3);
        box-shadow: -1px 0 0 rgba(255,255,255,.3);
    }
    
    #menu ul li
    {
        float: none;
        display: block;
        border: 0;
        _line-height: 0; /*IE6 only*/
        -moz-box-shadow: 0 1px 0 #CBDFAB, 0 2px 0 #666;
        -webkit-box-shadow: 0 1px 0 #CBDFAB, 0 2px 0 #666;
        box-shadow: 0 1px 0 #CBDFAB, 0 2px 0 #666;
    }
    
    #menu ul li:last-child
    {
        -moz-box-shadow: none;
        -webkit-box-shadow: none;
        box-shadow: none;
    }
    
    #menu ul a
    {
        padding: 5px;
        width: 250px;
        _height: 10px; /*IE6 only*/
        display: block;
        white-space: nowrap;
        float: none;
        text-transform: none;
    }
    
    #menu ul a:hover
    {
        background-color: #CBDFAB;
        background-image: -moz-linear-gradient(#04acec,  #0186ba);
        background-image: -webkit-gradient(linear, left top, left bottom, from(#04acec), to(#0186ba));
        background-image: -webkit-linear-gradient(#04acec, #0186ba);
        background-image: -o-linear-gradient(#04acec, #0186ba);
        background-image: -ms-linear-gradient(#04acec, #0186ba);
        background-image: linear-gradient(#04acec, #0186ba);
    }
    
    #menu ul li:first-child > a
    {
        -moz-border-radius: 3px 3px 0 0;
        -webkit-border-radius: 3px 3px 0 0;
        border-radius: 3px 3px 0 0;
    }
    
    #menu ul li:first-child > a:after
    {
        content: '';
        position: absolute;
        left: 40px;
        top: -6px;
        border-left: 6px solid transparent;
        border-right: 6px solid transparent;
        border-bottom: 6px solid #CBDFAB;
    }
    
    #menu ul ul li:first-child a:after
    {
        left: -6px;
        top: 50%;
        margin-top: -6px;
        border-left: 0;
        border-bottom: 6px solid transparent;
        border-top: 6px solid transparent;
        border-right: 6px solid #3b3b3b;
    }
    
    #menu ul li:first-child a:hover:after
    {
        border-bottom-color: #044c9c;
    }
    
    #menu ul ul li:first-child a:hover:after
    {
        border-right-color: #0299d3;
        border-bottom-color: transparent;
    }
    
    #menu ul li:last-child > a
    {
        -moz-border-radius: 0 0 3px 3px;
        -webkit-border-radius: 0 0 3px 3px;
        border-radius: 0 0 3px 3px;
    }
    
    /* Mobile */
    #menu-trigger
    {
        display: none;
    }
    
    @media screen and (max-width: 600px)
    {
    
        /* nav-wrap */
        #menu-wrap
        {
            position: relative;
        }
    
        #menu-wrap *
        {
            -moz-box-sizing: border-box;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
        }
    
    
    
        /* main nav */
        #menu
        {
            margin: 0;
            padding: 0px;
            position: absolute;
            top: 40px;
            width: 100%;
            z-index: 1;
            background-color: #CBDFAB;
            display: none;
            -moz-box-shadow: none;
            -webkit-box-shadow: none;
            box-shadow: none;
        }
    
        #menu:after
        {
            content: '';
            position: absolute;
            left: 25px;
            top: -8px;
            border-left: 8px solid transparent;
            border-right: 8px solid transparent;
            border-bottom: 8px solid #CBDFAB;
        }
    
        #menu ul
        {
            position: static;
            visibility: visible;
            opacity: 1;
            margin: 0;
            background: none;
            -moz-box-shadow: none;
            -webkit-box-shadow: none;
            box-shadow: none;
        }
    
        #menu ul ul
        {
            margin: 0 0 0 20px !important;
            -moz-box-shadow: none;
            -webkit-box-shadow: none;
            box-shadow: none;
        }
    
        #menu li
        {
            position: static;
            display: block;
            float: none;
            border: 0;
            margin: 5px;
            -moz-box-shadow: none;
            -webkit-box-shadow: none;
            box-shadow: none;
        }
    
        #menu ul li
        {
            margin-left: 0px;
            -moz-box-shadow: none;
            -webkit-box-shadow: none;
            box-shadow: none;
        }
    
        #menu a
        {
            display: block;
            float: none;
            padding: 0;
            color: black;
        }
    
        #menu a:hover
        {
            color: black;
        }
    
        #menu ul a
        {
            padding: 0;
            width: auto;
        }
    
        #menu ul a:hover
        {
            background: none;
        }
    
        #menu ul li:first-child a:after, #menu ul ul li:first-child a:after
        {
            border: 0;
        }
    
    }
    
    @media screen and (min-width: 600px)
    {
        #menu
        {
            display: block !important;
        }
    }
    
    /* iPad */
    .no-transition
    {
        -webkit-transition: none;
        -moz-transition: none;
        -ms-transition: none;
        -o-transition: none;
        visibility: visible;
        display: none;
    }
    
    #menu li:hover > .no-transition
    {
        display: block;
    }
</style>
<nav id="menu-wrap">      
    <ul id="menu" style="color:#044c9c; width: inherit; height: inherit;border: 1px solid black;">
        <li class="active" text-align:"center";>
            <asp:HyperLink runat="server" ID="MenuHome" style="color: White" Text="Home" NavigateUrl="~/Modules/frmMain.aspx"></asp:HyperLink></li>
        <li>
         <a style="color: White" >Masters</a>
            <ul style="overflow: inherit; width: inherit; height: inherit; border: 1px solid black;">
                <li id="Menu101A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu101"  Text="User Master" NavigateUrl="~/Masters/frmUserMaster.aspx" style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
                <li id="Menu102A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu102" Text="User Roles" NavigateUrl="~/Masters/frmUserRole.aspx" style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
                <li id="Menu103A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu103" Text="Plant Master " NavigateUrl="../Masters/frmPlantMasters.aspx" style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
                <li id="Menu104A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu104" Text="Bin Master" NavigateUrl="../Masters/frmBinMaster.aspx" style="color:White" BackColor="#044c9c"></asp:HyperLink></li>
                <li id="Menu105A" runat="server" visible="false">
  <%--                  <asp:HyperLink runat="server" ID="Menu105" Text="Printer Master" NavigateUrl="../Masters/FrmPrinter.aspx" style="color:White" BackColor="#044c9c"></asp:HyperLink></li>
                <li id="Menu106A" runat="server" visible="false">--%>
                    <asp:HyperLink runat="server" ID="Menu106" Text="Weighing Master" NavigateUrl="~/Masters/frmWeigningMaster.aspx" style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
                <li id="Menu107A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu107" Text="Booth Master" NavigateUrl="~/Masters/frmBoothMaster.aspx" style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
            </ul>
        </li>
        <li><a style="color: White">Warehouse</a>
            <ul style="color:#044c9c; width: inherit; height: inherit;border: 1px solid black;">
                <li id="Menu201A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu200" Text="SU Label Printing"
                        NavigateUrl="~/Transactions/frmGrnPrinting.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>

                <li id="Menu202A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu201" Text="SU Label Re-Printing"
                        NavigateUrl="~/Transactions/frmGrnRePrinting.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>

                <li id="Menu203A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu202" Text="Sampling Printing"
                        NavigateUrl="~/Transactions/frmSamplePrinting.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
                
                <li id="Menu204A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu203" Text="Sampling Label Re-Printing"
                        NavigateUrl="~/Transactions/frmSampleReprinting.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
              
                <li id="Menu205A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu204" Text="Picklist Generation"
                        NavigateUrl="~/Transactions/frmPicklistGeneration.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
                  
                <li id="Menu206A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu205" Text="Dispensing Confirmation"
                        NavigateUrl="~/Transactions/frrDispensingConfirmation.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
                  
                <li id="Menu207A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu206" Text="Dispensing Reprint"
                        NavigateUrl="~/Transactions/frmDispensingReprinting.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
                
                <li id="Menu208A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu207" Text="Location Chart"
                        NavigateUrl="~/Transactions/frmLocationSheet.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
                
                <li id="Menu209A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu208" Text="Offline Stock Adjust"
                        NavigateUrl="~/Transactions/frmARStockAdjust.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>

                 <li id="Menu210A" runat="server" visible="false">
                    <asp:HyperLink runat="server" ID="Menu209" Text="Reset Stock "
                        NavigateUrl="~/Transactions/frmResetARNo.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
                                        
                <li id="Li1" runat="server" visible="true">
                   <asp:HyperLink runat="server" ID="HyperLink1" Text="ERP Stock Update"
                   NavigateUrl="~/Transactions/frmGrnOfflineUpdate.aspx"  style="color:White" BackColor="#044c9c" ></asp:HyperLink></li>
            </ul>
        </li>
         <li><a  style="color: White">Production</a>
            <ul style="color:#044c9c; width: inherit; height: inherit;border: 1px solid black;">
               <li id="Menu301A" runat="server" visible="false">
               <asp:HyperLink runat="server" ID="Menu301" Text="MRN Label Printing" NavigateUrl="~/Transactions/frmMRNLabelPrinting.aspx" style="color:White" 
               BackColor="#044c9c"  ></asp:HyperLink></li>

               <li id="Menu302A" runat="server" visible="false">
               <asp:HyperLink runat="server" ID="Menu302" Text="MRN Label Re-Print" NavigateUrl="~/Transactions/frmMRNLableReprinting.aspx" style="color:White" 
               BackColor="#044c9c"  ></asp:HyperLink></li>
            </ul>
         </li>
         <li style="color: White" runat="server" visible="true" id="Menu9102A"><a  style="color: White">Reports</a>
             <ul style="overflow: inherit; width: inherit; height: inherit; border: 1px solid black;" visible="false">
             <li id="Li2" runat="server" visible="true">
               <asp:HyperLink runat="server" ID="HyperLink2" Text="Reports" NavigateUrl="~/Reports/frmRework_Report.aspx" style="color:White" 
               BackColor="#044c9c"  ></asp:HyperLink></li>
             </ul>
        </li>
    </ul>
</nav>

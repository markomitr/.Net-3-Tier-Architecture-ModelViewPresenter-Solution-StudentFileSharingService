<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PredmetiStudent.aspx.cs" Inherits="WebAppStudentDemo.PredmetiStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Predmeti</title>

     <!-- css datoteki --> 
    <link rel="Stylesheet" type="text/css" href="css/Global.css" />
    <link rel="Stylesheet" type="text/css" href="css/PredmetiMain.css" />
    <!-- ------------ -->

    <style type="text/css">
        a
        {
            text-decoration:none;
            color:Black;
        }        
        
        .Status
        {
            width: 100%;
            position:fixed;
            bottom:0;
            left:0;
            font-weight: bold;
            background-color:#000000;
            color:White;
            border:2px solid Maroon;            
            padding:3px;
        }                
        
        span#VratiSeProfil
        {
            float:left;
            padding-left: 3%;
            padding-bottom: 3%;
            background:url(sliki/profil.png) top left no-repeat;
        }        
        #sodrzina
        {
        	padding:10px !important;
        }
        .tekstUpastvo
        {
        	font-size:1.1em;
        	text-align:justify;
        	display:block;
        	margin:20px 0 0 0;
        	padding:5px;
        }
    
        #InstitucijaIzbor
        {
            width: 90%;
            margin-left: 10px;
            padding: 2% 0% 0% 2%;
            border:1px solid #1782bb;                        
            float:left;
            font-size: 1em;
            font-weight: bold;
            color: #000000;
            background:url(sliki/PredmetiStudentSliki/institucijaBg.png) top left repeat-x;
            background-color: #33a8e6;
        }
        #PredmetIzbor
        {
            margin:10px 10px 0px 0px;
            padding: 2% 2% 2% 2%;
            border:1px solid #1782bb;                        
            float:left;
            font-size: 1em;
            font-weight: bold;
            color: #000000;
            background:url(sliki/PredmetiStudentSliki/institucijaBg.png) top left repeat-x;
            background-color: #33a8e6;
        }
        #UstanovaIzbor
        {
            width: 90%;
            margin-left: 10px;
            padding: 2% 0% 0% 2%;
            border:1px solid #79b604;            
            height:60px;            
            float:left;
            font-size: 1em;
            font-weight: bold;
            color: #000000;
            background:url(sliki/PredmetiStudentSliki/ustanovaBg.png) top left repeat-x;
            background-color: #90da02;
        }   
        
        #OblastIzbor
        {
            width: 90%;
            margin-left: 10px;
            padding: 2% 0% 0% 2%;
            border:1px solid #eeb805;            
            height:60px;            
            float:left;
            font-size: 1em;
            font-weight: bold;
            color: #000000;
            background:url(sliki/PredmetiStudentSliki/oblastBg.png) top left repeat-x;
            background-color: #f3a208;
        }   
        
        #NasokaIzbor
        {
            width: 90%;
            margin-left: 10px;
            padding: 2% 0% 0% 2%;
            border:1px solid #bb9001;            
            height:60px;            
            float:left;
            font-size: 1em;
            font-weight: bold;
            color: #000000;
            background:url(sliki/PredmetiStudentSliki/nasokaBg.png) top left repeat-x;
            background-color: #ffc70e;
        }        
        
        #InstitucijaIzbor #InstitucijaKratenka
        {
            float:left;
            font-size:1em;
        }
        #NasokaIzbor #NasokaOpis
        {
            width: 90%;
            float:left;
            font-size:0.7em;            
            height:50px;
            overflow:hidden;            
            word-break: break-all;
        }
        #InstitucijaIzbor #InstitucijaIme,#UstanovaIzbor #UstanovaIme,#OblastIzbor #OblastIme,#NasokaIzbor #NasokaIme
        {
            width: 100%;
            float:left;
            font-size:0.8em;            
            overflow:hidden;
            display:block;
        }
         #InstitucijaIzbor #InstitucijaAdresa,#UstanovaIzbor #UstanovaAdresa,#OblastIzbor #OblastAdresa
        {
            float:left;
            font-size:0.7em;            
            overflow:hidden;
            display:block;
            color: #ffffff;
        }
        
        #UstanovaIzbor #UstanovaWebStrana,#OblastIzbor #OblastWebStrana
        {
            float:left;
            text-decoration: underline;
            font-size:0.7em;   
            color: #ffffff;         
            overflow:hidden;
            word-break:break-all;
        }
        #PredmetIzbor #PredmetOpis
        {
        	display:none;
        }
        .Selected
        {
            background-image:none!important;
        	background-color:#a8a8a8!important;
        }
       
        ul
        {
            width: 100%;
	        list-style: none;
	        margin:10px 0px;
	        padding: 0;	        
	        width:90%;
        }
        ul li
        {
            
	        padding: 0px;
	        margin:0 2px 0 0;
	        list-style:none;
	        display:inline;
        }
        ul li span.naslov{
	        display: inline-block!important;
	        overflow: hidden;
	        height: 200px;
	        width: 50px;
	        white-space:nowrap;
	        text-align:left;
	        border:1px solid green;
	        cursor:pointer;
        }
        ul li span.naslov .obvivka {
	        padding:0 0 0 50px;
	        line-height:normal;
	        width:500px;
	        height:200px;
	        overflow:auto;
        }
        ul li span.institucija {
	        background:url(sliki/PredmetiStudentSliki/institucija.png) top left no-repeat;
        }
        ul li span.ustanova {
	        background:url(sliki/PredmetiStudentSliki/ustanova.png) top left no-repeat;
        }
        ul li span.oblast {
	        background:url(sliki/PredmetiStudentSliki/oblast.png) top left no-repeat;
        }
        ul li span.nasoka {
	        background:url(sliki/PredmetiStudentSliki/nasoka.png) top left no-repeat;
        }
    </style>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("ul li span.naslov").each(function () {
                $(this).click(function () {
                    $("ul li span.naslov").animate({ width: "50px" }, { queue: false, duration: 450 });
                    $("ul li span.naslov").removeClass("aktiven");

                    $(this).animate({ width: "600px" }, { queue: false, duration: 450 });
                    $(this).addClass("aktiven");
                });
            });
            $("ul li span.aktiven").animate({ width: "600px" }, { queue: false, duration: 450 });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="zaglavje"> 
        <div id="profilPregled" runat="server" class="profilPregled">
                
        </div>
    </div>
    <div id="sodrzina">
    <div>
        <span class="tekstUpastvo" >
            Ние (читај<strong> Вие</strong>) се грижиме за Вас и ви нудиме целосна поддршка во студирањето со тоа што ви нудиме огромен број
            материјали и информации за огромен број на предмети. За да го пронајдете предметот изберете соодветно според следните критериуми :
        </span>
        <ul>
            <li><span title="" class="institucija naslov" id="spanInstitucija" runat="server">
                <div id="IzborInstitucija" class="IzborInstitucijaDiv obvivka" runat="server">
                </div>
            </span></li>
            <li><span title="" class="ustanova naslov" id="spanUstanova" runat="server" >
                <div id="IzborUstanova" class="IzborUstanovaDiv obvivka" runat="server">
                </div>
            </span></li>
            <li><span title="" class="oblast naslov" id="spanOblast" runat="server">
                <div id="IzborOblast" class="IzborOblastDiv obvivka" runat="server">
                </div>
            </span></li>
            <li><span title="" class="nasoka naslov" id="spanNasoka" runat="server">
                <div id="IzborNasoka" class="IzborNasokaDiv obvivka" runat="server">
                </div>
            </span></li>
        </ul>
    <div id="IzborNePretplaten" class="IzborNePretplatenDiv" runat="server"></div>
    <asp:Label ID="lblStatus" class="Status" runat="server" Text="Label"></asp:Label>

<%--    <asp:Button ID="btnListajPretplateni" runat="server" OnClick="btnListajPretplateni_Click" Text="Листа Претплатени"/>
    <div class="IzborPretplateniDiv" >
        Ова е листа на претплатени предмети. 
        <br />Со кликнување врз нив можете да ги видите материјалите.
        <div id="IzborPretplateniPredmeti" runat="server">
        </div>  
    </div>--%>
    </div>
    </form>
    
</body>
</html>

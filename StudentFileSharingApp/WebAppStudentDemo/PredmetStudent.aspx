<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PredmetStudent.aspx.cs" Inherits="WebAppStudentDemo.PredmetStudent" %>
<%@ Register src="Kontroli/FileDownload.ascx" tagname="FileDownload" tagprefix="nasi" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Предмет</title>

    <!-- css datoteki --> 
    <link rel="Stylesheet" type="text/css" href="css/Global.css" />
    <link rel="Stylesheet" type="text/css" href="css/PredmetMain.css" />
    <!-- ------------ -->

    <style type="text/css">      
        
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
        
        #MaterijalPregled
        {
        	width: 80%;
        	min-height: 60px;
        	margin-left:auto;
        	margin-right: auto;
        	background-image: url("../Sliki/PredmetStudentSliki/materjalPregledBg.jpg");
            background-position: left top;
            background-repeat:repeat-x;
            background-color: #2f9ad2;
            border: 1px solid #e6e6e6;
            clear:both;
        }
        #MaterijalPregled #MaterijalNaslov a,#materijaliIzbor #MaterijalPregled #MaterijalNaslov a:visited
        {
            text-decoration:none;
            font-size:1.2em;
            font-weight: bold;
            display:block;
            margin:2px auto;            
            font-family:Verdana;
            text-decoration:none;
            color: #000000;
        }

        #materijaliIzbor #MaterijalPregled #MaterijalOpis
        {
            width: 40%;
            min-height: 60px;
            float:left;      
            text-align:center;   	
        	padding: 5px;        	
        	background-image: url("../Sliki/PredmetStudentSliki/materjalPregledSeparator.jpg");
            background-position: 100% 50%;
            background-repeat:no-repeat;
            word-wrap: break-word;
            overflow: hidden;
        	
        }        
       
        
        
        #materijaliIzbor #MaterijalPregled #MaterijalNaslov 
        {
            width: 20%;
            min-height: 60px!important;
            float:left;     
            text-align:center;   	      	
        	padding: 5px; 
        	background-image: url("../Sliki/PredmetStudentSliki/materjalPregledSeparator.jpg");
            background-position: 100% 50%;
            background-repeat:no-repeat;
            word-wrap: break-word;   
            overflow:hidden;    	
        }
        
        
        #MaterijalPregled
        {           	 
        	text-align:center;
        	 	
        }
        
        #MaterijalSlikaTip
        {        	
        	float:left;  
        	text-align:center;
        	padding-top:10px;
        	 	
        }    
        
        span#MaterijalDownload
        {
            padding:0px;
            margin:0px;
        }
        
        
        div#DownloadLenta
        {            
            width: 100%;
            min-height:30px;
            background-image: url("../Sliki/PredmetStudentSliki/downloadLentaBg.png");            
            background-repeat:repeat-x;
        }
        
        span#MaterijalDownloadCount, span#DobarRejtingMaterijal, span#LosRejtingMaterijal
        {
            float:right;
            width:8%;
            vertical-align: middle;
            padding: 3px;
        }    
        
        span#LosRejtingMaterijal
        {
            font-weight: bold;
            color: #eb4f29;
        }    
        
        span#DobarRejtingMaterijal
        {
            font-weight: bold;
            color: #1f681f;
        }   
        
        span#MaterijalDownloadCount 
        {
            font-weight: bold;
            color: #000000;
        }   
        
        #PorakaPredmetStudent
        {
        	display:block;
        	clear:both;
        }
        #PorakaPredmet
        {
            width:80%;
            background-color: #f0f0f0;
            margin-left: auto;
            margin-right: auto;
            border: 1px solid #cbcbcb;            
            margin-bottom: 1%;
            
        }
        #PorakaUserID
        {           
            float:left;             
            font-size:1em;       
            color: #154fa1;
            padding: 1%;
        }
        
        #PorakaDatum
        {
            color: #154fa1;
            float:right;
            padding-right: 2%;
            font-size:0.7em;
            margin-left:3px;
        }
        
        #PorakaSodrzina
        {            
            clear:both;
            min-height: 80px;
            padding: 1%;
            background-color:#cbcbcb;
            font-size:1em;
            font-family:Verdana;
            color: #000000;
        }
        
        #PorakaPredmetStudent
        {
            background-color: #f0f0f0;
        }
        
        div#PorakaPredmetStudentKomponenti
        {
            float:right;
            width: 50%;
            padding: 0px;
            margin:0px;
        }
        
        div#PorakaPredmetSlogan
        {
            float:left;
            width: 40%;
            min-height: 170px;
            margin: 0px;
            background-image: url("../Sliki/PredmetStudentSliki/komentiraj.jpg");     
            background-position: left bottom;       
            background-repeat:no-repeat;
        }
        
        
        div#PorakaPredmetSlogan h1
        {
            float:right;
            margin:0px;
            padding-bottom: 50px;
            font-size: 3em;
            color: #0044aa;
        }
        
        .textfield
        {
            font-family:Verdana Sans-Serif;
            width: 70%;
            min-height: 100px;
            border: 1px solid #1877a9;
            margin-right:4%;
            padding: 1%;
            font-size: left;
           
        }
        
        .btnPrati
        {          
            float:right;  
            width: 30%;
            min-height: 30px;
            margin-right: 28%;            
            border: 2px solid #1877a9;
            background-image: url("../Sliki/PredmetStudentSliki/btnPratiBg.jpg");
            background-position: 0 0;
            background-repeat:repeat-x;   
            background-color: #154fa1;
            color: #ffffff;
            font-weight: bold;  
            vertical-align:baseline;   
        }
        
        .btnPrati:hover
        {
            background-image: url("../Sliki/PredmetStudentSliki/btnPratiBgHover.jpg");
            background-position: 0 0;
            background-repeat:repeat-x;
            background-color: #5b83bd;                
        }
        
        span#PorakaHeader
        {
            clear: both;            
            background-color: #ffffff;
        }
        
        div#materijaliIzbor
        {
            clear:both;
        }
        .predmetInfo
        {
        	display:block;
        	font-family:Verdana;
        	padding:5px;
        	text-align:center;
        	display:block;
        	background-image: url("../Sliki/PredmetStudentSliki/predmetBgKos.jpg");
            background-position:right top;
            background-repeat:no-repeat;
        }
        .predmetInfo .predmetIme
        {
        	font-size:2.3em;
        	color:Black;
        	font-family:Verdana;
        	font-weight:bold;
        	text-align:center;
        	display:block;
        	width:80%;
        	margin:0 auto;
        	padding:20px 0;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div id="zaglavje"> 
        <div id="profilPregled" runat="server" class="profilPregled"></div>
    </div>
    <div id="sodrzina">
        <div id="predmetInfo" runat="server" class="predmetInfo">
        </div>
        <div class="deloviIzbor">                
                <div id="deloviIzbor" runat="server">       

                </div>
        </div>
        
        <fieldset>
        <legend>Листа на матерјали за овој предмет: </legend>
        <div class="materijaliIzbor">            
            <div id="materijaliIzbor" runat="server" >
            </div>
        </div>
        </fieldset>
        <nasi:FileDownload runat="server" id="kontrolaPrezemi"/>

       
        <div id="PorakaPredmetStudent">
            <fieldset>
            <legend>Прати порака во врска со предметот</legend>
            <br />
            <div id="PorakaPredmetStudentKomponenti">
            <asp:TextBox ID="txtBoxSodrzinaPoraka" runat="server" TextMode="MultiLine" 
                    CssClass="textfield"></asp:TextBox>

            <br />
            <asp:Button ID="btnPratiPoraka" runat="server" Text="Прати Порака" OnClick="btnPratiPoraka_Click"  CssClass="btnPrati"/>
            <br />
            
            </div>
            <div id="PorakaPredmetSlogan">
                <h1>Кажи си!</h1><br />
                
            </div>
            </fieldset>
        </div>
         <fieldset>
            <legend>Пораки пратени од корисниците</legend>
        <div id="PorakiPredmet" runat="server">
        
        </div>
        </fieldset>
        <asp:Label ID="lblStatus" class="Status" runat="server" Text="Label"></asp:Label>
        
    </div>
    </form>
</body>
</html>

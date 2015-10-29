<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginStudent.aspx.cs" Inherits="WebAppStudentDemo.LoginStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Најави се!</title>
    <!-- css datoteki -->
    <link rel="Stylesheet" type="text/css" href="css/Global.css" />
    <link rel="Stylesheet" type="text/css" href="css/LoginMain.css" />    
    <!-- ------------ -->
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/Nasi/Globalna.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="sodrzina">
        <div id="najaviSePozadina1">
            <div id="najaviSePozadina2">
                <div id="najaviSePodatoci">
                <fieldset>
                <legend>Влезиии!</legend>

                    Корисничко име:<br />
                    <asp:TextBox ID="TextBoxKorisnickoIme" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Лозинка:<br />
                    <asp:TextBox ID="TextBoxLozinka" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="ButtonNajaviSe" runat="server" Text="Најави се!" OnClick="ButtonNajaviSe_Click" CssClass="btnPrati" />
                    <br />
                   </fieldset>
                </div>
            </div>
        </div>
        <div id="greska">
            <asp:Label ID="LabelaGlobalnaGreska" class="lblGlobalnaGreska" runat="server" Text="*"></asp:Label>
        </div>
    </div>
    <div id="copyright">
        <div id="copyrightPodatoci">
         <h1>&copy;Студентски ресурси</h1>       
            2011 All rights reserved.
        </div>
    </div>
    </form>
</body>
</html>

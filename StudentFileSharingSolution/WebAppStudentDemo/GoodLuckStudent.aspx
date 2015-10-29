<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodLuckStudent.aspx.cs"
    Inherits="WebAppStudentDemo.GoodLuckStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Goodluck!</title>
    <!-- css datoteki -->
    <link rel="Stylesheet" type="text/css" href="css/Global.css" />
    <link rel="Stylesheet" type="text/css" href="css/GoodLuckMain.css" />
    <!-- ------------ -->
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/Nasi/Globalna.js" type="text/javascript"></script>
</head>
<body>
    <form id="forma" runat="server" defaultbutton="BtnNajaviSe">
    <div id="sodrzina">
        <div id="gorenDel">
            <%--            <div id="zaglavje">
                <img src="Sliki/GoodLuckStudentSliki/molivPenkalaGoreDesno.png" alt="моливи" />
            </div>--%>
            <div id="glavenDelSodrzina">
                <img src="Sliki/GoodLuckStudentSliki/PrvaStranav2.jpg" alt="живот" />
            </div>
        </div>
        <div id="footer">
            <div id="nasaCel">
                <div id="nasaCelZaglavje">
                    <span id="nasaCelZaglavjeLevo"></span><span id="nasaCelZaglavjeSredina">Наша цел!
                    </span><span id="nasaCelZaglavjeDesno"></span>
                </div>
                <div id="nasaCelSodrzina">
                    Според статистиката секој петти студент оди на испит спремен за препишување. Наша цел е да направиме и останатите четири да одат подготвени за тоа!
                </div>                
            </div>
            <div id="pridruziSe">
                <div id="pridruziSeZaglavje">
                    <span id="pridruziSeZaglavjeLevo"></span><span id="pridruziSeZaglavjeSredina">Придружи се </span>
                    <span id="pridruziSeZaglavjeDesno"></span>
                </div>
                <div id="pridruziSeSodrzina">
                    <span id="pridruziSeSodrzinaLevo">
                    Корисничко име:<br />
                    <asp:TextBox ID="TextBoxKorisnickoIme_Nov" runat="server"></asp:TextBox>                    
                    <asp:Label ID="lblKorisnickoIme_Nov_Validacija" runat="server" Text=""></asp:Label>
                    <br />
                    Емаил:
                    <br />
                    <asp:TextBox ID="TextBoxEmail_Nov" runat="server"></asp:TextBox>                    
                    <asp:Label ID="lblEmail_Nov_Validacija" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="lblSummaryValidacija" runat="server" class="lblSummary" ></asp:Label>
                    </span>
                    <span id="pridruziSeSodrzinaDesno">
                    Лозинка:
                    <br />
                    <asp:TextBox ID="TextBoxLozinka_Nov" runat="server" TextMode="Password"></asp:TextBox> 
                    <asp:Label ID="lblLozinka_Nov_Validacija" runat="server" Text=""></asp:Label>                   
                    <br />
                    Провери лозинка:
                    <br />
                    <asp:TextBox ID="TextBoxProveriLozinka_Nov" runat="server" TextMode="Password"></asp:TextBox>      
                    <asp:Label ID="lblProveriLozinka_Nov_Validacija" runat="server" Text=""></asp:Label>           
                    

                    <asp:Button ID="BtnPridruziSe" runat="server" Text="Креирај корисник" OnClick="BtnPridruziSe_Click"
                        CssClass="btnPrati" />
                    <br />
                    </span>
                </div>                
            </div>
            <div id="najaviSe">
                <div id="najaviSeZaglavje">
                    <span id="najaviSeZaglavjeLevo"></span><span id="najaviSeZaglavjeSredina">Најави се!
                    </span><span id="najaviSeZaglavjeDesno"></span>
                </div>
                <div id="najaviSeSodrzina">
                    Корисничко име:<br />
                    <asp:TextBox ID="TextBoxKorisnickoIme_Najava" runat="server"></asp:TextBox>                    
                    <br />
                    <br />
                    Лозинка:
                    <br />
                    <asp:TextBox ID="TextBoxLozinka_Najava" runat="server" TextMode="Password"></asp:TextBox>                 
                    

                    <asp:Button ID="BtnNajaviSe" runat="server" Text="Најави се" OnClick="BtnNajaviSe_Click"
                        CssClass="btnNajaviSe" />
                    <br />
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

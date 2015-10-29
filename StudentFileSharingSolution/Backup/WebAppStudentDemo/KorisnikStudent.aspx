<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KorisnikStudent.aspx.cs"
    Inherits="WebAppStudentDemo.KorisnikStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Корисник</title>
    <!-- css datoteki -->
    <link rel="Stylesheet" type="text/css" href="css/Global.css" />
    <link rel="Stylesheet" type="text/css" href="css/KorisnikMain.css" />
    <!-- ------------ -->
     <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/Nasi/Globalna.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="zaglavje">
        <div id="profilPregled" runat="server" class="profilPregled">
        </div>
    </div>
    <div id="sodrzina">
        <div id="profil">
            <div id="profilLevo">
                <div id="profilLevoTop">
                    <img src="Sliki/KorisnikStudentSliki/kockaProfilGorenLevDel.jpg" alt="" />
                </div>
                <div id="profilLevoBottom">
                    <h2>
                        Профил
                    </h2>
                    <ul>
                        <li><a href="?izmeni=false">Преглед</a></li>
                        <li><a href="?izmeni=true">Измена</a></li>
                    </ul>
                </div>
            </div>
            <div id="profilDesno">                
                    <div id="licniPodatoci" runat="server">
                    <fieldset>
                    <legend>Лично податоци: </legend>Име:
                        <br />
                        <asp:TextBox ID="TextBoxIme" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        Презиме:<br />
                        <asp:TextBox ID="TextBoxPrezime" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        Емаил:
                        <br />
                        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                        <br />
                        <br /> 
                      </fieldset>                                   
            </div>
            <div id="smetka" runat="server">
                <fieldset>
                    <legend>Податоци за сметката</legend>Корисничко име:
                    <br />
                    <asp:TextBox ID="TextBoxKorisnickoIme" runat="server"></asp:TextBox>
                    <br />
                    <br />
                                    
                </fieldset>
                <asp:Button ID="ButtonZacuvajIzmeni" runat="server" OnClick="ButtonZacuvajIzmeni_Click"
                    Text="Зачувај" CssClass="btnPrati" />
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <div id="linija">
        <hr />
    </div>
    <div id="predmeti">
    <div id="predmetiOpisi">
        <div id="predmetDesno">
            <div id="predmetDesnoTop">
                <img src="Sliki/KorisnikStudentSliki/kockaPredmetGorenLevDel.jpg" alt="" />
            </div>
            <div id="predmetDesnoBottom">
                <h2>
                    Предмети
                </h2>
            </div>
        </div>
        <div id="predmetLevo">
        <div id="predmetiNovaPretplateniOpis">
          Доколку сакате да додадете нов предмет кој го немате во листата на веќе претплатени предмети кликнете на линкот(сликата) за претплата на нови предмети. Со избор на новиот предмет т.е претплата на избраниот предемет, тој ке ви биде излистан во долната листа.
        </div>
        <div id="predmetiPretplateniOpis">
          Прикажани ви се предметите на кои се имате претплатено. Со избор на предметот т.е кликнување над соодветната икона се пренасочувате до страната на предметот. Таму имате пристап до последните матерјали и коментари.
        </div>  
        </div>
         <div id="pretplatiSe">
                <a href="PredmetiStudent.aspx">
                    <img src="Sliki/KorisnikStudentSliki/pretplatiSe.jpg" alt="Претплати се" />
                </a>
            </div>
    </div>
        <div id="IzborPretplateniPredmeti" runat="server">
        </div>
    </div>
    <div class="clear">
    </div>
    <div id="linija">
        <hr />
    </div>
    <<%--div id="novosti">
        <div id="novostiLevo">
            <h2>
                Новости!!!</h2>
        </div>
        <div id="novostiDesno">
        </div>
    </div>--%>
    </div>
    <div id="greska">
    <asp:Label ID="LabelaGlobalnaGreska" class="lblGlobalnaGreska" Text="*" runat="server" />
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppTestiranje._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Студентски ресурси - 2010/11</title>
    <link href="css/prva_strana.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="kontejner">
        <div id="najaviSe">
            <div class="sodrzina">
                <h2>
                    Најави се!
                </h2>
                <hr />
                <br />
                <div class="levaKelija">
                    Корисничко име:
                    <br />
                    <asp:TextBox ID="TxtBoxIme" runat="server"></asp:TextBox>
                    <br />                    
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <div class="desnaKelija">
                    Лозинка:
                    <br />
                    <asp:TextBox ID="TxtBoxPass" runat="server" TextMode="Password"></asp:TextBox>
                    <br />                    
                    <div class="btnPozicija">
                        <asp:Button ID="Button1" runat="server" Text="Логирај се" OnClick="Button1_Click"
                            CssClass="btn" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <br />
            </div>
        </div>
    </div>
    <div id="kontejnerKreirajSmetka">
        <div id="kreirajKorisnik">
            <div class="sodrzina">
                <h2>
                    Сеуште немате сметка? Креирајте една тука!
                </h2>
                <hr>
                <br />
                <br />
                <div class="levaKelija">
                    Корисничко име:<br />
                    <asp:TextBox ID="TxtBoxKorisnikID" runat="server"></asp:TextBox>
                    Име:<br />
                    <asp:TextBox ID="TxtBoxKorisnikIme" runat="server"></asp:TextBox>
                    Емаил:<br />
                    <asp:TextBox ID="TxtBoxEmail" runat="server"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" ForeColor="#CC0000"></asp:Label>
                </div>
                <div class="desnaKelija">
                    Лозинка:<br />
                    <asp:TextBox ID="TxtBoxKorisnikLozinka" runat="server" TextMode="Password"></asp:TextBox>
                    Презиме:<br />
                    <asp:TextBox ID="TxtBoxKorisnikPrezime" runat="server"></asp:TextBox>
                    <br />
                    <div class="btnPozicija">
                        <asp:Button ID="Button2" runat="server" Text="Креирај сметка" OnClick="Button2_Click"
                            CssClass="btn" />
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="listaKorisnici">
            <br />
            <br />
            <asp:Button ID="listajKopce" runat="server" Text="Листај Корисници" OnClick="listajKopce_Click"
                CssClass="btn" />
            <asp:BulletedList ID="BulletedList1" runat="server">
            </asp:BulletedList>
        </div>
    </div>
    </form>
</body>
</html>

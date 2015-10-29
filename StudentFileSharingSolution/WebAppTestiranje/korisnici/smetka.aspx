<%@ Page Title="" Language="C#" MasterPageFile="~/korisnici/Pocetna.Master" AutoEventWireup="true" CodeBehind="smetka.aspx.cs" Inherits="WebAppTestiranje.korisnici.smetka1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="korisniciProfil">
    <div id="profilPodmeni1">
    <h1>Сметка</h1>    
    </div>
    <div id="profilPodmeni2">
    <ul>
        <li id="profilSmetkaPregled"><a href="smetka.aspx?izmeni=false&id=12202">Преглед</a></li>
        <li id="profilSmetkaIzmeni"><a href="smetka.aspx?izmeni=true&id=12202">Измени</a></li>        
    </ul>    
    </div>
   <p>
                     UserID:<br />
                     <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                 </p>
                 <p>
                     Лозинка:<br />
                     <asp:TextBox ID="txtLozinka" runat="server"></asp:TextBox>
                 </p>
                 <p>
                     Емаил:<br />
                     <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                 </p>
                 <p>
                     Име:<br />
                     <asp:TextBox ID="txtIme" runat="server"></asp:TextBox>
                 </p>
                 <p>
                     Презиме:<br />
                     <asp:TextBox ID="txtPrezime" runat="server"></asp:TextBox>
                 </p>
                 <p>
                     <asp:Button ID="btnPromeniUser" runat="server" Text="Зачувај промени" onclick="btnPromeniUser_Click1" 
                          />
                     &nbsp;</p>
    <p>
                     &nbsp;</p>
        

    <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
    
    </div>
</asp:Content>

<%@ Page Title="Измена корисници" Language="C#" MasterPageFile="~/korisnici/Pocetna.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebAppTestiranje.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="bg">        
        <div id="bgContent">
        
                 <h2>Измени податоци</h2>
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
                     <asp:Button ID="Button1" runat="server" Text="Button" />
                 </p>
        
        
        </div>
    </div>
   
</asp:Content>

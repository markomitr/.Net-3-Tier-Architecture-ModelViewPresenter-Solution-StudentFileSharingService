<%@ Page Title="" Language="C#" MasterPageFile="~/korisnici/Pocetna.Master" AutoEventWireup="true" CodeBehind="Materijali.aspx.cs" Inherits="WebAppTestiranje.Materijali" %>
<%@ Register src="FtpUploadControl.ascx" tagname="FtpUploadControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<br />

    <asp:Label ID="Label5" runat="server" Text="Датотека:"></asp:Label>
    <asp:FileUpload ID="kaci1" runat="server" />
    <br />
    <asp:Button ID="uploadBtn" runat="server" Text="FTP" OnClick="Button1_Click" />
    <br />
    Наслов : <asp:TextBox ID="textBoxNaslovMaterijal_Add" runat="server"></asp:TextBox>
    <br />
    Опис : <asp:TextBox ID="textBoxOpisMaterijal_Add" runat="server"></asp:TextBox>
    <br />
    Слика : <asp:TextBox ID="textBoxSlikaMaterijal_Add" runat="server"></asp:TextBox>
    <br />
    Патека : <asp:TextBox ID="textBoxPatekaMaterijal_Add" runat="server"></asp:TextBox>
    <asp:Button ID="btnAddMaterijal" runat="server" Text="Додади" 
        onclick="btnAddMaterijal_Click" />
        <br />
        <br />
    <asp:DropDownList ID="dodadenOdMaterijal_Add" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblStatus" runat="server" Text=" "></asp:Label>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RedularExpression.aspx.cs" Inherits="WebAppTestiranje.RedularExpression" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Username&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="349px"></asp:TextBox>
        <br />
        <br />
        password&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Width="242px"></asp:TextBox>
        <br />
        <br />
        email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Width="223px"></asp:TextBox>
        <br />
        <br />
        ime&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Width="207px"></asp:TextBox>
        <br />
        <br />
        prezime&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" Width="204px"></asp:TextBox>
        <br />
        <br />
        naslov na materijal&nbsp;
        <asp:TextBox ID="TextBox6" runat="server" Width="190px"></asp:TextBox>
        <br />
        <br />
        opis na materijal&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox8" runat="server" Height="169px" Width="244px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="OK" 
            Width="81px" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    
        <br />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    
    </div>
    </form>
</body>
</html>

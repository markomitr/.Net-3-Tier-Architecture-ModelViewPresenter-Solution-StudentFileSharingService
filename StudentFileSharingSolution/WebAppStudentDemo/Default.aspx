<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppStudentDemo._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #PorakaPredmet
        {
            border:2px solid Black;
            height:100px;
            width:350px;
            margin:1px;
            
        }
        #PorakaUserID,#PorakaDatum
        {
            font-size:0.7em;
            margin-left:3px;
        }
        #PorakaSodrzina
        {
            background-color:Gray;
            font-size:0.8em;
            font-family:Verdana;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="PorakaPredmetStudent">
    <asp:TextBox ID="txtBoxSodrzinaPoraka" runat="server" Height="54px" TextMode="MultiLine" 
        Width="172px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnPratiPoraka" runat="server" Text="Прати Порака" 
            onclick="btnPratiPoraka_Click" />

        <br />
        <br />
       
    <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
    </div>
    <div id="PorakiPredmet" runat ="server">

    </div>
    </form>
</body>
</html>

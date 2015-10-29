<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NovPrepisuvacStudent.aspx.cs" Inherits="WebAppStudentDemo.NovPrepisuvacStudent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nov Prepisuvac</title>
   
      <!-- css datoteki -->
    <link rel="Stylesheet" type="text/css" href="css/NovPrepisuvacMain.css" />
    <style type="text/css">
        .style2
        {
            text-align: right;
        }
        .style3
        {
            width: 49px;
        }
        .style4
        {
            vertical-align: middle;
            height: 50px;
            width: 324px;
        }
        .style5
        {
            width: 324px;
        }
        .style6
        {
            cursor: pointer;
            color: #666666;
            font: 11px/14px 'Lucida Grande',sans-serif;
            text-align: right;
            width: 324px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table style="width:74%;">
        <tr>
            <td style="text-align: right">
                Корисничко име</td>
            <td class="style4">
                <asp:TextBox ID="TextBoxUserIDAdd" runat="server" style="text-align: center" 
                    Width="177px"></asp:TextBox>
                <asp:Label ID="lblUserIDValidacija" runat="server" Text=""></asp:Label>
                <br />
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Лозинка</td>
            <td class="style4">
                <asp:TextBox ID="TextBoxLozinkaAdd" runat="server" style="text-align: center" 
                    Width="177px" TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblLozinkaValidacija" runat="server" Text=""></asp:Label>
                <br />
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Потврди лозинка</td>
            <td class="cell">
                <asp:TextBox ID="TextBoxPotvrdiLozinkaAdd" runat="server" style="text-align: center" 
                    Width="177px" TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblPotvrdiLozinkaValidacija" runat="server" Text=""></asp:Label>
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                Email</td>
            <td class="style4">
                <asp:TextBox ID="TextBoxEmailAdd" runat="server" style="text-align: center" 
                    Width="177px"></asp:TextBox>
                <asp:Label ID="lblEmailValidacija" runat="server" Text=""></asp:Label>
                <br />
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                Име</td>
            <td class="style4">
                <asp:TextBox ID="TextBoxImeAdd" runat="server" style="text-align: center" 
                    Width="177px"></asp:TextBox>
                <asp:Label ID="lblImeValidacija" runat="server" Text=""></asp:Label>
                <br />
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                Презиме</td>
            <td class="style4">
                <asp:TextBox ID="TextBoxPrezimeAdd" runat="server" style="text-align: center" 
                    Width="177px"></asp:TextBox>
                <asp:Label ID="lblPrezimeValidacija" runat="server" Text=""></asp:Label>
                <br />
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                100% се согласувам: </td>
            <td class="style5">
                <textarea id="TextArea1" name="S1">
     Бидејќи времето што требаше да го потрошам на уредно посетување настава и фаќање белешки го преспав, бидејќи вечерите кога колегите не излегуваа со мене со изговор дека учеле, јас ги поминав многу покреативно – мислејќи нови методи за препишување (и секако паднав на испитите), бидејќи од моите забавно-рекреативни хобија не ми остана слободно време за да ги искористам термините за консултации со професорите и разјаснување на нејасното (воглавно цел изучен материјал) и бидејќи денеска сум ден пред испит/ колоквиум/ тест со огромно задоволство прифаќам да не се молам кај бубалиците за нивните тетратки туку да ги прифатам долунаведените услови:

    1.	Се согласувам дека ќе го скенирам испитот/колоквиумот/тестот и ќе го поставам како материјал од кој ќе имаат корист и други студенти.

    2.	Ако положам со оцена >=9 во сабота вечер креаторите на сајтот ќе добијат вечера во медитеранскиот ресторан Гурмет.
    
    3.	Се согласувам дека на корисникот чиј поставен материјал ми помогнал најмногу ќе му подарам голема Милка чоколада.
    
    4.	Се согласувам дека ќе го подобрам својот ракопис за во иднина моите тетратки да им послужат и на други студенти/ученици.
    
    5.	Согласен сум со условот дека нема да поставувам материјали со несоодветна содржина и да им отварам дополнителна работа на админите.

    6.	Ветувам дека ќе ги споделам со останатите студенти/ученици сите ливчиња што досега сум ги правел за препишување.

    7.	Се согласувам дека за секое фалење на facebook дека сум положил некој испит ќе ја нагласам освен мојата и заслугата на сајтов (за да може и моите fb пријателчиња да си дочекаат дипломирање до 26тата година).

    8.	И за крај ветувам дека нема да дозволам со олку добри материјали да презапишам предмет повеќе од 2 пати и дека ќе сторам се што е во мојата препишувачка и потпрашувачка моќ за да положам. Зошто секој положен испит (тест) на секој студент е успех за секој од нас што сме поставиле материјали кои биле причина за уште едно илјадарче во индексот/свидителството.

</textarea></td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style6">
               &nbsp;&nbsp;&nbsp; 
                <asp:Button ID="Button1" runat="server" Text="Нов препишувач" 
                    Width="125px" class="Kopce" onclick="Button1_Click" />
           
            </td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>

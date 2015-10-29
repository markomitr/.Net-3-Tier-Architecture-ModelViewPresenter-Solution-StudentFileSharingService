using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassDLL.RegularExpression;
using ClassDLL.SysPart;

namespace WebAppTestiranje
{
    public partial class RedularExpression : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = new Korisnik();
          //  korisnik.UserID = this.TextBox1.Text;
           // korisnik.Lozinka = this.TextBox2.Text;
           // korisnik.Email = this.TextBox3.Text;
           // korisnik.Ime = this.TextBox4.Text;
            //korisnik.Prezime = this.TextBox5.Text;

            Materijal materijal = new Materijal();
            materijal.Naslov = TextBox6.Text;

           Label1.Text = materijal.Naslov;
            materijal.Opis = TextBox8.Text;
            Label2.Text = materijal.Opis;
        }
    }
}
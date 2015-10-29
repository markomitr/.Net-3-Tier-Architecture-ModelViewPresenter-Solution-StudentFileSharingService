using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presenter.Interface;
using Presenter.Presenter;
using ClassDLL.SysPart;

namespace WebAppTestiranje
{
    public partial class _Default : System.Web.UI.Page, IKorisnikLoginCreateListView,IKorisnikLoginStarView
    {
        IPresenter presenter;
        List<Korisnik> listaKor;
        #region Properties
        public string UserID
        {
            get
            {
                return this.TxtBoxIme.Text;
            }
            set
            {
                this.TxtBoxIme.Text = value;
            }
        }

        public string Lozinka
        {
            get
            {
                return this.TxtBoxPass.Text;
            }
            set
            {
                this.TxtBoxPass.Text = value;
            }
        }

        public string PorakaLogin
        {
            set
            {
                this.Label1.Text = value;
            }
        }


        public string NovUserID
        {
            get
            {
                return this.TxtBoxKorisnikID.Text;
            }
            set
            {
                this.TxtBoxKorisnikID.Text = value;
            }
        }

        public string NovLozinka
        {
            get
            {
                return this.TxtBoxKorisnikLozinka.Text;
            }
            set
            {
                this.TxtBoxKorisnikLozinka.Text = value;
            }
        }

        public string NovIme
        {
            get
            {
                return this.TxtBoxKorisnikIme.Text;
            }
            set
            {
                this.TxtBoxKorisnikIme.Text = value;
            }
        }

        public string NovPrezime
        {
            get
            {
                return this.TxtBoxKorisnikPrezime.Text;
            }
            set
            {
                this.TxtBoxKorisnikPrezime.Text = value;
            }
        }

        public string NovEmail
        {
            get
            {
                return this.TxtBoxEmail.Text;
            }
            set
            {
                this.TxtBoxEmail.Text = value;
            }
        }

        public string PorakaNovKor
        {
            set
            {
                this.Label2.Text = value;
            }
        }

        public List<Korisnik> ListaKorisnici
        {
            get
            {
                return this.listaKor;
            }
            set
            {
                this.listaKor = value;
            }
        }
#endregion
        public _Default()
        {

            presenter = new KorisniciPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ((KorisniciPresenter)presenter).logirajKorisnik();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ((KorisniciPresenter)presenter).kreirajKorisnik();

        }
        protected void listajKopce_Click(object sender, EventArgs e)
        {
            ((KorisniciPresenter)presenter).listaKorisnici();
        }

        public void napolniKorisnici()
        {
            BulletedList1.Items.Clear();
            foreach (Korisnik korisnik in ListaKorisnici)
            {
                string id = korisnik.UserID;
                string aktiven = korisnik.Aktiven ? "N" : "D";
                BulletedList1.Items.Add(String.Format("id={0}, aktiven={1} ", id, aktiven));
            }
        }


        public string Poraka
        {
            set { this.PorakaLogin = value; }
        }
    }
}
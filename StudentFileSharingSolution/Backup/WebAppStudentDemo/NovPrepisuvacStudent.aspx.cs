using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppStudentDemo.Class;
using Presenter.Interface.Views.KorisnikViews;
using Presenter.Presenter;
namespace WebAppStudentDemo
{
    public partial class NovPrepisuvacStudent : Glavna,IKorisnikAddView
    {
        KorisniciPresenter korPresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.korPresenter = new KorisniciPresenter(this);
        }

        #region IKorisnikAddView Members

        public string UserId_Korisnik_Add_Input
        {
            get
            {
                return this.TextBoxUserIDAdd.Text;
            }
            set
            {
                this.TextBoxUserIDAdd.Text = value;
            }
        }

        public string Lozinka_Korisnik_Add_Input
        {
            get
            {
                return this.TextBoxLozinkaAdd.Text;
            }
            set
            {
                this.TextBoxLozinkaAdd.Text = value;
            }
        }

        public string LozinkaCheck_Korisnik_Add_Input
        {
            get
            {
                return this.TextBoxPotvrdiLozinkaAdd.Text;
            }
            set
            {
                this.TextBoxPotvrdiLozinkaAdd.Text = value;
            }
        }

        public string Email_Korisnik_Add_Input
        {
            get
            {
                return this.TextBoxEmailAdd.Text;
            }
            set
            {
                this.TextBoxEmailAdd.Text = value;
            }
        }

        public string Ime_Korisnik_Add_Input
        {
            get
            {
                return this.TextBoxImeAdd.Text;
            }
            set
            {
                this.TextBoxImeAdd.Text = value;
            }
        }

        public string Prezime_Korisnik_Add_Input
        {
            get
            {
                return this.TextBoxPrezimeAdd.Text;
            }
            set
            {
                this.TextBoxPrezimeAdd.Text = value;
            }
        }

        public string UserId_Korisnik_Add_Validacija
        {
            get
            {
                return this.lblUserIDValidacija.Text;
            }
            set
            {
                this.lblUserIDValidacija.Text = value;
            }
        }

        public string Lozinka_Korisnik_Add_Validacija
        {
            get
            {
                return this.lblLozinkaValidacija.Text;
            }
            set
            {
                this.lblLozinkaValidacija.Text = value;
            }
        }

        public string LozinkaCheck_Korisnik_Add_Validacija
        {
            get
            {
                return this.lblPotvrdiLozinkaValidacija.Text;
            }
            set
            {
                this.lblPotvrdiLozinkaValidacija.Text = value;
            }
        }

        public string Email_Korisnik_Add_Validacija
        {
            get
            {
                return this.lblEmailValidacija.Text;
            }
            set
            {
                this.lblEmailValidacija.Text = value;
            }
        }

        public string Ime_Korisnik_Add_Validacija
        {
            get
            {
                return this.lblImeValidacija.Text;
            }
            set
            {
                this.lblImeValidacija.Text = value;
            }
        }

        public string Prezime_Korisnik_Add_Validacija
        {
            get
            {
                return this.lblPrezimeValidacija.Text;
            }
            set
            {
                this.lblPrezimeValidacija.Text = value;
            }
        }

        public void ClearValidacija()
        {
            this.lblPrezimeValidacija.Text = "";
            this.lblUserIDValidacija.Text = "";
            this.lblPotvrdiLozinkaValidacija.Text = "";
            this.lblLozinkaValidacija.Text = "";
            this.lblImeValidacija.Text = "";
            this.lblEmailValidacija.Text = "";
        }

        #endregion

        #region IMsgStatus Members

        public string ErrorPoraka
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string InfoPoraka
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.korPresenter.addKorisnik();
        }
    }
}
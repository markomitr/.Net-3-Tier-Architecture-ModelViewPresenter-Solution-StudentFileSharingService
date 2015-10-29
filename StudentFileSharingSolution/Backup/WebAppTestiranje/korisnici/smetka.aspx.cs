using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presenter.Interface.KorisnikViews;
using Presenter.Interface;
using Presenter.Presenter;
using ClassDLL.SysPart;

namespace WebAppTestiranje.korisnici
{
    public partial class smetka1 : System.Web.UI.Page, IView, IKorisnikUpdateFormView, IKorisnikUpdateView,IMsgStatus
    {
        IPresenter presKorisnik;
        String UserIDEditSelected;
        String statusIzmena;        

        protected void Page_Load(object sender, EventArgs e)
        {       
            if (Request.QueryString["izmeni"] != null)
            {
                this.statusIzmena = Request.QueryString["izmeni"];                
            }

            if (Request.QueryString["id"] != null)
            {
                UserIDEditSelected = Request.QueryString["id"].ToString();
                ((KorisniciPresenter)presKorisnik).zemiKorisnikZaIzmena();
            }
        }

        public smetka1()
        {
            presKorisnik = new KorisniciPresenter(this);
        }

        public smetka1(String UserID)
        {
            presKorisnik = new KorisniciPresenter(this);
        }

        #region IKorisnikUpdateFormView
        public string UserID_Edit_Selected
        {
            get
            {
                return this.UserIDEditSelected;
            }
            set
            {
                this.UserIDEditSelected = value;
            }
        }
        
        #endregion

        #region IKorisnikUpdateView
        public string UserId_Update_Input
        {
            get
            {
                return this.txtUserID.Text;
            }
            set
            {
                this.txtUserID.Text = value;
            }
        }

        public string Lozinka_Update_Input
        {
            get
            {
                return this.txtLozinka.Text;
            }
            set
            {
                this.txtLozinka.Text = value;
            }
        }

        public string Email_Update_Input
        {
            get
            {
                return this.txtEmail.Text;
            }
            set
            {
                this.txtEmail.Text = value;
            }
        }

        public string Ime_Update_Input
        {
            get
            {
                return this.txtIme.Text;
            }
            set
            {
                this.txtIme.Text = value;
            }
        }

        public string Prezime_Update_Input
        {
            get
            {
                return this.txtPrezime.Text;
            }
            set
            {
                this.txtPrezime.Text = value;
            }
        }
        #endregion
       

        protected void btnPromeniUser_Click1(object sender, EventArgs e)
        {
            ((KorisniciPresenter)presKorisnik).izmeniKorisnik();
        }

        #region UpdateFormView
        

        public void nacrtajFormaZaUpdateKorisnik(ClassDLL.SysPart.Korisnik korObj)
        {
            this.txtUserID.Text = korObj.UserID;
            this.txtUserID.Enabled = false;
            this.txtLozinka.Text = korObj.Lozinka;
            this.txtEmail.Text = korObj.Email;
            this.txtIme.Text = korObj.Ime;
            this.txtPrezime.Text = korObj.Prezime;
        }     
        #endregion


        public string ErrorPoraka
        {
            get
            {
                return this.lblStatus.Text;
            }
            set
            {
                this.lblStatus.Text = value;
            }
        }

        public string InfoPoraka
        {
            get
            {
                return this.lblStatus.Text;
            }
            set
            {
                this.lblStatus.Text = value;
            }
        }
    }


}
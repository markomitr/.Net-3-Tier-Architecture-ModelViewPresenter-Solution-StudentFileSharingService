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

namespace WebAppTestiranje
{
    public partial class Home : System.Web.UI.Page, IView, IKorisnikUpdateFormView, IKorisnikUpdateView
    {
        IPresenter presKorisnik;
        String UserIDEditSelected;

        public Home()
        {
            presKorisnik = new KorisniciPresenter(this);
        }   

        public Home(String UserID)
        {            
            presKorisnik = new KorisniciPresenter(this);
           

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                UserIDEditSelected = Request.QueryString["id"].ToString();
                ((KorisniciPresenter)presKorisnik).zemiKorisnikZaIzmena();
            }
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

        public void nacrtajFormaZaUpdateKorisnik(ClassDLL.SysPart.Korisnik korObj)
        {
            this.txtUserID.Text = korObj.UserID;
            this.txtUserID.Enabled = false;
            this.txtIme.Text = korObj.Ime;
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
                return " ";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Email_Update_Input
        {
            get
            {
                return " ";
            }
            set
            {
                throw new NotImplementedException();
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
                return " ";
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        private void btnPromeniUser_Click(object sender, EventArgs e)
        {
            ((KorisniciPresenter)presKorisnik).izmeniKorisnik();
        }
    }
  }

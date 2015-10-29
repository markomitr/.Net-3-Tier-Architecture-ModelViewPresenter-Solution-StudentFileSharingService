using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnMkConvertor;
using Presenter.Interface;
using Presenter.Interface.Presenters;
using Presenter.Interface.Views.KorisnikViews;
using Presenter.Presenter;
using WebAppStudentDemo.Class;
namespace WebAppStudentDemo
{
    public partial class GoodLuckStudent : Glavna,
                                    IView,IKorisnikAddBrzView, IKorisnikLoginView
    {
        IKorisnikPresenter korisnikPresenter;
        public GoodLuckStudent()
        {
            this.daliLogin = false;
            korisnikPresenter = new KorisniciPresenter(this);
		  
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        #region IKorisnikAddBrzView
        public string UserId_Korisnik_AddBrz_Input
        {
            get
            {
                return this.TextBoxKorisnickoIme_Nov.Text;
            }
            set
            {
                this.TextBoxKorisnickoIme_Nov.Text = value;
            }
        }

        public string Lozinka_Korisnik_AddBrz_Input
        {
            get
            {
                return this.TextBoxLozinka_Nov.Text;
            }
            set
            {
                this.TextBoxLozinka_Nov.Text = value;
            }
        }

        public string Lozinka_Korisnik_AddBrz_Check_Input
        {
            get
            {
                return this.TextBoxProveriLozinka_Nov.Text;
            }
            set
            {
                this.TextBoxProveriLozinka_Nov.Text = value;
            }
        }

        public string Email_Korisnik_AddBrz_Input
        {
            get
            {
                return this.TextBoxEmail_Nov.Text;
            }
            set
            {
                this.TextBoxEmail_Nov.Text = value;
            }
        }

        public string ErrorPoraka
        {
            get
            {
                return this.LabelaGlobalnaGreska.Text;
            }
            set
            {
                this.LabelaGlobalnaGreska.Text =EnMk.CistoKonv(value);
            }
        }

        public string InfoPoraka
        {
            get
            {
                return this.LabelaGlobalnaGreska.Text;
            }
            set
            {
                this.LabelaGlobalnaGreska.Text = EnMk.CistoKonv(value);
            }
        }
        protected void BtnPridruziSe_Click(object sender, EventArgs e)
        {
            this.korisnikPresenter.addBrzKorisnk();
        }


        public void uspeshnoDodadenKorisnkBrz()
        {
            this.TextBoxKorisnickoIme_Nov.Text = "";
            this.TextBoxKorisnickoIme_Nov.Text = "";
            this.TextBoxLozinka_Nov.Text = "";
            this.TextBoxProveriLozinka_Nov.Text = "";
            this.TextBoxEmail_Nov.Text = "";
            this.TextBoxKorisnickoIme_Najava.Focus();
        }
        #endregion

        #region IKorisnikLoginView
        public string UserID_Login_Input
        {
            get
            {
                return this.TextBoxKorisnickoIme_Najava.Text;
            }
            set
            {
                this.TextBoxKorisnickoIme_Najava.Text = value ;
            }
        }

        public string Lozinka_Login_Input
        {
            get
            {
                return this.TextBoxLozinka_Najava.Text;
            }
            set
            {
                this.TextBoxLozinka_Najava.Text = value;
            }
        }

        public void logirajKorisnik(ClassDLL.SysPart.Korisnik korObj)
        {
            this.Session["korisnik"] = korObj;
            Response.Redirect("KorisnikStudent.aspx");
        }
        protected void BtnNajaviSe_Click(object sender, EventArgs e)
        {
            this.korisnikPresenter.loginKorisnik();
        }
      


        public string UserId_Korisnik_AddBrz_Validacija
        {
            get
            {
               return this.lblKorisnickoIme_Nov_Validacija.Text;
            }
            set
            {
                this.lblKorisnickoIme_Nov_Validacija.Text = "*";
                this.lblSummaryValidacija.Text += value + "<br />&nbsp";
            }
        }

        public string Lozinka_Korisnik_AddBrz_Validacija
        {
            get
            {
                return this.lblLozinka_Nov_Validacija.Text;
            }
            set
            {
                this.lblLozinka_Nov_Validacija.Text = "*";
                this.lblSummaryValidacija.Text += value + "<br />&nbsp";
            }
        }

        public string LozinkaCheck_Korisnik_AddBrz_Validacija
        {
            get
            {
                return this.lblProveriLozinka_Nov_Validacija.Text;
            }
            set
            {
                this.lblProveriLozinka_Nov_Validacija.Text = "*";
                this.lblSummaryValidacija.Text += value + "<br />&nbsp";
            }
        }

        public string Email_Korisnik_AddBrz_Validacija
        {
            get
            {
                return this.lblEmail_Nov_Validacija.Text;
            }
            set
            {
                this.lblEmail_Nov_Validacija.Text = "*";
                this.lblSummaryValidacija.Text += value + "<br />&nbsp";
            }
        }

        public void ClearValidacija()
        {
            this.lblSummaryValidacija.Text="";
            this.lblEmail_Nov_Validacija.Text = "";
            this.lblKorisnickoIme_Nov_Validacija.Text = "";
            this.lblLozinka_Nov_Validacija.Text = "";
            this.lblProveriLozinka_Nov_Validacija.Text = "";
        }

        #endregion
    }
}
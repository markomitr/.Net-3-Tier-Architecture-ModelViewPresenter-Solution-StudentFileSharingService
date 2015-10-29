using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassDLL.SysPart;
using EnMkConvertor;
using Presenter.Interface;
using Presenter.Interface.Presenters;
using Presenter.Interface.Views.KorisnikViews;
using Presenter.Presenter;
using WebAppStudentDemo.Class;
namespace WebAppStudentDemo
{
    public partial class LoginStudent : Glavna,
                                 IView,IKorisnikLoginView
    {
        IKorisnikPresenter korisnikPresenter;

        public LoginStudent()
        {
            this.daliLogin = false;
            korisnikPresenter = new KorisniciPresenter(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextBoxKorisnickoIme.Focus();
        }

        #region IKorisnikLoginView Members

        public string UserID_Login_Input
        {
            get
            {
                return this.TextBoxKorisnickoIme.Text;
            }
            set
            {
                this.TextBoxKorisnickoIme.Text = value;
            }
        }

        public string Lozinka_Login_Input
        {
            get
            {
                return this.TextBoxLozinka.Text;
            }
            set
            {
                this.TextBoxLozinka.Text = value;
            }
        }
        protected void ButtonNajaviSe_Click(object sender, EventArgs e)
        {
            this.korisnikPresenter.loginKorisnik();
        }

        public void logirajKorisnik(Korisnik korObj)
        {
            this.Session["korisnik"] = korObj;
            if (Request["p"] != null)
            {
                string strana = Server.UrlDecode(Request.QueryString.ToString()).Split('/')[1];
                Response.Redirect(strana);
            }
            else
            {
                Response.Redirect("KorisnikStudent.aspx");
            }
            
        }

        #endregion
        #region IMsgStatus Members

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

        #endregion


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassDLL.SysPart;

namespace WebAppStudentDemo.Class
{
    public class Glavna : System.Web.UI.Page
    {

        Korisnik tekovenKorisnik;
        Boolean _daliLogin;

        public Glavna()
        {
            tekovenKorisnik = new Korisnik();
            this._daliLogin = true;
        }
        public Glavna(bool daliLogin)
        {
            this._daliLogin = daliLogin;
            tekovenKorisnik = new Korisnik();
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            if (Request.QueryString["lout"] != null)
            {
                Session.Remove("korisnik");
                Response.Redirect("GoodLuckStudent.aspx");
            }
            else
            {
                if (Session["korisnik"] != null)
                {
                    tekovenKorisnik = (Korisnik)Session["korisnik"];
                }
                else
                {
                    if (daliLogin)
                    {
                        Response.Redirect("LoginStudent.aspx?p=" + Server.UrlDecode(Request.RawUrl));
                    }
                }
            }
        }

        #region Properties

        public bool KorisnikDaliLogiran
        {
            get
            {
                bool daliLogiran = false;

                if (Session["korisnik"] != null)
                    daliLogiran = true;

                return daliLogiran;
            }
        }
        public Boolean daliLogin
        {
            get
            {
                return this._daliLogin;
            }
            set
            {
                this._daliLogin = value;
            }
        }
        protected Korisnik TekovenKorisnik
        {
            get 
            {
                if (Session["korisnik"] != null)
                {
                    return (Korisnik)Session["korisnik"];
                }
                else
                {
                    //treba da se frli greska ovdeka nekoja nasa - 
                    return null;
                }
            }
            set
            {
               //Za Set metoda mislam deka treaba da si izgrame so Session - da se proveri dali e taka
                Session["korisnik"] = value;
            }
        }

        #endregion
    }
}

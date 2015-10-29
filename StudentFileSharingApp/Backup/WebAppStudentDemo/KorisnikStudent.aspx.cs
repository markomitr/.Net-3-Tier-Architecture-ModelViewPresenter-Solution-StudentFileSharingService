using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassDLL.SysPart;
using EnMkConvertor;
using Presenter.Interface;
using Presenter.Interface.KorisnikViews;
using Presenter.Interface.Views.PretplataPredmetViews;
using Presenter.Presenter;
using WebAppStudentDemo.Class;


namespace WebAppStudentDemo
{
    public partial class KorisnikStudent : Glavna, IView, IKorisnikPregled1View, IKorisnikUpdateFormView, IKorisnikUpdateView, IMsgStatus, IPretplataPredmetPregled8SoIzborView
    {
        #region Presenters
        KorisniciPresenter _korisnikPresenter;
        IPresenter presKorisnik;
        PretplataPredmetPresenter pretplataPresenter;
        #endregion
        
        String UserIDEditSelected;
        String statusIzmena;

        #region PretplataPredmet-Promenlivi

        int _predmet_id_Pretplata_Predmet_selected;
        
        #endregion
        public KorisnikStudent()
        {
            this.daliLogin = true;
            this._korisnikPresenter = new KorisniciPresenter(this);
            presKorisnik = new KorisniciPresenter(this);
            pretplataPresenter = new PretplataPredmetPresenter(this);
        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (base.KorisnikDaliLogiran)
            {
                this._korisnikPresenter.getKorisnik();
                this.UserId_Korisnik_Update_Selected = this.TekovenKorisnik.UserID;
                this.statusIzmena = "false";

                if (Request.QueryString["izmeni"] != null)
                {
                    this.statusIzmena = Request.QueryString["izmeni"].ToString();
                    if (this.statusIzmena == "false")
                    {
                        ((KorisniciPresenter)presKorisnik).getKorisnik();
                    }
                    else if (this.statusIzmena == "true")
                    {
                        ((KorisniciPresenter)presKorisnik).zemiKorisnikZaEdit();
                    }

                }
                else
                {
                    ((KorisniciPresenter)presKorisnik).getKorisnik();
                }
                
                pretplataPresenter.pregled8PretplateniPredmeti();

            }
            else
            {
                Response.Write("Не е логиран коирисникот.Овде не е смее да се прикаже. Види Glavna.");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (base.KorisnikDaliLogiran)
            //{
            //    this._korisnikPresenter.getKorisnik();
            //    this.UserId_Korisnik_Update_Selected = this.TekovenKorisnik.UserID;
            //    this.statusIzmena = "false";

            //    if (Request.QueryString["izmeni"] != null)
            //    {
            //        this.statusIzmena = Request.QueryString["izmeni"].ToString();
            //    }

            //    ((KorisniciPresenter)presKorisnik).zemiKorisnikZaEdit();
            //    pretplataPresenter.pregled8PretplateniPredmeti();

            //}
            //else
            //{
            //    Response.Write("Не е логиран коирисникот.Овде не е смее да се прикаже. Види Glavna.");
            //}
            
        }

        #region IKorisnikPregled1View Members

        public string UserID_Korisnik_Pregled_Selected
        {
            get
            {
                return base.TekovenKorisnik.UserID;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregledZaKorisnik(Korisnik korObj)
        {
            this.profilPregled.Controls.Clear();
            this.profilPregled.Controls.Add(NacrtajKorisnikPregled(korObj));

            
            this.licniPodatoci.Controls.Add(NacrtajKorisnikSamoPregled(korObj));
            this.smetka.Controls.Add(NacrtajKorisnikPregledZaIzmena(korObj));
        }

        LiteralControl NacrtajKorisnikPregled(Korisnik korObj)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div id=\"KorisnikPregled\">");

            sb.Append("<div id=\"IDiLogOut\">");
            sb.Append("<span id=\"KorisnikUserID\">");
            sb.Append("Најавени сте како: <b>");
            sb.Append(korObj.UserID);
            sb.Append("</b> | ");
            sb.Append("</span>");

            sb.Append("</span>");
            sb.Append("<span id=\"LogOut\">");
            sb.Append("<a href=\"?lout=D\">Одјави се</a>");
            sb.Append("</span>");
            sb.Append("</div>");
            
            sb.Append("<div id=\"ImeIPrezime\">");
            sb.Append("<span id=\"KorisnikIme\">");
            if (String.IsNullOrEmpty(korObj.Ime))
            {
                sb.Append("<a href=\"#\">Немате внесено име.</a>");
            }
            else
            {
                sb.Append("Име: ");
                sb.Append("<b>");
                sb.Append(korObj.Ime);
                sb.Append("</b>");
                sb.Append(" | ");
            }
            sb.Append("</span>");

            sb.Append("<span id=\"KorisnikPrezime\">");
            if (String.IsNullOrEmpty(korObj.Prezime))
            {
                sb.Append("<a href=\"#\">Немате внесено презиме.</a>");
            }
            else
            {
                sb.Append("Презиме: ");
                sb.Append("<b>");
                sb.Append(korObj.Prezime);
                sb.Append("</b>");

            }
            sb.Append("</div>");

            sb.Append("</div>");

            return new LiteralControl(sb.ToString());
        }

        LiteralControl NacrtajKorisnikSamoPregled(Korisnik korObj)
        {
            StringBuilder sb = new StringBuilder();

            //if (Request.QueryString["izmeni"] != null && Request.QueryString["izmeni"]== "false")
            //{
            if (this.statusIzmena == "false")
            {
                this.licniPodatoci.Controls.Clear();
                sb.Append("<fieldset>");
                sb.Append("<legend>Лични податоци</legend>");
                sb.Append("Име: ");
                sb.Append("<br />");
                sb.Append("<b>");
                sb.Append(korObj.Ime);
                sb.Append("</b>");
                sb.Append("<br /><br />");
                sb.Append("Презиме: ");
                sb.Append("<br />");
                sb.Append("<b>");
                sb.Append(korObj.Prezime);
                sb.Append("</b>");
                sb.Append("<br /><br />");
                sb.Append("Емаил: ");
                sb.Append("<br />");
                sb.Append("<b>");
                sb.Append(korObj.Email);
                sb.Append("</b>");
                sb.Append("<br /><br />");
                sb.Append("</fieldset>");
            }                      
            //}         

            return new LiteralControl(sb.ToString());
        }

        LiteralControl NacrtajKorisnikPregledZaIzmena(Korisnik korObj)
        {
            StringBuilder sb = new StringBuilder();

            //if (Request.QueryString["izmeni"] != null && Request.QueryString["izmeni"] == "false")
            //{
            if (this.statusIzmena == "false")
            {
                this.smetka.Controls.Clear();
                sb.Append("<fieldset>");
                sb.Append("<legend>Податоци за сметката</legend>");
                sb.Append("Корисничко име: ");
                sb.Append("<br />");
                sb.Append("<b>");
                sb.Append(korObj.UserID);
                sb.Append("</b>");                             
                sb.Append("<br /><br />");
                sb.Append("Изменета на: ");
                sb.Append("<br />");
                sb.Append("<b>");
                sb.Append(korObj.IzmenetNa);
                sb.Append("</b>");
                sb.Append("<br /><br />");
                sb.Append("</fieldset>");
            }
            //}

            return new LiteralControl(sb.ToString());
        }


        #endregion

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
            //this.profilPregled.Controls.Clear();
            //if (this.statusIzmena == "false")
            //{
            //    this.TextBoxKorisnickoIme.Text = korObj.UserID;
            //    this.TextBoxKorisnickoIme.Enabled = false;
            //    this.TextBoxLozinka.Text = korObj.Lozinka;
            //    this.TextBoxLozinka.Enabled = false;
            //    this.TextBoxEmail.Text = korObj.Email;
            //    this.TextBoxEmail.Enabled = false;
            //    this.TextBoxIme.Text = korObj.Ime;
            //    this.TextBoxIme.Enabled = false;
            //    this.TextBoxPrezime.Text = korObj.Prezime;
            //    this.TextBoxPrezime.Enabled = false;
            //    this.ButtonZacuvajIzmeni.Enabled = false;
            //}else if (this.statusIzmena == "true")
            //{
            if (this.statusIzmena == "true")
            {
                this.TextBoxKorisnickoIme.Text = korObj.UserID;
                this.TextBoxKorisnickoIme.Enabled = false;                
                this.TextBoxEmail.Text = korObj.Email;
                this.TextBoxIme.Text = korObj.Ime;
                this.TextBoxPrezime.Text = korObj.Prezime;
            }
            //}
        }
        #endregion



        #region IKorisnikUpdateView
        public string UserId_Korisnik_Update_Selected
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

        public string UserId_Korisnik_Update_Input
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


        public string Email_Korisnik_Update_Input
        {
            get
            {
                return this.TextBoxEmail.Text;
            }
            set
            {
                this.TextBoxEmail.Text = value;
            }
        }

        public string Ime_Korisnik_Update_Input
        {
            get
            {
                return this.TextBoxIme.Text;
            }
            set
            {
                this.TextBoxIme.Text = value;
            }
        }

        public string Prezime_Korisnik_Update_Input
        {
            get
            {
                return this.TextBoxPrezime.Text;
            }
            set
            {
                this.TextBoxPrezime.Text = value;
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
                this.LabelaGlobalnaGreska.Text =EnMk.CistoKonv( value);
            }
        }
        #endregion

        protected void ButtonZacuvajIzmeni_Click(object sender, EventArgs e)
        {
            ((KorisniciPresenter)presKorisnik).updateKorisnik();
        }

        #region IPretplataPredmetPregled8SoIzborView Members

        public string Korisnik_ID_PretplataPredmet_PregledIzbor_Input
        {
            get
            {
                return this.UserId_Korisnik_Update_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int PredmetID_PretplataPredmet_PregledIzbor_Selected
        {
            get
            {
                return this._predmet_id_Pretplata_Predmet_selected;
            }
            set
            {
                this._predmet_id_Pretplata_Predmet_selected = value;
            }
        }

        public void nacrtajPregledSoIzborPretplateniPredmeti(List<PretplatenPredmet> listaPredmeti)
        {
            this.IzborPretplateniPredmeti.Controls.Clear();
            foreach (PretplatenPredmet pretplatenPredmet in listaPredmeti)
            {
                this.IzborPretplateniPredmeti.Controls.Add(nacrtajPretplatenPredmet(pretplatenPredmet));
            }
        }
        LiteralControl nacrtajPretplatenPredmet(PretplatenPredmet pretplatenPredmet)
        {

            StringBuilder sb = new StringBuilder();

            //sb.Append("<div id=\"PredmetIzbor\">");
            //sb.Append("<img src=\"Sliki/institucija.jpg\"/>");


            sb.Append("<div id=\"IzbranPredmet\">");
            sb.Append("<div id=\"IzbranPredmetIme\">");
            sb.Append("<span id=\"PredmetIme\">");
            sb.Append(pretplatenPredmet.PredmetNasoka.PredmetIme);
            sb.Append("</span>");
            sb.Append("</div>");
            sb.Append("<div id=\"IzbranPredmetOpis\">");
            sb.Append("</div>");
            sb.Append("</div>");
            
            /* // Opisot ne ni treba sega
            
            sb.Append("<span id=\"PredmetOpis\">");
            sb.Append(pretplatenPredmet.PredmetNasoka.PredmetOpis);
            sb.Append("</span>");
            
             */
            //sb.Append("</div>");
            return new LiteralControl("<a href=\"PredmetStudent.aspx?NasID=" + pretplatenPredmet.PredmetNasoka.NasokaID + "&PredId=" + pretplatenPredmet.PredmetNasoka.PredmetID + "\" >" + sb.ToString() + "</a>");
        }
        protected void btnListajPretplateni_Click(object sender, EventArgs e)
        {
            pretplataPresenter.pregled8PretplateniPredmeti();
        }
        #endregion
    }
}
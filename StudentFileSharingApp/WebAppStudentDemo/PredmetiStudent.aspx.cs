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
using Presenter.Interface.Presenters;
using Presenter.Interface.Views.CompositeViews;
using Presenter.Interface.Views.InstitucijaViews;
using Presenter.Interface.Views.NasokaViews;
using Presenter.Interface.Views.OblastViews;
using Presenter.Interface.Views.PredmetViews;
using Presenter.Interface.Views.PretplataPredmetViews;
using Presenter.Interface.Views.UstanovaViews;
using Presenter.Presenter;
using WebAppStudentDemo.Class;

namespace WebAppStudentDemo
{
    public partial class PredmetiStudent : Glavna,
                                           IView, IKorisnikPregled1View, IInstitucijaPregled8SoIzborView, IIUONIzborView,
                                           IPretplataPredmetAddView, INePretplataPredmetPregled8SoIzborView 
                                           //,IPretplataPredmetPregled8SoIzborView 
    {

        #region IUION.Filter-Promenlivi
        int id_institucija_izborfilter_selected;
        int id_ustanova_izborfilter_selected;
        int id_oblast_izborfilter_selected;
        int id_nasoka_izborfilter_selected;
        #endregion

        #region PretplataPredmet-Promenlivi
        int _predmet_id_NePretplata_Predmet_selected;
        //int _predmet_id_Pretplata_Predmet_selected;
        #endregion
        #region Presenters

        KorisniciPresenter _korisnikPresenter;
        IInstitucijaPresenter institucijaPresenter;
        IUstanovaPresenter ustanovaPresenter;
        IOblastPresenter oblastPresenter;
        INasokaPresenter nasokaPresenter;
        PretplataPredmetPresenter pretplataPresenter;
        #endregion

        public PredmetiStudent()
        {
            this.daliLogin = true;
            
            this._korisnikPresenter = new KorisniciPresenter(this);
            institucijaPresenter = new InstitucjaPresenter(this);
            ustanovaPresenter = new UstanovaPresenter(this);
            oblastPresenter = new OblastPresenter(this);
            nasokaPresenter = new NasokaPresenter(this);
            pretplataPresenter = new PretplataPredmetPresenter(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (base.KorisnikDaliLogiran)
            {
                this._korisnikPresenter.getKorisnik();

                SetirajPromenlivi();
                institucijaPresenter.pregled8soIzborInstitucii();
                SetAktivenSlide(1);
                if (Request.QueryString["InstID"] != null)
                {
                    ustanovaPresenter.pregled8UstanoviSoFilter();
                    SetAktivenSlide(2);
                    if (Request.QueryString["UstID"] != null)
                    {
                        oblastPresenter.pregledOblastiSoFilter();
                        SetAktivenSlide(3);
                        if (Request.QueryString["OblID"] != null)
                        {
                            nasokaPresenter.pregled8NasokiSoFilter();
                            SetAktivenSlide(4);
                            if (Request.QueryString["NasID"] != null)
                            {
                                pretplataPresenter.pregled8NePretplateniPredmeti();
                                
                                if (Request.QueryString["PredID"] != null)
                                {
                                    pretplataPresenter.PretplatiKorisnikNaPredmet();
                                    pretplataPresenter.pregled8NePretplateniPredmeti();
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                Response.Write("Не е логиран Овдека не смејт да дојТ. Види Glavna.");
            }
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


            sb.Append("<span id=\"VratiSeProfil\">");
            sb.Append("<a href=\"KorisnikStudent.aspx?izmeni=false\">");
            sb.Append("Профил");
            sb.Append("</a>");
            sb.Append("</span>");
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
            sb.Append("</span>");
            sb.Append("</div>");

            sb.Append("</div>");

            return new LiteralControl(sb.ToString());
        }
        #endregion



        void SetirajPromenlivi()
        {
            if (Request.QueryString["InstID"] != null)
            {
                this.ID_Institucija_Izbor_Selected = int.Parse(Request.QueryString["InstID"].ToString());
            }
            if (Request.QueryString["UstID"] != null)
            {
                this.ID_Ustanova_UstanovaFilter_Selected = int.Parse(Request.QueryString["UstID"].ToString());
            }
            if (Request.QueryString["OblID"] != null)
            {
                this.ID_Oblast_OblastFilter_Selected = int.Parse(Request.QueryString["OblID"].ToString());
            }
            if (Request.QueryString["NasID"] != null)
            {
                this.ID_Nasoka_NasokaFilter_Selected = int.Parse(Request.QueryString["NasID"].ToString());
            }
            if (Request.QueryString["PredID"] != null)
            {
                this.PredmetID_NePretplataPredmet_PregledIzbor_Selected = int.Parse(Request.QueryString["PredID"].ToString());
            }
        }

        void SetAktivenSlide(int koj)
        {
            this.spanInstitucija.Attributes["class"] = TrgniKlasa("aktiven", this.spanInstitucija.Attributes["class"].Split(' ').ToArray());
            this.spanUstanova.Attributes["class"] = TrgniKlasa("aktiven", this.spanUstanova.Attributes["class"].Split(' ').ToArray());
            this.spanOblast.Attributes["class"] = TrgniKlasa("aktiven", this.spanOblast.Attributes["class"].Split(' ').ToArray());
            this.spanNasoka.Attributes["class"] = TrgniKlasa("aktiven", this.spanNasoka.Attributes["class"].Split(' ').ToArray());
            switch (koj)
            {
                case 1:
                    {
                        this.spanInstitucija.Attributes["class"] += " aktiven";
                        break;
                    }
                case 2:
                    {
                        this.spanUstanova.Attributes["class"] += " aktiven";
                        break;
                    }
                case 3:
                    {
                        this.spanOblast.Attributes["class"] += " aktiven";
                        break;
                    }
                case 4:
                    {
                        this.spanNasoka.Attributes["class"] += " aktiven";
                        break;
                    }
            }
        }
        String TrgniKlasa(string klasa, String[] lista)
        {
            String rez = "";
            foreach (String item in lista)
            {
                if (item.ToLower().Trim() != klasa.ToLower().Trim())
                {
                    rez += item + " ";
                }
            }

            return rez;
        }
        
        
        #region IInstitucijaPregled8SoIzborView
        public int ID_Institucija_Izbor_Selected
        {
            get
            {

                return this.id_institucija_izborfilter_selected;
            }
            set
            {
                try
                {
                    int pom = int.Parse(value.ToString());
                    this.id_institucija_izborfilter_selected = pom;
                }
                catch (Exception ex)
                {
                    this.id_institucija_izborfilter_selected = -1;
                }
            }
        }

        public void nacrtajPregled8InstituciiSoIzbor(List<Institucija> instList)
        {
            //ova za da go polne combobox za izbor pri add
            this.IzborInstitucija.Controls.Clear();
            
            foreach (Institucija instObj in instList)
            {

                this.IzborInstitucija.Controls.Add(nacrtajIntitucija(instObj));
            }

        }
        LiteralControl nacrtajIntitucija(Institucija instObj)
        {

            StringBuilder sb = new StringBuilder();
            string klasa = "";
            if (this.ID_Institucija_Izbor_Selected == instObj.ID)
            {
                klasa = "Selected";
            }
            sb.Append("<div id=\"InstitucijaIzbor\" class=\"" + klasa + "\">");
            sb.Append("<span id=\"InstitucijaKratenka\">");
            sb.Append(instObj.Kratenka);
            sb.Append("</span>");            
            sb.Append("<span id=\"InstitucijaIme\">");
            sb.Append(instObj.Ime);
            sb.Append("</span><br />");
            sb.Append("<span id=\"InstitucijaAdresa\">");
            sb.Append(instObj.Adresa);
            sb.Append("</span>");
            sb.Append("</div>");
            return new LiteralControl("<a href=\"PredmetiStudent.aspx?InstID="+ instObj.ID +"\">" +sb.ToString() +"</a>");
        }
        #endregion
        #region IUstanovaPregled8SoFilterView
        public int ID_Ustanova_UstanovaFilter_Selected
        {
            get
            {


                return this.id_ustanova_izborfilter_selected;
            }
            set
            {
                this.id_ustanova_izborfilter_selected = value;
            }
        }
        public int ID_Institucuja_UstanovaFilter_Selected
        {
            get
            {
                return this.ID_Institucija_Izbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajUstanovaSoFilter(List<Ustanova> listaUstanovi)
        {

            this.IzborUstanova.Controls.Clear();

            foreach (Ustanova ustanovaObj in listaUstanovi)
            {

                this.IzborUstanova.Controls.Add(nacrtajUstanova(ustanovaObj));
            }

        }
        LiteralControl nacrtajUstanova(Ustanova ustanovaObj)
        {

            StringBuilder sb = new StringBuilder();
            string klasa = "";
            if (this.ID_Ustanova_UstanovaFilter_Selected == ustanovaObj.UstanovaID)
            {
                klasa = "Selected";
            }
            sb.Append("<div id=\"UstanovaIzbor\" class=\"" + klasa + "\">");            
            sb.Append("<span id=\"UstanovaIme\">");
            sb.Append(ustanovaObj.Ime);
            sb.Append("</span><br />");
            sb.Append("<span id=\"UstanovaAdresa\">");
            sb.Append(ustanovaObj.Adresa);
            sb.Append("</span><br />");
             sb.Append("<span id=\"UstanovaWebStrana\">");
            sb.Append(ustanovaObj.WebStrana);
            sb.Append("</span>");
            sb.Append("</div>");
            return new LiteralControl("<a href=\"PredmetiStudent.aspx?InstID=" + ustanovaObj.Institucija_ID + "&UstID=" + ustanovaObj.UstanovaID + "\">" + sb.ToString() + "</a>");
        }
        #endregion
        #region IOblastPregledSoFilterView
        public int ID_Ustanova_OblastFilter_Selected
        {
            get
            {
                return this.ID_Ustanova_UstanovaFilter_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int ID_Oblast_OblastFilter_Selected
        {
            get
            {

                return this.id_oblast_izborfilter_selected;
            }
            set
            {
                this.id_oblast_izborfilter_selected = value;
            }
        }

        public void nacrtajPregledOblastiSoFilter(List<Oblast> oblastiList)
        {

            this.IzborOblast.Controls.Clear();
            foreach (Oblast oblastObj in oblastiList)
            {
                this.IzborOblast.Controls.Add(nacrtajOblast(oblastObj));
            }

        }
        LiteralControl nacrtajOblast(Oblast oblastObj)
        {

            StringBuilder sb = new StringBuilder();
            string klasa = "";
            if (this.ID_Oblast_NasokaFilter_Selected == oblastObj.OblastID)
            {
                klasa = "Selected";
            }
            sb.Append("<div id=\"OblastIzbor\" class=\"" + klasa + "\">");
            sb.Append("<span id=\"OblastIme\">");
            sb.Append(oblastObj.Ime);
            sb.Append("</span><br />");
            sb.Append("<span id=\"OblastAdresa\">");
            sb.Append(oblastObj.Adresa);
            sb.Append("</span><br />");
            sb.Append("<span id=\"OblastWebStrana\">");
            sb.Append(oblastObj.WebStrana);
            sb.Append("</span>");
            sb.Append("</div>");
            return new LiteralControl("<a href=\"PredmetiStudent.aspx?InstID=" + this.ID_Institucija_Izbor_Selected + "&UstID=" + this.ID_Ustanova_UstanovaFilter_Selected + "&OblID="+ oblastObj.OblastID +"\">" + sb.ToString() + "</a>");
        }
        #endregion
        #region INasokaPregledSoFilterView
        public int ID_Nasoka_NasokaFilter_Selected
        {
            get
            {
                return this.id_nasoka_izborfilter_selected;
            }
            set
            {
                this.id_nasoka_izborfilter_selected = value;
            }
        }

        public int ID_Oblast_NasokaFilter_Selected
        {
            get
            {
                return this.ID_Oblast_OblastFilter_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajNasokaSoFilter(List<Nasoka> listaNasoki)
        {

            this.IzborNasoka.Controls.Clear();
            foreach (Nasoka nasokaObj in listaNasoki)
            {
                this.IzborNasoka.Controls.Add( nacrtajNasoka(nasokaObj));
            }

        }
        LiteralControl nacrtajNasoka(Nasoka nasokaObj)
        {

            StringBuilder sb = new StringBuilder();
            string klasa = "";
            if (this.ID_Nasoka_NasokaFilter_Selected == nasokaObj.NasokaID)
            {
                klasa = "Selected";
            }
            sb.Append("<div id=\"NasokaIzbor\" class=\"" + klasa + "\">");             
            sb.Append("<span id=\"NasokaIme\">");
            sb.Append(nasokaObj.Ime);
            sb.Append("</span><br />");
            sb.Append("<span id=\"NasokaOpis\">");
            sb.Append(nasokaObj.Opis);
            sb.Append("</span>");
            sb.Append("</div>");
            return new LiteralControl("<a href=\"PredmetiStudent.aspx?InstID=" + this.ID_Institucija_Izbor_Selected + "&UstID=" + this.ID_Ustanova_UstanovaFilter_Selected + "&OblID=" + this.ID_Oblast_OblastFilter_Selected + "&NasID="+ nasokaObj.NasokaID +"\">" + sb.ToString() + "</a>");
        }

        #endregion

        #region IMsgStatus Members

        public string ErrorPoraka
        {
            get
            {
                return this.lblStatus.Text;
            }
            set
            {
                lblStatus.Text = EnMk.CistoKonv(value);
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
                lblStatus.Text = EnMk.CistoKonv(value);
            }
        }

        #endregion


        #region IPretplataPredmetAddView Members

        public string KorisnikID_PretplataPredmet_Add_Input
        {
            get
            {
                if (base.KorisnikDaliLogiran)
                {
                    return base.TekovenKorisnik.UserID;
                }
                else
                {
                    //treba da se frli nas exception deka korisnikot ne e logiran
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int NasokaID_PretplataPredmet_Add_Input
        {
            get
            {
                return this.ID_Nasoka_NasokaFilter_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int PredmetID_PretplataPredmet_Add_Input
        {
            get
            {
                return this.PredmetID_NePretplataPredmet_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajFormaZaAddPretplataPredmet()
        {
            //Imeplemenitrana e vo stranata
        }

        #endregion

        #region INePretplataPredmetPregled8SoIzborView Members

        public string Korisnik_ID_NePretplataPredmet_PregledIzbor_Input
        {
            get
            {
                return this.KorisnikID_PretplataPredmet_Add_Input;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int? OblastID_NePretplataPredmet_PregledIzbor_Input
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int? NasokaID_NePretplataPredmet_PregledIzbor_Input
        {
            get
            {
                return this.NasokaID_PretplataPredmet_Add_Input;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int PredmetID_NePretplataPredmet_PregledIzbor_Selected
        {
            get
            {
                return this._predmet_id_NePretplata_Predmet_selected;
            }
            set
            {
                this._predmet_id_NePretplata_Predmet_selected = value;
            }
        }

        public void nacrtajPregledSoIzborNePretplateniPredmeti(List<PredmetNasoka> listaPredmeti)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<span id=\"tekstNePretplateni\" class=\"tekstUpastvo\">");
            sb.Append("Со кликнување врз некој од долунаведените предмети добивате пристап до сите материјали(предавања, испити, ливчина за препишување ..) а исто така и ќе добивате известувања за предметот(кога се полага , како да препишувате и т.н).");
            sb.Append("<br />");
            sb.Append("</span>");

            this.IzborNePretplaten.Controls.Clear();
            this.IzborNePretplaten.Controls.Add(new LiteralControl(sb.ToString()));
            foreach (PredmetNasoka nepretplatenObj in listaPredmeti)
            {
                this.IzborNePretplaten.Controls.Add(nacrtajPredmetNasoka(nepretplatenObj));
            }
        }

        LiteralControl nacrtajPredmetNasoka(PredmetNasoka nepretplatenObj)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("<div id=\"PredmetIzbor\">");            
            sb.Append("<span id=\"PredmetIme\">");
            sb.Append(nepretplatenObj.PredmetIme);
            sb.Append("</span>");
            sb.Append("<span id=\"PredmetOpis\">");
            sb.Append(nepretplatenObj.PredmetOpis);
            sb.Append("</span>");
            sb.Append("</div>");
            return new LiteralControl("<a href=\"PredmetiStudent.aspx?InstID=" + this.ID_Institucija_Izbor_Selected + "&UstID=" + this.ID_Ustanova_UstanovaFilter_Selected + "&OblID=" + this.ID_Oblast_OblastFilter_Selected + "&NasID=" + this.ID_Nasoka_NasokaFilter_Selected + "&PredID=" +nepretplatenObj.PredmetID + "\">" + sb.ToString() + "</a>");
        }

        #endregion


        /*
        #region IPretplataPredmetPregled8SoIzborView Members

        public string Korisnik_ID_PretplataPredmet_PregledIzbor_Input
        {
            get
            {
                return this.KorisnikID_PretplataPredmet_Add_Input;
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

            sb.Append("<div id=\"PredmetIzbor\">");
            sb.Append("<img src=\"Sliki/institucija.jpg\"/>");
            
            sb.Append("<span id=\"PredmetIme\">");
            sb.Append(pretplatenPredmet.PredmetNasoka.PredmetIme);
            sb.Append("</span>");

            sb.Append("<span id=\"PredmetOpis\">");
            sb.Append(pretplatenPredmet.PredmetNasoka.PredmetOpis);
            sb.Append("</span>");
            
            sb.Append("</div>");
            return new LiteralControl("<a href=\"PredmetStudent.aspx?NasID="+ pretplatenPredmet.PredmetNasoka.NasokaID+"&PredId="+pretplatenPredmet.PredmetNasoka.PredmetID +"\" >"+sb.ToString()+"</a>");
        }
        protected void btnListajPretplateni_Click(object sender, EventArgs e)
        {
            pretplataPresenter.pregled8PretplateniPredmeti();
        }
        #endregion
         * 
         * */
    }
}

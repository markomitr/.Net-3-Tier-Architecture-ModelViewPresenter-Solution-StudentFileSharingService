using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassDLL.GreskiEX;
using ClassDLL.SysPart;
using EnMkConvertor;
using Presenter.Interface;
using Presenter.Interface.KorisnikViews;
using Presenter.Interface.Presenters;
using Presenter.Interface.Views.CompositeViews;
using Presenter.Interface.Views.MaterijaliPredmetiViews;
using Presenter.Interface.Views.MaterijalViews;
using Presenter.Interface.Views.NasokaPredmetDelViews;
using Presenter.Interface.Views.PorakaViews;
using Presenter.Presenter;
using WebAppStudentDemo.Class;

namespace WebAppStudentDemo
{
    public partial class PredmetStudent : Glavna,IView,IKorisnikPregled1View,
                                            INPDPregled1SoIzborView, IMaterijaliPredmetPregled8SoIzborView, 
                                            IPorakaPredmetAddView,IPorakaPredmetPregled8View ,
                                            IMaterijalPregled1View,IMaterijaliZgolemiDownloadView,
                                            IMaterijaliPredmetAddRejtingView, IPredmetNasokaPregled1View
    {
        KorisniciPresenter _korisnikPresenter;
        NasokaPresenter _nasokaPresenter;
        MaterijalPresenter _materijaliPresenter;
        PorakaPresenter _porakaPresenter;

        #region IUNPD.Promenlivi
        int _id_predmet_NPD_selected;
        int _id_nasoka_NPD_selected;
        int _id_del_NPD_selected;
        int _id_materijal_NPD_selected;
        #endregion

        RejtingTip _tipNaRejtingZaMaterijal;
        public PredmetStudent()
        {
            this.daliLogin = true;
            this._korisnikPresenter = new KorisniciPresenter(this);
            this._nasokaPresenter = new NasokaPresenter(this);
            this._materijaliPresenter = new MaterijalPresenter(this);
            this._porakaPresenter = new PorakaPresenter(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.KorisnikDaliLogiran)
            {
                this._korisnikPresenter.getKorisnik();
                

                if (Request.QueryString["NasID"] != null)
                {
                    this.Nasoka_ID_NPD_Pregled_Selected = int.Parse(Request.QueryString["NasID"].ToString());

                    if (Request.QueryString["PredID"] != null)
                    {
                        this.Predmet_ID_NPD_Pregled_Selected = int.Parse(Request.QueryString["PredID"].ToString());

                        this._porakaPresenter.getPorakiPredmet();

                        this._nasokaPresenter.pregled1DeloviZaPredmetPoNasoka();

                        this._nasokaPresenter.pregled1PredmetNasoka();

                        if (Request.QueryString["DelID"] != null)
                        {
                            this.Del_ID_NPD_PregledIzbor_Selected = int.Parse(Request.QueryString["DelID"].ToString());
                            this._materijaliPresenter.pregled8MaterijaliPredmetSoIzbor();

                            if (Request.QueryString["MatID"] != null)
                            {
                                this.ID_Materijal_MaterijaliPredmet_PregledIzbor_Selected = int.Parse(Request.QueryString["MatID"].ToString());

                                if (Request.QueryString["Get"] != null && Request.QueryString["Get"].ToString()=="1")
                                {
                                    _materijaliPresenter.pregled1Materijal();
                                }
                                if (Request.QueryString["Rejting"] != null)
                                {
                                    try
                                    {
                                        Char _rejting = char.Parse(Request.QueryString["Rejting"].ToString());
                                        if (_rejting == 'D')
                                        {
                                            this.TipNaRejting_MaterijaliPredmet = RejtingTip.Pozitiven;
                                        }
                                        else
                                        {
                                            this.TipNaRejting_MaterijaliPredmet = RejtingTip.Negativen;
                                        }
                                        _materijaliPresenter.addRejtingMaterijal();
                                        
                                    }
                                    catch (Exception ex)
                                    {
                                        
                                        //throw;
                                    }
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
            sb.Append("</div>");

            sb.Append("</div>");

            return new LiteralControl(sb.ToString());
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
                this.lblStatus.Text = EnMk.CistoKonv(value);
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
                this.lblStatus.Text = EnMk.CistoKonv(value);
            }
        }

        #endregion

        #region INPDPregled1SoIzborView Members

        public int Nasoka_ID_NPD_Pregled_Selected
        {
            get
            {
                return this._id_nasoka_NPD_selected;
            }
            set
            {
                this._id_nasoka_NPD_selected = value;
            }
        }

        public int Predmet_ID_NPD_Pregled_Selected
        {
            get
            {
                return this._id_predmet_NPD_selected;
            }
            set
            {
                this._id_predmet_NPD_selected = value;
            }
        }

        public int Nasoka_ID_NPD_PregledIzbor_Selected
        {
            get
            {
                return this.Nasoka_ID_NPD_Pregled_Selected;
            }
            set
            {
                this.Nasoka_ID_NPD_Pregled_Selected = value;
            }
        }

        public int Predmet_ID_NPD_PregledIzbor_Selected
        {
            get
            {
                return this.Predmet_ID_NPD_Pregled_Selected;
            }
            set
            {
                this.Predmet_ID_NPD_Pregled_Selected = value;
            }
        }

        public int Del_ID_NPD_PregledIzbor_Selected
        {
            get
            {
                return this._id_del_NPD_selected;
            }
            set
            {
                this._id_del_NPD_selected = value;
            }
        }

        public void nacrtajPregledDelovizaPredmetiZaNasokaSoIzbor(List<DeloviPredmetNasoka> dpnList)
        {
            
            int i = 0;
            this.deloviIzbor.Controls.Clear();
            foreach (DeloviPredmetNasoka delObj in dpnList)
            {
                String kategorija = "";
                kategorija += "kategorija" + ((i % 8) + 1).ToString();
                i++;
                this.deloviIzbor.Controls.Add(NacrtajDeloviPredmetNasoka(delObj.Del, delObj.Nasoka_ID, kategorija, i));
            }
        }
        LiteralControl NacrtajDeloviPredmetNasoka(Del delObj,int nasokaID, String kategorija, int broj)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<li id=\"" + kategorija + "\">");
            sb.Append(delObj.Ime);
            sb.Append("</li>");

            return new LiteralControl("<a href=\"PredmetStudent.aspx?NasID=" + this.Nasoka_ID_NPD_Pregled_Selected + "&PredID=" + this.Predmet_ID_NPD_Pregled_Selected + "&DelID=" + delObj.ID + "\">" + sb.ToString() + "</a>");
        }
        #endregion

        #region IMaterijaliPredmetPregled8SoIzborView Members

        public int Nasoka_ID_MaterijaliPredmet_PregledIzbor_Input
        {
            get
            {
                return this.Nasoka_ID_NPD_Pregled_Selected;
            }
            set
            {
                this.Nasoka_ID_NPD_Pregled_Selected = value;
            }
        }

        public int Predmet_ID_MaterijaliPredmet_PregledIzbor_Input
        {
            get
            {
                return this.Predmet_ID_NPD_Pregled_Selected;
            }
            set
            {
                this.Predmet_ID_NPD_Pregled_Selected = value;
            }
        }

        public int Del_ID_MaterijaliPredmet_PregledIzbor_Input
        {
            get
            {
                return this.Del_ID_NPD_PregledIzbor_Selected;
            }
            set
            {
                this.Del_ID_NPD_PregledIzbor_Selected = value;
            }
        }

        public int ID_Materijal_MaterijaliPredmet_PregledIzbor_Selected
        {
            get
            {
                return this._id_materijal_NPD_selected;
            }
            set
            {
                this._id_materijal_NPD_selected = value;
            }
        }

        public void nacrtajPregledSoIzborMaterijaliPredmet(MaterijaliGrupirani materijaliGrupirani)
        {
            this.materijaliIzbor.Controls.Clear();

            if (materijaliGrupirani.DeloviMaterijali.Count == 0 && materijaliGrupirani.Materijali.Count == 0)
            {
                this.materijaliIzbor.Controls.Add(new LiteralControl("Извини ! Нема материјали."));
            }
            else
            {
                foreach (DelMaterijali matDelovi in materijaliGrupirani.DeloviMaterijali)
                {
                    foreach (Materijal item in matDelovi.Materijali)
                    {
                        this.materijaliIzbor.Controls.Add(NacrtajMaterijali(item));
                    }
                }
            }
        }
        LiteralControl NacrtajMaterijali(Materijal matObj)
        {
            String patekaSlikaPrevzemi = "<img src=\"Sliki/PredmetStudentSliki/prevzemi.png\" alt=\"превземи\" />";
            String patekaDownloadIkona = "<img src=\"Sliki/PredmetStudentSliki/downloadIkona.png\" alt=\"превземи\" />";
            String patekaDobarIkona = "<img src=\"Sliki/PredmetStudentSliki/likeIkona.png\" alt=\"превземи\" />";
            String patekaLosIkona = "<img src=\"Sliki/PredmetStudentSliki/dislikeIkona.png\" alt=\"превземи\" />";

            StringBuilder sb = new StringBuilder();
            
            sb.Append("<div id=\"MaterijalPregled\">");

            sb.Append("<span id=\"MaterijalSlikaTip\">");
            sb.Append("<img src=\"Sliki/PredmetStudentSliki/");
            if (matObj.TypeEnum == MaterijalTip.Slika)
            {
                sb.Append("Slika.png");
            }
            else if (matObj.TypeEnum == MaterijalTip.Word)
            {
                sb.Append("Word.png");
            }
            else if (matObj.TypeEnum == MaterijalTip.Excel)
            {
                sb.Append("Excel.png");
            }
            else if (matObj.TypeEnum == MaterijalTip.Arhiva)
            {
                sb.Append("Arhiva.png");
            }
            else if (matObj.TypeEnum == MaterijalTip.PowerPoint)
            {
                sb.Append("PowerPoint.png");
            }
            else if (matObj.TypeEnum == MaterijalTip.Pdf)
            {
                sb.Append("Pdf.png");
            }
            else if (matObj.TypeEnum == MaterijalTip.Text)
            {
                sb.Append("Text.png");
            }
            else if (matObj.TypeEnum == MaterijalTip.Html)
            {
                sb.Append("Html.png");
            }
            else
            {
                sb.Append("Nepoznat.png");
            }
            sb.Append("\"/>");
            sb.Append("</span>");
 
            sb.Append("<span id=\"MaterijalNaslov\">");
            sb.Append("<a href=\"PredmetStudent.aspx?NasID=" + this.Nasoka_ID_NPD_Pregled_Selected + "&PredID=" + this.Predmet_ID_NPD_Pregled_Selected + "&DelID=" + this.Del_ID_NPD_PregledIzbor_Selected + "&MatID=" + matObj.MaterijalID + "\">");
            sb.Append(matObj.Naslov);
            sb.Append("</a>");
            sb.Append("</span>");
            

            sb.Append("<span id=\"MaterijalOpis\">");
            sb.Append("<p>");
            sb.Append(matObj.Opis);
            sb.Append("</p>");
            sb.Append("</span>");
            sb.Append("<br /><span id=\"MaterijalDownload\">");
            sb.Append("<a href=\"PredmetStudent.aspx?NasID=" + this.Nasoka_ID_NPD_Pregled_Selected + "&PredID=" + this.Predmet_ID_NPD_Pregled_Selected + "&DelID=" + this.Del_ID_NPD_PregledIzbor_Selected + "&MatID=" + matObj.MaterijalID + "&Get=1\">" + patekaSlikaPrevzemi + "</a>");
            sb.Append("</span>");

            sb.Append("<div id=\"DownloadLenta\">");                 

            sb.Append("<span id=\"LosRejtingMaterijal\">");
            sb.Append("<a href=\"PredmetStudent.aspx?NasID=" + this.Nasoka_ID_NPD_Pregled_Selected + "&PredID=" + this.Predmet_ID_NPD_Pregled_Selected + "&DelID=" + this.Del_ID_NPD_PregledIzbor_Selected + "&MatID=" + matObj.MaterijalID + "&Rejting=L\">" + patekaLosIkona + "</a>" + "  ");
            sb.Append(matObj.LosRejting);            
            sb.Append("</span>");

            sb.Append("<span id=\"DobarRejtingMaterijal\">");
            sb.Append("<a href=\"PredmetStudent.aspx?NasID=" + this.Nasoka_ID_NPD_Pregled_Selected + "&PredID=" + this.Predmet_ID_NPD_Pregled_Selected + "&DelID=" + this.Del_ID_NPD_PregledIzbor_Selected + "&MatID=" + matObj.MaterijalID + "&Rejting=D\">" + patekaDobarIkona + "</a>" + "  ");
            sb.Append(matObj.DobarRejting);            
            sb.Append("</span>");

            sb.Append("<span id=\"MaterijalDownloadCount\">");
            sb.Append(patekaDownloadIkona + "  ");
            sb.Append(matObj.Prevzemen.ToString());
            sb.Append("</span>");
            sb.Append("</div>");
            sb.Append("</div>");

            return new LiteralControl(sb.ToString());
        }
        #endregion

        #region IPorakaPredmetAddView
        public int Predmet_ID_PorakaPredmet_Add_Input
        {
            get
            {
                return this.Predmet_ID_NPD_Pregled_Selected;
            }
            set
            {
                this.Predmet_ID_NPD_Pregled_Selected = value;
            }
        }

        public int Nasoka_ID_PorakaPredmet_Add_Input
        {
            get
            {
                return this.Nasoka_ID_NPD_Pregled_Selected;
            }
            set
            {
                this.Nasoka_ID_NPD_Pregled_Selected = value;
            }
        }

        public string Sodrzina_PorakaPredmet_Add_Input
        {
            get
            {
                return this.txtBoxSodrzinaPoraka.Text;
            }
            set
            {
                this.txtBoxSodrzinaPoraka.Text = value;
            }
        }

        public string UserID_PorakaPredmet_Add_Inpit
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
        protected void btnPratiPoraka_Click(object sender, EventArgs e)
        {
            _porakaPresenter.addPorakaPredmet();
            _porakaPresenter.getPorakiPredmet();
        }



        #endregion

        #region IPorakaPredmetPregled8View
        public int Predmet_ID_PorakaPredmet_Add_Selected
        {
            get
            {
                return this.Predmet_ID_NPD_Pregled_Selected;
            }
            set
            {
                this.Predmet_ID_NPD_Pregled_Selected = value;
            }
        }

        public int Nasoka_ID_PorakaPredmet_Add_Selected
        {
            get
            {
                return this.Nasoka_ID_NPD_Pregled_Selected;
            }
            set
            {
                this.Nasoka_ID_NPD_Pregled_Selected = value;
            }
        }

        public void nacrtajPregledPorakiZaPredmet(List<PorakaPredmet> ppList)
        {
            this.PorakiPredmet.Controls.Clear();
            foreach (PorakaPredmet ppObj in ppList)
            {
                this.PorakiPredmet.Controls.Add(nacrtajPorakaPredmet(ppObj));
            }
        }
        LiteralControl nacrtajPorakaPredmet(PorakaPredmet ppObj)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div id=\"PorakaPredmet\">");            
            sb.Append("<span id=\"PorakaUserID\">");
            sb.Append("<img src=\"Sliki/PredmetStudentSliki/korisnikKomentarV1.png\" alt=\"корисник\" />");
            sb.Append("<b>");
            sb.Append("<br />");
            sb.Append(ppObj.DodadenaOd);
            sb.Append("</b>");
            sb.Append("</span>");
            sb.Append("<span id=\"PorakaDatum\">Датум:");
            sb.Append("<b>");
            sb.Append(ppObj.DodadenaNa);
            sb.Append("</b>");
            sb.Append("</span>");
            sb.Append("<br />");                       
            sb.Append("<div id=\"PorakaSodrzina\">");
            sb.Append(ppObj.Sodrzina);
            sb.Append("</div>");
            sb.Append("</div>");

            return new LiteralControl(sb.ToString());

        }
        #endregion


        #region IMaterijalPregled1View Members

        public int ID_Materijal_Pregled1_Input
        {
            get
            {
                return this.ID_Materijal_MaterijaliPredmet_PregledIzbor_Selected;
            }
            set
            {
                ID_Materijal_MaterijaliPredmet_PregledIzbor_Selected = value;
            }
        }

        public void nacrtajPregled1Materijal(Materijal matObj)
        {
           //sega ja koristime samo za da napravime download na materijalot

            kontrolaPrezemi.SourceFile = matObj.Pateka;
            try
            {
                kontrolaPrezemi.StartDownloading();
            }
            catch (Exception e)
            {
                
            }

        }

        #endregion
        #region IMaterijaliZgolemiDownloadView
        public int Nasoka_ID_Materijali_ZgolemiDownload_Input
        {
            get
            {
                return this.Nasoka_ID_NPD_Pregled_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Predmet_ID_Materijali_ZgolemiDownload_Input
        {
            get
            {
                return this.Predmet_ID_NPD_Pregled_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Delovi_ID_Materijali_ZgolemiDownload_Input
        {
            get
            {
                return this.Del_ID_NPD_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Materijal_ID_Materijali_ZgolemiDownload_Input
        {
            get
            {
                return this.ID_Materijal_Pregled1_Input;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region IMaterijaliPredmetAddRejtingView
        public int Materijal_ID_MaterijalPredmet_AddRejting_Input
        {
            get
            {
                return this.ID_Materijal_Pregled1_Input;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Nasoka_ID_MaterijalPredmet_AddRejting_Input
        {
            get
            {
                return this.Nasoka_ID_NPD_Pregled_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Predmet_ID_MaterijalPredmet_AddRejting_Input
        {
            get
            {
                return this.Predmet_ID_NPD_Pregled_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Del_ID_MaterijalPredmet_AddRejting_Input
        {
            get
            {
                return this.Del_ID_NPD_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public RejtingTip TipNaRejting_MaterijaliPredmet
        {
            get
            {
                return _tipNaRejtingZaMaterijal;
            }
            set
            {
                _tipNaRejtingZaMaterijal = value;
            }
        }
        #endregion


        #region IPredmetNasokaPregled1View Members

        public int Nasoka_ID_PredmetNasoka_Pregled_Selected
        {
            get
            {
                return this.Nasoka_ID_NPD_Pregled_Selected;
            }
            set
            {
                this.Nasoka_ID_NPD_Pregled_Selected = value;
            }
        }

        public int Predmet_ID_PredmetNasoka_Pregled_Selected
        {
            get
            {
                return this.Predmet_ID_NPD_Pregled_Selected;
            }
            set
            {
                this.Predmet_ID_NPD_Pregled_Selected = value;
            }
        }

        public void nacrtajPregledPredmetiZaNasoka(PredmetNasoka predmetNasokaObj)
        {
            this.predmetInfo.Controls.Clear();

            this.predmetInfo.Controls.Add(nacrtajInfoPredmetNasoka(predmetNasokaObj));
        }
        LiteralControl nacrtajInfoPredmetNasoka(PredmetNasoka predmetObj)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("<span class=\"predmetIme\" >");
            sb.Append(predmetObj.PredmetIme);
            sb.Append("</span>");
            sb.Append("<span class=\"predmetTekst\" >");
            sb.Append("Во прилог можете да ги погледнете и превземeте материјалите за " + predmetObj.PredmetIme);
            sb.Append("</span>");
            return new LiteralControl(sb.ToString());
        }
        #endregion
    }
}

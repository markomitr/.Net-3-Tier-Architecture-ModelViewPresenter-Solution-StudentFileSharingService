using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Interface;
using Presenter.Interface.Presenters;
using Presenter.Interface.Views.PretplataPredmetViews;
using ClassDLL.SysPart;
using ClassDLL.RegularExpression;
using DAL.DBAccess;
namespace Presenter.Presenter
{
    public class PretplataPredmetPresenter:IPretplataPredmetPresenter 
    {
        IView _view;
        PredmetiNasokaDB _predmetNasokaDB;
        public PretplataPredmetPresenter() { }
        public PretplataPredmetPresenter(IView view)
        {
            this._view = view;
            this._predmetNasokaDB = new PredmetiNasokaDB();
        }

        #region IPretplataPredmetPresenter Members

        public void PretplatiKorisnikNaPredmet()
        {
            try
            {
                IPretplataPredmetAddView _viewPredmet = (IPretplataPredmetAddView)_view;
                RezultatKomanda rezultat = _predmetNasokaDB.addKorisnikPredmet(_viewPredmet.NasokaID_PretplataPredmet_Add_Input, _viewPredmet.PredmetID_PretplataPredmet_Add_Input, _viewPredmet.KorisnikID_PretplataPredmet_Add_Input);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPredmet.InfoPoraka = "Korisnikot e pretplaten na predmetot. ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPredmet.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPredmet.ErrorPoraka = "Greska pri preplakanje na predmet.";
                }
            }
            catch (Exception ex)
            {
                //Greska vo pretplata predmet
                throw ex;
            }
        }

        public void pregled8PretplateniPredmeti()
        {
            try
            {
                IPretplataPredmetPregled8SoIzborView _viewPredmet = (IPretplataPredmetPregled8SoIzborView)_view;
                List<PretplatenPredmet> listaPredmeti = new List<PretplatenPredmet>();
                RezultatKomanda rezultat = this._predmetNasokaDB.getKorisnikPredmeti(_viewPredmet.Korisnik_ID_PretplataPredmet_PregledIzbor_Input, ref listaPredmeti);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPredmet.InfoPoraka = "Izlistani se predmetite na koi sto e pretplaten korisnikot - IZBOR. ";
                    _viewPredmet.nacrtajPregledSoIzborPretplateniPredmeti(listaPredmeti);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPredmet.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPredmet.ErrorPoraka = "Greska pri listanje na pretplateni predmeti so IZBOR.";
                }
            }
            catch (Exception ex)
            {
                //Greska vo listanje pretplata predmet
                throw ex;
            }
        }

        public void pregled8NePretplateniPredmeti()
        {
            try
            {
                INePretplataPredmetPregled8SoIzborView _viewPredmet = (INePretplataPredmetPregled8SoIzborView)_view;
                List<PredmetNasoka>  listaPredmeti = new List<PredmetNasoka>();
                RezultatKomanda rezultat = _predmetNasokaDB.getPredmetiNasokaNepetplaten(_viewPredmet.OblastID_NePretplataPredmet_PregledIzbor_Input, _viewPredmet.NasokaID_NePretplataPredmet_PregledIzbor_Input, _viewPredmet.Korisnik_ID_NePretplataPredmet_PregledIzbor_Input, ref listaPredmeti);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPredmet.InfoPoraka = "Izlistani se predmetite za izbranata nasoka/oblast za PRETPLAKANJE. ";
                    _viewPredmet.nacrtajPregledSoIzborNePretplateniPredmeti(listaPredmeti);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPredmet.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPredmet.ErrorPoraka = "Greska pri listanje na predmeti za preplakanje.";
                }
            }
            catch (Exception ex)
            {
                //Greska vo listanje predmeti za pretplakanje
                throw ex;
            }
        }
        public void OtkaziPretplataNaPredmet()
        {
            try
            {
                IPretplataPredmetDeleteView _viewPredmet = (IPretplataPredmetDeleteView)_view;
                RezultatKomanda rezultat = this._predmetNasokaDB.deleteKorisnikPredmet(_viewPredmet.NasokaID_PretplataPredmet_Delete_Input, _viewPredmet.PredmetID_PretplataPredmet_Delete_Input, _viewPredmet.KorisnikID_PreplataPredmet_Delete_Input);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPredmet.InfoPoraka = "Uspesno e otkazana pretplatata od predmet. ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPredmet.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPredmet.ErrorPoraka = "Greska pri otkazuvanje na pretplata na predmet.";
                }
            }
            catch (Exception ex)
            {
                //Greska vo otkazuvanje na pretplata na predmet
                throw ex;
            }
        }
        #endregion


    }
}

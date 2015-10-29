using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DBAccess;
using ClassDLL.SysPart;
using Presenter.Interface.Presenters;
using Presenter.Interface;
using Presenter.Interface.Views.PredmetViews;
namespace Presenter.Presenter
{
    public class PredmetPresenter : IPredmetPresenter
    {

        IView _view;
        PredmetDB predmetDB;

        public PredmetPresenter(IView view)
        {
            _view = view;
            predmetDB = new PredmetDB();
        }

        public void addPredmet()
        {
            try
            {
                IPredmetAddView _viewPredmet =  (IPredmetAddView) _view;
                 RezultatKomanda rezultat = predmetDB.addPredmet(_viewPredmet.Ime_Predmet_Add_Input,_viewPredmet.Opis_Predmet_Add_Input);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPredmet.InfoPoraka = "Kreiran e nov predmet";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPredmet.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPredmet.ErrorPoraka = "Greska pri kreiranje predmet";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void updatePredmet()
        {
                try
                {
                    IPredmetEditView _viewPredmet = (IPredmetEditView)_view;
                    Predmet predmetObj = new Predmet(_viewPredmet.ID_Predmet_Edit_Input, _viewPredmet.Ime_Predmet_Edit_Input, _viewPredmet.Opis_Predmet_Edit_Input);
                    RezultatKomanda rezultat = predmetDB.updatePredmet(predmetObj);
                    if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                    {
                        _viewPredmet.InfoPoraka = "Izmenat e predmet";
                    }
                    else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                    {
                        _viewPredmet.ErrorPoraka = rezultat.Pricina;
                    }
                    else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                    {
                        _viewPredmet.ErrorPoraka = "Greska pri izmeni predmet";
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

        }

        public void deletePredmet()
        {
            throw new NotImplementedException();
        }
        public void pregled1Predmet()
        {
            try
            {
                IPredmetPregled1View _viewPredmet = (IPredmetPregled1View )_view;
                Predmet predmetObj = new Predmet();
                RezultatKomanda rezultat = predmetDB.getPredmet(_viewPredmet.ID_Predmet_Pregled1_Selected,ref predmetObj);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPredmet.nacrtajPregled1Predmet(predmetObj);
                    _viewPredmet.InfoPoraka = "Pregled na predmet";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPredmet.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPredmet.ErrorPoraka = "Greska pri pregled predmet";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void pregled8Predmeti()
        {
            try
            {
                IPredmetPregled8View _viewPredmet = (IPredmetPregled8View )_view;
                List<Predmet> predmetiList = new List<Predmet>(); 

                RezultatKomanda rezultat = predmetDB.getPredmeti(ref predmetiList);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPredmet.nacrtajPregled8Predmeti(predmetiList);
                    _viewPredmet.InfoPoraka = "Pregled na predmeti";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPredmet.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPredmet.ErrorPoraka = "Greska pri pregled predmeti";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void pregled8PremdetiSoIzbor()
        {
            try
            {
                IPredmetPregled8SoIzborView _viewPredmet = (IPredmetPregled8SoIzborView)_view;
                List<Predmet> predmetiList = new List<Predmet>(); 

                RezultatKomanda rezultat = predmetDB.getPredmeti(ref predmetiList);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPredmet.nacrtajPregled8PredmetiSoIzbor(predmetiList);
                    _viewPredmet.InfoPoraka = "Pregled na predmeti";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPredmet.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPredmet.ErrorPoraka = "Greska pri pregled predmeti";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void zemiPredmetZaEdit()
        {
            try
            {
                IPredmetEditView _viewPredmet = (IPredmetEditView)_view;
                Predmet predmetObj = new Predmet();
                RezultatKomanda rezultat = predmetDB.getPredmet(_viewPredmet.ID_Predmet_Edit_Selected,ref predmetObj);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPredmet.nacrtajFromaZaEditPredmet(predmetObj);
                    _viewPredmet.InfoPoraka = "Pregled na predmet";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPredmet.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPredmet.ErrorPoraka = "Greska pri pregled predmet";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

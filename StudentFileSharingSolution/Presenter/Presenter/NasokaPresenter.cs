using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DBAccess;
using ClassDLL.SysPart;
using Presenter.Interface.Presenters;
using Presenter.Interface;
using Presenter.Interface.Views.NasokaViews;
using Presenter.Interface.Views.CompositeViews;
using Presenter.Interface.Views.NasokaPredmetDelViews;
namespace Presenter.Presenter
{
    public class NasokaPresenter : INasokaPresenter 
    {
        IView _view;
        NasokaDB nasokaDB;
        PredmetiNasokaDB predmetiNasokaDB;
        public NasokaPresenter(IView view)
        {
            _view = view;
            nasokaDB = new NasokaDB();
            predmetiNasokaDB = new PredmetiNasokaDB();
        }
        public void addNasoka()
        {
            try
            {
                INasokaAddView _viewNasoka = (INasokaAddView)_view;

                RezultatKomanda rezultat = nasokaDB.addNasoka(_viewNasoka.Ime_Nasoka_Add_Input, _viewNasoka.Opis_Nasoka_Add_Input, _viewNasoka.OblastID_Nasoka_Add_Input);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewNasoka.InfoPoraka = "Kreirana e nova nasoka ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewNasoka.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewNasoka.ErrorPoraka = "Greska pri kreiranje nasoka";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add nasoka
                throw ex;
            }
        }

        public void updateNasoka()
        {
            try
            {
                INasokaEditView _viewNasoka = (INasokaEditView)_view;

                RezultatKomanda rezultat = nasokaDB.updateNasoka(_viewNasoka.ID_Nasoka_Edit_Input,_viewNasoka.OblastID_Nasoka_Edit_Input,_viewNasoka.Ime_Nasoka_Edit_Input, _viewNasoka.Opis_Nasoka_Edit_Input);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewNasoka.InfoPoraka = "Izmeneta e nasokata ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewNasoka.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewNasoka.ErrorPoraka = "Greska pri izmena nasoka";
                }
            }
            catch (Exception ex)
            {
                //Greska vo edit nasoka
                throw ex;
            }
        }
        public void zemiNasokaZaEdit()
        {
            try
            {
                INasokaEditView _viewNasoka = (INasokaEditView)_view;

                Oblast oblastObj = new Oblast();
                Nasoka nasokaObj = new Nasoka();

                RezultatKomanda rezultat = nasokaDB.getNasoka(_viewNasoka.ID_Nasoka_Edit_Selected, ref nasokaObj);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewNasoka.nacrtajFormaZaEditNasoka(nasokaObj);

                    //_viewNasoka.InfoPoraka = "Pregled na nasoka";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewNasoka.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewNasoka.ErrorPoraka = "Greska pri edit nasoka";
                }
            }
            catch (Exception ex)
            {
                //Greska vo pregled nasoki
                throw ex;
            }
        }
        public void deleteNasoka()
        {

        }

        public void pregled8Nasoki()
        {
            try
            {
                INasokaPregled8View _viewNasoka = (INasokaPregled8View)_view;
                List<Nasoka> listNasoki = new List<Nasoka>();

                RezultatKomanda rezultat = nasokaDB.getNasoki(ref listNasoki);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewNasoka.nacrtajPregled8Nasoki(listNasoki);

                    _viewNasoka.InfoPoraka = "Izlistani se nasokite";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewNasoka.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewNasoka.ErrorPoraka = "Greska pri listanje nasoki";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add nasoki
                throw ex;
            }
        }

        public void pregled1Nasoka()
        {
            try
            {
                INasokaPregled1View _viewNasoka = (INasokaPregled1View)_view;
               Nasoka nasokaObj = new Nasoka();

               RezultatKomanda rezultat = nasokaDB.getNasoka(_viewNasoka.ID_Nasoka_Pregled1_Selected,ref nasokaObj);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewNasoka.nacrtajPregled1Nasoka(nasokaObj);

                    _viewNasoka.InfoPoraka = "Pregled na nasoka";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewNasoka.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewNasoka.ErrorPoraka = "Greska pri pregled nasoka";
                }
            }
            catch (Exception ex)
            {
                //Greska vo pregled nasoki
                throw ex;
            }
        }

        public void pregled8NasokiSoIzbor()
        {
            try
            {
                INasokaPregledSoIzborView _viewNasoka = (INasokaPregledSoIzborView)_view;
                List<Nasoka> listNasoki = new List<Nasoka>();

                RezultatKomanda rezultat = nasokaDB.getNasoki(ref listNasoki);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewNasoka.nacrtajPregledSoIzborNasoki(listNasoki);

                    _viewNasoka.InfoPoraka = "Izlistani se nasokite";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewNasoka.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewNasoka.ErrorPoraka = "Greska pri listanje nasoki";
                }
            }
            catch (Exception ex)
            {
                //Greska vo pregledSoIzbor nasoki
                throw ex;
            }
        }
        public void pregled8NasokiSoFilter()
        {
            try
            {
                INasokaPregledSoFilterView _viewNasoka = (INasokaPregledSoFilterView)_view;
                List<Nasoka> listNasoki = new List<Nasoka>();

                RezultatKomanda rezultat = nasokaDB.getNasokiPoOblast(_viewNasoka.ID_Oblast_NasokaFilter_Selected,ref listNasoki);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewNasoka.nacrtajNasokaSoFilter(listNasoki);

                    _viewNasoka.InfoPoraka = "Izlistani se nasokite so FILTER";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewNasoka.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewNasoka.ErrorPoraka = "Greska pri listanje nasoki so FILTER";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void addPredmetZaNasoka()
        {
            try
            {
                IPredmetNasokaAddView _viewPredmetNasoka = (IPredmetNasokaAddView)_view;
                RezultatKomanda rezultat = nasokaDB.addPredmetPoNasoka(_viewPredmetNasoka.ID_Nasoka_NasokaFilter_Selected, _viewPredmetNasoka.ID_Predmet_PregledIzbor_Selected, _viewPredmetNasoka.Ime_PredmetNasoka_Input,_viewPredmetNasoka.Kod_PredmetNasoka_Input,_viewPredmetNasoka.Krediti_PredmetNasoka_Input);     
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPredmetNasoka.InfoPoraka = "Dodaden e predmet na izbranta nasoka ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPredmetNasoka.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPredmetNasoka.ErrorPoraka = "Greska pri kreiranje dodavanej predmet na nasoka";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add nasoka
                throw ex;
            }
        }
        public void pregled1PredmetiPoNasoka()
        {
            try
            {
                IPredmetiNasokaPoNasokaPregled1View _viewPN = (IPredmetiNasokaPoNasokaPregled1View)_view;
                List<PredmetNasoka> pnList = new List<PredmetNasoka>();
                RezultatKomanda rezultat = nasokaDB.getPredmetiPoNasoka(_viewPN.NasokaID_PredmetiNasoka_PregledFilter_Selected, ref pnList);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPN.nacrtajPregledPredmetiZaNasoka(pnList);

                    _viewPN.InfoPoraka = "Izlistani se predmetite za odbranata nasoka";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPN.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPN.ErrorPoraka = "Greska pri listanje predmeti za nasoka";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add nasoki
                throw ex;
            }
        }
        public void pregled1PredmetiPoNasokaSoIzbor()
        {
            try
            {
                IPredmetiNasokaPoNasokaPregled1SoIzborView _viewPN = (IPredmetiNasokaPoNasokaPregled1SoIzborView)_view;
                List<PredmetNasoka> pnList = new List<PredmetNasoka>();
                RezultatKomanda rezultat = nasokaDB.getPredmetiPoNasoka(_viewPN.NasokaID_PredmetiNasoka_PregledFilter_Selected, ref pnList);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPN.nacrtajPregledPredmetiZaNasokaSoIzbor(pnList);

                    _viewPN.InfoPoraka = "Izlistani se predmetite za odbranata nasoka";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPN.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPN.ErrorPoraka = "Greska pri listanje predmeti za nasoka";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add nasoki
                throw ex;
            }
        }

        public void addDelZaPredmetPoNasoka()
        {
            try
            {
                INPDAddView _npdView = (INPDAddView)_view;
                RezultatKomanda rezultat = nasokaDB.addDeloviZaPredmetPoNasoka(_npdView.Nasoka_ID_NasokaPredmetDel_Input,
                                                                               _npdView.Predmet_ID_NasokaPredmetDel_Input,
                                                                               _npdView.Delovi_ID_NasokaPredmetDel_Input,
                                                                               _npdView.Stuff_ID_NasokaPredmetDel_Input);
                                                                                            
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _npdView.InfoPoraka = "Dodaden e del za izbraniot predmet po Nasoka ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _npdView.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _npdView.ErrorPoraka = "Greska pri kreiranje dodavanje del za izbraniot predmet po Nasoka";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add del za izbraniot predmet po Nasoka
                throw ex;
            }
        }
        public void pregled1DeloviZaPredmetPoNasoka()
        {
            try
            {
                INPDPregled1SoIzborView _npdView = (INPDPregled1SoIzborView)_view;
                List<DeloviPredmetNasoka> npdList = new List<DeloviPredmetNasoka>();
                RezultatKomanda rezultat = nasokaDB.getDeloviZaPredmetPoNasoka(_npdView.Nasoka_ID_NPD_Pregled_Selected,
                                                                               _npdView.Predmet_ID_NPD_Pregled_Selected,
                                                                               ref npdList);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _npdView.nacrtajPregledDelovizaPredmetiZaNasokaSoIzbor(npdList);

                    _npdView.InfoPoraka = "Izlistani se delovite za  predmetite za odbranata nasoka";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _npdView.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _npdView.ErrorPoraka = "Greska pri listanje delovi za predmeti za nasoka";
                }
            }
            catch (Exception ex)
            {
                //Greska vo  delovi za predmeti za nasoka
                throw ex;
            }
        }

        public void pregled1PredmetNasoka()
        {
            try
            {
                IPredmetNasokaPregled1View _viewPN = (IPredmetNasokaPregled1View)_view;
                PredmetNasoka predmetNasObj = new PredmetNasoka();
                RezultatKomanda rezultat = predmetiNasokaDB.getPredmetNasoka(_viewPN.Nasoka_ID_PredmetNasoka_Pregled_Selected, _viewPN.Predmet_ID_PredmetNasoka_Pregled_Selected, ref predmetNasObj);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewPN.nacrtajPregledPredmetiZaNasoka(predmetNasObj);

                    _viewPN.InfoPoraka = "Prikazani se informacii za predmetot.";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewPN.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewPN.ErrorPoraka = "Greska pri listanje predmeti za nasoka";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add nasoki
                throw ex;
            }
        }


    }
}

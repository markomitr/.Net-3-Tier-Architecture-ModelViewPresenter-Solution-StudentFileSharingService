using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.GreskiEX;
using ClassDLL.RegularExpression;
using ClassDLL.SysPart;
using DAL.DBAccess;
using Presenter.Interface;
using Presenter.Interface.Presenters;
using Presenter.Interface.Views;
using Presenter.Interface.Views.MaterijalViews;
using Presenter.Interface.Views.MaterijaliPredmetiViews;
namespace Presenter.Presenter
{
    public class MaterijalPresenter : IMaterijalPresenter
    {
        IView _view;
        MaterijaliDB _materijalDB;
        public MaterijalPresenter() { }
        public MaterijalPresenter(IView pogled)
        {
            _view = pogled;
            _materijalDB = new MaterijaliDB();
        }

        #region IMaterijalPresenter Members

        public void addMaterijal()
        {
            try
            {
                FactoryRegEx regExFactory = new FactoryRegEx();
                RegExNas proverka = (RegExNas)regExFactory.Produce(ValidatorEnum.Materijal_Naslov, null);
                RegExNas proverkaOpis = (RegExNas)regExFactory.Produce(ValidatorEnum.Materijal_Opis, null);

                IMaterijalAddView _viewMat = (IMaterijalAddView)_view;
                proverka.Validiraj(_viewMat.Naslov_Materijal_Add_Input);
                proverkaOpis.Validiraj(_viewMat.Opis_Materijal_Add_Input);
                if (proverka.uspeh == true && proverkaOpis.uspeh == true)
                {
                    _viewMat.Opis_Materijal_Add_Input = proverkaOpis.IzmenetVlez.ToString();
                    RezultatKomanda rezultat = _materijalDB.addMaterijal(_viewMat.Naslov_Materijal_Add_Input, _viewMat.Opis_Materijal_Add_Input, _viewMat.DodadenOD_Materijal_Add_Input, _viewMat.Slika_Materijal_Add_Input, _viewMat.Pateka_Materijal_Add_Input,_viewMat.Type_Materijal_Add_Input);

                    if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                    {
                        _viewMat.InfoPoraka = "Kreiran e nov materijal ";
                    }
                    else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                    {
                        _viewMat.ErrorPoraka = rezultat.Pricina;
                    }
                    else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                    {
                        _viewMat.ErrorPoraka = "Greska pri dodadvanje materijal";
                    }
                }
                else
                {
                    _viewMat.ErrorPoraka = proverka.poraka;
                    _viewMat.ErrorPoraka += proverkaOpis.poraka;
                }

            }
            catch (Exception ex)
            {
                //Greska vo add Materijal
                throw ex;
            }
        }

        public void addMaterijalPredmet()
        {
            try
            {

                IMaterijaliPredmetAddView _viewMat = (IMaterijaliPredmetAddView)_view;

                RezultatKomanda rezultat = _materijalDB.addMaterijalPredmet(_viewMat.Materijal_ID_MaterijalPredmet_Add_Input, _viewMat.Nasoka_ID_MaterijalPredmet_Add_Input, _viewMat.Predmet_ID_MaterijalPredmet_Add_Input, _viewMat.Del_ID_MaterijalPredmet_Add_Input);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewMat.InfoPoraka = "Materijalot e dodaden na predmetot. ";

                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewMat.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewMat.ErrorPoraka = "Greska pri dodadvanje materijal na odreden predmet";
                }


            }
            catch (Exception ex)
            {
                //Greska vo add MaterijalPredmet
                throw ex;
            }
        }

        public void pregled1Materijal()
        {
            try
            {
                IMaterijalPregled1View _viewMat = (IMaterijalPregled1View)_view;
                Materijal matObj = new Materijal();

                RezultatKomanda rezultat = _materijalDB.getMaterijal(_viewMat.ID_Materijal_Pregled1_Input, ref matObj);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewMat.InfoPoraka += "Izlistan e materijalot. ";
                    IMaterijaliZgolemiDownloadView _viewMatDown = (IMaterijaliZgolemiDownloadView)_view;
                    _materijalDB.addDownloadCount(_viewMatDown.Materijal_ID_Materijali_ZgolemiDownload_Input,
                                                  _viewMatDown.Nasoka_ID_Materijali_ZgolemiDownload_Input,
                                                  _viewMatDown.Predmet_ID_Materijali_ZgolemiDownload_Input,
                                                  _viewMatDown.Delovi_ID_Materijali_ZgolemiDownload_Input);
                    _viewMat.nacrtajPregled1Materijal(matObj);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewMat.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewMat.ErrorPoraka = "Greska pri listanje materijal.";
                }
            }
            catch (Exception ex)
            {
                //Greska vo pregled na materijal
                throw ex;
            }
        }
        public void pregled8SoIzborMaterijali()
        {
            try
            {
                IMaterijaliPregled8SoIzborView _viewMat = (IMaterijaliPregled8SoIzborView)_view;
                List<Materijal> materijalList = new List<Materijal>();

                RezultatKomanda rezultat = _materijalDB.getMaterijali(ref materijalList);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewMat.InfoPoraka += "Izlistani se materijalite so izbor. ";
                    _viewMat.nacrtajPregled8MaterijaliSoIzbor(materijalList);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewMat.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewMat.ErrorPoraka = "Greska pri listanje  materijali.";
                }


            }
            catch (Exception ex)
            {
                //Greska vo pregled na materijali
                throw ex;
            }
        }

        public void pregled8MaterijaliPredmet()
        {
            try
            {
                IMaterijaliPredmetPregled8View _viewMat = (IMaterijaliPredmetPregled8View)_view;
                MaterijaliGrupirani materijaliGrupirani = new MaterijaliGrupirani();

                RezultatKomanda rezultat = _materijalDB.getMaterijali(_viewMat.Nasoka_ID_MaterijaliPredmet_Pregled_Input, _viewMat.Predmet_ID_MaterijaliPredmet_Pregled_Input, _viewMat.Del_ID_MaterijaliPredmet_Pregled_Input, ref materijaliGrupirani);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewMat.InfoPoraka += "Izlistani se materijalite. ";
                    _viewMat.nacrtajPregled8MaterijaliPredmet(materijaliGrupirani);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewMat.ErrorPoraka = rezultat.Pricina;
                    _viewMat.nacrtajPregled8MaterijaliPredmet(materijaliGrupirani);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewMat.ErrorPoraka = "Greska pri listanje  materijali.";
                }


            }
            catch (Exception ex)
            {
                //Greska vo pregled na materijali
                throw ex;
            }
        }
        public void pregled8MaterijaliPredmetSoIzbor()
        {
            try
            {
                IMaterijaliPredmetPregled8SoIzborView _viewMat = (IMaterijaliPredmetPregled8SoIzborView)_view;
                MaterijaliGrupirani materijaliGrupirani = new MaterijaliGrupirani();

                RezultatKomanda rezultat = _materijalDB.getMaterijali(_viewMat.Nasoka_ID_MaterijaliPredmet_PregledIzbor_Input, _viewMat.Predmet_ID_MaterijaliPredmet_PregledIzbor_Input, _viewMat.Del_ID_MaterijaliPredmet_PregledIzbor_Input,ref  materijaliGrupirani);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewMat.InfoPoraka += "Izlistani se materijalite so izbor. ";
                    _viewMat.nacrtajPregledSoIzborMaterijaliPredmet(materijaliGrupirani);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewMat.ErrorPoraka = rezultat.Pricina;
                    _viewMat.nacrtajPregledSoIzborMaterijaliPredmet(materijaliGrupirani);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewMat.ErrorPoraka = "Greska pri listanje  materijali so IZBOR.";
                }


            }
            catch (Exception ex)
            {
                //Greska vo pregled na materijali si uzbor
                throw ex;
            }
        }
        public void deleteMaterijalPredmet()
        {
            try
            {
                IMaterijaliPredmetDeleteView _viewMat = (IMaterijaliPredmetDeleteView)_view;

                RezultatKomanda rezultat = _materijalDB.deleteMaterijalOdPredmet(_viewMat.Materijal_ID_MaterijaliPredmet_Delete_Input, _viewMat.Nasoka_ID_MaterijaliPredmet_Delete_Input, _viewMat.Predmet_ID_MaterijaliPredmet_Delete_Input, _viewMat.Delovi_ID_MaterijaliPredmet_Delete_Input);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewMat.InfoPoraka = "Materijalot e izbrisan od predmetot. ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewMat.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewMat.ErrorPoraka = "Greska pri brisenje na materijal od predmet";
                }


            }
            catch (Exception ex)
            {
                //Greska vo brisenej predmet
                throw ex;
            }
        }
        #endregion


        public void addRejtingMaterijal()
        {
            try
            {
                IMaterijaliPredmetAddRejtingView _viewMatRejting = (IMaterijaliPredmetAddRejtingView)_view;
            
                RezultatKomanda rezultat = _materijalDB.addRejting(_viewMatRejting.Materijal_ID_MaterijalPredmet_AddRejting_Input,
                                                                  _viewMatRejting.Nasoka_ID_MaterijalPredmet_AddRejting_Input,
                                                                  _viewMatRejting.Predmet_ID_MaterijalPredmet_AddRejting_Input,
                                                                  _viewMatRejting.Del_ID_MaterijalPredmet_AddRejting_Input,
                                                                   _viewMatRejting.TipNaRejting_MaterijaliPredmet);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewMatRejting.InfoPoraka = "Doaden e rejtingot za materjalot!";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewMatRejting.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                   _viewMatRejting.ErrorPoraka = "Greska pri dodavanje rejtingot za materjalot.";
                }
            }
            catch (Exception ex)
            {
                //Greska vo pregled na materijal
                throw ex;
            }
        }
    }
}

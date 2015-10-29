using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DBAccess;
using ClassDLL.SysPart;
using Presenter.Interface.Presenters;
using Presenter.Interface;
using Presenter.Interface.Views.OblastViews;

namespace Presenter.Presenter
{
    public class OblastPresenter : IOblastPresenter
    {
        IView _view;
        OblastDB oblastDB;
        public OblastPresenter(IView view)
        {
            _view = view;
            oblastDB = new OblastDB();
        }
        public void addOblast()
        {

            try
            {
                IOblastAddView _viewOblast = (IOblastAddView)_view;
                
                RezultatKomanda rezultat = oblastDB.addOblast(_viewOblast.Ime_Oblast_Add_Input, _viewOblast.Adresa_Oblast_Add_Input, _viewOblast.WebStrana_Oblast_Add_Input,_viewOblast.UstanovaID_Oblast_Add_Input);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewOblast.InfoPoraka = "Kreirana e nova oblast ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewOblast.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewOblast.ErrorPoraka = "Greska pri kreiranje oblast";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add oblast
                throw ex;
            }
        }

        public void updateOblast()
        {
             try
            {
                IOblastEditView _viewOblast = (IOblastEditView)_view;
                //Da vidam dali voopsto treba Ud_Ustavova_Oblast_Edit_Selected
                RezultatKomanda rezultat = oblastDB.updateOblast(_viewOblast.ID_Oblast_Edit_Input,_viewOblast.ID_Ustanova_Oblast_Edit_Selected,_viewOblast.Ime_Oblast_Edit_Input, _viewOblast.Adresa_Oblast_Edit_Input, _viewOblast.WebStrana_Oblast_Edit_Input);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewOblast.InfoPoraka = "Izmeneta e oblasta ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewOblast.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewOblast.ErrorPoraka = "Greska pri izmena oblast";
                }
            }
            catch (Exception ex)
            {
                //Greska vo izmena oblast
                throw ex;
            }
        }

        public void deleteOblast()
        {

        }

        public void pregled8Oblasti()
        {
            try
            {
                IOblastPregled8View _viewOblast = (IOblastPregled8View)_view;
                List<Oblast> listOblasti = new List<Oblast>();

                RezultatKomanda rezultat = oblastDB.getOblasti(ref listOblasti);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewOblast.nacrtajPregled8Oblasti(listOblasti);

                    _viewOblast.InfoPoraka = "Izlistani se oblastite";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewOblast.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewOblast.ErrorPoraka = "Greska pri listanje oblasti";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add oblast
                throw ex;
            }
        }

        public void pregled1Oblast()
        {
            try
            {
                IOblastPregled1View _viewOblast = (IOblastPregled1View)_view;
                Oblast oblastObj = new Oblast();

                RezultatKomanda rezultat = oblastDB.getOblast(_viewOblast.ID_Oblast_Pregled1_input, ref oblastObj);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewOblast.nacrtajPregled1Oblast(oblastObj);

                    _viewOblast.InfoPoraka = "Prikazna e oblasta";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewOblast.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewOblast.ErrorPoraka = "Greska pri prikazuvanje oblast";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add oblast
                throw ex;
            }
        }

        public void pregled8OblastiSoIzbor()
        {
            try
            {
                IOblastPregledSoIzborView _viewOblast = (IOblastPregledSoIzborView)_view;
                List<Oblast> listOblasti = new List<Oblast>();

                RezultatKomanda rezultat = oblastDB.getOblasti(ref listOblasti);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewOblast.nacrtajPregledSoIzborOblast(listOblasti);

                    _viewOblast.InfoPoraka = "Prikaz na oblasti so izbor";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewOblast.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewOblast.ErrorPoraka = "Greska pri prikazuvanje oblasti";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add oblast so izbor
                throw ex;
            }
        }
        public void zemiOblastZaEdit()
        {
            try
            {
                IOblastEditView _viewOblastEdit = (IOblastEditView)_view;

                Oblast oblastObj = new Oblast();
                RezultatKomanda rezultat = oblastDB.getOblast(_viewOblastEdit.ID_Oblast_Edit_Selected, ref oblastObj);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewOblastEdit.nacrtajFromaZaEditOblast(oblastObj);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewOblastEdit.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewOblastEdit.ErrorPoraka = "Greska pri crtanje Edit za Oblast";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void pregledOblastiSoFilter()
        {
            try
            {
                IOblastPregledSoFilterView _viewOblast = (IOblastPregledSoFilterView)_view;
                List<Oblast> listOblasti = new List<Oblast>();

                RezultatKomanda rezultat = oblastDB.getOblastiPoUstanova(_viewOblast.ID_Ustanova_OblastFilter_Selected,ref listOblasti);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewOblast.nacrtajPregledOblastiSoFilter(listOblasti);

                    _viewOblast.InfoPoraka = "Prikaz na oblasti so izbor";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewOblast.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewOblast.ErrorPoraka = "Greska pri prikazuvanje oblasti";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add oblast so izbor
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DBAccess;
using ClassDLL.SysPart;
using Presenter.Interface.Presenters;
using Presenter.Interface;
using Presenter.Interface.Views.InstitucijaViews;
namespace Presenter.Presenter
{
    public class InstitucjaPresenter :IInstitucijaPresenter
    {
        IView _view;
        InstituciiDB instDB;
        public InstitucjaPresenter(IView view)
        {
            _view = view;
            instDB = new InstituciiDB();
        }
        public void addInstitucija()
        {
            try
            {
                IInstitucijaAddView _viewInst = (IInstitucijaAddView)_view;

                RezultatKomanda rezultat = instDB.addInstitucija(_viewInst.Ime_Institucija_Add_Input, _viewInst.Adresa_Institucija_Add_Input, _viewInst.Kratenka_Institucija_Add_Input);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
                    _viewInst.InfoPoraka = "Kreirana e nova institucija ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewInst.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewInst.ErrorPoraka = "Greska pri kreiranje institucija";
                }
            }
            catch(Exception ex)
            {
                //Greska vo add Institucija
                throw ex;
            }
        }

        public void updateInstitucija()
        {
            try
            {
                IInstitucijaEditView _viewInstEdit = (IInstitucijaEditView)_view;

               
                RezultatKomanda rezultat = instDB.updateInstitucija(_viewInstEdit.ID_Institucija_Edit_Input,_viewInstEdit.Ime_Institucija_Edit_Input,_viewInstEdit.Adresa_Institucija_Edit_Input,_viewInstEdit.Kratenka_Institucija_Edit_Input);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {

                    _viewInstEdit.InfoPoraka = "Uspeno e izmeneta instuticijata";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewInstEdit.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    //_viewKor.PorakaNovKor = "Greska pri listanje korisnici";
                    _viewInstEdit.ErrorPoraka = "Greska pri izmena institucija";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void deleteInstitucija()
        {
        }

        public void pregled8Institucii()
        {
            try
            {
                IInstitucijaPregled8View _viewInst = (IInstitucijaPregled8View)_view;
                List<Institucija> listInst = new List<Institucija>();

                RezultatKomanda rezultat = instDB.getInstitucii(ref listInst);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewInst.nacrtajPregled8Institucii(listInst);

                    _viewInst.InfoPoraka = "Izlistani se instituciite ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewInst.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewInst.ErrorPoraka = "Greska pri listanje institucii";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add Institucija
                throw ex;
            }
        }

        public void pregled1Institucija()
        {
        }
        public void zemiInstitucijaZaEdit()
        {
            
            try
            {
                IInstitucijaEditView _viewInstEdit = (IInstitucijaEditView)_view;

                Institucija instObj = new Institucija();
                RezultatKomanda rezultat = instDB.getInstitucija(_viewInstEdit.ID_Institucija_Edit_Selected,ref instObj);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
                    //_viewKor.ListaKorisnici = listaKor;
                    //_viewKor.napolniKorisnici();
                    _viewInstEdit.nacrtajFromaZaEditInstitucija(instObj);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewInstEdit.ErrorPoraka= rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    //_viewKor.PorakaNovKor = "Greska pri listanje korisnici";
                    _viewInstEdit.ErrorPoraka = "Greska pri citanje institucija";
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public void pregled8soIzborInstitucii()
        {
            try
            {
                IInstitucijaPregled8SoIzborView _viewInst = (IInstitucijaPregled8SoIzborView)_view;
                List<Institucija> listInst = new List<Institucija>();

                RezultatKomanda rezultat = instDB.getInstitucii(ref listInst);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewInst.nacrtajPregled8InstituciiSoIzbor(listInst);

                    _viewInst.InfoPoraka = " Izlistani se instituciite za izbor ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewInst.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewInst.ErrorPoraka = "Greska pri listanje institucii";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add Institucija
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DBAccess;
using ClassDLL.SysPart;
using Presenter.Interface.Presenters;
using Presenter.Interface;
using Presenter.Interface.Views.UstanovaViews;
namespace Presenter.Presenter
{
    public class UstanovaPresenter :IUstanovaPresenter 
    {
        IView _view;
        UstanovaDB  ustanovaDB;
        InstituciiDB institucijaDB;
        public UstanovaPresenter(IView view)
        {
            _view = view;
            ustanovaDB = new UstanovaDB();
            institucijaDB = new InstituciiDB();
        }
        public void addUstanova()
        {
            try
            {
                IUstanovaAddView _viewUstanova = (IUstanovaAddView)_view;

                RezultatKomanda rezultat = ustanovaDB.addUstanova(_viewUstanova.Ime_Ustanova_Add_Input, _viewUstanova.Adresa_Ustanova_Add_Input, _viewUstanova.WebStrana_Ustanova_Add_Input, _viewUstanova.InstitucijaID_Ustanova_Add_Input);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewUstanova.InfoPoraka = "Kreirana e nova ustanova ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewUstanova.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewUstanova.ErrorPoraka = "Greska pri kreiranje ustanova";
                }
            }
            catch(Exception ex)
            {
                //Greska vo add ustanova
                throw ex;
            }
        }

        public void updateUstanova()
        {
            try
            {
                IUstanovaEditView _viewUstanovaEdit = (IUstanovaEditView)_view;


                RezultatKomanda rezultat = ustanovaDB.updateUstanova(_viewUstanovaEdit.ID_Ustanova_Edit_Input,_viewUstanovaEdit.ID_Institucija_Edit_Input,_viewUstanovaEdit.Ime_Ustanova_Edit_Input,_viewUstanovaEdit.Adresa_Ustanova_Edit_Input,_viewUstanovaEdit.WebStrana_Ustanova_Edit_Input);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewUstanovaEdit.InfoPoraka = "Uspeno e izmeneta ustanovata";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewUstanovaEdit.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewUstanovaEdit.ErrorPoraka = "Greska pri izmena ustanova";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void deleteUstanova()
        {
        }

        public void pregled8Ustanovi()
        {
            try
            {
                IUstanovaPregled8View _viewUstanova = (IUstanovaPregled8View)_view;
                List<Ustanova> listUstanovi = new List<Ustanova>();

                RezultatKomanda rezultat = ustanovaDB.getUstanovi(ref listUstanovi);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewUstanova.nacrtajPregled8Ustanovi(listUstanovi);

                    _viewUstanova.InfoPoraka = "Izlistani se ustanovite";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewUstanova.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewUstanova.ErrorPoraka = "Greska pri listanje ustanovi";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add ustanova
                throw ex;
            }
        }

        public void pregled1Ustanova()
        {
        }
        public void zemiUstanovaZaEdit()
        {
            
            try
            {
                IUstanovaEditView _viewUstanovaEdit = (IUstanovaEditView)_view;

                Ustanova ustanovaObj = new Ustanova();
                RezultatKomanda rezultat = ustanovaDB.getUstanova(_viewUstanovaEdit.ID_Ustanova_Edit_Selected, ref ustanovaObj);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    List<Institucija> institucii = new List<Institucija>();
                    RezultatKomanda rezultatInstitucija = institucijaDB.getInstitucii(ref institucii);
                    if (rezultatInstitucija.Rezultat == RezultatKomandaEnum.Uspeh)
                    {
                        _viewUstanovaEdit.nacrtajFromaZaEditUstanova(ustanovaObj, institucii);
                    }
                    else if (rezultatInstitucija.Rezultat == RezultatKomandaEnum.Neuspeh)
                    {
                        _viewUstanovaEdit.ErrorPoraka = rezultat.Pricina;
                    }
                    else
                    {
                        _viewUstanovaEdit.ErrorPoraka = "Greska pri citanje intitucii vo ustanova";
                    }
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewUstanovaEdit.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewUstanovaEdit.ErrorPoraka = "Greska pri citanje na edna EDIT ustanova";
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public void pregled8soIzborUstanovi()
        {
            try
            {
                IUstanovaPregled8SoIzborView _viewInst = (IUstanovaPregled8SoIzborView)_view;
                List<Ustanova> ustanovaInst = new List<Ustanova>();

                RezultatKomanda rezultat = ustanovaDB.getUstanovi(ref ustanovaInst);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewInst.nacrtajPregled8UstanoviSoIzbor(ustanovaInst);

                    _viewInst.InfoPoraka = " Izlistani se ustanovite za izbor ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewInst.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewInst.ErrorPoraka = "Greska pri listanje ustanovi";
                }
            }
            catch (Exception ex)
            {
                //Greska vo pregled
                throw ex;
            }
        }
        public void pregled8UstanoviSoFilter()
        {
            try
            {
                IUstanovaPregledSoFilterView _viewUstanova = (IUstanovaPregledSoFilterView)_view;
                List<Ustanova> ustanovaInst = new List<Ustanova>();

                RezultatKomanda rezultat = ustanovaDB.getUstanoviPoInstitucii(_viewUstanova.ID_Institucuja_UstanovaFilter_Selected,ref ustanovaInst);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewUstanova.nacrtajUstanovaSoFilter(ustanovaInst);

                    _viewUstanova.InfoPoraka = " Izlistani se ustanovite  so FILTER ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewUstanova.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewUstanova.ErrorPoraka = "Greska pri listanje ustanovi so FILTER";
                }
            }
            catch (Exception ex)
            {
                //Greska vo pregled
                throw ex;
            }
        }
    }
}

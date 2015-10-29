using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
using ClassDLL.RegularExpression;
using ClassDLL.GreskiEX;
using DAL.DBAccess;
using Presenter.Interface;
using Presenter.Interface.Views.DeloviViews;
using Presenter.Interface.Presenters;
namespace Presenter.Presenter
{
    public class DelPresenter:IDelPresenter 
    {
        IView _view;
        DeloviDB deloviDB;

        public DelPresenter(IView view)
        {
            _view = view;
            deloviDB = new DeloviDB();
        }

        #region IDelPresenter Members

        public void addDel()
        {
            try
            {
                IDeloviAddView _viewDel = (IDeloviAddView)_view;

                RezultatKomanda rezultat = deloviDB.addDel(_viewDel.Ime_Delovi_Add_Input,_viewDel.ImaPredavac_Delovi_Add_Input,_viewDel.VidIzgled_Delovi_Add_Input);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewDel.InfoPoraka = "Kreiran e nov del ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewDel.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewDel.ErrorPoraka = "Greska pri kreiranje nov del";
                }
            }
            catch (Exception ex)
            {
                //Greska vo add ustanova
                throw ex;
            }
        }

        public void updateDel()
        {
            try
            {
                IDeloviEditView _viewDelEdit = (IDeloviEditView)_view;


                RezultatKomanda rezultat = deloviDB.updateDel(_viewDelEdit.ID_Delovi_Edit_Input,_viewDelEdit.Ime_Delovi_Edit_Input,_viewDelEdit.ImaPredavac_Delovi_Edit_Input,_viewDelEdit.VidIzgled_Delovi_Edit_Input,_viewDelEdit.Aktiven_Delovi_Edit_Input);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewDelEdit.InfoPoraka = "Uspesno e promenet del-ot";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewDelEdit.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewDelEdit.ErrorPoraka = "Greska pri izmena del";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteDel()
        {
            throw new NotImplementedException();
        }

        public void pregled1Del()
        {
            throw new NotImplementedException();
        }

        public void pregled8Delovi()
        {
            try
            {
                IDeloviPregled8View _viewDel = (IDeloviPregled8View)_view;
                List<Del> listDelovi = new List<Del>();

                RezultatKomanda rezultat = deloviDB.getDelovi(ref listDelovi);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewDel.nacrtajPregled8Delovi(listDelovi);
                    _viewDel.InfoPoraka = "Izlistani se delovite";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewDel.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewDel.ErrorPoraka = "Greska pri listanje na delovi";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void pregled8SoIzborDelovi()
        {
            try
            {
                IDeloviPregled8SoIzborView _viewDel = (IDeloviPregled8SoIzborView)_view;
                List<Del> deloviList = new List<Del>();

                RezultatKomanda rezultat = deloviDB.getDelovi(ref deloviList);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewDel.nacrtajPregled8DeloviSoIzbor(deloviList);

                    _viewDel.InfoPoraka = " Izlistani se delovite za izbor ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewDel.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewDel.ErrorPoraka = "Greska pri listanje delovi so IZBOR";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void zemiDelZaEdit()
        {
            try
            {
                IDeloviEditView _viewDelEdit = (IDeloviEditView)_view;
                Del delObj = new Del();

                RezultatKomanda rezultat = deloviDB.getDel(_viewDelEdit.ID_Delovi_Edit_Selected, ref delObj);

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _viewDelEdit.nacrtajFormaZaEditDelovi(delObj);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _viewDelEdit.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewDelEdit.ErrorPoraka = "Greska pri citanje na EDIT del";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}

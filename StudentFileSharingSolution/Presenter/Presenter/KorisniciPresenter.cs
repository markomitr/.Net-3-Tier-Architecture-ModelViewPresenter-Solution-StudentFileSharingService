using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Interface;
using DAL.DBAccess;
using ClassDLL.SysPart;
using ClassDLL.GreskiEX;
using ClassDLL.RegularExpression;
using ClassDLL.Interface;
using Presenter.Interface.KorisnikViews;
using Presenter.Interface.Views.KorisnikViews;
using Presenter.Interface.Presenters;
namespace Presenter.Presenter
{
    public class KorisniciPresenter : IKorisnikPresenter
    {
        IView _view;
        Type _viewType;
        KorisnikDB korDb;
        Korisnik korObj;
        //Ova ne mi e Reseno
        IMsgStatus getMsgStatus(IView view)
        {
            return (IMsgStatus)view;
        }
        public KorisniciPresenter(IView view)
        {
            _view = view;
            korDb = new KorisnikDB();
        }
        #region StarPresenter
        //public KorisniciPresenter(IView view)
        //{
        //    if (view is IKorisnikLoginStarView)
        //    {
        //        _viewType = typeof(IKorisnikLoginStarView);
        //    }
        //    else if (view is IKorisnikLoginCreateListView)
        //    {
        //        _viewType = typeof(IKorisnikLoginCreateListView);
        //    }
        //    else
        //    {
        //        _viewType = typeof(IView);
        //    }

        //    _view = view;

        //    korDb = new KorisnikDB();
        //}
        //public void logirajKorisnik()
        //{
        //    if (_viewType.Name.Equals("IKorisnikLoginStarView"))
        //    {
        //         IKorisnikLoginStarView _viewKor;
        //         _viewKor = ((IKorisnikLoginStarView)_view);

                
        //        korObj = new Korisnik ();
        //        try
        //        {
        //            RezultatKomanda rezultat = korDb.getKorisnik(_viewKor.UserID, _viewKor.Lozinka, ref korObj);
        //            if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
        //            {
        //                _viewKor.Poraka = "Logirani ste";
        //            }
        //            else if(rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
        //            {
        //                _viewKor.Poraka = rezultat.Pricina;
        //            }else if(rezultat.Rezultat == RezultatKomandaEnum.Greska)
        //            {
        //                _viewKor.Poraka = "Greska";
        //            }

        //        }
        //        catch (GlavenException ex)
        //        {

        //            if (ex is KonekcijaEX)
        //            {
        //                throw new Exception("KONEKCIJA NESTO ");
        //            }
        //        }
                
        //    }
        //}
        //public void logirajKorisnikTest()
        //{
        //    if (_viewType.Name.Equals("IKorisnikLoginCreateListView"))
        //    {
        //        IKorisnikLoginCreateListView _viewKor;
        //        _viewKor = ((IKorisnikLoginCreateListView)_view);


        //        korObj = new Korisnik();
        //        try
        //        {
        //            RezultatKomanda rezultat = korDb.getKorisnik(_viewKor.UserID, _viewKor.Lozinka, ref korObj);
        //            if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
        //            {
        //                _viewKor.PorakaLogin = "Logirani ste";
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
        //            {
        //                _viewKor.PorakaLogin = rezultat.Pricina;
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
        //            {
        //                _viewKor.PorakaLogin = "Greska";
        //            }

        //        }
        //        catch (GlavenException ex)
        //        {

        //            if (ex is KonekcijaEX)
        //            {
        //                throw new Exception("KONEKCIJA NESTO ");
        //            }
        //        }

        //    }
        //}
        //public void kreirajKorisnik()
        //{
        //    //if (_viewType.Name.Equals("IKorisnikLoginCreateListView"))
        //    //{
        //        IKorisnikLoginCreateListView _viewKor;
        //        _viewKor = ((IKorisnikLoginCreateListView)_view);

        //        korObj = new Korisnik();

        //        try
        //        {
        //            RezultatKomanda rezultat = korDb.addKorisnik(_viewKor.NovUserID, _viewKor.NovLozinka, _viewKor.NovEmail);
        //            if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
        //            {
        //                _viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
        //            {
        //                _viewKor.PorakaNovKor = rezultat.Pricina;
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
        //            {
        //                _viewKor.PorakaNovKor = "Greska pri kreiranje korisnik";
        //            }

        //        }
        //        catch (GlavenException ex)
        //        {
                    
        //            throw ex;
        //        }
        //    //}
        //}
        //public void listaKorisnici()
        //{
        //    if (_viewType.Name.Equals("IKorisnikLoginCreateListView"))
        //    {
        //        IKorisnikLoginCreateListView _viewKor;
        //        _viewKor = ((IKorisnikLoginCreateListView)_view);

        //        List<Korisnik> listaKor = new List<Korisnik>() ;

        //        try
        //        {
        //            RezultatKomanda rezultat = korDb.getKorisnici(ref listaKor);
        //            if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
        //            {
        //                //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
        //                _viewKor.ListaKorisnici = listaKor;
        //                _viewKor.napolniKorisnici();
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
        //            {
        //                _viewKor.PorakaNovKor = rezultat.Pricina;
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
        //            {
        //                _viewKor.PorakaNovKor = "Greska pri listanje korisnici";
        //            }
        //        }
        //        catch (GlavenException ex)
        //        {
                    
        //            throw ex;
        //        }
        //    }
        //}
        #endregion
        #region NovPresenterTest
        //public void logirajKorisnikNovTest()
        //{
        //    IKorisnikLoginView _viewKor = ((IKorisnikLoginView)_view);

        //        korObj = new Korisnik();
        //        try
        //        {
        //            FactoryRegEx regExFactory = new FactoryRegEx();
        //            RegExNas  proverka =(RegExNas) regExFactory.Produce(ValidatorEnum.Korisnik_UserID, null);

                    
        //            proverka.Validiraj(_viewKor.UserID_Login_Input);
                   
        //            if (proverka.uspeh == true)
        //            {
                        
        //            }
        //            RezultatKomanda rezultat = korDb.getKorisnik(_viewKor.UserID_Login_Input, _viewKor.Lozinka_Login_Input, ref korObj);
        //            if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
        //            {
        //                //_viewKor.PorakaLogin = "Logirani ste";
        //                getMsgStatus(_viewKor).InfoPoraka = "Logirani ste";
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
        //            {
        //                //_viewKor.PorakaLogin = rezultat.Pricina;
        //                getMsgStatus(_viewKor).ErrorPoraka = rezultat.Pricina;
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
        //            {
        //                //_viewKor.PorakaLogin = "Greska";
        //                getMsgStatus(_viewKor).ErrorPoraka = "Greska";
        //            }

        //        }
        //        catch (GlavenException ex)
        //        {

        //            if (ex is KonekcijaEX)
        //            {
        //                throw new Exception("KONEKCIJA NESTO ");
        //            }
        //        }

        //}
        //public void kreirajKorisnikNovTest()
        //{
        //        IKorisnikAddView _viewKor = ((IKorisnikAddView)_view);


        //        korObj = new Korisnik();
        //        try
        //        {
        //            RezultatKomanda rezultat = korDb.addKorisnik(_viewKor.UserId_Input, _viewKor.Lozinka_Input, _viewKor.Email_Input, _viewKor.Ime_Input,_viewKor.Prezime_Input);
        //            if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
        //            {
        //                //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
        //                getMsgStatus(_viewKor).InfoPoraka = "Kreiran e nov korisnik ";
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
        //            {
        //                getMsgStatus( _viewKor).ErrorPoraka = rezultat.Pricina;
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
        //            {
        //                getMsgStatus(_viewKor).ErrorPoraka = "Greska pri kreiranje korisnik";
        //            }

        //        }
        //        catch (GlavenException ex)
        //        {

        //            throw ex;
        //        }
        //}
        //public void listajKorisnici()
        //{
        //    IKorisninPregled8View _viewKor = ((IKorisninPregled8View)_view);
                
        //        List<Korisnik> listaKor = new List<Korisnik>();

        //        try
        //        {
        //            RezultatKomanda rezultat = korDb.getKorisnici(ref listaKor);
        //            if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
        //            {
        //                //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
        //                //_viewKor.ListaKorisnici = listaKor;
        //                //_viewKor.napolniKorisnici();
        //                _viewKor.nacrtajPregledZaKorisnici(listaKor);
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
        //            {
        //                //_viewKor.PorakaNovKor = rezultat.Pricina;
        //            }
        //            else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
        //            {
        //                //_viewKor.PorakaNovKor = "Greska pri listanje korisnici";
        //            }
        //        }
        //        catch (GlavenException ex)
        //        {

        //            throw ex;
        //        }
        //}
        //public void pregledKorisnik()
        //{
        //    IKorisnikPregled1View _viewKor = ((IKorisnikPregled1View)_view);

        //    List<Korisnik> listaKor = new List<Korisnik>();
        //    Korisnik korIzbran = new Korisnik();

        //    try
        //    {
        //        RezultatKomanda rezultat = korDb.getKorisnik(_viewKor.UserID_Korisnik_Pregled_Selected,ref korIzbran);
        //        if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
        //        {
        //            //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
        //            //_viewKor.ListaKorisnici = listaKor;
        //            //_viewKor.napolniKorisnici();
        //            _viewKor.nacrtajPregledZaKorisnik(korIzbran);
        //        }
        //        else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
        //        {
        //            //_viewKor.PorakaNovKor = rezultat.Pricina;
        //        }
        //        else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
        //        {
        //            //_viewKor.PorakaNovKor = "Greska pri listanje korisnici";
        //        }
        //    }
        //    catch (GlavenException ex)
        //    {

        //        throw ex;
        //    }

        //}
        //public void zemiKorisnikZaIzmena()
        //{
        //    IKorisnikUpdateFormView _viewKor = ((IKorisnikUpdateFormView)_view);

        //    //List<Korisnik> listaKor = new List<Korisnik>();
        //    Korisnik korIzbran = new Korisnik();

        //    try
        //    {
        //        RezultatKomanda rezultat = korDb.getKorisnik(_viewKor.UserID_Edit_Selected, ref korIzbran);
        //        if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
        //        {
        //            //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
        //            //_viewKor.ListaKorisnici = listaKor;
        //            //_viewKor.napolniKorisnici();
        //            _viewKor.nacrtajFormaZaUpdateKorisnik(korIzbran);
        //        }
        //        else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
        //        {
        //            //_viewKor.PorakaNovKor = rezultat.Pricina;
        //        }
        //        else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
        //        {
        //            //_viewKor.PorakaNovKor = "Greska pri listanje korisnici";
        //        }
        //    }
        //    catch (GlavenException ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public void izmeniKorisnik()
        //{

        //    IKorisnikUpdateView _viewKor = ((IKorisnikUpdateView)_view);

        //    korObj = new Korisnik(_viewKor.UserId_Update_Input, _viewKor.Lozinka_Update_Input,'D',"student", _viewKor.Ime_Update_Input,_viewKor.Prezime_Korisnik_Update_Input, _viewKor.Email_Update_Input);
            
        //    try
        //    {
        //        RezultatKomanda rezultat = korDb.updateKorisnik(korObj);
        //        if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
        //        {
        //            //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
        //            getMsgStatus(_viewKor).InfoPoraka = "Izmenat e korisnikot " + korObj.UserID;
        //        }
        //        else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
        //        {
        //            getMsgStatus(_viewKor).ErrorPoraka = rezultat.Pricina;
        //        }
        //        else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
        //        {
        //            getMsgStatus(_viewKor).ErrorPoraka = "Greska pri izmena korisnik";
        //        }

        //    }
        //    catch (GlavenException ex)
        //    {

        //        throw ex;
        //    }
        //}
        #endregion


        #region IKorisnikPresenter Members

        public void addKorisnik()
        {
            try
            {
                FactoryRegEx regExFactory = new FactoryRegEx();
                RegExNas proverka = (RegExNas)regExFactory.Produce(ValidatorEnum.Korisnik_UserID, null);
                RegExNas proverkaLozinka = (RegExNas)regExFactory.Produce(ValidatorEnum.Korisnik_Lozinka, null);
                RegExNas proverkaEmail = (RegExNas)regExFactory.Produce(ValidatorEnum.Korisnik_Email, null);
                RegExNas proverkaIme = (RegExNas)regExFactory.Produce(ValidatorEnum.Korisnik_Ime, null);
                RegExNas proverkaPrezime = (RegExNas)regExFactory.Produce(ValidatorEnum.Korisnik_Prezime, null);

                IKorisnikAddView _viewKor = ((IKorisnikAddView)_view);
                _viewKor.ClearValidacija();
                bool imaGreska = false;
                proverka.Validiraj(_viewKor.UserId_Korisnik_Add_Input);

                if (proverka.uspeh == true)
                {
                }
                else
                {
                    _viewKor.ErrorPoraka = proverka.poraka;
                    _viewKor.UserId_Korisnik_Add_Validacija = proverka.poraka;
                    imaGreska = true;
                }

                proverkaLozinka.Validiraj(_viewKor.Lozinka_Korisnik_Add_Input);

                if (proverkaLozinka.uspeh == true)
                {

                }
                else
                {
                    _viewKor.ErrorPoraka = proverkaLozinka.poraka;
                    _viewKor.Lozinka_Korisnik_Add_Validacija = proverkaLozinka.poraka;
                    imaGreska = true;
                }
                proverkaEmail.Validiraj(_viewKor.Email_Korisnik_Add_Input);

                if (proverkaEmail.uspeh == true)
                {

                }
                else
                {
                    _viewKor.ErrorPoraka = proverkaEmail.poraka;
                    _viewKor.Email_Korisnik_Add_Validacija = proverkaEmail.poraka;
                    imaGreska = true;
                }
                proverkaIme.Validiraj(_viewKor.Ime_Korisnik_Add_Input);
                if (proverkaIme.uspeh == true)
                {

                }
                else
                {
                    _viewKor.ErrorPoraka = proverkaIme.poraka;
                    _viewKor.Ime_Korisnik_Add_Validacija = proverkaIme.poraka;
                    imaGreska = true;
                }

                proverkaPrezime.Validiraj(_viewKor.Prezime_Korisnik_Add_Input);

                if (proverkaPrezime.uspeh == true)
                {

                }
                else
                {
                    _viewKor.ErrorPoraka = proverkaPrezime.poraka;
                    _viewKor.Prezime_Korisnik_Add_Validacija = proverkaPrezime.poraka;
                    imaGreska = true;
                }


                if (_viewKor.Lozinka_Korisnik_Add_Input == _viewKor.LozinkaCheck_Korisnik_Add_Input)
                {

                }
                else
                {
                    _viewKor.LozinkaCheck_Korisnik_Add_Validacija = "Не ја внесовте истата лозинка";
                    imaGreska = true;
                }
                if (imaGreska != true)
                {
                    korObj = new Korisnik();
                    RezultatKomanda rezultat = korDb.addKorisnik(_viewKor.UserId_Korisnik_Add_Input,
                                                                                   _viewKor.Lozinka_Korisnik_Add_Input,
                                                                                   _viewKor.Email_Korisnik_Add_Input,
                                                                                   _viewKor.Ime_Korisnik_Add_Input,
                                                                                   _viewKor.Prezime_Korisnik_Add_Input);
                    if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                    {
                        //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
                        _viewKor.InfoPoraka = "Kreiran e nov korisnik ";
                    }
                    else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                    {
                        _viewKor.ErrorPoraka = rezultat.Pricina;
                    }
                    else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                    {
                        _viewKor.ErrorPoraka = "Greska pri kreiranje korisnik";
                    }
                }
            }
            catch (GlavenException ex)
            {

                throw ex;
            }
        }

        public void addBrzKorisnk()
        {
           
            try
            {
                FactoryRegEx regExFactory = new FactoryRegEx();
                RegExNas proverkaUser = (RegExNas)regExFactory.Produce(ValidatorEnum.Korisnik_UserID, null);
                RegExNas proverkaLozinka = (RegExNas)regExFactory.Produce(ValidatorEnum.Korisnik_Lozinka, null);
                RegExNas proverkaEmail = (RegExNas)regExFactory.Produce(ValidatorEnum.Korisnik_Email, null);
                IKorisnikAddBrzView _viewKor = ((IKorisnikAddBrzView)_view);
                _viewKor.ClearValidacija();

                bool imaGreska = false;
                proverkaUser.Validiraj(_viewKor.UserId_Korisnik_AddBrz_Input);

                if (proverkaUser.uspeh == true)
                {
                }
                else
                {
                    _viewKor.ErrorPoraka = proverkaUser.poraka;
                    _viewKor.UserId_Korisnik_AddBrz_Validacija = proverkaUser.poraka;
                    imaGreska = true;
                }

                proverkaLozinka.Validiraj(_viewKor.Lozinka_Korisnik_AddBrz_Input);

                if (proverkaLozinka.uspeh == true)
                {
                }
                else
                {
                    _viewKor.ErrorPoraka = proverkaLozinka.poraka;
                    _viewKor.Lozinka_Korisnik_AddBrz_Validacija = proverkaLozinka.poraka;
                    imaGreska = true;
                }

                proverkaEmail.Validiraj(_viewKor.Email_Korisnik_AddBrz_Input);

                if (proverkaEmail.uspeh == true)
                {
                }
                else
                {
                    _viewKor.ErrorPoraka = proverkaEmail.poraka;
                    _viewKor.Email_Korisnik_AddBrz_Validacija = proverkaEmail.poraka;
                    imaGreska = true;
                }

                if (_viewKor.Lozinka_Korisnik_AddBrz_Input == _viewKor.Lozinka_Korisnik_AddBrz_Check_Input)
                {

                }
                else
                {
                    _viewKor.LozinkaCheck_Korisnik_AddBrz_Validacija = "Не ја внесовте истата лозинка";
                    imaGreska = true;
                }
                if (imaGreska != true)
                {
                    korObj = new Korisnik();

                    RezultatKomanda rezultat = korDb.addKorisnik(_viewKor.UserId_Korisnik_AddBrz_Input,
                                                                 _viewKor.Lozinka_Korisnik_AddBrz_Input,
                                                                 _viewKor.Email_Korisnik_AddBrz_Input);
                    if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                    {
                        //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
                        _viewKor.InfoPoraka = "Kreiran e nov korisnik. Za da pristapite do sistemot ve molime logirajte se! ";
                        _viewKor.uspeshnoDodadenKorisnkBrz();
                    }
                    else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                    {
                        _viewKor.ErrorPoraka = rezultat.Pricina;
                    }
                    else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                    {
                        _viewKor.ErrorPoraka = "Greska pri kreiranje korisnik";
                    }
                }
            }
            catch (GlavenException ex)
            {

                throw ex;
            }
        }
        public void updateKorisnik()
        {
            IKorisnikUpdateView _viewKor = ((IKorisnikUpdateView)_view);

            korObj = new Korisnik(_viewKor.UserId_Korisnik_Update_Input,"", 'D', "student",
                                    _viewKor.Ime_Korisnik_Update_Input, _viewKor.Prezime_Korisnik_Update_Input, _viewKor.Email_Korisnik_Update_Input);

            try
            {
                RezultatKomanda rezultat = korDb.updateKorisnik(korObj);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
                    _viewKor.InfoPoraka = "Izmenat e korisnikot " + korObj.UserID;
                }

                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                   _viewKor.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewKor.ErrorPoraka = "Greska pri izmena korisnik";
                }

            }
            catch (GlavenException ex)
            {

                throw ex;
            }
        }
        public void getKorisnik()
        {
            IKorisnikPregled1View _viewKor = ((IKorisnikPregled1View)_view);

            //List<Korisnik> listaKor = new List<Korisnik>();
            Korisnik korIzbran = new Korisnik();

            try
            {
                RezultatKomanda rezultat = korDb.getKorisnik(_viewKor.UserID_Korisnik_Pregled_Selected, ref korIzbran);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
                    //_viewKor.ListaKorisnici = listaKor;
                    //_viewKor.napolniKorisnici();
                    _viewKor.nacrtajPregledZaKorisnik(korIzbran);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    //_viewKor.PorakaNovKor = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewKor.ErrorPoraka = "Greska pri pregled korisnk";
                }
            }
            catch (GlavenException ex)
            {

                throw ex;
            }
        }

        public void getKorisnici()
        {
            IKorisnikPregled8View _viewKor = ((IKorisnikPregled8View)_view);

            List<Korisnik> listaKor = new List<Korisnik>();

            try
            {
                RezultatKomanda rezultat = korDb.getKorisnici(ref listaKor);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
                    //_viewKor.ListaKorisnici = listaKor;
                    //_viewKor.napolniKorisnici();
                    _viewKor.nacrtajPregledZaKorisnici(listaKor);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    //_viewKor.PorakaNovKor = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _viewKor.ErrorPoraka= "Greska pri listanje korisnici";
                }
            }
            catch (GlavenException ex)
            {

                throw ex;
            }
        }

        public void zemiKorisnikZaEdit()
        {
            IKorisnikUpdateView _viewKor = ((IKorisnikUpdateView)_view);

            //List<Korisnik> listaKor = new List<Korisnik>();
            Korisnik korIzbran = new Korisnik();

            try
            {
                RezultatKomanda rezultat = korDb.getKorisnik(_viewKor.UserId_Korisnik_Update_Selected, ref korIzbran);
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    //_viewKor.PorakaNovKor = "Kreiran e nov korisnik " + _viewKor.NovUserID;
                    //_viewKor.ListaKorisnici = listaKor;
                    //_viewKor.napolniKorisnici();
                    _viewKor.nacrtajFormaZaUpdateKorisnik(korIzbran);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    //_viewKor.PorakaNovKor = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    //_viewKor.PorakaNovKor = "Greska pri listanje korisnici";
                }
            }
            catch (GlavenException ex)
            {

                throw ex;
            }
        }

        public void loginKorisnik()
        {
            IKorisnikLoginView _viewKor = ((IKorisnikLoginView)_view);

            korObj = new Korisnik();
            try
            {
                FactoryRegEx regExFactory = new FactoryRegEx();
                RegExNas proverka = (RegExNas)regExFactory.Produce(ValidatorEnum.Korisnik_UserID, null);


                //proverka.Validiraj(_viewKor.UserID_Login_Input);

                //if (proverka.uspeh == true)
                //{

                //}
                
                //RezultatKomanda rezultat = korDb.getKorisnik(_viewKor.UserID_Login_Input, _viewKor.Lozinka_Login_Input, ref korObj);
                RezultatKomanda rezultat = new RezultatKomanda(true);
                Korisnik pom = new Korisnik();
                pom.UserID = "Marko";
                rezultat.Rezultat = RezultatKomandaEnum.Uspeh;

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    //_viewKor.PorakaLogin = "Logirani ste";
                    _viewKor.InfoPoraka = "Logirani ste";
                    _viewKor.logirajKorisnik(korObj);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    //_viewKor.PorakaLogin = rezultat.Pricina;
                    _viewKor.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    //_viewKor.PorakaLogin = "Greska";
                   _viewKor.ErrorPoraka = "Greska";
                }

            }
            catch (GlavenException ex)
            {

                if (ex is KonekcijaEX)
                {
                    throw new Exception("KONEKCIJA NESTO ");
                }
            }
        }

        #endregion


    }
}
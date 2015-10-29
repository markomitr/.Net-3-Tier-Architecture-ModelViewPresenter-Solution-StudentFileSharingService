using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Interface.Presenters;
using Presenter.Interface.Views.PorakaViews;
using Presenter.Interface;
using DAL.DBAccess;
using ClassDLL.SysPart;
using ClassDLL.RegularExpression;

namespace Presenter.Presenter
{
    public class PorakaPresenter : IPorakaPresenter
    {
        IView _view;
        PorakaDB porakaDB;
        public PorakaPresenter(IView view)
        {
            _view = view;
            porakaDB = new PorakaDB();
        }
        public void addPorakaPredmet()
        {
            try
            {
                FactoryRegEx regExFactory = new FactoryRegEx();
                RegExNas proverka = (RegExNas)regExFactory.Produce(ValidatorEnum.Poraka_Sodrzina, null);

                IPorakaPredmetAddView _porakaPredmetView = (IPorakaPredmetAddView)_view;

                proverka.Validiraj(_porakaPredmetView.Sodrzina_PorakaPredmet_Add_Input);
                RezultatKomanda rezultat = new RezultatKomanda(false);
                if (proverka.uspeh == true)
                {
                    rezultat = porakaDB.addPorakaPredmet(_porakaPredmetView.Predmet_ID_PorakaPredmet_Add_Input,
                                                                 _porakaPredmetView.Nasoka_ID_PorakaPredmet_Add_Input,
                                                                 _porakaPredmetView.UserID_PorakaPredmet_Add_Inpit,
                                                                 _porakaPredmetView.Sodrzina_PorakaPredmet_Add_Input,null);
                }
                else
                {
                    rezultat = porakaDB.addPorakaPredmet(_porakaPredmetView.Predmet_ID_PorakaPredmet_Add_Input,
                                                                _porakaPredmetView.Nasoka_ID_PorakaPredmet_Add_Input,
                                                                _porakaPredmetView.UserID_PorakaPredmet_Add_Inpit,
                                                                _porakaPredmetView.Sodrzina_PorakaPredmet_Add_Input,
                                                                'N');
                }
                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _porakaPredmetView.InfoPoraka = "Porakata e dodadena za predmetot ";
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _porakaPredmetView.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _porakaPredmetView.ErrorPoraka = "Greska pri kreiranje poraka za predmet";
                }

                else
                {
                    _porakaPredmetView.ErrorPoraka = proverka.poraka;
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void getPorakiPredmet()
        {
            try
            {
                FactoryRegEx regExFactory = new FactoryRegEx();
                RegExNas proverka = (RegExNas)regExFactory.Produce(ValidatorEnum.Poraka_Sodrzina, null);

                IPorakaPredmetPregled8View _porakaPredmetView = (IPorakaPredmetPregled8View )_view;
                List<PorakaPredmet> ppList = new List<PorakaPredmet>();
                List<PorakaPredmet> ppListIzmeneta = new List<PorakaPredmet>();


                RezultatKomanda rezultat = porakaDB.getPorakiPredmet(_porakaPredmetView.Predmet_ID_PorakaPredmet_Add_Selected,
                                                                     _porakaPredmetView.Nasoka_ID_PorakaPredmet_Add_Selected, ref ppList);

                foreach (PorakaPredmet poraka in ppList)
                {
                    proverka.Validiraj(poraka.Sodrzina);
                    if (proverka.uspeh == false && proverka.IzmenetVlez != "F")
                    {
                        poraka.Sodrzina = proverka.IzmenetVlez.ToString();
                        ppListIzmeneta.Add(poraka);
                    }
                    else if (proverka.uspeh==true)
                    {
                        ppListIzmeneta.Add(poraka);
                    }
                }

                if (rezultat.Rezultat == RezultatKomandaEnum.Uspeh)
                {
                    _porakaPredmetView.InfoPoraka = "Izlistani se porakite za predmetot ";
                    _porakaPredmetView.nacrtajPregledPorakiZaPredmet(ppListIzmeneta);
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    _porakaPredmetView.ErrorPoraka = rezultat.Pricina;
                }
                else if (rezultat.Rezultat == RezultatKomandaEnum.Greska)
                {
                    _porakaPredmetView.ErrorPoraka = "Greska pri pregled - poraki za predmet";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

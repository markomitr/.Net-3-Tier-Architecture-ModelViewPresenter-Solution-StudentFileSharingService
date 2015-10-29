using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class PredmetNasoka:IPredmetNasoka 
    {
        int _nasokaID;
        int _predmetID;
        int _krediti;
        int _tipPredmet;

        string _kod;
        string _ime;
        string _nasokaIme;
        string _predmetIme;
        string _predmetOpis;

        char _aktiven;
        bool _aktivenBool;

        DateTime _dodadenNa;


        public PredmetNasoka() { }
        public PredmetNasoka(int nasokaID,int predmetID)
        {
            this.NasokaID = nasokaID;
            this.PredmetID = predmetID;
        }

        public PredmetNasoka(int nasokaID, int predmetID,string kod,int krediti,char aktiven)
        {
            this.NasokaID = nasokaID;
            this.PredmetID = predmetID;
            this.Kod = kod;
            this.Krediti = krediti;
            this.Aktiven = aktiven;
        }

        public PredmetNasoka(int nasokaID, int predmetID, string kod, int krediti, char aktiven,DateTime dodadenNa,int tipPredmet)
        {
            this.NasokaID = nasokaID;
            this.PredmetID = predmetID;
            this.Kod = kod;
            this.Krediti = krediti;
            this.Aktiven = aktiven;
            this.DodadenNa = dodadenNa;
            this.TipPredmet = tipPredmet;
        }

        public PredmetNasoka(int nasokaID, int predmetID, string kod, int krediti, char aktiven, DateTime dodadenNa, int tipPredmet, string ime)
        {
            this.NasokaID = nasokaID;
            this.PredmetID = predmetID;
            this.Kod = kod;
            this.Krediti = krediti;
            this.Aktiven = aktiven;
            this.DodadenNa = dodadenNa;
            this.TipPredmet = tipPredmet;
            this.Ime = ime;
        }

        public PredmetNasoka(int nasokaID, int predmetID, string kod, int krediti, char aktiven, DateTime dodadenNa, int tipPredmet, string ime, string nasokaIme, string predmetIme)
        {
            this.NasokaID = nasokaID;
            this.PredmetID = predmetID;
            this.Kod = kod;
            this.Krediti = krediti;
            this.Aktiven = aktiven;
            this.DodadenNa = dodadenNa;
            this.TipPredmet = tipPredmet;
            this.Ime = ime;
            this.NasokaIme = nasokaIme;
            this.PredmetIme = predmetIme;
        }


        public int NasokaID
        {
            get
            {
                return this._nasokaID;
            }
            set
            {
                this._nasokaID = value;
            }
        }

        public int PredmetID
        {
            get
            {
                return this._predmetID;
            }
            set
            {
                this._predmetID = value;
            }
        }

        public string Kod
        {
            get
            {
                return this._kod;
            }
            set
            {
                this._kod = value;
            }
        }

        public string Ime
        {
            get
            {
                return this._ime;
            }
            set
            {
                this._ime = value;
            }
        }

        public int Krediti
        {
            get
            {
                return this._krediti;
            }
            set
            {
                this._krediti = value;
            }
        }

        public string NasokaIme
        {
            get
            {
                return this._nasokaIme;
            }
            set
            {
                this._nasokaIme = value;
            }
        }

        public string PredmetIme
        {
            get
            {
                return this._predmetIme;
            }
            set
            {
                this._predmetIme = value;
            }
        }
        public string PredmetOpis
        {
            get
            {
                return this._predmetOpis;
            }
            set
            {
                this._predmetOpis = value;
            }
        }
        
        public char Aktiven
        {
            get
            {
                return this._aktiven;
            }
            set
            {
                this._aktiven = value;
                if (value == 'D')
                {
                    this.AktivenBool = true;
                }
                else if (value == 'N')
                {
                    this.AktivenBool = false;
                }
            }
        }

        public bool AktivenBool
        {
            get
            {
                return this._aktivenBool;
            }
            set
            {
                this._aktivenBool = value;
            }
        }

        public DateTime DodadenNa
        {
            get
            {
                return this._dodadenNa;
            }
            set
            {
                this._dodadenNa = value;
            }
        }


        public int TipPredmet
        {
            get
            {
                return this._tipPredmet;
            }
            set
            {
                this._tipPredmet = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class PretplatenPredmet:IPretplatenPredmet
    {
        //PredmetNasoka Predmet { get; set; }
        //Korisnik Korisnik { get; set; }
        //DateTime DatumPretplata { get; set; }
        //Char Aktiven { get; set; }
        //Boolean AktivenBool { get; set; }

        PredmetNasoka _predmetNasoka;
        Korisnik _korisnik;

        DateTime _datumPretplata;
        Char _aktiven;

        public PretplatenPredmet()
        { 
            this._korisnik = new Korisnik();
            this._predmetNasoka = new PredmetNasoka();
        }
        public PretplatenPredmet(PredmetNasoka predmet,Korisnik korisnik) 
        {
            this.PredmetNasoka = predmet;
            this.Korisnik = korisnik;
        }

        public PretplatenPredmet(int NasokaID, int PredmetID, string PredmetIme, string PredmetOpis, string kod, int krediti, string NasokaIme, string KorisnikID, DateTime pretplatenNa, char aktiven)
        {
            this.PredmetNasoka = new PredmetNasoka(NasokaID, PredmetID);
            this.PredmetNasoka.Kod = kod;
            this.PredmetNasoka.PredmetIme = PredmetIme;
            this.PredmetNasoka.PredmetOpis = PredmetOpis;
            this.PredmetNasoka.NasokaIme = NasokaIme;
            this.PredmetNasoka.Krediti = krediti;

            this.Korisnik = new Korisnik();
            this.Korisnik.UserID = KorisnikID;

            this.DatumPretplata = pretplatenNa;
            this.Aktiven = aktiven;
        }

        #region IPretplatenPredmet Members

        public PredmetNasoka PredmetNasoka
        {
            get
            {
                return this._predmetNasoka;
            }
            set
            {
                this._predmetNasoka = value;
            }
        }

        public Korisnik Korisnik
        {
            get
            {
                return this._korisnik;
            }
            set
            {
                this._korisnik = value;
            }
        }

        public DateTime DatumPretplata
        {
            get
            {
                return this._datumPretplata;
            }
            set
            {
                this._datumPretplata = value;
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
            }
        }

        public bool AktivenBool
        {
            get
            {
                if (this.Aktiven == 'D')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (value == true)
                {
                    this.Aktiven = 'D';
                }
                else
                {
                    this.Aktiven = 'N';
                }
            }
        }

        #endregion
    }
}

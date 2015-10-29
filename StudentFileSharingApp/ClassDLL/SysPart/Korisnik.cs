using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.RegularExpression;
namespace ClassDLL.SysPart
{

    public class Korisnik
    {
        ProveriKorisnik proverka = new ProveriKorisnik();
        //Field - promenlivi
        string  _userId;
        string _lozinka;
        string _email;
        string _ime ;
        string _prezime ;
        string _izmenetOd;
       
        char _aktiven ;

        string _korTipID;
        KorisnikTip _tipKorisnik;

        DateTime _dodadenNa;
        DateTime _izmenetNa;

        
        //Konstruktori
        public Korisnik() { }
        public Korisnik(String UserID, String Lozinka)
        {
                this.UserID = UserID;
                this.Lozinka = Lozinka;
        }
        public Korisnik(String UserID, String Lozinka,Char Aktiven,string KorTipId)
        {
                this.UserID = UserID;
                this.Lozinka = Lozinka;
                this._aktiven = Aktiven;
                this.KorTip_ID = KorTipId;
        }
        public Korisnik(String UserID,String Ime,String Prezime,String Email, Char Aktiven, string KorTipId)
        {
            this.UserID = UserID;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this._aktiven = Aktiven;
            this.KorTip_ID = KorTipId;
            this.Email = Email;
        }
        public Korisnik(String UserID, String Lozinka, Char Aktiven,string KorTipId,String Ime,String Prezime,String EMail)
        {
                this.UserID = UserID;
                this.Lozinka = Lozinka;
                this._aktiven = Aktiven;
                this.KorTip_ID = KorTipId;
                this.Ime = Ime;
                this.Prezime = Prezime;
                this.Email = EMail ;
        }

        //Properties
        public String UserID
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }

        public String Lozinka
        {
            get
            {
                //if (proverka.PorveriLozinka(_lozinka))
                //{
                //    return this._lozinka;
                //}
                //else
                //{
                //    throw new Exception("lozinkata ne e validna");
                //}
                return this._lozinka;
            }
            set
            {
            //    if (proverka.PorveriLozinka(value))
            //    {

            //        this._lozinka = value;
            //    }
            //    else
            //    {
            //        throw new Exception("lozinkata ne e validna");
            //    }

                this._lozinka = value;
            }
        }
        public String Email
        {
            get
            {

                return this._email;
            }
            set
            {
                this._email = value;
            }
        }

        public String Ime
        {
            get
            {
                //if (proverka.PorveriIme(_ime))
                //{
                //    return this._ime;
                //}
                //else
                //{
                //    throw new Exception("nevalidno ime");
                //}
                return this._ime;
            }

            set
            {
                //if (proverka.PorveriIme(value))
                //{
                //    this._ime = value;
                //}
                //else
                //{
                //    throw new Exception("nevalidno ime");
                //}
                this._ime = value;
            }
        }


        public String Prezime
        {
            get
            {
                return this._prezime;
            }

            set
            {
                this._prezime = value;
            }
        }


        public DateTime DodadenNa
        {
            get { return this._dodadenNa ; }
            set { this._dodadenNa = value; }
        }

        public DateTime IzmenetNa
        {
            get { return this._izmenetNa ; }
            set { this._izmenetNa = value; }
        }

        public String IzmenetOd
        {
            get { return this._izmenetOd ; }
            set { this._izmenetOd = value; }
        }

        public String  KorTip_ID
        {
            set {
                this._korTipID = value;
                if (value.ToLower() == "student")
                {
                    this._tipKorisnik = KorisnikTip.Student;
                }
                else if (value.ToLower() == "profesor")
                {
                    this._tipKorisnik = KorisnikTip.Profesor;
                }
            }
        }
        public KorisnikTip TipKorisnik
        {
            get { return this._tipKorisnik; }
            set { this._tipKorisnik = value; }
        }
        public  Boolean Aktiven
        {
            get
            {
                if (this._aktiven == 'D')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public char AktivenChar
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
    }
}

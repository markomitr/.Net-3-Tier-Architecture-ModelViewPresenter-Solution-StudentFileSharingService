using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.SysPart
{
    public enum RezultatKomandaEnum
    {
        Uspeh,Greska,Neuspeh
    }
    public enum KorisnikTip
    {
        Student, Profesor
    };


    public  enum ValidatorEnum
    {
        Korisnik_UserID, Korisnik_Lozinka, Korisnik_Email,Korisnik_Ime,Korisnik_Prezime,
        Materijal_Naslov, Materijal_Opis, Poraka_Sodrzina
    }

    public enum MaterijalTip
    {
        Slika,Arhiva,Word,Excel,PowerPoint,Pdf,Text,Html,Nepoznato,Greska
    };

    public enum RejtingTip
    {
        Pozitiven,Negativen
    };
    public static class Enumerator
    {
    }
}

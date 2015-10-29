using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;

namespace DAL.Interface
{
    public interface IDBUstanovi
    {
        RezultatKomanda addUstanova(String Ime, String Adresa, String WebStrana, int Institucija_ID);
        RezultatKomanda addUstanova(Ustanova ustanovaObj);

        RezultatKomanda updateUstanova(int UstanovaID, int Institucija_ID, String Ime, String Adresa, String WebStrana);
        RezultatKomanda updateUstanova(Ustanova ustanovaObj);

        RezultatKomanda deleteUstanova(int UstanovaID);
        RezultatKomanda deleteUstanova(Ustanova ustanovaObj);

        RezultatKomanda getUstanova(int UstanovaID, ref Ustanova ustanovaObj);
        RezultatKomanda getUstanovi(ref List<Ustanova> ustanoviLista);
        RezultatKomanda getUstanoviPoInstitucii(int Institucija_ID, ref List<Ustanova> ustanoviLista);
    }
}

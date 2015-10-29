using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace DAL.Interface
{
    public interface IDBInstitucii
    {
        RezultatKomanda addInstitucija(String Ime, String Adresa, String Kratenka);
        RezultatKomanda addInstitucija(Institucija instObj);

        RezultatKomanda updateInstitucija(int ID, String ime, String Adresa, String Kratenka);
        RezultatKomanda updateInstitucija(Institucija instObj);

        RezultatKomanda deleteInstitucija(int ID);
        RezultatKomanda deleteInstitucija(Institucija instObj);

        RezultatKomanda getInstitucija(int ID, ref Institucija instObj);
        RezultatKomanda getInstitucii(ref List<Institucija> instLista);
    }
}

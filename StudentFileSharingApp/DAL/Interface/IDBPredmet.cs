using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace DAL.Interface
{
    public interface IDBPredmet
    {
        RezultatKomanda addPredmet(String Ime, String Opis);
        RezultatKomanda addPredmet(Predmet predmetObj);

        RezultatKomanda updatePredmet(int ID,String Ime, String Opis);
        RezultatKomanda updatePredmet(Predmet predmetObj);

        RezultatKomanda deletePredmet(int ID);
        RezultatKomanda deletePredmet(Predmet predmetObj);

        RezultatKomanda getPredmet(int ID, ref Predmet predmetObj);
        RezultatKomanda getPredmeti(ref List<Predmet> predmetiLista);
    }
}

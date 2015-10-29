using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace DAL.Interface
{
    public interface IDBPoraka
    {
        RezultatKomanda addPorakaPredmet(int Predmet_ID, int Nasoka_ID, String DodadenaOd, String Sodrzina,char? validna);
        RezultatKomanda addPorakaPredmet(int Predmet_ID, int Nasoka_ID, Poraka porakaObj);
        RezultatKomanda addPorakaPredmet(PorakaPredmet porakaPredmetObj);

        RezultatKomanda getPorakiPredmet(int Predmet_ID, int Nasoka_ID, ref List<PorakaPredmet> ppList);
        RezultatKomanda getPorakiPredmet(int Predmet_ID, int Nasoka_ID, Char Aktivna, ref List<PorakaPredmet> ppList);
        RezultatKomanda getPorakiPredmet(int Predmet_ID, int Nasoka_ID,String DodadenaOd, ref List<PorakaPredmet> ppList);
        RezultatKomanda getPorakiPredmet(int Predmet_ID, int Nasoka_ID,String DodadenaOd, Char Aktivna, ref List<PorakaPredmet> ppList);
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace DAL.Interface
{
    public interface IDBNasoki
    {
        RezultatKomanda addNasoka(String Ime, String Opis, int Oblast_ID);
        RezultatKomanda addNasoka(Nasoka nasokaObj);

        RezultatKomanda updateNasoka(int ID, int Oblast_ID, String Ime, String Opis);
        RezultatKomanda updateNasoka(Nasoka NasokaObj);

        RezultatKomanda deleteNasoka(int ID);
        RezultatKomanda deleteNasoka(Nasoka NasokaObj);

        RezultatKomanda getNasoka(int ID, ref Nasoka nasokaObj);
        RezultatKomanda getNasoki(ref List<Nasoka> nasokiLista);
        RezultatKomanda getNasokiPoOblast(int Oblast_ID, ref List<Nasoka> nasokiLista);



        RezultatKomanda addPredmetPoNasoka(int Nasoka_ID, int Predmet_ID,String Ime,String Kod,int Krediti);
        RezultatKomanda getPredmetiPoNasoka(int Nasoka_ID, ref List<PredmetNasoka> predmetiPoNasokaLista);

        RezultatKomanda addDeloviZaPredmetPoNasoka(int Nasoka_ID, int Predmet_ID, int Delovi_ID, int Stuff_ID);
        RezultatKomanda getDeloviZaPredmetPoNasoka(int? Nasoka_ID, int? Predmet_ID, ref List<DeloviPredmetNasoka> delPredmetNasokaList);
    }
}

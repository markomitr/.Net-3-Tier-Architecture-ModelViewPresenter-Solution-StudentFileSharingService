using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace DAL.Interface
{
    public interface IDBPredmetiNasoka
    {
        //Ovaj inteface e vsusnot onaj objekt koj sto ke go koristime nie nasekade 
        //bidejki ni gi pretstavuva predmetite spored nasokata
        //Matematika na ProgramskoInzenerstvo
        //Matematika na Biohemija
        //Matematika na ekonomski(Ekonomska Matematika)


        RezultatKomanda addPredmetNasoka(int nasokaID,int predmetID,int tipPredmet);
        RezultatKomanda addPredmetNasoka(int nasokaID, int predmetID, int tipPredmet,String kod,int krediti,String ime);
        RezultatKomanda addPredmetNasoka(PredmetNasoka  predmetNasokaObj);

        RezultatKomanda updatePredmetNasoka(int nasokaID, int predmetID, int? tipPredmet, String kod, int? krediti, String ime);
        RezultatKomanda updatePredmetNasoka(PredmetNasoka predmetNasokaObj);

        RezultatKomanda deletePredmetNasoka(int nasokaID, int predmetID);
        RezultatKomanda deletePredmetNasoka(PredmetNasoka predmetNasokaObj);

        RezultatKomanda getPredmetNasoka(int nasokaID, int predmetID, ref PredmetNasoka predmetNasokaObj);
        RezultatKomanda getPredmetiNasoka(int? nasokaID, int? predmetID, ref List<PredmetNasoka> predmetiLista);

        //del za pretlata na korisnici na odreden predmet
        #region KorisnikPredmet

        RezultatKomanda addKorisnikPredmet(int nasokaID, int predmetID, string korisnikID);
        RezultatKomanda addKorisnikPredmet(int nasokaID, int predmetID, Korisnik korisnikObj);
        RezultatKomanda addKorisnikPredmet(PredmetNasoka predmetNasokaObj, string korisnikID);
        RezultatKomanda addKorisnikPredmet(PredmetNasoka predmetNasokaObj, Korisnik korisnikObj);

        RezultatKomanda deleteKorisnikPredmet(int nasokaID, int predmetID, string korisnikID);
        
        //Gi brisi site korisnici od daden predmet/nasoka
        RezultatKomanda deleteKorisniciOdPredmet(int nasokaID, int predmetID);
        RezultatKomanda deleteKorisniciOdPredmet(PredmetNasoka predmetNasokaObj);

        //Pregled na korisnici koi se pretplateni na odreden predmet/nasoka
        RezultatKomanda getKorisniciPredmet(int nasokaID, int predmetID, ref List<Korisnik> korLista);
        RezultatKomanda getKorisniciPredmet(PredmetNasoka predmetNasokaObj, ref List<Korisnik> korLista);

        //Pregled na predmeti na koi sto eden korisnik e pretplaten
        RezultatKomanda getKorisnikPredmeti(string korisnikID,ref List<PretplatenPredmet> listaPredmeti);
        
        //lista na predmeti na koi sto korisnikot ne e pretplaten
        RezultatKomanda getPredmetiNasokaNepetplaten(int? oblastID,int? nasokaID, string KorisnikID, ref List<PredmetNasoka> predmetiLista);
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace DAL.Interface
{
    public interface IDBMaterijali
    {
        //ovie se opsti funkcii - treba da se implementiraat i funkcii za dodavanje na materijal na soodveten del/nasoka .... 

        RezultatKomanda addMaterijal(String Naslov,String Opis,String DodadenOd,String Slika,String Pateka,String Type);
        RezultatKomanda addMaterijal(Materijal materijalObj);

        RezultatKomanda updateMaterijal(int MaterijalID,String Naslov, String Opis, String DodadenOd, String Slika, String Pateka,String Type);
        RezultatKomanda updateMaterijal(Materijal materijalObj);

        RezultatKomanda deleteMaterijal(int ID);
        RezultatKomanda deleteMaterijal(Materijal materijalObj);

        RezultatKomanda getMaterijal(int ID, ref Materijal materijalObj);
        RezultatKomanda getMaterijali(ref List<Materijal> marerijaliLista);
        
        //Da se definiraat ostanatite funkcii za dodavanje na materijalite na del/nasoka , listanje na istite i t.n
        
        //Lista na materijali postaveni od eden korisnik
        RezultatKomanda getMaterijali(String DodadenOd, ref List<Materijal> marerijaliLista);

       

        #region MaterijalPredmet

        //Lista na meterijali daden predmet (laboratoriski , predavanja ... ) 
        RezultatKomanda getMaterijali(int NasokaID,int PredmetID,int? DeloviID,ref MaterijaliGrupirani  grupiranMaterijali);

        //Dodadi materijal na odreden predmet(Predmet/Nasoka)
        RezultatKomanda addMaterijalPredmet(int MaterijalID, int NasokaID, int PredmetID,int DelID);

        RezultatKomanda addMaterijalPredmet(int MaterijalID, PredmetNasoka predmetNasokaObj,int DelID);

        RezultatKomanda addMaterijalPredmet(Materijal matObj, int NasokaID, int PredmetID,int DelID);

        RezultatKomanda addMaterijalPredmet(Materijal matObj, PredmetNasoka predmetNasokaObj,Del delObj);

        //Brisenje na materijal od daden predmet - otstranuvanje 
        RezultatKomanda deleteMaterijalOdPredmet(int MaterijalID,int NasokaID,int PredmetID,int DelID);
        RezultatKomanda deleteMaterijalOdPredmet(Materijal matObj, int NasokaID, int PredmetID, int DelID);
        RezultatKomanda deleteMaterijalOdPredmet(int MaterijalID, PredmetNasoka predmetNasokaObj, int DelID);
        RezultatKomanda deleteMaterijalOdPredmet(Materijal matObj, PredmetNasoka predmetNasokaObj, int DelID);

        RezultatKomanda addDownloadCount(int MaterijalID, int NasokaID, int PredmetID, int DelID);
        RezultatKomanda addRejting(int MaterijalID, int NasokaID, int PredmetID, int DelID, RejtingTip tipRejting);

        #endregion
    }
}

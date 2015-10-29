using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace DAL.Interface
{
    public interface IDBOblasti
    {
        RezultatKomanda addOblast(String Ime, String Adresa, String WebStrana, int Ustanova_ID);
        RezultatKomanda addOblast(Oblast OblastObj);

        RezultatKomanda updateOblast(int OblastID, int Ustanova_ID, String Ime, String Adresa, String WebStrana);
        RezultatKomanda updateOblast(Oblast oblastObj);

        RezultatKomanda deleteOblast(int OblastID);
        RezultatKomanda deleteOblast(Oblast oblastObj);

        RezultatKomanda getOblast(int OblastID, ref Oblast oblastObj);
        RezultatKomanda getOblasti(ref List<Oblast> oblastiLista);
        RezultatKomanda getOblastiPoUstanova(int Ustanova_ID, ref List<Oblast> oblastiLista);
    }
}

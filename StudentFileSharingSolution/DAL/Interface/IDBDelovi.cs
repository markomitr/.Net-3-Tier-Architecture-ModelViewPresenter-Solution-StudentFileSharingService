using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace DAL.Interface
{
    public interface IDBDelovi
    {
        RezultatKomanda addDel(String Ime,char ImaPredavac,int VidIzgled);
        RezultatKomanda addDel(Del  delObj);

        RezultatKomanda updateDel(int ID, String ime, char ImaPredavac,int VidIzgled,char aktiven);
        RezultatKomanda updateDel(Del delObj);

        RezultatKomanda deleteDel(int ID);
        RezultatKomanda deleteDel(Del delObj);

        RezultatKomanda getDel(int ID, ref Del delObj);
        RezultatKomanda getDelovi(ref List<Del> deloviLista);
    }
}

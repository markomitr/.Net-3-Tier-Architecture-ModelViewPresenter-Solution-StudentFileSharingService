using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interface
{
    /*
     * Interfejs za komunikacija na entitetot
     * KorisniciTp so bazata(Add,Edti,Update,Delete)
     * KorisniciTip se odnesuva na (Student,Profesor,Sorabotnik,etc.)
    */
    interface IDBKorisnikTip
    {
        //ADD
        bool addTip(String tipID, String Opis);
        bool addTip(Object tipObj);

        //EDIT
        bool updateTip(String tipID, String opis);
        bool updateTip(String tipID, Char aktiven);
        bool updateTip(String tipID,String opis, Char aktiven);
        bool updateTip(Object tipObj);
        
        //DEACTIVATE
        bool deactivateTip(String tipID);

        //GET
        bool getTip(ref LinkedList<Object> listaTip);
        bool getTip(Char aktiven ,ref LinkedList<Object> listaTip);
    }
}

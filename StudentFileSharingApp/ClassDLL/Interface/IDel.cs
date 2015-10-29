using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.Interface
{
    /// <summary>
    /// Interfejs koj ja definira strukturata na Del. Sekoj predmet e strukturiran spored obvrskite koi se 
    /// zastapeni vo ramkite na kursot, del moze da pretstavuva (Predavanje, Laboratoriski, Esej, Auditoriski), 
    /// Celta e na korisnikot da mu se ovozmozi kreiranje na novi obvrski vo ramki na eden kurs.
    /// </summary>
   public  interface IDel
    {
       int ID { get; set; }
       int Vid_Izgled { get; set; }
       String Ime { get; set; }
       char ImaPredavac { get; set; }
       bool ImaPredavacBool { get; set; }
       char Aktiven { get; set; }
    }
}

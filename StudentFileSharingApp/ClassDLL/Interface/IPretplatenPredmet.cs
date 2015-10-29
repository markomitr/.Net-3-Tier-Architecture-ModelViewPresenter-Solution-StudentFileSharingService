using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace ClassDLL.Interface
{
    public interface IPretplatenPredmet
    {
        PredmetNasoka  PredmetNasoka { get; set; }
        Korisnik Korisnik { get; set; }
        DateTime DatumPretplata { get; set; }
        Char Aktiven { get; set; }
        Boolean AktivenBool { get; set; }
    }
}

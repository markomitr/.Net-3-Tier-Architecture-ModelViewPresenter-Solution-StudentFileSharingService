using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.Interface
{
    public interface IPoraka
    {
        int PorakaID { get; set; }
        String Sodrzina { get; set; }
        Char Aktivna { get; set; }
        Decimal Rejting { get; set; }
        DateTime DodadenaNa { get; set; }
        String DodadenaOd { get; set; }
        DateTime IzmenetaNa { get; set; }
        String IzmenetaOd { get; set; }
    }
}

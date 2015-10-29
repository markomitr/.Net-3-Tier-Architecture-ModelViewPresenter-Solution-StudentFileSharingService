using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.Interface
{
    public interface IDeloviPredmetNasoka
    {
        int Nasoka_ID { get; set; }
        String Nasoka_Ime { get; set; }
        int Predmet_ID { get; set; }
        String Predmet_Ime { get; set; }
        int Del_ID { get; set; }
        String Del_Ime { get; set; }
        int Stuff_ID { get; set; }
        char Aktiven { get; set; }
    }
}

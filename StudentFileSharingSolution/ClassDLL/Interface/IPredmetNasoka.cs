using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.Interface
{
    public interface IPredmetNasoka
    {
        //Ova e vusnost realizacija na eden predmet vo soodvetna nasoka
        // Primer Matematika na Prorramski Inzenerstvo, Matematika na Hemija ...
        int NasokaID { get; set; }
        int PredmetID { get; set; }
        int TipPredmet { get; set; }
    
        String Kod { get; set; }
        String Ime { get; set; }
        int Krediti { get; set; }
        char Aktiven { get; set; }
        bool AktivenBool { get; set; }

        DateTime DodadenNa { get; set; }

        //Ovie dve polinja dobro e da gi ima za da ne pravime mnogu join na tabelite vo bazata
        String NasokaIme { get; set; }
        String PredmetIme { get; set; }
        String PredmetOpis { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace ClassDLL.Interface
{
    public interface IMaterijal
    {
        int MaterijalID { get; set; }
        
        String Naslov { get; set; }
        String Opis { get; set; }

        //Mozebi e dobro za DodadenOD da kreirame nekoj tenok objekt Korisnik - so ime , id  i takvi sitni raboti  ??? Da se razmisli 
        String DodadenOd { get; set; }
        
        String Slika { get; set; }
        String Pateka { get; set; }

        int Prevzemen { get; set; }
        int DobarRejting { get; set; }
        int LosRejting { get; set; }

        DateTime DodadenNa { get; set; }

        Char Aktiven { get; set; }
        bool AktivenBool { get; set; }

        string Type { get; set; }
        MaterijalTip TypeEnum { get; set; }
        //overload na tosting
        string ToString();
    }
}

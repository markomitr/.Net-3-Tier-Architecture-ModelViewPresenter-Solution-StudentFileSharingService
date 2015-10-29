using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassDLL.SysPart;
namespace ClassDLL.Interface
{
    public interface IMaterijaliGrupirani
    {
        Nasoka Nasoka {get;set;}
        Predmet Predmet {get;set;}

        Boolean PoDelovi { get; set; }

        //Ako e grupiranjeto po delovi togas imame kompozicija
        LinkedList<DelMaterijali> DeloviMaterijali { get; set; }

        //Ako nemame grupiranje togas imame samo lista od materijali(go znaeme delot)
        LinkedList<Materijal> Materijali { get; set; }
    }
}

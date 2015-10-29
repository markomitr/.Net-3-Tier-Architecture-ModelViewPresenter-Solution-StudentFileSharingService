using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.CompositeViews
{
    public interface IPredmetNasokaPregled1View:IView,IMsgStatus 
    {
        int Nasoka_ID_PredmetNasoka_Pregled_Selected { get; set; }
        int Predmet_ID_PredmetNasoka_Pregled_Selected { get; set; }

        void nacrtajPregledPredmetiZaNasoka(PredmetNasoka predmetNasokaObj);
    }
}

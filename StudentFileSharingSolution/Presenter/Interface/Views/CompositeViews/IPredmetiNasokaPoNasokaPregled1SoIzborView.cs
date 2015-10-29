using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.CompositeViews
{
    public interface IPredmetiNasokaPoNasokaPregled1SoIzborView :IView,IMsgStatus 
    {
        int NasokaID_PredmetiNasoka_PregledFilter_Selected { get; set; }
        int Nasoka_ID_PredmetiNasoka_PregledIzbor_Selected { get; set; }
        int Predmet_ID_PredmetiNasoka_PregledIzbor_Selected { get; set; }
        void nacrtajPregledPredmetiZaNasokaSoIzbor(List<PredmetNasoka> pnList);
    }
}

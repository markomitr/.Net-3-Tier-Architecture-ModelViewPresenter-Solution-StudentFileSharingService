using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.CompositeViews
{
    public interface IPredmetiNasokaPoNasokaPregled1View:IView,IMsgStatus
    {
        int NasokaID_PredmetiNasoka_PregledFilter_Selected { get; set; }
        void nacrtajPregledPredmetiZaNasoka(List<PredmetNasoka> pnList);
    }
}

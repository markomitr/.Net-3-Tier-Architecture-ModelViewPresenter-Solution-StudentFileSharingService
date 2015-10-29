using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Interface.Views.NasokaViews;
using Presenter.Interface.Views.PredmetViews;



namespace Presenter.Interface.Views.CompositeViews
{
    public interface IPredmetNasokaAddView : IPredmetPregled8SoIzborView,INasokaPregledSoFilterView,IMsgStatus
    {
        String Ime_PredmetNasoka_Input { get; set; }
        String Kod_PredmetNasoka_Input { get; set; }
        int Krediti_PredmetNasoka_Input { get; set; }

    }
}

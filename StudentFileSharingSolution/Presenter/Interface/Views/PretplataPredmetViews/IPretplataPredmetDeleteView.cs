using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.PretplataPredmetViews
{
    public interface IPretplataPredmetDeleteView:IView,IMsgStatus 
    {
        string KorisnikID_PreplataPredmet_Delete_Input { get; set; }
        int PredmetID_PretplataPredmet_Delete_Input { get; set; }
        int NasokaID_PretplataPredmet_Delete_Input { get; set; }

        void nacrtajFormaZaDeletePretplatenPredmet();
    }
}

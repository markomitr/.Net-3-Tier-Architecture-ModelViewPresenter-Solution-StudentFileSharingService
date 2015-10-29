using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.PretplataPredmetViews
{
    public interface IPretplataPredmetPregled8SoIzborView:IView,IMsgStatus
    {
        String Korisnik_ID_PretplataPredmet_PregledIzbor_Input { get; set; }

        int PredmetID_PretplataPredmet_PregledIzbor_Selected { get; set; }

        void nacrtajPregledSoIzborPretplateniPredmeti(List<PretplatenPredmet> listaPredmeti);
    }
}

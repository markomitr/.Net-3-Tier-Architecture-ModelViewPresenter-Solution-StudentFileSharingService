using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.PretplataPredmetViews
{
    public interface INePretplataPredmetPregled8SoIzborView:IView,IMsgStatus
    {
        String Korisnik_ID_NePretplataPredmet_PregledIzbor_Input { get; set; }
        int? OblastID_NePretplataPredmet_PregledIzbor_Input { get; set; }
        int? NasokaID_NePretplataPredmet_PregledIzbor_Input { get; set; }

        int PredmetID_NePretplataPredmet_PregledIzbor_Selected { get; set; }
        void nacrtajPregledSoIzborNePretplateniPredmeti(List<PredmetNasoka> listaPredmeti);
    }
}

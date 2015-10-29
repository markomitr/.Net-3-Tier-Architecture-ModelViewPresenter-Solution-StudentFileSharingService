using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.PretplataPredmetViews
{
    public interface IPretplataPredmetAddView:IView,IMsgStatus
    {
        String KorisnikID_PretplataPredmet_Add_Input { get; set; }
        int NasokaID_PretplataPredmet_Add_Input { get; set; }
        int PredmetID_PretplataPredmet_Add_Input { get; set; }

        void nacrtajFormaZaAddPretplataPredmet();
    }
}

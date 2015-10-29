using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.NasokaViews
{
    public interface INasokaAddView : IView, IMsgStatus
    {
        String Ime_Nasoka_Add_Input { get; set; }
        String Opis_Nasoka_Add_Input { get; set; }
        int OblastID_Nasoka_Add_Input { get; set; }
        void nacrtajFormaZaAddNasoka();
    }
}

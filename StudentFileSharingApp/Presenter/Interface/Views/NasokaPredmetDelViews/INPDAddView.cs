using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.NasokaPredmetDelViews
{
    public interface INPDAddView : IView,IMsgStatus 
    {
        int Nasoka_ID_NasokaPredmetDel_Input { get; set; }
        int Predmet_ID_NasokaPredmetDel_Input { get; set; }
        int Delovi_ID_NasokaPredmetDel_Input { get; set; }
        int Stuff_ID_NasokaPredmetDel_Input { get; set; }
    }
}

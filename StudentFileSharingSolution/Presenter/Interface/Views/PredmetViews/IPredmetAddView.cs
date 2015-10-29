using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.PredmetViews
{
    public interface IPredmetAddView : IMsgStatus
    {
        String Ime_Predmet_Add_Input { get; set; }
        String Opis_Predmet_Add_Input { get; set; }
    }
}

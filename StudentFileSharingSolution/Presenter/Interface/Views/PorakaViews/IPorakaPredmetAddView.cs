using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.PorakaViews
{
    public interface IPorakaPredmetAddView : IView,IMsgStatus
    {
        int Predmet_ID_PorakaPredmet_Add_Input { get; set; }
        int Nasoka_ID_PorakaPredmet_Add_Input { get; set; }
        String Sodrzina_PorakaPredmet_Add_Input { get; set; }
        String UserID_PorakaPredmet_Add_Inpit { get; set; }
    }
}

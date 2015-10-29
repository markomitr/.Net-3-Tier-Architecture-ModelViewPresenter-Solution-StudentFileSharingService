using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;

namespace Presenter.Interface.Views.PredmetViews
{
    public interface IPredmetEditView : IMsgStatus
    {
        int ID_Predmet_Edit_Selected { get; set; }
        int ID_Predmet_Edit_Input { get; set; }
        String Ime_Predmet_Edit_Input { get; set; }
        String Opis_Predmet_Edit_Input { get; set; }

        void nacrtajFromaZaEditPredmet(Predmet predmetObj);
    }
}

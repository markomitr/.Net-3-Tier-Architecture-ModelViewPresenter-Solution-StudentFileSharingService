using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.NasokaViews
{
    public interface INasokaEditView : IView, IMsgStatus
    {
        int ID_Nasoka_Edit_Input { get; set; }
        String Ime_Nasoka_Edit_Input { get; set; }
        String Opis_Nasoka_Edit_Input { get; set; }
        int ID_Nasoka_Edit_Selected { get; set; }
        int OblastID_Nasoka_Edit_Input { get; set; }
        void nacrtajFormaZaEditNasoka(Nasoka nasokaObj);
    }
}

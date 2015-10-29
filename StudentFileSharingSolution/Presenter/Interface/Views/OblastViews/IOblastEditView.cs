using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.OblastViews
{
    public interface IOblastEditView :IView,IMsgStatus
    {
        
        int ID_Oblast_Edit_Input { get; set; }
        String Ime_Oblast_Edit_Input { get; set; }
        String Adresa_Oblast_Edit_Input { get; set; }
        String WebStrana_Oblast_Edit_Input { get; set; }

        int ID_Oblast_Edit_Selected { get; set; }
        int ID_Ustanova_Oblast_Edit_Selected { get; set; }

        void nacrtajFromaZaEditOblast(Oblast oblastObj);
    }
}

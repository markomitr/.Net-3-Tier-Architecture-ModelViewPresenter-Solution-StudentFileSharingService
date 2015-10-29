using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.UstanovaViews
{
    public interface IUstanovaEditView : IView,IMsgStatus
    {

        int ID_Ustanova_Edit_Input { get; set; }
        int ID_Institucija_Edit_Input { get; set; }
        String Ime_Ustanova_Edit_Input { get; set; }
        String Adresa_Ustanova_Edit_Input { get; set; }
        String WebStrana_Ustanova_Edit_Input { get; set; }

        int ID_Ustanova_Edit_Selected { get; set; }

        void nacrtajFromaZaEditUstanova(Ustanova ustanovaObj,List<Institucija> institucii);

    }
}

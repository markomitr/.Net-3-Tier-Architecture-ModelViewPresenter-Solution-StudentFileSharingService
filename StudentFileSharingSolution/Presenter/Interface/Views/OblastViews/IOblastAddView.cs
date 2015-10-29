using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.OblastViews
{
    public interface IOblastAddView : IView,IMsgStatus
    {
        String Ime_Oblast_Add_Input { get; set; }
        String Adresa_Oblast_Add_Input { get; set; }
        String WebStrana_Oblast_Add_Input { get; set; }
        int UstanovaID_Oblast_Add_Input { get; set; }
        void nacrtajFormaZaAddOblast();
    }
}

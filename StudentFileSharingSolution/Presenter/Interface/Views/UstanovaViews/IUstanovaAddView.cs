using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.UstanovaViews
{
    public interface IUstanovaAddView: IView ,IMsgStatus 
    {
        String Ime_Ustanova_Add_Input { get; set; }
        String Adresa_Ustanova_Add_Input { get; set; }
        String WebStrana_Ustanova_Add_Input { get; set; }
        int InstitucijaID_Ustanova_Add_Input { get; set; }
        void nacrtajFormaZaAddUstanova();
    }
}

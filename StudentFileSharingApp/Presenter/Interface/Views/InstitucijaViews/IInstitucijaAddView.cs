using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.InstitucijaViews
{
    public interface IInstitucijaAddView: IView ,IMsgStatus 
    {
        String Ime_Institucija_Add_Input { get; set; }
        String Adresa_Institucija_Add_Input { get; set; }
        String Kratenka_Institucija_Add_Input { get; set; }

        void nacrtajFormaZaAddInstitucija();
    }
}

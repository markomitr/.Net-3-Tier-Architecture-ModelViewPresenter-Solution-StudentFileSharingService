using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.InstitucijaViews
{
    public interface IInstitucijaEditView : IView,IMsgStatus
    {

        int ID_Institucija_Edit_Input { get; set; }
        String Ime_Institucija_Edit_Input { get; set; }
        String Adresa_Institucija_Edit_Input { get; set; }
        String Kratenka_Institucija_Edit_Input { get; set; }

        int ID_Institucija_Edit_Selected { get; set; }

        void nacrtajFromaZaEditInstitucija(Institucija instObj);

    }
}

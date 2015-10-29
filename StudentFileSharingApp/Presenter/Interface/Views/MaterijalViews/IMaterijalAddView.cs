using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.MaterijalViews
{
    public interface IMaterijalAddView : IView, IMsgStatus
    {
        String Naslov_Materijal_Add_Input { get; set; }
        String Opis_Materijal_Add_Input { get; set; }
        String Slika_Materijal_Add_Input { get; set; }
        String Pateka_Materijal_Add_Input { get; set; }
        String Type_Materijal_Add_Input { get; set; }

        String  DodadenOD_Materijal_Add_Input { get; set; }

        //Treba da se implementiraat i ovie
        int Predmet_ID_Materijal_Add_Input { get; set; }
        int Delovi_ID_Materijal_Add_Input { get; set; }

        void nacrtajFormaZaAddMaterijal();
    }
}

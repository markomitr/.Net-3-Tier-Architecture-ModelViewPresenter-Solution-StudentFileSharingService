using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.MaterijaliPredmetiViews
{
    public interface IMaterijaliPredmetPregled8View : IView, IMsgStatus
    {
        int Nasoka_ID_MaterijaliPredmet_Pregled_Input { get; set; }
        int Predmet_ID_MaterijaliPredmet_Pregled_Input { get; set; }
        int Del_ID_MaterijaliPredmet_Pregled_Input { get; set; }

        void nacrtajPregled8MaterijaliPredmet(MaterijaliGrupirani  materijaliGrupirani);
    }
}

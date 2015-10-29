using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.MaterijaliPredmetiViews
{
    public interface IMaterijaliPredmetPregled8SoIzborView : IView, IMsgStatus
    {
        int Nasoka_ID_MaterijaliPredmet_PregledIzbor_Input { get; set; }
        int Predmet_ID_MaterijaliPredmet_PregledIzbor_Input { get; set; }
        int Del_ID_MaterijaliPredmet_PregledIzbor_Input { get; set; }

        int ID_Materijal_MaterijaliPredmet_PregledIzbor_Selected { get; set; }

        void nacrtajPregledSoIzborMaterijaliPredmet(MaterijaliGrupirani materijaliGrupirani);
    }
}

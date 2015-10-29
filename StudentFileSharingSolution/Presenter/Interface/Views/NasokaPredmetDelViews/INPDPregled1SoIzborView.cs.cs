using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.NasokaPredmetDelViews
{
    public interface INPDPregled1SoIzborView:IView,IMsgStatus
    {
        int Nasoka_ID_NPD_Pregled_Selected { get; set; }
        int Predmet_ID_NPD_Pregled_Selected { get; set; }

        int Nasoka_ID_NPD_PregledIzbor_Selected { get; set; }
        int Predmet_ID_NPD_PregledIzbor_Selected { get; set; }
        int Del_ID_NPD_PregledIzbor_Selected { get; set; }
        void nacrtajPregledDelovizaPredmetiZaNasokaSoIzbor(List<DeloviPredmetNasoka> dpnList);
    }
}

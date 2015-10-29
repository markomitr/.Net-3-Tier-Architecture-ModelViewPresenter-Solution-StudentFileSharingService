using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Interface;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.UstanovaViews
{
    public interface IUstanovaPregledSoFilterView : IView, IMsgStatus
    {
        int ID_Ustanova_UstanovaFilter_Selected { get; set; }
        int ID_Institucuja_UstanovaFilter_Selected { get; set; }
        void nacrtajUstanovaSoFilter(List<Ustanova> listaUstanovi);
    }
}

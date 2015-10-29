using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.NasokaViews
{
    public interface INasokaPregledSoFilterView:IView,IMsgStatus 
    {
        int ID_Nasoka_NasokaFilter_Selected { get; set; }
        int ID_Oblast_NasokaFilter_Selected { get; set; }
        void nacrtajNasokaSoFilter(List<Nasoka> listaNasoki);
    }
}

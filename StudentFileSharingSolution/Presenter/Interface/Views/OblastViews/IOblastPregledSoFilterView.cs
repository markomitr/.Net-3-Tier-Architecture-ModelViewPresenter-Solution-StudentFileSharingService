using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.OblastViews
{
    public interface IOblastPregledSoFilterView : IView,IMsgStatus
    {
        int ID_Ustanova_OblastFilter_Selected { get; set; }
        int ID_Oblast_OblastFilter_Selected { get; set; }
        void nacrtajPregledOblastiSoFilter(List<Oblast> oblastiList);
    }
}

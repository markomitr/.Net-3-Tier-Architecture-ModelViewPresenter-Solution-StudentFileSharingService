using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;

namespace Presenter.Interface.Views.OblastViews
{
    public interface IOblastPregledSoIzborView : IView,IMsgStatus
    {
        int ID_Oblast_PregledIzbor_Selected { get; set; }

        void nacrtajPregledSoIzborOblast(List<Oblast> oblastiLista);
    }
}

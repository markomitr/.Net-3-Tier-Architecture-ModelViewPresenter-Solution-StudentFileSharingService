using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;

namespace Presenter.Interface.Views.PredmetViews
{
    public interface IPredmetPregled8SoIzborView:IView,IMsgStatus
    {
        int ID_Predmet_PregledIzbor_Selected { get; set; }
        void nacrtajPregled8PredmetiSoIzbor(List<Predmet> predmetList);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;

namespace Presenter.Interface.Views.PredmetViews
{
    public interface IPredmetPregled1View : IMsgStatus
    {
        int ID_Predmet_Pregled1_Selected { get; set; }

        void nacrtajPregled1Predmet(Predmet predmetObj);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;

namespace Presenter.Interface.Views.PredmetViews
{
    public interface IPredmetPregled8View : IMsgStatus 
    {

        void nacrtajPregled8Predmeti(List<Predmet> predmetList);
    }
}

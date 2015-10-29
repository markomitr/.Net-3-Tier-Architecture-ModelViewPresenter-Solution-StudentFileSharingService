using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;

namespace Presenter.Interface.Views.OblastViews
{
    public interface IOblastPregled1View : IView,IMsgStatus
    {
        int ID_Oblast_Pregled1_input { get; set; }

        void nacrtajPregled1Oblast(Oblast oblastOBj);
    }
}

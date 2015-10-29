using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.NasokaViews
{
    public interface INasokaPregled1View : IView, IMsgStatus
    {
        int ID_Nasoka_Pregled1_Selected { get; set; }

        void nacrtajPregled1Nasoka(Nasoka nasokaObj);
    }
}

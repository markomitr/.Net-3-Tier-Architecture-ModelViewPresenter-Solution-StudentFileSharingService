using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.DeloviViews
{
    public interface IDeloviPregled1View
    {
        int ID_Delovi_Pregled1_Input { get; set; }
        void nacrtajPregled1Delovi(Del delObj);
    }
}

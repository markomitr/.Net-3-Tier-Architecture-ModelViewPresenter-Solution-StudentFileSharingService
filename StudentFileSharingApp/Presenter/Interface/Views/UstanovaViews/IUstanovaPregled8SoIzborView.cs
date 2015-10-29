using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
using Presenter.Interface;
namespace Presenter.Interface.Views.UstanovaViews
{
    public interface IUstanovaPregled8SoIzborView : IView,IMsgStatus
    {
        int ID_Ustanova_Izbor_Selected { get; set; }

        void nacrtajPregled8UstanoviSoIzbor(List<Ustanova> ustanovaList);
    }
}

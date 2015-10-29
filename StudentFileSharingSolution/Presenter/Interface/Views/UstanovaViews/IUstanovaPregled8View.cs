using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.UstanovaViews
{
    public interface IUstanovaPregled8View :IView,IMsgStatus
    {
        void nacrtajPregled8Ustanovi(List<Ustanova> ustanovaList);
    }
}

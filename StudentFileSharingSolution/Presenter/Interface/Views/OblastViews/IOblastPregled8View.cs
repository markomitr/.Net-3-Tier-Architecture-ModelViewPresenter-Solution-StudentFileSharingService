using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.OblastViews
{
    public interface IOblastPregled8View : IView,IMsgStatus
    {
        void nacrtajPregled8Oblasti(List<Oblast> oblastiLista);
    }
}

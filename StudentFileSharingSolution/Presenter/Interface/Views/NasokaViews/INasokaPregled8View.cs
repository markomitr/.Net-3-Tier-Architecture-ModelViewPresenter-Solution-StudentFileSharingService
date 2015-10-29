using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.NasokaViews
{
    public interface INasokaPregled8View :IView,IMsgStatus
    {
        void nacrtajPregled8Nasoki(List<Nasoka> nasokiLista);
    }

}

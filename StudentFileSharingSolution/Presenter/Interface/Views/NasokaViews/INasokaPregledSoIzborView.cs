using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.NasokaViews
{
    public interface INasokaPregledSoIzborView : IView,IMsgStatus
    {
        int ID_Nasoka_Selected { get; set; }

        void nacrtajPregledSoIzborNasoki(List<Nasoka> nasokiLista); 
    }
}

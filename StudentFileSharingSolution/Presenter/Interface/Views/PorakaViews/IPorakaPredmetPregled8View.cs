using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.PorakaViews
{
    public interface IPorakaPredmetPregled8View :IView,IMsgStatus 
    {
        int Predmet_ID_PorakaPredmet_Add_Selected { get; set; }
        int Nasoka_ID_PorakaPredmet_Add_Selected { get; set; }
        void nacrtajPregledPorakiZaPredmet(List<PorakaPredmet> ppList);
    }
}

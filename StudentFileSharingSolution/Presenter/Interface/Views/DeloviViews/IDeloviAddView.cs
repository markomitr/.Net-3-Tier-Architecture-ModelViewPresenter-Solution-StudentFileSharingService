using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.DeloviViews
{
    public interface IDeloviAddView:IView,IMsgStatus 
    {
        String Ime_Delovi_Add_Input { get; set; }
        char ImaPredavac_Delovi_Add_Input { get; set; }
        int VidIzgled_Delovi_Add_Input { get; set; }

        void nacrtajFormaZaAddDelovi();
    }
}

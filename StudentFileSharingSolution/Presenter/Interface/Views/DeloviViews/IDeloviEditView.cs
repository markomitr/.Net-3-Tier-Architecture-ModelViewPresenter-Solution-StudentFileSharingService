using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
using ClassDLL.RegularExpression;
namespace Presenter.Interface.Views.DeloviViews
{
    public interface IDeloviEditView:IView,IMsgStatus
    {
        int ID_Delovi_Edit_Input { get; set; }
        String Ime_Delovi_Edit_Input { get; set; }
        char ImaPredavac_Delovi_Edit_Input { get; set; }
        int VidIzgled_Delovi_Edit_Input { get; set; }
        char Aktiven_Delovi_Edit_Input { get; set; }

        int ID_Delovi_Edit_Selected { get; set; }

        void nacrtajFormaZaEditDelovi(Del delObj);
    }
}

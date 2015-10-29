using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.MaterijaliPredmetiViews
{
    public interface IMaterijaliPredmetAddView : IView, IMsgStatus
    {
        int Materijal_ID_MaterijalPredmet_Add_Input { get; set; }
        int Nasoka_ID_MaterijalPredmet_Add_Input { get; set; }
        int Predmet_ID_MaterijalPredmet_Add_Input { get; set; }
        int Del_ID_MaterijalPredmet_Add_Input { get; set; }

        void nacrtajFormaZaAddMaterijalPredmet();
    }
}

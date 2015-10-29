using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.MaterijaliPredmetiViews
{
    public interface IMaterijaliPredmetDeleteView:IView,IMsgStatus 
    {
        int Nasoka_ID_MaterijaliPredmet_Delete_Input { get; set; }
        int Predmet_ID_MaterijaliPredmet_Delete_Input { get; set; }
        int Delovi_ID_MaterijaliPredmet_Delete_Input { get; set; }
        int Materijal_ID_MaterijaliPredmet_Delete_Input { get; set; }

        void nacrtajFormaZaDeleteMaterijaliPredmet();
    }
}

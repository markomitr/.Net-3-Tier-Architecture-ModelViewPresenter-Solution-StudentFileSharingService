using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.MaterijaliPredmetiViews
{
    public interface IMaterijaliZgolemiDownloadView:IView
    {
        int Nasoka_ID_Materijali_ZgolemiDownload_Input { get; set; }
        int Predmet_ID_Materijali_ZgolemiDownload_Input { get; set; }
        int Delovi_ID_Materijali_ZgolemiDownload_Input { get; set; }
        int Materijal_ID_Materijali_ZgolemiDownload_Input { get; set; }

    }
}

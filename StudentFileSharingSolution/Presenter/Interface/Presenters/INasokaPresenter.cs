using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Presenters
{
    public interface INasokaPresenter : IPresenter
    {
        void addNasoka();
        void updateNasoka();
        void deleteNasoka();
        void pregled8Nasoki();
        void pregled1Nasoka();
        void pregled8NasokiSoIzbor();
        void zemiNasokaZaEdit();

        void pregled8NasokiSoFilter();

        void addPredmetZaNasoka();
        void pregled1PredmetiPoNasoka();
        void pregled1PredmetiPoNasokaSoIzbor();

        void addDelZaPredmetPoNasoka();
        void pregled1DeloviZaPredmetPoNasoka();

        void pregled1PredmetNasoka();
    }
}

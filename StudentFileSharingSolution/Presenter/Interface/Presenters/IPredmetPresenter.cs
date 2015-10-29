using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Presenters
{
    public interface IPredmetPresenter : IPresenter
    {
        void addPredmet();
        void updatePredmet();
        void deletePredmet();
        void pregled1Predmet();
        void pregled8Predmeti();
        void pregled8PremdetiSoIzbor();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Presenters
{
    public interface IPretplataPredmetPresenter:IPresenter 
    {
        void PretplatiKorisnikNaPredmet();

        void pregled8PretplateniPredmeti();
        void pregled8NePretplateniPredmeti(); 

        void OtkaziPretplataNaPredmet();

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Presenters
{
    public interface IUstanovaPresenter : IPresenter
    {
        void addUstanova();
        void updateUstanova();
        void deleteUstanova();
        void pregled8Ustanovi();
        void pregled1Ustanova();
        void zemiUstanovaZaEdit();
        void pregled8soIzborUstanovi();
        void pregled8UstanoviSoFilter();
    }
}

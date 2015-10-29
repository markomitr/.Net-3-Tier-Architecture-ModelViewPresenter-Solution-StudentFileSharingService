using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Presenters
{
    public interface IOblastPresenter : IPresenter 
    {
        void addOblast();
        void updateOblast();
        void deleteOblast();
        void pregled8Oblasti();
        void pregled1Oblast();
        void pregled8OblastiSoIzbor();
        void pregledOblastiSoFilter();
    }
}

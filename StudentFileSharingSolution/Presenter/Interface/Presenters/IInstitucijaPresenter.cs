using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Presenters
{
    public interface IInstitucijaPresenter : IPresenter
    {
        void addInstitucija();
        void updateInstitucija();
        void deleteInstitucija();
        void pregled8Institucii();
        void pregled1Institucija();
        void pregled8soIzborInstitucii();
    }
}

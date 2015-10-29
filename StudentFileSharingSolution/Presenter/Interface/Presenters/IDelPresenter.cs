using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Presenters
{
    public interface IDelPresenter:IPresenter 
    {
        void addDel();
        void updateDel();
        void deleteDel();
        void pregled1Del();
        void pregled8Delovi();
        void pregled8SoIzborDelovi();
        void zemiDelZaEdit();
    }
}

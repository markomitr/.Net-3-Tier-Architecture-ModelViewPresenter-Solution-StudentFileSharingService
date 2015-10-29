using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.InstitucijaViews
{
    public interface IInstitucijaPregled8View :IView,IMsgStatus
    {
        void nacrtajPregled8Institucii(List<Institucija> instList);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
using Presenter.Interface;
namespace Presenter.Interface.Views.InstitucijaViews
{
    public interface IInstitucijaPregled8SoIzborView : IView,IMsgStatus
    {
        int ID_Institucija_Izbor_Selected { get; set; }

        void nacrtajPregled8InstituciiSoIzbor(List<Institucija> instiList);
    }
}

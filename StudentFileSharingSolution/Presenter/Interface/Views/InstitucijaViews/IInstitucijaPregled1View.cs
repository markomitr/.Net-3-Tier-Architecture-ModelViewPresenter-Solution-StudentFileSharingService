using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.InstitucijaViews
{
    public interface IInstitucijaPregled1View : IView
    {
        String ID_Institucija_Pregled1_Input { get; set; }

        void nacrtajPregled1Institucija(Institucija instObj);
    }
}

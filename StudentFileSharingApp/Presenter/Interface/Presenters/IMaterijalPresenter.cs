using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.GreskiEX;
using ClassDLL.RegularExpression;
using ClassDLL.SysPart;
using Presenter.Interface;
using Presenter.Interface.Views;
using Presenter.Interface.Views.MaterijalViews;
namespace Presenter.Interface.Presenters
{
   public  interface IMaterijalPresenter:IPresenter 
    {
       void addMaterijal();
       void pregled1Materijal();
       void pregled8SoIzborMaterijali();

       void addMaterijalPredmet();
       void pregled8MaterijaliPredmet();
       void pregled8MaterijaliPredmetSoIzbor();
       void deleteMaterijalPredmet();

       void addRejtingMaterijal();
    }
}

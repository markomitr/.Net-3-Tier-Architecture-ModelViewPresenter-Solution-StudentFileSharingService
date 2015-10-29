using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Interface.Views.OblastViews;
using Presenter.Interface.Views.NasokaViews;
using Presenter.Interface.Views.UstanovaViews;
namespace Presenter.Interface.Views.CompositeViews
{
    public interface IIUONIzborView:IView,IMsgStatus,IUstanovaPregledSoFilterView,IOblastPregledSoFilterView,INasokaPregledSoFilterView
    {
    }
}

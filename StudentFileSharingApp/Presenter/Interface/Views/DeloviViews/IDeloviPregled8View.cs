using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.DeloviViews
{
    public interface IDeloviPregled8View:IView,IMsgStatus 
    {
        void nacrtajPregled8Delovi(List<Del> deloviList);
    }
}

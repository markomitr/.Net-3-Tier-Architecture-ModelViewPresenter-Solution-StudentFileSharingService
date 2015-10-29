using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.DeloviViews
{
    public interface IDeloviPregled8SoIzborView:IView,IMsgStatus 
    {
        int ID_Delovi_Izbor_Selected { get; set; }

        void nacrtajPregled8DeloviSoIzbor(List<Del> deloviList);
    }
}

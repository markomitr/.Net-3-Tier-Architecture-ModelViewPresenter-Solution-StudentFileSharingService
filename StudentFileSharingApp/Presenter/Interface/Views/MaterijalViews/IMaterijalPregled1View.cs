using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.MaterijalViews
{
    public interface IMaterijalPregled1View:IView,IMsgStatus
    {
        int ID_Materijal_Pregled1_Input { get; set; }

        void nacrtajPregled1Materijal(Materijal matObj);
    }
}

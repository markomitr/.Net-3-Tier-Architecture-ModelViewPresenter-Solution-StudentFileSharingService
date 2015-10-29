using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.MaterijalViews
{
    public interface IMaterijaliPregled8SoIzborView : IView, IMsgStatus 
    {
        int ID_Materijal_Materijali_Izbor_Selected { get; set; }

        void nacrtajPregled8MaterijaliSoIzbor(List<Materijal> materijaliList);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.UstanovaViews
{
   public  interface IUstanovaPregled1View:IView 
    {
       int ID_UStanova_Pregled1_Input { get; set; }
       void nacrtajPregled1Ustanova(Ustanova ustanovaObj);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.KorisnikViews
{
    public interface IKorisnikLoginView : IView, IMsgStatus
    {
        String UserID_Login_Input { get; set; }
        String Lozinka_Login_Input { get; set; }

        void logirajKorisnik(Korisnik korObj);
    }
}

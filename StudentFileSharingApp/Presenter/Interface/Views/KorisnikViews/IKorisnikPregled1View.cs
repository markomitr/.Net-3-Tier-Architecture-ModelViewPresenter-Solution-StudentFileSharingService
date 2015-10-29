using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.KorisnikViews
{
    public interface IKorisnikPregled1View : IView,IMsgStatus
    {
        String UserID_Korisnik_Pregled_Selected { get; set; }

        void nacrtajPregledZaKorisnik(Korisnik korObj);
    }
}

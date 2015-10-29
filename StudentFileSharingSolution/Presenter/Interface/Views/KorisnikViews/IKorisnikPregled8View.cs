using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.Views.KorisnikViews
{
    public interface IKorisnikPregled8View : IView,IMsgStatus
    {
        void nacrtajPregledZaKorisnici(List<Korisnik> korLista);
    }
}

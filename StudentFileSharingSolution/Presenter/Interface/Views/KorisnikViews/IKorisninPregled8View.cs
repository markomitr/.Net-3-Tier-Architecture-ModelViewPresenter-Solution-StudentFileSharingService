using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.KorisnikViews
{
    public interface IKorisninPregled8View : IView
    {
        //Treba da se stavat ako ima potreba nekoi parametri,
        // na pr Kor_Tip ili Grad_ID - da se zemaat po nekoj kriterium;

        void nacrtajPregledZaKorisnici(List<Korisnik> korLista);
    }
}

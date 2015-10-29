using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface
{
    public interface IKorisnikLoginCreateListView : IView
    {
        String UserID { get; set; }
        String Lozinka { get; set; }
        String PorakaLogin { set; }

        String NovUserID { get; set; }
        String NovLozinka { get; set; }
        String NovEmail { get; set; }
        String PorakaNovKor { set; }

        List<Korisnik> ListaKorisnici { set; }

         void napolniKorisnici();

    }
}

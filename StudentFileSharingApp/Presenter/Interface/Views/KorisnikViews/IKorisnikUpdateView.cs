using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace Presenter.Interface.KorisnikViews
{
    public interface IKorisnikUpdateView : IView,IMsgStatus
    {
        String UserId_Korisnik_Update_Selected { get; set; }
        String UserId_Korisnik_Update_Input { get; set; }
        //String Lozinka_Korisnik_Update_Input { get; set; }
        String Email_Korisnik_Update_Input { get; set; }
        String Ime_Korisnik_Update_Input { get; set; }
        String Prezime_Korisnik_Update_Input { get; set; }
        void nacrtajFormaZaUpdateKorisnik(Korisnik korObj);
    }
}

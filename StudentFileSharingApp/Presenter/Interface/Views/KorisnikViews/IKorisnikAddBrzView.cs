using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Views.KorisnikViews
{
    public interface IKorisnikAddBrzView : IView, IMsgStatus
    {
        String UserId_Korisnik_AddBrz_Input { get; set; }
        String Lozinka_Korisnik_AddBrz_Input { get; set; }
        String Lozinka_Korisnik_AddBrz_Check_Input { get; set; }
        String Email_Korisnik_AddBrz_Input { get; set; }

        String UserId_Korisnik_AddBrz_Validacija { get; set; }
        String Lozinka_Korisnik_AddBrz_Validacija { get; set; }
        String LozinkaCheck_Korisnik_AddBrz_Validacija { get; set; }
        String Email_Korisnik_AddBrz_Validacija { get; set; }
        
        void ClearValidacija();
        void uspeshnoDodadenKorisnkBrz();
    }
}

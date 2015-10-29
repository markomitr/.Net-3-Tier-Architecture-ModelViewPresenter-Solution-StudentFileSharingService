using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Interface.KorisnikViews;

namespace Presenter.Interface.Views.KorisnikViews
{
    public interface IKorisnikAddView : IView,IMsgStatus
    {
        String UserId_Korisnik_Add_Input { get; set; }
        String Lozinka_Korisnik_Add_Input { get; set; }
        String LozinkaCheck_Korisnik_Add_Input { get; set; }
        String Email_Korisnik_Add_Input { get; set; }
        String Ime_Korisnik_Add_Input { get; set; }
        String Prezime_Korisnik_Add_Input { get; set; }

        String UserId_Korisnik_Add_Validacija { get; set; }
        String Lozinka_Korisnik_Add_Validacija { get; set; }
        String LozinkaCheck_Korisnik_Add_Validacija { get; set; }
        String Email_Korisnik_Add_Validacija { get; set; }
        String Ime_Korisnik_Add_Validacija { get; set; }
        String Prezime_Korisnik_Add_Validacija { get; set; }

        void ClearValidacija();
    }
}

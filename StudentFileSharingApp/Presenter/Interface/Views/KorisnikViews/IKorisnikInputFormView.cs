using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.KorisnikViews
{
    public interface IKorisnikInputFormView : IView
    {
        String UserId_Input { get; set; }
        String Lozinka_Input { get; set; }
        String Email_Input { get; set; }
        String Ime_Input { get; set; }
        String Prezime_Input { get; set; }
    }
}

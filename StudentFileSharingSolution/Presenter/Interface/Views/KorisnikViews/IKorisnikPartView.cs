using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presenter.Interface;

namespace Presenter.Interface.KorisnikViews
{
    public interface IKorisnikPartView : IView
    {
        String UserId { get; set; }
        String Lozinka { get; set; }
        String Email { get; set; }
        String Ime { get; set; }
        String Prezime { get; set; }
        String IzmenetOd { get; set; }
    }
}

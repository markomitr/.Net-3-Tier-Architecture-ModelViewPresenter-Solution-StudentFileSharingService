using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;

namespace Presenter.Interface.KorisnikViews
{
    public interface IKorisnikUpdateFormView : IView
    {
        String UserID_Edit_Selected { get; set; }
        void nacrtajFormaZaUpdateKorisnik(Korisnik korObj);
    }
}

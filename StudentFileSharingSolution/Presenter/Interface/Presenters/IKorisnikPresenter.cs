using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface.Presenters
{
    public interface IKorisnikPresenter : IPresenter
    {
        void addKorisnik();
        void addBrzKorisnk();
        void updateKorisnik();
        void getKorisnik();
        void getKorisnici();

        void zemiKorisnikZaEdit();
        void loginKorisnik();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.SysPart
{
    public class RezultatKomanda
    {
        RezultatKomandaEnum _rezultat;
        String _pricina;

        public RezultatKomanda(bool uspeh)
        {
            if (uspeh == true)
            {
                this.Rezultat = RezultatKomandaEnum.Uspeh;
            }
            else
            {
                this.Rezultat = RezultatKomandaEnum.Neuspeh;
            }
        }

        public String Pricina
        {
            get { return this._pricina; }
            set { this._pricina = value; }
        }
        public RezultatKomandaEnum Rezultat
        {
            get { return this._rezultat; }
            set { this._rezultat  = value; }
        }
        /*
        public bool Uspeh
        {
            get
            {
                if (_rezultat == RezultatKomandaEnum.Uspeh)
                {
                    return true;
                }
                else if (_rezultat == RezultatKomandaEnum.Neuspeh)
                {
                    return false;
                }
                return false;
            }
            set
            {
                if (value == true)
                {
                    this._rezultat = Uspeh;
                }
            }
        }
          */

    }
}

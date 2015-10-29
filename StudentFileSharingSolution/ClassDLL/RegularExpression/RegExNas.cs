using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.RegularExpression
{
    public class RegExNas : IRegEx
    {
        public delegate IRegEx ValidateObject(string o);

        public ValidateObject FunkcijaValidiraj;

        private object _prvicenVlez;
        private object _izmenetVlez;
        private String _poraka;
        private Boolean _uspeh;
        public RegExNas() {
            this._uspeh = false;
        }
        public RegExNas(object o) {
            this._prvicenVlez = o;
            this._izmenetVlez = _prvicenVlez;
            this._uspeh = false;
        }


        public IRegEx Validiraj(object o)
        {
            IRegEx rezultat= FunkcijaValidiraj(o.ToString());
            this.poraka = rezultat.poraka;
            this.IzmenetVlez = rezultat.IzmenetVlez;
            this.uspeh = rezultat.uspeh;

            return rezultat;
        }

        public IRegEx Validiraj()
        {
            IRegEx rezultat = FunkcijaValidiraj(this._prvicenVlez.ToString());
            this.poraka = rezultat.poraka;
            this.IzmenetVlez = rezultat.IzmenetVlez;
            this.uspeh = rezultat.uspeh;

            return rezultat;
        }

 
        public object PrvicenVlez
        {
            get
            {
                return this._prvicenVlez;
            }
            set
            {
                this._prvicenVlez = value;
            }
        }

        public object IzmenetVlez
        {
            get
            {
                return this._izmenetVlez;
            }
            set
            {
                this._izmenetVlez = value;
            }
        }

        public string poraka
        {
            get
            {
                return this._poraka;
            }
            set
            {
                this._poraka = value;
            }
        }

        public bool uspeh
        {
            get
            {
                return this._uspeh;
            }
            set
            {
                this._uspeh = value;
            }
        }

    }
}

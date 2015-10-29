using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class Predmet : IPredmet
    {
        int _ID;
        String _ime;
        String _opis;
        public Predmet() { }
        public Predmet(int id)
        {
            this.PredmetID = id;
        }
        public Predmet(int id,String ime,String opis)
        {
            this.PredmetID = id;
            this.Ime = ime;
            this.Opis = opis;
        }
        #region Properties
        public int PredmetID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }

        public string Ime
        {
            get
            {
                return this._ime;
            }
            set
            {
                this._ime = value;
            }
        }

        public string Opis
        {
            get
            {
                return this._opis;
            }
            set
            {
                this._opis = value;
            }
        }
        #endregion
    }
}

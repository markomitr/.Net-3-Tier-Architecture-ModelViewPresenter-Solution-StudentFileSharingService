using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class Ustanova : IUstanova 
    {
        int _ustanovaID;
        int _institucija_ID;
        String _ime;
        String _adresa;
        String _webStrana;
        #region Properties
        public int UstanovaID
        {
            get
            {
                return this._ustanovaID;
            }
            set
            {
                this._ustanovaID = value;
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

        public string Adresa
        {
            get
            {
                return this._adresa;
            }
            set
            {
                this._adresa = value;
            }
        }

        public string WebStrana
        {
            get
            {
                return this._webStrana;
            }
            set
            {
                this._webStrana = value;
            }
        }

        public int Institucija_ID
        {
            get
            {
                return this._institucija_ID;
            }
            set
            {
                this._institucija_ID = value;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class Nasoka : INasoka 
    {
        int _nasokaID;
        int _oblast_ID;
        String _ime;
        String _opis;
        #region Properties
        public int NasokaID
        {
            get
            {
                return this._nasokaID;
            }
            set
            {
                this._nasokaID = value;
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

        public int Oblast_ID
        {
            get
            {
                return this._oblast_ID;
            }
            set
            {
                this._oblast_ID = value;
            }
        }
        #endregion
    }
}

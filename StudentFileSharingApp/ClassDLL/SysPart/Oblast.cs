﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class Oblast : IOblast 
    {
        int _oblastID;
        int _ustanova_ID;
        String _ime;
        String _adresa;
        String _webStrana;

        #region Properties
        public int OblastID
        {
            get
            {
                return this._oblastID;
            }
            set
            {
                this._oblastID = value;
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

        public int Ustanova_ID
        {
            get
            {
                return this._ustanova_ID;
            }
            set
            {
                this._ustanova_ID = value;
            }
        }
        #endregion
    }
}

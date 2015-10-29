using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class Poraka : IPoraka
    {

        int _porakaID;
        String _sodrzina;
        Char _aktivna;
        Decimal _rejting;
        DateTime _dodadenaNa;
        DateTime _izmenetaNa;
        String _dodadenaOd;
        String _izmenetaOd;

        public Poraka() { }


        #region Property
        public int PorakaID
        {
            get
            {
                return this._porakaID;
            }
            set
            {
                this._porakaID = value;
            }
        }
        public string Sodrzina
        {
            get
            {
                return this._sodrzina;
            }
            set
            {
                this._sodrzina = value;
            }
        }
        public char Aktivna
        {
            get
            {
                return this._aktivna;
            }
            set
            {
                this._aktivna = value;
            }
        }
        public decimal Rejting
        {
            get
            {
                return this._rejting;
            }
            set
            {
                this._rejting = value;
            }
        }
        public DateTime DodadenaNa
        {
            get
            {
                return this._dodadenaNa;
            }
            set
            {
                this._dodadenaNa = value;
            }
        }
        public string DodadenaOd
        {
            get
            {
                return this._dodadenaOd;
            }
            set
            {
                this._dodadenaOd = value;
            }
        }
        public DateTime IzmenetaNa
        {
            get
            {
                return this._izmenetaNa;
            }
            set
            {
                this._izmenetaNa = value;
            }
        }
        public string IzmenetaOd
        {
            get
            {
                return this._izmenetaOd;
            }
            set
            {
                this._izmenetaOd = value;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class Institucija: IInstitucija
    {
        int _id;
        String _ime;
        String _adresa;
        String _kratenka;
#region Properties
         public int  ID
        {
	          get 
	        {
                return this._id;
	        }
	          set 
	        {
                this._id = value;
	        }
        }

        public string  Ime
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

        public string  Adresa
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

        public string  Kratenka
        {
	          get 
	        {
                return this._kratenka;
	        }
	          set 
	        {
                this._kratenka = value;
	        }
        }
        #endregion
        public Institucija()
        {
        }
        public Institucija(String ime,String adresa,String kratenka)
        {
            _ime = ime;
            _adresa = adresa;
            _kratenka = kratenka;
        }
        public Institucija(int ID,String ime, String adresa, String kratenka)
        {
            _id = ID;
            _ime = ime;
            _adresa = adresa;
            _kratenka = kratenka;
        }
    }
}

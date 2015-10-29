using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
using ClassDLL.SysPart;
namespace ClassDLL.SysPart
{
    public class DeloviPredmetNasoka : IDeloviPredmetNasoka
    {

        int _stuff_id;
        char _aktiven;
        Del _delObj;
        Predmet _predmetObj;
        Nasoka _nasokaObj;

        public DeloviPredmetNasoka()
        {
            _delObj = new Del();
            _predmetObj = new Predmet();
            _nasokaObj = new Nasoka();
        }
        #region Properites
        public int Nasoka_ID
        {
            get
            {
                return this._nasokaObj.NasokaID;
            }
            set
            {
                this._nasokaObj.NasokaID = value;
            }
        }
        public string Nasoka_Ime
        {
            get
            {
                return this._nasokaObj.Ime;
            }
            set
            {
                this._nasokaObj.Ime = value;
            }
        }

        public int Predmet_ID
        {
            get
            {
                return this._predmetObj.PredmetID;
            }
            set
            {
                this._predmetObj.PredmetID = value;
            }
        }
        public string Predmet_Ime
        {
            get
            {
                return this._predmetObj.Ime;
            }
            set
            {
                this._predmetObj.Ime = value;
            }
        }

        public int Del_ID
        {
            get
            {
                return this._delObj.ID;
            }
            set
            {
                this._delObj.ID = value;
            }
        }

        public string Del_Ime
        {
            get
            {
                return this._delObj.Ime;
            }
            set
            {
                this._delObj.Ime = value;
            }
        }
        public int Stuff_ID
        {
            get
            {
                return this._stuff_id;
            }
            set
            {
                this._stuff_id = value;
            }
        }
        public char Aktiven
        {
            get
            {
                return this._aktiven;
            }
            set
            {
                this._aktiven = value;
            }
        }
        public Del Del
        {
            get 
            {
                return this._delObj;
            }
        }
        #endregion


        

       

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassDLL.GreskiEX;
using ClassDLL.Interface;
using ClassDLL.RegularExpression;
namespace ClassDLL.SysPart
{
    public class MaterijaliGrupirani : IMaterijaliGrupirani
    {
        Nasoka _nasoka;
        Predmet _predmet;

        bool _poDelovi;
        DelMaterijali _delMaterijal;
        LinkedList<DelMaterijali> _deloviMaterijali;

        LinkedList<Materijal> _materijali;

        public MaterijaliGrupirani() 
        {
            this._materijali = new LinkedList<Materijal>();
            this._deloviMaterijali = new LinkedList<DelMaterijali>();
        }
        public MaterijaliGrupirani(Nasoka nasoka, Predmet predmet,bool poDelovi)
        {
            this._materijali = new LinkedList<Materijal>();
            this._deloviMaterijali = new LinkedList<DelMaterijali>();

            this.Nasoka = nasoka;
            this.Predmet = predmet;
            this.PoDelovi = poDelovi;
        }
        public MaterijaliGrupirani(int NasokaID, String NasokaIme, int PredmetID, String PredmetIme,bool poDelovi)
        {
            this._materijali = new LinkedList<Materijal>();
            this._deloviMaterijali = new LinkedList<DelMaterijali>();

            this._nasoka = new Nasoka();
            this._nasoka.NasokaID = NasokaID;
            this._nasoka.Ime = NasokaIme;

            this._predmet = new Predmet();
            this._predmet.PredmetID = PredmetID;
            this._predmet.Ime = PredmetIme;

            this.PoDelovi = poDelovi;
        }
        public void DodadiMaterijalPoDel(Del del,Materijal materijal)
        {
            if (PoDelovi)
            {
                DelMaterijali tek = NajdiDel(del.ID);
                if (tek != null)
                {
                    tek.DodadiMaterijal(materijal);
                }
                else
                {
                    tek = new DelMaterijali(del);
                    tek.DodadiMaterijal(materijal);
                    this._deloviMaterijali.AddLast(tek);
                }
            }
            else
            {
                throw new Exception("Dodadvate materijal po delovi - a objektot e podesen raboti bez delovi.!");
            }
        }
        public void DodadiSamoMaterijal( Materijal materijal)
        {
            if (PoDelovi == false)
            {
                this._materijali.AddLast(materijal);
            }
            else
            {
                throw new Exception("Dodadvate samo materijali -a objektot e podesen da raboti po delovi.!");
            }
        }
        private DelMaterijali NajdiDel(int delID)
        {
            foreach (DelMaterijali  element in this._deloviMaterijali)
            {
                if (element.Del.ID == delID)
                {
                    return element;
                }
            }
            return null;
        }
        public Nasoka Nasoka
        {
            get
            {
                return this._nasoka;
            }
            set
            {
                this._nasoka = value;
            }
        }

        public Predmet Predmet
        {
            get
            {
                return this._predmet;
            }
            set
            {
                this._predmet = value;
            }
        }

        public bool PoDelovi
        {
            get
            {
                return this._poDelovi;
            }
            set
            {
                this._poDelovi = value;
            }
        }

        public LinkedList<DelMaterijali> DeloviMaterijali
        {
            get
            {
                return this._deloviMaterijali;
            }
            set
            {
                this._deloviMaterijali = value;
            }
        }

        public LinkedList<Materijal> Materijali
        {
            get
            {
                return this._materijali;
            }
            set
            {
                this._materijali = value;
            }
        }

    }
}

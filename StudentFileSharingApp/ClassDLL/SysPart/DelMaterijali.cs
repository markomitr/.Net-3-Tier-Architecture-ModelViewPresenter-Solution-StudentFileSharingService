using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassDLL.GreskiEX;
using ClassDLL.RegularExpression;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class DelMaterijali:IDelMaterijali
    {

        Del _del;
        List<Materijal> _materijali;

        public DelMaterijali() { }
        public DelMaterijali(Del del) 
        {
            this.Del = del;
            this._materijali = new List<Materijal>();
        }
        public DelMaterijali(Del del, List<Materijal> materijali)
        {
            this.Del = del;
            this.Materijali = materijali;
        }
        public DelMaterijali(int DelID, String DelIme, int DelVidIzgled)
        {
            this._del = new Del(DelID, DelIme, ' ', DelVidIzgled);
            this._materijali = new List<Materijal>();
        }
        public void DodadiMaterijal(Materijal mat)
        {
            this._materijali.Add(mat);
        }
        public void DodadiMaterijal(String naslov, String opis, String dodadenOd, int materijalID, String pateka, String slika, char aktiven,string type)
        {
            Materijal nov = new Materijal(naslov, opis, dodadenOd, materijalID, pateka, slika, aktiven,type);
            this._materijali.Add(nov);
        }
        public Del Del
        {
            get
            {
                return _del;
            }
            set
            {
                this._del = value;
            }
        }

        public List<Materijal> Materijali
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

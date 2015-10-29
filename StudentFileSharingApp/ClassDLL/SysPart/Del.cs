using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class Del:IDel 
    {
        int _id;
        int _vid_Del;
        string _ime;
        char _imaPredavac;
        bool _imaPredavacBool;
        char _aktiven;

        public Del() { }
        public Del(int id, String ime, char imaPredavac)
        {
            this.ID = id;
            this.Ime = ime;
            this.ImaPredavac = imaPredavac;
        }
        public Del(int id, String ime, char imaPredavac,int VidDel)
        {
            this.ID = id;
            this.Ime = ime;
            this.ImaPredavac = imaPredavac;
        }
        public Del(int id, String ime, char imaPredavac, int VidDel,char aktiven)
        {
            this.ID = id;
            this.Ime = ime;
            this.ImaPredavac = imaPredavac;
            this.Aktiven = aktiven;
        }
        public int ID
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

        public char ImaPredavac
        {
            get
            {
                return this._imaPredavac;
            }
            set
            {
                this._imaPredavac = value;
                if (value == 'D')
                {
                    this.ImaPredavacBool = true;
                }
                else if (value == 'N')
                {
                    this.ImaPredavacBool = false;
                }
            }
        }

        public bool ImaPredavacBool
        {
            get
            {
                return this._imaPredavacBool;
            }
            set
            {
                this._imaPredavacBool = value;
            }
        }
        public int Vid_Izgled 
        {
            get
            {
                return this._vid_Del;
            }
            set
            {
                this._vid_Del = value;
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
    }
}

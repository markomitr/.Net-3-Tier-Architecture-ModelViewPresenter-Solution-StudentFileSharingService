using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
using ClassDLL.GreskiEX;
using ClassDLL.SysPart;
using System.IO;
namespace ClassDLL.SysPart
{
    public class Materijal : IMaterijal
    {
        ClassDLL.RegularExpression.ProveriMaterijal proverka = new RegularExpression.ProveriMaterijal();
        int _materijalID;
        String _naslov;
        String _opis;
        String _dodadenOd;
        String _slika;
        String _pateka;
        String _type;
        int _prevzemen;
        int _dobar;
        int _los;
        DateTime _dodadenNa;

        char _aktvien;
        bool _aktivenBool;
        public Materijal() { }
        public Materijal(String naslov, String opis, String dodadenOd)
        {
            this.Naslov = naslov;
            this.Opis = opis;
            this.DodadenOd = dodadenOd;
        }
        public Materijal(String naslov, String opis, String dodadenOd, int materijalID)
        {
            this.Naslov = naslov;
            this.Opis = opis;
            this.DodadenOd = dodadenOd;
            this.MaterijalID = materijalID;
        }
        public Materijal(String naslov, String opis, String dodadenOd, int materijalID, String pateka, String slika, char aktiven, string type)
        {
            this.Naslov = naslov;
            this.Opis = opis;
            this.DodadenOd = dodadenOd;
            this.MaterijalID = materijalID;
            this.Pateka = pateka;
            this.Slika = slika;
            this.Aktiven = aktiven;
            this.Type = type;
        }
        public int MaterijalID
        {
            get
            {
                return this._materijalID;
            }
            set
            {
                this._materijalID = value;
            }
        }

        public string Naslov
        {
            get
            {
                return this._naslov;
            }
            set
            {
                this._naslov = value;
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

        public string DodadenOd
        {
            get
            {
                return this._dodadenOd;
            }
            set
            {
                this._dodadenOd = value;
            }
        }

        public string Slika
        {
            get
            {
                return this._slika;
            }
            set
            {
                this._slika = value;
            }
        }

        public string Pateka
        {
            get
            {
                return this._pateka;
            }
            set
            {
                this._pateka = value;
            }
        }

        public int Prevzemen
        {
            get
            {
                return this._prevzemen;
            }
            set
            {
                this._prevzemen = value;
            }
        }

        public int DobarRejting
        {
            get
            {
                return this._dobar;
            }
            set
            {
                this._dobar =value;
            }
        }

        public int LosRejting
        {
            get
            {
                return this._los;
            }
            set
            {
                this._los = value;
            }
        }

        public DateTime DodadenNa
        {
            get
            {
                return this._dodadenNa;
            }
            set
            {
                this._dodadenNa = value;
            }
        }

        public char Aktiven
        {
            get
            {
                return this._aktvien;
            }
            set
            {
                this._aktvien = value;
                if (value == 'D')
                {
                    this.AktivenBool = true;
                }
                else if (value == 'N')
                {
                    this.AktivenBool = false;
                }
            }
        }

        public bool AktivenBool
        {
            get
            {
                return this._aktivenBool;
            }
            set
            {
                this._aktivenBool = value;
            }
        }
        public override string ToString()
        {
            return this.MaterijalID + " - " + this.Naslov + " : " + this.Pateka;
        }


        public string Type
        {
            get
            {
                if (String.IsNullOrEmpty(this._type))
                {
                    //ako nemame vo baza zapis za tipot - togas proubavame da go zemime od patekata

                    try
                    {
                        string tip = Path.GetExtension(this.Pateka).ToLower().Split('.')[1];
                        return tip;
                    }
                    catch (Exception)
                    {

                    }
                    return "err";


                }
                else
                {
                    return this._type;
                }
            }
            set
            {
                this._type = value;
            }
        }

        public MaterijalTip TypeEnum
        {
            get
            {
                if (this.Type == "err")
                {
                    return MaterijalTip.Greska;
                }
                else if (this.Type == "pdf")
                {
                    return MaterijalTip.Pdf;
                }
                else if (this.Type == "jpg" || this.Type == "jpeg" || this.Type == "png" || this.Type == "gif" || this.Type == "bmp")
                {
                    return MaterijalTip.Slika;
                }
                else if (this.Type == "zip" || this.Type == "rar" || this.Type == "7z")
                {
                    return MaterijalTip.Arhiva;
                }
                else if (this.Type == "doc" || this.Type == "docx")
                {
                    return MaterijalTip.Word;
                }
                else if (this.Type == "xls" || this.Type == "xlsx")
                {
                    return MaterijalTip.Excel;
                }
                else if (this.Type == "ppt" || this.Type == "pptx" || this.Type == "pot" || this.Type == "pos")
                {
                    return MaterijalTip.PowerPoint;
                }
                else if (this.Type == "txt")
                {
                    return MaterijalTip.Text;
                }
                else if (this.Type == "htm" || this.Type == "html")
                {
                    return MaterijalTip.Html;
                }

                return MaterijalTip.Nepoznato;
            }
            set
            {
            }
        }

        
    }
}

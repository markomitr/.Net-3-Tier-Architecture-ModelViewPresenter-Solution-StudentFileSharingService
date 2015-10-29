using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.GreskiEX
{

    /// <summary>
    /// Klastata GlavenException e osnovna klasa za klasite koi se grizat za rakuvanje na razlicni tipovi
    /// na poraki: KomandaKorisniciEx, KonekcijaCloseEx, KonekcijaEx, KonekcijaOpenEx, KonekcijaStringEx, NemaKolonaEx.
    /// Ovaa klasa vo sebe gi sodrzi porakite i kodovite koi klasite naslednicki gi isprakjaat do osnovnata klasa, a
    /// istata ovozmozuva i lesen pristap do istite.
    /// </summary>
    abstract public class GlavenException:Exception 
    {
        String _korisnickaPoraka;
        String _sistemskaPoraka;
        int _kod;

        public GlavenException() { }
        public GlavenException(String Message) : base(Message) { }
        public GlavenException(String Message, int Kod)
            : base(Message)
        {
            this._kod = Kod;
        }

        /// <summary>
        /// Inicijalizacija na globalnite promenlivi: _korisnickaPoraka, _sistemskaPoraka, _kod
        /// </summary>
        /// <param name="KorisnickaPoraka">Sodrzina na korisnicka poraka</param>
        /// <param name="SistemskaPoraka">Sodrzina na sistemska poraka</param>
        /// <param name="Message">Sodrzina koja se prakja do osnovnata klasa Exception</param>
        /// <param name="Kod">Celobrojna vrednost koja pretstavuva kod na porakata</param>
        public GlavenException(String KorisnickaPoraka, String SistemskaPoraka, String Message,int Kod)
            : base(Message)
        {
            this._korisnickaPoraka = KorisnickaPoraka;
            this._sistemskaPoraka = SistemskaPoraka;
            this._kod = Kod;
        }


        /// <value>
        /// KorisnickaPoraka e property koja ovozmozuva get i set pristap do promenlivata _korisnickaPoraka
        /// </value>
        public String KorisnickaPoraka
        {
            get { return _korisnickaPoraka; }
            set { this._korisnickaPoraka = value; }
        }


        /// <value>
        /// SistemskaPoraka e property koja ovozmozuva get i set pristap do promenlivata _sistemskaPoraka
        /// </value>
        public String SistemskaPoraka
        {
            get { return _sistemskaPoraka  ; }
            set { this._sistemskaPoraka = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.GreskiEX
{

    /// <summary>
    /// Klasa koja regulira isklucoci koi se povrzani so poraki generirani za nedostatok na kolona kon koja se pristapuva
    /// </summary>
   public  class NemaKolonaEX:GlavenException 
    {

        /// <summary>
        /// Inicijalizacija na osnovna klasa: GlavenException 
        /// </summary>
        /// <param name="KorisnickaPoraka">Sodrzina na korisnicka poraka</param>
        /// <param name="SistemskaPoraka">Sodrzina na sistemska poraka</param>
        /// <param name="Message">Sodrzina koja se prakja do osnovnata klasa Exception</param>
        /// <param name="Kod">Celobrojna vrednost koja pretstavuva kod na porakata</param>
        public NemaKolonaEX(String KorisnickaPoraka, String SistemskaPoraka, String Message, int Kod)
            : base(KorisnickaPoraka, SistemskaPoraka, Message, Kod)
        {
        }
    }
}

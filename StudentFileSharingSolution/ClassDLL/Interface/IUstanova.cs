using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.Interface
{
    public interface IUstanova
    {

        int UstanovaID { get; set; }
        String Ime { get; set; }
        String Adresa { get; set; }
        String WebStrana { get; set; }
        int Institucija_ID { get; set; }

    }
}

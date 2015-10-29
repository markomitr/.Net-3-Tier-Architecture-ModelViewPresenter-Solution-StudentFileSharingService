using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.Interface
{
    public interface INasoka
    {
        int NasokaID { get; set; }
        String Ime { get; set; }
        String Opis { get; set; }
        int Oblast_ID { get; set; }
    }
}

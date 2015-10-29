using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.Interface
{
    public interface IInstitucija
    {

        int ID { get; set; }
        String Ime { get; set; }
        String Adresa { get; set; }
        String Kratenka { get; set; }
    }
}

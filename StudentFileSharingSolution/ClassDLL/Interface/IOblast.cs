using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.Interface
{
    public interface IOblast
    {

        int OblastID { get; set; }
        String Ime { get; set; }
        String Adresa { get; set; }
        String WebStrana { get; set; }
        int Ustanova_ID { get; set; }
    }
}

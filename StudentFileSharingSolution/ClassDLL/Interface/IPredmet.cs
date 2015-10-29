using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.Interface
{
    public interface IPredmet
    {
        int PredmetID { get; set; }
        String Ime { get; set; }
        String Opis  { get; set; }
    }
}

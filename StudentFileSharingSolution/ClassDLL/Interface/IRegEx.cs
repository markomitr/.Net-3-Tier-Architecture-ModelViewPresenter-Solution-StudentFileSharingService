using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDLL.Interface
{
    public interface IRegEx
    {
        object PrvicenVlez { get; set; }
        object IzmenetVlez { get; set; }
        String poraka { get; set; }
        Boolean uspeh { get; set; }

        IRegEx Validiraj(object o);
        IRegEx Validiraj();
    }
}

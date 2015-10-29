using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
namespace ClassDLL.Interface
{
    /// <summary>
    /// Interfejs koj zapazuva lista na materjali vo sklop na opredelena obvrska-del.
    /// </summary>
   public  interface IDelMaterijali
    {
       Del Del { get; set; }
       List<Materijal> Materijali { get; set; }
    }
}

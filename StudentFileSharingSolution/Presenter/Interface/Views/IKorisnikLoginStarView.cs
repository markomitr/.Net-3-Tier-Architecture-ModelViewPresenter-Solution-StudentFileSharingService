using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface
{
    public interface IKorisnikLoginStarView : IView 
    {
        String UserID { get; set;}
        String Lozinka { get; set; }
        String Poraka { set; }
    }
}

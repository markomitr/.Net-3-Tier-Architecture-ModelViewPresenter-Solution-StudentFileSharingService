using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presenter.Interface
{
    public interface IMsgStatus :IView
    {
        String ErrorPoraka { get; set; }
        String InfoPoraka { get; set; }
    }
}

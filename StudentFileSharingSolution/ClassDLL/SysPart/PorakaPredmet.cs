using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassDLL.Interface;
namespace ClassDLL.SysPart
{
    public class PorakaPredmet : Poraka,IPorakaPredmet
    {
        int _predmet_id;
        int _nasoka_id;
        public PorakaPredmet()
            : base() {}
        #region Property
        public int Predmet_ID
        {
            get
            {
                return this._predmet_id;
            }
            set
            {
                this._predmet_id = value;
            }
        }
        public int Nasoka_ID
        {
            get
            {
                return this._nasoka_id;
            }
            set
            {
                this._nasoka_id = value;
            }
        }
        #endregion
       
    }
}

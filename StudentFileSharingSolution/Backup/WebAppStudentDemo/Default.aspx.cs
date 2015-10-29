using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppStudentDemo.Class;
using ClassDLL.SysPart;
using Presenter.Interface;
using Presenter.Interface.Views.PorakaViews;
using Presenter.Interface.Presenters;
using Presenter.Presenter;
namespace WebAppStudentDemo
{
    public partial class _Default : Glavna,
                                    IView,IPorakaPredmetAddView,IPorakaPredmetPregled8View
    {
        IPorakaPresenter porakaPresenter;
        public _Default()
        {
            porakaPresenter = new PorakaPresenter(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            porakaPresenter.getPorakiPredmet();
        }
        #region IPorakaPredmetAddView
        public int Predmet_ID_PorakaPredmet_Add_Input
        {
            get
            {
                return  1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Nasoka_ID_PorakaPredmet_Add_Input
        {
            get
            {
                return 1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Sodrzina_PorakaPredmet_Add_Input
        {
            get
            {
                return this.txtBoxSodrzinaPoraka.Text;
            }
            set
            {
                this.txtBoxSodrzinaPoraka.Text = value;
            }
        }

        public string UserID_PorakaPredmet_Add_Inpit
        {
            get
            {
                return base.TekovenKorisnik.UserID;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region IMsgStatus
        public string ErrorPoraka
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                this.lblStatus.Text = value;
            }
        }

        public string InfoPoraka
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                this.lblStatus.Text = value;
            }
        }
        #endregion IMsgStatus

        protected void btnPratiPoraka_Click(object sender, EventArgs e)
        {
            porakaPresenter.addPorakaPredmet();
            porakaPresenter.getPorakiPredmet();
        }
        #region IPorakaPredmetPregled8View
        public int Predmet_ID_PorakaPredmet_Add_Selected
        {
            get
            {
                return 1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Nasoka_ID_PorakaPredmet_Add_Selected
        {
            get
            {
                return 1;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregledPorakiZaPredmet(List<PorakaPredmet> ppList)
        {
            this.PorakiPredmet.Controls.Clear();
            foreach (PorakaPredmet  ppObj in ppList)
            {
                this.PorakiPredmet.Controls.Add(nacrtajPorakaPredmet(ppObj));
            }
        }
        LiteralControl nacrtajPorakaPredmet(PorakaPredmet ppObj)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div id=\"PorakaPredmet\">");
            sb.Append("<span id=\"PorakaUserID\">Корисник:");
            sb.Append(ppObj.DodadenaOd);
            sb.Append("</span>");
            sb.Append("<span id=\"PorakaDatum\">Датум:");
            sb.Append(ppObj.DodadenaNa);
            sb.Append("</span>");
            sb.Append("<div id=\"PorakaSodrzina\">");
            sb.Append(ppObj.Sodrzina);
            sb.Append("</div>");
            sb.Append("</div>");

            return new LiteralControl(sb.ToString());
            
        }
        #endregion
    }
}
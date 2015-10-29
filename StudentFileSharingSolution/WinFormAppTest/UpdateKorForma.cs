using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presenter.Interface.KorisnikViews;
using Presenter.Interface;
using Presenter.Presenter;
namespace WinFormAppTest
{
    public partial class UpdateKorForma : Form, IView //IKorisnikUpdateFormView, IKorisnikUpdateView
    {
        IPresenter presKorisnik;
        String UserIDEditSelected;
        public UpdateKorForma()
        {
            InitializeComponent();
            presKorisnik = new KorisniciPresenter(this);
        }
        public UpdateKorForma(String UserID)
        {
            InitializeComponent();
            presKorisnik = new KorisniciPresenter(this);
            UserIDEditSelected = UserID;
            //((KorisniciPresenter)presKorisnik).zemiKorisnikZaIzmena();

        }
        private void UpdateKorForma_Load(object sender, EventArgs e)
        {

        }
        //#region IKorisnikUpdateFormView
        //public string UserID_Edit_Selected
        //{
        //    get
        //    {
        //       return this.UserIDEditSelected;
        //    }
        //    set
        //    {
        //        this.UserIDEditSelected = value;
        //    }
        //}

        //public void nacrtajFormaZaUpdateKorisnik(ClassDLL.SysPart.Korisnik korObj)
        //{
        //    this.txtBoxUserID.Text  = korObj.UserID;
        //    this.txtBoxUserID.Enabled = false;
        //    this.txtBoxIme.Text = korObj.Ime;
        //}
        //#endregion

        //#region IKorisnikUpdateView
        //public string UserId_Update_Input
        //{
        //    get
        //    {
        //        return txtBoxUserID.Text;
        //    }
        //    set
        //    {
        //        txtBoxUserID.Text =value;
        //    }
        //}

        //public string Lozinka_Update_Input
        //{
        //    get
        //    {
        //        return " ";
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string Email_Update_Input
        //{
        //    get
        //    {
        //        return " ";
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public string Ime_Update_Input
        //{
        //    get
        //    {
        //       return txtBoxIme.Text ;
        //    }
        //    set
        //    {
        //        txtBoxIme.Text = value;
        //    }
        //}

        //public string Prezime_Korisnik_Update_Input
        //{
        //    get
        //    {
        //        return " ";
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
        //#endregion

        private void btnPromeniUser_Click(object sender, EventArgs e)
        {
            //((KorisniciPresenter)presKorisnik).izmeniKorisnik();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presenter.Interface;
using Presenter.Presenter;
using ClassDLL.SysPart;

namespace WinFormAppTest
{
    public partial class Form1 : Form,IKorisnikLoginCreateListView
    {
        IPresenter presenter;
        List<Korisnik> korisnici;

        #region Properties
        public string UserID
        {
            get
            {
                return this.txtBoxUserID.Text;
            }
            set
            {
                this.txtBoxUserID.Text = value;
            }
        }

        public string Lozinka
        {
            get
            {
                return this.txtBoxLozinka.Text;
            }
            set
            {
                this.txtBoxLozinka.Text = value;
            }
        }

        public string PorakaLogin
        {
            set { this.lblPoraka.Text = value; }
        }



        public string NovUserID
        {
            get
            {
                return txtBoxNovUserID.Text;
            }
            set
            {
                txtBoxNovUserID.Text = value;
            }
        }

        public string NovLozinka
        {
            get
            {
                return txtBoxNovLozinka.Text;
            }
            set
            {
                txtBoxNovLozinka.Text = value;
            }
        }

        public string NovEmail
        {
            get
            {
                return txtBoxNovEmail.Text;
            }
            set
            {
                txtBoxNovEmail.Text = value;
            }
        }

        public List<Korisnik> ListaKorisnici
        {
            set
            {
                this.korisnici = value;
            }
        }

        public string PorakaNovKor
        {
            set { this.lblPorakaNovKor.Text = value; }
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
            presenter = new KorisniciPresenter(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //((KorisniciPresenter)presenter).logirajKorisnikTest();
        }

        private void btnNovKor_Click(object sender, EventArgs e)
        {
            //((KorisniciPresenter)presenter).kreirajKorisnik() ;
           
        }
        public void napolniKorisnici()
        {
            lsBoxKor.Items.Clear();
            foreach (Korisnik kor in this.korisnici)
            {
                lsBoxKor.Items.Add("User:" +  kor.UserID + " Email:" + kor.Email);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //((KorisniciPresenter)presenter).listaKorisnici();
        }
    }
}

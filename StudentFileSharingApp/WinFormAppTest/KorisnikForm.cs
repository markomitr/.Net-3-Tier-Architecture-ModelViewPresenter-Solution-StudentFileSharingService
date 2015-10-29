using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presenter.Presenter;
using Presenter.Interface;
using Presenter.Interface.KorisnikViews;
using Presenter.Interface.Views.KorisnikViews;

namespace WinFormAppTest
{
    public partial class KorisnikForm : Form,IView,IKorisninPregled8View,IKorisnikPregled1View,
        IKorisnikUpdateFormView,IKorisnikLoginView,IKorisnikAddView//,IKorisnikUpdateView,IKorisnikLoginView,
    {
        IPresenter presenterkor;
        String UserIDIzbrano;
        String UserIDIzbranoEdit;

        public KorisnikForm()
        {
            InitializeComponent();
            presenterkor = new KorisniciPresenter(this);
            //((KorisniciPresenter)presenterkor).listajKorisnici();
        }

        private void btnLogIN_Click(object sender, EventArgs e)
        {
            //((KorisniciPresenter)presenterkor).logirajKorisnikNovTest();
        }
        #region LoginView
        public string UserID_Login_Input
        {
            get
            {
               return this.textBoxUserID.Text;
            }
            set
            {
                textBoxUserID.Text = value;
            }
        }

        public string Lozinka_Login_Input
        {
            get
            {
                return textBoxLozinka.Text;
            }
            set
            {
                textBoxLozinka.Text = value;
            }
        }
        #endregion

        public void logirajKorisnik(ClassDLL.SysPart.Korisnik korObj)
        {

        }

        public void nacrtajFormaZaAddKorisnik()
        {
            //OD IKorisnikAddFormView
        }
        #region UserAddView
        public string UserId_Input
        {
            get
            {
                return this.textBoxUserIDNov.Text;
            }
            set
            {
                this.textBoxUserIDNov.Text = value;
            }
        }
        public string Lozinka_Input
        {
            get
            {
                return textBoxLozinkaNov.Text;
            }
            set
            {
                textBoxLozinka.Text = value;
            }
        }
        public string Email_Input
        {
            get
            {
                return this.textBoxEmailNov.Text;
            }
            set
            {
                this.textBoxEmailNov.Text = value;
            }
        }

        public string Ime_Input
        {
            get
            {
                return this.textBoxImeNov.Text;
            }
            set
            {
                this.textBoxImeNov.Text = value;
            }
        }

        public string Prezime_Input
        {
            get
            {
                return this.textBoxPrezimeNov.Text;
            }
            set
            {
                this.textBoxPrezimeNov.Text = value;
            }
        }

        #endregion

        private void btnNovKor_Click(object sender, EventArgs e)
        {
            //((KorisniciPresenter)presenterkor).kreirajKorisnikNovTest();
            //((KorisniciPresenter)presenterkor).listajKorisnici();
            ((KorisniciPresenter)presenterkor).addKorisnik();
        }
        #region IMsgStatus
        public string ErrorPoraka
        {
            get
            {
                return this.lblStatus.Text;
            }
            set
            {
                this.lblStatus.ForeColor = System.Drawing.Color.Red;
                this.lblStatus.Text = "STATUS: " + value ;
                MessageBox.Show(value);
            }
        }

        public string InfoPoraka
        {
            get
            {
                return this.lblStatus.Text;
            }
            set
            {
                this.lblStatus.ForeColor = System.Drawing.Color.Green;
                this.lblStatus.Text = "STATUS: " + value;
            }
        }
        #endregion

        public void nacrtajPregledZaKorisnici(List<ClassDLL.SysPart.Korisnik> korLista)
        {

            int brBtn = 0;
            panelPregledKor.Controls.Clear();
            Button btnKor = new Button();
            foreach (ClassDLL.SysPart.Korisnik kor in korLista)
            {

                btnKor = new Button();
                btnKor.Text = kor.UserID + " " + kor.Ime  + " " + kor.Prezime + " " + kor.Email;
                btnKor.Tag = kor.UserID;
                btnKor.TextAlign = ContentAlignment.MiddleLeft;
                btnKor.Padding = new Padding(5);
                btnKor.Click += new EventHandler(btnKor_Click);
                btnKor.Name = kor.UserID;
                btnKor.Location = new Point(panelPregledKor.Location.X + 3, panelPregledKor.Location.Y + btnKor.Height * brBtn);
                panelPregledKor.Controls.Add(btnKor);
                btnKor.Size = new Size(250, 30);
                btnKor.Location = new Point(10 , brBtn *btnKor.Height + 15);

                brBtn ++;
            }

        }

        void btnKor_Click(object sender, EventArgs e)
        {
            Button korPress = (Button)sender;
            this.UserID_Korisnik_Pregled_Selected = korPress.Tag.ToString();
            //((KorisniciPresenter)presenterkor).pregledKorisnik();

            this.UserID_Edit_Selected = korPress.Tag.ToString();
            //((KorisniciPresenter)presenterkor).zemiKorisnikZaIzmena();


        }
        #region PregledKorisnik
        public string UserID_Korisnik_Pregled_Selected
        {
            get
            {
               return this.UserIDIzbrano ;
            }
            set
            {
                this.UserIDIzbrano = value;
            }
        }

        public void nacrtajPregledZaKorisnik(ClassDLL.SysPart.Korisnik korObj)
        {
            this.lblUserIdPregled.Text = korObj.UserID;
            this.lblLozinkaPregled.Text = korObj.Lozinka;
            this.lblEmailPregled.Text = korObj.Email;
            this.lblImePregled.Text = korObj.Ime;
            this.lblPrezimePregled.Text = korObj.Prezime;
        }
        #endregion
        #region UpdateFormView
        public string  UserID_Edit_Selected
        {
	          get 
	        { 
		        return this.UserIDIzbranoEdit; 
	        }
	          set 
	        { 
		        this.UserIDIzbranoEdit = value; 
	        }
        }

        public void  nacrtajFormaZaUpdateKorisnik(ClassDLL.SysPart.Korisnik korObj)
        {
            this.textBoxUserIDEdit.Text = korObj.UserID;
            this.textBoxUserIDEdit.Enabled = false;
            this.textBoxLozinkaEdit.Text = korObj.Lozinka;
            this.textBoxEmailEdit.Text = korObj.Email;
            this.textBoxImeEdit.Text = korObj.Ime;
            this.textBoxPrezimeEdit.Text = korObj.Prezime;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //((KorisniciPresenter)presenterkor).izmeniKorisnik();
            //((KorisniciPresenter)presenterkor).listajKorisnici();
        }

        public string UserId_Update_Input
        {
            get
            {
               return this.textBoxUserIDEdit.Text;
            }
            set
            {
                this.textBoxUserIDEdit.Text = value ;
            }
        }

        public string Lozinka_Update_Input
        {
            get
            {
                return this.textBoxLozinkaEdit.Text;
            }
            set
            {
                this.textBoxLozinkaEdit.Text = value;
            }
        }

        public string Email_Update_Input
        {
            get
            {
                return this.textBoxEmailEdit.Text;
            }
            set
            {
                this.textBoxEmailEdit.Text = value;
            }
        }

        public string Ime_Update_Input
        {
            get
            {
                return this.textBoxImeEdit.Text;
            }
            set
            {
                this.textBoxImeEdit.Text = value;
            }
        }

        public string Prezime_Korisnik_Update_Input
        {
            get
            {
                return this.textBoxPrezimeEdit.Text;
            }
            set
            {
                this.textBoxPrezimeEdit.Text = value;
            }
        }
        #endregion

        #region IKorisnikAddView Members

        public string UserId_Korisnik_Add_Input
        {
            get
            {
                return textBoxUserIDNov.Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Lozinka_Korisnik_Add_Input
        {
            get
            {
                return textBoxLozinkaNov.Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string LozinkaCheck_Korisnik_Add_Input
        {
            get
            {
                return textBoxLozinkaCheckNov.Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Email_Korisnik_Add_Input
        {
            get
            {
                return textBoxEmailNov.Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Ime_Korisnik_Add_Input
        {
            get
            {
                return textBoxImeNov.Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Prezime_Korisnik_Add_Input
        {
            get
            {
                return textBoxPrezimeNov.Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        

        public string UserId_Korisnik_Add_Validacija
        {
            get
            {
                return lblUserID_KorisnikAdd.Text;
            }
            set
            {
                lblUserID_KorisnikAdd.Text = value;
            }
        }

        public string Lozinka_Korisnik_Add_Validacija
        {
            get
            {
                return lblLozinka_KorisnikAdd.Text;
            }
            set
            {
                lblLozinka_KorisnikAdd.Text = value;
            }
        }

        public string LozinkaCheck_Korisnik_Add_Validacija
        {
            get
            {
                return lblLozinkaRE_KorisnikAdd.Text;
            }
            set
            {
                lblLozinkaRE_KorisnikAdd.Text = value;
            }
        }

        public string Email_Korisnik_Add_Validacija
        {
            get
            {
                return lblEmail_KorisnikAdd.Text;
            }
            set
            {
                lblEmail_KorisnikAdd.Text = value;
            }
        }

        public string Ime_Korisnik_Add_Validacija
        {
            get
            {
                return lblIme_KorisnikAdd.Text;
            }
            set
            {
                lblIme_KorisnikAdd.Text = value;
            }
        }

        public string Prezime_Korisnik_Add_Validacija
        {
            get
            {
                return lblPrezime_KorisnikAdd.Text;
            }
            set
            {
                lblPrezime_KorisnikAdd.Text = value;
            }
        }

     
        public void ClearValidacija()
        {
            this.UserId_Korisnik_Add_Validacija = "";
            this.Lozinka_Korisnik_Add_Validacija = "";
            this.LozinkaCheck_Korisnik_Add_Validacija = "";
            this.Email_Korisnik_Add_Validacija = "";
            this.Ime_Korisnik_Add_Validacija = "";
            this.Prezime_Korisnik_Add_Validacija = "";
        }

        #endregion
    }
}

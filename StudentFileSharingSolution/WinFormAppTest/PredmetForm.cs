using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassDLL.SysPart;
using ClassDLL.Interface;
using Presenter.Presenter;
using Presenter.Interface;
using Presenter.Interface.Views.PredmetViews;
namespace WinFormAppTest
{
    public partial class PredmetForm : Form,IView, IPredmetAddView,IPredmetEditView,IPredmetPregled8View,IPredmetPregled8SoIzborView
    {
        IPresenter predmetiPresenter;
        int id_prdmet_edit_SelectedID;
        int id_predmet_pregledizbor_SelectedID;
        public PredmetForm()
        {
            InitializeComponent();
            predmetiPresenter = new PredmetPresenter(this);
        }

        private void PredmetForm_Load(object sender, EventArgs e)
        {
            this.PredmetPresenterGet.pregled8PremdetiSoIzbor();
            this.PredmetPresenterGet.pregled8Predmeti();
        }

        #region Pomosni
        PredmetPresenter PredmetPresenterGet
        {
            get
            {
                return ((PredmetPresenter)predmetiPresenter);
            }
        } 
        #endregion
        #region IPredmetAddView

        public void nacrtajFormaZaAddNasoka()
        {
            //Forma ADD nacrtana
        }
        public string Ime_Predmet_Add_Input
        {
            get
            {
                return textBoxIme_Predmet_Add.Text;
            }
            set
            {
                textBoxIme_Predmet_Add.Text = value;
            }
        }

        public string Opis_Predmet_Add_Input
        {
            get
            {
                return textBoxOpis_Predmet_Add.Text;
            }
            set
            {
                textBoxOpis_Predmet_Add.Text = value;
            }
        }
        public string ErrorPoraka
        {
            get
            {
                return this.lblStatus.Text;
            }
            set
            {
                MessageBox.Show(value);
                this.lblStatus.ForeColor = Color.Red;
                this.lblStatus.Text = "STATUS: " + value;
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
                this.lblStatus.ForeColor = Color.Green;
                this.lblStatus.Text = "STATUS: " + value;
            }
        }
        private void btnDodadiPredmet_Click(object sender, EventArgs e)
        {
            this.PredmetPresenterGet.addPredmet();
            this.PredmetPresenterGet.pregled8PremdetiSoIzbor();
            this.PredmetPresenterGet.pregled8Predmeti();
        }
        #endregion
        #region IPredmetEditView
        public int ID_Predmet_Edit_Selected
        {
            get
            {
                return this.id_prdmet_edit_SelectedID;
            }
            set
            {
                this.id_prdmet_edit_SelectedID = value;
            }
        }

        public int ID_Predmet_Edit_Input
        {
            get
            {
                return int.Parse(this.textBoxID_Predmet_Edit.Text);
            }
            set
            {
                this.textBoxID_Predmet_Edit.Text = value.ToString();
            }
        }

        public string Ime_Predmet_Edit_Input
        {
            get
            {
                return textBoxIme_Predmet_Edit.Text;
            }
            set
            {
                textBoxIme_Predmet_Edit.Text = value;
            }
        }

        public string Opis_Predmet_Edit_Input
        {
            get
            {
                return textBoxOpis_Predmet_Edit.Text;
            }
            set
            {
                textBoxOpis_Predmet_Edit.Text = value;
            }
        }

        public void nacrtajFromaZaEditPredmet(Predmet predmetObj)
        {
            this.textBoxID_Predmet_Edit.Text = predmetObj.PredmetID.ToString();
            this.textBoxID_Predmet_Edit.Enabled = false;
            this.textBoxIme_Predmet_Edit.Text = predmetObj.Ime;
            this.textBoxOpis_Predmet_Edit.Text = predmetObj.Opis;
        }
        private void btnIzmeniPredmet_Click(object sender, EventArgs e)
        {
            this.PredmetPresenterGet.updatePredmet();
            this.PredmetPresenterGet.pregled8PremdetiSoIzbor();
            this.PredmetPresenterGet.pregled8Predmeti();
        }
        #endregion
        #region IPredmetPregled8View
        public void nacrtajPregled8Predmeti(List<Predmet> predmetList)
        {
            int brBtn = 0;
            panelPregledPredmeti.Controls.Clear();
            Button btnPredmetObj = new Button();
            foreach (Predmet predmetObj in predmetList)
            {

                btnPredmetObj = new Button();
                btnPredmetObj.Text = predmetObj.Ime + " " + predmetObj.Opis;
                btnPredmetObj.Tag = predmetObj.PredmetID ;
                btnPredmetObj.TextAlign = ContentAlignment.MiddleLeft;
                btnPredmetObj.Padding = new Padding(1);
                btnPredmetObj.FlatStyle = FlatStyle.Flat;
                //btnInstObj.Click += new EventHandler(btnInstObj_Click);
                btnPredmetObj.Location = new Point(panelPregledPredmeti.Location.X + 3, panelPregledPredmeti.Location.Y + btnPredmetObj.Height * brBtn);
                panelPregledPredmeti.Controls.Add(btnPredmetObj);
                btnPredmetObj.Size = new Size(450, 30);
                btnPredmetObj.Location = new Point(10, brBtn * btnPredmetObj.Height + 10);

                brBtn++;
            }
        }
        #endregion
        #region  IPredmetPregled8SoIzborView
        public void nacrtajPregled8PredmetiSoIzbor(List<Predmet> predmetList)
        {
            int brBtn = 0;
            panelPregledPredmetiSoIzbor.Controls.Clear();
            Button btnPredmetObj = new Button();
            foreach (Predmet predmetObj in predmetList)
            {

                btnPredmetObj = new Button();
                btnPredmetObj.Text = predmetObj.Ime + " " + predmetObj.Opis;
                btnPredmetObj.Tag = predmetObj.PredmetID;
                btnPredmetObj.TextAlign = ContentAlignment.MiddleLeft;
                btnPredmetObj.Padding = new Padding(1);
                //btnPredmetObj.FlatStyle = FlatStyle.Flat;
                btnPredmetObj.BackColor = Color.White;
                btnPredmetObj.Click += new EventHandler(btnPredmetObj_Click);
                btnPredmetObj.Location = new Point(panelPregledPredmetiSoIzbor.Location.X + 3, panelPregledPredmetiSoIzbor.Location.Y + btnPredmetObj.Height * brBtn);
                panelPregledPredmetiSoIzbor.Controls.Add(btnPredmetObj);
                btnPredmetObj.Size = new Size(450, 30);
                btnPredmetObj.Location = new Point(10, brBtn * btnPredmetObj.Height + 10);

                brBtn++;
            }
        }
        public int ID_Predmet_PregledIzbor_Selected
        {
            get
            {
                return id_predmet_pregledizbor_SelectedID;
            }
            set
            {
                id_predmet_pregledizbor_SelectedID = value;
            }
        }
        void btnPredmetObj_Click(object sender, EventArgs e)
        {
            Button kopPress = (Button)sender;
            this.ID_Predmet_PregledIzbor_Selected=this.ID_Predmet_Edit_Selected = int.Parse(kopPress.Tag.ToString());
            this.PredmetPresenterGet.zemiPredmetZaEdit();
        }
        #endregion



        
    }
}

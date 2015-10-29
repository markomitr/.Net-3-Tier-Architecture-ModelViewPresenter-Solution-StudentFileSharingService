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
using Presenter.Interface.Views.NasokaViews;
using Presenter.Interface.Views.OblastViews;
namespace WinFormAppTest
{
    public partial class NasokaForm : Form,IView,INasokaAddView,INasokaEditView,INasokaPregled8View,INasokaPregledSoIzborView,IOblastPregledSoIzborView
    {
        IPresenter oblastPresenter;
        IPresenter nasokaPresenter;
        int id_Nasoka_selected;
        int id_oblast_izborSelected;
        public NasokaForm()
        {
            InitializeComponent();
            oblastPresenter = new OblastPresenter(this);
            nasokaPresenter = new NasokaPresenter(this);
            this.OblstPresenterGet.pregled8OblastiSoIzbor();
            this.NasokaPresenterGet.pregled8Nasoki();
            this.NasokaPresenterGet.pregled8NasokiSoIzbor();
        }
        #region Pomosni
        OblastPresenter OblstPresenterGet
        {
            get
            {
                return ((OblastPresenter)oblastPresenter);
            }
        }
        NasokaPresenter NasokaPresenterGet
        {
            get
            {
                return ((NasokaPresenter)nasokaPresenter);
            }
        }
        #endregion
        #region INasokaAddView


        public void nacrtajFormaZaAddNasoka()
        {
            //Forma ADD nacrtana
        }
        public string Ime_Nasoka_Add_Input
        {
            get
            {
                return textBoxIme_Nasoka_Add.Text;
            }
            set
            {
                textBoxIme_Nasoka_Add.Text = value;
            }
        }

        public string Opis_Nasoka_Add_Input
        {
            get
            {
                return textBoxOpis_Nasoka_Add.Text;
            }
            set
            {
                textBoxOpis_Nasoka_Add.Text = value;
            }
        }

        public int OblastID_Nasoka_Add_Input
        {
            get
            {
                return this.ID_Oblast_PregledIzbor_Selected;
            }
            set
            {
                this.ID_Oblast_PregledIzbor_Selected = value;
            }
        }

        public void nacrtajFormaZaAddOblast()
        {
            //Nacrtana po default
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
        private void btnDodadiNasoka_Click(object sender, EventArgs e)
        {
            this.NasokaPresenterGet.addNasoka();
            this.NasokaPresenterGet.pregled8Nasoki();
            this.NasokaPresenterGet.pregled8NasokiSoIzbor();
        }
        #endregion
        #region IOblastPregledSoIzborView
        public int ID_Oblast_PregledIzbor_Selected
        {
            get
            {
                return this.id_oblast_izborSelected;
            }
            set
            {
                this.id_oblast_izborSelected= value;
            }
        }

        public void nacrtajPregledSoIzborOblast(List<Oblast> oblastiLista)
        {
            cBoxNasokiIzborAdd.Items.Clear();
            cBoxNasokiIzborEdit.Items.Clear();
            
            foreach(Oblast nasokaObj in oblastiLista)
            {
                cBoxNasokiIzborAdd.DisplayMember = "Ime";
                cBoxNasokiIzborEdit.DisplayMember = "Ime";
                cBoxNasokiIzborAdd.Items.Add(nasokaObj);// + "-" + ustaObj.Ime);
                cBoxNasokiIzborEdit.Items.Add(nasokaObj);
            }
        }
        private void cBoxNasokiIzborAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox sentOblasti = (ComboBox)sender;
            this.ID_Oblast_PregledIzbor_Selected = ((Oblast)sentOblasti.SelectedItem).OblastID;
        }
        #endregion
        #region INasokaPregled8View
        public void nacrtajPregled8Nasoki(List<Nasoka> nasokiLista)
        {
            int brBtn = 0;
            panelPregledNasoki.Controls.Clear();
            Button btnNasokaObj = new Button();
            foreach (Nasoka nasokaObj in nasokiLista)
            {

                btnNasokaObj = new Button();
                btnNasokaObj.Text = nasokaObj.Ime + " " + nasokaObj.Opis;
                btnNasokaObj.Tag = nasokaObj.NasokaID;
                btnNasokaObj.TextAlign = ContentAlignment.MiddleLeft;
                btnNasokaObj.Padding = new Padding(1);
                btnNasokaObj.FlatStyle = FlatStyle.Flat;
                //btnInstObj.Click += new EventHandler(btnInstObj_Click);
                btnNasokaObj.Location = new Point(panelPregledNasoki.Location.X + 3, panelPregledNasoki.Location.Y + btnNasokaObj.Height * brBtn);
                panelPregledNasoki.Controls.Add(btnNasokaObj);
                btnNasokaObj.Size = new Size(450, 30);
                btnNasokaObj.Location = new Point(10, brBtn * btnNasokaObj.Height + 10);

                brBtn++;
            }
        }
        #endregion
        #region INasokaPregledSoIzborView
        public int ID_Nasoka_Selected
        {
            get
            {
                return this.id_Nasoka_selected;
            }
            set
            {
                this.id_Nasoka_selected = value;
            }
        }

        public void nacrtajPregledSoIzborNasoki(List<Nasoka> nasokiLista)
        {
            int brBtn = 0;
            panelPregledIzborNasoki.Controls.Clear();
            Button btnNasokaObj = new Button();
            foreach (Nasoka nasokaObj in nasokiLista)
            {

                btnNasokaObj = new Button();
                btnNasokaObj.Text = nasokaObj.Ime + " " + nasokaObj.Opis;
                btnNasokaObj.Tag = nasokaObj.NasokaID;
                btnNasokaObj.TextAlign = ContentAlignment.MiddleLeft;
                btnNasokaObj.Padding = new Padding(1);        
                btnNasokaObj.BackColor = Color.White;
                btnNasokaObj.Click += new EventHandler(btnNasokaObj_Click);
                btnNasokaObj.Location = new Point(panelPregledIzborNasoki.Location.X + 3, panelPregledIzborNasoki.Location.Y + btnNasokaObj.Height * brBtn);
                panelPregledIzborNasoki.Controls.Add(btnNasokaObj);
                btnNasokaObj.Size = new Size(450, 30);
                btnNasokaObj.Location = new Point(10, brBtn * btnNasokaObj.Height + 10);

                brBtn++;
            }
        }

        void btnNasokaObj_Click(object sender, EventArgs e)
        {
            Button kopPress = (Button)sender;
            this.ID_Nasoka_Selected = int.Parse(kopPress.Tag.ToString());
            this.NasokaPresenterGet.zemiNasokaZaEdit();
        }
        #endregion
        #region INasokaEditView

        public int ID_Nasoka_Edit_Input
        {
            get
            {
                return int.Parse(this.textBoxID_Nasoka_Edit.Text);
            }
            set
            {
                this.textBoxID_Nasoka_Edit.Text = value.ToString();
            }
        }
        public string Ime_Nasoka_Edit_Input
        {
            get
            {
                return this.textBoxIme_Nasoka_Edit.Text;
            }
            set
            {
                this.textBoxIme_Nasoka_Edit.Text = value;
            }
        }
        public string Opis_Nasoka_Edit_Input
        {
            get
            {
                return this.textBoxOpis_Nasoka_Edit.Text;
            }
            set
            {
                this.textBoxOpis_Nasoka_Edit.Text = value;
            }
        }
        public int ID_Nasoka_Edit_Selected
        {
            get
            {
                return this.ID_Nasoka_Selected;
            }
            set
            {
                this.ID_Nasoka_Selected = value;
            }
        }
        public int OblastID_Nasoka_Edit_Input
        {
            get
            {
                return this.ID_Oblast_PregledIzbor_Selected;
            }
            set
            {
                this.ID_Oblast_PregledIzbor_Selected = value;
            }
        }
        public void nacrtajFormaZaEditNasoka(Nasoka nasokaObj)
        {
            this.textBoxID_Nasoka_Edit.Text = nasokaObj.NasokaID.ToString();
            this.textBoxID_Nasoka_Edit.Enabled = false;
            this.textBoxIme_Nasoka_Edit.Text = nasokaObj.Ime;
            this.textBoxOpis_Nasoka_Edit.Text = nasokaObj.Opis;
            foreach (object cbObj in cBoxNasokiIzborEdit.Items)
            {

                if (cbObj is Oblast)
                {
                    if (((Oblast)cbObj).OblastID== nasokaObj.Oblast_ID)
                    {
                        this.cBoxNasokiIzborEdit.SelectedItem = cbObj;
                        break;
                    }
                }
            }

        }
        private void btnIzmeniNasoka_Click(object sender, EventArgs e)
        {
            this.NasokaPresenterGet.updateNasoka();
            this.NasokaPresenterGet.pregled8Nasoki();
            this.NasokaPresenterGet.pregled8NasokiSoIzbor();
        }
        #endregion

        private void NasokaForm_Load(object sender, EventArgs e)
        {

        }




        
    }
}

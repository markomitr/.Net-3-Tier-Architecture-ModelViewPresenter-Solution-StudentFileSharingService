using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassDLL.SysPart;
using Presenter.Presenter;
using Presenter.Interface;
using Presenter.Interface.Views.InstitucijaViews;

namespace WinFormAppTest
{
    public partial class InstitucijaForm : Form, IView,IInstitucijaAddView,IInstitucijaEditView,IInstitucijaPregled8View,IInstitucijaPregled8SoIzborView
    {
        IPresenter instPresenter;
        int IDInstitucija_Selected;
        int ID_Institucija_Izbor;
        public InstitucijaForm()
        {
            InitializeComponent();
            instPresenter = new InstitucjaPresenter(this);
            InstPresenter.pregled8Institucii();
            InstPresenter.pregled8soIzborInstitucii();
        }
        #region Pomosni
        InstitucjaPresenter InstPresenter
        {
            get
            {
                return ((InstitucjaPresenter)instPresenter);
            }
        }
        #endregion
        private void InstitucijaAdd_Load(object sender, EventArgs e)
        {
            //Forma Load
        }

        #region AddInstitucija

        private void btnAddInstitucija_Click(object sender, EventArgs e)
        {
            ((InstitucjaPresenter)instPresenter).addInstitucija();
            InstPresenter.pregled8Institucii();
        }

        public void nacrtajFormaZaAddInstitucija()
        {
            //po default e nacrtana
        }
        public string Ime_Institucija_Add_Input
        {
            get
            {
                return this.textBoxIme_Institucija.Text;
            }
            set
            {
                this.textBoxIme_Institucija.Text = value;
            }
        }

        public string Adresa_Institucija_Add_Input
        {
            get
            {
                return this.textBoxAdresa_Institucija.Text;
            }
            set
            {
                this.textBoxAdresa_Institucija.Text = value;
            }
        }

        public string Kratenka_Institucija_Add_Input
        {
            get
            {
                return this.textBoxKratenka_Institucija.Text;
            }
            set
            {
                this.textBoxKratenka_Institucija.Text = value;
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
        #endregion


        #region Pregled8Institucija
        public void nacrtajPregled8Institucii(List<Institucija> instList)
        {
            int brBtn = 0;
            panelPregledInstitucii.Controls.Clear();
            Button btnInstObj = new Button();
            foreach (Institucija  instObj in instList)
            {

                btnInstObj = new Button();
                btnInstObj.Text = instObj.Kratenka + " " + instObj.Ime + " " + instObj.Adresa;
                btnInstObj.Tag = instObj.ID;
                btnInstObj.TextAlign = ContentAlignment.MiddleLeft;
                btnInstObj.Padding = new Padding(1);
                btnInstObj.FlatStyle = FlatStyle.Flat;
                //btnInstObj.Click += new EventHandler(btnInstObj_Click);
                btnInstObj.Location = new Point(panelPregledInstitucii.Location.X + 3, panelPregledInstitucii.Location.Y + btnInstObj.Height * brBtn);
                panelPregledInstitucii.Controls.Add(btnInstObj);
                btnInstObj.Size = new Size(450, 30);
                btnInstObj.Location = new Point(10, brBtn * btnInstObj.Height + 10);

                brBtn++;
            }
            
        }
        #endregion

        #region EditInstitucija
        public int ID_Institucija_Edit_Input
        {
            get
            {
                try
                {
                    return int.Parse(this.textBoxIDInstitucija_Edit.Text);
                }
                catch
                {
                    return -1;
                }
                
            }
            set
            {
                this.textBoxIDInstitucija_Edit.Text = value.ToString() ;
            }
        }

        public string Ime_Institucija_Edit_Input
        {
            get
            {
                return this.textBoxImeInstitucija_Edit.Text;
            }
            set
            {
                this.textBoxImeInstitucija_Edit.Text = value;
            }
        }

        public string Adresa_Institucija_Edit_Input
        {
            get
            {
                return this.textBoxAdresaInstitucija_Edit.Text;
            }
            set
            {
                this.textBoxAdresaInstitucija_Edit.Text = value;
            }
        }

        public string Kratenka_Institucija_Edit_Input
        {
            get
            {
                return this.textBoxKratenkaInstitucija_Edit.Text;
            }
            set
            {
                this.textBoxKratenkaInstitucija_Edit.Text = value;
            }
        }

        public int ID_Institucija_Edit_Selected
        {
            get
            {
               return this.IDInstitucija_Selected;
            }
            set
            {
                 this.IDInstitucija_Selected = value;
            }
        }

        public void nacrtajFromaZaEditInstitucija(Institucija instObj)
        {
            this.textBoxIDInstitucija_Edit.Text = instObj.ID.ToString();
            this.textBoxIDInstitucija_Edit.Enabled = false;
            this.textBoxImeInstitucija_Edit.Text  = instObj.Ime;
            this.textBoxAdresaInstitucija_Edit.Text = instObj.Adresa;
            this.textBoxKratenkaInstitucija_Edit.Text = instObj.Kratenka;
        }

        private void    btnInstitucijaEdit_Click(object sender, EventArgs e)
        {
            InstPresenter.updateInstitucija();
            InstPresenter.pregled8Institucii();
            InstPresenter.pregled8soIzborInstitucii();
        }
        #endregion

        #region IInstitucijaPregled8SoIzborView
        public int ID_Institucija_Izbor_Selected
        {
            get
            {
                return this.ID_Institucija_Izbor;
            }
            set
            {
                this.ID_Institucija_Izbor = value;
            }
        }

        public void nacrtajPregled8InstituciiSoIzbor(List<Institucija> instList)
        {
            int brBtn = 0;
            panelInstituciiIzbor.Controls.Clear();
            Button btnInstObj = new Button();
            foreach (Institucija instObj in instList)
            {

                btnInstObj = new Button();
                btnInstObj.Text = instObj.Kratenka + " " + instObj.Ime + " " + instObj.Adresa;
                btnInstObj.Tag = instObj.ID;
                btnInstObj.TextAlign = ContentAlignment.MiddleLeft;
                btnInstObj.Padding = new Padding(5);
                btnInstObj.BackColor = Color.White;
                btnInstObj.Click += new EventHandler(btnInstObj_Click);
                btnInstObj.Location = new Point(panelInstituciiIzbor.Location.X + 3, panelInstituciiIzbor.Location.Y + btnInstObj.Height * brBtn);
                panelInstituciiIzbor.Controls.Add(btnInstObj);
                btnInstObj.Size = new Size(350, 30);
                btnInstObj.Location = new Point(10, brBtn * btnInstObj.Height + 15);

                brBtn++;
            }
        }
        void btnInstObj_Click(object sender, EventArgs e)
        {
            Button korPress = (Button)sender;
            this.ID_Institucija_Edit_Selected = int.Parse(korPress.Tag.ToString());
            this.ID_Institucija_Izbor_Selected = int.Parse(korPress.Tag.ToString());
            InstPresenter.zemiInstitucijaZaEdit();
        }
        #endregion
    }
}

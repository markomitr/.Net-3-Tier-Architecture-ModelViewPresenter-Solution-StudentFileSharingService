using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassDLL.RegularExpression;
using ClassDLL.SysPart;
using Presenter.Interface.Presenters;
using Presenter.Interface.Views.UstanovaViews;
using Presenter.Interface.Views.InstitucijaViews;
using Presenter.Interface;
using Presenter.Presenter;
namespace WinFormAppTest
{
    public partial class UstanovaForm : Form, IView, IMsgStatus, IUstanovaAddView, IUstanovaEditView, IUstanovaPregled1View, IUstanovaPregled8View, IUstanovaPregled8SoIzborView, IInstitucijaPregled8SoIzborView
    {
        IUstanovaPresenter ustanovaPresenter;
        IInstitucijaPresenter institucijaPrezenter;

        int ustanovaID_Selected;
        public UstanovaForm()
        {
            InitializeComponent();
            ustanovaPresenter = new UstanovaPresenter(this);
            institucijaPrezenter = new InstitucjaPresenter(this);
            institucijaPrezenter.pregled8soIzborInstitucii();

            ustanovaPresenter.pregled8Ustanovi();
            ustanovaPresenter.pregled8soIzborUstanovi();
          
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
                this.lblStatus.ForeColor = Color.Red;
                this.lblStatus.Text =  " " + value;
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
                this.lblStatus.Text =  " " + value;
            }
        }
        #endregion

        #region IUstanovaAddView
        public string Ime_Ustanova_Add_Input
        {
            get
            {
                return this.textBoxIme_Ustanova.Text;
            }
            set
            {
                this.textBoxIme_Ustanova.Text = value;
            }
        }

        public string Adresa_Ustanova_Add_Input
        {
            get
            {
                return this.textBoxAdresa_Ustanova.Text;
            }
            set
            {
                this.textBoxAdresa_Ustanova.Text = value;
            }
        }

        public string WebStrana_Ustanova_Add_Input
        {
            get
            {
                return textBoxWebStrana_Ustanova.Text;
            }
            set
            {
                this.textBoxWebStrana_Ustanova.Text = value;
            }
        }

        public int InstitucijaID_Ustanova_Add_Input
        {
            get
            {
                string pom = this.comboBoxInstitucija_Add.SelectedItem.ToString().Split('-')[0].Trim();
                return Int16.Parse(pom);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajFormaZaAddUstanova()
        {
            //nema sto da se crta
        }
        #endregion

        #region IUstanovaEditView

        public int ID_Ustanova_Edit_Input
        {
            get
            {
                return Int16.Parse(this.textBoxIDUstanova_Edit.Text.Trim());
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int ID_Institucija_Edit_Input
        {
            get
            {
                string pom = this.comboBoxInstitucija_Edit.SelectedItem.ToString().Split('-')[0].Trim();
                return Int16.Parse(pom);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Ime_Ustanova_Edit_Input
        {
            get
            {
                return this.textBoxImeUstanova_Edit.Text;
            }
            set
            {
                this.textBoxImeUstanova_Edit.Text = value;
            }
        }

        public string Adresa_Ustanova_Edit_Input
        {
            get
            {
                return this.textBoxAdresaUstanova_Edit.Text;
            }
            set
            {
                this.textBoxAdresaUstanova_Edit.Text = value;
            }
        }

        public string WebStrana_Ustanova_Edit_Input
        {
            get
            {
                return this.textBoxWebStranaUstanova_Edit.Text;
            }
            set
            {
                this.textBoxWebStranaUstanova_Edit.Text = value;
            }
        }

        public int ID_Ustanova_Edit_Selected
        {
            get
            {
                return this.ustanovaID_Selected;
            }
            set
            {
                this.ustanovaID_Selected = value;
            }
        }

        public void nacrtajFromaZaEditUstanova(Ustanova ustanovaObj, List<Institucija> institucii)
        {
            this.textBoxIDUstanova_Edit.Text = ustanovaObj.UstanovaID.ToString();
            this.textBoxIDUstanova_Edit.Enabled = false;
            this.textBoxImeUstanova_Edit.Text = ustanovaObj.Ime;
            this.textBoxAdresaUstanova_Edit.Text = ustanovaObj.Adresa;
            this.textBoxWebStranaUstanova_Edit.Text = ustanovaObj.WebStrana;

            int i = -1;
            comboBoxInstitucija_Edit.Items.Clear();
            foreach (Institucija instObj in institucii)
            {
                i++;
                comboBoxInstitucija_Edit.Items.Add(instObj.ID + "-" + instObj.Ime);
                if (instObj.ID == ustanovaObj.Institucija_ID)
                {
                    comboBoxInstitucija_Edit.SelectedIndex = i;
                }
                
            }

        }
        #endregion

        #region IUstanovaPregled1View
        public int ID_UStanova_Pregled1_Input
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregled1Ustanova(Ustanova ustanovaObj)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUstanovaPregled8View
        public void nacrtajPregled8Ustanovi(List<Ustanova> ustanovaList)
        {
            int brBtn = 0;
            panelPregledUstanovi.Controls.Clear();
            Button btnInstObj = new Button();
            foreach (Ustanova instObj in ustanovaList)
            {

                btnInstObj = new Button();
                btnInstObj.Text = instObj.Ime + " " + instObj.Adresa;
                btnInstObj.Tag = instObj.UstanovaID;
                btnInstObj.TextAlign = ContentAlignment.MiddleLeft;
                btnInstObj.Padding = new Padding(1);
                btnInstObj.FlatStyle = FlatStyle.Flat;
                //btnInstObj.Click += new EventHandler(btnInstObj_Click);
                btnInstObj.Location = new Point(panelPregledUstanovi.Location.X + 3, panelPregledUstanovi.Location.Y + btnInstObj.Height * brBtn);
                panelPregledUstanovi.Controls.Add(btnInstObj);
                btnInstObj.Size = new Size(450, 30);
                btnInstObj.Location = new Point(10, brBtn * btnInstObj.Height + 10);

                brBtn++;
            }
        }
        #endregion
        #region IInstitucijaPregled8SoIzborView
        public int ID_Institucija_Izbor_Selected
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }

        public void nacrtajPregled8InstituciiSoIzbor(List<Institucija> instList)
        {
            //ova za da go polne combobox za izbor pri add
            comboBoxInstitucija_Add.Items.Clear();
            foreach (Institucija instObj in instList)
            {
                comboBoxInstitucija_Add.Items.Add(instObj.ID + "-" + instObj.Ime);
            }

        }

        #endregion


        #region IUstanovaPregled8SoIzborView

        public int ID_Ustanova_Izbor_Selected
        {
            get
            {
                return this.ID_Ustanova_Edit_Selected;
            }
            set
            {
                this.ID_Ustanova_Edit_Selected = value;
            }
        }

        public void nacrtajPregled8UstanoviSoIzbor(List<Ustanova> ustanovaList)
        {
            int brBtn = 0;
            panelUstanoviIzbor.Controls.Clear();
            Button btnInstObj = new Button();
            foreach (Ustanova ustanovaObj in ustanovaList)
            {

                btnInstObj = new Button();
                btnInstObj.Text =  ustanovaObj.Ime + " " + ustanovaObj.Adresa;
                btnInstObj.Tag = ustanovaObj.UstanovaID;
                btnInstObj.TextAlign = ContentAlignment.MiddleLeft;
                btnInstObj.Padding = new Padding(5);
                btnInstObj.BackColor = Color.White;
                btnInstObj.Click += new EventHandler(btnUstanivaObj_Click);
                btnInstObj.Location = new Point(panelUstanoviIzbor.Location.X + 3, panelUstanoviIzbor.Location.Y + btnInstObj.Height * brBtn);
                panelUstanoviIzbor.Controls.Add(btnInstObj);
                btnInstObj.Size = new Size(350, 30);
                btnInstObj.Location = new Point(10, brBtn * btnInstObj.Height + 15);

                brBtn++;
            }
        }
        #endregion

        void btnUstanivaObj_Click(object sender, EventArgs e)
        {
            Button korPress = (Button)sender;
            this.ID_Ustanova_Edit_Selected = int.Parse(korPress.Tag.ToString());//za edit pogledot
            this.ID_Ustanova_Izbor_Selected  = int.Parse(korPress.Tag.ToString());//za pregled8izvorview
            ustanovaPresenter.zemiUstanovaZaEdit();
        }

        private void btnUstanovaEdit_Click(object sender, EventArgs e)
        {
            ((UstanovaPresenter)ustanovaPresenter).updateUstanova();
            ((UstanovaPresenter)ustanovaPresenter).pregled8Ustanovi();
        }
        private void btnAddUstanova_Click(object sender, EventArgs e)
        {
            ((UstanovaPresenter)ustanovaPresenter).addUstanova();
            ((UstanovaPresenter)ustanovaPresenter).pregled8Ustanovi();
            ((UstanovaPresenter)ustanovaPresenter).pregled8soIzborUstanovi();
        }

        private void UstanovaForm_Load(object sender, EventArgs e)
        {

        }
    }
}

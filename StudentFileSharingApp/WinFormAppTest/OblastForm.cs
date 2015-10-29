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
using Presenter.Interface.Views.UstanovaViews;
using Presenter.Interface.Views.OblastViews;
namespace WinFormAppTest
{
    public partial class OblastForm : Form,IView,IOblastAddView,IOblastPregled8View,IOblastPregledSoIzborView,IOblastEditView,IUstanovaPregled8SoIzborView
    {
        IPresenter oblastPresenter;
        IPresenter ustanovaPresenter;
        int ID_Oblast_SelectedID;
        int ID_Ustanovi_Izbor_Selected;
        public OblastForm()
        {
            InitializeComponent();
            oblastPresenter = new OblastPresenter(this);
            ustanovaPresenter = new UstanovaPresenter(this);
            this.OblstPresenterGet.pregled8Oblasti();
            this.OblstPresenterGet.pregled8OblastiSoIzbor();
            this.UstanovaPresenterGet.pregled8soIzborUstanovi();
        }
        #region Pomosni
        OblastPresenter OblstPresenterGet
        {
            get
            {
                return ((OblastPresenter)oblastPresenter);
            }
        }
        UstanovaPresenter UstanovaPresenterGet
        {
            get
            {
                return ((UstanovaPresenter)ustanovaPresenter);
            }
        }
        #endregion
        #region IOblastAddView
        public string Ime_Oblast_Add_Input
        {
            get
            {
                return textBoxIme_Oblast.Text;
            }
            set
            {
                textBoxIme_Oblast.Text = value;
            }
        }

        public string Adresa_Oblast_Add_Input
        {
            get
            {
                return textBoxAdresa_Oblast.Text;
            }
            set
            {
                textBoxAdresa_Oblast.Text = value;
            }
        }

        public string WebStrana_Oblast_Add_Input
        {
            get
            {
                return textBoxWeb_Oblast.Text;
            }
            set
            {
                textBoxWeb_Oblast.Text = value;
            }
        }

        public int UstanovaID_Oblast_Add_Input
        {
            get
            {
                return this.ID_Ustanova_Izbor_Selected ;
            }
            set
            {
                this.ID_Ustanova_Izbor_Selected = value;
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
        private void btnDodadiOblast_Click(object sender, EventArgs e)
        {
            this.OblstPresenterGet.addOblast();
            this.OblstPresenterGet.pregled8Oblasti();
        }
        #endregion
        #region IOblastPregled8View
        public void nacrtajPregled8Oblasti(List<Oblast> oblastiLista)
        {
            int brBtn = 0;
            panelPregledOblasti.Controls.Clear();
            Button btnOblastObj = new Button();
            foreach (Oblast oblastObj in oblastiLista)
            {

                btnOblastObj = new Button();
                btnOblastObj.Text = oblastObj.Ime +  " " + oblastObj.Adresa + " " + oblastObj.WebStrana;
                btnOblastObj.Tag = oblastObj.OblastID;
                btnOblastObj.TextAlign = ContentAlignment.MiddleLeft;
                btnOblastObj.Padding = new Padding(1);
                btnOblastObj.FlatStyle = FlatStyle.Flat;
                //btnInstObj.Click += new EventHandler(btnInstObj_Click);
                btnOblastObj.Location = new Point(panelPregledOblasti.Location.X + 3, panelPregledOblasti.Location.Y + btnOblastObj.Height * brBtn);
                panelPregledOblasti.Controls.Add(btnOblastObj);
                btnOblastObj.Size = new Size(450, 30);
                btnOblastObj.Location = new Point(10, brBtn * btnOblastObj.Height + 10);

                brBtn++;
            }
        }
        #endregion
        #region IOblastPregledSoIzborView
        public int ID_Oblast_PregledIzbor_Selected
        {
            get
            {
                return this.ID_Oblast_SelectedID;
            }
            set
            {
                this.ID_Oblast_SelectedID = value;
            }
        }

        public void nacrtajPregledSoIzborOblast(List<Oblast> oblastiLista)
        {
            int brBtn = 0;
            panelPregledOblastiIZbor.Controls.Clear();
            Button btnOblastObj = new Button();
            foreach (Oblast oblastObj in oblastiLista)
            {

                btnOblastObj = new Button();
                btnOblastObj.Text = oblastObj.Ime + " " + oblastObj.Adresa + " " + oblastObj.WebStrana;
                btnOblastObj.Tag = oblastObj.OblastID;
                btnOblastObj.TextAlign = ContentAlignment.MiddleLeft;
                btnOblastObj.Padding = new Padding(1);
                btnOblastObj.BackColor = Color.White;
                btnOblastObj.Click += new EventHandler(btnOblastObj_Click);
                btnOblastObj.Location = new Point(panelPregledOblastiIZbor.Location.X + 3, panelPregledOblastiIZbor.Location.Y + btnOblastObj.Height * brBtn);
                panelPregledOblastiIZbor.Controls.Add(btnOblastObj);
                btnOblastObj.Size = new Size(450, 30);
                btnOblastObj.Location = new Point(10, brBtn * btnOblastObj.Height + 10);

                brBtn++;
            }
        }

        void btnOblastObj_Click(object sender, EventArgs e)
        {
            Button kopPress = (Button)sender;
            this.ID_Oblast_PregledIzbor_Selected = int.Parse(kopPress.Tag.ToString());
            OblstPresenterGet.zemiOblastZaEdit();
        }
        #endregion
        #region IOblastEditView
        private void btnIzmeniOblast_Click(object sender, EventArgs e)
        {
            this.OblstPresenterGet.updateOblast();
            this.OblstPresenterGet.pregled8OblastiSoIzbor();
        }

        public int ID_Oblast_Edit_Input
        {
            get
            {
                return int.Parse(this.textBoxID_Oblast_Edit.Text);
            }
            set
            {
                this.textBoxID_Oblast_Edit.Text = value.ToString();
            }
        }

        public string Ime_Oblast_Edit_Input
        {
            get
            {
                return this.textBoxIme_Oblast_Edit.Text;
            }
            set
            {
                this.textBoxIme_Oblast_Edit.Text = value;
            }
        }

        public string Adresa_Oblast_Edit_Input
        {
            get
            {
                return this.textBoxAdresa_Oblast_Edit.Text;
            }
            set
            {
                this.textBoxAdresa_Oblast_Edit.Text = value;
            }
        }

        public string WebStrana_Oblast_Edit_Input
        {
            get
            {
                return this.textBoxWeb_Oblast_Edit.Text;
            }
            set
            {
                this.textBoxWeb_Oblast_Edit.Text = value;
            }
        }

        public int ID_Oblast_Edit_Selected
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

        public int ID_Ustanova_Oblast_Edit_Selected
        {
            get
            {
                return this.ID_Ustanova_Izbor_Selected;
            }
            set
            {
                this.ID_Ustanova_Izbor_Selected = value;
            }
        }

        public void nacrtajFromaZaEditOblast(Oblast oblastObj)
        {
            this.textBoxID_Oblast_Edit.Text  = oblastObj.OblastID.ToString();
            this.textBoxID_Oblast_Edit.Enabled = false;
            this.textBoxIme_Oblast_Edit.Text = oblastObj.Ime;
            this.textBoxAdresa_Oblast_Edit.Text = oblastObj.Adresa;
            this.textBoxWeb_Oblast_Edit.Text = oblastObj.WebStrana;
            foreach(object cbObj in cBoxUstanoviIzborEdit.Items)
            {
                
                if(cbObj  is Ustanova)
                {
                    if (((Ustanova)cbObj).UstanovaID == oblastObj.Ustanova_ID)
                    {
                        this.cBoxUstanoviIzborEdit.SelectedItem = cbObj;
                        break;
                    }
                }
            }
            
        }
        #endregion
        #region IUstanovaPregled8SoIzborView
        public int ID_Ustanova_Izbor_Selected
        {
            get
            {
                return this.ID_Ustanovi_Izbor_Selected;
            }
            set
            {
                this.ID_Ustanovi_Izbor_Selected = value;
            }
        }

        public void nacrtajPregled8UstanoviSoIzbor(List<Ustanova> ustanovaList)
        {
            cBoxUstanoviIzbor.Items.Clear();
            cBoxUstanoviIzborEdit.Items.Clear();
            foreach (Ustanova ustaObj in ustanovaList)
            {
                cBoxUstanoviIzbor.DisplayMember = "Ime";
                cBoxUstanoviIzborEdit.DisplayMember = "Ime";
                cBoxUstanoviIzbor.Items.Add(ustaObj);// + "-" + ustaObj.Ime);
                cBoxUstanoviIzborEdit.Items.Add(ustaObj);
            }
        }
        #endregion

        private void cBoxUstanoviIzbor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox sentUstanovi = (ComboBox)sender;
            this.ID_Ustanova_Izbor_Selected = ((Ustanova)sentUstanovi.SelectedItem).UstanovaID;
        }

        private void OblastForm_Load(object sender, EventArgs e)
        {

        }

    }
}

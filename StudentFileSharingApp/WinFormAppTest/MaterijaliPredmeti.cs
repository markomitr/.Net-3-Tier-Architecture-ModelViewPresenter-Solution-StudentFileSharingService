using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassDLL.Interface;
using ClassDLL.SysPart;
using Presenter.Interface;
using Presenter.Interface.Views;
using Presenter.Interface.Views.CompositeViews;
using Presenter.Interface.Views.InstitucijaViews;
using Presenter.Interface.Views.MaterijaliPredmetiViews;
using Presenter.Interface.Views.MaterijalViews;
using Presenter.Interface.Views.NasokaPredmetDelViews;
using Presenter.Interface.Views.PredmetViews;
using Presenter.Presenter;
namespace WinFormAppTest
{
    public partial class MaterijaliPredmeti : Form, IView, IMsgStatus, IInstitucijaPregled8SoIzborView, IIUONIzborView, IPredmetPregled8SoIzborView, INPDPregled1SoIzborView, IMaterijaliPredmetAddView, IMaterijaliPregled8SoIzborView, IMaterijaliPredmetPregled8View
    {
        UstanovaPresenter ustanovaPresenter;
        InstitucjaPresenter institucijaPresenter;
        OblastPresenter oblastPresenter;
        NasokaPresenter nasokaPresenter;
        PredmetPresenter predmetPresenter;
        MaterijalPresenter materijalPresenter;

        public MaterijaliPredmeti()
        {
            InitializeComponent();
            ustanovaPresenter = new UstanovaPresenter(this);
            institucijaPresenter = new InstitucjaPresenter(this);
            oblastPresenter = new OblastPresenter(this);
            nasokaPresenter = new NasokaPresenter(this);
            predmetPresenter = new PredmetPresenter(this);

            materijalPresenter = new MaterijalPresenter(this);

            institucijaPresenter.pregled8soIzborInstitucii();
            ustanovaPresenter.pregled8UstanoviSoFilter();
            oblastPresenter.pregledOblastiSoFilter();
            nasokaPresenter.pregled8NasokiSoFilter();
            predmetPresenter.pregled8PremdetiSoIzbor();

            materijalPresenter.pregled8SoIzborMaterijali();
        }
        private void MaterijaliPredmeti_Load(object sender, EventArgs e)
        {

        }

        #region IMsgStatus Members

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

        #region IInstitucijaPregled8SoIzborView Members

        public int ID_Institucija_Izbor_Selected
        {
            get
            {
                int id_institucija = ((Institucija)this.comboBoxInstitucija_Add.SelectedItem).ID;
                return id_institucija;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregled8InstituciiSoIzbor(List<Institucija> instiList)
        {
            //ova za da go polne combobox za izbor pri add
            comboBoxInstitucija_Add.Items.Clear();
            comboBoxInstitucija_Add.DisplayMember = "Ime";
            foreach (Institucija instObj in instiList)
            {
                comboBoxInstitucija_Add.Items.Add(instObj);

            }
            comboBoxInstitucija_Add.SelectedIndex = 0;
        }
        private void comboBoxInstitucija_Add_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxUstanoviIzbor.Items.Clear();
            cBoxOblastiIzborAdd.Items.Clear();
            cBoxNasokiIzbor.Items.Clear();
            listBoxDeloviNasoka.Items.Clear();
            listBoxPredmeti.Items.Clear();

            ustanovaPresenter.pregled8UstanoviSoFilter();
            //oblastPresenter.pregledOblastiSoFilter();
            //nasokaPresenter.pregled8NasokiSoFilter();
        }
        #endregion

        #region IUstanovaPregledSoFilterView Members

        public int ID_Ustanova_UstanovaFilter_Selected
        {
            get
            {
                int id_ustanova = ((Ustanova)this.cBoxUstanoviIzbor.SelectedItem).UstanovaID;
                return id_ustanova;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int ID_Institucuja_UstanovaFilter_Selected
        {
            get
            {
                return this.ID_Institucija_Izbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajUstanovaSoFilter(List<Ustanova> listaUstanovi)
        {
            cBoxUstanoviIzbor.Items.Clear();
            cBoxUstanoviIzbor.DisplayMember = "Ime";
            foreach (Ustanova ustaObj in listaUstanovi)
            {
                cBoxUstanoviIzbor.Items.Add(ustaObj);

            }
            cBoxUstanoviIzbor.SelectedIndex = 0;
        }
        private void cBoxUstanoviIzbor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxOblastiIzborAdd.Items.Clear();
            cBoxNasokiIzbor.Items.Clear();
            listBoxDeloviNasoka.Items.Clear();
            listBoxPredmeti.Items.Clear();

            oblastPresenter.pregledOblastiSoFilter();
            //nasokaPresenter.pregled8NasokiSoFilter();
        }
        #endregion

        #region IOblastPregledSoFilterView Members

        public int ID_Ustanova_OblastFilter_Selected
        {
            get
            {
                return this.ID_Ustanova_UstanovaFilter_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int ID_Oblast_OblastFilter_Selected
        {
            get
            {
                return ((Oblast)this.cBoxOblastiIzborAdd.SelectedItem).OblastID;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregledOblastiSoFilter(List<Oblast> oblastiList)
        {
            cBoxOblastiIzborAdd.Items.Clear();
            cBoxOblastiIzborAdd.DisplayMember = "Ime";

            foreach (Oblast oblastObj in oblastiList)
            {
                cBoxOblastiIzborAdd.Items.Add(oblastObj);
            }
            cBoxOblastiIzborAdd.SelectedIndex = 0;
        }
        private void cBoxOblastiIzborAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxNasokiIzbor.Items.Clear();
            listBoxDeloviNasoka.Items.Clear();
            listBoxPredmeti.Items.Clear();
            nasokaPresenter.pregled8NasokiSoFilter();
        }
        #endregion

        #region INasokaPregledSoFilterView Members

        public int ID_Nasoka_NasokaFilter_Selected
        {
            get
            {
                return ((Nasoka)this.cBoxNasokiIzbor.SelectedItem).NasokaID;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int ID_Oblast_NasokaFilter_Selected
        {
            get
            {
                return this.ID_Oblast_OblastFilter_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajNasokaSoFilter(List<Nasoka> listaNasoki)
        {
            cBoxNasokiIzbor.Items.Clear();
            cBoxNasokiIzbor.DisplayMember = "Ime";

            foreach (Nasoka nasokaObj in listaNasoki)
            {
                cBoxNasokiIzbor.Items.Add(nasokaObj);
            }
            cBoxNasokiIzbor.SelectedIndex = 0;
        }
        private void cBoxNasokiIzbor_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxDeloviNasoka.Items.Clear();
            listBoxPredmeti.Items.Clear();

            predmetPresenter.pregled8PremdetiSoIzbor();
        }
        #endregion

        #region IPredmetPregled8SoIzborView Members

        public int ID_Predmet_PregledIzbor_Selected
        {
            get
            {
                return ((Predmet)this.listBoxPredmeti.SelectedItem).PredmetID;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregled8PredmetiSoIzbor(List<Predmet> predmetList)
        {
            listBoxPredmeti.Items.Clear();
            listBoxPredmeti.DisplayMember = "Ime";

            foreach (Predmet predmetObj in predmetList)
            {
                listBoxPredmeti.Items.Add(predmetObj);
            }
            listBoxPredmeti.SelectedIndex = 0;
        }

        #endregion

        #region INPDPregled1SoIzborView Members

        public int Nasoka_ID_NPD_Pregled_Selected
        {
            get
            {
                return this.ID_Nasoka_NasokaFilter_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Predmet_ID_NPD_Pregled_Selected
        {
            get
            {
                return this.ID_Predmet_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Nasoka_ID_NPD_PregledIzbor_Selected
        {
            get
            {
                return this.ID_Nasoka_NasokaFilter_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Predmet_ID_NPD_PregledIzbor_Selected
        {
            get
            {
                return this.ID_Predmet_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Del_ID_NPD_PregledIzbor_Selected
        {
            get
            {
                return ((DeloviPredmetNasoka)this.listBoxDeloviNasoka.SelectedItem).Del_ID;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregledDelovizaPredmetiZaNasokaSoIzbor(List<DeloviPredmetNasoka> dpnList)
        {
            listBoxDeloviNasoka.Items.Clear();
            listBoxDeloviNasoka.DisplayMember = "Del_Ime";

            foreach (DeloviPredmetNasoka delObj in dpnList)
            {
                listBoxDeloviNasoka.Items.Add(delObj);
            }
            listBoxDeloviNasoka.SelectedIndex = 0;
        }

        private void listBoxPredmetiMaterijal_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxDeloviNasoka.Items.Clear();

            nasokaPresenter.pregled1DeloviZaPredmetPoNasoka();
        }
        #endregion

        #region IMaterijalPredmetAddView Members

        public int Materijal_ID_MaterijalPredmet_Add_Input
        {
            get
            {
                return this.ID_Materijal_Materijali_Izbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Nasoka_ID_MaterijalPredmet_Add_Input
        {
            get
            {
                return this.Nasoka_ID_NPD_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Predmet_ID_MaterijalPredmet_Add_Input
        {
            get
            {
                return this.Predmet_ID_NPD_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Del_ID_MaterijalPredmet_Add_Input
        {
            get
            {
                return this.Del_ID_NPD_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajFormaZaAddMaterijalPredmet()
        {
            //nacrtana e po default
        }
        private void btnMaterijalPredmetAdd_Click(object sender, EventArgs e)
        {
            materijalPresenter.addMaterijalPredmet();
            materijalPresenter.pregled8MaterijaliPredmet();
        }
        #endregion
        #region IMaterijaliPregled8SoIzborView Members

        public int ID_Materijal_Materijali_Izbor_Selected
        {
            get
            {
                return ((Materijal)this.listBoxMaterijaliPregled.SelectedItem).MaterijalID;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregled8MaterijaliSoIzbor(List<Materijal> materijaliList)
        {
            this.listBoxMaterijaliPregled.Items.Clear();

            foreach (Materijal mat in materijaliList)
            {
                listBoxMaterijaliPregled.Items.Add(mat);
            }
            this.listBoxMaterijaliPregled.SelectedIndex = 0;
        }

        #endregion



        #region IMaterijaliPredmetPregled8View Members

        public int Nasoka_ID_MaterijaliPredmet_Pregled_Input
        {
            get
            {
                return this.Nasoka_ID_NPD_Pregled_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Predmet_ID_MaterijaliPredmet_Pregled_Input
        {
            get
            {
                return this.Predmet_ID_NPD_Pregled_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Del_ID_MaterijaliPredmet_Pregled_Input
        {
            get
            {
                return this.Del_ID_NPD_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregled8MaterijaliPredmet(MaterijaliGrupirani materijaliGrupirani)
        {
            listBoxMaterijaliPredmet.Items.Clear();
            foreach (Materijal item in materijaliGrupirani.DeloviMaterijali.First.Value.Materijali)
            {
                listBoxMaterijaliPredmet.Items.Add(item);
            }
            listBoxMaterijaliPredmet.SelectedIndex = 0;
        }

        #endregion

        private void listBoxDeloviNasoka_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBoxMaterijaliPredmet.Items.Clear();
            materijalPresenter.pregled8MaterijaliPredmet();
        }
    }
}

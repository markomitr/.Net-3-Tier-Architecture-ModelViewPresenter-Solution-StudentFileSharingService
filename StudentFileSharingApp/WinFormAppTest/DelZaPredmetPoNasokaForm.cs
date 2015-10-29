using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassDLL.SysPart;
using Presenter.Interface.Presenters;
using Presenter.Interface.Views.InstitucijaViews;
using Presenter.Interface.Views.UstanovaViews;
using Presenter.Interface.Views.OblastViews;
using Presenter.Interface.Views.NasokaViews;
using Presenter.Interface.Views.DeloviViews;
using Presenter.Interface.Views.PredmetViews;
using Presenter.Interface.Views.CompositeViews;
using Presenter.Interface.Views.NasokaPredmetDelViews;
using Presenter.Interface;
using Presenter.Presenter;
namespace WinFormAppTest
{
    public partial class DelZaPredmetPoNasokaForm : Form, IView,
                                                          IInstitucijaPregled8SoIzborView,
                                                          IUstanovaPregledSoFilterView,
                                                          IOblastPregledSoFilterView,
                                                          INasokaPregledSoFilterView,
                                                          IPredmetiNasokaPoNasokaPregled1View,
                                                          INasokaPregled1View,
                                                          IPredmetiNasokaPoNasokaPregled1SoIzborView,
                                                          IDeloviPregled8SoIzborView,
                                                          INPDAddView
    {   
        IInstitucijaPresenter institucijaPrezenter;
        IUstanovaPresenter ustanovaPresenter;
        IOblastPresenter oblastPresenter;
        INasokaPresenter nasokaPresenter;
        IPredmetPresenter predmetPresenter;
        IDelPresenter delPresenter;
        public DelZaPredmetPoNasokaForm()
        {
            InitializeComponent();
            institucijaPrezenter = new InstitucjaPresenter(this);
            ustanovaPresenter = new UstanovaPresenter(this);
            oblastPresenter = new OblastPresenter(this);
            nasokaPresenter = new NasokaPresenter(this);
            predmetPresenter = new PredmetPresenter(this);
            delPresenter = new DelPresenter(this);

        }

        private void DelZaPredmetPoNasokaForm_Load(object sender, EventArgs e)
        {
            institucijaPrezenter.pregled8soIzborInstitucii();
            //nasokaPresenter.pregled1PredmetiPoNasokaSoIzbor();
            delPresenter.pregled8SoIzborDelovi();

        }

        #region IInstitucijaPregled8SoIzborView
        public int ID_Institucija_Izbor_Selected
        {
            get
            {
                int id_institucija = ((Institucija)this.comboBoxInstitucija_Add.SelectedItem).ID;
                return id_institucija;
            }
            set
            {

            }
        }

        public void nacrtajPregled8InstituciiSoIzbor(List<Institucija> instList)
        {
            //ova za da go polne combobox za izbor pri add
            comboBoxInstitucija_Add.Items.Clear();
            comboBoxInstitucija_Add.DisplayMember = "Ime";
            foreach (Institucija instObj in instList)
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

            ustanovaPresenter.pregled8UstanoviSoFilter();
            oblastPresenter.pregledOblastiSoFilter();
            nasokaPresenter.pregled8NasokiSoFilter();
        }
        #endregion
        #region IUstanovaPregled8SoFilterView
        public int ID_Ustanova_UstanovaFilter_Selected
        {
            get
            {
                int id_ustanova = -1;
                try
                {
                    id_ustanova = ((Ustanova)this.cBoxUstanoviIzbor.SelectedItem).UstanovaID;
                }
                catch (Exception ex)
                {
                    // prazna lista
                }

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

            oblastPresenter.pregledOblastiSoFilter();
            nasokaPresenter.pregled8NasokiSoFilter();
        }
        #endregion
        #region IOblastPregledSoFilterView
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
                int id_oblast = -1;
                try
                {
                    id_oblast = ((Oblast)this.cBoxOblastiIzborAdd.SelectedItem).OblastID;
                }
                catch (Exception ex)
                {
                    //prazna lista
                }
                return id_oblast;
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
            nasokaPresenter.pregled8NasokiSoFilter();
        }
        #endregion
        #region INasokaPregledSoFilterView
        public int ID_Nasoka_NasokaFilter_Selected
        {
            get
            {
                int id_nasoka = -1;
                try
                {
                    id_nasoka = ((Nasoka)this.cBoxNasokiIzbor.SelectedItem).NasokaID;
                }
                catch (Exception ex)
                {
                    //prazna lista
                }
                return id_nasoka;
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
            listBoxPostoeckiPredmeti.Items.Clear();
            cBoxIzborPredmetPoNasoka.Items.Clear();
            nasokaPresenter.pregled1PredmetiPoNasoka();
            nasokaPresenter.pregled1Nasoka();
            nasokaPresenter.pregled1PredmetiPoNasokaSoIzbor();
        }

        #endregion

        #region IMsgStatus
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
        #region IPredmetNasokaPregled1View
        public int NasokaID_PredmetiNasoka_Pregled_Selected
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

        public void nacrtajPregledPredmetiZaNasoka(List<PredmetNasoka> pnList)
        {
            listBoxPostoeckiPredmeti.Items.Clear();
            listBoxPostoeckiPredmeti.DisplayMember = "Ime";
            listBoxPostoeckiPredmeti.SelectionMode = SelectionMode.None;

            foreach (PredmetNasoka pnObj in pnList)
            {
                listBoxPostoeckiPredmeti.Items.Add(pnObj);
            }
            //listBoxPostoeckiPredmeti.SelectedIndex = 0;

        }
        #endregion
        #region INasokaPregled1View
        public int ID_Nasoka_Pregled1_Selected
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

        public void nacrtajPregled1Nasoka(Nasoka nasokaObj)
        {
            this.lblNasokaIme.Text = nasokaObj.Ime;
            this.txtBoxNasokaOpis_Pregled.Text = nasokaObj.Opis;
        }
        #endregion
        #region IPredmetNasokaPregled1SoIzborView
        public int NasokaID_PredmetiNasoka_PregledFilter_Selected
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
        public int Nasoka_ID_PredmetiNasoka_PregledIzbor_Selected
        {
            get
            {
                int id_Nasoka = -1;
                try
                {
                    id_Nasoka = ((PredmetNasoka)this.cBoxIzborPredmetPoNasoka.SelectedItem).NasokaID;
                }
                catch (Exception ex)
                {
                    //prazna lista
                }
                return id_Nasoka;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public int Predmet_ID_PredmetiNasoka_PregledIzbor_Selected
        {
            get
            {
                int id_Predmet = -1;
                try
                {
                    id_Predmet = ((PredmetNasoka)this.cBoxIzborPredmetPoNasoka.SelectedItem).PredmetID;
                }
                catch (Exception ex)
                {
                    //prazna lista
                }
                return id_Predmet;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregledPredmetiZaNasokaSoIzbor(List<PredmetNasoka> pnList)
        {
            cBoxIzborPredmetPoNasoka.Items.Clear();
            cBoxIzborPredmetPoNasoka.DisplayMember = "Ime";
            foreach (PredmetNasoka pnObj in pnList)
            {
                cBoxIzborPredmetPoNasoka.Items.Add(pnObj);
            }
            cBoxIzborPredmetPoNasoka.SelectedIndex = 0;
        }
        #endregion
        #region IDeloviPregled8SoIzborView
        public int ID_Delovi_Izbor_Selected
        {
            get
            {
                int id_del = -1;
                try
                {
                    id_del = ((Del)this.listBoxDelovi.SelectedItem).ID;
                }
                catch (Exception ex)
                {
                    //prazna lista
                }
                return id_del;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void nacrtajPregled8DeloviSoIzbor(List<Del> deloviList)
        {
            listBoxDelovi.Items.Clear();
            listBoxDelovi.DisplayMember = "Ime";

            foreach (Del delObj in deloviList)
            {
                listBoxDelovi.Items.Add(delObj);
            }
            listBoxDelovi.SelectedIndex = 0;
            
        }
        #endregion

        private void btnDodadiDelZaPredmetPoNasoka_Click(object sender, EventArgs e)
        {
            nasokaPresenter.addDelZaPredmetPoNasoka();
        }
        #region  INPDAddView
        public int Nasoka_ID_NasokaPredmetDel_Input
        {
            get
            {
                return this.Nasoka_ID_PredmetiNasoka_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Predmet_ID_NasokaPredmetDel_Input
        {
            get
            {
                return this.Predmet_ID_PredmetiNasoka_PregledIzbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Delovi_ID_NasokaPredmetDel_Input
        {
            get
            {
                return this.ID_Delovi_Izbor_Selected;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Stuff_ID_NasokaPredmetDel_Input
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
        #endregion
    }
}

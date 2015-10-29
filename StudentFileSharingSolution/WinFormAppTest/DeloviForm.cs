using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ClassDLL.SysPart;
using ClassDLL.Interface;
using Presenter.Presenter;
using Presenter.Interface.Presenters;
using Presenter.Interface.Views.DeloviViews;
using Presenter.Interface;
using System.Windows.Forms;

namespace WinFormAppTest
{
    public partial class DeloviForm : Form,IView,IDeloviAddView,IDeloviEditView,IDeloviPregled1View,IDeloviPregled8View ,IDeloviPregled8SoIzborView
    {
        DelPresenter delPresenter;
        int _id_del_Selected = -1;
        public DeloviForm()
        {
            InitializeComponent();
            delPresenter = new DelPresenter(this);
            delPresenter.pregled8Delovi();
            delPresenter.pregled8SoIzborDelovi();
        }

        private void btnAddInstitucija_Click(object sender, EventArgs e)
        {
            this.delPresenter.addDel();
            this.textBoxIme_Del_Add.Text = "";
            this.textBoxVidIzgled_Del_Add.Text = "";
            delPresenter.pregled8Delovi();
            delPresenter.pregled8SoIzborDelovi();
        }

        #region IDeloviAddView Members

        public string Ime_Delovi_Add_Input
        {
            get
            {
                return this.textBoxIme_Del_Add.Text;
            }
            set
            {
                this.textBoxIme_Del_Add.Text = value;
            }
        }

        public char ImaPredavac_Delovi_Add_Input
        {
            get
            {
                if (checkBoxImaPredavac_Del_Add.Checked == true)
                {
                    return 'D';
                }
                else
                {
                    return 'N';
                }
            }
            set
            {
                if (value == 'D')
                {
                    this.checkBoxImaPredavac_Del_Add.Checked = true;
                }
                else
                {
                    this.checkBoxImaPredavac_Del_Add.Checked = false;
                }
            }
        }

        public int VidIzgled_Delovi_Add_Input
        {
            get
            {
                return Int32.Parse(this.textBoxVidIzgled_Del_Add.Text.Trim());
            }
            set
            {
                this.textBoxVidIzgled_Del_Add.Text = value.ToString();
            }
        }

        public void nacrtajFormaZaAddDelovi()
        {
            //veke e implementirana 
        }

        #endregion

        #region IMsgStatus Members

        public string ErrorPoraka
        {
            get
            {
                return this.lblStatus.Text;
            }
            set
            {
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

        #region IDeloviEditView Members

        public int ID_Delovi_Edit_Input
        {
            get
            {
                return Int32.Parse(this.textBoxIDDel_Del_Edit.Text.Trim());
            }
            set
            {
                this.textBoxIDDel_Del_Edit.Text = value.ToString();
            }
        }

        public string Ime_Delovi_Edit_Input
        {
            get
            {
                return this.textBoxIme_Del_Edit.Text;
            }
            set
            {
                this.textBoxIme_Del_Edit.Text = value;
            }
        }

        public char ImaPredavac_Delovi_Edit_Input
        {
            get
            {
                if (checkBoxImaPredavac_Del_Edit.Checked == true)
                {
                    return 'D';
                }
                else
                {
                    return 'N';
                }
            }
            set
            {
                if (value == 'D')
                {
                    this.checkBoxImaPredavac_Del_Edit.Checked = true;
                }
                else
                {
                    this.checkBoxImaPredavac_Del_Edit.Checked = false;
                }
            }
        }

        public int VidIzgled_Delovi_Edit_Input
        {
            get
            {
                return Int32.Parse(this.textBoxVidIzgled_Del_Edit.Text.Trim());
            }
            set
            {
                this.textBoxVidIzgled_Del_Edit.Text = value.ToString();
            }
        }

        public char Aktiven_Delovi_Edit_Input
        {
            get
            {
                if (this.checkBoxAktiven_Del_Edit.Checked == true)
                {
                    return 'D';
                }
                else
                {
                    return 'N';
                }
            }
            set
            {
                if (value == 'D')
                {
                    this.checkBoxAktiven_Del_Edit.Checked = true;
                }
                else if (value == 'N')
                {
                    this.checkBoxAktiven_Del_Edit.Checked = false;
                }
            }
        }

        public int ID_Delovi_Edit_Selected
        {
            get
            {
                return this._id_del_Selected;
            }
            set
            {
                this._id_del_Selected = value;
            }
        }

        public void nacrtajFormaZaEditDelovi(Del delObj)
        {
            if (delObj != null)
            {
                this.ID_Delovi_Edit_Input = delObj.ID;
                this.Ime_Delovi_Edit_Input = delObj.Ime;
                this.Aktiven_Delovi_Edit_Input = delObj.Aktiven;
                this.ImaPredavac_Delovi_Edit_Input = delObj.ImaPredavac;
                this.VidIzgled_Delovi_Edit_Input = delObj.Vid_Izgled;

                this.textBoxIDDel_Del_Edit.Enabled = false;
            }
        }

        #endregion

        #region IDeloviPregled1View Members

        public int ID_Delovi_Pregled1_Input
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

        public void nacrtajPregled1Delovi(Del delObj)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDeloviPregled8View Members

        public void nacrtajPregled8Delovi(List<Del> deloviList)
        {
            if (deloviList != null)
            {
                int brBtn = 0;
                panelPregledDelovi.Controls.Clear();
                Button btnDelObj = new Button();
                foreach (Del delObj in deloviList)
                {

                    btnDelObj = new Button();
                    btnDelObj.Text = delObj.Ime + " Predavac:" + delObj.ImaPredavac + " Izgled:"+ delObj.Vid_Izgled; 
                    btnDelObj.Tag = delObj.ID;
                    btnDelObj.TextAlign = ContentAlignment.MiddleLeft;
                    btnDelObj.Padding = new Padding(1);
                    btnDelObj.FlatStyle = FlatStyle.Flat;
                    btnDelObj.Location = new Point(panelPregledDelovi.Location.X + 3, panelPregledDelovi.Location.Y + btnDelObj.Height * brBtn);
                    panelPregledDelovi.Controls.Add(btnDelObj);
                    btnDelObj.Size = new Size(450, 30);
                    btnDelObj.Location = new Point(10, brBtn * btnDelObj.Height + 10);

                    brBtn++;
                }
            }
        }

        #endregion

        #region IDeloviPregled8SoIzborView Members

        public int ID_Delovi_Izbor_Selected
        {
            get
            {
                return this.ID_Delovi_Edit_Selected;
            }
            set
            {
                this.ID_Delovi_Edit_Selected = value;
            }
        }

        public void nacrtajPregled8DeloviSoIzbor(List<Del> deloviList)
        {
            if (deloviList != null)
            {
                int brBtn = 0;
                panelDeloviIzbor.Controls.Clear();
                Button btnDelObj = new Button();
                foreach (Del delObj in deloviList)
                {

                    btnDelObj = new Button();
                    btnDelObj.Text = delObj.Ime + " Predavac:" + delObj.ImaPredavac + " Izgled:" + delObj.Vid_Izgled;
                    btnDelObj.Tag = delObj.ID;
                    btnDelObj.TextAlign = ContentAlignment.MiddleLeft;
                    btnDelObj.Padding = new Padding(1);
                    btnDelObj.FlatStyle = FlatStyle.Flat;
                    btnDelObj.Click += new EventHandler(btnDelObj_Click);
                    btnDelObj.Location = new Point(panelDeloviIzbor.Location.X + 3, panelDeloviIzbor.Location.Y + btnDelObj.Height * brBtn);
                    panelDeloviIzbor.Controls.Add(btnDelObj);
                    btnDelObj.Size = new Size(450, 30);
                    btnDelObj.Location = new Point(10, brBtn * btnDelObj.Height + 10);

                    brBtn++;
                }
            }
        }
        void btnDelObj_Click(object sender, EventArgs e)
        {
            Button korPress = (Button)sender;
            this.ID_Delovi_Edit_Selected  = int.Parse(korPress.Tag.ToString());
            this.ID_Delovi_Edit_Selected = int.Parse(korPress.Tag.ToString());
            delPresenter.zemiDelZaEdit();
        }

        #endregion

        private void btnDelEdit_Click(object sender, EventArgs e)
        {

            delPresenter.updateDel();
            delPresenter.pregled8Delovi();
            delPresenter.pregled8SoIzborDelovi();
        }
    }
}

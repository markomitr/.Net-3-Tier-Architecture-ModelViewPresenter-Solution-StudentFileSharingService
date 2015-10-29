using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Interface;
using Presenter.Interface.Presenters;
using Presenter.Interface.Views.MaterijalViews;
using Presenter.Presenter;
namespace WinFormAppTest
{
    public partial class Materijali : Form, IView, IMaterijalAddView
	{
        IMaterijalPresenter _materijalPresenter;
        String _DodadenoOD;//ova ne treba sega e samo za da ne loadovame korisnici

        string _imeFile;//pomosen za Imeto na fajlot 
		public Materijali()
		{
			InitializeComponent();
            this._materijalPresenter = new MaterijalPresenter(this);

            this._DodadenoOD = "12193";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            this.btnAddMaterijal.Enabled = false;
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
            if (this.openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                this.txtUploadFile.Text = this.openFileDialog1.FileName;
                this._imeFile = openFileDialog1.SafeFileName;
            }
		}

		private void btnUpload_Click(object sender, EventArgs e)
		{
			// the upload button is also used as a cancel button, depending on the state of the FtpProgress thread
			if(this.ftpProgress1.IsBusy)
			{
				this.ftpProgress1.CancelAsync();
				this.btnUpload.Text = "Upload";
			}
			else
			{
				// create a new FtpSettings class to store all the paramaters for the FtpProgress thread
				FtpSetup f = new FtpSetup();
				f.Host = this.txtHost.Text;
				f.UserName = this.txtUsername.Text;
				f.Password = this.txtPassword.Text;
				f.TargetFolder = this.txtDir.Text;
				f.SourceFile = this.txtUploadFile.Text;
				this.toolStripProgressBar1.Visible = true;
				this.ftpProgress1.RunWorkerAsync(f);
				this.btnUpload.Text = "Cancel";
			}
		}

		private void ftpProgress1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.toolStripStatusLabel1.Text = e.UserState.ToString();	// the message will be something like: 45 Kb / 102.12 Mb
			this.toolStripProgressBar1.Value = Math.Min(this.toolStripProgressBar1.Maximum, e.ProgressPercentage);		
		}

		private void ftpProgress1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "FTP error");
            }
            else if (e.Cancelled)
            {
                this.toolStripStatusLabel1.Text = "Upload Cancelled";
            }
            else
            {
                this.toolStripStatusLabel1.Text = "Upload Complete";
                this.btnAddMaterijal.Enabled = true;
                this.textBoxPateka_Materijal_Add.Text = this.txtDir.Text + "\\" + this._imeFile;
                this.textBoxPateka_Materijal_Add.Enabled = false;
            }
			this.btnUpload.Text = "Upload";
			this.toolStripProgressBar1.Visible = false;
		}
        #region IMaterijalAddView Members

        public string Naslov_Materijal_Add_Input
        {
            get
            {
                return this.textBoxNaslov_Materijal_Add.Text;
            }
            set
            {
                this.textBoxNaslov_Materijal_Add.Text = value;
            }
        }

        public string Opis_Materijal_Add_Input
        {
            get
            {
                return this.textBoxOpis_Materijal_Add.Text;
            }
            set
            {
                this.textBoxOpis_Materijal_Add.Text = value;
            }
        }

        public string Slika_Materijal_Add_Input
        {
            get
            {
                return this.textBoxSlika_Materijal_Add.Text;
            }
            set
            {
                this.textBoxSlika_Materijal_Add.Text = value;
            }
        }

        public string Pateka_Materijal_Add_Input
        {
            get
            {
                return this.textBoxPateka_Materijal_Add.Text;
            }
            set
            {
                this.textBoxPateka_Materijal_Add.Text = value;
            }
        }

        public string DodadenOD_Materijal_Add_Input
        {
            get
            {
                return this._DodadenoOD;
            }
            set
            {
                this._DodadenoOD = value;
            }
        }
        public string Type_Materijal_Add_Input
        {
            get
            {
                return this.textBoxType_Materijal_Add.Text;
            }
            set
            {
                this.textBoxType_Materijal_Add.Text = value;
            }
        }
        public void nacrtajFormaZaAddMaterijal()
        {
            //formata e veke nacertana
        }


        public int Predmet_ID_Materijal_Add_Input
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

        public int Delovi_ID_Materijal_Add_Input
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
                MessageBox.Show(value);
                this.lblStatus.ForeColor = Color.Red;
                this.lblStatus.Text = " " + value;
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
                this.lblStatus.Text = " " + value;
            }
        }

        #endregion

        private void btnAddMaterijal_Click_1(object sender, EventArgs e)
        {
            _materijalPresenter.addMaterijal();
        }
	}
}
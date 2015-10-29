using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassDLL.GreskiEX;
using ClassDLL.RegularExpression;
using ClassDLL.SysPart;
using Presenter.Interface;
using Presenter.Interface.Views.MaterijalViews;
using Presenter.Interface.KorisnikViews;
using Presenter.Interface.Presenters;
using Presenter.Presenter;
namespace WebAppTestiranje
{
    public partial class Materijali : System.Web.UI.Page, IView, IMaterijalAddView, IKorisninPregled8View
    {
        #region AceKontrolaField
        private bool _bIsBusy = false;

        private String _strHost;
        private String _strUsername;
        private String _strPassword;
        private String _strTargetFolder;
        private String _strSourceFile;
        #endregion
        int dodadenOd;
        IMaterijalPresenter _materijalPresenter;
        KorisniciPresenter  _korisnikPresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            this._materijalPresenter = new MaterijalPresenter(this);
            this._korisnikPresenter = new KorisniciPresenter(this);
        }

        #region IMaterijalAddView Members

        public string Naslov_Materijal_Add_Input
        {
            get
            {
                return this.textBoxNaslovMaterijal_Add.Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Opis_Materijal_Add_Input
        {
            get
            {
                return this.textBoxOpisMaterijal_Add.Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Slika_Materijal_Add_Input
        {
            get
            {
                return this.textBoxSlikaMaterijal_Add.Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Pateka_Materijal_Add_Input
        {
            get
            {
                return this.textBoxPatekaMaterijal_Add.Text;
            }
            set
            {
                this.textBoxPatekaMaterijal_Add.Text = value;
            }
        }

        public string DodadenOD_Materijal_Add_Input
        {
            get
            {
                return this.dodadenOdMaterijal_Add.SelectedValue;
            }
            set
            {
                throw new NotImplementedException();
            }
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

        public void nacrtajFormaZaAddMaterijal()
        {
            //se crta po default
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
                this.lblStatus.Text = value;
                this.lblStatus.ForeColor = System.Drawing.Color.Red;
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
                this.lblStatus.Text = value;
                this.lblStatus.ForeColor = System.Drawing.Color.Green;
            }
        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Host = "ftp://78.157.0.161";
            this.UserName = "Administrator";
            this.Password = "Tv2010PC";
            this.TargetFolder = "Materjali";





            try
            {
                this.StartUploading();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            this.Pateka_Materijal_Add_Input =this.TargetFolder+"/"+ this.kaci1.FileName;
            _korisnikPresenter.listajKorisnici();


        }
        #region AceKontrola

        private void UploadFile()
        {
            if (kaci1.HasFile)
            {
                _strSourceFile = kaci1.PostedFile.FileName;
                String ServerPath = String.Format("{0}/{1}{2}", _strHost, _strTargetFolder == "" ? "" : _strTargetFolder + "/", Path.GetFileName(_strSourceFile));
                if (!ServerPath.ToLower().StartsWith("ftp://"))
                    ServerPath = "ftp://" + ServerPath;
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ServerPath);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(UserName, Password);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;




                long FileSize = new FileInfo(SourceFile).Length;
                string FileSizeDescription = GetFileSize(FileSize);
                int ChunkSize = 4096, NumRetries = 0, MaxRetries = 50;
                long SentBytes = 0;
                byte[] Buffer = new byte[ChunkSize];

                using (Stream requestStream = request.GetRequestStream())
                {
                    using (FileStream fs = File.Open(_strSourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        int BytesRead = fs.Read(Buffer, 0, ChunkSize);

                        while (BytesRead > 0)
                        {
                            try
                            {
                                if (_bIsBusy == false)
                                    return;

                                requestStream.Write(Buffer, 0, BytesRead);

                                SentBytes += BytesRead;

                                Console.WriteLine(String.Format("Transferred({0}%): {1} / {2}", (int)(((decimal)SentBytes / (decimal)FileSize) * 100), GetFileSize(SentBytes), FileSizeDescription));


                            }
                            catch (Exception ex)
                            {

                                if (NumRetries++ < MaxRetries)
                                {

                                    fs.Position -= BytesRead;
                                }
                                else
                                {
                                    throw new Exception(String.Format("Грешка настаната од премногу обиди. \n{0}", ex.ToString()));
                                }
                            }
                            BytesRead = fs.Read(Buffer, 0, ChunkSize);
                        }
                    }
                }
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    System.Diagnostics.Debug.WriteLine(String.Format("Качувањето на датотеката е комплетно, статус {0}", response.StatusDescription));
                _bIsBusy = false;

            }
            else
                throw new Exception("Ве молиме изберете датотека!!!");

        }

        public static string GetFileSize(long numBytes)
        {
            string fileSize = "";

            if (numBytes > 1073741824)
                fileSize = String.Format("{0:0.00} Gb", (double)numBytes / 1073741824);
            else if (numBytes > 1048576)
                fileSize = String.Format("{0:0.00} Mb", (double)numBytes / 1048576);
            else
                fileSize = String.Format("{0:0} Kb", (double)numBytes / 1024);

            if (fileSize == "0 Kb")
                fileSize = "1 Kb";
            return fileSize;
        }

        public bool isBusy
        {
            get
            {
                return this._bIsBusy;
            }
        }

        public void StartUploading()
        {
            this._bIsBusy = true;
            UploadFile();

        }




        #region GetSetRegion
        public String Host
        {
            get
            {
                return _strHost;
            }
            set
            {
                this._strHost = value;
            }
        }


        public String UserName
        {
            get
            {
                return _strUsername;
            }
            set
            {
                this._strUsername = value;
            }
        }


        public String Password
        {
            get
            {
                return _strPassword;
            }
            set
            {
                this._strPassword = value;
            }
        }


        public String TargetFolder
        {
            get
            {
                return _strTargetFolder;
            }
            set
            {
                this._strTargetFolder = value;
            }
        }


        public String SourceFile
        {
            get
            {
                return _strSourceFile;
            }
            set
            {
                this._strSourceFile = value;
            }
        }

        #endregion

        protected void btnAddMaterijal_Click(object sender, EventArgs e)
        {
            _materijalPresenter.addMaterijal();
        }
        #endregion

        #region IKorisninPregled8View Members

        public void nacrtajPregledZaKorisnici(List<Korisnik> korLista)
        {
            this.dodadenOdMaterijal_Add.Items.Clear();
            foreach (Korisnik korObj in korLista)
            {
                this.dodadenOdMaterijal_Add.Items.Add(new ListItem(korObj.Ime, korObj.UserID));
            }
        }

        #endregion
    }
}
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Diagnostics;

public partial class FtpUploadControl : System.Web.UI.UserControl
{
    private bool _bIsBusy = false;

    private String _strHost;
    private String _strUsername;
    private String _strPassword;
    private String _strTargetFolder;
    private String _strSourceFile;

    protected void Page_Load(object sender, EventArgs e)
    {
 
    }

    private void UploadFile()
    {
        System.Web.UI.WebControls.FileUpload upload = new FileUpload();
        if (upload.HasFile)
        {
            _strSourceFile = upload.PostedFile.FileName;
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


}

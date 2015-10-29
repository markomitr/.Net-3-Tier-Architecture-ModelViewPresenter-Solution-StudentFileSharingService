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


using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;

public partial class FileDownload : System.Web.UI.UserControl
{

    private String _strHost;
    private String _strUsername;
    private String _strPassword;
    private String _strTargetFolder;
    private String _strSourceFile;

    public FileDownload() 
    {
        this.Host = "ftp://78.157.0.161";
        this.UserName = "Administrator";
        this.Password = "Tv2010PC";
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public void StartDownloading()
    {

        String ServerPath = String.Format("{0}/{1}{2}", _strHost, _strTargetFolder == "" ? "" : _strTargetFolder + "/", _strSourceFile);
        if (!ServerPath.ToLower().StartsWith("ftp://"))
            ServerPath = "ftp://" + ServerPath;


        FtpWebRequest request = FtpWebRequest.Create(ServerPath) as FtpWebRequest;


        request.Method = WebRequestMethods.Ftp.GetFileSize;
        request.Credentials = new NetworkCredential(_strUsername, _strPassword);
        request.UsePassive = true;
        request.UseBinary = true;
        request.KeepAlive = true;

        int dataLength = (int)request.GetResponse().ContentLength;


        request = FtpWebRequest.Create(ServerPath) as FtpWebRequest;
        request.Method = WebRequestMethods.Ftp.DownloadFile;
        request.Credentials = new NetworkCredential(_strUsername, _strPassword);
        request.UsePassive = true;
        request.UseBinary = true;
        request.KeepAlive = false;


        FtpWebResponse response = request.GetResponse() as FtpWebResponse;
        Stream reader = response.GetResponseStream();

        try
        {
            byte[] buffer = new byte[1024];

            string strExtenstion = Path.GetExtension(SourceFile).ToLower();

            Response.Clear();
            Response.Buffer = true;

            if (strExtenstion == ".doc" || strExtenstion == ".docx")
            {
                Response.ContentType = "application/vnd.ms-word";
                Response.AddHeader("content-disposition",
                                                  "attachment;filename=" + SourceFile);
            }
            else if (strExtenstion == ".xls" || strExtenstion == ".xlsx")
            {
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition",
                                                "attachment;filename=" + SourceFile);
            }
            else if (strExtenstion == ".pdf")
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition",
                                               "attachment;filename=" + SourceFile);
            }
            else if (strExtenstion == ".jpg" || strExtenstion == ".jpeg")
            {
                Response.ContentType = "image/jpeg";
                Response.AddHeader("content-disposition",
                                               "attachment;filename=" + SourceFile);
            }
            else if (strExtenstion == ".ppt" || strExtenstion == ".pptx" || strExtenstion == ".pot" || strExtenstion == "pos")
            {
                Response.ContentType = "application/vnd.ms-powerpoint";
                Response.AddHeader("content-disposition",
                                               "attachment;filename=" + SourceFile);
            }
            else {
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition",
                                               "attachment;filename=" + SourceFile);
            }

            Response.AddHeader("Content-Length", dataLength.ToString());
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);



            while (true)
            {
                if (Response.IsClientConnected)
                {
                    int bytesRead = reader.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {

                        break;
                    }
                    else
                    {
                        Response.OutputStream.Write(buffer, 0, bytesRead);
                        Response.Flush();
                    }
                }
                else
                {

                    break;
                }
            }
        }

        catch (Exception ex)
        {
          
            Response.Write("Error : " + ex.Message);
        }
        finally
        {

            try
            {

                if (reader != null)
                    reader.Close();


                if (response != null)
                    response.Close();

                Response.End();

            }
            catch (Exception gr)
            {

            }

        }

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

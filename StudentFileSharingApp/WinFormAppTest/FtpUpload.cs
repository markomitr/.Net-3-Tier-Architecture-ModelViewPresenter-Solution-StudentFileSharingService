using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace WinFormAppTest
{

    public partial class FtpUpload : BackgroundWorker
    {
        public FtpUpload()
        {
            InitializeComponent();
        }

        public FtpUpload(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private void FtpProgress_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker bgWorker = sender as BackgroundWorker;
            FtpSetup ftpSetup = e.Argument as FtpSetup;
            String ServerPath = String.Format("{0}/{1}{2}", ftpSetup.Host, ftpSetup.TargetFolder == "" ? "" : ftpSetup.TargetFolder + "/", Path.GetFileName(ftpSetup.SourceFile));
            if (!ServerPath.ToLower().StartsWith("ftp://"))
                ServerPath = "ftp://" + ServerPath;
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ServerPath);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(ftpSetup.UserName, ftpSetup.Password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;




            // Kopiranje na sodrzinata na datoteka vo stream
            long FileSize = new FileInfo(ftpSetup.SourceFile).Length;
            string FileSizeDescription = GetFileSize(FileSize); 		
            int ChunkSize = 4096, NumRetries = 0, MaxRetries = 50;
            long SentBytes = 0;
            byte[] Buffer = new byte[ChunkSize];   

            using (Stream requestStream = request.GetRequestStream())
            {
                using (FileStream fs = File.Open(ftpSetup.SourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    int BytesRead = fs.Read(Buffer, 0, ChunkSize);	// citanje na segmentite od datotekata vo buffer
                    //sekvencno isprakjanje na podatocite, se dodeka FileStream.Read() ne vrati nula
                    while (BytesRead > 0)
                    {
                        try
                        {
                            if (bgWorker.CancellationPending)
                                return;

                            //isprakjanje na podatokot do server
                            requestStream.Write(Buffer, 0, BytesRead);

  
                            SentBytes += BytesRead;

                            // osvezuvanje na korisnickiot interface
                            string SummaryText = String.Format("Isprateno: {0} / {1}", GetFileSize(SentBytes), FileSizeDescription);
                            bgWorker.ReportProgress((int)(((decimal)SentBytes / (decimal)FileSize) * 100), SummaryText);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Exception: " + ex.ToString());
                            if (NumRetries++ < MaxRetries)
                            {
                               
                                fs.Position -= BytesRead;
                            }
                            else
                            {
                                throw new Exception(String.Format("Premnogu obidi. \n{0}", ex.ToString()));
                            }
                        }
                        BytesRead = fs.Read(Buffer, 0, ChunkSize);	
                    }
                }
            }
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                System.Diagnostics.Debug.WriteLine(String.Format("Kacuvanjeto na datotekata zavrsi, status: {0}", response.StatusDescription));

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
    }
}

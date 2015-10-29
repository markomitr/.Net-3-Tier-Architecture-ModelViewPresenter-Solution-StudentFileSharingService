using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormAppTest
{
    public class FtpSetup
    {
        private String _strHost;
        private String _strUsername;
        private String _strPassword;
        private String _strTargetFolder;
        private String _strSourceFile;

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

}

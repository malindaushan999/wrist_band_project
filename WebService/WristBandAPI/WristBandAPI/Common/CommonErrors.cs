using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WristBandAPI.Common
{
    /**
     * 1    -  999 Common 
     * 1001 - 1999 Base
     * 2001 - 2999 
     * 3001 - 3999 
     */

    public static class CommonErrors
    {
        public static class SUCCESS
        {
            public static readonly int eCode = 0000;
            public static readonly string eMsg = "Operation is successfully completed.";
        }

        public static class DBOperationError
        {
            public static readonly int eCode = 0001;
            public static readonly string eMsg = "Error occured while performing database operation";
        }

        public static class InformationNotFound
        {
            public static readonly int eCode = 0002;
            public static readonly string eMsg = "Information Not Found";
        }

        public static class InvalidParams
        {
            public static readonly int eCode = 0003;
            public static readonly string eMsg = "Invalid Params";
        }

        public static class SessionExpired
        {
            public static readonly int eCode = 0004;
            public static readonly string eMsg = "SessionExpired";
        }

        public static class FileUploadError
        {
            public static readonly int eCode = 0005;
            public static readonly string eMsg = "FileUploadError";
        }

        public static class InfomationSavingError
        {
            public static readonly int eCode = 0006;
            public static readonly string eMsg = "Can not save the information to database";
        }

        public static class InvalidCSVItemCount
        {
            public static readonly int eCode = 0007;
            public static readonly string eMsg = "Invalid CSV Item Count";
        }

        public static class InvalidListCount
        {
            public static readonly int eCode = 0008;
            public static readonly string eMsg = "Invalid List Count";
        }

        public static class InvalidCSVID
        {
            public static readonly int eCode = 0009;
            public static readonly string eMsg = "Invalid CSV File Name";
        }
        public static class TemporyDataNotFound
        {
            public static readonly int eCode = 0010;
            public static readonly string eMsg = "Temp Data Not Found";
        }
        public static class UserNotFound
        {
            public static readonly int eCode = 0011;
            public static readonly string eMsg = "User Not Found";
        }
        public static class RecordAlreadyExist
        {
            public static readonly int eCode = 0012;
            public static readonly string eMsg = "Record already exist";
        }

        public static class FailToConnectNSBMACtiveDirectory
        {
            public static readonly int eCode = 0013;
            public static readonly string eMsg = "Invalid User Name or Password";
        }

        public static class IncorrectOldPassword
        {
            public static readonly int eCode = 0014;
            public static readonly string eMsg = "Incorrect Old Password";
        }

        public static class InvalidUser
        {
            public static readonly int eCode = 0015;
            public static readonly string eMsg = "Invalid User";
        }
    }
}
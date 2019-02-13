using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WristBandAPI.Common
{
    public class StaticData
    {
        public static readonly int AUDIT_STR_MAX_LEN = 2000;
        public static readonly string[] EXCLUDE_AUDIT_TABLES = { };
        public static string S_LogUser = "UNKNOWN";
        public static readonly string SYSADMIN = "sysadmin";
        public static readonly long SYSADMIN_ID = 0;
        public static readonly string GROUPNEXTID = "GROUPNEXTID";
        public static readonly string DAG_NOTIFICATION_GROUPNEXTID = "DAG_NOTIFICATION_GROUPNEXTID";
        public static readonly int AUTO_GEN_PASSWORD_LENGTH = 6;
        public static readonly int NOOF_NON_ALPHA_NUMERIC = 3;


    }
}
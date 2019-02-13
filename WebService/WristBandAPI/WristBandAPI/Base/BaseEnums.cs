using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WristBandAPI.Base
{
    [DataContract(Name = "EBUserTitleType")]
    public enum EBUserTitle
    {
        [EnumMember]
        MR = 0,

        [EnumMember]
        MRS = 1,

        [EnumMember]
        MISS = 2,

        [EnumMember]
        MS = 3,

        [EnumMember]
        DR = 4,

        [EnumMember]
        REV = 5
    }

    [DataContract(Name = "EBUserType")]
    public enum EBUserType
    {
        [EnumMember]
        SYS_USER = 0,

        [EnumMember]
        USER = 1
    }

    [DataContract(Name = "EBSessionStatus")]
    public enum EBSessionStatus
    {
        [EnumMember]
        NOT_DEFINED = 0,

        [EnumMember]
        OPEN = 1,

        [EnumMember]
        CLOSED = 2
    }
}
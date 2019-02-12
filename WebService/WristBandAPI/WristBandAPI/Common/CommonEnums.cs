using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WristBandAPI.Common
{

    [DataContract(Name = "ECDeleteType")]
    public enum ECDeleteType
    {
        [EnumMember]
        NOT_DELETE = 0,

        [EnumMember]
        DELETE = 1
    }

    [DataContract(Name = "ECSessionStatus")]
    public enum ECSessionStatus
    {
        [EnumMember]
        NOT_DEFINED = 0,

        [EnumMember]
        OPEN = 1,

        [EnumMember]
        CLOSED = 2
    }
	
    [DataContract(Name = "ECYesNoType")]
    public enum ECYesNo
    {
        [EnumMember]
        OFF = 0,

        [EnumMember]
        ON = 1
    }
}
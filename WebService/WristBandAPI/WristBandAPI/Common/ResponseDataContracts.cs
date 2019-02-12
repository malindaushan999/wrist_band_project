using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace WristBandAPI.Common
{

    /// <summary>
    /// Every response from the service will be this type of information
    /// </summary>
    [DataContract]
    public class CSResponse
    {
        // Result code of the response 
        [DataMember]
        public int ResultCode { get; set; }

        // Result message of the response
        [DataMember]
        public string ResultMessage { get; set; }

        // Exception message if error occurs
        [DataMember]
        public string ExceptionMessage { get; set; }
    }

    /// <summary>
    /// Response message for UserEdit api function
    /// </summary>
    [MessageContract]
    public class UploadFileResponse 
    {
        // Result code of the response 
       [MessageHeader(MustUnderstand = true)]
        public int ResultCode { get; set; }

        // Result message of the response
       [MessageHeader(MustUnderstand = true)]
        public string ResultMessage { get; set; }

        // Exception message if error occurs
        [MessageHeader(MustUnderstand = true)]
        public string ExceptionMessage { get; set; }
        public UploadFileResponse()
        {
        }
    }
}
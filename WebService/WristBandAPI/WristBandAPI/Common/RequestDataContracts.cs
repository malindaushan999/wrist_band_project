using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace WristBandAPI.Common
{

    [DataContract]
    public class Request
    {
        [DataMember]
        public Guid SessionId { get; set; }

        public Request() { }
    }

    [MessageContract]
    public class RemoteFileInfo
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public long Length;

        [MessageBodyMember(Order = 1)]
        public System.IO.Stream FileByteStream;

        [MessageHeader(MustUnderstand = true)]
        public Guid SessionId;

        [MessageHeader(MustUnderstand = true)]
        public string FolderName;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
}
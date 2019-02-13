using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WristBandAPI.Common;

namespace WristBandAPI.Base
{
    
    /// <summary>
    /// Request message for Login api function
    /// </summary>
    [DataContract]
    public class LoginResponse : CSResponse
    {
        [DataMember]
        public User User { get; set; }

        [DataMember]
        public Guid SessionId { get; set; }

        public LoginResponse()
        {
        }
    }

    /// <summary>
    /// Request message for Logout api function
    /// </summary>
    [DataContract]
    public class LogoutResponse : CSResponse
    {
        [DataMember]
        public User User { get; set; }

        [DataMember]
        public Guid SessionId { get; set; }

        public LogoutResponse()
        {
        }
    }

    /// <summary>
    /// Request message for User api function
    /// </summary>
    [DataContract]
    public class RegisterUserResponse : CSResponse
    {
        public RegisterUserResponse()
        {
        }
    }

    /// <summary>
    /// Request message for ForgotPasswordResponse api function
    /// </summary>
    [DataContract]
    public class ForgotPasswordResponseResponse : CSResponse
    {
        [DataMember]
        public string SignupToken { get; set; }
        public ForgotPasswordResponseResponse()
        {
        }
    }

    /// <summary>
    /// Request message for VerifySignUpToken api function
    /// </summary>
    [DataContract]
    public class VerifySignUpTokenResponse : CSResponse
    {
        public VerifySignUpTokenResponse()
        {
        }
    }

    /// <summary>
    /// Request message for ChangePassword api function
    /// </summary>
    [DataContract]
    public class ChangePasswordResponse : CSResponse
    {
        public ChangePasswordResponse()
        {
        }
    }

    #region USER UPDATE RESPONSES
    /// <summary>
    /// Request message for UpdateUser api function
    /// Author: Malinda Ushan
    /// </summary>
    [DataContract]
    public class UpdateUserResponse : CSResponse
    {
        public UpdateUserResponse()
        {
        }
    }

    /// <summary>
    /// Request message for UpdateUserPassword api function
    /// Author: Malinda Ushan
    /// </summary>
    [DataContract]
    public class UpdateUserPasswordResponse : CSResponse
    {
        public UpdateUserPasswordResponse()
        {
        }
    }

    /// <summary>
    /// Request message for VerifyUserAccount api function
    /// </summary>
    [DataContract]
    public class VerifyUserAccountResponse : CSResponse
    {
        public VerifyUserAccountResponse()
        {
        }
    }
    #endregion

    [DataContract]
    public class GetBTDataResponse : CSResponse
    {
        // XXBT table data info list
        [DataMember]
        public List<XXBTData> XXBTDataList { get; set; }

        public GetBTDataResponse()
        {
            XXBTDataList = new List<XXBTData>();
        }
    }
}

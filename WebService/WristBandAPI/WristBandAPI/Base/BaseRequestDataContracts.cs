using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WristBandAPI.Common;

namespace WristBandAPI.Base
{
    
    /// <summary>
    /// Request message for Login api function
    /// </summary>
    [DataContract]
    public class LoginRequest : Request
    {
        // User's name 
        [DataMember]
        public string UserName { get; set; }

        // User's password
        [DataMember]
        public string Password { get; set; }

        public LoginRequest() { }
    }

    /// <summary>
    /// Request message for Logout api function
    /// </summary>
    [DataContract]
    public class LogoutRequest : Request
    {
        // User's name 
        [DataMember]
        public string UserName { get; set; }

        public LogoutRequest() { }
    }

    /// <summary>
    /// Request message for RegisterUser api function
    /// </summary>
    [DataContract]
    public class RegisterUserRequest : Request
    {
        // User's name 
        [DataMember]
        public User User { get; set; }

        public RegisterUserRequest() { }
    }

    /// <summary>
    /// Request message for ForgotPasswordRequest api function
    /// </summary>
    [DataContract]
    public class ForgotPasswordRequestRequest : Request
    {
        // User's name 
        [DataMember]
        public string Email { get; set; }

        public ForgotPasswordRequestRequest() { }
    }

    /// <summary>
    /// Request message for ForgotPasswordRequest api function
    /// </summary>
    [DataContract]
    public class VerifySignUpTokenRequest : Request
    {
        // User's name 
        [DataMember]
        public string Email { get; set; }

        // User's name 
        [DataMember]
        public string SignupToken { get; set; }

        public VerifySignUpTokenRequest() { }
    }

    /// <summary>
    /// Request message for ChangePassword api function
    /// </summary>
    [DataContract]
    public class ChangePasswordRequest : Request
    {
        // Email 
        [DataMember]
        public string Email { get; set; }

        // Sign up token 
        [DataMember]
        public string SignupToken { get; set; }

        // Sign up token 
        [DataMember]
        public string NewPassword { get; set; }

        public ChangePasswordRequest() { }
    }

    #region USER UPDATE REQUESTS
    /// <summary>
    /// Request message for UpdateUser api function
    /// Author: Malinda Ushan
    /// </summary>
    [DataContract]
    public class UpdateUserRequest : Request
    {
        // User's name 
        [DataMember]
        public User User { get; set; }

        public UpdateUserRequest() { }
    }

    /// <summary>
    /// Request message for UpdateUserPassword api function
    /// Author: Malinda Ushan
    /// </summary>
    [DataContract]
    public class UpdateUserPasswordRequest : Request
    {
        // Old Password
        [DataMember]
        public string OldPassword { get; set; }

        // New Password
        [DataMember]
        public string NewPassword { get; set; }

        public UpdateUserPasswordRequest() { }
    }

    /// <summary>
    /// Request message for VerifyUserAccount api function
    /// </summary>
    [DataContract]
    public class VerifyUserAccountRequest : Request
    {
        // Old Password
        [DataMember]
        public string Email { get; set; }

        // New Password
        [DataMember]
        public string SecToken { get; set; }

        public VerifyUserAccountRequest() { }
    }
    #endregion

    /// <summary>
    /// Request message for GetBTData api function
    /// </summary>
    [DataContract]
    public class GetBTDataRequest : Request
    {
        // XXBT table name
        [DataMember]
        public string XXBTName { get; set; }

        public GetBTDataRequest() { }
    }
}
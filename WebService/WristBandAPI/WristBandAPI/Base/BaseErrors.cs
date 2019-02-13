using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WristBandAPI.Base
{
    public static class BaseErrors
    {
        public static class InvalidUserNameOrPassword
        {
            public static readonly int eCode = 1001;
            public static readonly string eMsg = "Invalid User Name or Password";
        }

        public static class UserEmailAlreadyExsits
        {
            public static readonly int eCode = 1002;
            public static readonly string eMsg = "User email is already exsits";
        }

        public static class SignUpTokenNotFound
        {
            public static readonly int eCode = 1003;
            public static readonly string eMsg = "Please request signup token may be expired";
        }

        public static class InvalidSignUpToken
        {
            public static readonly int eCode = 1004;
            public static readonly string eMsg = "Invalid Signup token";
        }

        public static class SignUpTokenExpired
        {
            public static readonly int eCode = 1005;
            public static readonly string eMsg = "Sign up token expired";
        }

        public static class UserEmailNotFound
        {
            public static readonly int eCode = 1006;
            public static readonly string eMsg = "User email not found";
        }

        public static class TempaoryUserAlreadyExsits
        {
            public static readonly int eCode = 1007;
            public static readonly string eMsg = "Yor already registered using this email and please confirm your";
        }

        public static class UserVerfyTokenExpired
        {
            public static readonly int eCode = 1008;
            public static readonly string eMsg = "User verfication token expired.";
        }
    }
}
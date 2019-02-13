using Newtonsoft.Json;
using NLog;
using System;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WristBandAPI.Common
{
    public class CommonUtility
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        // This object is use to lock the session expire time when accessing from defferent threads
        private static object sessionExpirationTimeLocker = new object();
        // This object is use to lock the password hash when accessing from defferent threads
        private static object passwordHashLocker = new object();
        // This object is use to lock the  email character set when accessing from defferent threads
        private static object emailCharacterSetLocker = new object();

        // Session expiration time gap - 30 minutes
        private static int sessionExpireTime = 30;
        public static int accountVerfyExpireTime = 1440;
        public static int SessionExpireTime
        {
            get
            {
                lock (sessionExpirationTimeLocker)
                {
                    return sessionExpireTime;
                }
            }
            set
            {
                lock (sessionExpirationTimeLocker)
                {
                    sessionExpireTime = value;
                }
            }
        }

        // Password is encrypted using this hash key
        private static string passwordHash = "1Gth$5^&JdiopynvjgLL572Lbhdf^42d*32CFdfk5";
        public static string PasswordHash
        {
            get
            {
                lock (passwordHashLocker)
                {
                    return passwordHash;
                }
            }
            set
            {
                lock (passwordHashLocker)
                {
                    passwordHash = value;
                }
            }
        }

        // Email verification key is genarated using this string
        private static string emailCharacterSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
        public static string EmailCharacterSet
        {
            get
            {
                lock (emailCharacterSetLocker)
                {
                    return emailCharacterSet;
                }
            }
            set
            {
                lock (emailCharacterSetLocker)
                {
                    emailCharacterSet = value;
                }
            }
        }

        /// <summary>
        /// This function will check expirity of the current session
        /// </summary>
        /// <param name="currentDateTime">Session created date time</param>
        /// <returns>True - session is expired, False - session not expired</returns>
        public static bool isCurrentSessionIsExpired(DateTime sessionCreatedDatetime)
        {
            TimeSpan sessionExpirationTimePeriod = new TimeSpan(0, SessionExpireTime, 00);
            DateTime sessionExpireTime = sessionCreatedDatetime.Add(sessionExpirationTimePeriod);

            if (DateTime.Compare(DateTime.Now, sessionExpireTime) < 0)
            // If session is valid session
            {
                return false;
            }
            else
            // If session not valid
            {
                return true;
            }
        }

        /// <summary>
        /// This function is use to create a tripple des object
        /// </summary>
        /// <param name="key">Password hash</param>
        /// <returns>TripleDES object</returns>
        public static TripleDES CreateDES(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }

        /// <summary>
        /// This function is use to create encrypted string
        /// </summary>
        /// <param name="plainText">Text you want to encrypt</param>
        /// <param name="hash">Password hash</param>
        /// <returns>Encrypted string</returns>
        public static string EncryptString(string plainText, string hash)
        {
            // Convert plain text into byte array
            byte[] plainTextBytes = Encoding.Unicode.GetBytes(plainText);
            // Use a memory stream to hold the bytes
            MemoryStream ms = new MemoryStream();
            // Create the key and initialize vector using the password
            TripleDES des = CreateDES(hash);
            // Create the encoder that will write memory stream
            CryptoStream cryptStream = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cryptStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptStream.FlushFinalBlock();
            // Return encrypted string
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// This function is use to decrypted a encrypted string
        /// </summary>
        /// <param name="encryptedText">Encrypted text</param>
        /// <param name="hash">Password hash</param>
        /// <returns>Decrypted string</returns>
        public static string DecryptString(string encryptedText, string hash)
        {
            // Convert encrypted string to byte array
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
            // Create memory stream to hold the bytes
            MemoryStream ms = new MemoryStream();
            // Create the key and initialize vector using the password
            TripleDES des = CreateDES(hash);
            // Create the decoder that will write memory stream
            CryptoStream decryptStream = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            decryptStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
            decryptStream.FlushFinalBlock();
            // Return decrypted string
            return Encoding.Unicode.GetString(ms.ToArray());
        }

        /// <summary>
        /// This function is use to genarate the email verification key
        /// </summary>
        /// <returns>Email verification key</returns>
        public static string GetEmailVerificationKey()
        {
            // Responsible for create log details
            Logger logger = LogManager.GetCurrentClassLogger();

            try
            // Try to genarate email verification key
            {
                // Default size of the verification key is 6 chars
                Random random = new Random();
                return new string(Enumerable.Repeat(EmailCharacterSet, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            }
            catch (Exception ex)
            // Exception is occured
            {
                logger.Trace(ex.InnerException);
                logger.Trace(ex.StackTrace);
                logger.Trace(ex.Message);
                return null;
            }
        }

        public static Guid getGUID()
        {
            Guid guid = Guid.NewGuid();
            return guid;

        }

        public static void writeErrorLog(string funcName, CSResponse res, Exception ex, Logger logger)
        {
            logger.Error("{0} [NG]=>[CODE:{1}][MSG:{2}]", funcName, res.ResultCode, res.ResultMessage);
            if (ex != null)
            {
                logger.Error(ex.StackTrace);
                logger.Error(ex.InnerException);
            }
        }

        public static string ToJson(object value)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented, settings);
        }

        // this function is uesd to check Entity framework validation error
        // error like this Eg:Validation failed for one or more entities. See 'EntityValidationErrors' property for more details

        public static void checkVlidationErrors(Exception ex)
        {
            DbEntityValidationException exv = (DbEntityValidationException)ex;
            foreach (var eve in exv.EntityValidationErrors)
            {
                logger.Debug("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    logger.Debug("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"", ve.PropertyName, eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName), ve.ErrorMessage);
                }
            }
        }

        //public static user GetUserInfoBySessionId(string sessionId, KuurakuEntities context)
        //{
        //    login_session logInfo = context.login_session.Where(w => w.session_id == sessionId && w.session_status_id == (short)ECSessionStatus.OPEN).FirstOrDefault();
        //    if (logInfo != null)
        //    {
        //        if (logInfo.user_type_id == (short)EBUserType.USER)
        //        {
        //            return logInfo.user;
        //        }
        //        else if (logInfo.user_type_id == (short)EBUserType.SYS_USER)
        //        {
        //            user sysUserInfo = new user();
        //            sysUserInfo.email = logInfo.sys_user.user_name;
        //            sysUserInfo.user_id = logInfo.sys_user_id.Value;
        //            sysUserInfo.user_type = (short)EBUserType.SYS_USER;
        //            return sysUserInfo;
        //        }
        //    }

        //    return null;
        //}
    }

}
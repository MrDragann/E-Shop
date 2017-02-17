using IServices;
using IServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Numerics;
using System.Globalization;
using Shop.Infrastructura.Extensions;
using System.Net.Mail;

namespace Shop.Infrastructura
{
    public class WebUser
    {
        private static IMainServices Services = DependencyResolver.Current.GetService<IMainServices>();

        public static ModelUser CurrentUser
        {
            get
            {
                if (!(HttpContext.Current.Session["user"] is ModelUser))
                {

                    var data = HttpContext.Current.Request.Cookies["data"];
                    if (data == null || string.IsNullOrWhiteSpace(data.Value))
                    {
                        return new ModelUser();
                    }
                    else
                    {
                        var model = Decrypt(data.Value);
                        if (model != null)
                            Login(model.UserName, model.Password);
                        else return new ModelUser();
                    }
                }
                return HttpContext.Current.Session["user"] as ModelUser;
            }
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
        }

        public static void Login(string userName, string password, bool remember = false)
        {
            if (Services.Users.Login(userName, password))
            {
                CurrentUser = new ModelUser { UserName = userName, IsAuth = true, Password = password  };
                if (remember) HttpContext.Current.Response.Cookies.Add(new HttpCookie("data") { Value = Encrypt(CurrentUser), Expires = DateTime.Now.AddDays(1) });
            }
            
        }

        public static string Register(string userName, string email, string password)
        {
            var salt = GetSalt();
            Services.Register.Register(userName, email, password.GetHashString(), salt);
            salt = EncryptSalt(salt);
            return salt;
        }

        public static void Confrimed(string salt, string userName)
        {
            var decrSalt = DecryptSalt(salt);
            Services.Register.ConfrimedEmail(decrSalt, userName);
        }

        public static void LogOff()
        {
            HttpContext.Current.Session.Remove("user");
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("data") { Expires = DateTime.Now.AddDays(-1) });
        }

        public static bool CheckRole(int id, string role)
        {
            return (Services.Users.CheckRole(id, role));
        }

        public static void SendMail(string subject, string email, string body)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(email);
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
        }

        #region Криптография

        static byte[] key = Encoding.UTF8.GetBytes("Some salt value0Some salt value0");

        static byte[] IV = Encoding.UTF8.GetBytes("Some salt value0");


        private static string Encrypt(ModelUser model)
        {
            using (Aes myAes = Aes.Create())
            {
                myAes.Key = key;
                myAes.IV = IV;
                byte[] encrypted = EncryptStringToBytes_Aes($"{model.UserName},{model.Password}",myAes.Key, myAes.IV);
                return new BigInteger(encrypted).ToString("x2");
            }
        }

        private static ModelUser Decrypt(string encrypted)
        {
            using (Aes myAes = Aes.Create())
            {
                try
                {
                    myAes.Key = key;
                    myAes.IV = IV;
                    var number = BigInteger.Parse(encrypted, NumberStyles.HexNumber);
                    string roundtrip = DecryptStringFromBytes_Aes(number.ToByteArray(), myAes.Key, myAes.IV);
                    var mas = roundtrip.Split(',');
                    var model = new ModelUser() { UserName = mas[0], Password = mas[1] };
                    return model;
                }catch(Exception ex)
                {
                    return null;
                }
            }
        }

        private static string EncryptSalt(string salt)
        {
            using (Aes myAes = Aes.Create())
            {
                myAes.Key = key;
                myAes.IV = IV;
                byte[] encrypted = EncryptStringToBytes_Aes($"{salt}", myAes.Key, myAes.IV);
                return new BigInteger(encrypted).ToString("x2");
            }
        }

        private static string DecryptSalt(string encrypted)
        {
            using (Aes myAes = Aes.Create())
            {
                try
                {
                    myAes.Key = key;
                    myAes.IV = IV;
                    var number = BigInteger.Parse(encrypted, NumberStyles.HexNumber);
                    string salt = DecryptStringFromBytes_Aes(number.ToByteArray(), myAes.Key, myAes.IV);
                    return salt;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        public static string GetSalt()
        {
            var random = new RNGCryptoServiceProvider();

            // Максимальная длина соли
            int max_length = 32;

            // Empty salt array
            byte[] salt = new byte[max_length];

            // Build the random bytes
            random.GetNonZeroBytes(salt);

            // Return the string encoded salt
            return Convert.ToBase64String(salt);
        }
        #endregion
    }
}
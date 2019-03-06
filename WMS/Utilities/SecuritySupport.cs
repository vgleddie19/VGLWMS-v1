using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Framework
{
    public  static class SecuritySupport
    {
        static string PasswordHash = "cfsSc&@";
        static string SaltKey = "S@sTsKEYd";
        static string VIKey = "@bcdc3D4adv6d7H8";
     
        public static string GetSHA1Digest(string message)
        {


            try
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                System.Security.Cryptography.SHA1 sha1 = new
                System.Security.Cryptography.SHA1CryptoServiceProvider();
                byte[] result = sha1.ComputeHash(data);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < result.Length; i++)
                    sb.Append(result[i].ToString("X2"));
                return sb.ToString().ToLower();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string Encrypt(this string plainText)
        {
            plainText = plainText.Replace("'", "");
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(this string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };
           
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray()).Split(new String[]{"'"}, StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }
}
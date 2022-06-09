using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GetSiteAccessIP.Models
{
    public class CommonUtility
    {
        public static string DecryptString(string sourceString, string password)
        {
            try
            {
                //Create a RijndaelManaged object
                RijndaelManaged rijndael = new RijndaelManaged();

                // Create shared key and initialization vector from password
                byte[] key = null;
                byte[] iv = null;

                CommonUtility.GenerateKeyFromPassword(password, rijndael.KeySize, ref key, rijndael.BlockSize, ref iv);
                rijndael.Key = key;
                rijndael.IV = iv;

                //Return a string to a byte array
                byte[] strBytes = Convert.FromBase64String(sourceString);

                // Creating a symmetric encrypted object
                ICryptoTransform decryptor = rijndael.CreateDecryptor();

                // Decrypting a byte array An exception CryptographicException occurs if decoding fails
                byte[] decBytes = decryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);

                // close up
                decryptor.Dispose();

                // Returns a byte array back to a string
                return System.Text.Encoding.UTF8.GetString(decBytes);

              
            }
            catch (FormatException)
            {
                return sourceString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void GenerateKeyFromPassword(string password, int keySize, ref byte[] key, int blockSize, ref byte[] iv)
        {
            // Create a shared key and initialization vector from the password
            byte[] salt = Encoding.UTF8.GetBytes("must be 8 bytes or more");

            //Create an Rfc2898DeriveBytes object
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, salt);

            //Specify the number of iterations 1000 times by default
            deriveBytes.IterationCount = 1000;

            //Generate shared key and initialization vector
            key = deriveBytes.GetBytes(keySize / 8);
            iv = deriveBytes.GetBytes(blockSize / 8);
        }

        public static string EncryptString(string sourceString, string password)
        {
            // Create rijndaelManaged object
            var rijndael = new RijndaelManaged();

            // Create shared key and initialization vector from password
            byte[] key = null;
            byte[] iv = null;

            CommonUtility.GenerateKeyFromPassword(password, rijndael.KeySize, ref key, rijndael.BlockSize, ref iv);
            rijndael.Key = key;
            rijndael.IV = iv;

            // Convert a string to a byte array
            byte[] strBytes = Encoding.UTF8.GetBytes(sourceString);

            // Creating a symmetric encrypted object
            ICryptoTransform encryptor = rijndael.CreateEncryptor();

            // Encrypt byte array
            byte[] encBytes = encryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);

            // close up
            encryptor.Dispose();

            // Converts a byte array to a string and returns it
            return Convert.ToBase64String(encBytes);
        }

        public class ViewDataParam
        {
            /// <summary>画面タイトル</summary>
            public const string Title = "Title";

            /// <summary>画面ID</summary>
            public const string ScreenId = "ScreenId";

            /// <summary>サーバエラーのメッセージ</summary>
            public const string ErrorMessage = "ErrorMessage";
        }
    }

}
using System.Security.Cryptography;
using System.Text;

namespace MauiBlazorNote.Library
{
    public class AesCryptography
    {
        private static byte[] _solt = { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
        private static int _iterations = 128;
        private static HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA256;


        public static string GetEncrypt(string planeText, string userKey)
        {
            string encryptText = "";

            if (!string.IsNullOrEmpty(planeText) && !string.IsNullOrEmpty(userKey))
            {
                encryptText = Encrypt(planeText, userKey, _solt, _iterations, _hashAlgorithm);
            }

            return encryptText;
        }

        public static string GetDecrypt(string cipherText, string userKey)
        {
            string decryptText = "";

            if (!string.IsNullOrEmpty(cipherText) && !string.IsNullOrEmpty(userKey))
            {
                decryptText = Decrypt(cipherText, userKey, _solt, _iterations, _hashAlgorithm);
            }

            return decryptText;
        }

        private static string Encrypt(string clearText, string key, byte[] salt, int iteration, HashAlgorithmName hasAlgorithonName)
        {
            string encryptionKey = key;
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, salt, iteration, hasAlgorithonName);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private static string Decrypt(string cipherText, string key, byte[] salt, int iteration, HashAlgorithmName hasAlgorithonName)
        {
            string encryptionKey = key;
            byte[] cipherBytes = null;
            string error = null;

            try
            {
                cipherBytes = Convert.FromBase64String(cipherText);
            }
            catch (Exception ex)
            {
                if (ex != null)
                    error = "Please enter correct decrypt text...";
            }

            if (cipherBytes != null)
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, salt, iteration, hasAlgorithonName);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            try
                            {
                                cs.Write(cipherBytes, 0, cipherBytes.Length);
                                cs.Close();
                            }
                            catch (Exception ex)
                            {
                                if (ex != null)
                                    error = "Please enter correct password...";
                            }
                        }

                        if (error == null)
                            cipherText = Encoding.Unicode.GetString(ms.ToArray());
                        else
                            cipherText = error;
                    }
                }
            }
            else
            {
                cipherText = error;
            }

            return cipherText;
        }
    }
}
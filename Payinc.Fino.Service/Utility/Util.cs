using Payinc.Fino.Service.Model;
using RestSharp;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Payinc.Fino.Service.Utility
{
    public class Util
    {
        #region HTTP GET/POST METHOD

        public string HttpGet(string path, string getParamter)
        {
            string response = null;
            getParamter = OpenSSLEncrypt(getParamter, Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
            var authenticationReq = new AuthenticationReq() { AuthKey = Startup.AppSetting[AppSettings.FINO_AUTHKEY_KEY], PartnerID = Startup.AppSetting[AppSettings.FINO_PARTNERID] };
            string getAuthenticationHeader = OpenSSLEncrypt(JsonConvert.SerializeObject(authenticationReq), Startup.AppSetting[AppSettings.HEADER_ENCRYPTION_KEY]);
            try
            {
                var client = new RestClient(path + "?" + getParamter);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authentication", getAuthenticationHeader);
                request.AddJsonBody(string.Empty);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                IRestResponse iRestResponse = client.Execute(request);

                #region CREATE LOGGER
                if (Convert.ToString(Startup.AppSetting[AppSettings.IS_LOG]) == "1")
                {
                    Logger.Debug("Request " + path + "?" + getParamter);
                    Logger.Debug("Response " + iRestResponse.Content);
                }
                #endregion

                response = iRestResponse.Content;
            }
            catch (Exception ex) { response = ex.Message; }
            return response;
        }
        public string HttpPost(string path)
        {
            string response = null;
            var authenticationReq = new AuthenticationReq() { AuthKey = Startup.AppSetting[AppSettings.FINO_AUTHKEY_KEY], PartnerID = Startup.AppSetting[AppSettings.FINO_PARTNERID] };
            string getAuthenticationHeader = OpenSSLEncrypt(JsonConvert.SerializeObject(authenticationReq), Startup.AppSetting[AppSettings.HEADER_ENCRYPTION_KEY]);
            try
            {
                var client = new RestClient(path);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authentication", getAuthenticationHeader);
                request.AddJsonBody(string.Empty);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                IRestResponse iRestResponse = client.Execute(request);

                #region CREATE LOGGER
                if (Convert.ToString(Startup.AppSetting[AppSettings.IS_LOG]) == "1")
                {
                    Logger.Debug("Request " + path);
                    Logger.Debug("Response " + iRestResponse.Content);
                }
                #endregion

                response = iRestResponse.Content;
            }
            catch (Exception ex) { response = ex.Message; }
            return response;
        }
        public string HttpPostWithPara(string path, string payLoad)
        {
            string response = null;
            #region CREATE LOGGER
            if (Convert.ToString(Startup.AppSetting[AppSettings.IS_LOG]) == "1")
            {
                Logger.Debug("Plant Text payLoad: " + payLoad);
            }
            #endregion

            payLoad = OpenSSLEncrypt(payLoad, Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
            #region CREATE LOGGER
            if (Convert.ToString(Startup.AppSetting[AppSettings.IS_LOG]) == "1")
            {
                Logger.Debug("BODY_ENCRYPTION_KEY: " + Startup.AppSetting[AppSettings.BODY_ENCRYPTION_KEY]);
                Logger.Debug("Encrypted payLoad: " + payLoad);
            }
            #endregion

            var authenticationReq = new AuthenticationReq() { AuthKey = Startup.AppSetting[AppSettings.FINO_AUTHKEY_KEY], PartnerID = Startup.AppSetting[AppSettings.FINO_PARTNERID] };

            #region CREATE LOGGER
            if (Convert.ToString(Startup.AppSetting[AppSettings.IS_LOG]) == "1")
            {
                Logger.Debug("Plant Text Authentication: " + JsonConvert.SerializeObject(authenticationReq));
            }
            #endregion

            string getAuthenticationHeader = OpenSSLEncrypt(JsonConvert.SerializeObject(authenticationReq), Startup.AppSetting[AppSettings.HEADER_ENCRYPTION_KEY]);

            #region CREATE LOGGER
            if (Convert.ToString(Startup.AppSetting[AppSettings.IS_LOG]) == "1")
            {
                Logger.Debug("HEADER_ENCRYPTION_KEY: " + Startup.AppSetting[AppSettings.HEADER_ENCRYPTION_KEY]);
                Logger.Debug("Encrypted Authentication: " + getAuthenticationHeader);
            }
            #endregion

            try
            {
                var client = new RestClient(path);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authentication", getAuthenticationHeader);
                request.AddJsonBody(payLoad);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                IRestResponse iRestResponse = client.Execute(request);

                #region CREATE LOGGER
                if (Convert.ToString(Startup.AppSetting[AppSettings.IS_LOG]) == "1")
                {
                    Logger.Debug("Final Request: " + path + "||" + payLoad);
                    Logger.Debug("Final Response: " + iRestResponse.Content);
                }
                #endregion

                response = iRestResponse.Content;
            }
            catch (Exception ex) { response = ex.Message; }
            return response;
        }
        #endregion

        #region AES ENCRYPTION/DECRYPTION
        public string OpenSSLEncrypt(string plainText, string passphrase, Int32 KeySize = 256)
        {
            // generate salt
            byte[] key, iv;
            byte[] salt = new byte[8];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(salt);
            DeriveKeyAndIV(passphrase, salt, out key, out iv);
            // encrypt bytes
            byte[] encryptedBytes = EncryptStringToBytesAes(plainText, key, iv, KeySize);
            // add salt as first 8 bytes
            byte[] encryptedBytesWithSalt = new byte[salt.Length + encryptedBytes.Length + 8];
            Buffer.BlockCopy(Encoding.ASCII.GetBytes("Salted__"), 0, encryptedBytesWithSalt, 0, 8);
            Buffer.BlockCopy(salt, 0, encryptedBytesWithSalt, 8, salt.Length);
            Buffer.BlockCopy(encryptedBytes, 0, encryptedBytesWithSalt, salt.Length + 8, encryptedBytes.Length);
            // base64 encode
            return Convert.ToBase64String(encryptedBytesWithSalt);
        }
        public string OpenSSLDecrypt(string encrypted, string passphrase, Int32 KeySize = 256)
        {
            // base 64 decode
            byte[] encryptedBytesWithSalt = Convert.FromBase64String(encrypted);
            // extract salt (first 8 bytes of encrypted)
            byte[] salt = new byte[8];
            byte[] encryptedBytes = new byte[encryptedBytesWithSalt.Length - salt.Length - 8];
            Buffer.BlockCopy(encryptedBytesWithSalt, 8, salt, 0, salt.Length);
            Buffer.BlockCopy(encryptedBytesWithSalt, salt.Length + 8, encryptedBytes, 0, encryptedBytes.Length);
            // get key and iv
            byte[] key, iv;
            DeriveKeyAndIV(passphrase, salt, out key, out iv);
            return DecryptStringFromBytesAes(encryptedBytes, key, iv, KeySize);
        }
        private void DeriveKeyAndIV(string passphrase, byte[] salt, out byte[] key, out byte[] iv)
        {
            // generate key and iv
            List<byte> concatenatedHashes = new List<byte>(48);

            byte[] password = Encoding.UTF8.GetBytes(passphrase);
            byte[] currentHash = new byte[0];
            MD5 md5 = MD5.Create();
            bool enoughBytesForKey = false;
            // See http://www.openssl.org/docs/crypto/EVP_BytesToKey.html#KEY_DERIVATION_ALGORITHM
            while (!enoughBytesForKey)
            {
                int preHashLength = currentHash.Length + password.Length + salt.Length;
                byte[] preHash = new byte[preHashLength];

                Buffer.BlockCopy(currentHash, 0, preHash, 0, currentHash.Length);
                Buffer.BlockCopy(password, 0, preHash, currentHash.Length, password.Length);
                Buffer.BlockCopy(salt, 0, preHash, currentHash.Length + password.Length, salt.Length);

                currentHash = md5.ComputeHash(preHash);
                concatenatedHashes.AddRange(currentHash);

                if (concatenatedHashes.Count >= 48)
                    enoughBytesForKey = true;
            }

            key = new byte[32];
            iv = new byte[16];
            concatenatedHashes.CopyTo(0, key, 0, 32);
            concatenatedHashes.CopyTo(32, iv, 0, 16);

            md5.Clear();
            md5 = null;
        }
        public byte[] EncryptStringToBytesAes(string plainText, byte[] key, byte[] iv, Int32 KeySize = 256)
        {
            Int32 blockSize = 128;
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("iv");

            // Declare the stream used to encrypt to an in memory
            // array of bytes.
            MemoryStream msEncrypt;

            // Declare the RijndaelManaged object
            // used to encrypt the data.
            RijndaelManaged aesAlg = null;
            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged { Mode = CipherMode.CBC, KeySize = KeySize, BlockSize = blockSize, Key = key, IV = iv };

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                msEncrypt = new MemoryStream();
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                        swEncrypt.Flush();
                        swEncrypt.Close();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }
            // Return the encrypted bytes from the memory stream.
            return msEncrypt.ToArray();
        }
        public string DecryptStringFromBytesAes(byte[] cipherText, byte[] key, byte[] iv, Int32 KeySize = 256)
        {
            Int32 blockSize = 128;
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("iv");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext;
            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged { Mode = CipherMode.CBC, KeySize = KeySize, BlockSize = blockSize, Key = key, IV = iv };

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
                            srDecrypt.Close();
                        }
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class SafeHandler : ISafeHandler
    {
        #region Hash

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string HashPasswordWithSalt(string password, string salt)
        {
            //Convert password to byte array in UTF8 format allowing the use of special characters
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            //Hash the byte array with SHA512 512 bits
            byte[] hashedPassword = SHA512.Create()
                .ComputeHash(Combine(passwordBytes, saltBytes));

            //Return the Hashed password as a string
            return Convert.ToBase64String(hashedPassword);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GenerateSalt()
        {
            const int saltLength = 32;

            using RandomNumberGenerator numberGenerator = RandomNumberGenerator.Create();
            byte[] randomNumber = new byte[saltLength];
            numberGenerator.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        #endregion

        #region Encryption
        private string iv { get; set; } = "HR$2pIjHR$2pIj12";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public byte[] GenerateRandomKey(int length)
        {
            using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] randomNumber = new byte[length];
            randomNumberGenerator.GetBytes(randomNumber);

            return randomNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataToEncrypt"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public byte[] Encrypt(string dataToEncrypt, string key)
        {
            using Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            aes.Key = Convert.FromBase64String(key);

            byte[] data = Encoding.UTF8.GetBytes(dataToEncrypt);
            byte[] Vector = Encoding.UTF8.GetBytes(iv);

            return aes.EncryptCbc(data, Vector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataToDecrypt"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public byte[] Decrypt(string dataToDecrypt, string key)
        {
            using Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            aes.Key = Convert.FromBase64String(key);

            
            return aes.DecryptCbc(Convert.FromBase64String(dataToDecrypt), Encoding.UTF8.GetBytes(iv));
        }

        #endregion

    }
}

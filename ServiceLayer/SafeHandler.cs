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
        /// Hash the given <paramref name="password"/> with the given <paramref name="salt"/>
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns><see cref="string"/> <paramref name="password"/></returns>
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
        /// Combine the given <paramref name="first"/> <see cref="byte"/>[] with the given <paramref name="second"/> <see cref="byte"/>[]
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Combined <see cref="byte"/>[]</returns>
        public byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

        /// <summary>
        /// Generate a random number used as a salt
        /// </summary>
        /// <returns><see cref="string"/> salt</returns>
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
        /// Create a random key with the given <paramref name="length"/> in the form: <see cref="byte"/>[]
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
        /// Encrypt the given <paramref name="dataToEncrypt"/> with the given random <paramref name="key"/>
        /// </summary>
        /// <param name="dataToEncrypt"></param>
        /// <param name="key"></param>
        /// <returns>Encrypted <see cref="byte"/>[]</returns>
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
        /// Decrypt the given <paramref name="dataToDecrypt"/> with the given <paramref name="key"/>
        /// </summary>
        /// <param name="dataToDecrypt"></param>
        /// <param name="key"></param>
        /// <returns>Decrypted <see cref="byte"/>[]</returns>
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

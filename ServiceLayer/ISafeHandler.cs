using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface ISafeHandler
    {
        #region Hash

        /// <summary>
        /// Hash the given <paramref name="password"/> with the given <paramref name="salt"/>
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns><see cref="string"/> <paramref name="password"/></returns>
        public string HashPasswordWithSalt(string password, string salt);

        /// <summary>
        /// Combine the given <paramref name="first"/> <see cref="byte"/>[] with the given <paramref name="second"/> <see cref="byte"/>[]
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Combined <see cref="byte"/>[]</returns>
        public byte[] Combine(byte[] first, byte[] second);

        /// <summary>
        /// Generate a random number used as a salt
        /// </summary>
        /// <returns><see cref="string"/> salt</returns>
        public string GenerateSalt();

        #endregion

        #region Encryption

        /// <summary>
        /// Create a random key with the given <paramref name="length"/> in the form: <see cref="byte"/>[]
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public byte[] GenerateRandomKey(int length);

        /// <summary>
        /// Encrypt the given <paramref name="dataToEncrypt"/> with the given random <paramref name="key"/>
        /// </summary>
        /// <param name="dataToEncrypt"></param>
        /// <param name="key"></param>
        /// <returns>Encrypted <see cref="byte"/>[]</returns>
        public byte[] Encrypt(string dataToEncrypt, string key);

        /// <summary>
        /// Decrypt the given <paramref name="dataToDecrypt"/> with the given <paramref name="key"/>
        /// </summary>
        /// <param name="dataToDecrypt"></param>
        /// <param name="key"></param>
        /// <returns>Decrypted <see cref="byte"/>[]</returns>
        public byte[] Decrypt(string dataToDecrypt, string key);

        #endregion
    }
}

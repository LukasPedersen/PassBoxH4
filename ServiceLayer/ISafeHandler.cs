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

        public string HashPasswordWithSalt(string password, string salt);

        public byte[] Combine(byte[] first, byte[] second);

        public string GenerateSalt();

        #endregion

        #region Encryption

        public byte[] GenerateRandomKey(int length);

        public byte[] Encrypt(string dataToEncrypt, string key);

        public byte[] Decrypt(string dataToDecrypt, string key);

        #endregion
    }
}

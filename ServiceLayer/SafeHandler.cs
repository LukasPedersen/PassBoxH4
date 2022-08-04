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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string HashPasswordWithSalt(string password, string salt)
        {
            //Convert password to byte array in UTF8 format allowing the use of special characters
            byte[] data = Encoding.UTF8.GetBytes(password);

            //Hash the byte array with SHA512 512 bits
            byte[] hashedPassword = SHA512.Create()
                .ComputeHash(Combine(Convert.FromBase64String(password), Convert.FromBase64String(salt)));

            //Return the Hashed password as a string
            return Convert.ToBase64String(hashedPassword);
        }

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
    }
}

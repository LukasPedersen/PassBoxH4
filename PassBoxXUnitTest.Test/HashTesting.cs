using System;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace PassBoxXUnitTest.Test
{
    public class PassBoxXUnitTest
    {
        [Theory]
        [InlineData("123", "FrKwVvKrYlpI8wgqnzrK25qjgwPzeT1d3rRe72jBXcA=")]
        public void HashPassword(string password, string salt)
        {
            //SETUP
            //Convert password to byte array in UTF8 format allowing the use of special characters
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            //ATTEMPT
            //Hash the byte array with SHA512 512 bits
            byte[] hashedPassword = SHA512.Create()
                .ComputeHash(Combine(passwordBytes, saltBytes));

            //VERIFY
            //Return the Hashed password as a string
            Assert.Equal("vcEf6WNhyDbiENs1CDWlZ6cExvMxNzxRB0be5W4+RMC35fpLwQEPSKRT8pfGc36pKFZAa/jVYF6a5Cmz3ovtgw==", Convert.ToBase64String(hashedPassword));
        }

        public byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }
    }
}

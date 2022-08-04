using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface ISafeHandler
    {
        public string HashPasswordWithSalt(string password, string salt);

        public byte[] Combine(byte[] first, byte[] second);

        public string GenerateSalt();
    }
}

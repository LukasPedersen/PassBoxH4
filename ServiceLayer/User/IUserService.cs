using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IUserService
    {
        public void CreateUser();

        public void UpdateUser();

        public void DeleteUser();

        public bool Login();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IUserService
    {
        public void CreateUser(string username, string hashedPassword, string personalSalt);

        public void UpdateUser();

        public void DeleteUser();

        public bool Login(string username, string password);

        public string GetUserSalt(string username);
        public string GetCurrentUsername();

        public bool Logout();

        public bool CheckIfLoggedIn();
    }
}

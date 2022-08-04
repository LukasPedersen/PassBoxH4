using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserService : IUserService
    {
        public User? CurrentUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void CreateUser()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateUser()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteUser()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Login()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Logout()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckIfLoggedIn()
        {
            if (CurrentUser == null)
            {
                return false;
            }
            else
                return true;
        }

        
    }
}

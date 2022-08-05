using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user given the <paramref name="username"/>, <paramref name="hashedPassword"/>, <paramref name="personalSalt"/>, parameters
        /// </summary>
        public void CreateUser(string username, string hashedPassword, string personalSalt);

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateUser();

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteUser();

        /// <summary>
        /// Will try to login the <see cref="User"/> with the given <paramref name="username"/> <see langword="and"/> <paramref name="hashedPassword"/>
        /// </summary>
        /// <returns><see langword="true"/> if logedin else <see langword="false"/></returns>
        public bool Login(string username, string password);

        /// <summary>
        /// Gets users <see langword="salt"/> by the given <paramref name="username"/>
        /// </summary>
        /// <param name="username"></param>
        /// <returns><see cref="string"/> contaning <see cref="User"/>'s <see langword="salt"/></returns>
        public string GetUserSalt(string username);

        /// <summary>
        /// Gets <see cref="CurrentUser"/>'s <see cref="User.Username"/>
        /// </summary>
        /// <returns><see cref="CurrentUser"/>'s <see cref="User.Username"/></returns>
        public string GetCurrentUsername();

        /// <summary>
        /// Gets the current <see cref="CurrentUser"/> <see langword="object"/>
        /// </summary>
        /// <returns><see cref="User"/> CurrentUser</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public User GetCurrentUser();

        /// <summary>
        /// Logout current user
        /// </summary>
        /// <returns></returns>
        public bool Logout();

        /// <summary>
        /// Check if <see cref="CurrentUser"/> is <see langword="null"/>
        /// </summary>
        /// <returns><see langword="true"/> if <see cref="CurrentUser"/> != <see langword="null"/> else return <see langword="false"/></returns>
        public bool CheckIfLoggedIn();
    }
}

using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer
{
    public class PasswordService : IPasswordService
    {
        private readonly PassBoxContext _PassBoxContext;

        public PasswordService(PassBoxContext passBoxContext)
        {
            _PassBoxContext = passBoxContext;
        }

        /// <summary>
        /// Add a new <see cref="Password"/> "website" to <see cref="_PassBoxContext"/> and save changes 
        /// </summary>
        public void AddWebsite(string website, string username, string password, string key, User user)
        {
            _PassBoxContext.Passwords.Add(new Password
            {
                Website = website,
                Username = username,
                Pass = password,
                Key = key,
                User = user
            });
            _PassBoxContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateWebsite()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteWebsite()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all <see cref="Password"/> a user has by the given <paramref name="userID"/>
        /// </summary>
        /// <param name="userID"></param>
        /// <returns><see cref="List{T}"/> contaning <see cref="Password"/></returns>
        public List<Password> GetAllPasswords(int userID)
        {
            return _PassBoxContext.Passwords.Where(p => p.User.Id == userID).ToList();
        }

        /// <summary>
        /// Gets the <see cref="Password"/> for a specific website buy the given <paramref name="website"/>
        /// </summary>
        /// <param name="website"></param>
        /// <returns><see cref="Password"/> <see langword="object"/></returns>
        public Password GetPassword(string website)
        {
            return _PassBoxContext.Passwords.Where(p => p.Website == website).First();
        }

        /// <summary>
        /// Gets the given key for a specific <paramref name="website"/>
        /// </summary>
        /// <param name="website"></param>
        /// <returns><see cref="string"/> key</returns>
        public string GetKey(string website)
        {
            return _PassBoxContext.Passwords.Where(p => p.Website == website).First().Key;
        }
    }
}

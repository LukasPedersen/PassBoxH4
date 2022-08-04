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
        /// 
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
        public void UpdateWebsite()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteWebsite()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public List<Password> GetAllPasswords(int userID)
        {
            return _PassBoxContext.Passwords.Where(p => p.User.Id == userID).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="webwite"></param>
        public Password GetPassword(string website)
        {
            return _PassBoxContext.Passwords.Where(p => p.Website == website).First();
        }

        public string GetKey(string website)
        {
            return _PassBoxContext.Passwords.Where(p => p.Website == website).First().Key;
        }
    }
}

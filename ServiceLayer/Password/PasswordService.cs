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
        public void AddWebsite()
        {

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
        public List<Password> GetAllPasswords()
        {
            return _PassBoxContext.Passwords.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="webwite"></param>
        public Password GetPassword(string website)
        {
            return _PassBoxContext.Passwords.Where(p => p.Website == website).First();
        }
    }
}

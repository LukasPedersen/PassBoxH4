using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IPasswordService
    {
        #region Website

        /// <summary>
        /// 
        /// </summary>
        public void AddWebsite(string website, string username, string password, string key, User user);

        /// <summary>
        /// 
        /// </summary>
        public void UpdateWebsite();

        /// <summary>
        /// 
        /// </summary>
        public void DeleteWebsite();

        public List<Password> GetAllPasswords(int userID);

        public Password GetPassword(string website);

        public string GetKey(string website);

        #endregion
    }
}

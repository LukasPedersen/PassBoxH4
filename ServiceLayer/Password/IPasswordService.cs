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
        /// Add a new <see cref="Password"/> "website" to <see cref="_PassBoxContext"/> and save changes 
        /// </summary>
        public void AddWebsite(string website, string username, string password, string key, User user);

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateWebsite();

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteWebsite();

        /// <summary>
        /// Gets all <see cref="Password"/> a user has by the given <paramref name="userID"/>
        /// </summary>
        /// <param name="userID"></param>
        /// <returns><see cref="List{T}"/> contaning <see cref="Password"/></returns>
        public List<Password> GetAllPasswords(int userID);

        /// <summary>
        /// Gets the <see cref="Password"/> for a specific website buy the given <paramref name="website"/>
        /// </summary>
        /// <param name="website"></param>
        /// <returns><see cref="Password"/> <see langword="object"/></returns>
        public Password GetPassword(string website);

        /// <summary>
        /// Gets the given key for a specific <paramref name="website"/>
        /// </summary>
        /// <param name="website"></param>
        /// <returns><see cref="string"/> key</returns>
        public string GetKey(string website);

        #endregion
    }
}

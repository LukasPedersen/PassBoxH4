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
        public void AddWebsite();

        /// <summary>
        /// 
        /// </summary>
        public void UpdateWebsite();

        /// <summary>
        /// 
        /// </summary>
        public void DeleteWebsite();

        public List<Password> GetAllPasswords();

        public Password GetPassword(string website);

        #endregion
    }
}

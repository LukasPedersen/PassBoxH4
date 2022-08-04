using DataLayer;
using DataLayer.Models;


namespace ServiceLayer
{
    public class UserService : IUserService
    {
        private readonly PassBoxContext _PassBoxContext;

        public UserService(PassBoxContext passBoxContext)
        {
            _PassBoxContext = passBoxContext;
        }

        public User? CurrentUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void CreateUser(string username, string hashedPassword, string personalSalt)
        {
            _PassBoxContext.Users.Add(new User
            {
                Username = username,
                Password = hashedPassword,
                PersonalSalt = personalSalt
            }); ;
            _PassBoxContext.SaveChanges();
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
        public bool Login(string username, string hashedPassword)
        {
            User user = _PassBoxContext.Users.Where(x => x.Username == username && x.Password == hashedPassword).First();

            if (user != null)
            {
                CurrentUser = user;
                return true;
            }
            else
                return false;
        }

        public string GetUserSalt(string username)
        {
            return _PassBoxContext.Users.Where(x => x.Username == username).First().PersonalSalt.ToString();
        }

        public string GetCurrentUsername()
        {
            if (CurrentUser != null)
                return CurrentUser.Username;
            else 
                return "";
        }
        public User GetCurrentUser()
        {
            if (CurrentUser != null)
                return CurrentUser;
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Logout()
        {
            CurrentUser = null;
            if (CurrentUser == null)
                return true;
            else 
                return false;
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

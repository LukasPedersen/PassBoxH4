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
        /// Creates a new user given the <paramref name="username"/>, <paramref name="hashedPassword"/>, <paramref name="personalSalt"/>, parameters
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
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Will try to login the <see cref="User"/> with the given <paramref name="username"/> <see langword="and"/> <paramref name="hashedPassword"/>
        /// </summary>
        /// <returns><see langword="true"/> if logedin else <see langword="false"/></returns>
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

        /// <summary>
        /// Gets users <see langword="salt"/> by the given <paramref name="username"/>
        /// </summary>
        /// <param name="username"></param>
        /// <returns><see cref="string"/> contaning <see cref="User"/>'s <see langword="salt"/></returns>
        public string GetUserSalt(string username)
        {
            return _PassBoxContext.Users.Where(x => x.Username == username).First().PersonalSalt.ToString();
        }

        /// <summary>
        /// Gets <see cref="CurrentUser"/>'s <see cref="User.Username"/>
        /// </summary>
        /// <returns><see cref="CurrentUser"/>'s <see cref="User.Username"/></returns>
        public string GetCurrentUsername()
        {
            if (CurrentUser != null)
                return CurrentUser.Username;
            else 
                return "";
        }

        /// <summary>
        /// Gets the current <see cref="CurrentUser"/> <see langword="object"/>
        /// </summary>
        /// <returns><see cref="User"/> CurrentUser</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public User GetCurrentUser()
        {
            if (CurrentUser != null)
                return CurrentUser;
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// Logout current user
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
        /// Check if <see cref="CurrentUser"/> is <see langword="null"/>
        /// </summary>
        /// <returns><see langword="true"/> if <see cref="CurrentUser"/> != <see langword="null"/> else return <see langword="false"/></returns>
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

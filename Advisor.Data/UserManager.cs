using System;
using System.Security.Cryptography;
using System.Text;
using Advisor.Dal;
using Advisor.Dal.Domain;

namespace Advisor.Data
{
    public class UserManager :
        IUserManager
    {
        public User Register(string login, string password)
        {
            using (var da = new UserDa())
            {
                var user = da.GetFirst(u => u.Login == login);
                if (user != null)
                    return null;

                user = new User
                {
                    Login = login,
                    PasswordHash = CalculateHash(password)
                };

                return da.Save(user);
            }
        }

        public User Verify(string login, string password)
        {
            using (var da = new UserDa())
            {
                var user = da.GetFirst(u => u.Login == login);
                if (user == null)
                    return null;

                var testHash = CalculateHash(password);
                if (testHash != user.PasswordHash)
                    return null;

                return user;
            }
        }

        public User GetById(int id)
        {
            using (var da = new UserDa())
            {
                return da.GetById(id);
            }
        }

        private string CalculateHash(string password)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = algorithm.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
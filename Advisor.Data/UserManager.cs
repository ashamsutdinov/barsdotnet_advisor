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
        public User Register(string login, string password,string name,string sirname,string email,string info)
        {
            using (var da = new UserDa())
            {
                //не дает регистрировать пользователей с тем же логином
                var user = da.GetFirst(u => u.Login == login);
                if (user != null)
                    return null;
                
                user = new User
                {
                    Login = login,
                    PasswordHash = CalculateHash(password),
                    Name = name,
                    Sirname = sirname,
                    Email = email,
                    Info = info
                };
                return da.Save(user);
            }
        }

        //проверка, что пользователь зарегистрирован
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

        public User Get(int id)
        {
            using (var da = new UserDa())
            {
                return da.GetById(id);
            }
        }

        public User Get(string login)
        {
            using (var da = new UserDa())
            {
                var user = da.GetFirst(u => u.Login == login);//поиск в таблице по запросу.
                return user;
            }
        }
        
        public User ChangeLogin(string oldLogin, string newLogin)
        {
            using (var da = new UserDa())
            {
                var user=this.Get(oldLogin);
                user.Login = newLogin;
                return da.Save(user);
            } 
        }
        //если передан не тот пароль
        public User ChangePassword(string login, string oldPassword, string newPassword)
        {
            using (var da = new UserDa())
            {
                var user = this.Get(login);
                if (user.PasswordHash == this.CalculateHash(oldPassword))
                {
                    user.PasswordHash = this.CalculateHash(newPassword);
                    return da.Save(user);
                }
                else return user;
            } 
        }

        public User ChangeData(int id, string newName, string newSirname, string newEmail, string newInfo)
        {
            using (var da = new UserDa())
            {
                var user = this.Get(id);
                user.Name = newName;
                user.Sirname = newSirname;
                user.Email = newEmail;
                user.Info = newInfo;
                return da.Save(user);
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
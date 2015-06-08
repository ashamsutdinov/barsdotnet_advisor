﻿using System;
using System.Security.Cryptography;
using System.Text;
using Advisor.Dal;
using Advisor.Dal.Domain;
using System.Collections.Generic;

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
        
        public User ChangeLogin(int id, string newLogin)
        {
            using (var da = new UserDa())
            {
                var user=this.Get(id);
                if (user != null)
                {
                    user.Login = newLogin;
                    return da.Save(user);
                }
                return user;
            } 
        }

        //занимается еще и тем, что проверяет, тот ли старый пароль
        //если передан не тот пароль
        public User ChangePassword(int id, string oldPassword, string newPassword)
        {
            using (var da = new UserDa())
            {
                var user = this.Get(id);
                if (user==null || user.PasswordHash == this.CalculateHash(oldPassword))
                {
                    user.PasswordHash = this.CalculateHash(newPassword);
                    return da.Save(user);
                }
                else return null;
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

        //найти товары пользователя

        public IEnumerable<Product> GetAllByOwner(int ownerId)
        {
            return Select(p => p.UserId == ownerId)
            .OrderByDescending(p => p.DateOfCreate)
            .ThenByDescending(p => p.Rating);
            //.Skip(10)
            //.Take(10);
        }
    }
}
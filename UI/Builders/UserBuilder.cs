using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Advisor.Dal.Domain;
using UI.Models;

namespace UI.Builders
{
    public class UserBuilder
        :IBuilder<UserModel,User>
    {
        public UserModel Build(User user)
        {
            UserModel um = new UserModel();
            um.Email = user.Email;
            um.Id = user.Id;
            um.Info = user.Info;
            um.Login = user.Login;
            um.Name = user.Name;
            um.Password = um.PasswordClone = "1";
            um.Sirname = user.Sirname;

            return um;
        }
    }
}
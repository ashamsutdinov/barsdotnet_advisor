using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class UserModel
        :LoginModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sirname { get; set; }

        public string Email { get; set; }

        public string Info { get; set; }

        public string PasswordClone { get; set; }
    }
}
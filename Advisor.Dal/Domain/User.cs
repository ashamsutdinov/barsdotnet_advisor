﻿namespace Advisor.Dal.Domain
{
    public class User
    {
        public virtual int Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string Name { get; set; }

        public virtual string Sirname { get; set; }

        public virtual string Email { get; set; }

        public virtual string Info { get; set; }
    }
}

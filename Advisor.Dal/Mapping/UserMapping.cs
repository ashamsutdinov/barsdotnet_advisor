﻿using Advisor.Dal.Domain;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Advisor.Dal.Mapping
{
    public class UserMapping :
        ClassMapping<User>
    {
        public UserMapping()
        {
            Table("Users");
            Id(u => u.Id, m => m.Generator(Generators.Identity));
            Property(u => u.Login);
            Property(u => u.PasswordHash);
        }
    }


}
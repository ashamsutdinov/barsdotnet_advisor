using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace Advisor.Dal
{
    public class DatabaseManager
    {
        static DatabaseManager()
        {
            var configuration = new Configuration();
            var nhConfig = configuration.Configure();
            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            nhConfig.AddMapping(domainMapping);
            SessionFactory = nhConfig.BuildSessionFactory();
        }
        public static ISessionFactory SessionFactory { get; private set; }
    }
}

using Advisor.Dal.Domain;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Advisor.Dal
{
    public class CategoryDa:
        Dao<int,Category>
    {
        public IEnumerable<string> GetAllCategories()
        {
            return this.Query().Select(p => p.Name) 
                .OrderBy(p => p)
                .ToList();
        }
    }
}

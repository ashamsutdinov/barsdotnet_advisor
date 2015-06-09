using Advisor.Dal.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Advisor.Dal
{
    public class CategoryDa:
        Dao<int,Category>
    {
        public IEnumerable<Category> GetAllCategories()
        {
            return Select(p => true)
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}

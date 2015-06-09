using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Dal.Domain;

namespace Advisor.Data
{
    public interface ICategoryManager
    {
        Category Get(int id);
        Category Add(string name, string info);
        IEnumerable<Category> GetAllCategories();
    }
}

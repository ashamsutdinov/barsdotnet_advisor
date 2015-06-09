using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Dal.Domain;
using Advisor.Dal;

namespace Advisor.Data
{
    public class CategoryManager:
        ICategoryManager
    {
        public Category Get(int id)
        {
            using (var da = new CategoryDa())
            {
                return da.GetById(id);
            }
        }

        public Category Add(string name, string info)
        {
            using (var da = new CategoryDa())
            {
                //не дает регистрировать одинаковые категории
                var category = da.GetFirst(u => u.Name == name);
                if (category != null)
                    return null;

                category = new Category
                {
                    Name = name,
                    Info = info
                };
                return da.Save(category);
            }
        }

        public IEnumerable<string> GetAllCategories()
        {
            using (var da=new CategoryDa())
            {
                return da.GetAllCategories();
            }
        }
    }
}

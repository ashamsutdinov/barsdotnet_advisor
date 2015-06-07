using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Dal.Domain;
namespace Advisor.Data
{
    public interface IProductManager
    {
        Product Add(int userId, string name, string info, int minval, int maxval, string category);
        Product Get(int id);
        Product SaveChanges(int id, string name, string info, int minval, int maxval, string category);
        bool Delete(int id);

        //взять самые популярные товары
        IEnumerable<Product> GetMostPop(int count);
        
        //
    }
}

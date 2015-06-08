using Advisor.Dal.Domain;
using System.Collections.Generic;
using NHibernate;
using System.Linq;

namespace Advisor.Dal
{
    public class ProductDa:
        Dao<int,Product>
    {

        public IEnumerable<Product> GetAllByOwner(int ownerId)
        {
            return Select(p => p.UserId == ownerId)
                .OrderByDescending(p => p.DateOfCreate)
                .ThenByDescending(p => p.Rating)
                .ToList();
                //.Skip(10)
                //.Take(10);
        }

        public IEnumerable<Product> GetMostPopular(int amount,int from)
        {
            return Select(p => true)
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.DateOfCreate)
                .Skip(from)
                .Take(amount)
                .ToList();
        }
    }
}

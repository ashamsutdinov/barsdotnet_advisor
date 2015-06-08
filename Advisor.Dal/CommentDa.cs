using Advisor.Dal.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Advisor.Dal
{
    public class CommentDa:
        Dao<int,Comment>
    {
        //получить все комментарии по событию в виде перечислимой коллекции
        public IEnumerable<Comment> GetAllByProduct(int productId)
        {
            return Select(p => p.ProductId == productId)
                .OrderByDescending(p => p.DateOfCreate)
                .ToList();
            //.Skip(10)
            //.Take(10);
        }
    }
}

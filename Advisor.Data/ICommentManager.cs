using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Dal.Domain;

namespace Advisor.Data
{
    public interface ICommentManager
    {
        Comment Get(int AuthorId, int ProductId);
        Comment Add(int AuthorId, int ProductId, string Text);
        IEnumerable<Comment> GetAllByProduct(int productId);
    }
}

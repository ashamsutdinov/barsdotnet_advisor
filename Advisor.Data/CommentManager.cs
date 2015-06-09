using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Dal.Domain;
using Advisor.Dal;

namespace Advisor.Data
{
    public class CommentManager
        :ICommentManager
    {
        public Comment Add(int AuthorId, int ProductId, string Text)
        {
            using (CommentDa da = new CommentDa())
            {
                //
                var comment = new Comment
                {
                    UserId = AuthorId,
                    ProductId = ProductId,
                    Text = Text,
                    DateOfCreate = DateTime.Now
                };
                return da.Save(comment);
            }
        }

        public IEnumerable<Comment> GetAllByProduct(int productId)
        {
            using (CommentDa da = new CommentDa())
            {
                return da.GetAllByProduct(productId);
            }
        }
        public Comment Get(int AuthorId, int ProductId)
        {
            using (CommentDa da = new CommentDa())
            {
                return da.Select(p=>(p.ProductId==ProductId && p.UserId==AuthorId))
                    .FirstOrDefault();
            }
        }
    }
}

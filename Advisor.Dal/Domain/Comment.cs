using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Dal.Domain
{
    public class Comment
    {
        public virtual int Id { get; set; }

        public virtual DateTime DateOfCreate { get; set; }

        public virtual int AuthorId { get; set; }

        public virtual int ProductId { get; set; }

        public virtual string Text { get; set; }

        //-----
        public virtual User Author { get; set; }
        public virtual Product Product { get; set; }
    }
}

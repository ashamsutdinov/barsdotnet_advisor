using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Dal.Domain
{
    public class Product
    {
        public virtual int Id { get; set; }

        public virtual int UserId { get; set; }

        public virtual string Info { get; set; }

        public virtual int MinValue { get; set; }

        public virtual int MaxValue { get; set; }

        public virtual DateTime DateOfCreate { get; set; }

        public virtual string Name { get; set; }

        public virtual int CategoryId { get; set; }

        public virtual double Rating { get; set; }

        //----
        //public virtual IList<Comment> Comments { get; set; }
        //public virtual Category Category { get; set; }
        //public virtual User User { get; set; }
        //public virtual IList<Rating> Ratings { get; set; }
        //public virtual IList<ProductPhoto> ProductPhotos { get; set; }

    }
}

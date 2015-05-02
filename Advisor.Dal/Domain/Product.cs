using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Dal.Domain
{
    class Product
    {
        public virtual int Id { get; set; }

        public virtual int UserId { get; set; }

        public virtual string Info { get; set; }

        public virtual int MinValue { get; set; }

        public virtual int MaxValue { get; set; }

        public virtual DateTime DateOfCreate { get; set; }

        public virtual string Name { get; set; }

        public virtual int CategoryId { get; set; }
    }
}

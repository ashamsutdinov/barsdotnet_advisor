using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Dal.Domain
{
    public class Rating
    {
        public virtual int Id { get; set; }

        public virtual int Value { get; set; }

        public virtual int UserId { get; set; }

        public virtual int ProductId { get; set; }
    }
}

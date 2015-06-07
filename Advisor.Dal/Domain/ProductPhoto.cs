using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Dal.Domain
{
    public class ProductPhoto
    {
        public virtual int Id { get; set; }

        public virtual byte[] Photo { get; set; }

        public virtual string MimeType { get; set; }

        public virtual int ProductId { get; set; }
        

        //---
        public virtual Product Product { get; set; }
    }
}

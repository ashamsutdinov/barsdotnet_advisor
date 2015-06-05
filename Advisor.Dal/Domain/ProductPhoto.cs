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

        //какой тип данных?
        public virtual Object Photo { get; set; }
        //!!!!!

        public virtual int ProductId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Dal.Domain
{
    //это рейтинг товара, а никак не usera. Просто тут хранится автор оценки
    public class Rating
    {
        public virtual int Id { get; set; }

        public virtual int Value { get; set; }

        public virtual int UserId { get; set; }

        public virtual int ProductId { get; set; }

        //--
        //public virtual User Author { get; set; }
        //public virtual Product Product { get; set; }
    }
}

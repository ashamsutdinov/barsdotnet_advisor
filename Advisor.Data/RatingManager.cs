using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Dal;
using Advisor.Dal.Domain;

namespace Advisor.Data
{
    public class RatingManager
        :IRatingManager
    {
        public Rating Add(int UserId, int ProductId, int Value)
        {
            double count;
            using (RatingDa da = new RatingDa())
            {
                 count=da.Select(p => p.ProductId == ProductId)
                     .ToList().Count();
            }
            using (ProductDa da = new ProductDa())
            {
                var product=da.GetById(ProductId);
                if (count == 0) product.Rating = Value;
                else
                    product.Rating = (product.Rating * count + Value) / (count + 1);
            }
            using (RatingDa da = new RatingDa())
            {
                //
                var rating = new Rating
                {
                    UserId = UserId,
                    ProductId = ProductId,
                    Value = Value
                };
                return da.Save(rating);
            }
        }
        public Rating Get(int AuthorId, int ProductId)
        {
            using (RatingDa da = new RatingDa())
            {
                return da.Select(p => ((p.ProductId == ProductId) && (p.UserId == AuthorId)))
                    .FirstOrDefault();
            }
        }
    }
}

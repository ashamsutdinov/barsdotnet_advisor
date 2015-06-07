using Advisor.Dal.Domain;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Advisor.Dal.Mapping
{
    public class ProductMapping:
        ClassMapping<Product>
    {
        public ProductMapping()
        {
            Table("Products");
            Id(u => u.Id, m => m.Generator(Generators.Identity));
            Property(u => u.UserId);
            Property(u => u.MaxValue);
            Property(u => u.Name);
            Property(u => u.MinValue);
            Property(u => u.DateOfCreate);
            Property(u => u.Info);
            Property(u => u.CategoryId);
            Property(u => u.Rating);

            //---
            Bag(x => x.Comments, map => map.Key(km => km.Column("ProductId")), rel => rel.OneToMany());
            Bag(x => x.Ratings, map => map.Key(km => km.Column("ProductId")), rel => rel.OneToMany());
            Bag(x => x.ProductPhotos, map => map.Key(km => km.Column("ProductId")), rel => rel.OneToMany());
            
            ManyToOne(x => x.Category, map => map.Column("CategoryId"));
            ManyToOne(x => x.User, map => map.Column("UserId"));
        }
    }
}

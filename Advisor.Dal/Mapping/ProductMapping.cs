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
        }
    }
}

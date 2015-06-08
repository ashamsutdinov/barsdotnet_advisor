using Advisor.Dal.Domain;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Advisor.Dal.Mapping
{
    public class CategoryMapping:
         ClassMapping<Category>
    {
        public CategoryMapping()
        {
            Table("Categories");
            Id(u => u.Id, m => m.Generator(Generators.Identity));
            Property(u => u.Name);
            Property(u => u.Info);

            //---
            //Bag(x => x.Products, map => map.Key(km => km.Column("CategoryId")), rel => rel.OneToMany());
        }
    }
}

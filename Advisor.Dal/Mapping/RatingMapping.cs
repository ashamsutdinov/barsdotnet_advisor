using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Advisor.Dal.Domain;

namespace Advisor.Dal.Mapping
{
    class RatingMapping:
        ClassMapping<Rating>
    {
        public RatingMapping()
        {
            Table("Ratings");
            Id(u => u.Id, m => m.Generator(Generators.Identity));
            Property(u => u.Value);
            Property(u => u.UserId);
            Property(u => u.ProductId);
        }
    }
}

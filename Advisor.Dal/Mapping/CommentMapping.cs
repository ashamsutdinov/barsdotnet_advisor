using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Advisor.Dal.Domain;

namespace Advisor.Dal.Mapping
{
    public class CommentMapping:
        ClassMapping<Comment>
    {
        public CommentMapping()
        {
            Table("Comments");
            Id(u => u.Id, m => m.Generator(Generators.Identity));
            Property(u => u.DateOfCreate);
            Property(u => u.UserId);
            Property(u => u.ProductId);
            Property(u => u.Text);

            //----
            //ManyToOne(x => x.Author, map => map.Column("UserId"));
            //ManyToOne(x => x.Product, map => map.Column("ProductId"));
        }
    }
}

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Advisor.Dal.Domain;

namespace Advisor.Dal.Mapping
{
    class CommentMapping:
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
            ManyToOne(x => x.User, map => map.Column("UserId"));
        }
    }
}

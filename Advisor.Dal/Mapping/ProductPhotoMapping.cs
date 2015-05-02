﻿using Advisor.Dal.Domain;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Advisor.Dal.Mapping
{
    class ProductPhotoMapping:
        ClassMapping<ProductPhoto>
    {
        public ProductPhotoMapping()
        {
            Table("ProductPhotos");
            Id(u => u.Id, m => m.Generator(Generators.Identity));
            Property(u => u.Photo);
            Property(u => u.ProductId);
        }
    }
}

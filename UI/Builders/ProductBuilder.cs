using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Advisor.Dal.Domain;
using UI.Models;
using Advisor.Data;

namespace UI.Builders
{
    public static class ProductBuilder
    {
        public static ProductModel Build(Product product)
        {
            ProductModel pm = new ProductModel();
            pm.Id = product.Id;
            pm.Info = product.Info;
            pm.MaxValue = product.MaxValue;
            pm.MinValue = product.MinValue;
            pm.Name = product.Name;
            pm.UserId = product.UserId;

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //pm.Category = product.Category.Name;
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            ICategoryManager a = Services.Factory.Get<ICategoryManager>();
            pm.Category = a.Get(product.CategoryId).Name;

            pm.DateOfCreate = product.DateOfCreate;
            return pm;
        }
    }
}
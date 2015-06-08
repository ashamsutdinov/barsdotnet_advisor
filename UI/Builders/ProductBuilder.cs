using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Advisor.Dal.Domain;
using UI.Models;
using Advisor.Data;

namespace UI.Builders
{
    public class ProductBuilder
        :IBuilder<ProductModel,Product>
    {
        private readonly ICategoryManager _categoryManager = Services.Factory.Get<ICategoryManager>();
        private readonly IUserManager _userManager = Services.Factory.Get<IUserManager>();

        public ProductModel Build(Product product)
        {
            ProductModel pm = new ProductModel();
            pm.Id = product.Id;
            pm.Info = product.Info;
            pm.MaxValue = product.MaxValue;
            pm.MinValue = product.MinValue;
            pm.Name = product.Name;
            pm.Rating = product.Rating;

            pm.UserLogin = _userManager.Get(product.UserId).Login;
            pm.Category = _categoryManager.Get(product.CategoryId).Name;

            pm.DateOfCreate = product.DateOfCreate;
            return pm;
        }

        public IEnumerable<ProductModel> BuildIEnumerable(IEnumerable<Product> products)
        {
            List<ProductModel> res = new List<ProductModel>();
            foreach(Product p in products)
            {
                res.Add(this.Build(p));
            }
            return res;
        }
    }
}
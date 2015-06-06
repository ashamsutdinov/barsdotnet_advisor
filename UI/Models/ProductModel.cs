using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Advisor.Dal.Domain;
using Advisor.Data;

namespace UI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Info { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public DateTime DateOfCreate { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        //вопроооооос, куда запихать
        public static ProductModel FromDomainProduct(Product product)
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
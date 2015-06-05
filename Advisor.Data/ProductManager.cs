using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advisor.Dal;
using Advisor.Dal.Domain;

namespace Advisor.Data
{
    public class ProductManager:
        IProductManager
    {
        //найти товары пользователя
        public IQueryable<Product> GetProducts(int UserId)
        {
            using (var da = new ProductDa())
            {
              IQueryable <Product> Prods= da.Select(p=>p.UserId==UserId);          
              return Prods;
            }
        }
        //взять самые популярные товары
        public IQueryable<Product> GetMostPop()
        {
            //доделать
            return null;
        }
        
    }
}

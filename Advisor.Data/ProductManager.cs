using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advisor.Dal;
using Advisor.Dal.Domain;
//using Advisor.Dal.ProductDa;

namespace Advisor.Data
{
    public class ProductManager:
        IProductManager
    {
        public Product Get(int id)
        {
            using (var da = new ProductDa())
            {
                return da.GetById(id);
            }
        }

        //добавить новый продукт
        public Product Add(int userId, string name, string info, int minval, int maxval, string category)
        {
            using (var da = new ProductDa())
            {
                Category c;
                using (var cda = new CategoryDa())//определяем категорию товара.
                {
                    c = cda.GetFirst(u => u.Name == category);
                    if (c == null)//если введенной категории не существует
                    {
                        /*c = new Category
                        {
                            Info = "Пользовательская категория",
                            Name = category
                        };
                        cda.Save(c);
                        categor = c.Id;*/
                        return null;
                    }
                }
                Product product = new Product
                {
                    UserId = userId,
                    Name = name,
                    Info = info,
                    MinValue = minval,
                    MaxValue = maxval,
                    CategoryId = c.Id,
                    DateOfCreate = DateTime.Today,
                    Rating=0
                };
                /*using (var pda = new ProductPhotoDa())//добавляем фотографию
                {
                    ProductPhoto ph = new ProductPhoto
                    {
                        ProductId = product.Id,

                    };
                    pda.Save(ph);
                }*/
                return da.Save(product);
            }
        }

        public Product SaveChanges(int id,string name, string info, int minval, int maxval, string category)
        {
            using (var da = new ProductDa())
            {
                int categor;
                using (var cda = new CategoryDa())//определяем категорию товара.
                {
                    Category c = cda.GetFirst(u => u.Name == category);
                    if (c == null)//если введенной категории не существует
                    {
                        return null;
                    }
                    categor = c.Id;
                }
                var product = this.Get(id);
                if (product!=null)
                {
                    product.CategoryId = categor;
                    product.Info = info;
                    product.MaxValue = maxval;
                    product.MinValue = minval;
                    product.Name = name;
                    return da.Save(product);
                }
                return null;
            }
        }

        public bool Delete(int id)
        {
            using (var da = new ProductDa())
            {
                var product = da.GetById(id);
                if (product == null) return false;
                da.Delete(product);
                return true;
            }
        }


       
        //взять самые популярные товары
         public IEnumerable<Product> GetMostPop(int amount,int from)
         {
             using (var da = new ProductDa())
             {
                 return da.GetMostPopular(amount,from);
             }
         }
    }
}

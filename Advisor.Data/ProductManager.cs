﻿using System;
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
                    CategoryId =c.Id,
                    DateOfCreate = DateTime.Today
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
        public Product SaveChanges(int id, string name, string info, int minval, int maxval, string category)
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
                if (product != null)
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
    }
}

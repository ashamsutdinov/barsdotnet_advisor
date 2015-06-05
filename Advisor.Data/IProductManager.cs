using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Dal.Domain;
namespace Advisor.Data
{
    public interface IProductManager
    {
        IQueryable<Product> GetProducts(int UserId);
        //найти товары пользователя
        IQueryable<Product> GetMostPop();
        //взять самые популярные товары
    }
}

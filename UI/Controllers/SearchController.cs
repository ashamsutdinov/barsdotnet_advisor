using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Advisor.Data;
using UI.Builders;
using UI.Models;

namespace UI.Controllers
{
    public class SearchController : ControllerBase
    {
        private readonly IProductManager _productManager
            = Services.Factory.Get<IProductManager>();
        private readonly ProductBuilder _productBuilder
            = new ProductBuilder();


        // GET: Search
        public ActionResult Index()
        {
            return View();
        }




        private const int amount = 2;//можно изменить(чтобы показать и похвастаться))

        //показать самые популярные
        public ActionResult Top(int? id)
        {
            int from;
            if (id == null || (int)id == 1)
            {
                ViewBag.page = 1;
                from = 0;
            }
            else
            {
                from = amount * ((int)id - 1);
                ViewBag.page = (int)id;
            }
            IEnumerable<ProductModel> pm=_productBuilder.BuildIEnumerable(_productManager.GetMostPop(amount,from));
            return View(pm); 
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Advisor.Data;
using UI.Models;
using System.Web.Security;
using Advisor.Dal.Domain;


namespace UI.Controllers
{
    public class ProductDataController : ControllerBase
    {
        private readonly IProductManager _productManager
            = Services.Factory.Get<IProductManager>();

        //главная страница продукта
        public ActionResult Index()
        {
            return View();
        }

        //!!!!!
        //изменение продукта
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var product = _productManager.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductModel model = ProductModel.FromDomainProduct(product);
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
                //пусть пока сюда
            }
            return View();
        }




        


        //на этот метод приходят user, когда вбивает в командной строке
        public ActionResult Add()
        {
            if (CurrentUser == null)
            {//надо зарегаться чтобы добавлять что-либо
                //поэтому просто выкинем человека на главную Х)
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                _productManager.Add(CurrentUser.Id, model.Name, model.Info, model.MinValue, model.MaxValue, model.Category, "");
                //фотка нужна
                return Redirect("/");
            }
            return View();
        }
    }
}
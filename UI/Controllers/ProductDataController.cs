using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Advisor.Data;
using UI.Models;
using System.Web.Security;


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

        //изменение продукта
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            //пусть пока сюда
            return Redirect("/");
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
                //return Content("Ваш товар добавлен");
                return Redirect("/");
            }
            return View();
        }
    }
}
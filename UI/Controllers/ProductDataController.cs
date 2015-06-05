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

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Change()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductModel model)
        {
            if (CurrentUser == null)
            {//надо зарегаться чтобы добавлять что-либо
                ModelState.AddModelError("Name", "Вы не зарегистрированы!!");
                return View();
            }
            else
            {
                _productManager.Add(CurrentUser.Id, model.Name, model.Info, model.MinValue, model.MaxValue, model.Category, "");
               //фотка нужна
                //return Content("Ваш товар добавлен");
                return Redirect("/");
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Advisor.Data;
using UI.Models;
using System.Web.Security;
using Advisor.Dal.Domain;
using UI.Builders;


namespace UI.Controllers
{
    public class ProductDataController : ControllerBase
    {
        private readonly IProductManager _productManager
            = Services.Factory.Get<IProductManager>();
        private readonly ProductBuilder _productBuilder
            = new ProductBuilder();

        //главная страница продукта
        public ActionResult Index(int id)
        {
            var product=_productManager.Get(id);
            return View(_productBuilder.Build(product));
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
            
            ProductModel model = _productBuilder.Build(product);
            return View(model);
        }

        //тут еще нет, собсственно сохранения
        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                _productManager.SaveChanges(model.Id, model.Name, model.Info, model.MinValue, model.MaxValue, model.Category);
                return Redirect("/");
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
                _productManager.Add(CurrentUser.Id, model.Name, model.Info, model.MinValue, model.MaxValue, model.Category);
                //фотка нужна
                return Redirect("/");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();//пусть так
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            _productManager.Delete((int)id);
            return RedirectToAction("Index");
        }


        public ActionResult MyProducts()
        {
            //или как тут?)
            //List<Product> prods = _productManager.Get(CurrentUser.Id)
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
//using ImageDbApp.Models;
using System.IO;
using System.Web.Security;
using Advisor.Dal.Domain;
using UI.Builders;
using Advisor.Data;
namespace UI.Controllers
{
    public class ProductPhotoController:ControllerBase
    {
        private readonly IProductManager _productManager
            = Services.Factory.Get<IProductManager>();
        private readonly IProductPhotoManager _photoManager
            = Services.Factory.Get<IProductPhotoManager>();

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var product = _photoManager.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View();//здесь дописать билдер потом
        }
        //добавить фото
        [HttpPost]
        public ActionResult Add(int? productid)
        {
            Product pr = _productManager.Get(productid.Value);
            //не понимаю почему ругается на просто productid
            if ((pr== null) || (pr.UserId!=CurrentUser.Id))
            {//если нет такого товара, или это не его товар, то выкинуть!
                return Redirect("/");
            }
            return View();
        }
        public ActionResult Add(int? productid, ProductPhotosModel model, HttpPostedFileBase image)
        {
            Product pr = _productManager.Get(productid.Value);

            if ((pr== null) || (pr.UserId!=CurrentUser.Id))
            {
                if (ModelState.IsValid && image != null)
                {
                    byte[] imageData = null;
                    model.MimeType = image.ContentType;
                    model.Photo = new byte[image.ContentLength];
                    image.InputStream.Read(model.Photo, 0, image.ContentLength);
                    model.Photo = imageData;
                    _photoManager.Add(model.Photo, model.MimeType, productid.Value);

                    TempData["message"] = string.Format("фото услуги было сохранено");
                    return RedirectToAction("Index");
                }
                else
                    return Redirect("/");
            }
            else
              return View();

            
        }
    }
}
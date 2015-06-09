using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
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
        {//показать фото товара по заданному id
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                Product pr = _productManager.Get((int)id);
                if (pr == null)
                {
                    return HttpNotFound();
                }
                else
                    return View(_photoManager.GetPhotos(pr.Id));
            }
        }
        //добавить фото
        
        public ActionResult Add(int? id)
        {
            if (id == null)
                return Redirect("/");
            else
            {
                Product pr = _productManager.Get((int)id);

                if ((pr == null) || (CurrentUser == null)||(pr.UserId != CurrentUser.Id))
                {//если нет такого товара, или это не его товар, то выкинуть!
                    return Redirect("/");
                }
                else
                {
                    ProductPhotoModel model=new ProductPhotoModel();
                    model.ProductId = (int)id;
                    return View(model);
                }
                
            }
        }
        [HttpPost]
        public ActionResult Add(ProductPhotoModel model, HttpPostedFileBase image)
        {            
                if (ModelState.IsValid && image != null)
                {
                    /*byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(image.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(image.ContentLength);
                    }
                    model.MimeTypePhoto = image.ContentType;
                    model.Photo = imageData;
                    
                    */
                    model.MimeTypePhoto = image.ContentType;
                    model.Photo = new byte[image.ContentLength];
                    image.InputStream.Read(model.Photo, 0, image.ContentLength);

                    _photoManager.Add(model.Photo, model.MimeTypePhoto, model.Id);
                    
                    TempData["message"] = string.Format("фото услуги было сохранено");
                    return RedirectToAction("Index");
                }
                else
                    return View(model);
            
        }
    }
}
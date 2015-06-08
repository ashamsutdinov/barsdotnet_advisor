using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using System.Web.Security;
using Advisor.Dal.Domain;
using UI.Builders;
using Advisor.Data;

namespace UI.Controllers
{
    public class ProductDataController : ControllerBase
    {
        private readonly IProductManager _productManager
            = Services.Factory.Get<IProductManager>();
        private readonly ProductBuilder _productBuilder
            = new ProductBuilder();
 
        private readonly ICommentManager _commentManager
            = Services.Factory.Get<ICommentManager>();
        private readonly CommentBuilder _commentBuilder
            = new CommentBuilder();

        private readonly IUserManager _userManager
         = Services.Factory.Get<IUserManager>();

        private readonly IProductPhotoManager _photoManager
            = Services.Factory.Get<IProductPhotoManager>();

        //+
        //главная страница продукта
        public ActionResult Index(int? id)
        {
            if (id==null)
            {
                return Redirect("/");
            }
            var product=_productManager.Get((int)id);
            if (product==null)
            {
                return HttpNotFound();
            }
            return View(_productBuilder.Build(product));
        }

        //+
        //добавление комментария        
        [HttpPost, ActionName("Index")]
        public ActionResult AddComment(ProductModel model,String Comment)
        {
            //тут добавляется комментарий
            _commentManager.Add(CurrentUser.Id, model.Id, Comment);
            return Redirect("/ProductData/Index/"+model.Id);
        }

        //+
        public ActionResult Comments(int? id)
        {
            if (id==null)
            {
                return Redirect("/");
            }
            if (_productManager.Get((int)id) != null)
            {
                return View(_commentBuilder.BuildIEnumerable(_commentManager.GetAllByProduct((int)id)));
            }
            return HttpNotFound();
        }

        //+
        //изменение продукта
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return Redirect("/");
            }
            var product = _productManager.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            
            ProductModel model = _productBuilder.Build(product);
            return View(model);
        }

        //+
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
        public ActionResult Add(ProductModel model,HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Product p = _productManager.Add(CurrentUser.Id, model.Name, model.Info, model.MinValue, model.MaxValue, model.Category);
                if (image != null)
                {//если есть изображение, то добавляем его в базу
                    ProductPhoto Photo = new ProductPhoto();
                    Photo.MimeType = image.ContentType;
                    Photo.Photo = new byte[image.ContentLength];
                    image.InputStream.Read(Photo.Photo, 0, image.ContentLength);
                    Photo=_photoManager.Add(Photo.Photo, Photo.MimeType, p.Id);
                    model.PhotosId.Add(Photo.Id);
                    //а также ее id к модели
                }
                TempData["message"] = string.Format("{0} has been saved", p.Name);
                return Redirect("ProductData/Index"+model.Id);
            }
            else
            {//что-то пошло не так
                return View();
            }
        }


        //потом добавить список изображений
        public FileContentResult GetImage(int productId)
        {
            Product prod = _productManager.Get(productId);
            List<FileContentResult> ListPhotos = new List<FileContentResult>();
            //Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                //     return File(prod.ImageData, prod.ImageMimeType);
                foreach (var p in _photoManager.GetPhotos(productId))
                { ListPhotos.Add(File(p.Photo, p.MimeType));  }
                return ListPhotos[ListPhotos.Count-1];
            }
            else
            {
                return null;
            }
        }

        //-
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
    }
}
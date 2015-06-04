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
    public class UserDataController : ControllerBase
    {
        private readonly IUserManager _userManager
            = Services.Factory.Get<IUserManager>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if (model.Password == model.PasswordClone)
            {
                _userManager.Register(model.Login, model.Password, model.Name, model.Sirname, model.Email, model.Info);
                //return Content("Вы зарегистрированы");
                return Redirect("/UserData/Index");
            }
            //тут прописывается ошибка
            ModelState.AddModelError("Password", "Введенные пароли не совпадают");
            return View();
        }

        public ActionResult Edit()
        {
            if (this.CurrentUser != null)
            {
                return View();
            }
            else return Redirect("/");
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            _userManager.ChangeData(model.Id, model.Name, model.Sirname, model.Email, model.Info);
            
            //return Content("Данные изменены");
            return Redirect("/UserData/Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Advisor.Data;
using UI.Models;
using System.Web.Security;
using UI.Builders;

namespace UI.Controllers
{
    public class UserDataController : ControllerBase
    {
        private readonly IUserManager _userManager
            = Services.Factory.Get<IUserManager>();
        private readonly UserBuilder _userBuilder
            =new UserBuilder();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            if (CurrentUser == null)
            {
                return View();
            }
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                //если такой уже есть, то вернет Null
                var user = _userManager.Register(model.Login, model.Password, model.Name, model.Sirname, model.Email, model.Info);
                if (user == null)
                {
                    ModelState.AddModelError("Login", "Введенный логин не уникален");
                    return View();
                }
                return Redirect("/UserData/Index");
            }

            return View();
        }

        public ActionResult Edit()
        {
            if (this.CurrentUser != null)
            {
                return View(_userBuilder.Build(CurrentUser));
            }
            else return Redirect("/");
        }
        
        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Get(model.Login);
                if (user == null || user.Id==model.Id)
                {
                    _userManager.ChangeLogin(model.Id, model.Login);
                    _userManager.ChangeData(model.Id, model.Name, model.Sirname, model.Email, model.Info);
                    //return Redirect("/UserData/Index");
                    ModelState.AddModelError("","Изменения сохранены");
                    return View();
                }
                ModelState.AddModelError("Login", "Такой логин уже существует");
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditPassword(UserModel model, string oldPassword)
        {
            if (ModelState.IsValid)
            {
                var user=_userManager.ChangePassword(model.Id, oldPassword, model.Password);
                if (user != null)//если пароль верен
                {
                    return Redirect("/UserData/Index");
                }
                ViewBag.oldPasswordMessage = "Введенный пароль неверен";
                return View("Edit");
            }
            return View("Edit");
        }
    }
}
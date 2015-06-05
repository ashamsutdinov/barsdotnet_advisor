﻿using System;
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
                //if (model.Password == model.PasswordClone)
                {
                    var user = _userManager.Register(model.Login, model.Password, model.Name, model.Sirname, model.Email, model.Info);
                    //return Content("Вы зарегистрированы");
                    if (user == null)
                    {
                        ModelState.AddModelError("Login", "Введенный логин не уникален");
                        return View();
                    }
                    return Redirect("/UserData/Index");
                }
                //тут прописывается ошибка
                //ModelState.AddModelError("Password", "Введенные пароли не совпадают");
                //return View();
            }
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
            //все не так просто

            _userManager.ChangeData(model.Id, model.Name, model.Sirname, model.Email, model.Info);
            
            //return Content("Данные изменены");
            return Redirect("/UserData/Index");
        }
    }
}
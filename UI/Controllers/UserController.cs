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
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager 
            = Services.Factory.Get<IUserManager>();

        public ActionResult Login()
        {
            if (CurrentUser == null)
            {
                FormsAuthentication.SignOut();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Verify(model.Login, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный пароль или логин");
                    return View();
                }
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                return Redirect("/");
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        /*public ActionResult Current()
        {
            return Json(CurrentUser, JsonRequestBehavior.AllowGet);
        }*/

    }
}
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;
using Advisor.Data;
using Advisor.Dal.Domain;


namespace UI.Controllers
{
    public abstract class ControllerBase :
       Controller
    {
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
            ViewBag.IsAuthorized = false;
            try
            {
                var userManager = Services.Factory.Get<IUserManager>();
                var userid =
                    FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                var id = int.Parse(userid);
                CurrentUser = userManager.Get(id);
                filterContext.Principal = new GenericPrincipal(
                    new GenericIdentity(id.ToString()), new string[] { });
                ViewBag.IsAuthorized = true;
                ViewBag.Login = CurrentUser.Login;
                ViewBag.UserId = CurrentUser.Id;
            }
            catch
            {

            }
        }

        protected User CurrentUser { get; private set; }
    }
}
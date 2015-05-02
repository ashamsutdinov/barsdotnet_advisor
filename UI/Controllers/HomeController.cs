using System.Web.Mvc;
using Advisor.Data;
using Advisor.Dal.Domain;

using Advisor.Dal;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {         
            UserManager u = new UserManager();
            User us = u.GetById(1);
            ViewBag.Sirname = us.Sirname;
            return View();
        }
    }
}

using System.Web.Mvc;
using Advisor.Data;
using Advisor.Dal.Domain;

using Advisor.Dal;

namespace UI.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            /*UserManager u = new UserManager();
            u.Register("a", "a", "a", "a", "", "");*/
            return View();
        }
    }
}

using System.Web.Mvc;

namespace Web_CMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Admin/Login");
        }
    }
}
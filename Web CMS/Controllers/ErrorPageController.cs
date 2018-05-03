using System.Web.Mvc;

namespace Web_CMS.Controllers
{
    public class ErrorPageController : Controller
    {
        public ActionResult HttpError403(string message)
        {
            return View("UnauthorizedAccess", message);
        }
        public ActionResult HttpError404(string message) {
            return View("NotFound", message);
        }
        public ActionResult HttpError500(string message) {
            return View("ServerError", message);
        }
    }
}
using System.Web.Mvc;

namespace Web_CMS.Controllers
{
    public class ErrorPageController : Controller
    {
        public ActionResult HttpError403(string message)
        {
            return View("~/Views/ErrorPage/UnauthorizedAccess", message);
        }
        public ActionResult HttpError404(string message) {
            string physicalWebRootPath = Server.MapPath("~/Views/ErrorPage");

            return View("~/Views/ErrorPage/NotFound", message);
        }
        public ActionResult HttpError500(string message) {
            return View("~/Views/ErrorPage/ServerError", message);
        }
    }
}
using System.Web.Mvc;

namespace Web_CMS.Controllers{
    public class ErrorPageController : Controller {
        public ActionResult HttpError403(string message)
        {
            return View("~/Views/ErrorPage/UnauthorizedAccess.cshtml", model:message);
        }
        public ActionResult HttpError404(string message) {
            return View("~/Views/ErrorPage/NotFound.cshtml", model:message);
        }
        public ActionResult HttpError500(string message) {
            return View("~/Views/ErrorPage/ServerError.cshtml", model:message);
        }
    }
}
using System.Web.Mvc;

namespace Web_CMS.Controllers {
    public class ErrorController : Controller {
        public ActionResult HttpError403(string message) {
            return View("~/Views/Error/UnauthorizedAccess.cshtml", "_Layout", model:message);
        }
        public ActionResult HttpError404(string message) {
            string test = System.Web.HttpContext.Current.Server.MapPath("~/Views/Error/NotFound.cshtml");
            return View("~/Views/Error/NotFound.cshtml", "_Layout", model:message);
        }
        public ActionResult HttpError500(string message) {
            return View("~/Views/Error/ServerError.cshtml", "_Layout", model:message);
        }
    }
}